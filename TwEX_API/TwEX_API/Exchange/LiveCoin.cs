using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    public class LiveCoin
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "LiveCoin";
        public static string Url { get; } = "https://www.livecoin.net";
        public static string USDSymbol { get; } = "USDT";
        // API
        public static ExchangeApi Api { get; set; }
        private static RestClient client = new RestClient("https://api.livecoin.net");
        private static string Api_privateUrl = "https://api.livecoin.net/";
        #endregion Properties

        #region Api_Public
        #region API_PUBLIC_Getters
        /// <summary>/info/coinInfo
        /// <para>Returns public data for currencies</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static LiveCoinCoinInfoMessage getCoinInfo()
        {
            try
            {
                var request = new RestRequest("info/coinInfo", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCoinInfo", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<LiveCoinCoinInfoMessage>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCoinInfo", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/exchange/last_trades
        /// <para>To retrieve information on the latest transactions for a specified currency pair. You may receive data within the last hour or the last minute.</para>
        /// <para>Required : currencyPair (SYM/MKT)</para>
        /// <para>Optional : minutesOrHour - Return information for the last minute if true. Return information for the last hour if false (DEFAULT).</para>
        /// <para>Optional : type - Possible values: BUY SELL BOTH (DEFAULT)</para>
        /// </summary>
        public static List<LiveCoinPublicTrade> getLastTradesList(string symbol, string market, Boolean minutesOrHour = false, LiveCoinTradeType type = LiveCoinTradeType.BOTH)
        {
            List<LiveCoinPublicTrade> list = new List<LiveCoinPublicTrade>();
            try
            {
                string requestUrl = "/exchange/last_trades?currencyPair=" + symbol.ToUpper() + "/" + market.ToUpper() + "&minutesOrHour=" + minutesOrHour;
                if (type != LiveCoinTradeType.BOTH)
                {
                    requestUrl += "&type=" + type;
                }

                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getLastTradesList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                LiveCoinPublicTrade[] array = jsonVal.ToObject<LiveCoinPublicTrade[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getLastTradesList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/exchange/maxbid_minask
        /// <para>Returns maximum bid and minimum ask in current orderbook</para>
        /// <para>Required : none</para>
        /// <para>Optional : currencyPair - (SYM/MKT) All if not specified</para>
        /// </summary>
        public static List<LiveCoinMaxMinData> getMaxMinList(string symbol = "", string market = "")
        {
            List<LiveCoinMaxMinData> list = new List<LiveCoinMaxMinData>();
            try
            {
                string requestUrl = "/exchange/maxbid_minask";
                if (symbol.Length > 0 && market.Length > 0)
                {
                    requestUrl += "?currencyPair=" + symbol.ToUpper() + "/" + market.ToUpper();
                }
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                LogManager.AddLogMessage(Name, "getMaxMinList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                list = jsonObject["currencyPairs"].ToObject<List<LiveCoinMaxMinData>>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMaxMinList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/exchange/order_book
        /// <para>Used to get the orderbook for a given market (the grouping attribute can be set by price)</para>
        /// <para>Required : currencyPair (SYM/MKT)</para>
        /// <para>Optional : groupByPrice - If true then orders will be grouped by prices. False (default)</para>
        /// <para>Optional : depth - Maximum amount of bids (asks) in response.</para>
        /// </summary>
        public static LiveCoinOrderBookResult getOrderBook(string symbol, string market, Boolean groupByPrice = false, int depth = 1000)
        {
            try
            {
                string requestUrl = "/exchange/order_book?currencyPair=" + symbol.ToUpper() + "/" + market.ToUpper() + "&groupByPrice=" + groupByPrice + "&depth=" + depth;
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getLastTradesList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<LiveCoinOrderBookResult>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getLastTradesList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/exchange/all/order_book
        /// <para>Returns orderbook for every currency pair</para>
        /// <para>Required : none</para>
        /// <para>Optional : grouByPrice - If true then orders will be grouped by prices. false (DEFAULT)</para>
        /// <para>Optional : depth - Maximum amount of bids (asks) in response. Max.value - 10, by default - 10</para>
        /// </summary>
        public static List<LiveCoinOrderBookResult> getOrderBooksList(Boolean groupByPrice = false, int depth = 10)
        {
            List<LiveCoinOrderBookResult> list = new List<LiveCoinOrderBookResult>();
            try
            {
                string requestUrl = "exchange/all/order_book?groupByPrice=" + groupByPrice + "&depth=" + depth;
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getLastTradesList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);

                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(Name, "getOrderBooksList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                    LiveCoinOrderBookResult orderBook = jsonObject[item.Key].ToObject<LiveCoinOrderBookResult>();
                    string[] pairSplit = item.Key.ToString().Split('/');
                    orderBook.symbol = pairSplit[0];
                    orderBook.market = pairSplit[1];
                    list.Add(orderBook);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderBooksList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/exchange/restrictions
        /// <para>Returns limits for minimum amount to open order, for each pair. Also returns maximum number of digits after the decimal point for price.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static LiveCoinRestrictionMessage getRestrictions()
        {
            try
            {
                string requestUrl = "exchange/restrictions";
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getRestrictions", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<LiveCoinRestrictionMessage>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getRestrictions", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/exchange/ticker
        /// <para>To retrieve information on a particular currency pair for the last 24 hours.</para>
        /// <para>Required : currencyPair (SYM/MKT)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static LiveCoinTicker getTicker(string symbol, string market)
        {
            try
            {
                string requestUrl = "?currencyPair=" + symbol.ToUpper() + "/" + market.ToUpper();
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getTickerList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<LiveCoinTicker>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTickerList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/exchange/ticker
        /// <para>To retrieve information on all currency pairs for the last 24 hours.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<LiveCoinTicker> getTickerList()
        {
            List<LiveCoinTicker> list = new List<LiveCoinTicker>();
            try
            {
                string requestUrl = "/exchange/ticker";
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getTickerList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                LiveCoinTicker[] array = jsonVal.ToObject<LiveCoinTicker[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTickerList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion
        #endregion Api_Public

        #region Api_Private
        #region API_PRIVATE_Getters
        // ------------------------
        private static string getApiPrivateRequest(string requestUrl, String parameters)
        {
            string ResponseFromServer = "";
            //string parameterString = getParameterString(parameters);
            //string uri = requestUrl + parameterString;

            //string Sign = getHashHMAC(ApiSecret, parameterString).ToUpper();
            string Sign = getHashHMAC(Api.secret, parameters).ToUpper();
            LogManager.AddLogMessage(Name, "getApiPrivateRequest", requestUrl + parameters);
            HttpStatusCode StatusCode;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl + parameters);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            request.Headers["Api-Key"] = Api.key;
            request.Headers["Sign"] = Sign;

            Stream dataStream;
            try
            {
                WebResponse WebResponse = request.GetResponse();
                dataStream = WebResponse.GetResponseStream();
                StreamReader StreamReader = new StreamReader(dataStream);
                ResponseFromServer = StreamReader.ReadToEnd();
                dataStream.Close();
                WebResponse.Close();
                StatusCode = HttpStatusCode.OK;
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    dataStream = ex.Response.GetResponseStream();
                    StreamReader StreamReader = new StreamReader(dataStream);
                    StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
                    ResponseFromServer = ex.Message;
                }
                else
                {
                    StatusCode = HttpStatusCode.ExpectationFailed;
                    ResponseFromServer = "WE : No Response";
                }
            }
            catch (Exception ex)
            {
                StatusCode = HttpStatusCode.ExpectationFailed;
                ResponseFromServer = "?? : No Response : " + ex.Message;
            }
            return ResponseFromServer;
        }
        private static string getHashHMAC(string key, string message)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(key);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);

            byte[] messageBytes = encoding.GetBytes(message);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            return getByteArrayToString(hashmessage);
        }
        public static string getByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public static LiveCoinParameterData getCategoryData(CategoryAttribute[] attributes)
        {
            LiveCoinParameterData data = new LiveCoinParameterData();

            foreach (CategoryAttribute ca in attributes)
            {
                if (ca.Category != "required")
                {
                    string[] stringSplit = ca.Category.Split('|');
                    data.category = stringSplit[0];
                    data.defaultValue = stringSplit[1];
                }
                else
                {
                    data.category = ca.Category;
                    data.defaultValue = String.Empty;
                }
            }
            return data;
        }
        private static string getParameterString(Object parameters)
        {

            //PARAMETERS
            string parameterString = String.Empty;
            PropertyInfo[] propertyInfoArray = parameters.GetType().GetProperties();

            foreach (PropertyInfo property in propertyInfoArray)
            {
                object propValue = property.GetValue(parameters, null);
                //LogManager.AddLogMessage(Name, "getOrdersByCurrencyPairList", prop_info.Name + " | " + propValue);
                string propertyName = property.Name;
                string propertyValue = propValue.ToString();

                CategoryAttribute[] attributes = (CategoryAttribute[])property.GetCustomAttributes(typeof(CategoryAttribute), false);
                LiveCoinParameterData parameterData = getCategoryData(attributes);
                //string category = parameterData.category;
                //string defaultValue = parameterData.defaultValue;
                //Boolean notDefault = (propertyValue == defaultValue);
                //LogManager.AddLogMessage(Name, "getOrdersByCurrencyPairList", propertyName + " | " + propertyValue + " | " + parameterData.category + " | " + parameterData.defaultValue);

                if (parameterData.category == "required")
                {
                    if (parameterString.Length != 0)
                    {
                        parameterString += "&" + propertyName + "=" + propertyValue;
                    }
                    else
                    {
                        parameterString = "?" + propertyName + "=" + propertyValue;
                    }
                }
                else
                {
                    // OPTIONAL - check if theres a value to add
                    if (propertyValue != parameterData.defaultValue)
                    {
                        if (parameterString.Length != 0)
                        {
                            parameterString += "&" + propertyName + "=" + propertyValue;
                        }
                        else
                        {
                            parameterString = "?" + propertyName + "=" + propertyValue;
                        }
                    }
                }

            }
            //LogManager.AddLogMessage(Name, "getOrdersByCurrencyPairList", "parameterString=" + parameterString);
            // END PARAMETERS
            return parameterString;
        }
        // ------------------------
        /// <summary>/payment/balances
        /// <para>Returns an array with your balances. There are four types of balances for every currency: total, available (for trading), trade (amount in open orders), available_withdrawal (amount available for withdrawal)</para>
        /// <para>Required : none</para>
        /// <para>Optional : currency (BTC)</para>
        /// </summary>
        public static List<LiveCoinBalanceTotals> getBalances()
        {
            List<LiveCoinBalanceTotals> list = new List<LiveCoinBalanceTotals>();

            try
            {
                // GET BALANCES
                string param = "";
                string uri = "https://api.livecoin.net/payment/balances";
                string ResponseFromServer = "";
                string Sign = getHashHMAC(Api.secret, param).ToUpper();

                HttpStatusCode StatusCode;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri + param);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";

                request.Headers["Api-Key"] = Api.key;
                request.Headers["Sign"] = Sign;

                Stream dataStream;
                try
                {
                    WebResponse WebResponse = request.GetResponse();
                    dataStream = WebResponse.GetResponseStream();
                    StreamReader StreamReader = new StreamReader(dataStream);
                    ResponseFromServer = StreamReader.ReadToEnd();
                    dataStream.Close();
                    WebResponse.Close();
                    StatusCode = HttpStatusCode.OK;
                }
                catch (WebException ex)
                {
                    if (ex.Response != null)
                    {
                        dataStream = ex.Response.GetResponseStream();
                        StreamReader StreamReader = new StreamReader(dataStream);
                        StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
                        ResponseFromServer = ex.Message;
                    }
                    else
                    {
                        StatusCode = HttpStatusCode.ExpectationFailed;
                        ResponseFromServer = "WE : No Response";
                    }
                }
                catch (Exception ex)
                {
                    StatusCode = HttpStatusCode.ExpectationFailed;
                    ResponseFromServer = "?? : No Response : " + ex.Message;
                }

                //List<LiveCoinBalance> masterList = new JavaScriptSerializer().Deserialize<LiveCoinBalance[]>(ResponseFromServer).ToList();
                //var jsonObject = JObject.Parse(ResponseFromServer);
                JArray jArray = JArray.Parse(ResponseFromServer) as JArray;
                LiveCoinBalance[] array = jArray.ToObject<LiveCoinBalance[]>();
                List<LiveCoinBalance> masterList = array.ToList();
                //List<LiveCoinBalance> masterList = new List<LiveCoinBalance>();
                //LogManager.AddLogMessage(Name, "GetBalances", ResponseFromServer, LogManager.LogMessageType.DEBUG);

                foreach (LiveCoinBalance b in masterList)
                {
                    //LogManager.AddLogMessage("LiveCoinControl", "GetBalances", b.type + " | " + b.currency + " | " + b.value);
                    // CHECK IF THERE IS A balance list ENTRY
                    LiveCoinBalanceTotals lcb = list.FirstOrDefault(lcbitem => lcbitem.currency == b.currency);
                    string bType = b.type;

                    if (lcb != null)
                    {
                        // EXISTS SO SO JUST ADD THIS DATA
                        lcb.SetProperty(b.type, Convert.ToDecimal(b.value));
                    }
                    else
                    {
                        // DOES NOT EXIST SO CREATE AN ENTRY
                        LiveCoinBalanceTotals newTotal = new LiveCoinBalanceTotals();
                        newTotal.currency = b.currency;
                        newTotal.SetProperty(b.type, Convert.ToDecimal(b.value));
                        list.Add(newTotal);
                    }
                }
                //LogManager.AddLogMessage("LiveCoinControl", "GetBalances", "ml count:" + masterList.Count + " | bl count:" + balanceList.Count);
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalances", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }

            return list;
        }

        /// <summary>/exchange/client_orders
        /// <para>To retrieve full information on your trade-orders for the specified currency pair. You can optionally limit the response to orders of a certain type (open, closed, etc.)</para>
        /// <para>Required : none</para>
        /// <para>Optional : currencyPair - (SYM/MKT) Identifier of the currency pair. If not specified, all pairs will be included.</para>
        /// <para>Optional : openClosed - Order type. Possible values: ALL - All orders | OPEN - Open orders | CLOSED - Executed or cancelled orders | CANCELLED - Cancelled orders | NOT_CANCELLED - All orders except cancelled ones | PARTIALLY - partially closed orders | Default value: ALL</para>
        /// <para>Optional : issuedFrom - Start date (in UNIX Time format in milliseconds)</para>
        /// <para>Optional : issuedTo - End date (in UNIX Time format in milliseconds)</para>
        /// <para>Optional : startRow - The sequence number of the first record Default value: 0</para>
        /// <para>Optional : endRow - The sequence number of the last record Default value: 2147483646</para>
        /// </summary>
        public static List<LiveCoinTradeOrder> getOrdersByCurrencyPairList(LiveCoinClientOrderParameters parameters)
        {
            List<LiveCoinTradeOrder> list = new List<LiveCoinTradeOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "exchange/client_orders&currencyPair=XMR/BTC";
                //requestUrl += "&openClosed=" + LiveCoinOrderOpenClosedType.CLOSED;
                //string parameterString = getParameterString(parameters);
                //LogManager.AddLogMessage(Name, "getOrdersByCurrencyPairList", parameterString);
                //string response = getApiPrivateRequest(requestUrl, "");
                string response = getApiPrivateRequest(requestUrl, "");
                LogManager.AddLogMessage(Name, "getOrdersByCurrencyPairList", response);
                //JArray jsonVal = JArray.Parse(response) as JArray;
                //LiveCoinTradeOrder[] array = jsonVal.ToObject<LiveCoinTradeOrder[]>();
                //list = array.ToList();


            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrdersByCurrencyPairList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>/payment/balance
        /// <para>Returns available balance for selected currency</para>
        /// <para>Required : currency (BTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<LiveCoinBalance> getPaymentBalanceList()
        {
            List<LiveCoinBalance> list = new List<LiveCoinBalance>();
            try
            {
                string requestUrl = Api_privateUrl + "payment/balances";
                string parameters = "";

                string response = getApiPrivateRequest(requestUrl, parameters);
                LogManager.AddLogMessage(Name, "getPaymentBalanceList", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                LiveCoinBalance[] array = jsonVal.ToObject<LiveCoinBalance[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getPaymentBalanceList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/exchange/trades
        /// <para>To retrieve information on your latest transactions. The result may be determined by the parameters below.</para>
        /// <para>Required : none</para>
        /// <para>Optional : currencyPair - (SYM/MKT)</para>
        /// <para>Optional : orderDesc - Sorting order. If true (DEFAULT) then new orders will be first, otherwise old orders will be be first.</para>
        /// <para>Optional : limit - Number of items per page</para>
        /// <para>Optional : offset - Page offset (position of first order in the page)</para>
        /// </summary>
        public static List<LiveCoinTradeOrder> getTradesList(string symbol = "", string market = "")
        {
            List<LiveCoinTradeOrder> list = new List<LiveCoinTradeOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "exchange/trades";

                if (symbol.Length > 0 && market.Length > 0)
                {
                    requestUrl += "&currencyPair=" + symbol.ToUpper() + "/" + market.ToUpper();
                }

                string parameters = "";
                string response = getApiPrivateRequest(requestUrl, parameters);
                //LogManager.AddLogMessage(Name, "getTradesList", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                LiveCoinTradeOrder[] array = jsonVal.ToObject<LiveCoinTradeOrder[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTradesList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion
        #endregion Api_Private

        #region ExchangeManager
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();
            List<LiveCoinTicker> tickerList = getTickerList();
            foreach (LiveCoinTicker ticker in tickerList)
            {
                list.Add(ticker.GetExchangeTicker());
            }
            return list;
        }
        // UPDATERS
        public static void updateExchangeBalanceList()
        {
            List<LiveCoinBalanceTotals> list = getBalances();
            foreach (LiveCoinBalanceTotals balance in list)
            {
                ExchangeManager.processBalance(balance.GetExchangeBalance());
            }        
        }
        public static void updateExchangeTickerList()
        {
            List<LiveCoinTicker> list = getTickerList();

            foreach (LiveCoinTicker ticker in list)
            {
                ExchangeManager.processTicker(ticker.GetExchangeTicker());
            }
        }
        #endregion ExchangeManager

        #region DataModels
        #region DATAMODELS_Enumerables
        public enum LiveCoinOrderOpenClosedType
        {
            ALL,
            OPEN,
            CLOSED,
            CANCELLED,
            NOT_CANCELLED,
            PARTIALLY
        }
        public enum LiveCoinTradeType
        {
            BOTH,
            BUY,
            SELL
        }
        #endregion
        #region DATAMODELS_Parameters
        public class LiveCoinParameterData
        {
            public string category { get; set; }
            public string defaultValue { get; set; }
        }
        public class LiveCoinClientOrderParameters
        {
            /// <summary>Symbol identifier of the currency pair. If not specified, all pairs will be included.
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|")]
            public string symbol { get; set; } = String.Empty;

            /// <summary>Market identifier of the currency pair. If not specified, all pairs will be included.
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|")]
            public string market { get; set; } = String.Empty;

            /// <summary>Order Type. Possible values: ALL - All orders , OPEN - Open orders , CLOSED - Executed or cancelled orders , CANCELLED - Cancelled orders , NOT_CANCELLED - All orders except cancelled ones , PARTIALLY - partially closed orders , Default value: ALL
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|ALL")]
            public LiveCoinOrderOpenClosedType openClosed { get; set; } = LiveCoinOrderOpenClosedType.ALL;

            /// <summary>Start date. (in UNIX Time format in milliseconds)
            /// <para>REQUIRED</para>
            /// </summary>
            [Category("optional|0")]
            public long issuedFrom { get; set; } = 0;

            /// <summary>Start date. (in UNIX Time format in milliseconds)
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|0")]
            public long issuedTo { get; set; } = 0;

            /// <summary>The sequence number of the first record. Default value: 0
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|0")]
            public int startRow { get; set; } = 0;

            /// <summary>The sequence number of the last record. Default value: 2147483646
            /// <para>OPTIONAL</para>
            /// </summary>
            [Category("optional|2147483646")]
            public int endRow { get; set; } = 2147483646;
        }
        #endregion
        #region DATAMODELS_Public
        public class LiveCoinCoinInfo
        {
            public string name { get; set; }
            public string symbol { get; set; }
            public string walletStatus { get; set; }
            public object withdrawFee { get; set; }
            public object difficulty { get; set; }
            public int minDepositAmount { get; set; }
            public double minWithdrawAmount { get; set; }
            public double minOrderAmount { get; set; }
        }
        public class LiveCoinCoinInfoMessage
        {
            public bool success { get; set; }
            public string minimalOrderBTC { get; set; }
            public List<LiveCoinCoinInfo> info { get; set; }
        }
        public class LiveCoinMaxMinData
        {
            public string symbol { get; set; }
            public string maxBid { get; set; }
            public string minAsk { get; set; }
        }
        public class LiveCoinOrderBookResult
        {
            public long timestamp { get; set; }
            public List<List<string>> asks { get; set; }
            public List<List<string>> bids { get; set; }
            // ADDON
            public string symbol { get; set; }
            public string market { get; set; }
        }
        public class LiveCoinRestriction
        {
            public string currencyPair { get; set; }
            public double minLimitQuantity { get; set; }
            public int priceScale { get; set; }
        }
        public class LiveCoinRestrictionMessage
        {
            public bool success { get; set; }
            public double minBtcVolume { get; set; }
            public List<LiveCoinRestriction> restrictions { get; set; }
        }
        public class LiveCoinTicker
        {
            public string cur { get; set; }
            public string symbol { get; set; }
            public decimal last { get; set; }
            public decimal high { get; set; }
            public decimal low { get; set; }
            public decimal volume { get; set; }
            public decimal vwap { get; set; }
            public decimal max_bid { get; set; }
            public decimal min_ask { get; set; }
            public decimal best_bid { get; set; }
            public decimal best_ask { get; set; }
            public ExchangeTicker GetExchangeTicker()
            {
                ExchangeTicker eTicker = new ExchangeTicker();
                eTicker.exchange = Name;
                string[] pairs = symbol.Split('/');
                eTicker.market = pairs[1];
                eTicker.symbol = pairs[0];

                eTicker.last = last;
                eTicker.ask = best_ask;
                eTicker.bid = best_bid;
                //eTicker.change = (ticker.Last - ticker.PrevDay) / ticker.PrevDay;
                eTicker.volume = volume;
                eTicker.high = high;
                eTicker.low = low;
                return eTicker;
            }
        }
        public class LiveCoinPublicTrade
        {
            public int time { get; set; }
            public int id { get; set; }
            public double price { get; set; }
            public double quantity { get; set; }
            public string type { get; set; }
        }
        #endregion
        #region DATAMODELS_Private
        public class LiveCoinBalance
        {
            public string type { get; set; }
            public string currency { get; set; }
            public double? value { get; set; }
        }
        public class LiveCoinBalanceTotals
        {
            // TRADING BALANCE
            public string currency { get; set; }
            public Decimal total { get; set; }
            public Decimal available { get; set; }
            public Decimal trade { get; set; }
            public Decimal available_withdrawal { get; set; }
            // ADDON DATA
            public Decimal totalBTC { get; set; }
            public Decimal totalCoins { get; set; }
            public Decimal totalUSD { get; set; }

            // ADDON DATA
            public Decimal TotalInBTC { get; set; } = 0;
            public Decimal TotalInUSD { get; set; } = 0;
            public ExchangeBalance GetExchangeBalance()
            {
                ExchangeBalance eBalance = new ExchangeBalance();
                eBalance.Symbol = currency;
                eBalance.Exchange = Name;
                eBalance.Balance = total;
                eBalance.OnOrders = total - available;
                eBalance.TotalInBTC = TotalInBTC;
                eBalance.TotalInUSD = TotalInUSD;
                return eBalance;
            }
        }
        public class LiveCoinTradeOrder
        {
            public int datetime { get; set; }
            public int id { get; set; }
            public int clientorderid { get; set; }
            public string type { get; set; }
            public string symbol { get; set; }
            public double price { get; set; }
            public double quantity { get; set; }
            public double commission { get; set; }
        }
        #endregion
        #endregion DataModels
    }
}
