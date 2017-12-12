using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TwEX_API.Exchange
{
    public class YoBit
    {
        #region Properties
        public static String thisClassName = "YoBit";
        public static string ApiKey = String.Empty;
        public static string ApiSecret = String.Empty;
        private static RestClient client = new RestClient("https://yobit.net/api");
        public static string Api_privateUrl = "https://yobit.net/tapi/";
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
            try
            {
                var request = new RestRequest("/3/info", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getInfoList", "Response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                var pairsObject = JObject.Parse(jsonObject["pairs"].ToString());

                foreach (var item in pairsObject)
                {
                    //LogManager.AddLogMessage(thisClassName, "getInfo", item.Key + " | " + item.Value);
                    YoBitInfo info = pairsObject[item.Key].ToObject<YoBitInfo>();
                    info.pair = item.Key;
                    string[] pairs = info.pair.Split('_');
                    info.symbol = pairs[0];
                    info.market = pairs[1];
                    list.Add(info);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getInfoList", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                //LogManager.AddLogMessage(thisClassName, "getOrderBook", "Response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(thisClassName, "getOrderBook", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
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
                LogManager.AddLogMessage(thisClassName, "getOrderBook", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                LogManager.AddLogMessage(thisClassName, "getTicker", "tickerResponse.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                YoBitTicker ticker = jsonObject[pair].ToObject<YoBitTicker>();
                ticker.pair = pair;
                ticker.symbol = symbol;
                ticker.market = market;
                return ticker;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getTicker", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }
        /// <summary>ticker (LIST)
        /// <para>Method provides list of statistic data for the last 24 hours.</para>
        /// <para>Required : pairs - ARRAY of STRING (sym_mkt)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<YoBitTicker> getTickerList(string[] pairsArray)
        {
            List<YoBitTicker> list = new List<YoBitTicker>();   
            try
            {
                string pairs = string.Join("-", pairsArray);
                //LogManager.AddLogMessage(thisClassName, "getTickerList", pairs ,LogManager.LogMessageType.DEBUG); 
                var request = new RestRequest("/3/ticker/" + pairs, Method.GET);
                var response = client.Execute(request);
                LogManager.AddLogMessage(thisClassName, "getTicker", "tickerResponse.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                
                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(thisClassName, "getTicker", item.Key + " | " + item.Value);
                    YoBitTicker ticker = jsonObject[item.Key].ToObject<YoBitTicker>();
                    ticker.pair = item.Key;
                    string[] pairSplit = ticker.pair.Split('_');
                    ticker.symbol = pairSplit[0];
                    ticker.market = pairSplit[1];
                    list.Add(ticker);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "returnTicker", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                //LogManager.AddLogMessage(thisClassName, "getTradeList", "Response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);

                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(thisClassName, "getTradeList", item.Key + " | " + item.Value);
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
                LogManager.AddLogMessage(thisClassName, "getTradeList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion API_Public

        #region API_Private
        // ------------------------
        private static string getHMAC(string message)
        {
            var hmac = new HMACSHA512(Encoding.ASCII.GetBytes(ApiSecret));
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
                c.Headers.Add("Key", ApiKey);

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
            try
            {
                string req = "method=getInfo&nonce=" + ExchangeManager.GetNonce();
                string result = await SendPrivateApiRequestAsync(req);
                result = result.Replace("return", "results");
                //LogManager.AddLogMessage(thisClassName, "getInfo", "result=" + result, LogManager.LogMessageType.DEBUG);
                var balancejsonData = JObject.Parse(result);
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
                            LogManager.AddLogMessage(thisClassName, "GetBalances", "NOT IN BList already (WHY???) : " + f.Key + " | " + f.Value, LogManager.LogMessageType.DEBUG);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getBalances", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                //LogManager.AddLogMessage(thisClassName, "getOpenOrdersList", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                int isSuccess = Convert.ToInt32(jsonObject["success"]);

                if (isSuccess > 0)
                {
                    var results = JObject.Parse(jsonObject["results"].ToString());
                    foreach (var item in results)
                    {
                        //LogManager.AddLogMessage(thisClassName, "getOpenOrdersList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
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
                LogManager.AddLogMessage(thisClassName, "getOpenOrdersList", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                //LogManager.AddLogMessage(thisClassName, "getOrderInfoList", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                int isSuccess = Convert.ToInt32(jsonObject["success"]);

                if (isSuccess > 0)
                {         
                    var results = JObject.Parse(jsonObject["results"].ToString());
                    foreach (var item in results)
                    {
                        //LogManager.AddLogMessage(thisClassName, "getOrderInfoList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
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
                LogManager.AddLogMessage(thisClassName, "getOrderInfoList", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                LogManager.AddLogMessage(thisClassName, "getTradeHistoryList", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                
                int isSuccess = Convert.ToInt32(jsonObject["success"]);

                if (isSuccess > 0)
                {     
                    var results = JObject.Parse(jsonObject["results"].ToString());
                    foreach (var item in results)
                    {
                        //LogManager.AddLogMessage(thisClassName, "getTradeHistoryList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
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
                LogManager.AddLogMessage(thisClassName, "getTradeHistoryList", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
            //public Decimal totalBTC { get; set; }
            //public Decimal totalCoins { get; set; }
            //public Decimal totalUSD { get; set; }
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