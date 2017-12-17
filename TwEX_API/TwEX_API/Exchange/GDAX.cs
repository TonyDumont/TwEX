using Newtonsoft.Json.Linq;
using RestSharp;
using System;
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
        public static string USDSymbol { get; } = "USD";
        // API
        public static ExchangeApi Api { get; set; }
        private static RestClient client = new RestClient("https://api.gdax.com");
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
            try
            {
                // GET PRODUCTS
                var request = new RestRequest("/products", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getProductList", "Content:" + response.Content, LogManager.LogMessageType.DEBUG);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                list = jsonVal.ToObject<GDAXProduct[]>().ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getProductList", "EXCEPTION!!! : " + ex.Message, LogManager.LogMessageType.EXCEPTION);
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
            try
            {
                var request = new RestRequest("/products/" + productID + "/ticker", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage("GDAXControl", "GetProductTicker", "TICKER:" + tickresponse.Content);
                var jsonObject = JObject.Parse(response.Content);
                GDAXProductTicker ticker = jsonObject.ToObject<GDAXProductTicker>();
                ticker.id = productID;
                string[] split = ticker.id.Split('-');
                ticker.symbol = split[0];
                ticker.market = split[1];
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
                return null;
            }
        }

        /// <summary>Ticker List
        /// <para>Get a list of all available currency pair tickers</para>
        /// </summary>
        public static List<GDAXProductTicker> getProductTickerList()
        {
            List<GDAXProductTicker> list = new List<GDAXProductTicker>();
            try
            {
                // GET PRODUCTS
                List<GDAXProduct> products = getProductList();

                foreach (GDAXProduct product in products)
                {
                    //LogManager.AddLogMessage(Name, "getProductTickerList", product.id, LogManager.LogMessageType.DEBUG);
                    GDAXProductTicker ticker = GetProductTicker(product.id);
                    list.Add(ticker);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getProductTickerList", "EXCEPTION!!! : " + ex.Message);
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
            try
            {
                string ts = ExchangeManager.GetNonce();
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
                        String result = await response.Content.ReadAsStringAsync();
                        //LogManager.AddLogMessage(Name, "getAccountList", "response.IsSuccess: " + result);
                        JArray jArray = JArray.Parse(result) as JArray;
                        list = jArray.ToObject<List<GDAXAccount>>();
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "getAccountList", "response.IsSuccess is FALSE : NO BALANCES TO PROCESS : response.Content=" + response.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getAccountList", "EXCEPTION!!! : " + ex.Message);
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
                string ts = ExchangeManager.GetNonce();
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
                        //LogManager.AddLogMessage(Name, "getAccountHistoryList", "response.IsSuccess: " + dataString);
                        //list = new JavaScriptSerializer().Deserialize<GDAXAccountHistory[]>(result).ToList();
                        // TO TEST
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
        #endregion
        #endregion API_Private

        #region ExchangeManager
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
        // UPDATERS
        public async static void updateExchangeBalanceList()
        {
            List<GDAXAccount> list = await getAccountList();
            foreach (GDAXAccount balance in list)
            {
                ExchangeManager.processBalance(balance.GetExchangeBalance());
            }
        }
        public static void updateExchangeTickerList()
        {
            List<GDAXProductTicker> tickerList = getProductTickerList();

            foreach (GDAXProductTicker ticker in tickerList)
            {
                ExchangeManager.processTicker(ticker.GetExchangeTicker());
            }
        }
        #endregion ExchangeManager

        #region DataModels
        #region DATAMODELS_Public
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
        }
        public class GDAXProductTicker
        {
            public string id { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
            // ROOT
            public int trade_id { get; set; }
            public Decimal price { get; set; }
            public Decimal size { get; set; }
            public Decimal bid { get; set; }
            public Decimal ask { get; set; }
            public Decimal volume { get; set; }
            public string time { get; set; }

            public ExchangeTicker GetExchangeTicker()
            {
                ExchangeTicker eTicker = new ExchangeTicker();
                eTicker.exchange = Name.ToUpper();
                //string[] pairs = ticker.pair.Split('_');
                eTicker.market = market;
                eTicker.symbol = symbol;
                eTicker.last = price;
                eTicker.ask = ask;
                eTicker.bid = bid;
                //eTicker.change = ticker.percentChange;
                eTicker.volume = volume;
                //eTicker.high = ticker.high24hr;
                //eTicker.low = ticker.low24hr;
                return eTicker;
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
            public Decimal TotalInUSD { get; set; } = 0;
            public ExchangeBalance GetExchangeBalance()
            {
                ExchangeBalance eBalance = new ExchangeBalance();
                eBalance.Symbol = currency;
                eBalance.Exchange = Name;
                eBalance.Balance = balance;
                eBalance.OnOrders = hold;
                eBalance.TotalInBTC = TotalInBTC;
                eBalance.TotalInUSD = TotalInUSD;
                return eBalance;
            }
        }
        public class GDAXAccountHistory
        {
            public string id { get; set; }
            public DateTime created_at { get; set; }
            public string amount { get; set; }
            public string balance { get; set; }
            public string type { get; set; }
            public GDAXAccountHistoryDetails details { get; set; }
        }
        public class GDAXAccountHistoryDetails
        {
            public string order_id { get; set; }
            public string trade_id { get; set; }
            public string product_id { get; set; }
        }
        #endregion
        #endregion DataModels      
    }
}