using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TwEX_API.Exchange
{
    public class GDAX
    {
        #region Properties
        public static String thisClassName = "GDAX";
        private static string ApiKey = String.Empty;
        private static string ApiSecret = String.Empty;
        private static string ApiPassphrase = String.Empty;
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
                LogManager.AddLogMessage(thisClassName, "getProductList", "Content:" + response.Content, LogManager.LogMessageType.DEBUG);
                //list = new JavaScriptSerializer().Deserialize<GDAXProduct[]>(response.Content).ToList();
                //var jsonObject = JObject.Parse(response.Content);
                // TO TEST
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getProductList", "EXCEPTION!!! : " + ex.Message);
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
                /*
                GDAXProductTicker ticker = new JavaScriptSerializer().Deserialize<GDAXProductTicker>(response.Content);
                ticker.id = productID;
                return ticker;
                */
                // TO TEST
                return null;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "GetProductTicker", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
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
            byte[] keyByte = Convert.FromBase64String(ApiSecret);
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
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", ApiKey);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", sig);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", ts);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", ApiPassphrase);
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
                        LogManager.AddLogMessage(thisClassName, "getAccountList", "response.IsSuccess is FALSE : NO DATA : response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getAccountList", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                // GET PAYMENT BALANCES
                string ts = ExchangeManager.GetNonce();
                string method = "/accounts";
                string sig = GetSignature(ts, "GET", method, string.Empty);
                using (var acclient = new HttpClient())
                {
                    acclient.BaseAddress = new Uri("https://api.gdax.com");
                    acclient.DefaultRequestHeaders.Accept.Clear();
                    acclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", ApiKey);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", sig);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", ts);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", ApiPassphrase);
                    acclient.DefaultRequestHeaders.Add("User-Agent", "Win32");
                    HttpResponseMessage response = acclient.GetAsync(method).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String result = await response.Content.ReadAsStringAsync();
                        //LogManager.AddLogMessage(thisClassName, "getAccountList", "response.IsSuccess: " + dataString);
                        //list = new JavaScriptSerializer().Deserialize<GDAXAccount[]>(result).ToList();
                        // TO TEST
                    }
                    else
                    {
                        LogManager.AddLogMessage(thisClassName, "getAccountList", "response.IsSuccess is FALSE : NO BALANCES TO PROCESS : response.Content=" + response.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getAccountList", "EXCEPTION!!! : " + ex.Message);
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
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", ApiKey);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", sig);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", ts);
                    acclient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", ApiPassphrase);
                    acclient.DefaultRequestHeaders.Add("User-Agent", "Win32");
                    HttpResponseMessage response = acclient.GetAsync(method).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String result = await response.Content.ReadAsStringAsync();
                        //LogManager.AddLogMessage(thisClassName, "getAccountHistoryList", "response.IsSuccess: " + dataString);
                        //list = new JavaScriptSerializer().Deserialize<GDAXAccountHistory[]>(result).ToList();
                        // TO TEST
                    }
                    else
                    {
                        LogManager.AddLogMessage(thisClassName, "getAccountHistoryList", "response.IsSuccess is FALSE : response.Content=" + response.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getAccountHistoryList", "EXCEPTION!!! : " + ex.Message);
            }

            return list;
        }
        #endregion
        #endregion API_Private
        
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
            // ROOT
            public int trade_id { get; set; }
            public Decimal price { get; set; }
            public Decimal size { get; set; }
            public Decimal bid { get; set; }
            public Decimal ask { get; set; }
            public Decimal volume { get; set; }
            public string time { get; set; }
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
            public Decimal totalBTC { get; set; }
            public Decimal totalUSD { get; set; }
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