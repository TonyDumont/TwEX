using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    public class GDAX
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "GDAX";
        public static string Url { get; } = "https://www.gdax.com/";
        public static string IconUrl { get; } = "https://www.gdax.com/favicon.ico";
        public static string USDSymbol { get; } = "USD";
        public static string TradingView { get; } = "Coinbase";
        // API
        public static ExchangeApi Api { get; set; }
        private static RestClient client = new RestClient("https://api.gdax.com");
        // COLLECTIONS
        public static BlockingCollection<GDAXProduct> Products = new BlockingCollection<GDAXProduct>();
        // STATUS
        public static int ErrorCount { get; set; } = 0;
        public static DateTime LastUpdate { get; set; } = DateTime.Now;
        public static string LastMessage { get; set; } = String.Empty;
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters
        
        /// <summary>/products
        /// <para>Get a list of available currency pairs for trading.</para>
        /// <para>The base_min_size and base_max_size fields define the min and max order size. The quote_increment field specifies the min order price as well as the price increment.</para>
        /// <para>The order price must be a multiple of this increment (i.e. if the increment is 0.01, order prices of 0.001 or 0.021 would be rejected).</para>
        /// <para>Product ID will not change once assigned to a product but the min/max/quote sizes can be updated in the future.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<GDAXProduct> getProductList()
        {
            List<GDAXProduct> list = new List<GDAXProduct>();
            string responseString = String.Empty;

            try
            {
                var request = new RestRequest("/products", Method.GET);
                var response = client.Execute(request);
                responseString = response.Content;
                //LogManager.AddLogMessage(Name, "getProductList", "Content:" + response.Content, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(responseString) as JArray;
                list = jsonVal.ToObject<GDAXProduct[]>().ToList();
                UpdateStatus(true, "Updated Products");
            }
            catch (Exception ex)
            {
                //LogManager.AddLogMessage(Name, "getProductList", "EXCEPTION!!! : " + ex.Message, LogManager.LogMessageType.EXCEPTION);
                var jsonObject = JObject.Parse(responseString);
                GDAXErrorMessage error = jsonObject.ToObject<GDAXErrorMessage>();
                LogManager.AddLogMessage(Name, "getProductList", ex.Message + " | " + error.message, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, error.message);
            }
            return list;
        }
        
        /// <summary>/products/<product-id>/ticker
        /// <para>Snapshot information about the last trade (tick), best bid/ask and 24h volume.</para>
        /// <para>Required : product-id</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static GDAXProductTicker GetProductTicker(string productID)
        {
            string responseString = string.Empty;
            try
            {
                var request = new RestRequest("/products/" + productID + "/ticker", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage("GDAXControl", "GetProductTicker", "TICKER:" + tickresponse.Content);
                responseString = response.Content;
                var jsonObject = JObject.Parse(responseString);
                GDAXProductTicker ticker = jsonObject.ToObject<GDAXProductTicker>();
                ticker.id = productID;
                string[] split = ticker.id.Split('-');
                ticker.symbol = split[0];
                ticker.market = split[1];
                //LogManager.AddLogMessage(Name, "GetProductTicker", ticker.id + " | " + ticker.price);
                UpdateStatus(true, "Updated Tickers");
                return ticker;
                /*
                GDAXProductTicker ticker = new JavaScriptSerializer().Deserialize<GDAXProductTicker>(response.Content);
                ticker.id = productID;
                return ticker;
                */
                // TO TEST
                //return null;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "GetProductTicker", "EXCEPTION!!! : " + ex.Message);
                UpdateStatus(false, responseString);
                return null;
            }
        }

        /// <summary>Ticker List
        /// <para>Get a list of all available currency pair tickers</para>
        /// </summary>
        public static List<GDAXProductTicker> getProductTickerList()
        {
            List<GDAXProductTicker> list = new List<GDAXProductTicker>();

            if (Products.Count > 0)
            {
                foreach (GDAXProduct product in Products)
                {
                    GDAXProductTicker ticker = GetProductTicker(product.id);
                    //LogManager.AddLogMessage(Name, "getProductTickerList", product.id, LogManager.LogMessageType.DEBUG);
                    list.Add(ticker);
                }
            }
            else
            {
                if (updateProductList())
                {
                    foreach (GDAXProduct product in Products)
                    {
                        GDAXProductTicker ticker = GetProductTicker(product.id);
                        //LogManager.AddLogMessage(Name, "getProductTickerList", product.id, LogManager.LogMessageType.DEBUG);
                        list.Add(ticker);
                    }
                }
            }

            return list;
        }
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // ------------------------
        public static string GetSignature(string nonce, string method, string url, string body)
        {
            string message = string.Concat(nonce, method.ToUpper(), url, body);
            var encoding = new ASCIIEncoding();
            //byte[] keyByte = Convert.FromBase64String(config.API.Secret);
            byte[] keyByte = Convert.FromBase64String(Api.secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
        // ------------------------
        /// <summary>/accounts/<account-id>
        /// <para>Information for a single account. Use this endpoint when you know the account_id.</para>
        /// <para>Required : account-id</para>
        /// <para>Optional : none</para>
        /// </summary>
        public async static Task<GDAXAccount> getAccount(string account_id)
        {
            try
            {
                string ts = ExchangeManager.GetNonce();
                string method = "/accounts/" + account_id;
                string sig = GetSignature(ts, "GET", method, string.Empty);
                using (var acclient = new HttpClient())
                {
                    acclient.BaseAddress = new Uri("https://api.gdax.com");
                    acclient.DefaultRequestHeaders.Accept.Clear();
                    acclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", Api.key);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", sig);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", ts);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", Api.passphrase);
                    acclient.DefaultRequestHeaders.Add("User-Agent", "Win32");
                    HttpResponseMessage response = acclient.GetAsync(method).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String result = await response.Content.ReadAsStringAsync();
                        var jsonObject = JObject.Parse(result);
                        return jsonObject.ToObject<GDAXAccount>();
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "getAccountList", "response.IsSuccess is FALSE : NO DATA : response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getAccountList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }

        /// <summary>/accounts
        /// <para>Get a list of trading accounts.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public async static Task<List<GDAXAccount>> getAccountList()
        {
            List<GDAXAccount> list = new List<GDAXAccount>();
            string responseString = string.Empty;
            try
            {
                string ts = GetNonce();
                string method = "/accounts";
                string sig = GetSignature(ts, "GET", method, string.Empty);
                using (var acclient = new HttpClient())
                {
                    acclient.BaseAddress = new Uri("https://api.gdax.com");
                    acclient.DefaultRequestHeaders.Accept.Clear();
                    acclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", Api.key);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", sig);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", ts);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", Api.passphrase);
                    acclient.DefaultRequestHeaders.Add("User-Agent", "Win32");
                    HttpResponseMessage response = acclient.GetAsync(method).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = await response.Content.ReadAsStringAsync();
                        //LogManager.AddLogMessage(Name, "getAccountList", "response.IsSuccess: " + result);
                        JArray jArray = JArray.Parse(responseString) as JArray;
                        list = jArray.ToObject<List<GDAXAccount>>();
                        UpdateStatus(true, "Updated Balances");
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "getAccountList", "response.IsSuccess is FALSE : NO BALANCES TO PROCESS : response.Content=" + response.Content);
                        UpdateStatus(true, response.Content.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getAccountList", "EXCEPTION!!! : " + ex.Message);
                UpdateStatus(false, responseString);
            }
            return list;
        }

        /// <summary>/accounts/<account-id>/ledger
        /// <para>List account activity. Account activity either increases or decreases your account balance. Items are paginated and sorted latest first. See the Pagination section for retrieving additional entries after the first page</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public async static Task<List<GDAXAccountHistory>> getAccountHistoryList(string account_id)
        {
            List<GDAXAccountHistory> list = new List<GDAXAccountHistory>();
            try
            {
                string ts = GetNonce();
                string method = "/accounts/" + account_id + "/ledger";
                string sig = GetSignature(ts, "GET", method, string.Empty);
                using (var acclient = new HttpClient())
                {
                    acclient.BaseAddress = new Uri("https://api.gdax.com");
                    acclient.DefaultRequestHeaders.Accept.Clear();
                    acclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", Api.key);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", sig);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", ts);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", Api.passphrase);
                    acclient.DefaultRequestHeaders.Add("User-Agent", "Win32");
                    HttpResponseMessage response = acclient.GetAsync(method).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String result = await response.Content.ReadAsStringAsync();
                        //LogManager.AddLogMessage(Name, "getAccountHistoryList", result, LogManager.LogMessageType.DEBUG);
                        JArray jArray = JArray.Parse(result) as JArray;
                        list = jArray.ToObject<List<GDAXAccountHistory>>();
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "getAccountHistoryList", "response.IsSuccess is FALSE : response.Content=" + response.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getAccountHistoryList", "EXCEPTION!!! : " + ex.Message);
            }

            return list;
        }

        /// <summary>List Orders
        /// <para>List your current open orders. Only open or un-settled orders are returned. As soon as an order is no longer open and settled, it will no longer appear in the default request.</para>
        /// <para>Required : status : [open, pending, active] : Limit list of orders to these statuses. Passing 'all' returns orders of all statuses</para>
        /// <para>Optional : product_id : Only list orders for a specific product</para>
        /// </summary>
        public async static Task<List<GDAXOrder>> getOrdersList()
        {
            List<GDAXOrder> list = new List<GDAXOrder>();
            string responseString = string.Empty;
            try
            {
                string ts = GetNonce();
                string method = "/orders?status=all";
                string sig = GetSignature(ts, "GET", method, string.Empty);
                using (var acclient = new HttpClient())
                {
                    acclient.BaseAddress = new Uri("https://api.gdax.com");
                    acclient.DefaultRequestHeaders.Accept.Clear();
                    acclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", Api.key);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", sig);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", ts);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", Api.passphrase);
                    acclient.DefaultRequestHeaders.Add("User-Agent", "Win32");
                    HttpResponseMessage response = acclient.GetAsync(method).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = await response.Content.ReadAsStringAsync();
                        //LogManager.AddLogMessage(Name, "getOrdersList", "response.IsSuccess: " + responseString, LogManager.LogMessageType.DEBUG);
                        
                        JArray jArray = JArray.Parse(responseString) as JArray;
                        list = jArray.ToObject<List<GDAXOrder>>();
                        //UpdateStatus(true, "Updated Balances");
                        
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "getOrdersList", "response.IsSuccess is FALSE : NO ORDERS TO PROCESS : response.Content=" + response.Content);
                        //UpdateStatus(true, response.Content.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getOrdersList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                //UpdateStatus(false, responseString);
            }
            return list;
        }
        #endregion
        #endregion API_Private

        #region ExchangeManager
        // INITIALIZE
        public static void InitializeExchange()
        {
            LogManager.AddLogMessage(Name, "InitializeExchange", "Initialized", LogManager.LogMessageType.EXCHANGE);
            //updateExchangeTickerList();
            // GET PRODUCTS
            Products = new BlockingCollection<GDAXProduct>(new ConcurrentQueue<GDAXProduct>(getProductList()));
            //updateExchangeTickerList();
        }
        /*
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();
            List<GDAXProductTicker> tickerList = getProductTickerList();
            
            foreach (GDAXProductTicker ticker in tickerList)
            {
                list.Add(ticker.GetExchangeTicker());
            }           
            return list;
        }
        */
        // UPDATERS
        public async static void updateExchangeBalanceList()
        {
            List<GDAXAccount> list = await getAccountList();
            ExchangeTicker btcTicker = ExchangeManager.getExchangeTicker("CryptoCompare", "BTC", USDSymbol);
            //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", list.Count + " | " + btcTicker.last + " | " + btcTicker.exchange, LogManager.LogMessageType.EXCHANGE);
            foreach (GDAXAccount balance in list)
            {
                if (balance.balance > 0)
                {
                    if (balance.currency != "BTC" && balance.currency != USDSymbol)
                    {
                        // GET TICKER FOR PAIR IN BTC MARKET
                        ExchangeTicker ticker = ExchangeManager.getExchangeTicker("CryptoCompare", balance.currency.ToUpper(), "BTC");

                        if (ticker != null)
                        {
                            //Decimal orders = balance.Balance - balance.Available;
                            if (balance.hold > 0)
                            {
                                balance.TotalInBTCOrders = balance.hold * ticker.last;
                            }

                            balance.TotalInBTC = balance.balance * ticker.last;
                            balance.TotalInUSD = btcTicker.last * balance.TotalInBTC;
                        }
                        else
                        {
                            LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "EXCHANGE TICKER WAS NULL : " + Name + " | " + balance.currency.ToUpper(), LogManager.LogMessageType.EXCHANGE);
                        }
                    }
                    else
                    {
                        //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "CHECKING CURRENCY :" + balance.Currency, LogManager.LogMessageType.DEBUG);
                        if (balance.currency == "BTC")
                        {
                            if (balance.hold > 0)
                            {
                                balance.TotalInBTCOrders = balance.hold;
                            }

                            balance.TotalInBTC = balance.balance;
                            balance.TotalInUSD = btcTicker.last * balance.balance;
                        }
                        else if (balance.currency == USDSymbol)
                        {
                            if (btcTicker.last > 0)
                            {
                                if (balance.hold > 0)
                                {
                                    balance.TotalInBTCOrders = balance.hold / btcTicker.last;
                                }

                                balance.TotalInBTC = balance.balance / btcTicker.last;
                            }
                            balance.TotalInUSD = balance.balance;
                        }
                    }
                    //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", balance.Currency + " | " + balance.Balance + " | " + balance.TotalInBTC + " | " + balance.TotalInUSD, LogManager.LogMessageType.DEBUG);
                    ExchangeManager.processBalance(balance.GetExchangeBalance());
                }
            
            }
        }
        public async static void updateExchangeOrderList()
        {
            List<ExchangeOrder> list = new List<ExchangeOrder>();
            List<GDAXOrder> orders = await getOrdersList();
            
            foreach (GDAXOrder order in orders)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeOrderList", order.symbol + " | " + order.market + " | " + order.type, LogManager.LogMessageType.DEBUG);
                string[] pairSplit = order.product_id.Split('-');
                bool open = false;
                if (order.status == "open")
                {
                    open = true;
                }

                ExchangeOrder eOrder = new ExchangeOrder()
                {
                    exchange = Name,
                    id = order.id,
                    type = order.side,
                    rate = order.price,
                    amount = order.size,
                    total = order.price * order.size,
                    market = pairSplit[1],
                    symbol = pairSplit[0],
                    date = order.created_at,
                    open = open
                };
                processOrder(eOrder);
            }
            /*
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
            //LogManager.AddLogMessage(Name, "updateExchangeOrderList", "COUNT=" + Orders.Count, LogManager.LogMessageType.DEBUG);
        }
        public static void updateExchangeTickerList()
        {
            try
            {
                List<GDAXProductTicker> tickerList = getProductTickerList();
                foreach (GDAXProductTicker ticker in tickerList)
                {
                    //LogManager.AddLogMessage(Name, "updateExchangeTickerList", ticker.id + " | " + ticker.price + " | " + ticker.ask, LogManager.LogMessageType.DEBUG);
                   processTicker(ticker.GetExchangeTicker());
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "updateExchangeTickerList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
        }
        public async static void updateExchangeTransactionList()
        {
            List<GDAXAccount> accounts = await getAccountList();
            foreach(GDAXAccount account in accounts)
            {
                //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", account.id + " | " + account.currency, LogManager.LogMessageType.DEBUG);
                List<GDAXAccountHistory> history = await getAccountHistoryList(account.id);
                //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", account.currency + " | " + history.Count, LogManager.LogMessageType.DEBUG);
                foreach(GDAXAccountHistory historyItem in history)
                {
                    //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", historyItem.type + " | " + historyItem.id, LogManager.LogMessageType.DEBUG);
                    historyItem.currency = account.currency;
                    processTransaction(historyItem.ExchangeTransaction);
                }
            }           
            //LogManager.AddLogMessage(Name, "updateExchangeTransactionList", "COUNT=" + Transactions.Count, LogManager.LogMessageType.DEBUG);         
        }
        public static Boolean updateProductList()
        {
            List<GDAXProduct> list = getProductList();
            //string responseString = String.Empty;
            foreach(GDAXProduct product in list)
            {
                GDAXProduct listItem = Products.FirstOrDefault(item => item.id == product.id);

                if (listItem != null)
                {
                    listItem.base_min_size = product.base_min_size;
                    listItem.base_max_size = product.base_max_size;
                    listItem.quote_increment = product.quote_increment;
                    listItem.status = product.status;
                    listItem.status_message = product.status_message;
                }
                else
                {
                    Products.Add(product);
                }
            }
            return true;
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
        #region DATAMODELS_Public
        public class GDAXErrorMessage
        {
            public string message { get; set; }
        }
        public class GDAXProduct
        {
            public string id { get; set; }
            public string base_currency { get; set; }
            public string quote_currency { get; set; }
            public Decimal base_min_size { get; set; }
            public Decimal base_max_size { get; set; }
            public Decimal quote_increment { get; set; }
            public string display_name { get; set; }
            public bool margin_enabled { get; set; }
            public string status { get; set; }
            public object status_message { get; set; }
        }
        public class GDAXProductTicker
        {
            public string id { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
            // ROOT
            public int trade_id { get; set; }
            public Decimal price { get; set; } = 0;
            public Decimal size { get; set; }
            public Decimal bid { get; set; } = 0;
            public Decimal ask { get; set; } = 0;
            public Decimal volume { get; set; } = 0;
            public string time { get; set; }

            public ExchangeTicker GetExchangeTicker()
            {
                ExchangeTicker ticker = new ExchangeTicker()
                {
                    exchange = Name,
                    market = market,
                    symbol = symbol,
                    last = price,
                    ask = ask,
                    bid = bid,
                    volume = volume
                };      
                return ticker;
            }
        }
        #endregion
        #region DATAMODELS_Private
        public class GDAXAccount
        {
            public string id { get; set; }
            public string currency { get; set; }
            public Decimal balance { get; set; }
            public Decimal available { get; set; }
            public Decimal hold { get; set; }
            public string profile_id { get; set; }
            // ADDON DATA
            public Decimal TotalInBTC { get; set; } = 0;
            public Decimal TotalInBTCOrders { get; set; } = 0;
            public Decimal TotalInUSD { get; set; } = 0;
            public ExchangeBalance GetExchangeBalance()
            {
                return new ExchangeBalance()
                {
                    Symbol = currency,
                    Exchange = Name,
                    Balance = balance,
                    OnOrders = hold,
                    TotalInBTC = TotalInBTC,
                    TotalInBTCOrders = TotalInBTCOrders,
                    TotalInUSD = TotalInUSD
                };
            }
        }
        public class GDAXAccountHistory
        {
            public string id { get; set; }
            public DateTime created_at { get; set; }
            public double amount { get; set; }
            public string balance { get; set; }
            public string type { get; set; }
            public GDAXAccountHistoryDetails details { get; set; }

            public string currency { get; set; }
            //public ExchangeTransactionType type { get; set; }

            public ExchangeTransaction ExchangeTransaction
            {
                get
                {
                    ExchangeTransaction transaction = new ExchangeTransaction()
                    {
                        id = id,
                        currency = currency,
                        //address = CryptoAddress,
                        amount = amount,
                        //confirmations = Confirmations.ToString(),
                        datetime = created_at,
                        exchange = Name,
                        type = GetExchangeTransactionType(type)
                    };
                    return transaction;
                }
            }
        }
        public class GDAXAccountHistoryDetails
        {
            public string order_id { get; set; }
            public string trade_id { get; set; }
            public string product_id { get; set; }
            public string transfer_id { get; set; }
            public string transfer_type { get; set; }
        }
        public class GDAXOrder
        {
            public string id { get; set; }
            public double price { get; set; }
            public double size { get; set; }
            public string product_id { get; set; }
            public string side { get; set; }
            public string stp { get; set; }
            public string type { get; set; }
            public string time_in_force { get; set; }
            public bool post_only { get; set; }
            public DateTime created_at { get; set; }
            public string fill_fees { get; set; }
            public string filled_size { get; set; }
            public string executed_value { get; set; }
            public string status { get; set; }
            public bool settled { get; set; }
            public string funds { get; set; }
            public string specified_funds { get; set; }
            public DateTime? done_at { get; set; }
            public string done_reason { get; set; }
        }
        #endregion
        #endregion DataModels      
    }
}