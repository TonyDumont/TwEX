using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwEX_API.Exchange
{
    class Cryptopia
    {
        #region Properties
        public static string thisClassName = "Cryptopia";
        private static string ApiKey = String.Empty;
        private static string ApiSecret = String.Empty;
        private static RestClient client = new RestClient("https://www.cryptopia.co.nz/api");
        public static string Api_privateUrl = "https://www.cryptopia.co.nz/Api/";
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters
        /// <summary>GetCurrencies
        /// <para>Returns all currency data</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<CryptopiaCurrency> getCurrencyList()
        {
            List<CryptopiaCurrency> list = new List<CryptopiaCurrency>();
            try
            {
                string requestUrl = "/GetCurrencies";
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getMarketLists", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["Data"].ToObject<List<CryptopiaCurrency>>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getCurrencyList", "Success IS FALSE : message=" + jsonObject["Message"]);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getCurrencyList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>GetMarket
        /// <para>Returns market data for the specified trade pair</para>
        /// <para>Required : market (TradePairId or MarketName)</para>
        /// <para>Optional : hours (default: 24)</para>
        /// </summary>
        public static CryptopiaMarket getMarket(string symbol, string market, int hours = 24)
        {
            try
            {
                string requestUrl = "/GetMarkets/" + symbol.ToUpper() + "_" + market.ToUpper() + "/" + hours;
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getMarketLists", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject["Data"].ToObject<CryptopiaMarket>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getMarket", "Success IS FALSE : message=" + jsonObject["Message"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getMarket", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>GetMarkets
        /// <para>Returns all market data</para>
        /// <para>Required : none</para>
        /// <para>Optional : baseMarket (ex - BTC - default: All)</para>
        /// <para>Optional : hours (default: 24)</para>
        /// </summary>
        public static List<CryptopiaMarket> getMarketList(string baseMarket = "All", int hours = 24)
        {
            List<CryptopiaMarket> list = new List<CryptopiaMarket>();
            try
            {
                string requestUrl = "/GetMarkets/";
                if (baseMarket != "All")
                {
                    requestUrl += baseMarket.ToUpper() + "/";
                }
                requestUrl += hours;

                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getMarketLists", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["Data"].ToObject<List<CryptopiaMarket>>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getMarketLists", "Success IS FALSE : message=" + jsonObject["Message"]);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getMarketLists", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>GetMarketHistory
        /// <para>Returns the market history data for the specified tarde pair.</para>
        /// <para>Required : market (TradePairId or MarketName)</para>
        /// <para>Optional : hours (default: 24)</para>
        /// </summary>
        public static List<CryptopiaMarketHistory> getMarketHistoryList(string symbol, string market, int hours = 24)
        {
            List<CryptopiaMarketHistory> list = new List<CryptopiaMarketHistory>();
            try
            {
                string requestUrl = "/GetMarketHistory/" + symbol.ToUpper() + "_" + market.ToUpper() + "/" + hours;
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getMarketHistoryList", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["Data"].ToObject<List<CryptopiaMarketHistory>>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getMarketHistoryList", "Success IS FALSE : message=" + jsonObject["Message"]);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getMarketHistoryList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>GetMarketOrders
        /// <para>Returns the open buy and sell orders for the specified tarde pair.</para>
        /// <para>Required : market (TradePairId or MarketName)</para>
        /// <para>Optional : orderCount (default: 100)</para>
        /// </summary>
        public static List<CryptopiaMarketOrder> getMarketOrders(string symbol, string market, int orderCount = 100)
        {
            List<CryptopiaMarketOrder> list = new List<CryptopiaMarketOrder>();
            try
            {
                string requestUrl = "/GetMarkets/" + symbol.ToUpper() + "_" + market.ToUpper() + "/" + orderCount;
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getMarketLists", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    List<CryptopiaMarketOrder> buys = jsonObject["Data"]["Buy"].ToObject<List<CryptopiaMarketOrder>>();
                    List<CryptopiaMarketOrder> sells = jsonObject["Data"]["Sell"].ToObject<List<CryptopiaMarketOrder>>();

                    foreach (CryptopiaMarketOrder buy in buys)
                    {
                        buy.Type = "buy";
                        list.Add(buy);
                    }

                    foreach (CryptopiaMarketOrder sell in sells)
                    {
                        sell.Type = "sell";
                        list.Add(sell);
                    }
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getMarketLists", "Success IS FALSE : message=" + jsonObject["Message"]);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getMarketLists", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>GetMarketOrderGroups
        /// <para>Returns the open buy and sell orders for the specified markets.</para>
        /// <para>Required : markets (TradePairIds or MarketNames seperated by '-')</para>
        /// <para>Optional : orderCount (default: 100)</para>
        /// </summary>
        public static List<CryptopiaMarketOrder> getMarketOrderGroups(string SYMBOL_MARKET_pairs, int orderCount = 100)
        {
            List<CryptopiaMarketOrder> list = new List<CryptopiaMarketOrder>();
            try
            {
                string requestUrl = "/GetMarketOrderGroups/" + SYMBOL_MARKET_pairs + "/" + orderCount;
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getMarketLists", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    List<CryptopiaMarketOrder> buys = jsonObject["Data"]["Buy"].ToObject<List<CryptopiaMarketOrder>>();
                    List<CryptopiaMarketOrder> sells = jsonObject["Data"]["Sell"].ToObject<List<CryptopiaMarketOrder>>();

                    foreach (CryptopiaMarketOrder buy in buys)
                    {
                        buy.Type = "buy";
                        list.Add(buy);
                    }

                    foreach (CryptopiaMarketOrder sell in sells)
                    {
                        sell.Type = "sell";
                        list.Add(sell);
                    }
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getMarketLists", "Success IS FALSE : message=" + jsonObject["Message"]);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getMarketLists", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>GetTradePairs
        /// <para>Returns all trade pair data</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<CryptopiaTradePair> getTradePairList()
        {
            List<CryptopiaTradePair> list = new List<CryptopiaTradePair>();
            try
            {
                string requestUrl = "/GetTradePairs";
                var request = new RestRequest(requestUrl, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getMarketLists", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["Data"].ToObject<List<CryptopiaTradePair>>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getTradePairList", "Success IS FALSE : message=" + jsonObject["Message"]);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getTradePairList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // ------------------------
        public async static Task<string> GetApiPrivateRequest(string requestUrl, Object postData)
        {
            // Create Request
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(requestUrl);
            request.Content = new ObjectContent(typeof(object), postData, new JsonMediaTypeFormatter());

            // Authentication
            string requestContentBase64String = string.Empty;
            if (request.Content != null)
            {
                // Hash content to ensure message integrity
                using (var md5 = MD5.Create())
                {
                    requestContentBase64String = Convert.ToBase64String(md5.ComputeHash(await request.Content.ReadAsByteArrayAsync()));
                }
            }
            //create random nonce for each request
            //var nonce = Guid.NewGuid().ToString("N");
            var nonce = ExchangeManager.GetNonce();

            //Creating the raw signature string
            var signature = Encoding.UTF8.GetBytes(string.Concat(ApiKey, HttpMethod.Post, HttpUtility.UrlEncode(request.RequestUri.AbsoluteUri.ToLower()), nonce, requestContentBase64String));
            using (var hmac = new HMACSHA256(Convert.FromBase64String(ApiSecret)))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("amx", string.Format("{0}:{1}:{2}", ApiKey, Convert.ToBase64String(hmac.ComputeHash(signature)), nonce));
            }
            // Send Request
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        // ------------------------
        /// <summary>GetBalance
        /// <para>Returns all balances or a specific currency balance</para>
        /// <para>Required : Currency - The currency symbol of the balance to return e.g. 'DOT' (not required if 'CurrencyId' supplied)</para>
        /// <para>Optional : CurrencyId - The Cryptopia currency identifier of the balance to return e.g. '2' (not required if 'Currency' supplied)</para>
        /// </summary>
        public async static Task<List<CryptopiaBalance>> getBalanceList()
        {
            List<CryptopiaBalance> list = new List<CryptopiaBalance>();
            try
            {
                string requestUrl = Api_privateUrl + "GetBalance";
                var postData = new
                {
                    //Currency = "DOT"
                };

                string result = await GetApiPrivateRequest(requestUrl, postData);
                LogManager.AddLogMessage(thisClassName, "getBalanceList", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["Data"].ToObject<List<CryptopiaBalance>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "GetBalance", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>GetDepositAddress
        /// <para>Creates or returns a deposit address for the specified currency</para>
        /// <para>Required : Currency- The currency symbol of the address to return e.g. 'DOT' (not required if 'CurrencyId' supplied)</para>
        /// <para>Optional : CurrencyId- The Cryptopia currency identifier of the address to return e.g. '2' (not required if 'Currency' supplied)</para>
        /// </summary>
        public async static Task<CryptopiaDepositAddressMessage> getDepositAddress(string Currency)
        {
            try
            {
                string requestUrl = Api_privateUrl + "GetDepositAddress";
                var postData = new
                {
                    Currency = Currency.ToUpper()
                };

                string result = await GetApiPrivateRequest(requestUrl, postData);
                LogManager.AddLogMessage(thisClassName, "getDepositAddress", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject.ToObject<CryptopiaDepositAddressMessage>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "getDepositAddress", "success IS FALSE : Error=" + jsonObject["Error"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getDepositAddress", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>GetOpenOrders
        /// <para>Returns a list of open orders for all tradepairs or specified tradepair</para>
        /// <para>Required : Market: The market symbol of the orders to return e.g. 'DOT/BTC' (not required if 'TradePairId' supplied)</para>
        /// <para>Optional : TradePairId - The Cryptopia tradepair identifier of the orders to return e.g. '100' (not required if 'Market' supplied)</para>
        /// <para>Optional : Count - The maximum amount of orders to return e.g. '10' (default: 100)</para>
        /// </summary>
        public async static Task<List<CryptopiaOrder>> getOpenOrdersList(string symbol, string market, int Count = 100)
        {
            List<CryptopiaOrder> list = new List<CryptopiaOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "GetOpenOrders";
                var postData = new
                {
                    Market = "'" + symbol.ToUpper() + "/" + market.ToUpper() + "'",
                    Count = Count
                };

                string result = await GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(thisClassName, "getOpenOrdersList", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["Data"].ToObject<List<CryptopiaOrder>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getOpenOrdersList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>GetTradeHistory
        /// <para>Returns a list of trade history for all tradepairs or specified tradepair</para>
        /// <para>Required : Market: The market symbol of the history to return e.g. 'DOT/BTC' (not required if 'TradePairId' supplied)</para>
        /// <para>Optional : TradePairId - The Cryptopia tradepair identifier of the history to return e.g. '100' (not required if 'Market' supplied)</para>
        /// <para>Optional : Count - The maximum amount of history to return e.g. '10' (default: 100)</para>
        /// </summary>
        public async static Task<List<CryptopiaOrder>> getTradeHistoryList(string symbol, string market, int Count = 100)
        {
            List<CryptopiaOrder> list = new List<CryptopiaOrder>();
            try
            {
                string requestUrl = Api_privateUrl + "GetTradeHistory";
                var postData = new
                {
                    Market = "'" + symbol.ToUpper() + "/" + market.ToUpper() + "'",
                    Count = Count
                };

                string result = await GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(thisClassName, "getTradeHistoryList", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["Data"].ToObject<List<CryptopiaOrder>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getTradeHistoryList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }

        /// <summary>GetTransactions
        /// <para>Returns a list of transactions</para>
        /// <para>Required : Type - The type of transactions to return e.g. 'Deposit' or 'Withdraw'</para>
        /// <para>Optional : Count - The maximum amount of transactions to return e.g. '10' (default: 100)</para>
        /// </summary>
        public async static Task<List<CryptopiaTransaction>> getTransactionsList(CryptopiaTransactionType type, int Count = 100)
        {
            List<CryptopiaTransaction> list = new List<CryptopiaTransaction>();
            try
            {
                string requestUrl = Api_privateUrl + "GetTransactions";
                var postData = new
                {
                    Type = type,
                    Count = Count
                };

                string result = await GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(thisClassName, "getTransactionsList", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["Data"].ToObject<List<CryptopiaTransaction>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getTransactionsList", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }
        #endregion
        #region API_PRIVATE_Setters
        /// <summary>CancelTrade
        /// <para>Cancels a single order, all orders for a tradepair or all open orders</para>
        /// <para>Required : Type - The type of cancellation, Valid Types: 'All',  'Trade', 'TradePair'</para>
        /// <para>Required : OrderId - The order identifier of trade to cancel (required if type 'Trade')</para>
        /// <para>Optional : TradePairId - The Cryptopia tradepair identifier of trades to cancel e.g. '100' (required if type 'TradePair')</para>
        /// </summary>
        public async static Task<CryptopiaCancelMessage> setCancelTrade(string orderId, CryptopiaCancelTradeType type, string tradePairId = "")
        {
            try
            {
                string requestUrl = Api_privateUrl + "SubmitTrade";
                Object postData;

                if (type != CryptopiaCancelTradeType.TradePair)
                {
                    postData = new
                    {
                        OrderId = orderId,
                        Type = type
                    };
                }
                else
                {
                    postData = new
                    {
                        OrderId = orderId,
                        Type = type,
                        TradePairId = tradePairId
                    };
                }
                string result = await GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(thisClassName, "setCancelTrade", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject.ToObject<CryptopiaCancelMessage>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "setCancelTrade", "success IS FALSE : Error=" + jsonObject["Error"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "setCancelTrade", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>SubmitTrade
        /// <para>Submits a new trade order</para>
        /// <para>Required : Market - The market symbol of the trade e.g. 'DOT/BTC' (not required if 'TradePairId' supplied)</para>
        /// <para>Required : Type - the type of trade e.g. 'Buy' or 'Sell'</para>
        /// <para>Required : Rate - the rate or price to pay for the coins e.g. 0.00000034</para>
        /// <para>Required : Amount - the amount of coins to buy e.g. 123.00000000</para>
        /// <para>Optional : TradePairId - The Cryptopia tradepair identifier of trade e.g. '100' (not required if 'Market' supplied)</para>
        /// </summary>
        public async static Task<CryptopiaTradeMessage> setTrade(string symbol, string market, CryptopiaTradeType type, Decimal rate, Decimal amount)
        {
            try
            {
                string requestUrl = Api_privateUrl + "SubmitTrade";
                var postData = new
                {
                    Market = "'" + symbol.ToUpper() + "/" + market.ToUpper() + "'",
                    Type = type,
                    Rate = rate,
                    Amount = amount
                };

                string result = await GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(thisClassName, "setTrade", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject.ToObject<CryptopiaTradeMessage>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "setTrade", "success IS FALSE : Error=" + jsonObject["Error"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "setTrade", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }

        /// <summary>SubmitWithdraw
        /// <para>Submits a withdrawal request</para>
        /// <para>Required : Currency: The currency symbol of the coins to withdraw e.g. 'DOT' (not required if 'CurrencyId' supplied)</para>
        /// <para>Required : Address: The address to send the currency too. (Address must exist in you AddressBook, can be found in you Security settings page.)</para>
        /// <para>Required : PaymentId: The unique paimentid to identify the payment. (PaymentId for CryptoNote coins.)</para>
        /// <para>Required : Amount: the amount of coins to withdraw e.g. 123.00000000</para>
        /// <para>Optional : CurrencyId: The Cryptopia currency identifier of the coins to withdraw e.g. '2' (not required if 'Currency' supplied)</para>
        /// </summary>
        public async static Task<CryptopiaWithdrawMessage> setWithdraw(string currency, string address, Decimal amount, string paymentId = "")
        {
            try
            {
                string requestUrl = Api_privateUrl + "SubmitWithdraw";
                var postData = new
                {
                    Currency = currency.ToUpper(),
                    Address = address,
                    Amount = amount,
                    PaymentId = paymentId
                };

                string result = await GetApiPrivateRequest(requestUrl, postData);
                //LogManager.AddLogMessage(thisClassName, "setWithdraw", result);
                var jsonObject = JObject.Parse(result);
                string success = jsonObject["Success"].ToString().ToLower();

                if (success == "true")
                {
                    return jsonObject.ToObject<CryptopiaWithdrawMessage>();
                }
                else
                {
                    LogManager.AddLogMessage(thisClassName, "setWithdraw", "success IS FALSE : Error=" + jsonObject["Error"]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "setWithdraw", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        #endregion
        #region API_PRIVATE_TBD
        // SubmitTip - Submits a tip to the Trollbox
        // SubmitTransfer - Submits a transfer request to another user account
        #endregion
        #endregion API_Private
        
        #region DataModels
        #region DATAMODELS_Enumerables
        public enum CryptopiaCancelTradeType
        {
            All,
            Trade,
            TradePair
        }
        public enum CryptopiaTradeType
        {
            Buy,
            Sell
        }
        public enum CryptopiaTransactionType
        {
            Deposit,
            Withdraw
        }
        #endregion
        #region DATAMODELS_Public
        public class CryptopiaCurrency
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Symbol { get; set; }
            public string Algorithm { get; set; }
            public double WithdrawFee { get; set; }
            public double MinWithdraw { get; set; }
            public double MaxWithdraw { get; set; }
            public double MinBaseTrade { get; set; }
            public bool IsTipEnabled { get; set; }
            public double MinTip { get; set; }
            public int DepositConfirmations { get; set; }
            public string Status { get; set; }
            public string StatusMessage { get; set; }
            public string ListingStatus { get; set; }
        }
        public class CryptopiaMarket
        {
            public int TradePairId { get; set; }
            public string Label { get; set; }
            public Decimal AskPrice { get; set; }
            public Decimal BidPrice { get; set; }
            public Decimal Low { get; set; }
            public Decimal High { get; set; }
            public Decimal Volume { get; set; }
            public Decimal LastPrice { get; set; }
            public Decimal BuyVolume { get; set; }
            public Decimal SellVolume { get; set; }
            public Decimal Change { get; set; }
            public Decimal Open { get; set; }
            public Decimal Close { get; set; }
            public Decimal BaseVolume { get; set; }
            public Decimal BuyBaseVolume { get; set; }
            public Decimal SellBaseVolume { get; set; }
        }
        public class CryptopiaMarketOrder
        {
            public int TradePairId { get; set; }
            public string Label { get; set; }
            public double Price { get; set; }
            public double Volume { get; set; }
            public double Total { get; set; }
            // ADDON
            public string Type { get; set; }
        }
        public class CryptopiaMarketHistory
        {
            public int TradePairId { get; set; }
            public string Label { get; set; }
            public string Type { get; set; }
            public double Price { get; set; }
            public double Amount { get; set; }
            public double Total { get; set; }
            public int Timestamp { get; set; }
        }
        public class CryptopiaTradePair
        {
            public int Id { get; set; }
            public string Label { get; set; }
            public string Currency { get; set; }
            public string Symbol { get; set; }
            public string BaseCurrency { get; set; }
            public string BaseSymbol { get; set; }
            public string Status { get; set; }
            public string StatusMessage { get; set; }
            public double TradeFee { get; set; }
            public double MinimumTrade { get; set; }
            public double MaximumTrade { get; set; }
            public double MinimumBaseTrade { get; set; }
            public double MaximumBaseTrade { get; set; }
            public double MinimumPrice { get; set; }
            public double MaximumPrice { get; set; }
        }
        #endregion
        #region DATAMODELS_Private
        public class CryptopiaBalance
        {
            public int CurrencyId { get; set; }
            public string Symbol { get; set; }
            public Decimal Total { get; set; }
            public Decimal Available { get; set; }
            public Decimal Unconfirmed { get; set; }
            public Decimal HeldForTrades { get; set; }
            public Decimal PendingWithdraw { get; set; }
            public string Address { get; set; }
            public string Status { get; set; }
            public string StatusMessage { get; set; }
            public string BaseAddress { get; set; }
            // ADDON DATA
            public Decimal totalBTC { get; set; }
            public Decimal totalUSD { get; set; }
        }
        public class CryptopiaCancelMessage
        {
            public bool Success { get; set; }
            public object Error { get; set; }
            public List<int> Data { get; set; }
        }
        public class CryptopiaDepositAddressData
        {
            public string Currency { get; set; }
            public string Address { get; set; }
            public string BaseAddress { get; set; }
        }
        public class CryptopiaDepositAddressMessage
        {
            public bool Success { get; set; }
            public object Error { get; set; }
            public CryptopiaDepositAddressData Data { get; set; }
        }
        public class CryptopiaOrder
        {
            public int OrderId { get; set; }
            public int TradePairId { get; set; }
            public string Market { get; set; }
            public string Type { get; set; }
            public double Rate { get; set; }
            public double Amount { get; set; }
            public string Total { get; set; }
            public string Remaining { get; set; }
            public DateTime TimeStamp { get; set; }
            // TRADE HISTORY
            public int TradeId { get; set; }
            public string Fee { get; set; }
        }
        public class CryptopiaTradeMessage
        {
            public bool Success { get; set; }
            public object Error { get; set; }
            public CryptopiaTradeMessageData Data { get; set; }
        }
        public class CryptopiaTradeMessageData
        {
            public int OrderId { get; set; }
            public List<int> FilledOrders { get; set; }
        }
        public class CryptopiaTransaction
        {
            public int Id { get; set; }
            public string Currency { get; set; }
            public string TxId { get; set; }
            public string Type { get; set; }
            public double Amount { get; set; }
            public string Fee { get; set; }
            public string Status { get; set; }
            public string Confirmations { get; set; }
            public DateTime TimeStamp { get; set; }
            public string Address { get; set; }
        }
        public class CryptopiaWithdrawMessage
        {
            public bool Success { get; set; }
            public object Error { get; set; }
            public int Data { get; set; }
        }
        #endregion
        #endregion DataModels
    }
}
