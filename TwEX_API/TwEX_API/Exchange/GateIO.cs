using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace TwEX_API.Exchange
{
    class GateIO
    {
        #region Properties
        public static String thisClassName = "GateIO";
        private static string ApiKey = String.Empty;
        private static string ApiSecret = String.Empty;
        private static RestClient client = new RestClient("http://data.gate.io");
        private static HMACSHA512 hashMaker = new HMACSHA512(Encoding.ASCII.GetBytes(ApiSecret));
        private const string SecureUrl = "https://api.gate.io/api2/1/private/";
        #endregion Properties

        #region API_Public  
        #region API_PUBLIC_Getters
        /// <summary>Market Details API - /marketlist
        /// <para>Returns market details including pair, coin name, coin symbol, last price, trading volume, coin supply, coin market cap, price trend, etc.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static Boolean getMarketList()
        {
            try
            {
                var request = new RestRequest("/api2/1/marketlist", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getMarketList", "response.Content=" + response.Content);

                var jsonObject = JObject.Parse(response.Content);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    JArray pairsArray = JArray.Parse(jsonObject["pairs"].ToString());
                    foreach (JObject content in pairsArray.Children<JObject>())
                    {
                        foreach (JProperty item in content.Properties())
                        {
                            //LogManager.AddLogMessage(thisClassName, "getMarketInfo", item.Name + " | " + item.Value);
                        }
                    }
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getMarketList", "ERROR LOADING : RESULT RETURNED FALSE :" + response.Content);
                    //return null;
                }

                //LogManager.AddLogMessage(thisClassName, "getMarketList", "MarketList.Count=" + marketInfoList.Count);
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getMarketList", "EXCEPTION!!! : " + ex.Message);
            }
            return true;
        } // CURRENTLY RETURNING EMPTY DATA ARRAY

        /// <summary>Market Info API - /marketinfo
        /// <para>Returns all markets' fee, minimum order total amount, price decimal places.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<GateIOMarketInfo> getMarketInfoList()
        {
            List<GateIOMarketInfo> list = new List<GateIOMarketInfo>();
            try
            {
                var request = new RestRequest("/api2/1/marketinfo", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getMarketInfoList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {             
                    JArray pairsArray = JArray.Parse(jsonObject["pairs"].ToString());
                    foreach (JObject content in pairsArray.Children<JObject>())
                    {
                        foreach (JProperty item in content.Properties())
                        {
                            //LogManager.AddLogMessage(thisClassName, "getMarketInfo", item.Name + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                            GateIOMarketInfo marketInfo = jsonObject["pairs"][item.Name].ToObject<GateIOMarketInfo>();
                            marketInfo.pair = item.Name.ToUpper();
                            string[] pairSplit = marketInfo.pair.Split('_');
                            marketInfo.symbol = pairSplit[0];
                            marketInfo.market = pairSplit[1];

                            list.Add(marketInfo);
                        }
                    }
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getMarketInfo", "ERROR LOADING : RESULT RETURNED FALSE :" + response.Content, LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getMarketInfo", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>Depth API - /orderBook/[CURR_A]_[CURR_B]
        /// <para>Return the market depth including ask and bid orders.</para>
        /// <para>Required : Replace [CURR_A] and [CURR_B] with [SYM] and [MKT]</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static GateIOOrderBook getOrderBook(string symbol, string market)
        {
            try
            {
                var request = new RestRequest("/api2/1/orderBook/" + symbol + "_" + market, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getOrderBook", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    GateIOOrderBook orderBook = jsonObject.ToObject<GateIOOrderBook>();
                    orderBook.pair = symbol.ToUpper() + "_" + market.ToUpper();
                    orderBook.symbol = symbol.ToUpper();
                    orderBook.market = market.ToUpper();
                    return orderBook;
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getOrderBook", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getOrderBook", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>Ticker API - /ticker/[CURR_A]_[CURR_B]
        /// <para>returns the current ticker for the selected currency, cached in 10 seconds</para>
        /// <para>Required : Replace [CURR_A] and [CURR_B] with [SYM] and [MKT]</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static GateIOTicker getTicker(string symbol, string market)
        {
            try
            {
                // GET TICKERS
                var request = new RestRequest("/api2/1/ticker/" + symbol + "_" + market, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getTickers", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    GateIOTicker ticker = jsonObject.ToObject<GateIOTicker>();
                    ticker.pair = symbol.ToUpper() + "_" + market.ToUpper();
                    ticker.symbol = symbol.ToUpper();
                    ticker.market = market.ToUpper();
                    return ticker;
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getTickers", "result is FALSE : NO DATA", LogManager.LogMessageType.DEBUG);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "returnTicker", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>Tickers API - /tickers
        /// <para>returns the tickers for all the supported trading pairs at once, cached in 10 seconds</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<GateIOTicker> getTickersList()
        {
            List<GateIOTicker> list = new List<GateIOTicker>();
            try
            {
                var request = new RestRequest("/api2/1/tickers", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getTickersList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                
                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(thisClassName, "getTickersList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                    GateIOTicker ticker = jsonObject[item.Key].ToObject<GateIOTicker>();
                    ticker.pair = item.Key.ToUpper();
                    string[] pairSplit = ticker.pair.Split('_');
                    ticker.symbol = pairSplit[0];
                    ticker.market = pairSplit[1];
                    list.Add(ticker);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getTickersList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>Trade History API - /trade/[CURR_A]_[CURR_B]
        /// <para>Return the most recent 80 trade history records</para>
        /// <para>Required : Replace [CURR_A] and [CURR_B] with [SYM] and [MKT]</para>
        /// <para>Optional : Return at most 1,000 trade history records after [count]</para>
        /// </summary>
        public static List<GateIOTradeHistory> getTradeHistory(string symbol, string market, int count = 80)
        {
            List<GateIOTradeHistory> list = new List<GateIOTradeHistory>();
            try
            {
                string requestString = "/api2/1/tradeHistory/" + symbol + "_" + market;

                if (count > 80)
                {
                    requestString = "/api2/1/tradeHistory/" + symbol + "_" + market + "/" + count;
                }

                var request = new RestRequest(requestString, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getTradeHistory", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    list = jsonObject["data"].ToObject<List<GateIOTradeHistory>>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getTradeHistory", "result is FALSE : NO DATA", LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getTradeHistory", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>Trading Pairs API - /pairs
        /// <para>Return all the trading pairs supported by gate.io</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<GateIOTradingPair> getTradingPairsList()
        {
            List<GateIOTradingPair> list = new List<GateIOTradingPair>();
            try
            {
                var request = new RestRequest("/api2/1/pairs", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getTradingPairsList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                string result = response.Content.Substring(1, response.Content.Length - 1);
                string[] pairs = result.Split(',');

                foreach (string pair in pairs)
                {
                    //LogManager.AddLogMessage(thisClassName, "getTradingPairsList", pair, LogManager.LogMessageType.DEBUG);
                    GateIOTradingPair tradingPair = new GateIOTradingPair();
                    tradingPair.pair = pair;
                    string[] pairSplit = pair.Split('_');
                    tradingPair.symbol = pairSplit[0];
                    tradingPair.market = pairSplit[1];
                    list.Add(tradingPair);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getTradingPairsList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        /// <summary>/balances
        /// <para>Get account fund balances API</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<GateIOBalance> getBalances()
        {
            List<GateIOBalance> list = new List<GateIOBalance>();
            try
            {
                string url = "https://api.gate.io/api2/1/private/balances";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                //var reqStream = getPrivateRequest("balances").GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                //LogManager.AddLogMessage(thisClassName, "getBalances", "response.Content=" + response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();
                
                if (result == "true")
                {
                    foreach (var item in jsonObject)
                    {
                        //LogManager.AddLogMessage(thisClassName, "updateBalances", item.Key + " | " + item.Value);
                        if (item.Key == "available")
                        {
                            //LogManager.AddLogMessage(thisClassName, "updateBalances", "AVAILABALE | " + item.Value);
                            var availableObjects = JObject.Parse(item.Value.ToString());

                            foreach (var aItem in availableObjects)
                            {
                                //LogManager.AddLogMessage(thisClassName, "updateBalances", aItem.Key + " | " + aItem.Value);
                                GateIOBalance listItem = list.FirstOrDefault(i => i.symbol == aItem.Key);

                                if (listItem != null)
                                {
                                    // update
                                    listItem.available = Convert.ToDecimal(aItem.Value);
                                }
                                else
                                {
                                    // add
                                    GateIOBalance balance = new GateIOBalance();
                                    balance.symbol = aItem.Key;
                                    balance.available = Convert.ToDecimal(aItem.Value);
                                    list.Add(balance);
                                }
                            }
                        }
                        else if (item.Key == "locked")
                        {
                            //LogManager.AddLogMessage(thisClassName, "updateBalances", "LOCKED | " + item.Value);
                            var lockedObjects = JObject.Parse(item.Value.ToString());

                            foreach (var lItem in lockedObjects)
                            {
                                //LogManager.AddLogMessage(thisClassName, "updateBalances", lItem.Key + " | " + lItem.Value);
                                GateIOBalance listItem = list.FirstOrDefault(i => i.symbol == lItem.Key);

                                if (listItem != null)
                                {
                                    // update
                                    listItem.locked = Convert.ToDecimal(lItem.Value);
                                }
                                else
                                {
                                    // add
                                    GateIOBalance balance = new GateIOBalance();
                                    balance.symbol = lItem.Key;
                                    balance.locked = Convert.ToDecimal(lItem.Value);
                                    list.Add(balance);
                                }
                            }
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

        /// <summary>/depositAddress
        /// <para>get deposit address API</para>
        /// <para>Required : currency (BTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static GateIODepositAddress getDepositAddress(string currency)
        {
            try
            {
                string url = "https://api.gate.io/api2/1/private/depositAddress";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "currency=" + currency + "&nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                //var reqStream = getPrivateRequest("balances").GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                LogManager.AddLogMessage(thisClassName, "getDepositAddress", "response.Content=" + response);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    GateIODepositAddress address = jsonObject.ToObject<GateIODepositAddress>();
                    return address;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getDepositAddress", "EXCEPTION !!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/depositsWithdrawals
        /// <para>get deposit withdrawal history API</para>
        /// <para>Required : start (unix)</para>
        /// <para>Required : end (unix)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<GateIOTransaction> getDepositsWithdrawals(long unixStart, long unixEnd)
        {
            try
            {
                string url = SecureUrl + "depositsWithdrawals";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "start=" + unixStart + "&end=" + unixEnd + "&nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                LogManager.AddLogMessage(thisClassName, "getNewAddress", "response.Content=" + response);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    List<GateIOTransaction> list = new List<GateIOTransaction>();
                    List<GateIOTransaction> deposits = jsonObject["deposits"].ToObject<List<GateIOTransaction>>();
                    List<GateIOTransaction> withdraws = jsonObject["withdraws"].ToObject<List<GateIOTransaction>>();

                    foreach (GateIOTransaction deposit in deposits)
                    {
                        deposit.type = "deposit";
                        list.Add(deposit);
                    }

                    foreach (GateIOTransaction withdraw in withdraws)
                    {
                        withdraw.type = "withdraw";
                        list.Add(withdraw);
                    }
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getDepositsWithdrawals", "EXCEPTION !!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/newAddress
        /// <para>get new address API</para>
        /// <para>Required : currency (BTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static string getNewAddress(string currency)
        {
            try
            {
                string url = "https://api.gate.io/api2/1/private/newAddress";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "currency=" + currency + "&nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                //LogManager.AddLogMessage(thisClassName, "getNewAddress", "response.Content=" + response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    return jsonObject["addr"].ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getNewAddress", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return String.Empty;
            }
        }

        /// <summary>/openOrders
        /// <para>Get my open order list API</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<GateIOOrder> getOpenOrders()
        {
            List<GateIOOrder> list = new List<GateIOOrder>();
            try
            {
                string url = SecureUrl + "openOrders";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                //LogManager.AddLogMessage(thisClassName, "getOpenOrders", "response.Content=" + response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    list = jsonObject["orders"].ToObject<List<GateIOOrder>>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getOpenOrders", "result IS FALSE : NO DATA", LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getOpenOrders", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/getOrder
        /// <para>Get order status API</para>
        /// <para>Required : orderNumber</para>
        /// <para>Required : currencyPair (SYM_MKT)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static GateIOOrder getOrder(string orderNumber, string symbol, string market)
        {
            try
            {
                string url = SecureUrl + "getOrder";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "orderNumber=" + orderNumber + "&currencyPair=" + symbol + "_" + market + "&nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                //LogManager.AddLogMessage(thisClassName, "getOrder", "response.Content=" + response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    return jsonObject.ToObject<GateIOOrder>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getNewAddress", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/tradeHistory
        /// <para>Get my last 24h trades API</para>
        /// <para>Required : currencyPair (SYM_MKT)</para>
        /// <para>Required : orderNumber</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<GateIOTrade> getTradeHistory(string symbol, string market, string orderNumber = "")
        {
            List<GateIOTrade> list = new List<GateIOTrade>();
            try
            {
                string url = SecureUrl + "tradeHistory";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                string parameters = String.Empty;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                if (orderNumber.Length > 0)
                {
                    parameters = "currencyPair=" + symbol + "_" + market + "&orderNumber=" + orderNumber + "&nonce=" + ExchangeManager.GetNonce();
                }
                else
                {
                    parameters = "currencyPair=" + symbol + "_" + market + "&nonce=" + ExchangeManager.GetNonce();
                }

                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                //LogManager.AddLogMessage(thisClassName, "getTradeHistory", "response.Content=" + response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    list = jsonObject["trades"].ToObject<List<GateIOTrade>>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getTradeHistory", "result IS FALSE : NO DATA", LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getTradeHistory", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion
        #region API_PRIVATE_Setters
        /// <summary>/buy or /sell
        /// <para>Place order buy/sell API</para>
        /// <para>Required : currencyPair (SYM_MKT)</para>
        /// <para>Required : rate</para>
        /// <para>Required : amount</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static string setBuySell(string symbol, string market, Decimal rate, Decimal amount, string type)
        {
            try
            {
                string url = SecureUrl + type;
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "currencyPair=" + symbol + "_" + market + "&rate=" + rate + "&amount=" + amount + "&nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                //LogManager.AddLogMessage(thisClassName, "setBuySell", "response.Content=" + response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    return jsonObject["orderNumber"].ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "setBuySell", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return String.Empty;
            }
        }

        /// <summary>/cancelOrder
        /// <para>Cancel order API</para>
        /// <para>Required : orderNumber</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static Boolean setCancelOrder(string orderNumber)
        {
            try
            {
                string url = SecureUrl + "cancelOrder";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "orderNumber=" + orderNumber + "&nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                LogManager.AddLogMessage(thisClassName, "setCancelOrder", "response.Content=" + response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "setCancelOrder", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return false;
            }
        }

        /// <summary>/cancelAllOrders
        /// <para>Cancel all orders API</para>
        /// <para>Required : type - order type(0:sell,1:buy,-1:all)</para>
        /// <para>Required : currencyPair - (SYM_MKT)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static Boolean setCancelAllOrders(string symbol, string market, int type = -1)
        {
            try
            {
                string url = SecureUrl + "cancelOrder";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "type=" + type + "&currencyPair=" + symbol + "_" + market + "&nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                //LogManager.AddLogMessage(thisClassName, "setCancelAllOrders", "response.Content=" + response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "setCancelAllOrders", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return false;
            }
        }

        /// <summary>/withdraw
        /// <para>withdrawal API</para>
        /// <para>Required : currency</para>
        /// <para>Required : amount</para>
        /// <para>Required : address</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static Boolean setWithdraw(string currency, Decimal amount, string address)
        {
            try
            {
                string url = SecureUrl + "withdraw";
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;

                if (request == null)
                    throw new Exception("Non HTTP WebRequest");

                string parameters = "currency=" + currency + "&amount=" + amount + "&address=" + address + "&nonce=" + ExchangeManager.GetNonce();
                byte[] data = Encoding.ASCII.GetBytes(parameters);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Key", ApiKey);

                string signature = BitConverter.ToString(hashMaker.ComputeHash(data)).ToLower().Replace("-", "");
                request.Headers.Add("Sign", signature);

                var reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                //LogManager.AddLogMessage(thisClassName, "setWithdraw", "response.Content=" + response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string result = jsonObject["result"].ToString().ToLower();

                if (result == "true")
                {
                    if (jsonObject["message"].ToString().ToLower() == "success")
                    {
                        return true;
                    }
                    else
                    {
                        LogManager.AddLogMessage(thisClassName, "setWithdraw", "message NOT SUCCESS !!! : " + jsonObject["message"].ToString());
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "setWithdraw", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return false;
            }
        }
        #endregion
        #endregion API_Private
        
        #region DataModels
        #region DATAMODELS_Public
        public class GateIOMarketInfo
        {
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }

            public int decimal_places { get; set; }
            public double min_amount { get; set; }
            public double fee { get; set; }
        }
        public class GateIOTicker
        {
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }

            public Boolean result { get; set; }
            public Decimal last { get; set; }
            public Decimal lowestAsk { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public Decimal high24hr { get; set; }
            public Decimal low24hr { get; set; }
        }
        public class GateIOOrderBook
        {
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }

            public string result { get; set; }
            public List<List<double>> asks { get; set; }
            public List<List<double>> bids { get; set; }
        }
        public class GateIOTradeHistory
        {
            public string tradeID { get; set; }
            public string date { get; set; }
            public string timestamp { get; set; }
            public string type { get; set; }
            public double rate { get; set; }
            public double amount { get; set; }
            public double total { get; set; }
        }
        public class GateIOTradingPair
        {
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
        }
        #endregion
        #region DATAMODELS_Private
        public class GateIOBalance
        {
            public string symbol { get; set; }
            public Decimal available { get; set; } // balance
            public Decimal locked { get; set; } // on orders
            public Decimal TotalBTC { get; set; }
            public Decimal TotalUSD { get; set; }
        }
        public class GateIODepositAddress
        {
            public Boolean result { get; set; }
            public string addr { get; set; }
            public string message { get; set; }
            public int code { get; set; }
        }
        public class GateIOOrder
        {
            // ALL ORDERS
            public string id { get; set; }
            public string status { get; set; }
            public string pair { get; set; }
            public string type { get; set; }
            public double rate { get; set; }
            public string amount { get; set; }
            public double initial_rate { get; set; }
            public string initial_amount { get; set; }
            // OPEN ORDERS
            public string orderNumber { get; set; }
            public string total { get; set; }
            public string currencyPair { get; set; }
            public string timestamp { get; set; }
        }
        public class GateIOTrade
        {
            public string id { get; set; }
            public string orderid { get; set; }
            public string pair { get; set; }
            public string type { get; set; }
            public Decimal rate { get; set; }
            public Decimal amount { get; set; }
            public DateTime time { get; set; }
            public long time_unix { get; set; }
        }
        public class GateIOTransaction
        {
            public string id { get; set; }
            public string currency { get; set; }
            public string address { get; set; }
            public string amount { get; set; }
            public string txid { get; set; }
            public string timestamp { get; set; }
            public string status { get; set; }
            // ADDED
            public string type { get; set; }
        }
        #endregion
        #endregion DataModels
    }
}
