using Newtonsoft.Json;
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
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    public class HitBTC
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "HitBTC";
        public static string Url { get; } = "https://hitbtc.com/";
        public static string USDSymbol { get; } = "USDT";
        // API
        public static string ApiKey { get; set; } = String.Empty;
        public static string ApiSecret { get; set; } = String.Empty;
        private static RestClient client = new RestClient("https://api.hitbtc.com");
        private static string Api_publicUrl = "/api/2/public/";
        private static string Api_privateUrl = "https://api.hitbtc.com/api/2/";
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
            try
            {
                string requestUrl = Api_publicUrl + "ticker";
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getTickers", "response : " + response.Content, LogManager.LogMessageType.EXCEPTION);
                /*
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    Formatting = Formatting.None,
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    Converters = new List<JsonConverter> { new DecimalConverter() }
                };
                */
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                HitBTCTicker[] array = jsonVal.ToObject<HitBTCTicker[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTickers", "EXCEPTION!!! : " + ex.Message, LogManager.LogMessageType.EXCEPTION);
                //LogManager.AddLogMessage(Name, "getTickers", "EXCEPTION!!! : " + response.Content, LogManager.LogMessageType.EXCEPTION);
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
            string credentials = ApiKey + ":" + ApiSecret;
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
            try
            {
                string requestUrl = Api_privateUrl + "account/balance";
                string response = GetApiPrivateRequest(requestUrl);
                //LogManager.AddLogMessage(Name, "getAccountBalanceList", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                HitBTCBalance[] array = jsonVal.ToObject<HitBTCBalance[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getAccountBalanceList", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
            try
            {
                string requestUrl = Api_privateUrl + "trading/balance";
                string response = GetApiPrivateRequest(requestUrl);
                LogManager.AddLogMessage(Name, "getTradingBalanceList", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                HitBTCBalance[] array = jsonVal.ToObject<HitBTCBalance[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalances", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                LogManager.AddLogMessage(Name, "getOrdersHistoryList", response, LogManager.LogMessageType.DEBUG);
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
                LogManager.AddLogMessage(Name, "getTradeHistoryListByOrder", response, LogManager.LogMessageType.DEBUG);
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
                //LogManager.AddLogMessage(Name, "getTradeHistoryListByOrder", response, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response) as JArray;
                HitBTCTransactionHistory[] array = jsonVal.ToObject<HitBTCTransactionHistory[]>();
                list = array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTradeHistoryListByOrder", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                    clientOrderId = clientOrderId
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
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();

            try
            {
                
                List<HitBTCTicker> tickerList = getTickerList();

                foreach (HitBTCTicker ticker in tickerList)
                {
                    ExchangeTicker eTicker = new ExchangeTicker();
                    eTicker.exchange = Name.ToUpper();
                    string pair = ticker.symbol;
                    eTicker.market = pair.Substring(pair.Length - 3);
                    eTicker.symbol = pair.Substring(0, pair.Length - 3);

                    eTicker.last = ticker.last;
                    eTicker.ask = ticker.ask;
                    eTicker.bid = ticker.bid;
                    eTicker.volume = ticker.volume;
                    eTicker.high = ticker.high;
                    eTicker.low = ticker.low;
                    list.Add(eTicker);
                }
                
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getExchangeTickerList", "EXCEPTION!!! : " + ex.Message);
            }
            
            return list;
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
            public Decimal last { get; set; }
            public Decimal open { get; set; }
            public Decimal low { get; set; }
            public Decimal high { get; set; }
            public Decimal volume { get; set; }
            public Decimal volumeQuote { get; set; }
            public DateTime timestamp { get; set; }
            public string symbol { get; set; }
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
            // TRADING BALANCE V1
            public string currency_code { get; set; }
            public Decimal cash { get; set; }
            // TRADING BALANCE V2
            public string currency { get; set; }
            public Decimal reserved { get; set; }
            public Decimal available { get; set; }
            // PAYMENT BALANCE
            public Decimal balance { get; set; }
            // ADDON DATA
            public Decimal totalBTC { get; set; }
            public Decimal totalCoins { get; set; }
            public Decimal totalUSD { get; set; }
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
            public Decimal quantity { get; set; }
            public Decimal price { get; set; }
            public Decimal cumQuantity { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            // TRADE HISTORY
            public int orderId { get; set; }
            public string fee { get; set; }
            public DateTime timestamp { get; set; }
        }
        public class HitBTCTransactionHistory
        {
            public string id { get; set; }
            public int index { get; set; }
            public string currency { get; set; }
            public string amount { get; set; }
            public string fee { get; set; }
            public string networkFee { get; set; }
            public string address { get; set; }
            public string hash { get; set; }
            public string status { get; set; }
            public string type { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
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
                /*
                set
                {

                }
                */
            }
        }
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