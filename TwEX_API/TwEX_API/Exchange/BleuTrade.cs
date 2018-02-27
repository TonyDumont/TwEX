﻿using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    public class BleuTrade
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "BleuTrade";
        public static string Url { get; } = "https://bleutrade.com";
        public static string IconUrl { get; } = "https://bleutrade.com/imgs/favicon.ico";
        public static string USDSymbol { get; } = string.Empty;
        public static string TradingView { get; } = String.Empty;
        // API
        public static ExchangeApi Api { get; set; }
        private static RestClient client = new RestClient("https://bleutrade.com/api/v2");
        // STATUS
        public static int ErrorCount { get; set; } = 0;
        public static DateTime LastUpdate { get; set; } = DateTime.Now;
        public static string LastMessage { get; set; } = String.Empty;
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters  
        /// <summary>/public/getcandles
        /// <para>Obtains candles format historical trades of a specific market.</para>
        /// <para>Required : market (SYM_MKT)</para>
        /// <para>Required : period (1m, 2m, 3m, 4m, 5m, 6m, 10m, 12m, 15m, 20m, 30m, 1h, 2h, 3h, 4h, 6h, 8h, 12h, 1d)</para>
        /// <para>Required : count (default: 1000, max: 999999)</para>
        /// <para>Required : lasthours (default: 24, max: 720)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BleuTradeCandleData> getCandleList(string symbol, string market, BleuTradeCandlePeriod period, int count = 1000, int lasthours = 24)
        {
            List<BleuTradeCandleData> list = new List<BleuTradeCandleData>();
            try
            {
                string periodString = EnumUtils.GetDescription(period);
                var request = new RestRequest("/public/getcandles?market=" + symbol + "_" + market + "&period=" + periodString + "&count=" + count + "&lasthours=" + lasthours, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCandleList", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeCandleData>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCandleList", "EXCEPTION!!! : " + ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/public/getcurrencies
        /// <para>Get a list of all coins traded.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BleuTradeCurrency> getCurrencyList()
        {
            List<BleuTradeCurrency> list = new List<BleuTradeCurrency>();
            try
            {
                var request = new RestRequest("/public/getcurrencies", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCurrencyList", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeCurrency>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrencyList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>/public/getmarkets
        /// <para>Get the list of all pairs traded.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BleuTradeMarket> getMarketList()
        {
            List<BleuTradeMarket> list = new List<BleuTradeMarket>();
            try
            {
                var request = new RestRequest("/public/getmarkets", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketList", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeMarket>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>/public/getmarkethistory
        /// <para>Obtains historical trades of a specific market.</para>
        /// <para>Required : market (SYM_MKT)</para>
        /// <para>Optional : count(default: 20, max: 200)</para>
        /// </summary>
        public static List<BleuTradeMarketHistory> getMarketHistoryList(string symbol, string market, int count = 20)
        {
            List<BleuTradeMarketHistory> list = new List<BleuTradeMarketHistory>();
            try
            {
                var request = new RestRequest("/public/getmarkethistory?market=" + symbol + "_" + market + "&count=" + count, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketHistoryList", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeMarketHistory>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketHistoryList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>/public/getmarketsummaries
        /// <para>Used to get the last 24 hour summary of all active markets.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BleuTradeMarketSummary> getMarketSummariesList()
        {
            List<BleuTradeMarketSummary> list = new List<BleuTradeMarketSummary>();
            string responseString = String.Empty;
            try
            {
                var request = new RestRequest("/public/getmarketsummaries", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketSummaries", "response.Content=" + response.Content);
                responseString = response.Content;
                var jsonObject = JObject.Parse(responseString);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    //LogManager.AddLogMessage(Name, "getMarketSummaries", "success=true");
                    list = jsonObject["result"].ToObject<List<BleuTradeMarketSummary>>();
                    UpdateStatus(true, "Updated Tickers");
                }
                else
                {
                    UpdateStatus(true, jsonObject["message"].ToString());
                }
            }
            catch (Exception ex)
            {              
                UpdateStatus(false, "TIMEOUT");
                LogManager.AddLogMessage(Name, "getMarketSummaries", LogManager.StripHTML(responseString) + " | " + ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/public/getmarketsummary
        /// <para>Used to get the last 24 hour summary of specific market.</para>
        /// <para>Required : market (ex.: /public/getmarketsummary?market=ETH_BTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BleuTradeMarketSummary getMarketSummary(string symbol, string market)
        {
            try
            {
                var request = new RestRequest("/public/getmarketsummary?market=" + symbol + "_" + market, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketSummaries", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    List<BleuTradeMarketSummary> list = jsonObject["result"].ToObject<List<BleuTradeMarketSummary>>();
                    if (list.Count > 0)
                    {
                        return list[0];
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "getMarketSummary", "success is TRUE but no items in list : json=" + response.Content);
                        return null;
                    }
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getMarketSummary", "success is FALSE : message=" + jsonObject["message"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketSummary", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/public/getorderbook
        /// <para>Loads the book offers specific market.</para>
        /// <para>Required : market (SYM_MKT)</para>
        /// <para>Required : type (BUY, SELL, ALL)</para>
        /// <para>Optional : depth (default is 20)</para>
        /// </summary>
        public static List<BleuTradeOrderBookData> getOrderBookList(string symbol, string market, BleuTradeOrderBookType type = BleuTradeOrderBookType.ALL, int depth = 20)
        {
            List<BleuTradeOrderBookData> list = new List<BleuTradeOrderBookData>();
            try
            {
                var request = new RestRequest("/public/getorderbook?market=" + symbol + "_" + market + "&type=" + type + "&depth=" + depth, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getOrderBookList", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    List<BleuTradeOrderBookData> buys = new List<BleuTradeOrderBookData>();
                    List<BleuTradeOrderBookData> sells = new List<BleuTradeOrderBookData>();

                    foreach (BleuTradeOrderBookData buy in buys)
                    {
                        buy.type = "buy";
                        list.Add(buy);
                    }

                    foreach (BleuTradeOrderBookData sell in sells)
                    {
                        sell.type = "sell";
                        list.Add(sell);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderBookList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>/public/getticker
        /// <para>Used to get the current tick values for a market.</para>
        /// <para>Required : market (or markets) (ex.: /public/getticker?market=ETH_BTC or /public/getticker?market=ETH_BTC,HTML5_DOGE,DOGE_LTC)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BleuTradeTicker> getTickerList(string markets)
        {
            List<BleuTradeTicker> list = new List<BleuTradeTicker>();
            try
            {
                var request = new RestRequest("/public/getticker?market=" + markets, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getMarketSummaries", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    string[] tickerArray = markets.Split(',');
                    list = jsonObject["result"].ToObject<List<BleuTradeTicker>>();

                    int index = 0;
                    foreach (BleuTradeTicker ticker in list)
                    {
                        ticker.pair = tickerArray[index];
                        string[] pairSplit = ticker.pair.Split('_');
                        ticker.symbol = pairSplit[0];
                        ticker.market = pairSplit[1];
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketSummaries", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // ------------------------
        private static String GetApiSignature(String key, String message)
        {
            using (var hmacsha512 = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(message));
                return string.Concat(hmacsha512.Hash.Select(b => b.ToString("x2")).ToArray());
            }
        }
        // ------------------------
        /// <summary>/account/getbalance
        /// <para>Use to get the balance of a specific currency</para>
        /// <para>Required : currency</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BleuTradeBalance getBalance(string currency)
        {
            try
            {
                Console.WriteLine(Api.exchange + " | " + Api.key + " | " + Api.secret);
                string requestUrl = "https://bleutrade.com/api/v2/account/getbalance?currency=" + currency + "&apikey=" + Api.key + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();

                var jsonObject = JObject.Parse(response);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<BleuTradeBalance>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "GetBalance", "success is false : message=" + jsonObject["message"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "GetBalance", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/account/getbalances
        /// <para>Use to get the balance of all your coins</para>
        /// <para>Required : none</para>
        /// <para>Optional : currencies (optional, default=ALL) eg.: /account/getbalances?currencies=DOGE;BTC</para>
        /// </summary>
        public static List<BleuTradeBalance> getBalanceList()
        {
            List<BleuTradeBalance> list = new List<BleuTradeBalance>();
            string responseString = string.Empty;
            try
            {
                string requestUrl = "https://bleutrade.com/api/v2/account/getbalances?apikey=" + Api.key + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);

                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);

                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                responseString = strRead.ReadToEnd();

                var jsonObject = JObject.Parse(responseString);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeBalance>>();
                    UpdateStatus(true, "Updated Balances");
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getBalanceList", "success FALSE : " + jsonObject["message"]);
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
        /// <para>Use to get the deposit address of specific coin.</para>
        /// <para>Required : currency</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BleuTradeDepositAddressMessage getDepositAddress(string currency)
        {
            try
            {
                string requestUrl = "https://bleutrade.com/api/v2/account/getdepositaddress?currency=" + currency + "&apikey=" + Api.key + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();

                var jsonObject = JObject.Parse(response);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<BleuTradeDepositAddressMessage>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getDepositAddress", "success is false : message=" + jsonObject["message"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getDepositAddress", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/account/getdeposithistory
        /// <para>Use for historical deposits and received direct transfers.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BleuTradeTransactionHistory> getDepositHistoryList()
        {
            List<BleuTradeTransactionHistory> list = new List<BleuTradeTransactionHistory>();
            try
            {
                // BALANCES
                string requestUrl = "https://bleutrade.com/api/v2/account/getdeposithistory?apikey=" + Api.key + "&nonce=" + GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();

                var jsonObject = JObject.Parse(response);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeTransactionHistory>>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getDepositHistoryList", "success IS FALSE : message=" + jsonObject["message"]);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getDepositHistoryList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>/market/getopenorders
        /// <para>Use to list your open orders</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BleuTradeOrder> getOpenOrdersList()
        {
            List<BleuTradeOrder> list = new List<BleuTradeOrder>();
            try
            {
                // BALANCES
                string requestUrl = "https://bleutrade.com/api/v2/market/getopenorders?apikey=" + Api.key + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();
                LogManager.AddLogMessage(Name, "getOpenOrdersList", response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeOrder>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOpenOrdersList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/account/getorders
        /// <para>Use to list your orders</para>
        /// <para>Required : market (DIVIDEND_DIVISOR or ALL)</para>
        /// <para>Required : orderstatus (ALL, OK, OPEN, CANCELED)</para>
        /// <para>Required : ordertype (ALL, BUY, SELL)</para>
        /// <para>Optional : depth (default is 500, max is 20000)</para>
        /// </summary>
        public static BleuTradeOrder getOrder(string orderid)
        {
            try
            {
                string requestUrl = "https://bleutrade.com/api/v2/account/getorder?orderid=" + orderid + "&apikey=" + Api.key + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();

                var jsonObject = JObject.Parse(response);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["result"].ToObject<BleuTradeOrder>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getOrder", "success is false : message=" + jsonObject["message"]);
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
        /// <para>Use for historical trades of a given order.</para>
        /// <para>Required : orderid</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BleuTradeOrderHistory> getOrderHistoryList(string orderid)
        {
            List<BleuTradeOrderHistory> list = new List<BleuTradeOrderHistory>();
            try
            {
                string requestUrl = "https://bleutrade.com/api/v2/account/getorderhistory?apikey=" + Api.key + "&orderid=" + orderid + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();

                var jsonObject = JObject.Parse(response);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeOrderHistory>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage("BittrexControl", "getOrderHistoryList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>/account/getorders
        /// <para>Use to list your orders</para>
        /// <para>Required : market (DIVIDEND_DIVISOR or ALL)</para>
        /// <para>Required : orderstatus (ALL, OK, OPEN, CANCELED)</para>
        /// <para>Required : ordertype (ALL, BUY, SELL)</para>
        /// <para>Optional : depth (optional, default is 500, max is 20000)</para>
        /// </summary>
        public static List<BleuTradeOrder> getOrdersList(string symbol, string market, BleuTradeOrderStatus orderstatus = BleuTradeOrderStatus.ALL, BleuTradeOrderType ordertype = BleuTradeOrderType.ALL, int depth = 500) // depth max = 20,000
        {
            List<BleuTradeOrder> list = new List<BleuTradeOrder>();
            try
            {
                string marketString = symbol + "_" + market;
                if (symbol.ToLower() == "all" || market.ToLower() == "all")
                {
                    marketString = "ALL";
                }
                string requestUrl = "https://bleutrade.com/api/v2/account/getorders?apikey=" + Api.key + "&market=" + marketString + "&orderstatus=" + orderstatus + "&ordertype=" + ordertype + "&depth=" + depth + "&nonce=" + ExchangeManager.GetNonce();

                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();

                var jsonObject = JObject.Parse(response);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeOrder>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrdersList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>/account/getwithdrawhistory
        /// <para>Use for historical withdraw and sent direct transfers.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<BleuTradeTransactionHistory> getWithdrawHistoryList()
        {
            List<BleuTradeTransactionHistory> list = new List<BleuTradeTransactionHistory>();
            try
            {
                // BALANCES
                string requestUrl = "https://bleutrade.com/api/v2/account/getwithdrawhistory?apikey=" + Api.key + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();

                var jsonObject = JObject.Parse(response);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<BleuTradeTransactionHistory>>();
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getWithdrawHistoryList", "success IS FALSE : message=" + jsonObject["message"]);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getWithdrawHistoryList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }
        #endregion
        #region API_PRIVATE_Setters
        /// <summary>/market/buylimit
        /// <para>Use to send BUY orders</para>
        /// <para>Required : market (SYM_MKT)</para>
        /// <para>Required : rate</para>
        /// <para>Required : quantity</para>
        /// <para>Optional : comments (optional, up to 128 characters)</para>
        /// </summary>
        public static BleuTradeOrderMessage setBuy(string symbol, string market, Decimal rate, Decimal quantity, string comments = "")
        {
            try
            {
                string requestUrl = "https://bleutrade.com/api/v2/market/buylimit?apikey=" + Api.key + "&market=" + symbol + "_" + market + "&rate=" + rate + "&quantity=" + quantity + "&comments=" + comments + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "setBuy", "response=" + response);
                var jsonObject = JObject.Parse(response);
                return jsonObject.ToObject<BleuTradeOrderMessage>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setBuy", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/market/cancel
        /// <para>Use to cancel an order</para>
        /// <para>Required : orderid</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static BleuTradeOrderMessage setCancel(string orderid)
        {
            try
            {
                string requestUrl = "https://bleutrade.com/api/v2/market/cancel?apikey=" + Api.key + "&orderid=" + orderid + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "setBuy", "response=" + response);
                var jsonObject = JObject.Parse(response);
                return jsonObject.ToObject<BleuTradeOrderMessage>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setBuy", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/market/selllimit
        /// <para>Use to send SELL orders</para>
        /// <para>Required : market (SYM_MKT)</para>
        /// <para>Required : rate</para>
        /// <para>Required : quantity</para>
        /// <para>Optional : comments (optional, up to 128 characters)</para>
        /// </summary>
        public static BleuTradeOrderMessage setSell(string symbol, string market, Decimal rate, Decimal quantity, string comments = "")
        {
            try
            {
                string requestUrl = "https://bleutrade.com/api/v2/market/selllimit?apikey=" + Api.key + "&market=" + symbol + "_" + market + "&rate=" + rate + "&quantity=" + quantity + "&comments=" + comments + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "setSell", "response=" + response);
                var jsonObject = JObject.Parse(response);
                return jsonObject.ToObject<BleuTradeOrderMessage>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setSell", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/account/withdraw
        /// <para>Use to withdraw their currencies to another wallet.</para>
        /// <para>Required : currency</para>
        /// <para>Required : quantity</para>
        /// <para>Required : address</para>
        /// <para>Optional : comments (optional, up to 128 characters)</para>
        /// </summary>
        public static BleuTradeWithdrawMessage setWithdraw(string currency, Decimal quantity, string address, string comments = "")
        {
            try
            {
                string requestUrl = "https://bleutrade.com/api/v2/account/withdraw?apikey=" + Api.key + "&currency=" + currency + "&quantity=" + quantity + "&address=" + address + "&comments=" + comments + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = GetApiSignature(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                String response = strRead.ReadToEnd();
                //LogManager.AddLogMessage(Name, "setWithdraw", "response=" + response);
                var jsonObject = JObject.Parse(response);
                return jsonObject.ToObject<BleuTradeWithdrawMessage>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setWithdraw", "EXCEPTION!!! : " + ex.Message);
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
            updateExchangeBalanceList(true);
            //updateExchangeTickerList();
        }
        // GETTERS
        public static List<ExchangeBalance> getExchangeBalanceList()
        {
            List<ExchangeBalance> list = new List<ExchangeBalance>();
            List<BleuTradeBalance> requestList = getBalanceList();
            Console.WriteLine("requestList.count=" + requestList.Count);
            foreach (BleuTradeBalance balance in requestList)
            {
                ExchangeBalance eBalance = new ExchangeBalance()
                {
                    Symbol = balance.Currency,
                    Exchange = Name,
                    Balance = balance.Balance,
                    OnOrders = balance.Balance - balance.Available
                };
                eBalance.Symbol = balance.Currency;
                eBalance.Exchange = Name;
                eBalance.Balance = balance.Balance;
                eBalance.OnOrders = balance.Balance - balance.Available;
                list.Add(eBalance);
            }

            return list;
        }
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();

            try
            {
                
                List<BleuTradeMarketSummary> tickerList = getMarketSummariesList();

                foreach (BleuTradeMarketSummary ticker in tickerList)
                {
                    string[] pairs = ticker.MarketName.Split('_');
                    ExchangeTicker eTicker = new ExchangeTicker()
                    {
                        exchange = Name,                      
                        market = pairs[1],
                        symbol = pairs[0],
                        last = ticker.Last,
                        ask = ticker.Ask,
                        bid = ticker.Bid,
                        //eTicker.change = (ticker.Last - ticker.PrevDay) / ticker.PrevDay;
                        volume = ticker.BaseVolume,
                        high = ticker.High,
                        low = ticker.Low
                };
                    
                    list.Add(eTicker);
                }
                
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getExchangeTickerList", "EXCEPTION!!! : " + ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        // UPDATERS
        public static void updateExchangeBalanceList(bool clear = false)
        {
            List<BleuTradeBalance> list = getBalanceList();
            ExchangeTicker btcTicker = getExchangeTicker("CryptoCompare", "BTC", "USD");
            //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "btclast=" + btcTicker.last, LogManager.LogMessageType.DEBUG);
            if (list.Count > 0)
            {
                if (clear)
                {
                    ClearBalances(Name);
                }

                foreach (BleuTradeBalance balance in list)
                {
                    if (balance.Currency != "BTC")
                    {
                        ExchangeTicker ticker = getExchangeTicker(Name, balance.Currency.ToUpper(), "BTC");
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
                    }
                    else
                    {
                        Decimal orders = balance.Balance - balance.Available;
                        if (orders > 0)
                        {
                            balance.TotalInBTCOrders = orders;
                        }

                        balance.TotalInBTC = balance.Balance;
                        balance.TotalInUSD = btcTicker.last * balance.TotalInBTC;
                    }

                    processBalance(balance.GetExchangeBalance());
                }
            }
        }
        public static void updateExchangeOrderList()
        {
            List<ExchangeOrder> list = new List<ExchangeOrder>();
            
            List<BleuTradeOrder> trades = getOrdersList("all", "all");
            foreach (BleuTradeOrder trade in trades)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeOrderList", trade.Exchange + " | " + trade. + " | " + trade.type, LogManager.LogMessageType.DEBUG);
                string[] pairSplit = trade.Exchange.Split('_');
                bool open = false;
                if (trade.Status == "OPEN")
                {
                    open = true;
                }

                ExchangeOrder eOrder = new ExchangeOrder()
                {
                    exchange = Name,
                    id = trade.OrderId,
                    type = trade.Type.ToLower(),
                    rate = trade.Price,
                    amount = trade.Quantity,
                    total = trade.Quantity * trade.Price,
                    market = pairSplit[1],
                    symbol = pairSplit[0],
                    date = trade.Created,
                    open = open
                };
                processOrder(eOrder);
            }
            
            //LogManager.AddLogMessage(Name, "updateExchangeOrderList", "COUNT=" + Orders.Count, LogManager.LogMessageType.DEBUG);
        }
        public static void updateExchangeTickerList()
        {
            List<BleuTradeMarketSummary> list = getMarketSummariesList();
            //LogManager.AddLogMessage(Name, "updateExchangeTickerList", list.Count + " Tickers in LIST", LogManager.LogMessageType.DEBUG);
            foreach (BleuTradeMarketSummary item in list)
            {
                ExchangeManager.processTicker(item.GetExchangeTicker());
            }
        }
        public static void updateExchangeTransactionList()
        {
            List<ExchangeTransaction> list = new List<ExchangeTransaction>();

            List<BleuTradeTransactionHistory> depositList = getDepositHistoryList();
            foreach (BleuTradeTransactionHistory deposit in depositList)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", deposit.Currency + " | " + deposit.Amount, LogManager.LogMessageType.DEBUG);
                deposit.type = ExchangeTransactionType.deposit;
                processTransaction(deposit.ExchangeTransaction);
            }

            Thread.Sleep(1000);
            
            List<BleuTradeTransactionHistory> withdrawalList = getWithdrawHistoryList();
            foreach (BleuTradeTransactionHistory withdraw in withdrawalList)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", withdraw.Currency + " | " + withdraw.Amount, LogManager.LogMessageType.DEBUG);
                withdraw.type = ExchangeTransactionType.withdrawal;
                processTransaction(withdraw.ExchangeTransaction);
            }
            
            //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", "COUNT=" + Orders.Count, LogManager.LogMessageType.DEBUG);
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
        public enum BleuTradeCandlePeriod
        {
            [Description("1m")]
            minute_1,

            [Description("2m")]
            minute_2,

            [Description("3m")]
            minute_3,

            [Description("4m")]
            minute_4,

            [Description("5m")]
            minute_5,

            [Description("6m")]
            minute_6,

            [Description("10m")]
            minute_10,

            [Description("12m")]
            minute_12,

            [Description("15m")]
            minute_15,

            [Description("20m")]
            minute_20,

            [Description("30m")]
            minute_30,

            [Description("1h")]
            hour_1,

            [Description("2h")]
            hour_2,

            [Description("3h")]
            hour_3,

            [Description("4h")]
            hour_4,

            [Description("6h")]
            hour_6,

            [Description("8h")]
            hour_8,

            [Description("12h")]
            hour_12,

            [Description("1d")]
            day_1
        };
        public enum BleuTradeOrderBookType
        {
            ALL,
            BUY,
            SELL
        }
        public enum BleuTradeOrderStatus
        {
            ALL,
            OK,
            OPEN,
            CANCELED
        }
        public enum BleuTradeOrderType
        {
            ALL,
            BUY,
            SELL
        }
        #endregion
        #region DATAMODELS_Public
        public class BleuTradeCandleData
        {
            public string TimeStamp { get; set; }
            public string Open { get; set; }
            public string High { get; set; }
            public string Low { get; set; }
            public string Close { get; set; }
            public string Volume { get; set; }
            public string BaseVolume { get; set; }
        }
        public class BleuTradeCurrency
        {
            public string Currency { get; set; }
            public string CurrencyLong { get; set; }
            public string MinConfirmation { get; set; }
            public string TxFee { get; set; }
            public string CoinType { get; set; }
            public string IsActive { get; set; }
            public string MaintenanceMode { get; set; }
        }
        public class BleuTradeMarket
        {
            public string MarketCurrency { get; set; }
            public string BaseCurrency { get; set; }
            public string MarketCurrencyLong { get; set; }
            public string BaseCurrencyLong { get; set; }
            public string MinTradeSize { get; set; }
            public string MarketName { get; set; }
            public string IsActive { get; set; }
        }
        public class BleuTradeMarketHistory
        {
            public string TimeStamp { get; set; }
            public string Quantity { get; set; }
            public string Price { get; set; }
            public string Total { get; set; }
            public string OrderType { get; set; }
        }
        public class BleuTradeMarketSummary
        {
            public string MarketName { get; set; }
            public Decimal PrevDay { get; set; }
            public Decimal High { get; set; }
            public Decimal Low { get; set; }
            public Decimal Last { get; set; }
            public Decimal Average { get; set; }
            public Decimal Volume { get; set; }
            public Decimal BaseVolume { get; set; }
            public string TimeStamp { get; set; }
            public Decimal Bid { get; set; }
            public Decimal Ask { get; set; }
            public string IsActive { get; set; }

            public ExchangeTicker GetExchangeTicker()
            {
                string[] pairs = MarketName.Split('_');
                ExchangeTicker eTicker = new ExchangeTicker()
                {
                    exchange = Name,
                    market = pairs[1],
                    symbol = pairs[0],
                    last = Last,
                    ask = Ask,
                    bid = Bid,
                    //eTicker.change = (ticker.Last - ticker.PrevDay) / ticker.PrevDay;
                    volume = BaseVolume,
                    high = High,
                    low = Low
                };
                return eTicker;
            }
        }
        public class BleuTradeOrderBookData
        {
            public string Quantity { get; set; }
            public string Rate { get; set; }
            // ADDON
            public string type { get; set; }
        }
        public class BleuTradeTicker
        {
            public string Last { get; set; }
            public string Bid { get; set; }
            public string Ask { get; set; }
            // ADDON
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }


        }
        #endregion
        #region DATAMODELS_Private
        public class BleuTradeBalance
        {
            public string Currency { get; set; }
            public Decimal Balance { get; set; }
            public Decimal Available { get; set; }
            public Decimal Pending { get; set; }
            public string CryptoAddress { get; set; }
            public string IsActive { get; set; }
            public string AllowDeposit { get; set; }
            public string AllowWithdraw { get; set; }
            // ADDON DATA
            public Decimal TotalInBTC { get; set; } = 0;
            public Decimal TotalInBTCOrders { get; set; } = 0;
            public Decimal TotalInUSD { get; set; } = 0;
            public ExchangeBalance GetExchangeBalance()
            {
                return new ExchangeBalance()
                {
                    Symbol = Currency,
                    Exchange = Name,
                    Balance = Balance,
                    OnOrders = Balance - Available,
                    TotalInBTC = TotalInBTC,
                    TotalInBTCOrders = TotalInBTCOrders,
                    TotalInUSD = TotalInUSD
                };
            }
        }
        public class BleuTradeDepositAddressMessage
        {
            public bool success { get; set; }
            public string message { get; set; }
            public BleuTradeDepositAddressResult result { get; set; }
        }
        public class BleuTradeDepositAddressResult
        {
            public string Currency { get; set; }
            public string Address { get; set; }
        }
        public class BleuTradeTransactionHistory
        {
            public string Id { get; set; }
            public DateTime TimeStamp { get; set; }
            public string Coin { get; set; }
            public double Amount { get; set; }
            public string Label { get; set; }
            // WITHDRAWALS
            public string TransactionId { get; set; }
            public ExchangeTransactionType type { get; set; }

            public ExchangeTransaction ExchangeTransaction
            {
                get
                {
                    ExchangeTransaction transaction = new ExchangeTransaction()
                    {
                        id = Id,
                        currency = Coin,
                        address = Label,
                        amount = Amount,
                        //confirmations = Confirmations,
                        datetime = TimeStamp,
                        exchange = Name,
                        type = type
                    };
                    return transaction;
                }
            }
        }
        public class BleuTradeOrder
        {
            public string OrderId { get; set; }
            public string Exchange { get; set; }
            public string Type { get; set; }
            public double Quantity { get; set; }
            public double QuantityRemaining { get; set; }
            public string QuantityBaseTraded { get; set; }
            public double Price { get; set; }
            public string Status { get; set; }
            public DateTime Created { get; set; }
            public string Comments { get; set; }
        }
        public class BleuTradeOrderHistory
        {
            public string TimeStamp { get; set; }
            public string OrderType { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
        }
        public class BleuTradeOrderMessage
        {
            public bool success { get; set; }
            public string message { get; set; }
            public BleuTradeOrderResult result { get; set; }
        }
        public class BleuTradeOrderResult
        {
            public string orderid { get; set; }
        }
        public class BleuTradeWithdrawMessage
        {
            public bool success { get; set; }
            public string message { get; set; }
            public string result { get; set; }
        }
        #endregion     
        #endregion DataModels
    }
}
