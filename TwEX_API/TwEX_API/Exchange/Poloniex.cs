using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    public class Poloniex
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "Poloniex";
        public static string Url { get; } = "https://poloniex.com/";
        public static string USDSymbol { get; } = "USDT";
        // API
        public static ExchangeApi Api { get; set; }
        private static RestClient client = new RestClient("https://poloniex.com");
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters
        /// <summary>return24Volume
        /// <para>Returns the 24-hour volume for all markets, plus totals for primary currencies.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<Poloniex24hVolume> get24hVolumeList()
        {
            List<Poloniex24hVolume> list = new List<Poloniex24hVolume>();
            try
            {
                var request = new RestRequest("/public?command=return24hVolume", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "get24VolumeList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);

                var jsonObject = JObject.Parse(response.Content);

                foreach (var entry in jsonObject)
                {
                    if (!entry.Key.Contains("total"))
                    {
                        //LogManager.AddLogMessage(Name, "get24VolumeList", "Key=" + entry.Key + " | Value=" + entry.Value, LogManager.LogMessageType.DEBUG);
                        Poloniex24hVolume item = new Poloniex24hVolume();
                        item.pair = entry.Key; // MKT_SYM
                        string[] stringSplit = item.pair.Split('_');
                        item.market = stringSplit[0];
                        item.marketVolume = Convert.ToDecimal(jsonObject[item.pair][item.market]);
                        item.symbol = stringSplit[1];
                        item.symbolVolume = Convert.ToDecimal(jsonObject[item.pair][item.symbol]);
                    
                        list.Add(item);
                    }
                    else
                    {
                        // THESE ARE TOTALS - symbol & market contain same values
                        Poloniex24hVolume item = new Poloniex24hVolume();
                        item.pair = entry.Key; // totalMKT
                        item.market = entry.Key.Replace("total", "");
                        item.marketVolume = Convert.ToDecimal(entry.Value);
                        item.symbol = "total";
                        item.symbolVolume = Convert.ToDecimal(entry.Value);
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "get24VolumeList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnChartData
        /// <para>Returns candlestick chart data.</para>
        /// <para>Required : currencyPair (MKT_SYM)</para>
        /// <para>Required : period (candlestick period in seconds; valid values are 300, 900, 1800, 7200, 14400, and 86400)</para>
        /// <para>Required : start (unix)</para>
        /// <para>Required : end (unix)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<PoloniexChartData> getChartDataList(PoloniexChartDataParameters parameters)
        {
            try
            {
                string url = "/public?command=returnChartData&currencyPair=" + parameters.market + "_" + parameters.symbol + 
                    "&start=" + parameters.start + 
                    "&end=" + parameters.end + 
                    "&period=" + (Int32)parameters.period;

                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getChartData", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                PoloniexChartData[] array = jsonVal.ToObject<PoloniexChartData[]>();
                return array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getChartData", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>returnCurrencies
        /// <para>Returns information about currencies.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<PoloniexCurrency> getCurrencyList()
        {
            List<PoloniexCurrency> list = new List<PoloniexCurrency>();
            try
            {
                string url = "/public?command=returnCurrencies";
                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCurrencies", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);

                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(Name, "getCurrencies", "Key=" + item.Key + " | Value=" + item.Value, LogManager.LogMessageType.DEBUG);         
                    PoloniexCurrency currency = jsonObject[item.Key].ToObject<PoloniexCurrency>();
                    currency.symbol = item.Key;
                    list.Add(currency);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrencies", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnLoanOrders
        /// <para>Returns the list of loan offers and demands for a given currency, specified by the "currency" GET parameter.</para>
        /// <para>Required : currency (BTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<PoloniexLoanOrder> getLoanOrdersList(string currency)
        {
            List<PoloniexLoanOrder> list = new List<PoloniexLoanOrder>();
            try
            {
                string url = "/public?command=returnLoanOrders&currency=" + currency;
                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getLoanOrdersList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                
                List<PoloniexLoanOrder> offers = jsonObject["offers"].ToObject<List<PoloniexLoanOrder>>();
                List<PoloniexLoanOrder> demands = jsonObject["demands"].ToObject<List<PoloniexLoanOrder>>();

                foreach (PoloniexLoanOrder offer in offers)
                {
                    offer.type = "offer";
                    list.Add(offer);
                }

                foreach (PoloniexLoanOrder demand in demands)
                {
                    demand.type = "demand";
                    list.Add(demand);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getLoanOrdersList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnOrderBook (PAIR)
        /// <para>Returns the order book for a given market, as well as a sequence number for use with the Push API and an indicator specifying whether the market is frozen.</para>
        /// <para>Required : currencyPair (MKT_SYM)</para>
        /// <para>Optional : depth (defaults to 0 to get all)</para>
        /// </summary>
        public static PoloniexOrderBookItem getOrderBook(string market, string symbol, int depth = 0)
        {
            try
            {
                string url = "/public?command=returnOrderBook&currencyPair=" + market.ToUpper() + "_" + symbol.ToUpper();

                if (depth > 0)
                {
                    url += "&depth=" + depth;
                }

                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getOrderBook", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);

                PoloniexOrderBookItem item = jsonObject.ToObject<PoloniexOrderBookItem>();
                item.pair = market.ToUpper() + "_" + symbol.ToUpper();
                item.symbol = symbol;
                item.market = market;
                return item;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderBook", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>returnOrderBook (ALL)
        /// <para>Returns the order books for all markets, as well as a sequence number for use with the Push API and an indicator specifying whether the market is frozen.</para>
        /// <para>Optional : depth (defaults to 0 to get all)</para>
        /// </summary>
        public static List<PoloniexOrderBookItem> getOrderBookList(int depth = 0)
        {
            List<PoloniexOrderBookItem> list = new List<PoloniexOrderBookItem>();
            try
            {
                string url = "/public?command=returnOrderBook&currencyPair=all";

                if (depth > 0)
                {
                    url += "&depth=" + depth;
                }

                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getOrderBookList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                
                foreach (var item in jsonObject)
                {
                    PoloniexOrderBookItem orderBook = jsonObject[item.Key].ToObject<PoloniexOrderBookItem>();
                    orderBook.pair = item.Key;
                    string[] pairSplit = orderBook.pair.Split('_');
                    orderBook.symbol = pairSplit[1];
                    orderBook.market = pairSplit[0];
                    list.Add(orderBook);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderBookList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnTicker
        /// <para>Returns the ticker for all markets.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<PoloniexTicker> getTickerList()
        {
            List<PoloniexTicker> list = new List<PoloniexTicker>();
            
            try
            {
                var request = new RestRequest("/public?command=returnTicker", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getTickerList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);

                foreach (var entry in jsonObject)
                {
                    PoloniexTicker ticker = jsonObject[entry.Key].ToObject<PoloniexTicker>();
                    ticker.pair = entry.Key;
                    list.Add(ticker);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTickerList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnTradeHistory
        /// <para>Returns the past 200 trades for a given market, or up to 50,000 trades between a range specified in UNIX timestamps by the "start" and "end" GET parameters.</para>
        /// <para>Required : currencyPair (MKT_SYM)</para>
        /// <para>Optional : start (unix)</para>
        /// <para>Optional : end (unix)</para>
        /// </summary>
        public static List<PoloniexTradeHistory> getTradeHistory(string symbol, string market, long start = 0, long end = 0)
        {
            List<PoloniexTradeHistory> list = new List<PoloniexTradeHistory>();
            try
            {
                string url = "/public?command=returnTradeHistory&currencyPair=" + market + "_" + symbol;

                if (start > 0 && end > 0)
                {
                    url += "&start=" + start + "&end=" + end;
                }
                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getTradeHistory", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                PoloniexTradeHistory[] array = jsonVal.ToObject<PoloniexTradeHistory[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTradeHistory", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // -------------------------------------------------------------
        private static string getHMAC(string message)
        {
            var hmac = new HMACSHA512(Encoding.ASCII.GetBytes(Api.secret));
            var messagebyte = Encoding.ASCII.GetBytes(message);
            var hashmessage = hmac.ComputeHash(messagebyte);
            var sign = BitConverter.ToString(hashmessage).Replace("-", "").ToLower();
            return sign;
        }
        private static async Task<string> getPrivateApiRequestAsync(string privUrl, string myParam)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(privUrl);
                StringContent myContent = new StringContent(myParam);
                myContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                client.DefaultRequestHeaders.Add("Key", Api.key);
                client.DefaultRequestHeaders.Add("Sign", getHMAC(myParam));
                var result = await client.PostAsync(privUrl, myContent);
                return await result.Content.ReadAsStringAsync();
            }
        }
        // -------------------------------------------------------------
        /// <summary>returnBalances
        /// <para>Returns all of your available balances.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<List<PoloniexBalance>> getBalanceList()
        {
            List<PoloniexBalance> list = new List<PoloniexBalance>();
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string myParam = "command=returnBalances&nonce=" + ExchangeManager.GetNonce();
                string result = await getPrivateApiRequestAsync(url, myParam);
                //LogManager.AddLogMessage(Name, "getBalances", "result=" + result);

                var jsonObject = JObject.Parse(result);

                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(Name, "getBalances", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                    PoloniexBalance balance = new PoloniexBalance();
                    balance.symbol = item.Key;
                    balance.available = Convert.ToDecimal(item.Value);
                    list.Add(balance);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalances", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnCompleteBalances
        /// <para>Returns all of your balances, including available balance, balance on orders, and the estimated BTC value of your balance. By default, this call is limited to your exchange account; set the "account" POST parameter to "all" to include your margin and lending accounts.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<List<PoloniexBalance>> getCompleteBalanceList()
        {
            List<PoloniexBalance> list = new List<PoloniexBalance>();
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string myParam = "command=returnCompleteBalances&nonce=" + ExchangeManager.GetNonce();
                string result = await getPrivateApiRequestAsync(url, myParam);
                //LogManager.AddLogMessage(Name, "getCompleteBalances", "result=" + result);
                var jsonObject = JObject.Parse(result);

                foreach (var item in jsonObject)
                {
                    PoloniexBalance balance = jsonObject[item.Key].ToObject<PoloniexBalance>();
                    balance.symbol = item.Key;
                    list.Add(balance);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCompleteBalances", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnDepositAddresses
        /// <para>Returns all of your deposit addresses.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<List<PoloniexWallet>> getDepositAddressList()
        {
            List<PoloniexWallet> list = new List<PoloniexWallet>();
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string myParam = "command=returnDepositAddresses&nonce=" + ExchangeManager.GetNonce();
                string result = await getPrivateApiRequestAsync(url, myParam);
                //LogManager.AddLogMessage("PoloniexManager", "getDepositAddresses", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);

                foreach (var item in jsonObject)
                {
                    PoloniexWallet wallet = new PoloniexWallet();
                    wallet.symbol = item.Key;
                    wallet.address = item.Value.ToString();
                    list.Add(wallet);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getDepositAddresses", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnDepositsWithdrawals
        /// <para>Returns your deposit and withdrawal history within a range, specified by the "start" and "end" POST parameters, both of which should be given as UNIX timestamps.</para>
        /// <para>Required : start (unix)</para>
        /// <para>Required : end (unix)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<List<PoloniexTransaction>> getDepositsWithdrawalsList(long start, long end)
        {
            List<PoloniexTransaction> list = new List<PoloniexTransaction>();
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string parameters = "command=returnDepositsWithdrawals&start=" + start + "&end=" + end + "&nonce=" + ExchangeManager.GetNonce();
                string result = await getPrivateApiRequestAsync(url, parameters);
                //LogManager.AddLogMessage(Name, "getDepositsWithdrawals", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                List<PoloniexTransaction> deposits = jsonObject["deposits"].ToObject<List<PoloniexTransaction>>();
                List<PoloniexTransaction> withdrawals = jsonObject["withdrawals"].ToObject<List<PoloniexTransaction>>();
                foreach (PoloniexTransaction deposit in deposits)
                {
                    deposit.type = "deposit";
                    list.Add(deposit);
                }

                foreach (PoloniexTransaction withdrawal in withdrawals)
                {
                    withdrawal.type = "withdraw";
                    list.Add(withdrawal);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getDepositAddresses", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>generateNewAddress
        /// <para>Generates a new deposit address for the currency specified by the "currency" POST parameter.</para>
        /// <para>Required : currency (BTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<string> getNewAddresses(string currency)
        {
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string myParam = "command=generateNewAddress&currency=" + currency + "&nonce=" + ExchangeManager.GetNonce();
                string result = await getPrivateApiRequestAsync(url, myParam);
                //LogManager.AddLogMessage("PoloniexManager", "getNewAddresses", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                int success = Convert.ToInt32(jsonObject["success"]);

                if (success == 1)
                {
                    return jsonObject["response"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getNewAddresses", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return string.Empty;
            }     
        }

        /// <summary>returnOpenOrder
        /// <para>Returns your open orders for a given market, specified by the "currencyPair" POST parameter, e.g. "BTC_XCP".</para>
        /// <para>Required : currencyPair (MKT_SYM) - Set "currencyPair" to "all" to return open orders for all markets.</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<List<PoloniexOpenOrder>> getOpenOrdersList(string market, string symbol)
        {
            List<PoloniexOpenOrder> list = new List<PoloniexOpenOrder>();
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string param = "command=returnOpenOrders&currencyPair=" + market + "_" + symbol + "&nonce=" + ExchangeManager.GetNonce();
                Boolean isAll = (symbol.ToLower() == "all" || market.ToLower() == "all");

                if (isAll)
                {
                    param = "command=returnOpenOrders&currencyPair=all&nonce=" + ExchangeManager.GetNonce();
                }

                string result = await getPrivateApiRequestAsync(url, param);
                //LogManager.AddLogMessage(Name, "getOpenOrders", "result=" + result, LogManager.LogMessageType.DEBUG);

                if (isAll)
                {
                    var jsonObject = JObject.Parse(result);

                    foreach (var item in jsonObject)
                    {
                        //LogManager.AddDebugMessage(Name, "returnOpenOrders", item.Key + " | " + item.Value);

                        PoloniexOpenOrder[] orders = jsonObject[item.Key].ToObject<PoloniexOpenOrder[]>();
                        //LogManager.AddDebugMessage(Name, "returnOpenOrders", "count=" + orders.Count());
                        if (orders.Count() > 0)
                        {
                            foreach (PoloniexOpenOrder order in orders)
                            {
                                order.pair = item.Key;
                                string[] pairSplit = order.pair.Split('_');
                                order.market = pairSplit[0];
                                order.symbol = pairSplit[1];
                                list.Add(order);
                            }
                        }
                    }
                }
                else
                {
                    JArray jsonVal = JArray.Parse(result) as JArray;
                    List<PoloniexOpenOrder> resultList = jsonVal.ToObject<List<PoloniexOpenOrder>>();

                    foreach (PoloniexOpenOrder order in resultList)
                    {
                        order.symbol = symbol;
                        order.market = market;
                        order.pair = market + "_" + symbol;
                        list.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOpenOrders", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnOrderTrades
        /// <para>Returns all trades involving a given order, specified by the "orderNumber" POST parameter. If no trades for the order have occurred or you specify an order that does not belong to you, you will receive an error.</para>
        /// <para>Required : orderNumber</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<List<PoloniexTradeHistory>> getOrderTradesList(string orderNumber)
        {
            List<PoloniexTradeHistory> list = new List<PoloniexTradeHistory>();
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string param = "command=returnOrderTrades&orderNumber=" + orderNumber + "&nonce=" + ExchangeManager.GetNonce();
                string result = await getPrivateApiRequestAsync(url, param);
                //LogManager.AddLogMessage(Name, "getOrderTradesList", "result=" + result, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(result) as JArray;
                list = jsonVal.ToObject<List<PoloniexTradeHistory>>();

                foreach (PoloniexTradeHistory item in list)
                {
                    item.pair = item.currencyPair;
                    string[] pairSplit = item.pair.Split('_');
                    item.symbol = pairSplit[1];
                    item.market = pairSplit[0];
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderTradesList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>returnTradeHistory
        /// <para>Returns your trade history for a given market, specified by the "currencyPair" POST parameter. You may optionally specify a range via "start" and/or "end" POST parameters, given in UNIX timestamp format; if you do not specify a range, it will be limited to one day.</para>
        /// <para>Required : currencyPair (MKT_SYM) - You may specify "all" as the currencyPair to receive your trade history for all markets.</para>
        /// <para>Optional : start (unix)</para>
        /// <para>Optional : end (unix)</para>
        /// <para>Optional : limit - You may optionally limit the number of entries returned using the "limit" parameter, up to a maximum of 10,000. If the "limit" parameter is not specified, no more than 500 entries will be returned.</para>
        /// </summary>
        public static async Task<List<PoloniexTradeHistory>> getTradeHistoryList(string market, string symbol, long unixStart = 0, long unixEnd = 0, int limit = 500) // limit up to 10,000
        {
            List<PoloniexTradeHistory> list = new List<PoloniexTradeHistory>();

            try
            {
                string url = "https://poloniex.com/tradingApi";
                string param = String.Empty;
                Boolean isAll = (symbol.ToLower() == "all" || market.ToLower() == "all");

                if (isAll)
                {
                    param = "command=returnTradeHistory&currencyPair=all&nonce=" + ExchangeManager.GetNonce();
                }
                else
                {
                    param = "command=returnTradeHistory&currencyPair=" + market + "_" + symbol + "&nonce=" + ExchangeManager.GetNonce();
                }

                if (unixStart > 0)
                {
                    param += "&start=" + unixStart;

                    if (unixEnd > 0)
                    {
                        param += "&end=" + unixEnd;
                    }
                }

                if (limit > 500)
                {
                    param += "&limit=" + limit;
                }
                //LogManager.AddDebugMessage(Name, "returnTradeHistory", "param=" + param);

                string result = await getPrivateApiRequestAsync(url, param);
                //LogManager.AddDebugMessage(Name, "returnTradeHistory", "result=" + result);

                if (isAll)
                {
                    // OBJECT        
                    var jsonObject = JObject.Parse(result);
                    list = new List<PoloniexTradeHistory>();

                    foreach (var item in jsonObject)
                    {
                        //LogManager.AddDebugMessage(Name, "returnOpenOrders", item.Key + " | " + item.Value);
                        PoloniexTradeHistory[] trades = jsonObject[item.Key].ToObject<PoloniexTradeHistory[]>();
                        if (trades.Count() > 0)
                        {
                            foreach (PoloniexTradeHistory trade in trades)
                            {
                                trade.pair = item.Key;
                                string[] pairSplit = trade.pair.Split('_');
                                trade.market = pairSplit[0];
                                trade.symbol = pairSplit[1];
                                list.Add(trade);
                            }
                        }
                    }
                }
                else
                {
                    // ARRAY
                    JArray jsonVal = JArray.Parse(result) as JArray;
                    list = jsonVal.ToObject<List<PoloniexTradeHistory>>();

                    foreach (PoloniexTradeHistory item in list)
                    {
                        item.symbol = symbol;
                        item.market = market;
                        item.pair = market + "_" + symbol;
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderTradesList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;  
        }
        #endregion

        #region API_PRIVATE_Setters
        /// <summary>buy
        /// <para>Places a limit buy order in a given market. If successful, the method will return the order number.</para>
        /// <para>Required : currencyPair (MKT_SYM)</para>
        /// <para>Required : rate</para>
        /// <para>Required : amount</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<PoloniexNewOrderResult> setBuy(string market, string symbol, Decimal rate, Decimal amount, PoloniexOrderOption option = PoloniexOrderOption.None) //You may optionally set "fillOrKill", "immediateOrCancel", "postOnly" to 1.
        {
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string param = "command=buy&currencyPair=" + market + "_" + symbol + "&rate=" + rate + "&amount=" + amount + "&nonce=" + ExchangeManager.GetNonce();

                if (option != PoloniexOrderOption.None)
                {
                    param += "&" + option + "=1";
                }
                string result = await getPrivateApiRequestAsync(url, param);
                //LogManager.AddLogMessage(Name, "setBuy", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                return jsonObject.ToObject<PoloniexNewOrderResult>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setBuy", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>cancelOrder
        /// <para>Cancels an order you have placed in a given market. Required POST parameter is "orderNumber".</para>
        /// <para>Required : orderNumber</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<Boolean> setCancel(string orderNumber)
        {
            string url = "https://poloniex.com/tradingApi";

            string myParam = "command=cancelOrder&orderNumber=" + orderNumber + "&nonce=" + ExchangeManager.GetNonce();
            string result = await getPrivateApiRequestAsync(url, myParam);
            //LogManager.AddDebugMessage(Name, "cancelOrder", "result=" + result);
            var jsonObject = JObject.Parse(result);
            PoloniexCancelResult cancelResult = jsonObject.ToObject<PoloniexCancelResult>();
            if (cancelResult.success == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>sell
        /// <para>Places a limit sell order in a given market. If successful, the method will return the order number.</para>
        /// <para>Required : currencyPair (MKT_SYM)</para>
        /// <para>Required : rate</para>
        /// <para>Required : amount</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static async Task<PoloniexNewOrderResult> setSell(string symbol, string market, Decimal rate, Decimal amount, PoloniexOrderOption option = PoloniexOrderOption.None) //You may optionally set "fillOrKill", "immediateOrCancel", "postOnly" to 1.
        {
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string param = "command=sell&currencyPair=" + market + "_" + symbol + "&rate=" + rate + "&amount=" + amount + "&nonce=" + ExchangeManager.GetNonce();

                if (option != PoloniexOrderOption.None)
                {
                    param += "&" + option + "=1";
                }
                //LogManager.AddDebugMessage(Name, "setSell", "option=" + option + " | " + param);
                string result = await getPrivateApiRequestAsync(url, param);
                //LogManager.AddDebugMessage(Name, "setSell", "result=" + result);
                //return new JavaScriptSerializer().Deserialize<PoloniexNewOrderResult>(result);
                return null;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setSell", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        #endregion

        #region API_PRIVATE_TBD
        // NOT IMPLEMENTED
        // moveOrder - Cancels an order and places a new one of the same type in a single atomic transaction
        // withdraw
        // returnFeeInfo - If you are enrolled in the maker-taker fee schedule, returns your current trading fees and trailing 30-day volume in BTC
        // returnAvailableAccountBalances - Returns your balances sorted by account
        // returnTradableBalances - Returns your current tradable balances for each currency in each market for which margin trading is enabled
        // transferBalance - Transfers funds from one account to another (e.g. from your exchange account to your margin account)
        // returnMarginAccountSummary - Returns a summary of your entire margin account
        // marginBuy
        // marginSell
        // getMarginPosition
        // closeMarginPosition
        // createLoanOffer
        // cancelLoanOffer
        // returnOpenLoanOffers
        // returnActiveLoans
        // returnLendingHistory
        // toggleAutoRenew
        #endregion
        #endregion API_Private

        #region ExchangeManager
        // INITIALIZE
        public static void InitializeExchange()
        {
            LogManager.AddLogMessage(Name, "InitializeExchange", "Initialized", LogManager.LogMessageType.EXCHANGE);
            updateExchangeTickerList();
        }
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();
            List<PoloniexTicker> tickerList = getTickerList();

            foreach(PoloniexTicker ticker in tickerList)
            {
                list.Add(ticker.GetExchangeTicker());
            }

            return list;
        }
        // UPDATERS
        public async static void updateExchangeBalanceList()
        {
            List<PoloniexBalance> list = await getCompleteBalanceList();
            ExchangeTicker btcTicker = ExchangeManager.getExchangeTicker(Name, "BTC", USDSymbol);
            
            foreach (PoloniexBalance balance in list)
            {
                if (balance.total > 0)
                {
                    if (balance.symbol != "BTC" && balance.symbol != USDSymbol)
                    {
                        // GET TICKER FOR PAIR IN BTC MARKET
                        ExchangeTicker ticker = ExchangeManager.getExchangeTicker(Name, balance.symbol.ToUpper(), "BTC");

                        if (ticker != null)
                        {
                            balance.TotalInBTC = balance.total * ticker.last;
                            balance.TotalInUSD = btcTicker.last * balance.TotalInBTC;
                        }
                        else
                        {
                            LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "EXCHANGE TICKER WAS NULL : " + Name + " | " + balance.symbol.ToUpper());
                        }
                    }
                    else
                    {
                        //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "CHECKING CURRENCY :" + balance.Currency, LogManager.LogMessageType.DEBUG);
                        if (balance.symbol == "BTC")
                        {
                            balance.TotalInBTC = balance.total;
                            balance.TotalInUSD = btcTicker.last * balance.total;
                        }
                        else if (balance.symbol == USDSymbol)
                        {
                            if (btcTicker.last > 0)
                            {
                                balance.TotalInBTC = balance.total / btcTicker.last;
                            }
                            balance.TotalInUSD = balance.total;
                        }
                    }
                    //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", balance.Currency + " | " + balance.Balance + " | " + balance.TotalInBTC + " | " + balance.TotalInUSD, LogManager.LogMessageType.DEBUG);
                    ExchangeManager.processBalance(balance.GetExchangeBalance());
                }     
            }
        }
        public static void updateExchangeTickerList()
        {
            List<PoloniexTicker> list = getTickerList();

            foreach (PoloniexTicker ticker in list)
            {
                ExchangeManager.processTicker(ticker.GetExchangeTicker());
            }
        }
        #endregion ExchangeManager

        #region DataModels
        #region DATAMODELS_Enumerables  
        public enum PoloniexChartPeriod : Int32
        {
            // 300, 900, 1800, 7200, 14400, and 86400 - candlestick period in seconds
            None = 0,
            Minutes_5 = 300,
            Minutes_15 = 900,
            Minutes_30 = 1800,
            Hours_2 = 7200,
            Hours_4 = 14400,
            Hours_24 = 86400
        };
        public enum PoloniexOrderOption : Int32
        {
            //You may optionally set "fillOrKill", "immediateOrCancel", "postOnly" to 1.   
            [Description("Normal Order")]
            None = 0,
            [Description("A fill-or-kill order will either fill in its entirety or be completely aborted.")]
            fillOrKill = 1,
            [Description("An immediate-or-cancel order can be partially or completely filled, but any portion of the order that cannot be filled immediately will be canceled rather than left on the order book.")]
            immediateOrCancel = 2,
            [Description("A post-only order will only be placed if no portion of it fills immediately; this guarantees you will never pay the taker fee on any part of the order that fills.")]
            postOnly = 3
        };
        #endregion
        #region DATAMODELS_Public
        public class PoloniexChartData
        {
            //public Double date { get; set; }
            public long date { get; set; }

            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeSeconds(date).UtcDateTime.ToLocalTime();
                }
                /*
                set
                {

                }
                */
            }

            public double high { get; set; }
            public double low { get; set; }
            public double open { get; set; }
            public double close { get; set; }
            public double volume { get; set; }
            public double quoteVolume { get; set; }
            public double weightedAverage { get; set; }
        }
        public class PoloniexChartDataParameters
        {
            /// <summary>Symbol identifier of the currency pair.
            /// <para>REQUIRED</para>
            /// </summary>
            [Category("required")]
            public string symbol { get; set; } = String.Empty;

            /// <summary>Market identifier of the currency pair.
            /// <para>REQUIRED</para>
            /// </summary>
            [Category("required")]
            public string market { get; set; } = String.Empty;

            /// <summary>Candlestick period in seconds; valid values are 300, 900, 1800, 7200, 14400, and 86400
            /// <para>REQUIRED</para>
            /// </summary>
            [Category("required")]
            public PoloniexChartPeriod period { get; set; } = PoloniexChartPeriod.Minutes_5;

            /// <summary>Start Time. (in UNIX Time format in milliseconds)
            /// <para>REQUIRED</para>
            /// </summary>
            [Category("required")]
            public long start { get; set; } = 0;

            /// <summary>End Time. (in UNIX Time format in milliseconds)
            /// <para>REQUIRED</para>
            /// </summary>
            [Category("required")]
            public long end { get; set; } = 0;
        }
        public class PoloniexCurrency
        {
            public string symbol { get; set; }

            public int id { get; set; }
            public string name { get; set; }
            public string txFee { get; set; }
            public int minConf { get; set; }
            public object depositAddress { get; set; }
            public int disabled { get; set; }
            public int delisted { get; set; }
            public int frozen { get; set; }
        }
        public class PoloniexLoanOrder
        {
            public string rate { get; set; }
            public string amount { get; set; }
            public int rangeMin { get; set; }
            public int rangeMax { get; set; }
            // ADDON
            public string symbol { get; set; }
            public string type { get; set; }
        }
        public class PoloniexOrderBookData
        {
            public Decimal rate { get; set; }
            public Decimal quantity { get; set; }
        }
        public class PoloniexOrderBookItem
        {
            public List<List<object>> asks { get; set; }
            public List<List<object>> bids { get; set; }

            public string isFrozen { get; set; }
            public int seq { get; set; }
            // ADDON
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
        }
        public class PoloniexTicker
        {
            public int id { get; set; }
            public string pair { get; set; }
            public Decimal last { get; set; }
            public Decimal lowestAsk { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public int isFrozen { get; set; }
            public Decimal high24hr { get; set; }
            public Decimal low24hr { get; set; }
            public ExchangeTicker GetExchangeTicker()
            {
                ExchangeTicker eTicker = new ExchangeTicker();
                eTicker.exchange = Name;
                string[] pairs = pair.Split('_');
                eTicker.market = pairs[0];
                eTicker.symbol = pairs[1];
                eTicker.last = last;
                eTicker.ask = lowestAsk;
                eTicker.bid = highestBid;
                eTicker.change = percentChange;
                eTicker.volume = baseVolume;
                eTicker.high = high24hr;
                eTicker.low = low24hr;
                return eTicker;
            }
        }
        public class Poloniex24hVolume
        {
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }

            public Decimal symbolVolume { get; set; }
            public Decimal marketVolume { get; set; }
        }
        #endregion
        #region DATAMODELS_Private
        public class PoloniexBalance
        {
            public string symbol { get; set; }
            public Decimal available { get; set; }
            public Decimal onOrders { get; set; }
            public Decimal btcValue { get; set; }
            public Decimal total { get { return available + onOrders; } }
            // ADDON DATA
            public Decimal TotalInBTC { get; set; } = 0;
            public Decimal TotalInUSD { get; set; } = 0;
            public ExchangeBalance GetExchangeBalance()
            {
                ExchangeBalance eBalance = new ExchangeBalance();
                if (symbol != "STR")
                {
                    eBalance.Symbol = symbol;
                }
                else
                {
                    eBalance.Symbol = "XLM";
                }
                eBalance.Exchange = Name;
                eBalance.Balance = available + onOrders;
                eBalance.OnOrders = onOrders;
                eBalance.TotalInBTC = TotalInBTC;
                eBalance.TotalInUSD = TotalInUSD;
                return eBalance;
            }
        }
        public class PoloniexCancelResult
        {
            public int success { get; set; }
        }
        public class PoloniexOpenOrder
        {
            public string orderNumber { get; set; }
            public string type { get; set; }
            public Double rate { get; set; }
            public Double startingAmount { get; set; }
            public Double amount { get; set; }
            public Double total { get; set; }
            public DateTime date { get; set; }
            public int margin { get; set; }
            // ADDON
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
        }
        public class PoloniexResultingTrade
        {
            public string amount { get; set; }
            public string date { get; set; }
            public string rate { get; set; }
            public string total { get; set; }
            public string tradeID { get; set; }
            public string type { get; set; }
        }
        public class PoloniexNewOrderResult
        {
            public long orderNumber { get; set; }
            public List<PoloniexResultingTrade> resultingTrades { get; set; }
        }
        public class PoloniexTradeHistory
        {
            public string globalTradeID { get; set; }
            public string tradeID { get; set; }
            public DateTime date { get; set; }
            public Double rate { get; set; }
            public Double amount { get; set; }
            public Double total { get; set; }
            public Double fee { get; set; }
            public string orderNumber { get; set; }
            public string type { get; set; }
            public string category { get; set; }
            public string currencyPair { get; set; }
            // ADDON
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
        }
        public class PoloniexWallet
        {
            public string symbol { get; set; }
            public string address { get; set; }
        }
        public class PoloniexTransaction
        {
            public string type { get; set; } // deposit or withdraw
                                             // DEPOSIT
            public string currency { get; set; }
            public string address { get; set; }
            public Double amount { get; set; }
            public int confirmations { get; set; }
            public string txid { get; set; }
            public long timestamp { get; set; }
            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime.ToLocalTime();
                }
            }
            public string status { get; set; }
            // WITHDRAWAL
            public int withdrawalNumber { get; set; }
            public Double fee { get; set; }
            public string ipAddress { get; set; }
        }
        public class PoloniexDeposit
        {
            public string currency { get; set; }
            public string address { get; set; }
            public Double amount { get; set; }
            public int confirmations { get; set; }
            public string txid { get; set; }
            public long timestamp { get; set; }
            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime.ToLocalTime();
                }
                /*
                set
                {

                }
                */
            }
            public string status { get; set; }
        }
        public class PoloniexWithdrawal
        {
            public int withdrawalNumber { get; set; }
            public string currency { get; set; }
            public string address { get; set; }
            public Double amount { get; set; }
            public Double fee { get; set; }
            public long timestamp { get; set; }
            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime.ToLocalTime();
                }
                /*
                set
                {

                }
                */
            }
            public string status { get; set; }
            public string ipAddress { get; set; }
        }
        #endregion
        #endregion DataModels
    }
}
