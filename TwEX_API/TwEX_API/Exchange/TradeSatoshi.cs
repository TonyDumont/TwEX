using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    public class TradeSatoshi
    {

        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "TradeSatoshi";
        public static string Url { get; } = "https://tradesatoshi.com";
        public static string USDSymbol { get; } = "USDT";
        public static string IconUrl { get; } = "https://pbs.twimg.com/profile_images/669329805582581760/wO1hscPj_400x400.jpg";
        public static string TradingView { get; } = "";
        // API
        public static ExchangeApi Api { get; set; }
        //public static string ApiKey { get; set; } = String.Empty;
        //public static string ApiSecret { get; set; } = String.Empty;
        private static RestClient client = new RestClient("https://tradesatoshi.com/api");
        // STATUS
        public static int ErrorCount { get; set; } = 0;
        public static DateTime LastUpdate { get; set; } = DateTime.Now;
        public static string LastMessage { get; set; } = String.Empty;
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters
        // PUBLIC GETTERS
        public static List<TradeSatoshiCurrency> getCurrencyList()
        {
            List<TradeSatoshiCurrency> list = new List<TradeSatoshiCurrency>();
            try
            {
                var request = new RestRequest("/public/getcurrencies", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getCurrencyList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                string success = jsonObject["success"].ToString().ToLower();

                if (success == "true")
                {
                    list = jsonObject["result"].ToObject<List<TradeSatoshiCurrency>>();
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrencyList", "EXCEPTION!!! : " + ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        // GetTicker
        // GetMarketHistory
        // GetMarketSummary
        public static List<TradeSatoshiMarketSummary> getMarketSummariesList()
        {
            List<TradeSatoshiMarketSummary> list = new List<TradeSatoshiMarketSummary>();
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
                    list = jsonObject["result"].ToObject<List<TradeSatoshiMarketSummary>>();
                    UpdateStatus(true, "Updated Tickers");
                }
                else
                {
                    UpdateStatus(true, jsonObject["message"].ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getMarketSummariesList", ex.Message + " | " + responseString, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, responseString);
            }
            return list;
        }
        // GetOrderBook
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // ------------------------
        // PRIVATE AUTH UTILS
        // ------------------------
        // PRIVATE GETTERS
        // ------------------------
        /*
        private static string getHMAC(string secret, string url)
        {
            var hmac = new HMACSHA512(Encoding.ASCII.GetBytes(secret));
            var messagebyte = Encoding.ASCII.GetBytes(url);
            var hashmessage = hmac.ComputeHash(messagebyte);
            var sign = BitConverter.ToString(hashmessage).Replace("-", "");
            return sign;
        }
        */

            /*
        private static Task<string> GetSignature(string uri, string nonce, string post_params = null)
        {
            string signature = "";
            if (post_params != null)
            {
                post_params = Convert.ToBase64String(Encoding.UTF8.GetBytes(post_params));
                signature = Api.key + "POST" + uri + nonce + post_params;
            }
            else
            {
                signature = Api.key + "POST" + uri + nonce;
            }
            LogManager.AddLogMessage(Name, "GetSignature", "sig:" + signature, LogManager.LogMessageType.DEBUG);

            byte[] messageBytes = Encoding.UTF8.GetBytes(signature);
            using (HMACSHA512 _object = new HMACSHA512(Convert.FromBase64String(Api.secret)))
            {
                byte[] hashmessage = _object.ComputeHash(messageBytes);
                return Task.FromResult(Convert.ToBase64String(hashmessage));
            }


        }
        */
        private static string GetSignatureString(string uri, string nonce, string post_params = null)
        {
            string signature = "";
            if (post_params != null)
            {
                post_params = Convert.ToBase64String(Encoding.UTF8.GetBytes(post_params));
                signature = Api.key + "POST" + uri + nonce + post_params;
            }
            else
            {
                signature = Api.key + "POST" + uri + nonce;
            }
            //LogManager.AddLogMessage(Name, "GetSignatureString", "sig:" + signature, LogManager.LogMessageType.DEBUG);
            
            byte[] messageBytes = Encoding.UTF8.GetBytes(signature);
            using (HMACSHA512 _object = new HMACSHA512(Convert.FromBase64String(Api.secret)))
            {
                byte[] hashmessage = _object.ComputeHash(messageBytes);
                //return Task.FromResult(Convert.ToBase64String(hashmessage));
                return Convert.ToBase64String(hashmessage);
            }
            
            //return signature;
        }
        
        private static Task<string> GetSignature(string uri, string nonce, string post_params = null)
        {
            string signature = "";
            if (post_params != null)
            {
                post_params = Convert.ToBase64String(Encoding.UTF8.GetBytes(post_params));
                signature = Api.key + "POST" + uri + nonce + post_params;
            }
            else
            {
                signature = Api.key + "POST" + uri + nonce;
            }
            byte[] messageBytes = Encoding.UTF8.GetBytes(signature);
            using (HMACSHA512 _object = new HMACSHA512(Convert.FromBase64String(Api.secret)))
            {
                byte[] hashmessage = _object.ComputeHash(messageBytes);
                return Task.FromResult(Convert.ToBase64String(hashmessage));
            }
        }

        public static async Task<List<TradeSatoshiBalance>> GetTSBalances()
        {
            List<TradeSatoshiBalance> list = new List<TradeSatoshiBalance>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string uri = "https://tradesatoshi.com/api/private/getbalances";
                    //string nonce = Guid.NewGuid().ToString();
                    string nonce = ExchangeManager.GetNonce();
                    string signature = GetSignature(uri, nonce).Result;
                    string authenticationString = "Basic " + Api.key + ":" + signature + ":" + nonce;
                    client.DefaultRequestHeaders.Add("Authentication", authenticationString);
                    string result = await client.PostAsync(uri, null).Result.Content.ReadAsStringAsync();
                    LogManager.AddLogMessage(Name, "GetBalances", "result=" + result, LogManager.LogMessageType.OTHER);
                    //return JsonConvert.DeserializeObject<GetBalancesReturn>(result);
                    //return JsonConvert.DeserializeObject<GetBalancesReturn>(result);
                }
                catch (Exception e) { throw e; };
            }
            return list;
        }

        // GetBalance
        public static async Task<List<TradeSatoshiBalance>> getBalanceList()
        {
            List<TradeSatoshiBalance> list = new List<TradeSatoshiBalance>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string uri = "https://tradesatoshi.com/api/private/getbalances";
                    //string nonce = Guid.NewGuid().ToString();
                    string nonce = ExchangeManager.GetNonce();
                    LogManager.AddLogMessage(Name, "1:getBalanceList", uri + " | " + nonce, LogManager.LogMessageType.DEBUG);

                    /*
                    if (Api != null)
                    {
                        LogManager.AddLogMessage(Name, "API", "Api=" + Api.key + " | " + Api.secret, LogManager.LogMessageType.OTHER);
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "API", "IS NULL", LogManager.LogMessageType.DEBUG);
                    }
                    */


                    /*
                    string signature = GetSignatureString(uri, nonce);
                    LogManager.AddLogMessage(Name, "2:getBalanceList", signature, LogManager.LogMessageType.DEBUG);
                    

                    
                    string authenticationString = "Basic " + Api.key + ":" + signature + ":" + nonce;
                    LogManager.AddLogMessage(Name, "getBalanceList", authenticationString, LogManager.LogMessageType.DEBUG);
                    client.DefaultRequestHeaders.Add("Authentication", authenticationString);
                    */


                    
                    string result = await client.PostAsync(uri, null).Result.Content.ReadAsStringAsync();
                    LogManager.AddLogMessage(Name, "getBalanceList", result, LogManager.LogMessageType.DEBUG);
                    //return JsonConvert.DeserializeObject<GetBalancesReturn>(result);
                    
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "EX:getBalanceList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                    //UpdateStatus(false, responseString);
                    //throw e;
                };
            }
            /*
            string responseString = string.Empty;
            try
            {


                
                string requestUrl = "https://tradesatoshi.com/api/private/getbalances?apikey=" + Api.key + "&nonce=" + ExchangeManager.GetNonce();
                var url = new Uri(requestUrl);
                var webreq = WebRequest.Create(url);
                var signature = getHMAC(Api.secret, requestUrl);
                webreq.Headers.Add("apisign", signature);
                var webresp = webreq.GetResponse();
                var stream = webresp.GetResponseStream();
                var strRead = new StreamReader(stream);
                //String result = strRead.ReadToEnd();
                responseString = strRead.ReadToEnd();
                LogManager.AddLogMessage(Name, "getBalanceList", "result=" + responseString);
                
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
                LogManager.AddLogMessage(Name, "getBalanceList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                UpdateStatus(false, responseString);
            }
            */
            return list;
        }


        public static async Task<TradeSatoshiBalance> GetBalance(string Currency)
        {
            TradeSatoshiBalance balance = new TradeSatoshiBalance();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string uri = "https://tradesatoshi.com/api/private/getbalance";
                    //string nonce = Guid.NewGuid().ToString();
                    string nonce = ExchangeManager.GetNonce();
                    JObject post_params = new JObject();
                    post_params.Add("Currency", Currency);
                    string signature = GetSignature(uri, nonce, JsonConvert.SerializeObject(post_params)).Result;
                    //string authenticationString = "Basic " + GlobalSettings.API_Key + ":" + signature + ":" + nonce;
                    string authenticationString = Api.key + ":" + signature + ":" + nonce;
                    //string authenticationString = "Basic " + Api.key + ":" + signature + ":" + nonce;
                    client.DefaultRequestHeaders.Add("Authentication", authenticationString);
                    string result = await client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(post_params), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync();
                    LogManager.AddLogMessage(Name, "GetBalance", "result=" + result, LogManager.LogMessageType.CONSOLE);
                    //return JsonConvert.DeserializeObject<GetBalanceReturn>(await client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(post_params), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "GetBalance", ex.Message, LogManager.LogMessageType.EXCEPTION);
                    //throw e;
                };
            }
            return balance;
        }

        #endregion
        #region API_PRIVATE_Setters
        // PRIVATE SETTERS
        #endregion
        #region API_PRIVATE_TBD
        // TO BE DEVELOPED
        #endregion
        #endregion API_Private

        #region ExchangeManager
        public static void InitializeExchange()
        {

            LogManager.AddLogMessage(Name, "InitializeExchange", "Initialized", LogManager.LogMessageType.EXCHANGE);
            /*
            updateExchangeBalanceList(true);
            Thread.Sleep(1000);
            updateExchangeOrderList(true);
            */
            //InitializeExchangeBalanceList();
            //updateExchangeTickerList();
        }


        public static void updateExchangeBalanceList(bool clear = false)
        {

            if (Api != null)
            {
                LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "Api = NULL", LogManager.LogMessageType.OTHER);
            }
            else
            {
                LogManager.AddLogMessage(Name, "updateExchangeBalanceList", Api.key, LogManager.LogMessageType.OTHER);
            }
            /*
            List<BittrexBalance> list = getBalanceList();
            ExchangeTicker btcTicker = getExchangeTicker(Name, "BTC", USDSymbol);

            if (list.Count > 0)
            {
                if (clear)
                {
                    ClearBalances(Name);
                }

                foreach (BittrexBalance balance in list)
                {
                    if (balance.Balance > 0)
                    {
                        if (balance.Currency != "BTC" && balance.Currency != USDSymbol)
                        {
                            // GET TICKER FOR PAIR IN BTC MARKET
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
                        processBalance(balance.GetExchangeBalance());
                    }
                }
            }
            */
        }
        public static void updateExchangeOrderList(bool clear = false)
        {
            /*
            List<ExchangeOrder> list = new List<ExchangeOrder>();
            List<BittrexOpenOrder> openorders = getOpenOrdersList();

            if (clear)
            {
                ClearOrders(Name);
            }

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
            */
        }
        public static void updateExchangeTransactionList()
        {
            /*
            List<BittrexDeposit> depositList = getDepositHistoryList();
            foreach (BittrexDeposit deposit in depositList)
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
            */
        }
        public static void updateExchangeTickerList()
        {
            /*
            List<BittrexMarketSummary> list = getMarketSummariesList();
            foreach (BittrexMarketSummary ticker in list)
            {
                processTicker(ticker.GetExchangeTicker());
            }
            */
        }

        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();
            /*
            List<> tickerList = getTickerList();

            foreach (PoloniexTicker ticker in tickerList)
            {
                ExchangeTicker eTicker = new ExchangeTicker();
                eTicker.exchange = Name;

                string[] pairs = ticker.pair.Split('_');
                eTicker.market = pairs[0];
                eTicker.symbol = pairs[1];

                eTicker.last = ticker.last;
                eTicker.ask = ticker.lowestAsk;
                eTicker.bid = ticker.highestBid;
                eTicker.change = ticker.percentChange;
                eTicker.volume = ticker.baseVolume;
                eTicker.high = ticker.high24hr;
                eTicker.low = ticker.low24hr;

                list.Add(eTicker);
            }
            */
            return list;
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
        // ENUMS
        #endregion
        #region DATAMODELS_Public 
        // PUBLIC MODELS
        public class TradeSatoshiCurrency
        {
            public string currency { get; set; }
            public string currencyLong { get; set; }
            public int minConfirmation { get; set; }
            public double txFee { get; set; }
            public string status { get; set; }
        }
        public class TradeSatoshiMarketSummary
        {
            public string market { get; set; }
            public double high { get; set; }
            public double low { get; set; }
            public double volume { get; set; }
            public double baseVolume { get; set; }
            public double last { get; set; }
            public double bid { get; set; }
            public double ask { get; set; }
            public int openBuyOrders { get; set; }
            public int openSellOrders { get; set; }
            public double change { get; set; }
        }
        /*
        public class RootObject
        {
            public bool success { get; set; }
            public object message { get; set; }
            public List<Result> result { get; set; }
        }
        */
        #endregion
        #region DATAMODELS_Private
        // PRIVATE MODELS
        public class TradeSatoshiBalance
        {
            public string Currency { get; set; }
            public string CurrencyLong { get; set; }
            public int Avaliable { get; set; }
            public int Total { get; set; }
            public int HeldForTrades { get; set; }
            public int Unconfirmed { get; set; }
            public int PendingWithdraw { get; set; }
            public string Address { get; set; }
        }
        #endregion
        #endregion DataModels

    }
}
