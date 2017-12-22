using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    public class YoBit
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "YoBit";
        public static string Url { get; } = "https://yobit.net/";
        public static string USDSymbol { get; } = "USD";
        // API
        public static ExchangeApi Api { get; set; }
        private static RestClient client = new RestClient("https://yobit.net/api");
        private static string Api_privateUrl = "https://yobit.net/tapi/";
        // COLLECTIONS
        public static BlockingCollection<YoBitBalance> Balances = new BlockingCollection<YoBitBalance>();
        public static BlockingCollection<YoBitInfo> Pairs = new BlockingCollection<YoBitInfo>();
        public static BlockingCollection<YoBitTicker> Tickers = new BlockingCollection<YoBitTicker>();
        // STATUS
        public static int ErrorCount { get; set; } = 0;
        public static DateTime LastUpdate { get; set; } = DateTime.Now;
        public static string LastMessage { get; set; } = String.Empty;
        #endregion Properties

        #region API_Public
        /// <summary>info
        /// <para>The given method can be used for obtaining list of active pairs.</para>
        /// <para>Note! If we disable any pair from the list API will throw an error message. To enable the ignoration of such errors GET-parameter is available ignore_invalid.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<YoBitInfo> getInfoList()
        {
            List<YoBitInfo> list = new List<YoBitInfo>();
            string responseString = string.Empty;
            try
            {
                var request = new RestRequest("/3/info", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getInfoList", "Response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                responseString = response.Content;
                var jsonObject = JObject.Parse(responseString);
                var pairsObject = JObject.Parse(jsonObject["pairs"].ToString());

                foreach (var item in pairsObject)
                {
                    //LogManager.AddLogMessage(Name, "getInfo", item.Key + " | " + item.Value);
                    YoBitInfo info = pairsObject[item.Key].ToObject<YoBitInfo>();
                    info.pair = item.Key;
                    string[] pairs = info.pair.Split('_');
                    info.symbol = pairs[0];
                    info.market = pairs[1];
                    list.Add(info);
                }
                UpdateStatus(true, "Loaded " + list.Count + " Pairs");
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getInfoList", responseString, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, responseString);
            }
            return list;
        }
        /// <summary>depth
        /// <para>Method returns information about lists of active orders for selected pairs.</para>
        /// <para>Required : pairs - ARRAY of STRING (sym_mkt)</para>
        /// <para>Optional : limit - stipulates size of withdrawal (on default 150 to 2000 maximum).</para>
        /// </summary>
        public static List<YoBitOrderBook> getOrderBookList(string[] pairsArray, int limit = 150)
        {
            List<YoBitOrderBook> list = new List<YoBitOrderBook>();
            try
            {
                string pairs = string.Join("-", pairsArray);
                var request = new RestRequest("/3/depth/" + pairs + "?limit=" + limit, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getOrderBook", "Response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(Name, "getOrderBook", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                    YoBitOrderBook orderBook = jsonObject[item.Key].ToObject<YoBitOrderBook>();
                    orderBook.pair = item.Key;
                    string[] pairSplit = orderBook.pair.Split('_');
                    orderBook.symbol = pairSplit[0];
                    orderBook.market = pairSplit[1];
                    list.Add(orderBook);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderBook", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        /// <summary>ticker
        /// <para>Method provides statistic data for the last 24 hours.</para>
        /// <para>Required : pair (sym_mkt)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static YoBitTicker getTicker(string symbol, string market)
        {
            try
            {
                string pair = symbol.ToLower() + "_" + market.ToLower();
                var request = new RestRequest("/3/ticker/" + pair, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getTicker", "tickerResponse.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                YoBitTicker ticker = jsonObject[pair].ToObject<YoBitTicker>();
                ticker.pair = pair;
                ticker.symbol = symbol;
                ticker.market = market;
                return ticker;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTicker", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }
        /// <summary>ticker (LIST)
        /// <para>Method provides list of statistic data for the last 24 hours.</para>
        /// <para>Required : pairs - ARRAY of STRING (sym_mkt)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<YoBitTicker> getTickerList(List<YoBitInfo> pairs)
        {
            List<YoBitTicker> list = new List<YoBitTicker>();
            string responseString = String.Empty;
            try
            {
                string reqString = getPairsString(pairs);
                //LogManager.AddLogMessage(Name, "getTickerList", pairs ,LogManager.LogMessageType.DEBUG); 
                //LogManager.AddLogMessage(Name, "getTickerList", "reqString=" + reqString, LogManager.LogMessageType.DEBUG);
                var request = new RestRequest("/3/ticker/" + reqString, Method.GET);
                
                var response = client.Execute(request);
                responseString = response.Content;
                //LogManager.AddLogMessage(Name, "getTicker", "tickerResponse.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(responseString);
                
                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(Name, "getTicker", item.Key + " | " + item.Value);
                    YoBitTicker ticker = jsonObject[item.Key].ToObject<YoBitTicker>();
                    ticker.pair = item.Key;
                    string[] pairSplit = ticker.pair.Split('_');
                    ticker.symbol = pairSplit[0];
                    ticker.market = pairSplit[1];
                    list.Add(ticker);
                }
                UpdateStatus(true, "Updated Tickers");
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTickerList EX", LogManager.StripHTML(responseString), LogManager.LogMessageType.LOG);
                UpdateStatus(false, LogManager.StripHTML(responseString));
            }       
            return list;
        }
        
        /// <summary>trades
        /// <para>Method returns information about the last transactions of selected pairs.</para>
        /// <para>Required : pairs - ARRAY of STRING (sym_mkt)</para>
        /// <para>Optional : limit - stipulates size of withdrawal (on default 150 to 2000 maximum).</para>
        /// </summary>
        public static List<YoBitTrade> getTradeList(string[] pairsArray, int limit = 150)
        {
            List<YoBitTrade> list = new List<YoBitTrade>();
            try
            {
                string pairs = string.Join("-", pairsArray);
                var request = new RestRequest("/3/trades/" + pairs + "?limit=" + limit, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getTradeList", "Response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);

                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(Name, "getTradeList", item.Key + " | " + item.Value);
                    List<YoBitTrade> trades = jsonObject[item.Key].ToObject<List<YoBitTrade>>();
                    foreach (YoBitTrade trade in trades)
                    {
                        trade.pair = item.Key;
                        string[] pairSplit = trade.pair.Split('_');
                        trade.symbol = pairSplit[0];
                        trade.market = pairSplit[1];
                        list.Add(trade);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTradeList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        private static List<YoBitInfo> getWatchlistPairs()
        {
            List<YoBitInfo> list = new List<YoBitInfo>();

            foreach (string sym in ExchangeManager.Watchlist)
            {
                //LogManager.AddLogMessage(Name, "getWatchlistPairs", sym, LogManager.LogMessageType.DEBUG);

                //List<YoBitInfo> symPairs = Pairs.Where(i => i.symbol.ToLower() == sym.ToLower() && i.market.ToLower() == "btc" || i.market.ToLower() == "usd").ToList();
                List<YoBitInfo> symBtcPairs = Pairs.Where(i => i.symbol.ToLower() == sym.ToLower() && i.market.ToLower() == "btc").ToList();
                //LogManager.AddLogMessage(Name, "getWatchlistPairs", sym + " | count=" + symBtcPairs.Count, LogManager.LogMessageType.DEBUG);           
                foreach (YoBitInfo info in symBtcPairs)
                {
                    list.Add(info);
                }

                List<YoBitInfo> symUsdPairs = Pairs.Where(i => i.symbol.ToLower() == sym.ToLower() && i.market.ToLower() == "usd").ToList();
                //LogManager.AddLogMessage(Name, "getWatchlistPairs", sym + " | count=" + symBtcPairs.Count, LogManager.LogMessageType.DEBUG);
                foreach (YoBitInfo info in symUsdPairs)
                {
                    list.Add(info);
                }
            }

            foreach (YoBitBalance balance in Balances)
            {              
                List<YoBitInfo> balBtcPairs = Pairs.Where(i => i.symbol.ToLower() == balance.Currency.ToLower() && i.market.ToLower() == "btc").ToList();
                //LogManager.AddLogMessage(Name, "getWatchlistPairs", "b:" + balance.Currency + " | " + balPairs.Count, LogManager.LogMessageType.DEBUG);
                foreach (YoBitInfo info in balBtcPairs)
                {
                    if (!list.Contains(info))
                    {
                        list.Add(info);
                    }
                }
                List<YoBitInfo> balUsdPairs = Pairs.Where(i => i.symbol.ToLower() == balance.Currency.ToLower() && i.market.ToLower() == "usd").ToList();
                //LogManager.AddLogMessage(Name, "getWatchlistPairs", "b:" + balance.Currency + " | " + balPairs.Count, LogManager.LogMessageType.DEBUG);
                foreach (YoBitInfo info in balUsdPairs)
                {
                    if (!list.Contains(info))
                    {
                        list.Add(info);
                    }
                }
            }

            return list;
        }
        private static string getPairsString(List<YoBitInfo> list)
        {
            List<string> pairsList = new List<string>();

            foreach (YoBitInfo marketPair in list)
            {
                //LogManager.AddLogMessage(Name, "getExchangeTickerList", index + " | " + marketPair.pair, LogManager.LogMessageType.DEBUG);
                pairsList.Add(marketPair.pair);
            }
            string pairs = string.Join("-", pairsList.ToArray()).ToLower();

            return pairs;
        }
        #endregion API_Public

        #region API_Private
        // ------------------------
        private static string getHMAC(string message)
        {
            var hmac = new HMACSHA512(Encoding.ASCII.GetBytes(Api.secret));
            var messagebyte = Encoding.ASCII.GetBytes(message);
            var hashmessage = hmac.ComputeHash(messagebyte);
            var sign = BitConverter.ToString(hashmessage).Replace("-", "").ToLower();
            return sign;
        }
        private async static Task<string> SendPrivateApiRequestAsync(string request)
        {
            using (var client = new HttpClient())
            {
                //StringContent c = new StringContent(request);
                StringContent c = new StringContent(request, Encoding.UTF8, "application/x-www-form-urlencoded");
                c.Headers.Add("Sign", getHMAC(request));
                c.Headers.Add("Key", Api.key);

                var respond = await client.PostAsync(Api_privateUrl, c);
                return Encoding.UTF8.GetString(await respond.Content.ReadAsByteArrayAsync());
            }
        }
        // ------------------------
        /// <summary>getInfo
        /// <para>Method returns information about user's balances and priviledges of API-key as well as server time.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<List<YoBitBalance>> getBalanceList()
        {
            List<YoBitBalance> list = new List<YoBitBalance>();
            string responseString = string.Empty;
            try
            {
                string req = "method=getInfo&nonce=" + ExchangeManager.GetNonce();
                responseString = await SendPrivateApiRequestAsync(req);
                responseString = responseString.Replace("return", "results");
                //LogManager.AddLogMessage(Name, "getInfo", "result=" + result, LogManager.LogMessageType.DEBUG);
                var balancejsonData = JObject.Parse(responseString);
                int isSuccess = Convert.ToInt32(balancejsonData["success"]);

                if (isSuccess > 0)
                {
                    //LogManager.AddLogMessage("YoBitControl", "GetBalances", "Succeeded - get RESULTS : " + balancejsonData.GetValue("results"), LogManager.LogMessageType.DEBUG);
                    var results = JObject.Parse(balancejsonData.GetValue("results").ToString());
                    var funds = JObject.Parse(results.GetValue("funds").ToString());
                    var orders = JObject.Parse(results.GetValue("funds_incl_orders").ToString());

                    foreach (var o in orders)
                    {
                        //LogManager.AddLogMessage("YoBitControl", "GetBalances", "get ORDERS : " + o.Key + " | " + o.Value);
                        YoBitBalance newBalance = new YoBitBalance();
                        newBalance.Currency = o.Key;
                        newBalance.Balance = Convert.ToDecimal(o.Value);
                        list.Add(newBalance);
                    }

                    foreach (var f in funds)
                    {
                        //LogManager.AddLogMessage("YoBitControl", "GetBalances", "get FUNDS : " + f.Key + " | " + f.Value);
                        YoBitBalance bItem = list.FirstOrDefault(bi => bi.Currency == f.Key);

                        if (bItem != null)
                        {
                            //LogManager.AddLogMessage("YoBitControl", "GetBalances", "EXIST : " + f.Key + " | " + f.Value);
                            try
                            {
                                bItem.Available = Convert.ToDecimal(f.Value);
                            }
                            catch (Exception bex)
                            {
                                LogManager.AddLogMessage("YoBitControl", "GetBalances", f.Key + " | " + f.Value + " | " + bex.Message, LogManager.LogMessageType.EXCEPTION);
                            }
                        }
                        else
                        {
                            LogManager.AddLogMessage(Name, "GetBalances", "NOT IN BList already (WHY???) : " + f.Key + " | " + f.Value, LogManager.LogMessageType.DEBUG);
                        }
                    }
                    UpdateStatus(true, "Updated Balances");
                }
                else
                {
                    // SUCCESS FALSE
                    UpdateStatus(true, responseString);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalances", ex.Message, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, responseString);
            }
            return list;
        }
        /// <summary>ActiveOrders
        /// <para>Method returns list of user's active orders</para>
        /// <para>Required : pair (example: ltc_btc)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<List<YoBitOrder>> getOpenOrdersList()
        {
            List<YoBitOrder> list = new List<YoBitOrder>();
            try
            {
                string req = "method=ActiveOrders&nonce=" + ExchangeManager.GetNonce() + "&pair=btg_btc";
                string result = await SendPrivateApiRequestAsync(req);
                result = result.Replace("return", "results");
                //LogManager.AddLogMessage(Name, "getOpenOrdersList", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                int isSuccess = Convert.ToInt32(jsonObject["success"]);

                if (isSuccess > 0)
                {
                    var results = JObject.Parse(jsonObject["results"].ToString());
                    foreach (var item in results)
                    {
                        //LogManager.AddLogMessage(Name, "getOpenOrdersList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                        YoBitOrder order = results[item.Key].ToObject<YoBitOrder>();       
                        order.orderId = item.Key;
                        string[] pairs = order.pair.Split('_');
                        order.symbol = pairs[0];
                        order.market = pairs[1];
                        list.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOpenOrdersList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        /// <summary>OrderInfo
        /// <para>Method returns detailed information about the chosen order</para>
        /// <para>Required : order ID (value: numeral)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<List<YoBitOrder>> getOrderInfoList(string orderId)
        {
            List<YoBitOrder> list = new List<YoBitOrder>();
            try
            {
                string req = "method=OrderInfo&nonce=" + ExchangeManager.GetNonce() + "&orderId=" + orderId;
                string result = await SendPrivateApiRequestAsync(req);
                result = result.Replace("return", "results");
                //LogManager.AddLogMessage(Name, "getOrderInfoList", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                int isSuccess = Convert.ToInt32(jsonObject["success"]);

                if (isSuccess > 0)
                {         
                    var results = JObject.Parse(jsonObject["results"].ToString());
                    foreach (var item in results)
                    {
                        //LogManager.AddLogMessage(Name, "getOrderInfoList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                        YoBitOrder order = results[item.Key].ToObject<YoBitOrder>();
                        order.orderId = item.Key;
                        string[] pairs = order.pair.Split('_');
                        order.symbol = pairs[0];
                        order.market = pairs[1];
                        list.Add(order);
                    }  
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderInfoList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        /// <summary>TradeHistory
        /// <para>Method returns transaction history.</para>
        /// <para>Required : none</para>
        /// <para>Optional : from: No. of transaction from which withdrawal starts (value: numeral, on default: 0)</para>
        /// <para>Optional : count: quantity of withrawal transactions (value: numeral, on default: 1000)</para>
        /// <para>Optional : from_id: ID of transaction from which withdrawal starts (value: numeral, on default: 0)</para>
        /// <para>Optional : end_id: ID of transaction at which withdrawal finishes (value: numeral, on default: ∞)</para>
        /// <para>Optional : order: sorting at withdrawal (value: ASC or DESC, on default: DESC)</para>
        /// <para>Optional : since: the time to start the display (value: unix time, on default: 0)</para>
        /// <para>Optional : end: the time to end the display (value: unix time, on default: ∞)</para>
        /// <para>Optional : pair (example: ltc_btc)</para>
        /// </summary>
        public static async Task<List<YoBitOrder>> getTradeHistoryList(YoBitTradeHistoryParameters parameters)
        {
            List<YoBitOrder> list = new List<YoBitOrder>();
            try
            {
                string pair = parameters.symbol + "_" + parameters.market;
                string req = "method=TradeHistory&nonce=" + ExchangeManager.GetNonce() + "&pair=" + pair;
                string result = await SendPrivateApiRequestAsync(req);
                result = result.Replace("return", "results");
                LogManager.AddLogMessage(Name, "getTradeHistoryList", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                
                int isSuccess = Convert.ToInt32(jsonObject["success"]);

                if (isSuccess > 0)
                {     
                    var results = JObject.Parse(jsonObject["results"].ToString());
                    foreach (var item in results)
                    {
                        //LogManager.AddLogMessage(Name, "getTradeHistoryList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                        YoBitOrder order = results[item.Key].ToObject<YoBitOrder>();
                        order.orderId = item.Key;
                        string[] pairs = order.pair.Split('_');
                        order.symbol = pairs[0];
                        order.market = pairs[1];
                        list.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTradeHistoryList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #region API_PRIVATE_TBD
        // TO BE DEVELOPED
        // Trade
        // CancelOrder
        // GetDepositAddress
        // WithdrawCoinsToAddress
        // CreateYobicode
        // RedeemYobicode
        #endregion
        #endregion API_Private

        #region ExchangeManager
        // INITIALIZE
        public async static void InitializeExchange()
        {
            //Balances = new BlockingCollection<YoBitBalance>(new ConcurrentQueue<YoBitBalance>(await getBalanceList()));
            Pairs = new BlockingCollection<YoBitInfo>(new ConcurrentQueue<YoBitInfo>(getInfoList()));
            Balances = new BlockingCollection<YoBitBalance>(new ConcurrentQueue<YoBitBalance>(await getBalanceList()));
            LogManager.AddLogMessage(Name, "InitializeExchange", "Initialized", LogManager.LogMessageType.EXCHANGE);
        }
        // GETTERS
        /*
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();
            // GET ALL THE PAIRS
            List<YoBitInfo> infoList = getInfoList();
            var marketList = infoList.Select(p => p.market).Distinct();
            // SEPERATE INTO MARKETS TO BUILD REQUEST STRING
            foreach (string market in marketList)
            {
                //LogManager.AddLogMessage(Name, "getExchangeTickerList", market.ToString(), LogManager.LogMessageType.DEBUG);
                List<YoBitInfo> marketPairs = infoList.FindAll(mp => mp.market == market.ToString());
                LogManager.AddLogMessage(Name, "getExchangeTickerList", market.ToString() + " has " + marketPairs.Count + " pairs", LogManager.LogMessageType.DEBUG);
                //LogManager.AddLogMessage(Name, "getExchangeTickerList", getPairsString(marketPairs), LogManager.LogMessageType.DEBUG);
                // ADD TO EXCHANGE LIST

                //List<YoBitTicker> tickers = getTickerList(marketPairs);
                
                int groupCount = 25;
                int index = 0;
                List<YoBitInfo> requestPairs = new List<YoBitInfo>();

                foreach (YoBitInfo pair in marketPairs)
                {
                    if (index < groupCount)
                    {
                        requestPairs.Add(pair);
                        index++;
                    }
                    else
                    {
                        // LOAD AND RESET
                        
                        Console.WriteLine("Loading 25 tickers");
                        List<YoBitTicker> tickers = getTickerList(requestPairs);
                        foreach (YoBitTicker ticker in tickers)
                        {
                            //list.Add(ticker);
                            ExchangeTicker eTicker = new ExchangeTicker();
                            eTicker.exchange = Name;
                            //string[] pairs = ticker.pair.Split('_');
                            eTicker.market = ticker.market;
                            eTicker.symbol = ticker.symbol;

                            eTicker.last = ticker.last;
                            eTicker.ask = ticker.buy;
                            eTicker.bid = ticker.sell;
                            //eTicker.change = (ticker.Last - ticker.PrevDay) / ticker.PrevDay;
                            eTicker.volume = ticker.vol;
                            eTicker.high = ticker.high;
                            eTicker.low = ticker.low;
                            //LogManager.AddDebugMessage(thisClassName, "returnTicker", "pair=" + ticker.pair + " | last=" + ticker.last);
                            list.Add(eTicker);
                        }

                        index = 0;
                        //Console.WriteLine("SLEEPING");
                        //Thread.Sleep(2000);
                        
                    }
                }
                
            }

            LogManager.AddLogMessage(Name, "getExchangeTickerList", marketList.Count() + " markets found for " + Name, LogManager.LogMessageType.DEBUG);


            return list;
        }
        */
        // UPDATERS
        public async static void updateExchangeBalanceList()
        {
            //List<YoBitBalance> list = await getBalanceList();
            Balances = new BlockingCollection<YoBitBalance>(new ConcurrentQueue<YoBitBalance>(await getBalanceList()));
            ExchangeTicker btcTicker = ExchangeManager.getExchangeTicker(Name, "BTC", USDSymbol);

            foreach (YoBitBalance balance in Balances)
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
            //LogManager.AddLogMessage(Name, "updateExchangeTickerList", "THIS FUNCTION DISABLED UNTIL A SOLUTION IS FOUND ON PAIR REQUESTS", LogManager.LogMessageType.OTHER);
            
            Tickers = new BlockingCollection<YoBitTicker>(new ConcurrentQueue<YoBitTicker>(getTickerList(getWatchlistPairs())));
            foreach (YoBitTicker ticker in Tickers)
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
        #region DATAMODELS_Enums
        // ENUMS
        #endregion
        #region DATAMODELS_Parameters
        public class YoBitTradeHistoryParameters
        {
            /// <summary>No. of transaction from which withdrawal starts (value: numeral, on default: 0)
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|0")]
            public int from { get; set; } = 0;

            /// <summary>quantity of withrawal transactions (value: numeral, on default: 1000)
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|1000")]
            public int count { get; set; } = 1000;

            /// <summary>ID of transaction from which withdrawal starts (value: numeral, on default: 0)
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|0")]
            public int from_id { get; set; } = 0;

            /// <summary>ID of transaction at which withdrawal finishes (value: numeral, on default: ∞)
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|2147483646")]
            public int end_id { get; set; } = int.MaxValue;

            /// <summary>symbol for pair
            /// <para>REQUIRED</para>
            /// </summary>
            [Category("required")]
            public string symbol { get; set; }

            /// <summary>market for pair
            /// <para>REQUIRED</para>
            /// </summary>
            [Category("required")]
            public int market { get; set; }
        }
        #endregion
        #region DATAMODELS_Public 
        // PUBLIC MODELS
        public class YoBitInfo
        {
            [Description("Quantity of permitted numbers after decimal point")]
            public int decimal_places { get; set; }

            [Description("minimal permitted price")]
            public double min_price { get; set; }

            [Description("maximal permitted price")]
            public int max_price { get; set; }

            [Description("minimal permitted buy or sell amount")]
            public double min_amount { get; set; }

            [Description("minimal total")]
            public double min_total { get; set; }

            [Description("pair is hidden (0 or 1)")]
            public int hidden { get; set; }

            [Description("pair commission")]
            public double fee { get; set; }

            [Description("buyer fee")]
            public double fee_buyer { get; set; }

            [Description("seller fee")]
            public double fee_seller { get; set; }
            // ADDON
            [Description("pair (sym_mkt")]
            public string pair { get; set; }

            [Description("the symbol for the pair")]
            public string symbol { get; set; }

            [Description("the market for the pair")]
            public string market { get; set; }
        }
        public class YoBitOrderBook
        {
            [Description("selling orders")]
            public List<List<double>> asks { get; set; }

            [Description("buying orders")]
            public List<List<double>> bids { get; set; }

            // ADDON
            [Description("pair (sym_mkt")]
            public string pair { get; set; }

            [Description("the symbol for the pair")]
            public string symbol { get; set; }

            [Description("the market for the pair")]
            public string market { get; set; }
        }
        public class YoBitTicker
        {
            [Description("(sym_mkt) pair")]
            public string pair { get; set; }

            [Description("maximal price")]
            public Decimal high { get; set; }

            [Description("minimal price")]
            public Decimal low { get; set; }

            [Description("average price")]
            public Decimal avg { get; set; }

            [Description("traded volume")]
            public Decimal vol { get; set; }

            [Description("traded colume in currency")]
            public Decimal vol_cur { get; set; }

            [Description("last transaction price")]
            public Decimal last { get; set; }

            [Description("buying price")]
            public Decimal buy { get; set; }

            [Description("selling price")]
            public Decimal sell { get; set; }

            [Description("last cache upgrade")]
            public int updated { get; set; }

            // ADDON
            [Description("symbol for pair")]
            public string symbol { get; set; }

            [Description("market for pair")]
            public string market { get; set; }

            public ExchangeTicker GetExchangeTicker()
            {
                ExchangeTicker eTicker = new ExchangeTicker();
                eTicker.exchange = Name;
                //string pair = symbol;
                //eTicker.market = pair.Substring(pair.Length - 3);
                //eTicker.symbol = pair.Substring(0, pair.Length - 3);
                eTicker.symbol = symbol;
                eTicker.market = market;
                eTicker.last = last;
                eTicker.ask = sell;
                eTicker.bid = buy;
                eTicker.volume = vol;
                eTicker.high = high;
                eTicker.low = low;
                return eTicker;
            }
        }
        public class YoBitTrade
        {
            [Description("ask - sell, bid - buy")]
            public string type { get; set; }

            [Description("buying / selling price")]
            public double price { get; set; }

            [Description("amount")]
            public double amount { get; set; }

            [Description("transaction id")]
            public int tid { get; set; }

            [Description("transaction timestamp")]
            public int timestamp { get; set; }

            // ADDON
            [Description("(sym_mkt) pair")]
            public string pair { get; set; }

            [Description("symbol for pair")]
            public string symbol { get; set; }

            [Description("market for pair")]
            public string market { get; set; }
        }
        #endregion
        #region DATAMODELS_Private
        // PRIVATE MODELS
        public class YoBitBalance
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
                eBalance.Symbol = Currency.ToUpper();
                eBalance.Exchange = Name;
                eBalance.Balance = Balance;
                eBalance.OnOrders = Available;
                eBalance.TotalInBTC = TotalInBTC;
                eBalance.TotalInUSD = TotalInUSD;
                return eBalance;
            }
        }
        public class YoBitOrder
        {
            [Description("order ID (in example: 100025362)")]
            public string orderId { get; set; }

            [Description("pair (example: ltc_btc)")]
            public string pair { get; set; }

            [Description("transaction type (example: buy or sell)")]
            public string type { get; set; }

            [Description("remains to buy or to sell")]
            public Decimal amount { get; set; }

            [Description("price of buying or selling")]
            public Decimal rate { get; set; }

            [Description("order creation time")]
            public string timestamp_created { get; set; }

            [Description("0 - active, 1 - fulfilled and closed, 2 - cancelled, 3 - cancelled after partially fulfilled")]
            public int status { get; set; }
            
            // ADDON
            [Description("symbol for pair")]
            public string symbol { get; set; }

            [Description("market for pair")]
            public string market { get; set; }

            // OrderInfo
            [Description("starting amout at order creation")]
            public Decimal start_amount { get; set; }
        }
        #endregion
        #endregion DataModels
    }
}