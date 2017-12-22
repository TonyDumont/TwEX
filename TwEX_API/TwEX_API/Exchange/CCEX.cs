using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    public class CCEX
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "CCEX";
        public static string Url { get; } = "https://c-cex.com/";
        public static string USDSymbol { get; } = "USD";
        // API
        public static ExchangeApi Api { get; set; }
        private static RestClient client = new RestClient("https://c-cex.com/t");
        private static String Api_publicUrl = "/api_pub.html?a=";
        private static String Api_privateUrl = "https://c-cex.com/t/api.html?a=";
        // STATUS
        public static int ErrorCount { get; set; } = 0;
        public static DateTime LastUpdate { get; set; } = DateTime.Now;
        public static string LastMessage { get; set; } = String.Empty;
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters
        /// <summary>getmarkets
        /// <para>Get the open and available trading markets along with other meta data.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<CCEXMarket> getMarketList()
        {
            List<CCEXMarket> list = new List<CCEXMarket>();
            try
            {
                var request = new RestRequest(Api_publicUrl + "getmarkets", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketSummariesList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<CCEXMarket>>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getMarketList", "success IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>getmarkethistory
        /// <para>Latest trades that have occured for a specific market.</para>
        /// <para>Required : market - Market name (ex: SYM-MKT)</para>
        /// <para>Optional : count - Number of entries to return. Range 1-100, default is 50</para>
        /// </summary>
        public static List<CCEXMarketHistory> getMarketHistoryList(string symbol, string market, int count = 50)
        {
            List<CCEXMarketHistory> list = new List<CCEXMarketHistory>();
            try
            {
                string requestString = Api_publicUrl + "getmarkethistory" +
                    "&market=" + symbol + "-" + market +
                    "&count=" + count;

                if (symbol.ToLower() == "all" || market.ToLower() == "all")
                {
                    requestString = "/api_pub.html?a=getfullmarkethistory&count=" + count;
                }

                var request = new RestRequest(requestString, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketHistoryList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<CCEXMarketHistory>>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getMarketHistoryList", "success IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketHistoryList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>getmarketsummaries
        /// <para>Get the last 24 hour summary of all active markets.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<CCEXMarketSummary> getMarketSummariesList()
        {
            List<CCEXMarketSummary> list = new List<CCEXMarketSummary>();
            string responseString = String.Empty;
            try
            {
                var request = new RestRequest(Api_publicUrl + "getmarketsummaries", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketSummariesList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                responseString = response.Content;
                var jsonObject = JObject.Parse(responseString);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<CCEXMarketSummary>>();
                    UpdateStatus(true, "Updated Tickers");
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getMarketSummariesList", "Failed : " + jsonObject["message"], LogManager.LogMessageType.EXCHANGE);
                    UpdateStatus(true, jsonObject["message"].ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketSummariesList", LogManager.StripHTML(responseString), LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, LogManager.StripHTML(responseString));
            }
            return list;
        }

        /// <summary>getorderbook
        /// <para>Retrieve the orderbook for a given market.</para>
        /// <para>Required : market - Market name (ex: SYM-MKT)</para>
        /// <para>Required : type - Type of orders to return: "buy", "sell" or "both"(default)</para>
        /// <para>Optional : depth - Depth of an order book to retrieve. Default is 50, max is 100</para>
        /// </summary>
        public static List<CCEXOrderBookData> getOrderBookList(string symbol, string market, CCEXOrderBookType type = CCEXOrderBookType.both, int depth = 50)
        {
            List<CCEXOrderBookData> list = new List<CCEXOrderBookData>();
            try
            {
                var request = new RestRequest(Api_publicUrl + "getorderbook" +
                    "&market=" + symbol + "-" + market +
                    "&type=" + type +
                    "&depth=" + depth, Method.GET);

                if (symbol.ToLower() == "all" || market.ToLower() == "all")
                {
                    request = new RestRequest("/api_pub.html?a=getfullorderbook&depth=" + depth, Method.GET);
                    type = CCEXOrderBookType.both;
                }

                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getOrderBookList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    if (type == CCEXOrderBookType.both)
                    {
                        List<CCEXOrderBookData> buys = jsonObject["result"]["buy"].ToObject<List<CCEXOrderBookData>>();
                        List<CCEXOrderBookData> sells = jsonObject["result"]["sell"].ToObject<List<CCEXOrderBookData>>();

                        foreach (CCEXOrderBookData buy in buys)
                        {
                            buy.Type = "buy";
                            list.Add(buy);
                        }

                        foreach (CCEXOrderBookData sell in sells)
                        {
                            sell.Type = "sell";
                            list.Add(sell);
                        }
                    }
                    else
                    {
                        if (type == CCEXOrderBookType.buy)
                        {
                            List<CCEXOrderBookData> buys = jsonObject["result"]["buy"].ToObject<List<CCEXOrderBookData>>();
                            foreach (CCEXOrderBookData buy in buys)
                            {
                                buy.Type = "buy";
                                list.Add(buy);
                            }
                        }
                        else
                        {
                            List<CCEXOrderBookData> sells = jsonObject["result"]["sell"].ToObject<List<CCEXOrderBookData>>();
                            foreach (CCEXOrderBookData sell in sells)
                            {
                                sell.Type = "sell";
                                list.Add(sell);
                            }
                        }
                    }
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getOrderBookList", "success IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderBookList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        // getbalancedistribution - Exchange's wallet balance distribution for specific currency - no idea what this is for
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // ------------------------
        private static String GetApiRequest(string requestUrl)
        {
            var url = new Uri(requestUrl);
            var webreq = WebRequest.Create(url);
            var signature = GetApiSignature(Api.secret, requestUrl);
            webreq.Headers.Add("apisign", signature);
            var webresp = webreq.GetResponse();
            var stream = webresp.GetResponseStream();
            var strRead = new StreamReader(stream);
            return strRead.ReadToEnd();
        }
        private static String GetApiSignature(String key, String message)
        {
            using (var hmacsha512 = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(message));
                return string.Concat(hmacsha512.Hash.Select(b => b.ToString("x2")).ToArray());
            }
        }
        // ------------------------
        /// <summary>getbalance
        /// <para>Retrieve the balance from your account for a specific currency.</para>
        /// <para>Required : currency - Currency name (ex: BTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static CCEXBalance getBalance(string currency)
        {
            try
            {
                string requestUrl = Api_privateUrl + "getbalance" +
                    "&apikey=" + Api.key +
                    "&currency=" + currency +
                    "&nonce=" + ExchangeManager.GetNonce();

                var jsonObject = JObject.Parse(GetApiRequest(requestUrl));
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<CCEXBalance>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getBalance", "sucess IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalance", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>getbalances
        /// <para>Retrieve all balances from your account.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<CCEXBalance> getBalanceList()
        {
            List<CCEXBalance> list = new List<CCEXBalance>();
            string responseString = string.Empty;
            try
            {
                string requestUrl = Api_privateUrl + "getbalances" +
                    "&apikey=" + Api.key +
                    "&nonce=" + ExchangeManager.GetNonce();
                responseString = GetApiRequest(requestUrl);
                var jsonObject = JObject.Parse(responseString);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<CCEXBalance>>();
                    UpdateStatus(true, "Updated Balances");
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getBalanceList", "sucess IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                    UpdateStatus(true, jsonObject["message"].ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalances", ex.Message, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, responseString);
            }
            return list;
        }

        /// <summary>getopenorders
        /// <para>Get all orders that you currently have opened. A specific market can be requested.</para>
        /// <para>Required : none</para>
        /// <para>Optional : market - Market name (ex: MKT-SYM)</para>
        /// </summary>
        public static List<CCEXOrder> getOpenOrdersList(string market = "", string symbol = "")
        {
            List<CCEXOrder> list = new List<CCEXOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "getopenorders" +
                    "&apikey=" + Api.key +
                    "&nonce=" + ExchangeManager.GetNonce();

                if (market.Length > 0 && symbol.Length > 0)
                {
                    requestUrl += "&market=" + market + "-" + symbol;
                }

                var jsonObject = JObject.Parse(GetApiRequest(requestUrl));
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<CCEXOrder>>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getOpenOrdersList", "successs IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOpenOrdersList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>getorder
        /// <para>Retrieve a single order by uuid.</para>
        /// <para>Required : uuid - uuid of the buy or sell order</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static CCEXOrder getOrder(string uuid)
        {
            try
            {
                string requestUrl = Api_privateUrl + "getorder" +
                    "&apikey=" + Api.key +
                    "&uuid=" + uuid +
                    "&nonce=" + ExchangeManager.GetNonce();

                var jsonObject = JObject.Parse(GetApiRequest(requestUrl));
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<CCEXOrder>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getOrder", "successs IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrder", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>getorderhistory
        /// <para>Retrieve your order history.</para>
        /// <para>Required : none</para>
        /// <para>Optional : market - Market name (ex: MKT-SYM). If ommited, will return for all markets</para>
        /// <para>Optional : count - Number of records to return</para>
        /// </summary>
        public static List<CCEXOrder> getOrderHistoryList(string market = "", string symbol = "", int count = 0)
        {
            List<CCEXOrder> list = new List<CCEXOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "getorderhistory" +
                    "&apikey=" + Api.key +
                    "&nonce=" + ExchangeManager.GetNonce();

                if (market.Length > 0 && symbol.Length > 0)
                {
                    requestUrl += "&market=" + market + "-" + symbol;
                }
                if (count > 0)
                {
                    requestUrl += "&count=" + count;
                }

                var jsonObject = JObject.Parse(GetApiRequest(requestUrl));
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<CCEXOrder>>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getOrderHistoryList", "success IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderHistoryList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>mytrades
        /// <para>Retrieve detailed trading history.</para>
        /// <para>Required : marketid - name (ex: SYM-MKT)</para>
        /// <para>Optional : limit</para>
        /// </summary>
        public static List<CCEXTrade> getTradeList(string symbol, string market)
        {
            List<CCEXTrade> list = new List<CCEXTrade>();
            try
            {
                string requestUrl = Api_privateUrl + "mytrades" +
                    "&apikey=" + Api.key +
                    "&marketid=" + symbol.ToLower() + "-" + market.ToLower() +
                    "&nonce=" + ExchangeManager.GetNonce();

                var jsonObject = JObject.Parse(GetApiRequest(requestUrl));
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<CCEXTrade>>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getTradeList", "sucess IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTradeList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion
        #region API_PRIVATE_Setters
        /// <summary>buylimit
        /// <para>Place a buy limit order in a specific market.</para>
        /// <para>Required : market - Market name (ex: SYM-MKT)</para>
        /// <para>Required : quantity - Amount to purchase</para>
        /// <para>Required : rate - Rate at which to place the order</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static CCEXBuySellMessage setBuy(string symbol, string market, Decimal quantity, Decimal rate)
        {
            try
            {
                string requestUrl = "https://c-cex.com/t/api.html?a=buylimit&apikey=" + Api.key +
                    "&market=" + symbol + "-" + market +
                    "&quantity=" + quantity +
                    "&rate=" + rate +
                    "&nonce=" + ExchangeManager.GetNonce();

                var jsonObject = JObject.Parse(GetApiRequest(requestUrl));
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<CCEXBuySellMessage>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "setBuy", "sucess IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setBuy", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>cancel
        /// <para>Cancel a buy or sell order.</para>
        /// <para>Required : uuid - uuid of buy or sell order</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static CCEXBuySellMessage setCancel(string uuid)
        {
            try
            {
                string requestUrl = "https://c-cex.com/t/api.html?a=cancel&apikey=" + Api.key +
                    "&uuid=" + uuid +
                    "&nonce=" + ExchangeManager.GetNonce();

                var jsonObject = JObject.Parse(GetApiRequest(requestUrl));
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<CCEXBuySellMessage>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "setSell", "sucess IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setSell", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>selllimit
        /// <para>Place a sell limit order in a specific market.</para>
        /// <para>Required : market - Market name (ex: SYM-MKT)</para>
        /// <para>Required : quantity - Amount to purchase</para>
        /// <para>Required : rate - Rate at which to place the order</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static CCEXBuySellMessage setSell(string symbol, string market, Decimal quantity, Decimal rate)
        {
            try
            {
                string requestUrl = "https://c-cex.com/t/api.html?a=selllimit&apikey=" + Api.key +
                    "&market=" + symbol + "-" + market +
                    "&quantity=" + quantity +
                    "&rate=" + rate +
                    "&nonce=" + ExchangeManager.GetNonce();

                var jsonObject = JObject.Parse(GetApiRequest(requestUrl));
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<CCEXBuySellMessage>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "setSell", "sucess IS FALSE : message=" + jsonObject["message"], LogManager.LogMessageType.DEBUG);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setSell", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }
        #endregion
        #endregion API_Private

        #region ExchangeManager
        // INITIALIZE
        public static void InitializeExchange()
        {
            LogManager.AddLogMessage(Name, "InitializeExchange", "Initialized", LogManager.LogMessageType.EXCHANGE);
            updateExchangeTickerList();
        }
        // GETTERS
        public static List<ExchangeBalance> getExchangeBalanceList()
        {
            List<ExchangeBalance> list = new List<ExchangeBalance>();
            List<CCEXBalance> balanceList = getBalanceList();
            foreach (CCEXBalance balance in balanceList)
            {
                list.Add(balance.GetExchangeBalance());
            }
            return list;
        }
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();
            List<CCEXMarketSummary> tickerList = getMarketSummariesList();

            foreach (CCEXMarketSummary ticker in tickerList)
            {
                list.Add(ticker.GetExchangeTicker());
            }       
            return list;
        }
        // UPDATERS
        public static void updateExchangeBalanceList()
        {
            List<CCEXBalance> list = getBalanceList();
            ExchangeTicker btcTicker = ExchangeManager.getExchangeTicker(Name, "BTC", USDSymbol);

            foreach (CCEXBalance balance in list)
            {
                if (balance.Balance > 0)
                {
                    if (balance.Currency != "BTC" && balance.Currency != USDSymbol)
                    {
                        // GET TICKER FOR PAIR IN BTC MARKET
                        ExchangeTicker ticker = ExchangeManager.getExchangeTicker(Name, balance.Currency.ToUpper(), "BTC");

                        if (ticker != null)
                        {
                            balance.TotalInBTC = balance.Balance * ticker.last;
                            balance.TotalInUSD = btcTicker.last * balance.TotalInBTC;
                        }
                        else
                        {
                            LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "EXCHANGE TICKER WAS NULL : " + Name + " | " + balance.Currency.ToUpper());
                        }
                    }
                    else
                    {
                        //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "CHECKING CURRENCY :" + balance.Currency, LogManager.LogMessageType.DEBUG);
                        if (balance.Currency == "BTC")
                        {
                            balance.TotalInBTC = balance.Balance;
                            balance.TotalInUSD = btcTicker.last * balance.Balance;
                        }
                        else if (balance.Currency == USDSymbol)
                        {
                            if (btcTicker.last > 0)
                            {
                                balance.TotalInBTC = balance.Balance / btcTicker.last;
                            }
                            balance.TotalInUSD = balance.Balance;
                        }
                    }
                    //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", balance.Currency + " | " + balance.Balance + " | " + balance.TotalInBTC + " | " + balance.TotalInUSD, LogManager.LogMessageType.DEBUG);
                    ExchangeManager.processBalance(balance.GetExchangeBalance());
                }
            }
        }
        public static void updateExchangeTickerList()
        {
            List<CCEXMarketSummary> list = getMarketSummariesList();
            foreach (CCEXMarketSummary ticker in list)
            {
                ExchangeManager.processTicker(ticker.GetExchangeTicker());
            }
        }
        private static void UpdateStatus(Boolean success, string message = "")
        {
            if (success)
            {
                ErrorCount = 0;
            }
            else
            {
                ErrorCount++;
            }
            LastUpdate = DateTime.Now;
            LastMessage = message;
        }
        #endregion ExchangeManager

        #region DataModels
        #region DATAMODELS_Enumerables
        public enum CCEXOrderBookType
        {
            both,
            buy,
            sell
        }
        #endregion
        #region DATAMODELS_Public
        public class CCEXMarket
        {
            public string MarketCurrency { get; set; }
            public string BaseCurrency { get; set; }
            public string MarketCurrencyLong { get; set; }
            public string BaseCurrencyLong { get; set; }
            public double MinTradeSize { get; set; }
            public string MarketName { get; set; }
            public bool IsActive { get; set; }
            public DateTime Created { get; set; }
        }
        public class CCEXMarketHistory
        {
            public int Id { get; set; }
            public string TimeStamp { get; set; }
            public double Quantity { get; set; }
            public double Price { get; set; }
            public double Total { get; set; }
            public string FillType { get; set; }
            public string OrderType { get; set; }
        }
        public class CCEXMarketSummary
        {
            public string MarketName { get; set; }
            public Decimal High { get; set; }
            public Decimal Low { get; set; }
            public Decimal Volume { get; set; }
            public Decimal Last { get; set; }
            public Decimal BaseVolume { get; set; }
            public string TimeStamp { get; set; }
            public Decimal Bid { get; set; }
            public Decimal Ask { get; set; }
            public int OpenBuyOrders { get; set; }
            public int OpenSellOrders { get; set; }
            public Decimal PrevDay { get; set; }
            public string Created { get; set; }
            public object DisplayMarketName { get; set; }
            public ExchangeTicker GetExchangeTicker()
            {
                ExchangeTicker eTicker = new ExchangeTicker();
                eTicker.exchange = Name;
                string[] pairs = MarketName.Split('-');
                eTicker.market = pairs[1];
                eTicker.symbol = pairs[0];
                eTicker.last = Last;
                eTicker.ask = Ask;
                eTicker.bid = Bid;
                eTicker.volume = BaseVolume;
                eTicker.high = High;
                eTicker.low = Low;
                return eTicker;
            }
        }
        public class CCEXOrderBookData
        {
            public double Quantity { get; set; }
            public double Rate { get; set; }
            // ADDON
            public string Market { get; set; }
            public string Type { get; set; }
        }
        public class CCEXPrice
        {
            public String pair { get; set; }
            public Decimal high { get; set; }
            public Decimal low { get; set; }
            public Decimal avg { get; set; }
            public Decimal lastbuy { get; set; }
            public Decimal lastsell { get; set; }
            public Decimal buy { get; set; }
            public Decimal sell { get; set; }
            public Decimal lastprice { get; set; }
            public int updated { get; set; }
        }
        #endregion
        #region DATAMODELS_Private
        public class CCEXBalance
        {
            public string Currency { get; set; }
            public Decimal Balance { get; set; }
            public Decimal Available { get; set; }
            public Decimal Pending { get; set; }
            public string CryptoAddress { get; set; }
            // ADDON DATA
            public Decimal TotalInBTC { get; set; } = 0;
            public Decimal TotalInUSD { get; set; } = 0;
            public ExchangeBalance GetExchangeBalance()
            {
                ExchangeBalance eBalance = new ExchangeBalance();
                eBalance.Symbol = Currency;
                eBalance.Exchange = Name;
                eBalance.Balance = Balance;
                eBalance.OnOrders = Balance - Available;
                eBalance.TotalInBTC = TotalInBTC;
                eBalance.TotalInUSD = TotalInUSD;
                return eBalance;
            }
        }
        public class CCEXBuySellMessage
        {
            public bool success { get; set; }
            public string message { get; set; }
            public CCEXBuySellResult result { get; set; }
        }
        public class CCEXBuySellResult
        {
            public string uuid { get; set; }
        }
        public class CCEXOrder
        {
            public object Uuid { get; set; }
            public string OrderUuid { get; set; }
            public string Exchange { get; set; }
            public string OrderType { get; set; }
            public Double Quantity { get; set; }
            public Double QuantityRemaining { get; set; }
            public Double Limit { get; set; }
            public Double CommissionPaid { get; set; }
            public Double Price { get; set; }
            public object PricePerUnit { get; set; }
            public DateTime Opened { get; set; }
            public object Closed { get; set; }
            public bool CancelInitiated { get; set; }
            public bool ImmediateOrCancel { get; set; }
            public bool IsConditional { get; set; }
            public string Condition { get; set; }
            public object ConditionTarget { get; set; }
            // CLOSED ORDERS
            public double Commission { get; set; }
            public DateTime TimeStamp { get; set; }
        }
        public class CCEXTrade
        {
            public string tradeid { get; set; }
            public string tradetype { get; set; }
            public string datetime { get; set; }
            public string marketid { get; set; }
            public string tradeprice { get; set; }
            public string quantity { get; set; }
            public string fee { get; set; }
            public string total { get; set; }
            public string initiate_ordertype { get; set; }
            public string order_id { get; set; }
        }
        #endregion
        #endregion DataModels
    }
}