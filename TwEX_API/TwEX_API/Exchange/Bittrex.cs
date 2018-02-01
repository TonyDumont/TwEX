using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    public class Bittrex
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "Bittrex";
        public static string Url { get; } = "https://bittrex.com/";
        public static string IconUrl { get; } = "http://tradebittrext.com/wp-content/uploads/2017/10/lessons-in-crypto-arbitrage-nav-coin_1.jpg";
        public static string USDSymbol { get; } = "USDT";
        public static string TradingView { get; } = "Bittrex";
        // API
        public static ExchangeApi Api { get; set; }
        private static RestClient client = new RestClient("https://bittrex.com/api/v1.1");
        // STATUS
        public static int ErrorCount { get; set; } = 0;
        public static DateTime LastUpdate { get; set; } = DateTime.Now;
        public static string LastMessage { get; set; } = String.Empty;
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters
        /// <summary>/public/getcurrencies
        /// <para>Used to get all supported currencies at Bittrex along with other meta data.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BittrexCurrency> getCurrencyList()
        {
            List<BittrexCurrency> list = new List<BittrexCurrency>();
            try
            {
                var request = new RestRequest("/public/getcurrencies", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCurrencyList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BittrexCurrency>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrencyList", "EXCEPTION!!! : " + ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/public/getmarkets
        /// <para>Used to get the open and available trading markets at Bittrex along with other meta data.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BittrexMarket> getMarketList()
        {
            List<BittrexMarket> list = new List<BittrexMarket>();
            try
            {
                var request = new RestRequest("/public/getmarkets", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketsList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BittrexMarket>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketsList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/public/getmarkethistory
        /// <para>Used to retrieve the latest trades that have occured for a specific market.</para>
        /// <para>Required : market	- a string literal for the market (ex: MKT-SYM)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BittrexMarketHistory> getMarketHistoryList(string market, string symbol)
        {
            List<BittrexMarketHistory> list = new List<BittrexMarketHistory>();
            try
            {
                var request = new RestRequest("/public/getmarkethistory?market=" + market + "-" + symbol, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketHistory", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BittrexMarketHistory>>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getMarketHistory", "ERROR LOADING : SUCCESS false on market : " + market + " | " + symbol, LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketHistory", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/public/getmarketsummary
        /// <para>Used to get the last 24 hour summary of all active exchanges</para>
        /// <para>Required : market	- a string literal for the market (ex: MKT-SYM)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BittrexMarketSummary getMarketSummary(string market, string symbol)
        {
            try
            {
                var request = new RestRequest("/public/getmarketsummary?market=" + market + "-" + symbol, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketSummary", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    List<BittrexMarketSummary> list = jsonObject["result"].ToObject<List<BittrexMarketSummary>>();
                    if (list.Count > 0)
                    {
                        return list[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getMarketSummary", "ERROR LOADING : SUCCESS false on market : " + market, LogManager.LogMessageType.DEBUG);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketSummary", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/public/getmarketsummaries
        /// <para>Used to get the last 24 hour summary of all active exchanges</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BittrexMarketSummary> getMarketSummariesList()
        {
            List<BittrexMarketSummary> list = new List<BittrexMarketSummary>();
            string responseString = string.Empty;
            try
            {
                var request = new RestRequest("/public/getmarketsummaries", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketSummaries", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                responseString = response.Content;
                var jsonObject = JObject.Parse(responseString);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BittrexMarketSummary>>();
                    UpdateStatus(true, "Updated Tickers");
                }
                else
                {
                    UpdateStatus(true, jsonObject["message"].ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "returnTicker", ex.Message + " | " + responseString, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, responseString);
            }
            return list;
        }

        /// <summary>/public/getorderbook
        /// <para>Used to get retrieve the orderbook for a given market</para>
        /// <para>Required : market	- a string literal for the market (ex: MKT-SYM)</para>
        /// <para>Required : type - buy, sell or both to identify the type of orderbook to return.</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BittrexOrderBookData> getOrderBookList(string market, string symbol, BittrexOrderBookType type = BittrexOrderBookType.both)
        {
            List<BittrexOrderBookData> list = new List<BittrexOrderBookData>();
            try
            {
                var request = new RestRequest("/public/getorderbook?market=" + market + "-" + symbol + "&type=" + type.ToString(), Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getOrderBookList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    if (type != BittrexOrderBookType.both)
                    {
                        List<BittrexOrderBookData> resultList = jsonObject["result"].ToObject<List<BittrexOrderBookData>>();
                        foreach (BittrexOrderBookData data in resultList)
                        {
                            data.Type = type.ToString();
                            list.Add(data);
                        }
                    }
                    else
                    {
                        List<BittrexOrderBookData> buyList = jsonObject["result"]["buy"].ToObject<List<BittrexOrderBookData>>();
                        List<BittrexOrderBookData> sellList = jsonObject["result"]["sell"].ToObject<List<BittrexOrderBookData>>();

                        foreach (BittrexOrderBookData buy in buyList)
                        {
                            buy.Type = "buy";
                            list.Add(buy);
                        }

                        foreach (BittrexOrderBookData sell in sellList)
                        {
                            sell.Type = "sell";
                            list.Add(sell);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderBookList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/public/getticker
        /// <para>Used to get the current tick values for a market.</para>
        /// <para>Required : market	- a string literal for the market (ex: MKT-SYM)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BittrexTicker getTicker(string market, string symbol)
        {
            try
            {
                var request = new RestRequest("/public/getticker?market=" + market + "-" + symbol, Method.GET);
                var response = client.Execute(request);

                //LogManager.AddLogMessage(Name, "getTicker", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    BittrexTicker ticker = jsonObject["result"].ToObject<BittrexTicker>();
                    return ticker;
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getTicker", "ERROR LOADING : SUCCESS false on market : " + market, LogManager.LogMessageType.DEBUG);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTicker", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // ------------------------
        private static string getHMAC(string secret, string url)
        {
            var hmac = new HMACSHA512(Encoding.ASCII.GetBytes(secret));
            var messagebyte = Encoding.ASCII.GetBytes(url);
            var hashmessage = hmac.ComputeHash(messagebyte);
            var sign = BitConverter.ToString(hashmessage).Replace("-", "");
            return sign;
        }
        // ------------------------
        /// <summary>/account/getbalance
        /// <para>Used to retrieve the balance from your account for a specific currency.</para>
        /// <para>Required : currency - a string literal for the currency (ex: LTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BittrexBalance getBalance(string currency)
        {
            try
            {
                string requestUrl = "https://bittrex.com/api/v1.1/account/getbalance?Api.key=" + Api.key + "&currency=" + currency + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "getBalanceList", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<BittrexBalance>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getBalance", "success false : message=" + jsonObject["message"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalance", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/account/getbalances
        /// <para>Used to retrieve all balances from your account</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BittrexBalance> getBalanceList()
        {
            List<BittrexBalance> list = new List<BittrexBalance>();
            string responseString = string.Empty;
            try
            {
                string requestUrl = "https://bittrex.com/api/v1.1/account/getbalances?apikey=" + Api.key + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                //String result = strRead.ReadToEnd();
                responseString = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "getBalanceList", "result=" + result);
                var jsonObject = JObject.Parse(responseString);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BittrexBalance>>();
                    UpdateStatus(true, "Updated Balances");
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getBalanceList", "success FALSE : " + jsonObject["message"], LogManager.LogMessageType.EXCHANGE);
                    UpdateStatus(true, jsonObject["message"].ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalanceList", "EXCEPTION!!! : " + ex.Message);
                UpdateStatus(false, responseString);
            }
            return list;
        }

        /// <summary>/account/getdepositaddress
        /// <para>Used to retrieve or generate an address for a specific currency. If one does not exist, the call will fail and return ADDRESS_GENERATING until one is available.</para>
        /// <para>Required : currency - a string literal for the currency (ie. BTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BittrexDepositMessage getDepositAddress(string currency)
        {
            try
            {
                string requestUrl = "https://bittrex.com/api/v1.1/account/getdepositaddress?Api.key=" + Api.key + "&currency=" + currency + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "getDepositAddress", result);
                var jsonObject = JObject.Parse(result);
                return jsonObject.ToObject<BittrexDepositMessage>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getDepositAddress", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/account/getdeposithistory
        /// <para>Used to retrieve your deposit history.</para>
        /// <para>Required : none</para>
        /// <para>Optional : currency - a string literal for the currecy (ie. BTC). If omitted, will return for all currencies</para>
        /// </summary>
        public static List<BittrexDeposit> getDepositHistoryList(string currency = "")
        {
            List<BittrexDeposit> list = new List<BittrexDeposit>();
            try
            {
                string requestUrl = String.Empty;

                if (currency.Length > 0)
                {
                    requestUrl = "https://bittrex.com/api/v1.1/account/getdeposithistory?apikey=" + Api.key + "&currency=" + currency + "&nonce=" + ExchangeManager.GetNonce();
                }
                else
                {
                    requestUrl = "https://bittrex.com/api/v1.1/account/getdeposithistory?apikey=" + Api.key + "&nonce=" + ExchangeManager.GetNonce();
                }

                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "getDepositHistoryList", "result=" + result);
                
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BittrexDeposit>>();
                }
                
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getDepositHistoryList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/account/getorder
        /// <para>Used to retrieve a single order by uuid.</para>
        /// <para>Required : uuid - the uuid of the buy or sell order</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BittrexOrder getOrder(string uuid)
        {
            try
            {
                string requestUrl = "https://bittrex.com/api/v1.1/account/getorder?Api.key=" + Api.key + "&uuid=" + uuid + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "getOrder", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<BittrexOrder>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getOrder", "success false : message=" + jsonObject["message"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrder", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/account/getorderhistory
        /// <para>Used to retrieve your order history.</para>
        /// <para>Required : none</para>
        /// <para>Optional : market	- a string literal for the market (ie. MKT-SYM). If ommited, will return for all markets</para>
        /// </summary>
        public static List<BittrexOrderHistoryItem> getOrderHistoryList(string market = "", string symbol = "")
        {
            List<BittrexOrderHistoryItem> list = new List<BittrexOrderHistoryItem>();
            try
            {
                string requestUrl = String.Empty;

                if (market.Length > 0 && symbol.Length > 0)
                {
                    requestUrl = "https://bittrex.com/api/v1.1/account/getorderhistory?apikey=" + Api.key + "&market=" + market + "-" + symbol + "&nonce=" + GetNonce();
                }
                else
                {
                    requestUrl = "https://bittrex.com/api/v1.1/account/getorderhistory?apikey=" + Api.key + "&nonce=" + GetNonce();
                }

                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "returnOrderHistory", result, LogManager.LogMessageType.OTHER);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BittrexOrderHistoryItem>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderHistory", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/market/getopenorders
        /// <para>Get all orders that you currently have opened. A specific market can be requested</para>
        /// <para>Required : none</para>
        /// <para>Optional : market	- a string literal for the market (ie. MKT-SYM).</para>
        /// </summary>
        public static List<BittrexOpenOrder> getOpenOrdersList(string market = "", string symbol = "")
        {
            List<BittrexOpenOrder> list = new List<BittrexOpenOrder>();
            try
            {
                string requestUrl = String.Empty;

                if (market.Length > 0 && symbol.Length > 0)
                {
                    requestUrl = "https://bittrex.com/api/v1.1/market/getopenorders?apikey=" + Api.key + "&market=" + market + "-" + symbol + "&nonce=" + GetNonce();
                }
                else
                {
                    requestUrl = "https://bittrex.com/api/v1.1/market/getopenorders?apikey=" + Api.key + "&nonce=" + GetNonce();
                }
                //LogManager.AddLogMessage(Name, "getOpenOrdersList", "key=" + Api.key + " | " + requestUrl, LogManager.LogMessageType.DEBUG);
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "getOpenOrdersList", "result=" + result, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BittrexOpenOrder>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOpenOrdersList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/account/getwithdrawalhistory
        /// <para>Used to retrieve your withdrawal history.</para>
        /// <para>Required : none</para>
        /// <para>Optional : currency - a string literal for the currecy (ie. BTC). If omitted, will return for all currencies</para>
        /// </summary>
        public static List<BittrexWithdrawal> getWithdrawalHistoryList(string currency = "")
        {
            List<BittrexWithdrawal> list = new List<BittrexWithdrawal>();
            try
            {
                string requestUrl = String.Empty;

                if (currency.Length > 0)
                {
                    requestUrl = "https://bittrex.com/api/v1.1/account/getwithdrawalhistory?apikey=" + Api.key + "&currency=" + currency + "&nonce=" + GetNonce();
                }
                else
                {
                    requestUrl = "https://bittrex.com/api/v1.1/account/getwithdrawalhistory?apikey=" + Api.key + "&nonce=" + GetNonce();
                }

                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "getWithdrawalHistoryList", "result=" + result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BittrexWithdrawal>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getWithdrawalHistoryList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }
        #endregion

        #region API_PRIVATE_Setters
        /// <summary>/market/buylimit
        /// <para>Used to place a buy order in a specific market. Use buylimit to place limit orders.</para>
        /// <para>Required : market	- a string literal for the market (ex: MKT-SYM)</para>
        /// <para>Required : quantity - the amount to purchase</para>
        /// <para>Required : rate - the rate at which to place the order</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BittrexBuySellMessage setBuy(string market, string symbol, Decimal quantity, Decimal rate)
        {
            try
            {
                string requestUrl = "https://bittrex.com/api/v1.1/market/buylimit?Api.key=" + Api.key + "&market=" + market + "-" + symbol + "&quantity=" + quantity + "&rate=" + rate + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "setBuy", result);
                var jsonObject = JObject.Parse(result);
                return jsonObject.ToObject<BittrexBuySellMessage>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setBuy", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/market/cancel
        /// <para>Used to cancel a buy or sell order.</para>
        /// <para>Required : market	- a string literal for the market (ex: MKT-SYM)</para>
        /// <para>Required : quantity - the amount to purchase</para>
        /// <para>Required : rate - the rate at which to place the order</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BittrexBuySellMessage setCancel(string uuid)
        {
            try
            {
                string requestUrl = "https://bittrex.com/api/v1.1/market/cancel?Api.key=" + Api.key + "&uuid=" + uuid + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "setCancel", result);
                var jsonObject = JObject.Parse(result);
                return jsonObject.ToObject<BittrexBuySellMessage>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setCancel", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/market/selllimit
        /// <para>Used to place an sell order in a specific market. Use selllimit to place limit orders.</para>
        /// <para>Required : market	- a string literal for the market (ex: MKT-SYM)</para>
        /// <para>Required : quantity - the amount to purchase</para>
        /// <para>Required : rate - the rate at which to place the order</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BittrexBuySellMessage setSell(string market, string symbol, Decimal quantity, Decimal rate)
        {
            try
            {
                string requestUrl = "https://bittrex.com/api/v1.1/market/selllimit?Api.key=" + Api.key + "&market=" + market + "-" + symbol + "&quantity=" + quantity + "&rate=" + rate + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String result = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "setSell", result);
                var jsonObject = JObject.Parse(result);
                return jsonObject.ToObject<BittrexBuySellMessage>();
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
        // Withdraw
        #endregion
        #endregion API_Private

        #region ExchangeManager
        // INITIALIZE
        public static void InitializeExchange()
        {
            LogManager.AddLogMessage(Name, "InitializeExchange", "Initialized", LogManager.LogMessageType.EXCHANGE);
            //updateExchangeTickerList();
        }
        // GETTERS
        public static List<ExchangeBalance> getExchangeBalanceList()
        {
            List<ExchangeBalance> list = new List<ExchangeBalance>();
            List<BittrexBalance> requestList = getBalanceList();
            
            foreach (BittrexBalance balance in requestList)
            {
                list.Add(balance.GetExchangeBalance());
            }
            return list;
        }
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();
            List<BittrexMarketSummary> tickerList = getMarketSummariesList();

            foreach (BittrexMarketSummary ticker in tickerList)
            {
                list.Add(ticker.GetExchangeTicker());
            }
            return list;
        }
        // UPDATERS
        public static void updateExchangeBalanceList()
        {
            List<BittrexBalance> list = getBalanceList();
            ExchangeTicker btcTicker = ExchangeManager.getExchangeTicker(Name, "BTC", USDSymbol);

            foreach (BittrexBalance balance in list)
            {
                if (balance.Balance > 0)
                {
                    if (balance.Currency != "BTC" && balance.Currency != USDSymbol)
                    {
                        // GET TICKER FOR PAIR IN BTC MARKET
                        ExchangeTicker ticker = ExchangeManager.getExchangeTicker(Name, balance.Currency.ToUpper(), "BTC");

                        if (ticker != null)
                        {
                            Decimal orders = balance.Balance - balance.Available;
                            if (orders > 0)
                            {
                                balance.TotalInBTCOrders = orders * ticker.last;
                            }

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
                            Decimal orders = balance.Balance - balance.Available;
                            if (orders > 0)
                            {
                                balance.TotalInBTCOrders = orders;
                            }

                            balance.TotalInBTC = balance.Balance;
                            balance.TotalInUSD = btcTicker.last * balance.Balance;
                        }
                        else if (balance.Currency == USDSymbol)
                        {
                            Decimal orders = balance.Balance - balance.Available;
                            if (orders > 0)
                            {
                                balance.TotalInBTCOrders = orders / btcTicker.last;
                            }

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
        public static void updateExchangeOrderList()
        {
            List<ExchangeOrder> list = new List<ExchangeOrder>();
            List<BittrexOpenOrder> openorders = getOpenOrdersList();

            foreach (BittrexOpenOrder order in openorders)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeOrderList", order.symbol + " | " + order.market + " | " + order.type, LogManager.LogMessageType.DEBUG);
                string[] orderTypeSplit = order.OrderType.Split('_');
                string[] pairSplit = order.Exchange.Split('-');

                ExchangeOrder eOrder = new ExchangeOrder()
                {
                    exchange = Name,
                    id = order.OrderUuid,
                    type = orderTypeSplit[1].ToLower(),
                    rate = order.Limit,
                    amount = order.Quantity,
                    total = order.Price,
                    market = pairSplit[0],
                    symbol = pairSplit[1],
                    date = order.Opened,
                    open = true
                };
                processOrder(eOrder);
            }
            
            Thread.Sleep(1000);

            List<BittrexOrderHistoryItem> trades = getOrderHistoryList();
            foreach (BittrexOrderHistoryItem trade in trades)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeOrderList", trade.Exchange + " | " + trade. + " | " + trade.type, LogManager.LogMessageType.DEBUG);
                string[] orderTypeSplit = trade.OrderType.Split('_');
                string[] pairSplit = trade.Exchange.Split('-');

                ExchangeOrder eOrder = new ExchangeOrder()
                {
                    exchange = Name,
                    id = trade.OrderUuid,
                    type = orderTypeSplit[1].ToLower(),
                    rate = trade.Limit,
                    amount = trade.Quantity,
                    total = trade.Price,
                    market = pairSplit[0],
                    symbol = pairSplit[1],
                    date = trade.TimeStamp,
                    open = false
                };
                processOrder(eOrder);
            }
            //LogManager.AddLogMessage(Name, "updateExchangeOrderList", "COUNT=" + Orders.Count, LogManager.LogMessageType.DEBUG);
        }
        public static void updateExchangeTransactionList()
        {
            List<BittrexDeposit> depositList = getDepositHistoryList();
            foreach(BittrexDeposit deposit in depositList)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", deposit.Currency + " | " + deposit.Amount, LogManager.LogMessageType.DEBUG);
                processTransaction(deposit.ExchangeTransaction);
            }

            Thread.Sleep(1000);

            List<BittrexWithdrawal> withdrawalList = getWithdrawalHistoryList();
            foreach (BittrexWithdrawal withdraw in withdrawalList)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", withdraw.Currency + " | " + withdraw.Amount, LogManager.LogMessageType.DEBUG);
                processTransaction(withdraw.ExchangeTransaction);
            }           
            //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", "COUNT=" + Transactions.Count, LogManager.LogMessageType.DEBUG);
        }
        public static void updateExchangeTickerList()
        {
            List<BittrexMarketSummary> list = getMarketSummariesList();
            foreach (BittrexMarketSummary ticker in list)
            {
                processTicker(ticker.GetExchangeTicker());
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
        public enum BittrexOrderBookType
        {
            both,
            buy,
            sell
        }
        #endregion
        #region DATAMODELS_Public 
        public class BittrexCurrency
        {
            public string Currency { get; set; }
            public string CurrencyLong { get; set; }
            public int MinConfirmation { get; set; }
            public double TxFee { get; set; }
            public bool IsActive { get; set; }
            public string CoinType { get; set; }
            public string BaseAddress { get; set; }
            public string Notice { get; set; }
        }
        public class BittrexMarket
        {
            public string MarketCurrency { get; set; }
            public string BaseCurrency { get; set; }
            public string MarketCurrencyLong { get; set; }
            public string BaseCurrencyLong { get; set; }
            public double MinTradeSize { get; set; }
            public string MarketName { get; set; }
            public bool IsActive { get; set; }
            public DateTime Created { get; set; }
            public string Notice { get; set; }
            public bool? IsSponsored { get; set; }
            public string LogoUrl { get; set; }
        }
        public class BittrexMarketHistory
        {
            public int Id { get; set; }
            public DateTime TimeStamp { get; set; }
            public double Quantity { get; set; }
            public double Price { get; set; }
            public double Total { get; set; }
            public string FillType { get; set; }
            public string OrderType { get; set; }
        }
        public class BittrexMarketSummary
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

            public ExchangeTicker GetExchangeTicker()
            {
                string[] pairs = MarketName.Split('-');

                ExchangeTicker ticker = new ExchangeTicker()
                {
                    exchange = Name,                  
                    market = pairs[0],
                    symbol = pairs[1],
                    last = Last,
                    ask = Ask,
                    bid = Bid,
                    change = (Last - PrevDay) / PrevDay,
                    volume = BaseVolume,
                    high = High,
                    low = Low,                
                };
                return ticker;
            }
        }
        public class BittrexOrderBookData
        {
            public double Quantity { get; set; }
            public double Rate { get; set; }
            public string Type { get; set; }
        }
        public class BittrexTicker
        {
            public Decimal Bid { get; set; }
            public Decimal Ask { get; set; }
            public Decimal Last { get; set; }
        }
        #endregion
        #region DATAMODELS_Private
        public class BittrexBalance
        {
            public string Currency { get; set; }
            public Decimal Balance { get; set; }
            public Decimal Available { get; set; }
            public Decimal Pending { get; set; }
            public string CryptoAddress { get; set; }
            // ADDON DATA
            public Decimal TotalInBTC { get; set; } = 0;
            public Decimal TotalInBTCOrders { get; set; } = 0;
            public Decimal TotalInUSD { get; set; } = 0;
            public ExchangeBalance GetExchangeBalance()
            {
                return new ExchangeBalance()
                {
                    Exchange = Name,
                    Symbol = Currency,
                    Balance = Balance,
                    OnOrders = Balance - Available,
                    TotalInBTC = TotalInBTC,
                    TotalInBTCOrders = TotalInBTCOrders,
                    TotalInUSD = TotalInUSD
                };
            }
        }
        public class BittrexBuySellResult
        {
            public string uuid { get; set; }
        }
        public class BittrexBuySellMessage
        {
            public bool success { get; set; }
            public string message { get; set; }
            public BittrexBuySellResult result { get; set; }
        }
        public class BittrexDeposit
        {
            public string Id { get; set; }
            public Double Amount { get; set; }
            public string Currency { get; set; }
            public int Confirmations { get; set; }
            public DateTime LastUpdated { get; set; }
            public string TxId { get; set; }
            public string CryptoAddress { get; set; }

            public ExchangeTransaction ExchangeTransaction
            {
                get
                {
                    ExchangeTransaction transaction = new ExchangeTransaction()
                    {
                        id = Id,
                        currency = Currency,
                        address = CryptoAddress,
                        amount = Amount,
                        confirmations = Confirmations.ToString(),
                        datetime = LastUpdated,
                        exchange = Name,
                        type = ExchangeTransactionType.deposit
                    };
                    return transaction;
                }
            }
        }
            /*
            ExchangeTransaction transaction 
                // KEYS
                public string id { get; set; }
                // STANDARD
                public string currency { get; set; }
                public string address { get; set; }
                public Double amount { get; set; }
                public int confirmations { get; set; }
                public long timestamp { get; set; }
                public DateTime datetime
                {
                    get
                    {
                        return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime.ToLocalTime();
                    }

                }
                public string status { get; set; }
                // ADDON
                public string exchange { get; set; }
                public ExchangeTransactionType type { get; set; }
                */
            //}
        //}
        public class BittrexDepositMessage
        {
            public bool success { get; set; }
            public string message { get; set; }
            public BittrexDepositResult result { get; set; }
        }
        public class BittrexDepositResult
        {
            public string Currency { get; set; }
            public string Address { get; set; }
        }
        public class BittrexOpenOrder
        {
            public object Uuid { get; set; }
            public string OrderUuid { get; set; }
            public string Exchange { get; set; }
            public string OrderType { get; set; }
            public double Quantity { get; set; }
            public double QuantityRemaining { get; set; }
            public double Limit { get; set; }
            public double CommissionPaid { get; set; }
            public double Price { get; set; }
            public object PricePerUnit { get; set; }
            public DateTime Opened { get; set; }
            public object Closed { get; set; }
            public bool CancelInitiated { get; set; }
            public bool ImmediateOrCancel { get; set; }
            public bool IsConditional { get; set; }
            public string Condition { get; set; }
            public object ConditionTarget { get; set; }
        }
        public class BittrexOrder
        {
            public object AccountId { get; set; }
            public string OrderUuid { get; set; }
            public string Exchange { get; set; }
            public string Type { get; set; }
            public double Quantity { get; set; }
            public double QuantityRemaining { get; set; }
            public double Limit { get; set; }
            public double Reserved { get; set; }
            public double ReserveRemaining { get; set; }
            public double CommissionReserved { get; set; }
            public double CommissionReserveRemaining { get; set; }
            public double CommissionPaid { get; set; }
            public double Price { get; set; }
            public object PricePerUnit { get; set; }
            public DateTime Opened { get; set; }
            public object Closed { get; set; }
            public bool IsOpen { get; set; }
            public string Sentinel { get; set; }
            public bool CancelInitiated { get; set; }
            public bool ImmediateOrCancel { get; set; }
            public bool IsConditional { get; set; }
            public string Condition { get; set; }
            public object ConditionTarget { get; set; }
        }
        public class BittrexOrderHistoryItem
        {
            public string OrderUuid { get; set; }
            public string Exchange { get; set; }
            public DateTime TimeStamp { get; set; }
            public string OrderType { get; set; }
            public Double Limit { get; set; }
            public Double Quantity { get; set; }
            public Double QuantityRemaining { get; set; }
            public Double Commission { get; set; }
            public Double Price { get; set; }
            public Double PricePerUnit { get; set; }
            public bool IsConditional { get; set; }
            public string Condition { get; set; }
            public object ConditionTarget { get; set; }
            public bool ImmediateOrCancel { get; set; }
            public string Closed { get; set; }
        }
        public class BittrexWithdrawal
        {
            public string PaymentUuid { get; set; }
            public string Currency { get; set; }
            public double Amount { get; set; }
            public string Address { get; set; }
            public DateTime Opened { get; set; }
            public bool Authorized { get; set; }
            public bool PendingPayment { get; set; }
            public double TxCost { get; set; }
            public string TxId { get; set; }
            public bool Canceled { get; set; }
            public bool InvalidAddress { get; set; }
            
            public ExchangeTransaction ExchangeTransaction
            {
                get
                {
                    ExchangeTransaction transaction = new ExchangeTransaction()
                    {
                        id = PaymentUuid,
                        currency = Currency,
                        address = Address,
                        amount = Amount,
                        //confirmations = ,
                        datetime = Opened,
                        exchange = Name,
                        type = ExchangeTransactionType.withdrawal
                    };
                    return transaction;
                }
            }
            
        }

        #endregion
        #endregion DataModels
    }
}

/*
            List<BittrexOpenOrder> openorders = getOpenOrdersList();

            foreach (BittrexOpenOrder order in openorders)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeOrderList", order.symbol + " | " + order.market + " | " + order.type, LogManager.LogMessageType.DEBUG);
                string[] orderTypeSplit = order.OrderType.Split('_');
                string[] pairSplit = order.Exchange.Split('-');

                ExchangeOrder eOrder = new ExchangeOrder()
                {
                    exchange = Name,
                    id = order.OrderUuid,
                    type = orderTypeSplit[1].ToLower(),
                    rate = order.Limit,
                    amount = order.Quantity,
                    total = order.Price,
                    market = pairSplit[0],
                    symbol = pairSplit[1],
                    date = order.Opened,
                    open = true
                };
                processOrder(eOrder);
            }

            Thread.Sleep(1000);

            List<BittrexOrderHistoryItem> trades = getOrderHistoryList();
            foreach (BittrexOrderHistoryItem trade in trades)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeOrderList", trade.Exchange + " | " + trade. + " | " + trade.type, LogManager.LogMessageType.DEBUG);
                string[] orderTypeSplit = trade.OrderType.Split('_');
                string[] pairSplit = trade.Exchange.Split('-');

                ExchangeOrder eOrder = new ExchangeOrder()
                {
                    exchange = Name,
                    id = trade.OrderUuid,
                    type = orderTypeSplit[1].ToLower(),
                    rate = trade.Limit,
                    amount = trade.Quantity,
                    total = trade.Price,
                    market = pairSplit[0],
                    symbol = pairSplit[1],
                    date = trade.TimeStamp,
                    open = false
                };
                processOrder(eOrder);
            }
            */
