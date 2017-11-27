using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TwEX_API.Exchange
{
    class Poloniex
    {
        #region Properties
        public static string thisClassName = "Poloniex";
        private static string ApiKey = String.Empty;
        private static string ApiSecret = String.Empty;
        private static RestClient client = new RestClient("https://poloniex.com");
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters
        public static List<Poloniex24hVolume> get24hVolumeList()
        {
            List<Poloniex24hVolume> list = new List<Poloniex24hVolume>();
            try
            {
                var request = new RestRequest("/public?command=return24hVolume", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddDebugMessage(thisClassName, "get24VolumeList", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);

                //List<Poloniex24hVolume> list = new List<Poloniex24hVolume>();

                foreach (var entry in jsonObject)
                {
                    if (!entry.Key.Contains("total"))
                    {
                        //LogManager.AddDebugMessage(thisClassName, "get24VolumeList", entry.Key + " | " + entry.Value);
                        Poloniex24hVolume item = new Poloniex24hVolume();
                        item.pair = entry.Key; // MKT_SYM
                        string[] stringSplit = item.pair.Split('_');
                        item.market = stringSplit[0];
                        item.marketVolume = Convert.ToDecimal(jsonObject[item.pair][item.market]);
                        item.symbol = stringSplit[1];
                        item.symbolVolume = Convert.ToDecimal(jsonObject[item.pair][item.symbol]);
                        list.Add(item);
                        //LogManager.AddDebugMessage(thisClassName, "get24VolumeList", entry.Key + " | " + jsonObject[item.pair][item.market] + " | " + jsonObject[item.pair][item.symbol]);
                    }
                    else
                    {
                        // THESE ARE TOTALS - symbol & market contain same values
                        Poloniex24hVolume item = new Poloniex24hVolume();
                        item.pair = entry.Key; // totalMKT
                        item.market = entry.Key.Replace("total", "");
                        item.marketVolume = Convert.ToDecimal(entry.Value);
                        item.symbol = "total";
                        item.symbolVolume = Convert.ToDecimal(entry.Value);
                        list.Add(item);
                    }
                }
                //return list;
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "get24VolumeList", "EXCEPTION!!! : " + ex.Message);
                //return null;
            }
            return list;
        }
        public static List<PoloniexChartData> getChartData(string symbol, string market, long start, long end, PoloniexChartPeriod period)
        {
            try
            {
                //RestClient client = new RestClient("https://poloniex.com");
                //LogManager.AddDebugMessage(thisClassName, "getChartData", "period=" + (Int32)period);
                string url = "/public?command=returnChartData&currencyPair=" + market + "_" + symbol + "&start=" + start + "&end=" + end + "&period=" + (Int32)period;
                //LogManager.AddDebugMessage(thisClassName, "returnChartData", "url=" + url);
                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddDebugMessage(thisClassName, "returnTicker", "response.Content=" + response.Content);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                PoloniexChartData[] array = jsonVal.ToObject<PoloniexChartData[]>();
                return array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "getChartData", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        public static List<PoloniexCurrency> getCurrencies()
        {
            try
            {
                string url = "/public?command=returnCurrencies";
                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddDebugMessage(thisClassName, "getCurrencies", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                List<PoloniexCurrency> list = new List<PoloniexCurrency>();

                foreach (var item in jsonObject)
                {
                    //LogManager.AddDebugMessage(thisClassName, "getCurrencies", "key=" + item.Key + " | " + item.Value);         
                    PoloniexCurrency currency = jsonObject[item.Key].ToObject<PoloniexCurrency>();
                    currency.symbol = item.Key;
                    list.Add(currency);
                }
                return list;
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "getCurrencies", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        public static List<PoloniexLoanOrder> getLoanOrders(string currency)
        {
            try
            {
                string url = "/public?command=returnLoanOrders&currency=" + currency;

                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddDebugMessage(thisClassName, "getOrderBooks", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                List<PoloniexLoanOrder> list = new List<PoloniexLoanOrder>();
                List<PoloniexLoanOrder> offers = jsonObject["offers"].ToObject<List<PoloniexLoanOrder>>();
                List<PoloniexLoanOrder> demands = jsonObject["demands"].ToObject<List<PoloniexLoanOrder>>();

                foreach (PoloniexLoanOrder offer in offers)
                {
                    offer.type = "offer";
                    list.Add(offer);
                }

                foreach (PoloniexLoanOrder demand in demands)
                {
                    demand.type = "demand";
                    list.Add(demand);
                }

                return list;
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "getLoanOrders", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        public static PoloniexOrderBookItem getOrderBook(string currencyPair, int depth = 0)
        {
            try
            {
                string url = "/public?command=returnOrderBook&currencyPair=" + currencyPair;

                if (depth > 0)
                {
                    url += "&depth=" + depth;
                }

                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                LogManager.AddDebugMessage(thisClassName, "getOrderBook", "response.Content=" + response.Content);
                /*
                // MIGRATION
                //PoloniexOrderBookItem orderBookItem = new JavaScriptSerializer().Deserialize<PoloniexOrderBookItem>(response.Content);

                //LogManager.AddDebugMessage(thisClassName, "returnTicker", "items.seq=" + item.seq);
                orderBookItem.pair = currencyPair;
                string[] pairSplit = currencyPair.Split('_');
                orderBookItem.symbol = pairSplit[1];
                orderBookItem.market = pairSplit[0];
                
                return orderBookItem;
                */
                return null;
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "getOrderBook", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        public static List<PoloniexOrderBookItem> getOrderBooks(int depth = 0)
        {
            try
            {
                string url = "/public?command=returnOrderBook&currencyPair=all";

                if (depth > 0)
                {
                    url += "&depth=" + depth;
                }

                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddDebugMessage(thisClassName, "getOrderBooks", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                List<PoloniexOrderBookItem> list = new List<PoloniexOrderBookItem>();

                foreach (var item in jsonObject)
                {
                    //LogManager.AddDebugMessage(thisClassName, "getOrderBooks", "key=" + item.Key + " | " + item.Value);
                    PoloniexOrderBookItem orderBook = jsonObject[item.Key].ToObject<PoloniexOrderBookItem>();
                    orderBook.pair = item.Key;
                    string[] pairSplit = orderBook.pair.Split('_');
                    orderBook.symbol = pairSplit[1];
                    orderBook.market = pairSplit[0];
                    list.Add(orderBook);
                }
                return list;
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "getOrderBooks", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        public static List<PoloniexTicker> getTickerList()
        {
            List<PoloniexTicker> list = new List<PoloniexTicker>();
            /*
            try
            {
                // GET TICKERS
                var request = new RestRequest("/public?command=returnTicker", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddDebugMessage(thisClassName, "getTickerList", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);

                List<PoloniexTicker> list = new List<PoloniexTicker>();

                foreach (var entry in jsonObject)
                {
                    PoloniexTicker ticker = new JavaScriptSerializer().Deserialize<PoloniexTicker>(entry.Value.ToString());
                    ticker.pair = entry.Key;
                    list.Add(ticker);
                }
                return list;
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "getTickerList", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
            */
            return list;
        }
        public static List<PoloniexTradeHistory> getTradeHistory(string symbol, string market, long start = 0, long end = 0) // RETURNS LAST 200 if no start or end
        {
            try
            {
                string url = "/public?command=returnTradeHistory&currencyPair=" + market + "_" + symbol;

                if (start > 0 && end > 0)
                {
                    url += "&start=" + start + "&end=" + end;
                }
                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddDebugMessage(thisClassName, "getTradeHistory", "response.Content=" + response.Content);
                JArray jsonVal = JArray.Parse(response.Content) as JArray;
                PoloniexTradeHistory[] array = jsonVal.ToObject<PoloniexTradeHistory[]>();
                //LogManager.AddDebugMessage(thisClassName, "getTradeHistory", "Length=" + array.Length);
                return array.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "getTradeHistory", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // -------------------------------------------------------------
        private static string getHMAC(string message)
        {
            var hmac = new HMACSHA512(Encoding.ASCII.GetBytes(ApiSecret));
            var messagebyte = Encoding.ASCII.GetBytes(message);
            var hashmessage = hmac.ComputeHash(messagebyte);
            var sign = BitConverter.ToString(hashmessage).Replace("-", "").ToLower();
            return sign;
        }
        private static async Task<string> getPrivateApiRequestAsync(string privUrl, string myParam)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(privUrl);
                StringContent myContent = new StringContent(myParam);
                myContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                client.DefaultRequestHeaders.Add("Key", ApiKey);
                client.DefaultRequestHeaders.Add("Sign", getHMAC(myParam));
                var result = await client.PostAsync(privUrl, myContent);
                return await result.Content.ReadAsStringAsync();
            }
        }
        // -------------------------------------------------------------
        public static async Task<List<PoloniexBalance>> getBalances()
        {
            string url = "https://poloniex.com/tradingApi";
            string myParam = "command=returnBalances&nonce=" + ExchangeManager.GetNonce();
            string result = await getPrivateApiRequestAsync(url, myParam);
            LogManager.AddDebugMessage("PoloniexManager", "returnBalances", "result=" + result);

            var jsonObject = JObject.Parse(result);
            List<PoloniexBalance> list = new List<PoloniexBalance>();
            return list;
        }  
        public static async Task<List<PoloniexBalance>> getCompleteBalances()
        {
            List<PoloniexBalance> list = new List<PoloniexBalance>();
            
            string url = "https://poloniex.com/tradingApi";
            string myParam = "command=returnCompleteBalances&nonce=" + ExchangeManager.GetNonce();
            string result = await getPrivateApiRequestAsync(url, myParam);
            //LogManager.AddDebugMessage("PoloniexManager", "returnCompleteBalances", "result=" + result);

            var jsonObject = JObject.Parse(result);
            //List<PoloniexBalance> list = new List<PoloniexBalance>();

            foreach (var item in jsonObject)
            {
                //PoloniexBalance balance = new JavaScriptSerializer().Deserialize<PoloniexBalance>(item.Value.ToString());
                //balance.symbol = item.Key;
                //list.Add(balance);
            }
            
            return list;
        }
        public static async Task<List<PoloniexWallet>> getDepositAddresses()
        {
            string url = "https://poloniex.com/tradingApi";
            string myParam = "command=returnDepositAddresses&nonce=" + ExchangeManager.GetNonce();
            string result = await getPrivateApiRequestAsync(url, myParam);
            //LogManager.AddDebugMessage("PoloniexManager", "getDepositAddresses", "result=" + result);

            var jsonObject = JObject.Parse(result);
            List<PoloniexWallet> list = new List<PoloniexWallet>();

            foreach (var item in jsonObject)
            {
                PoloniexWallet wallet = new PoloniexWallet();
                wallet.symbol = item.Key;
                wallet.address = item.Value.ToString();
                list.Add(wallet);
            }

            return list;
        }
        public static async Task<List<PoloniexTransaction>> getDepositsWithdrawals(long unixStart, long unixEnd)
        {
            List<PoloniexTransaction> list = new List<PoloniexTransaction>();
            try
            {
                
                string url = "https://poloniex.com/tradingApi";
                string myParam = "command=returnDepositsWithdrawals&start=" + unixStart + "&end=" + unixEnd + "&nonce=" + ExchangeManager.GetNonce();

                string result = await getPrivateApiRequestAsync(url, myParam);
                //LogManager.AddDebugMessage(thisClassName, "returnDepositsWithdrawals", "result=" + result);
                var jsonObject = JObject.Parse(result);
                //LogManager.AddDebugMessage(thisClassName, "returnDepositsWithdrawals", jsonObject["deposits"].ToString());
                /*
                //List<PoloniexTransaction> list = new List<PoloniexTransaction>();
                List<PoloniexTransaction> deposits = new JavaScriptSerializer().Deserialize<List<PoloniexTransaction>>(jsonObject["deposits"].ToString());
                List<PoloniexTransaction> withdrawals = new JavaScriptSerializer().Deserialize<List<PoloniexTransaction>>(jsonObject["withdrawals"].ToString());

                foreach (PoloniexTransaction deposit in deposits)
                {
                    deposit.type = "deposit";
                    list.Add(deposit);
                }

                foreach (PoloniexTransaction withdrawal in withdrawals)
                {
                    withdrawal.type = "withdraw";
                    list.Add(withdrawal);
                }

                return list;
                */
                
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "returnDepositsWithdrawals", "EXCEPTION!!! : " + ex.Message);
            }
            return list;
        }     
        public static async Task<string> getNewAddresses(string symbol)
        {
            string url = "https://poloniex.com/tradingApi";
            string myParam = "command=generateNewAddress&currency=" + symbol + "&nonce=" + ExchangeManager.GetNonce();
            string result = await getPrivateApiRequestAsync(url, myParam);
            //LogManager.AddDebugMessage("PoloniexManager", "getNewAddresses", "result=" + result);

            var jsonObject = JObject.Parse(result);

            int success = Convert.ToInt32(jsonObject["success"]);

            if (success == 1)
            {
                return jsonObject["response"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        public static async Task<List<PoloniexOpenOrder>> getOpenOrders(string symbol, string market)
        {
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string param = "command=returnOpenOrders&currencyPair=" + market + "_" + symbol + "&nonce=" + ExchangeManager.GetNonce();
                Boolean isAll = (symbol.ToLower() == "all" || market.ToLower() == "all");

                if (isAll)
                {
                    param = "command=returnOpenOrders&currencyPair=all&nonce=" + ExchangeManager.GetNonce();
                }

                string result = await getPrivateApiRequestAsync(url, param);
                //LogManager.AddDebugMessage(thisClassName, "returnOpenOrders", "result=" + result);

                if (isAll)
                {
                    var jsonObject = JObject.Parse(result);
                    List<PoloniexOpenOrder> list = new List<PoloniexOpenOrder>();

                    foreach (var item in jsonObject)
                    {
                        //LogManager.AddDebugMessage(thisClassName, "returnOpenOrders", item.Key + " | " + item.Value);

                        PoloniexOpenOrder[] orders = jsonObject[item.Key].ToObject<PoloniexOpenOrder[]>();
                        //LogManager.AddDebugMessage(thisClassName, "returnOpenOrders", "count=" + orders.Count());
                        if (orders.Count() > 0)
                        {
                            foreach (PoloniexOpenOrder order in orders)
                            {
                                order.pair = item.Key;
                                string[] pairSplit = order.pair.Split('_');
                                order.market = pairSplit[0];
                                order.symbol = pairSplit[1];
                                list.Add(order);
                            }
                        }
                    }
                    return list;
                }
                else
                {
                    JArray jsonVal = JArray.Parse(result) as JArray;
                    //PoloniexChartData[] array = jsonVal.ToObject<PoloniexChartData[]>();
                    List<PoloniexOpenOrder> list = jsonVal.ToObject<List<PoloniexOpenOrder>>();

                    foreach (PoloniexOpenOrder order in list)
                    {
                        order.symbol = symbol;
                        order.market = market;
                        order.pair = market + "_" + symbol;
                        list.Add(order);
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "returnOpenOrders", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        public static async Task<List<PoloniexTradeHistory>> getOrderTrades(string orderNumber)
        {
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string param = "command=returnOrderTrades&orderNumber=" + orderNumber + "&nonce=" + ExchangeManager.GetNonce();
                string result = await getPrivateApiRequestAsync(url, param);
                //LogManager.AddDebugMessage(thisClassName, "getOrderTrades", "result=" + result);

                // ARRAY
                JArray jsonVal = JArray.Parse(result) as JArray;
                List<PoloniexTradeHistory> list = jsonVal.ToObject<List<PoloniexTradeHistory>>();

                foreach (PoloniexTradeHistory item in list)
                {
                    item.pair = item.currencyPair;
                    string[] pairSplit = item.pair.Split('_');
                    item.symbol = pairSplit[1];
                    item.market = pairSplit[0];
                }
                return list;
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "getOrderTrades", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        } 
        public static async Task<List<PoloniexTradeHistory>> getTradeHistoryList(string symbol, string market, long unixStart = 0, long unixEnd = 0, int limit = 500) // limit up to 10,000
        {
            string url = "https://poloniex.com/tradingApi";
            string param = String.Empty;
            Boolean isAll = (symbol.ToLower() == "all" || market.ToLower() == "all");

            if (isAll)
            {
                param = "command=returnTradeHistory&currencyPair=all&nonce=" + ExchangeManager.GetNonce();
            }
            else
            {
                param = "command=returnTradeHistory&currencyPair=" + market + "_" + symbol + "&nonce=" + ExchangeManager.GetNonce();
            }

            if (unixStart > 0)
            {
                param += "&start=" + unixStart;

                if (unixEnd > 0)
                {
                    param += "&end=" + unixEnd;
                }
            }

            if (limit > 500)
            {
                param += "&limit=" + limit;
            }
            //LogManager.AddDebugMessage(thisClassName, "returnTradeHistory", "param=" + param);

            string result = await getPrivateApiRequestAsync(url, param);
            //LogManager.AddDebugMessage(thisClassName, "returnTradeHistory", "result=" + result);

            if (isAll)
            {
                // OBJECT        
                var jsonObject = JObject.Parse(result);
                List<PoloniexTradeHistory> list = new List<PoloniexTradeHistory>();

                foreach (var item in jsonObject)
                {
                    //LogManager.AddDebugMessage(thisClassName, "returnOpenOrders", item.Key + " | " + item.Value);
                    PoloniexTradeHistory[] trades = jsonObject[item.Key].ToObject<PoloniexTradeHistory[]>();
                    //LogManager.AddDebugMessage(thisClassName, "returnOpenOrders", "count=" + orders.Count());
                    if (trades.Count() > 0)
                    {
                        foreach (PoloniexTradeHistory trade in trades)
                        {
                            trade.pair = item.Key;
                            string[] pairSplit = trade.pair.Split('_');
                            trade.market = pairSplit[0];
                            trade.symbol = pairSplit[1];
                            list.Add(trade);
                        }
                    }
                }
                return list;
            }
            else
            {
                // ARRAY
                JArray jsonVal = JArray.Parse(result) as JArray;
                List<PoloniexTradeHistory> list = jsonVal.ToObject<List<PoloniexTradeHistory>>();

                foreach (PoloniexTradeHistory item in list)
                {
                    item.symbol = symbol;
                    item.market = market;
                    item.pair = market + "_" + symbol;
                    list.Add(item);
                }
                return list;
            }
        }
        #endregion
        #region API_PRIVATE_Setters
        // SETTERS
        public static async Task<PoloniexNewOrderResult> setBuy(string symbol, string market, Decimal rate, Decimal amount, PoloniexOrderOption option = PoloniexOrderOption.None) //You may optionally set "fillOrKill", "immediateOrCancel", "postOnly" to 1.
        {
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string param = "command=buy&currencyPair=" + market + "_" + symbol + "&rate=" + rate + "&amount=" + amount + "&nonce=" + ExchangeManager.GetNonce();

                if (option != PoloniexOrderOption.None)
                {
                    param += "&" + option + "=1";
                }
                //LogManager.AddDebugMessage(thisClassName, "buyOrder", "option=" + option + " | " + param);
                string result = await getPrivateApiRequestAsync(url, param);
                //LogManager.AddDebugMessage(thisClassName, "buyOrder", "result=" + result);
                //return new JavaScriptSerializer().Deserialize<PoloniexNewOrderResult>(result);
                return null;
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "setBuy", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        public static async Task<Boolean> setCancel(string orderNumber)
        {
            string url = "https://poloniex.com/tradingApi";

            string myParam = "command=cancelOrder&orderNumber=" + orderNumber + "&nonce=" + ExchangeManager.GetNonce();
            string result = await getPrivateApiRequestAsync(url, myParam);
            //LogManager.AddDebugMessage(thisClassName, "cancelOrder", "result=" + result);
            /*
            PoloniexCancelResult cancelResult = new JavaScriptSerializer().Deserialize<PoloniexCancelResult>(result);
            if (cancelResult.success == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            */
            return false;
        }
        public static async Task<PoloniexNewOrderResult> setSell(string symbol, string market, Decimal rate, Decimal amount, PoloniexOrderOption option = PoloniexOrderOption.None) //You may optionally set "fillOrKill", "immediateOrCancel", "postOnly" to 1.
        {
            try
            {
                string url = "https://poloniex.com/tradingApi";
                string param = "command=sell&currencyPair=" + market + "_" + symbol + "&rate=" + rate + "&amount=" + amount + "&nonce=" + ExchangeManager.GetNonce();

                if (option != PoloniexOrderOption.None)
                {
                    param += "&" + option + "=1";
                }
                //LogManager.AddDebugMessage(thisClassName, "setSell", "option=" + option + " | " + param);
                string result = await getPrivateApiRequestAsync(url, param);
                //LogManager.AddDebugMessage(thisClassName, "setSell", "result=" + result);
                //return new JavaScriptSerializer().Deserialize<PoloniexNewOrderResult>(result);
                return null;
            }
            catch (Exception ex)
            {
                LogManager.AddDebugMessage(thisClassName, "setSell", "EXCEPTION!!! : " + ex.Message);
                return null;
            }
        }
        #endregion
        #region API_PRIVATE_TBD
        // NOT IMPLEMENTED
        // moveOrder - Cancels an order and places a new one of the same type in a single atomic transaction
        // withdraw
        // returnFeeInfo - If you are enrolled in the maker-taker fee schedule, returns your current trading fees and trailing 30-day volume in BTC
        // returnAvailableAccountBalances - Returns your balances sorted by account
        // returnTradableBalances - Returns your current tradable balances for each currency in each market for which margin trading is enabled
        // transferBalance - Transfers funds from one account to another (e.g. from your exchange account to your margin account)
        // returnMarginAccountSummary - Returns a summary of your entire margin account
        // marginBuy
        // marginSell
        // getMarginPosition
        // closeMarginPosition
        // createLoanOffer
        // cancelLoanOffer
        // returnOpenLoanOffers
        // returnActiveLoans
        // returnLendingHistory
        // toggleAutoRenew
        #endregion
        #endregion API_Private

        #region DataModels
        #region DATAMODELS_Enumerables  
        public enum PoloniexChartPeriod : Int32
        {
            // 300, 900, 1800, 7200, 14400, and 86400 - candlestick period in seconds
            None = 0,
            Minutes_5 = 300,
            Minutes_15 = 900,
            Minutes_30 = 1800,
            Hours_2 = 7200,
            Hours_4 = 14400,
            Hours_24 = 86400
        };
        public enum PoloniexOrderOption : Int32
        {
            //You may optionally set "fillOrKill", "immediateOrCancel", "postOnly" to 1.   
            [Description("Normal Order")]
            None = 0,
            [Description("A fill-or-kill order will either fill in its entirety or be completely aborted.")]
            fillOrKill = 1,
            [Description("An immediate-or-cancel order can be partially or completely filled, but any portion of the order that cannot be filled immediately will be canceled rather than left on the order book.")]
            immediateOrCancel = 2,
            [Description("A post-only order will only be placed if no portion of it fills immediately; this guarantees you will never pay the taker fee on any part of the order that fills.")]
            postOnly = 3
        };
        #endregion
        #region DATAMODELS_Public
        public class PoloniexChartData
        {
            //public Double date { get; set; }
            public long date { get; set; }

            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeSeconds(date).UtcDateTime.ToLocalTime();
                }
                /*
                set
                {

                }
                */
            }

            public double high { get; set; }
            public double low { get; set; }
            public double open { get; set; }
            public double close { get; set; }
            public double volume { get; set; }
            public double quoteVolume { get; set; }
            public double weightedAverage { get; set; }
        }
        public class PoloniexCurrency
        {
            public string symbol { get; set; }

            public int id { get; set; }
            public string name { get; set; }
            public string txFee { get; set; }
            public int minConf { get; set; }
            public object depositAddress { get; set; }
            public int disabled { get; set; }
            public int delisted { get; set; }
            public int frozen { get; set; }
        }
        public class PoloniexLoanOrder
        {
            public string rate { get; set; }
            public string amount { get; set; }
            public int rangeMin { get; set; }
            public int rangeMax { get; set; }
            // ADDON
            public string symbol { get; set; }
            public string type { get; set; }
        }
        public class PoloniexOrderBookData
        {
            public Decimal rate { get; set; }
            public Decimal quantity { get; set; }
        }
        public class PoloniexOrderBookItem
        {
            public List<List<object>> asks { get; set; }
            public List<List<object>> bids { get; set; }

            public string isFrozen { get; set; }
            public int seq { get; set; }
            // ADDON
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
        }
        public class PoloniexTicker
        {
            public int id { get; set; }
            public string pair { get; set; }
            public Decimal last { get; set; }
            public Decimal lowestAsk { get; set; }
            public Decimal highestBid { get; set; }
            public Decimal percentChange { get; set; }
            public Decimal baseVolume { get; set; }
            public Decimal quoteVolume { get; set; }
            public int isFrozen { get; set; }
            public Decimal high24hr { get; set; }
            public Decimal low24hr { get; set; }
        }
        public class Poloniex24hVolume
        {
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }

            public Decimal symbolVolume { get; set; }
            public Decimal marketVolume { get; set; }
        }
        #endregion
        #region DATAMODELS_Private
        public class PoloniexBalance
        {
            public string symbol { get; set; }
            public Decimal available { get; set; }
            public Decimal onOrders { get; set; }
            public Decimal btcValue { get; set; }
            // ADDON DATA
            public Decimal totalBTC { get; set; }
            public Decimal totalUSD { get; set; }
        }
        public class PoloniexCancelResult
        {
            public int success { get; set; }
        }
        public class PoloniexOpenOrder
        {
            public string orderNumber { get; set; }
            public string type { get; set; }
            public Double rate { get; set; }
            public Double startingAmount { get; set; }
            public Double amount { get; set; }
            public Double total { get; set; }
            public DateTime date { get; set; }
            public int margin { get; set; }
            // ADDON
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
        }
        public class PoloniexResultingTrade
        {
            public string amount { get; set; }
            public string date { get; set; }
            public string rate { get; set; }
            public string total { get; set; }
            public string tradeID { get; set; }
            public string type { get; set; }
        }
        public class PoloniexNewOrderResult
        {
            public long orderNumber { get; set; }
            public List<PoloniexResultingTrade> resultingTrades { get; set; }
        }
        public class PoloniexTradeHistory
        {
            public string globalTradeID { get; set; }
            public string tradeID { get; set; }
            public DateTime date { get; set; }
            public Double rate { get; set; }
            public Double amount { get; set; }
            public Double total { get; set; }
            public Double fee { get; set; }
            public string orderNumber { get; set; }
            public string type { get; set; }
            public string category { get; set; }
            public string currencyPair { get; set; }
            // ADDON
            public string pair { get; set; }
            public string symbol { get; set; }
            public string market { get; set; }
        }
        public class PoloniexWallet
        {
            public string symbol { get; set; }
            public string address { get; set; }
        }
        public class PoloniexTransaction
        {
            public string type { get; set; } // deposit or withdraw
                                             // DEPOSIT
            public string currency { get; set; }
            public string address { get; set; }
            public Double amount { get; set; }
            public int confirmations { get; set; }
            public string txid { get; set; }
            public long timestamp { get; set; }
            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime.ToLocalTime();
                }
            }
            public string status { get; set; }
            // WITHDRAWAL
            public int withdrawalNumber { get; set; }
            public Double fee { get; set; }
            public string ipAddress { get; set; }
        }
        public class PoloniexDeposit
        {
            public string currency { get; set; }
            public string address { get; set; }
            public Double amount { get; set; }
            public int confirmations { get; set; }
            public string txid { get; set; }
            public long timestamp { get; set; }
            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime.ToLocalTime();
                }
                /*
                set
                {

                }
                */
            }
            public string status { get; set; }
        }
        public class PoloniexWithdrawal
        {
            public int withdrawalNumber { get; set; }
            public string currency { get; set; }
            public string address { get; set; }
            public Double amount { get; set; }
            public Double fee { get; set; }
            public long timestamp { get; set; }
            public DateTime datetime
            {
                get
                {
                    return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime.ToLocalTime();
                }
                /*
                set
                {

                }
                */
            }
            public string status { get; set; }
            public string ipAddress { get; set; }
        }
        #endregion
        #endregion DataModels
    }
}
