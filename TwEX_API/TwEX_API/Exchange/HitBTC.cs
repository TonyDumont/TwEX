﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class HitBTC
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "HitBTC";
        public static string Url { get; } = "https://hitbtc.com/";
        public static string IconUrl { get; } = "https://hitbtc.com/195x195image.png";
        public static string USDSymbol { get; } = "USD";
        public static string TradingView { get; } = "HitBTC";
        // API
        public static ExchangeApi Api { get; set; }
        private static RestClient client = new RestClient("https://api.hitbtc.com");
        private static string Api_publicUrl = "/api/2/public/";
        private static string Api_privateUrl = "https://api.hitbtc.com/api/2/";
        // STATUS
        public static int ErrorCount { get; set; } = 0;
        public static DateTime LastUpdate { get; set; } = DateTime.Now;
        public static string LastMessage { get; set; } = String.Empty;
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters
        /// <summary>/api/2/public/candles/{symbol}
        /// <para>An candles used for OHLC a specific symbol.</para>
        /// <para>Required : limit (Limit of candles, default 100)</para>
        /// <para>Required : period (One of: M1 (one minute), M3, M5, M15, M30, H1, H4, D1, D7, 1M (one month). Default is M30 (30 minutes)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCCandleData> getCandleList(string symbol, string market, int limit = 100, HitBTCCandlePeriod period = HitBTCCandlePeriod.Minute_30)
        {
            List<HitBTCCandleData> list = new List<HitBTCCandleData>();
            try
            {
                string requestUrl = Api_publicUrl + "candles/" + symbol.ToUpper() + market.ToUpper() +
                    "?limit=" + limit +
                    "&period=" + EnumUtils.GetDescription(period);

                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                LogManager.AddLogMessage(Name, "getCandleList", response.Content, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                HitBTCCandleData[] array = jsonVal.ToObject<HitBTCCandleData[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCandleList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/api/2/public/currency/{currency}
        /// <para>Return the actual list of available currencies, tokens, ICO etc.</para>
        /// <para>Required : currency</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static HitBTCCurrency getCurrency(string currency)
        {
            try
            {
                string requestUrl = Api_publicUrl + "currency/" + currency.ToUpper();
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCurrency", response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<HitBTCCurrency>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrency", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/api/2/public/currency
        /// <para>Return the actual list of available currencies, tokens, ICO etc.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCCurrency> getCurrencyList()
        {
            List<HitBTCCurrency> list = new List<HitBTCCurrency>();
            try
            {
                string requestUrl = Api_publicUrl + "currency";
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCurrency", response.Content, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                HitBTCCurrency[] array = jsonVal.ToObject<HitBTCCurrency[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrency", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/api/2/public/symbol/{symbol}
        /// <para>Return the actual list of currency symbols (currency pairs) traded on HitBTC exchange. The first listed currency of a symbol is called the base currency, and the second currency is called the quote currency. The currency pair indicates how much of the quote currency is needed to purchase one unit of the base currency.</para>
        /// <para>Required : symbol (SYMMKT)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static HitBTCCurrencySymbol getCurrencySymbol(string symbol, string market)
        {
            try
            {
                string requestUrl = Api_publicUrl + "symbol/" + symbol.ToUpper() + market.ToUpper();
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCurrencySymbolList", response.Content);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<HitBTCCurrencySymbol>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrencySymbolList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/api/2/public/symbol
        /// <para>Return the actual list of currency symbols (currency pairs) traded on HitBTC exchange. The first listed currency of a symbol is called the base currency, and the second currency is called the quote currency. The currency pair indicates how much of the quote currency is needed to purchase one unit of the base currency.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCCurrencySymbol> getCurrencySymbolList()
        {
            List<HitBTCCurrencySymbol> list = new List<HitBTCCurrencySymbol>();
            try
            {
                string requestUrl = Api_publicUrl + "symbol";
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCurrencySymbolList", response.Content);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                HitBTCCurrencySymbol[] array = jsonVal.ToObject<HitBTCCurrencySymbol[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrencySymbolList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>/api/2/public/orderbook/{symbol}
        /// <para>An order book is an electronic list of buy and sell orders for a specific symbol, organized by price level.</para>
        /// <para>Required : none</para>
        /// <para>Optional : limit (Limit of orderbook levels, default 100. Set 0 to view full orderbook levels)</para>
        /// </summary>
        public static List<HitBTCOrderBookData> getOrderBookList(string symbol, string market)
        {
            List<HitBTCOrderBookData> list = new List<HitBTCOrderBookData>();
            try
            {
                string requestUrl = Api_publicUrl + "orderbook/" + symbol.ToUpper() + market.ToUpper();
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getOrderBookList", response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);

                List<HitBTCOrderBookData> buys = jsonObject["ask"].ToObject<List<HitBTCOrderBookData>>();
                List<HitBTCOrderBookData> sells = jsonObject["bid"].ToObject<List<HitBTCOrderBookData>>();

                foreach (HitBTCOrderBookData buy in buys)
                {
                    buy.type = "buy";
                    list.Add(buy);
                }

                foreach (HitBTCOrderBookData sell in sells)
                {
                    sell.type = "sell";
                    list.Add(sell);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrderBookList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/api/2/public/ticker/{symbol}
        /// <para>Return ticker information</para>
        /// <para>Required : symbol (SYMMKT)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static HitBTCTicker getTicker(string symbol, string market)
        {
            try
            {
                string requestUrl = Api_publicUrl + "ticker/" + symbol.ToUpper() + market.ToUpper();
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<HitBTCTicker>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTicker", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/api/2/public/ticker
        /// <para>Return ticker information</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCTicker> getTickerList()
        {
            List<HitBTCTicker> list = new List<HitBTCTicker>();
            string responseString = string.Empty;
            try
            {
                string requestUrl = Api_publicUrl + "ticker";
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                responseString = response.Content;
                //LogManager.AddLogMessage(Name, "getTickers", "response : " + response.Content, LogManager.LogMessageType.EXCEPTION);
                JArray jsonVal = JArray.Parse(responseString) as JArray;
                HitBTCTicker[] array = jsonVal.ToObject<HitBTCTicker[]>();
                list = array.ToList();
                UpdateStatus(true, "Updated Tickers");
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTickers", "EXCEPTION!!! : " + ex.Message, LogManager.LogMessageType.EXCEPTION);
                //LogManager.AddLogMessage(Name, "getTickers", "EXCEPTION!!! : " + response.Content, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, responseString);
            }

            return list;
        }

        /// <summary>/api/2/public/trades/{symbol}
        /// <para>Get trades</para>
        /// <para>Required : sort (Default DESC)</para>
        /// <para>Required : by (Filtration definition. Accepted values: id, timestamp. Default timestamp)</para>
        /// <para>Required : from (Number or Datetime)</para>
        /// <para>Required : till (Number or Datetime)</para>
        /// <para>Required : limit</para>
        /// <para>Required : offset</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCTrades> getTradesList(string symbol, string market, DateTime from, DateTime till, HitBTCSort sort = HitBTCSort.DESC, HitBTCTradeFilter by = HitBTCTradeFilter.timestamp, int limit = 100)
        {
            List<HitBTCTrades> list = new List<HitBTCTrades>();
            try
            {
                string requestUrl = Api_publicUrl + "trades/" + symbol.ToUpper() + market.ToUpper() +
                    "?sort=" + sort +
                    "&by=" + by +
                    "&limit=" + limit;

                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                HitBTCTrades[] array = jsonVal.ToObject<HitBTCTrades[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTradesList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // ------------------------
        private static string GetApiPrivateRequest(string requestUrl, Object postData = null)
        {
            WebRequest myReq = WebRequest.Create(requestUrl);
            string credentials = Api.key + ":" + Api.secret;
            CredentialCache mycache = new CredentialCache();
            myReq.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
            WebResponse wr = myReq.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }
        public static string GetSignature(string text, string secretKey)
        {
            using (var hmacsha512 = new HMACSHA512(Encoding.UTF8.GetBytes(secretKey)))
            {
                hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(text));
                return string.Concat(hmacsha512.Hash.Select(b => b.ToString("x2")).ToArray()); // minimalistic hex-encoding and lower case
            }
        }
        // ------------------------
        /// <summary>/api/2/account/balance
        /// <para>Get account balances</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCBalance> getAccountBalanceList()
        {
            List<HitBTCBalance> list = new List<HitBTCBalance>();
            string responseString = string.Empty;
            try
            {
                string requestUrl = Api_privateUrl + "account/balance";
                responseString = GetApiPrivateRequest(requestUrl);
                //LogManager.AddLogMessage(Name, "getAccountBalanceList", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(responseString) as JArray;
                HitBTCBalance[] array = jsonVal.ToObject<HitBTCBalance[]>();
                list = array.ToList();
                UpdateStatus(true, "Updated Balances");
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getAccountBalanceList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, responseString);
            }
            return list;
        }

        /// <summary>Helper method to group up balance totals from all accounts</summary>
        public static List<HitBTCBalance> getAllAccountBalances()
        {
            List<HitBTCBalance> list = getAccountBalanceList();
            List<HitBTCBalance> tradingList = getTradingBalanceList();

            foreach (HitBTCBalance balance in tradingList)
            {
                HitBTCBalance listItem = list.FirstOrDefault(item => item.currency == balance.currency);
                if (listItem != null)
                {
                    listItem.available += balance.available;
                }
                else
                {
                    list.Add(balance);
                }
            }

            return list;
        }

        /// <summary>/api/2/account/crypto/address/{currency}
        /// <para>Gets or creates address for a specified currency</para>
        /// <para>Required : symbol (BTC)</para>
        /// <para>Optional : createNew (if true generates new address - false by default)</para>
        /// </summary>
        public static HitBTCDepositAddress getDepositAddress(string symbol, Boolean createNew = false)
        {
            try
            {
                string requestUrl = Api_publicUrl + "account/crypto/address/" + symbol;
                var request = new RestRequest(requestUrl, Method.GET);
                if (createNew)
                {
                    request = new RestRequest(requestUrl, Method.POST);
                }
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getDepositAddress", response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<HitBTCDepositAddress>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getDepositAddress", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/api/2/order/{clientOrderId}
        /// <para>Get Active order by clientOrderId</para>
        /// <para>Required : clientOrderId</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static HitBTCOrder getOrder(string clientOrderId, int wait = 0)
        {
            try
            {
                string requestUrl = Api_privateUrl + "order/" + clientOrderId;
                string response = GetApiPrivateRequest(requestUrl);
                //LogManager.AddLogMessage(Name, "getOrder", response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                return jsonObject.ToObject<HitBTCOrder>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrder", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/api/2/order
        /// <para>Get Active orders</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCOrder> getOrdersList()
        {
            List<HitBTCOrder> list = new List<HitBTCOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "order";
                string response = GetApiPrivateRequest(requestUrl);
                //LogManager.AddLogMessage(Name, "getOrdersList", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                HitBTCOrder[] array = jsonVal.ToObject<HitBTCOrder[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrdersList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/api/2/trading/balance
        /// <para>Get Trading Balances</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCBalance> getTradingBalanceList()
        {
            List<HitBTCBalance> list = new List<HitBTCBalance>();
            string responseString = string.Empty;
            try
            {
                string requestUrl = Api_privateUrl + "trading/balance";
                responseString = GetApiPrivateRequest(requestUrl);
                //LogManager.AddLogMessage(Name, "getTradingBalanceList", response, LogManager.LogMessageType.DEBUG);

                JArray jsonVal = JArray.Parse(responseString) as JArray;
                HitBTCBalance[] array = jsonVal.ToObject<HitBTCBalance[]>();
                list = array.ToList();
                UpdateStatus(true, "Updated Balances");
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalances", ex.Message, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, responseString);
            }
            return list;
        }

        /// <summary>/api/2/trading/fee/{symbol}
        /// <para>Get personal trading commission rate.</para>
        /// <para>Required : symbol (SYMMKT)</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static HitBTCCommission getTradingCommission(string symbol, string market)
        {
            try
            {
                string requestUrl = Api_privateUrl + "trading/fee/" + symbol.ToUpper() + market.ToUpper();
                string response = GetApiPrivateRequest(requestUrl);
                LogManager.AddLogMessage(Name, "getTradingCommission", response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                return jsonObject.ToObject<HitBTCCommission>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTradingCommission", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/api/2/history/order
        /// <para>All orders older then 24 hours without trades are deleted.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCOrder> getOrdersHistoryList(HitBTCOrderHistoryParameters parameters)
        {
            List<HitBTCOrder> list = new List<HitBTCOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "history/order";
                string response = GetApiPrivateRequest(requestUrl);
                //LogManager.AddLogMessage(Name, "getOrdersHistoryList", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                HitBTCOrder[] array = jsonVal.ToObject<HitBTCOrder[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrdersHistoryList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/api/2/history/trades
        /// <para>Get Trades history</para>
        /// <para>Required : none</para>
        /// <para>Optional : symbol	- parameter to filter active orders by symbol</para>
        /// <para>Optional : sort - DESC or ASC. Default value DESC</para>
        /// <para>Optional : by	- timestamp by default, or id</para>
        /// <para>Optional : from - Datetime or Numbe</para>
        /// <para>Optional : till - Datetime or Number</para>
        /// <para>Optional : limit - Default 100</para>
        /// <para>Optional : offset - Number</para>
        /// </summary>
        public static List<HitBTCOrder> getTradeHistoryList(HitBTCTradeHistoryParameters parameters)
        {
            List<HitBTCOrder> list = new List<HitBTCOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "history/trades";
                string response = GetApiPrivateRequest(requestUrl);
                //LogManager.AddLogMessage(Name, "getTradeHistoryList", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                HitBTCOrder[] array = jsonVal.ToObject<HitBTCOrder[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrdersHistoryList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/api/2/history/order/{orderId}/trades
        /// <para>Trades by order</para>
        /// <para>Required : orderId</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<HitBTCOrder> getTradeHistoryListByOrder(string orderId)
        {
            List<HitBTCOrder> list = new List<HitBTCOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "history/order/" + orderId + "/trades";
                string response = GetApiPrivateRequest(requestUrl);
                //LogManager.AddLogMessage(Name, "getTradeHistoryListByOrder", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                HitBTCOrder[] array = jsonVal.ToObject<HitBTCOrder[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTradeHistoryListByOrder", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>/api/2/account/transactions
        /// <para>Get transactions history</para>
        /// <para>Required : none</para>
        /// <para>Optional : currency - (BTC)</para>
        /// <para>Optional : sort - DESC or ASC. Default value DESC</para>
        /// <para>Optional : by - timestamp or index. Default value timestamp</para>
        /// <para>Optional : from - If sort by timestamp then Datetime, otherwise Number of index value</para>
        /// <para>Optional : till - If sort by timestamp then Datetime, otherwise Number of index value</para>
        /// <para>Optional : limit - Default 100</para>
        /// <para>Optional : offset	- Number</para>
        /// </summary>
        public static List<HitBTCTransactionHistory> getTransactionsList(HitBTCTransactionParameters parameters = null)
        {
            List<HitBTCTransactionHistory> list = new List<HitBTCTransactionHistory>();
            try
            {
                string requestUrl = Api_privateUrl + "account/transactions";
                string response = GetApiPrivateRequest(requestUrl);
                //LogManager.AddLogMessage(Name, "getTransactionsList", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                HitBTCTransactionHistory[] array = jsonVal.ToObject<HitBTCTransactionHistory[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTransactionsList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion
        #region API_PRIVATE_Setters
        /// <summary>/api/2/order
        /// <para>Cancel all active orders, or all active orders for specified symbol.</para>
        /// <para>Required : clientOrderId</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static HitBTCNewOrderMessage setCancelOrder(string clientOrderId)
        {
            try
            {
                string requestUrl = Api_privateUrl + "order";
                var postData = new
                {
                    //clientOrderId = clientOrderId
                    clientOrderId
                };
                string response = GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(Name, "getOrder", response);
                var jsonObject = JObject.Parse(response);
                HitBTCNewOrderMessage message = jsonObject.ToObject<HitBTCNewOrderMessage>();
                return message;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrder", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>/api/2/order
        /// <para>Create New Order</para>
        /// <para>Price accuracy and quantity.</para>
        /// <para>Symbol config contain tickSize parameter which means that price should be divide by tickSize without residue. Quantity should be divide by quantityIncrement without residue. By default, if strictValidate not enabled, server round half down price and quantity for tickSize and quantityIncrement.</para>
        /// <para>Example for ETHBTC: tickSize = '0.000001' then price '0.046016' - valid, '0.0460165' - invalid</para>
        /// <para>Fee charged in symbol feeCurrency. Maker-taker fees offer a transaction rebate provideLiquidityRate to those who provide liquidity (the market maker), while charging customers who take that liquidity takeLiquidityRate.</para>
        /// <para>For buy orders you must have enough available balance including fees. Available balance > price * quantity * (1 + takeLiquidityRate)</para>
        /// <para>For orders with timeInForce IOC or FOK REST API returns final order state: filled or expired.</para>
        /// <para>If order can be instantly executed, then REST API return filled or partiallyFilled order's info.</para>
        /// <para>Required : symbol	String	Trading symbol</para>
        /// <para>Required : side	String	sell buy</para>
        /// <para>Required : quantity	Number	Order quantity</para>
        /// <para>Required : price	Number	Order price. Required for limit types.</para>
        /// <para>Required : stopPrice	Number	Required for stop types.</para>
        /// <para>Required : expireTime	Datetime	Required for GTD timeInForce.</para>
        /// <para>Required : stopPrice	Number	Required for stop types.</para>
        /// <para>Optional : clientOrderId - Optional parameter, if skipped - will be generated by server. Uniqueness must be guaranteed within a single trading day, including all active orders.</para>
        /// <para>Optional : type	String	Optional. Default - limit. One of: limit, market, stopLimit, stopMarket</para>
        /// <para>Optional : timeInForce	String	Optional. Default - GDC. One of: GTC, IOC, FOK, Day, GTD</para>
        /// <para>Optional : strictValidate	Boolean	Price and quantity will be checked that they increment within tick size and quantity step. See symbol tickSize and quantityIncrement</para>
        /// </summary>
        public static HitBTCNewOrderMessage setNewOrder(HitBTCNewOrderParameters parameters)
        {
            try
            {
                string requestUrl = Api_privateUrl + "order";
                /*
                var postData = new
                {
                    symbol = parameters.symbol,
                    market = parameters.market,
                    side = parameters.side,
                    type = parameters.type,
                    timeInForce = parameters.timeInForce,
                    quantity = parameters.quantity,
                    price = parameters.price,
                    stopPrice = parameters.stopPrice,
                    expireTime = parameters.expireTime,
                    strictValidate = parameters.strictValidate
                };
                */
                var postData = new
                {
                    parameters.symbol,
                    parameters.market,
                    parameters.side,
                    parameters.type,
                    parameters.timeInForce,
                    parameters.quantity,
                    parameters.price,
                    parameters.stopPrice,
                    parameters.expireTime,
                    parameters.strictValidate
                };
                string response = GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(Name, "getOrder", response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                HitBTCNewOrderMessage message = jsonObject.ToObject<HitBTCNewOrderMessage>();
                return message;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrder", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/api/2/account/transfer
        /// <para>Transfer money between trading and account</para>
        /// <para>Required : currency	String	Currency</para>
        /// <para>Required : amount	Number	The amount that will transfer between balances</para>
        /// <para>Required : type	String	bankToExchange or exchangeToBank</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static HitBTCTransactionMessage setTransfer(HitBTCTransactionParameters parameters)
        {
            try
            {
                string requestUrl = Api_privateUrl + "account/transfer";
                var postData = new
                {

                };
                string response = GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(Name, "setTransfer", response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                HitBTCTransactionMessage message = jsonObject.ToObject<HitBTCTransactionMessage>();
                return message;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setTransfer", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/api/2/account/crypto/withdraw
        /// <para>withdraw</para>
        /// <para>Required : currency	String	Currency</para>
        /// <para>Required : amount	Number	The amount that will be sent to the specified address</para>
        /// <para>Required : address	String</para>
        /// <para>Required : includeFee	Boolean	Default false. If set true then total will be spent the specified amount, fee and networkFee will be deducted from the amount</para>
        /// <para>Required : autoCommit	Boolean	Default true. If set false then you should commit or rollback transaction in an hour. Used in two phase commit schema.</para>
        /// <para>Optional : paymentId	String	Optional parameter</para>
        /// <para>Optional : networkFee	Number or String Too low and too high commission value will be rounded to valid values.</para>
        /// </summary>
        public static HitBTCTransactionMessage setWithdraw(HitBTCWithdrawParameters parameters)
        {
            //PUT / api / 2 / account / crypto / withdraw /{ id} -Commit
            //DELETE / api / 2 / account / crypto / withdraw /{ id} -Rollback
            try
            {
                string requestUrl = Api_privateUrl + "/account/crypto/withdraw";
                var postData = new
                {

                };
                string response = GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(Name, "setWithdraw", response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                HitBTCTransactionMessage message = jsonObject.ToObject<HitBTCTransactionMessage>();
                return message;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setWithdraw", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/api/2/account/crypto/withdraw/{id} - Commit | /api/2/account/crypto/withdraw/{id} - Rollback : TBD
        /// <para>commit or rollback withdrawal where autoCommit was set to false</para>
        /// <para>Required : id</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static HitBTCTransactionMessage setWithdrawCommit(string id, Boolean rollback)
        {
            //PUT / api / 2 / account / crypto / withdraw /{ id} -Commit
            //DELETE / api / 2 / account / crypto / withdraw /{ id} -Rollback
            try
            {
                string requestUrl = Api_privateUrl + "/account/crypto/withdraw/" + id;
                var postData = new
                {

                };
                /*
                string response = GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(Name, "setWithdraw", response, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response);
                HitBTCTransactionMessage message = jsonObject.ToObject<HitBTCTransactionMessage>();
                */
                return null;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "setWithdraw", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
        /*
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();

            try
            {
                List<HitBTCTicker> tickerList = getTickerList();

                foreach (HitBTCTicker ticker in tickerList)
                {
                    
                    list.Add(ticker.GetExchangeTicker());
                }
                
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getExchangeTickerList", "EXCEPTION!!! : " + ex.Message);
            }
            
            return list;
        }
        */
        // UPDATERS
        public static void updateExchangeBalanceList(bool clear = false)
        {
            List<HitBTCBalance> list = getAllAccountBalances();
            ExchangeTicker btcTicker = getExchangeTicker(Name, "BTC", USDSymbol);
            //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "count=" + list.Count + " | " + btcTicker.last);

            if (list.Count > 0)
            {
                if (clear)
                {
                    ClearBalances(Name);
                }

                foreach (HitBTCBalance balance in list)
                {
                    //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "balance : " + balance.currency + " | " + balance.balance);
                    if (balance.total > 0)
                    {
                        if (balance.currency != "BTC" && balance.currency != USDSymbol)
                        {
                            // GET TICKER FOR PAIR IN BTC MARKET
                            ExchangeTicker ticker = getExchangeTicker(Name, balance.currency.ToUpper(), "BTC");

                            if (ticker != null)
                            {
                                // Decimal orders = balance.available - balance.reserved;
                                if (balance.reserved > 0)
                                {
                                    balance.TotalInBTCOrders = balance.reserved * ticker.last;
                                }

                                balance.TotalInBTC = balance.total * ticker.last;
                                balance.TotalInUSD = btcTicker.last * balance.TotalInBTC;
                            }
                            else
                            {
                                LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "EXCHANGE TICKER WAS NULL : " + Name + " | " + balance.currency.ToUpper());
                            }
                        }
                        else
                        {
                            //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "CHECKING CURRENCY :" + balance.Currency, LogManager.LogMessageType.DEBUG);
                            if (balance.currency == "BTC")
                            {
                                //Decimal orders = balance.available - balance.reserved;
                                if (balance.reserved > 0)
                                {
                                    balance.TotalInBTCOrders = balance.reserved;
                                }

                                balance.TotalInBTC = balance.total;
                                balance.TotalInUSD = btcTicker.last * balance.total;
                            }
                            else if (balance.currency == USDSymbol)
                            {
                                if (btcTicker.last > 0)
                                {
                                    //Decimal orders = balance.available - balance.reserved;
                                    if (balance.reserved > 0)
                                    {
                                        balance.TotalInBTCOrders = balance.reserved / btcTicker.last;
                                    }

                                    balance.TotalInBTC = balance.total / btcTicker.last;
                                }
                                balance.TotalInUSD = balance.total;
                            }
                        }
                        //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", balance.Currency + " | " + balance.Balance + " | " + balance.TotalInBTC + " | " + balance.TotalInUSD, LogManager.LogMessageType.DEBUG);
                        processBalance(balance.GetExchangeBalance());
                    }
                }
            }
        }
        public static void updateExchangeOrderList()
        {
            List<ExchangeOrder> list = new List<ExchangeOrder>();
            List<HitBTCOrder> openorders = getOrdersList();

            foreach (HitBTCOrder order in openorders)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeOrderList", order.symbol + " | " + order.market + " | " + order.type, LogManager.LogMessageType.DEBUG);
                ExchangeOrder eOrder = new ExchangeOrder()
                {
                    exchange = Name,
                    id = order.clientOrderId,
                    type = order.side.ToLower(),
                    rate = order.price,
                    amount = order.quantity,
                    total = order.price * order.quantity,
                    market = order.symbol.Substring(3),
                    symbol = order.symbol.Substring(0, 3),
                    date = order.createdAt,
                    open = true
                };
                processOrder(eOrder);
            }
            
            Thread.Sleep(1000);

            List<HitBTCOrder> trades = getTradeHistoryList(new HitBTCTradeHistoryParameters());
            //LogManager.AddLogMessage(Name, "updateExchangeOrderList", "Count=" + trades.Count, LogManager.LogMessageType.DEBUG);
            foreach (HitBTCOrder trade in trades)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeOrderList", trade.symbol + " | " + trade.quantity + " | " + trade.price, LogManager.LogMessageType.DEBUG);
                ExchangeOrder eOrder = new ExchangeOrder()
                {
                    exchange = Name,
                    id = trade.clientOrderId,
                    type = trade.side.ToLower(),
                    rate = trade.price,
                    amount = trade.quantity,
                    total = trade.price * trade.quantity,
                    market = trade.symbol.Substring(3),
                    symbol = trade.symbol.Substring(0, 3),
                    date = trade.timestamp,
                    open = false
                };
                processOrder(eOrder);
            }         
            //LogManager.AddLogMessage(Name, "updateExchangeOrderList", "COUNT=" + Orders.Count, LogManager.LogMessageType.DEBUG);
        }
        public static void updateExchangeTickerList()
        {
            List<HitBTCTicker> list = getTickerList();
            foreach (HitBTCTicker ticker in list)
            {
                processTicker(ticker.GetExchangeTicker());
            }
        }
        public static void updateExchangeTransactionList()
        {          
            List<HitBTCTransactionHistory> transactions = getTransactionsList(new HitBTCTransactionParameters());
            foreach (HitBTCTransactionHistory transaction in transactions)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", transaction.currency + " | " + transaction.type, LogManager.LogMessageType.DEBUG);
                processTransaction(transaction.ExchangeTransaction);
            }
            //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", "COUNT=" + Transactions.Count, LogManager.LogMessageType.DEBUG);          
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
        public enum HitBTCCandlePeriod
        {
            [Description("M1")]
            Minute_1,

            [Description("M3")]
            Minute_3,

            [Description("M5")]
            Minute_5,

            [Description("M15")]
            Minute_15,

            [Description("M30")]
            Minute_30,

            [Description("H1")]
            Hour_1,

            [Description("H4")]
            Hour_4,

            [Description("D1")]
            Day_1,

            [Description("D7")]
            Day_7,

            [Description("1M")]
            Month_1
        };
        public enum HitBTCOrderTimeInForce
        {
            [Description("Good Till Canceled")]
            GTC,

            [Description("Immediate or Canceled")]
            IOC,

            [Description("Fill or Kill")]
            FOK,

            [Description("Day")]
            Day,

            [Description("Good Till DateTime")]
            GTD
        }
        public enum HitBTCOrderType
        {
            limit,
            market,
            stopLimit,
            stopMarket
        }
        public enum HitBTCOrderSide
        {
            buy,
            sell
        }
        public enum HitBTCSort
        {
            DESC,
            ASC
        }
        public enum HitBTCTradeFilter
        {
            timestamp,
            id
        }
        public enum HitBTCTransferType
        {
            bankToExchange,
            exchangeToBank
        }
        #endregion
        #region DATAMODELS_Parameters
        public class HitBTCNewOrderParameters
        {
            public string symbol { get; set; }
            public string market { get; set; }
            public HitBTCOrderSide side { get; set; }
            public HitBTCOrderType type { get; set; }
            public HitBTCOrderTimeInForce timeInForce { get; set; }
            public Decimal quantity { get; set; }
            public Decimal price { get; set; }
            public Decimal stopPrice { get; set; }
            public DateTime expireTime { get; set; }
            public Boolean strictValidate { get; set; }
        }
        public class HitBTCOrderHistoryParameters
        {
            public string symbol { get; set; }
            public string market { get; set; }
            public string clientOrderId { get; set; }
            public DateTime from { get; set; }
            public DateTime till { get; set; }
            public int limit { get; set; } = 100;
            public Decimal offset { get; set; }
        }
        public class HitBTCTradeHistoryParameters
        {
            public string symbol { get; set; }
            public string market { get; set; }
            public HitBTCSort sort { get; set; }
            public string by { get; set; } // timestamp by default or id
            public DateTime from { get; set; }
            public DateTime till { get; set; }
            public int limit { get; set; } = 100;
            public Decimal offset { get; set; }
        }
        public class HitBTCTransferParameters
        {
            public string currency { get; set; }
            public Decimal amount { get; set; }
            public HitBTCTransferType type { get; set; }
        }
        public class HitBTCTransactionParameters
        {
            public string currency { get; set; }
            public HitBTCSort sort { get; set; }
            public string by { get; set; } // timestamp by default or id
            public DateTime from { get; set; }
            public DateTime till { get; set; }
            public int limit { get; set; } = 100;
            public Decimal offset { get; set; }
        }
        public class HitBTCWithdrawParameters
        {
            public string currency { get; set; }
            public Decimal amount { get; set; }
            public string address { get; set; }
            public string paymentId { get; set; }
            public Decimal networkFee { get; set; } // BETTER TO GO LOW - Rounds up
            public Boolean includeFee { get; set; }
            public Boolean autoCommit { get; set; }
        }
        #endregion
        #region DATAMODELS_Public
        public class HitBTCCandleData
        {
            public DateTime timestamp { get; set; }
            public string open { get; set; }
            public string close { get; set; }
            public string min { get; set; }
            public string max { get; set; }
            public string volume { get; set; }
            public string volumeQuote { get; set; }
        }
        public class HitBTCCurrency
        {
            public string id { get; set; }
            public string fullName { get; set; }
            public bool crypto { get; set; }
            public bool payinEnabled { get; set; }
            public bool payinPaymentId { get; set; }
            public int payinConfirmations { get; set; }
            public bool payoutEnabled { get; set; }
            public bool payoutIsPaymentId { get; set; }
            public bool transferEnabled { get; set; }
        }
        public class HitBTCCurrencySymbol
        {
            public string id { get; set; }
            public string baseCurrency { get; set; }
            public string quoteCurrency { get; set; }
            public string quantityIncrement { get; set; }
            public string tickSize { get; set; }
            public string takeLiquidityRate { get; set; }
            public string provideLiquidityRate { get; set; }
            public string feeCurrency { get; set; }
        }
        public class HitBTCOrderBookData
        {
            public string price { get; set; }
            public string size { get; set; }
            public string type { get; set; }
        }
        public class HitBTCTicker
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal ask { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal bid { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal last { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal open { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal low { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal high { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal volume { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal volumeQuote { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DateTime timestamp { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string symbol { get; set; }

            public ExchangeTicker GetExchangeTicker()
            {
                string pair = symbol;
                ExchangeTicker ticker = new ExchangeTicker()
                {
                    exchange = Name,                 
                    market = pair.Substring(pair.Length - 3),
                    symbol = pair.Substring(0, pair.Length - 3),
                    last = last,
                    ask = ask,
                    bid = bid,
                    volume = volume,
                    high = high,
                    low = low
                }; 
                return ticker;
            }
        }
        public class HitBTCTrades
        {
            public int id { get; set; }
            public string price { get; set; }
            public string quantity { get; set; }
            public string side { get; set; }
            public DateTime timestamp { get; set; }
        }
        #endregion
        #region DATAMODELS_Private
        public class HitBTCBalance
        {
            public string currency { get; set; }
            public Decimal reserved { get; set; }
            public Decimal available { get; set; }
            // PAYMENT BALANCE
            public Decimal total { get { return available + reserved; } }
            // ADDON DATA
            public Decimal TotalInBTC { get; set; } = 0;
            public Decimal TotalInBTCOrders { get; set; } = 0;
            public Decimal TotalInUSD { get; set; } = 0;
            public ExchangeBalance GetExchangeBalance()
            {
                return new ExchangeBalance()
                {
                    Exchange = Name,
                    Symbol = currency,
                    Balance = total,
                    OnOrders = reserved,
                    TotalInBTC = TotalInBTC,
                    TotalInBTCOrders = TotalInBTCOrders,
                    TotalInUSD = TotalInUSD
                };
            }
        }
        public class HitBTCCommission
        {
            public string takeLiquidityRate { get; set; }
            public string provideLiquidityRate { get; set; }
            // ADDON
            public string symbol { get; set; }
            public string market { get; set; }
        }
        public class HitBTCDepositAddress
        {
            public string address { get; set; }
            public string paymentId { get; set; }
            // ADDON
            public string symbol { get; set; }
        }
        public class HitBTCErrorMessage
        {
            public int code { get; set; }
            public string message { get; set; }
            public string description { get; set; }
        }
        public class HitBTCNewOrderMessage
        {
            public int id { get; set; }
            public string clientOrderId { get; set; }
            public string symbol { get; set; }
            public string side { get; set; }
            public string status { get; set; }
            public string type { get; set; }
            public string timeInForce { get; set; }
            public string quantity { get; set; }
            public string price { get; set; }
            public string cumQuantity { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            // ERROR
            public HitBTCErrorMessage error { get; set; }
        }
        
        public class HitBTCOrder
        {
            public string id { get; set; }
            public string clientOrderId { get; set; }
            public string symbol { get; set; }
            public string side { get; set; }
            public string status { get; set; }
            public string type { get; set; }
            public string timeInForce { get; set; }
            public Double quantity { get; set; }
            public Double price { get; set; }
            public Double cumQuantity { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            // TRADE HISTORY
            public string orderId { get; set; }
            public string fee { get; set; }
            public DateTime timestamp { get; set; }
        }
        
        public class HitBTCTransactionHistory
        {
            public string id { get; set; }
            public int index { get; set; }
            public string currency { get; set; }
            public double amount { get; set; }
            public string fee { get; set; }
            public string networkFee { get; set; }
            public string address { get; set; }
            public string hash { get; set; }
            public string status { get; set; }
            //public ExchangeTransactionType type { get; set; }
            public string type { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }

            public ExchangeTransaction ExchangeTransaction
            {
                get
                {
                    ExchangeTransaction transaction = new ExchangeTransaction()
                    {
                        id = id,
                        currency = currency,
                        address = address,
                        amount = amount,
                        //confirmations = Confirmations.ToString(),
                        datetime = updatedAt,
                        exchange = Name,
                        type = GetExchangeTransactionType(type)
                    };
                    return transaction;
                }
            }
        }
        public class HitBTCTransactionMessage
        {
            public string id { get; set; }
        }
        // POSSIBLY DEPRECATED V1
        public class HitBTCTradeHistoryItem
        {
            public string symbol { get; set; }
            public string side { get; set; }
            //public int tradeId { get; set; }
            public string tradeId { get; set; }
            public Double execPrice { get; set; }
            public long timestamp { get; set; }
            public int execQuantity { get; set; }
            public string originalOrderId { get; set; }
            public string clientOrderId { get; set; }
            public string fee { get; set; }
            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime.ToLocalTime();
                }
                /*
                set
                {

                }
                */
            }
        }
        /*
        public class HitBTCActiveOrder
        {
            public string orderId { get; set; }
            public string orderStatus { get; set; }
            public long lastTimestamp { get; set; }
            public Double orderPrice { get; set; }
            public Double orderQuantity { get; set; }
            public Double avgPrice { get; set; }
            public Double quantityLeaves { get; set; }
            public string type { get; set; }
            public string timeInForce { get; set; }
            public Double cumQuantity { get; set; }
            public string clientOrderId { get; set; }
            public string symbol { get; set; }
            public string side { get; set; }
            public Double execQuantity { get; set; }
            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeMilliseconds(lastTimestamp).UtcDateTime.ToLocalTime();
                }
               
            }
        }
*/
        public class HitBTCTransaction
        {
            public string id { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public long created { get; set; }
            public long finished { get; set; }
            public Double amount_from { get; set; }
            public string currency_code_from { get; set; }
            public Double amount_to { get; set; }
            public string currency_code_to { get; set; }
            public int commission_percent { get; set; }
            public string bitcoin_address { get; set; }
            public string bitcoin_return_address { get; set; }
            public string external_data { get; set; }
        }
        #endregion
        #endregion DataModels 
    }
}