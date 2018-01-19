using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace TwEX_API.Market
{
    public class CoinMarketCap
    {
        #region Properties
        public static String Name = "CoinMarketCap";
        private static RestClient client = new RestClient("https://api.coinmarketcap.com");
        public static BlockingCollection<CoinMarketCapTicker> Tickers = new BlockingCollection<CoinMarketCapTicker>();
        //public static string IconUrl { get; } = "https://coinmarketcap.com/favicon.ico";
        public static string IconUrl { get; } = "https://images-na.ssl-images-amazon.com/images/I/61G3KF2yniL.png";
        #endregion Properties

        #region API_Public
        /// <summary>/global/
        /// <para>Return the global data for active markets</para>
        /// <para>Required : none</para>
        /// <para>Optional : [NOT IN USE] convert - return price, 24h volume, and market cap in terms of another currency. Valid values are: 'AUD', 'BRL', 'CAD', 'CHF', 'CLP', 'CNY', 'CZK', 'DKK', 'EUR', 'GBP', 'HKD', 'HUF', 'IDR', 'ILS', 'INR', 'JPY', 'KRW', 'MXN', 'MYR', 'NOK', 'NZD', 'PHP', 'PKR', 'PLN', 'RUB', 'SEK', 'SGD', 'THB', 'TRY', 'TWD', 'ZAR'</para>
        /// </summary>
        public static CoinMarketCapGlobalData getGlobalData()
        {
            try
            {
                var request = new RestRequest("/v1/global/", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getGlobalData", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<CoinMarketCapGlobalData>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getGlobalData", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }
        /// <summary>/ticker/{id}/
        /// <para>Return a tickers based on the id (ex. bitcoin)</para>
        /// <para>Required : none</para>
        /// <para>Optional : [NOT IN USE] convert - return price, 24h volume, and market cap in terms of another currency. Valid values are: 'AUD', 'BRL', 'CAD', 'CHF', 'CLP', 'CNY', 'CZK', 'DKK', 'EUR', 'GBP', 'HKD', 'HUF', 'IDR', 'ILS', 'INR', 'JPY', 'KRW', 'MXN', 'MYR', 'NOK', 'NZD', 'PHP', 'PKR', 'PLN', 'RUB', 'SEK', 'SGD', 'THB', 'TRY', 'TWD', 'ZAR'</para>
        /// </summary>
        public static CoinMarketCapTicker getTicker(string id)
        {
            try
            {
                var request = new RestRequest("/v1/ticker/" + id, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getTicker", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var jsonArray = JsonConvert.DeserializeObject<List<CoinMarketCapTicker>>(response.Content, settings);
                CoinMarketCapTicker ticker = jsonArray[0] as CoinMarketCapTicker;
                return ticker;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTicker", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }
        /// <summary>/ticker/
        /// <para>Return the list of tickers</para>
        /// <para>Required : none</para>
        /// <para>Optional : start - return results from rank [start] and above (default=1)</para>
        /// <para>Optional : limit - return a maximum of [limit] results (default is 100, use 0 to return all results)</para>
        /// <para>Optional : [NOT IN USE] convert - return price, 24h volume, and market cap in terms of another currency. Valid values are: 'AUD', 'BRL', 'CAD', 'CHF', 'CLP', 'CNY', 'CZK', 'DKK', 'EUR', 'GBP', 'HKD', 'HUF', 'IDR', 'ILS', 'INR', 'JPY', 'KRW', 'MXN', 'MYR', 'NOK', 'NZD', 'PHP', 'PKR', 'PLN', 'RUB', 'SEK', 'SGD', 'THB', 'TRY', 'TWD', 'ZAR'</para>
        /// </summary>
        
        public static List<CoinMarketCapTicker> getTickerList(int start=0, int limit=100)
        {
            List<CoinMarketCapTicker> list = new List<CoinMarketCapTicker>();
            try
            {
                var request = new RestRequest("/v1/ticker/?start=" + start + "&limit=" + limit, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getTickerList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                
                var jsonArray = JsonConvert.DeserializeObject<List<CoinMarketCapTicker>>(response.Content, settings);
                //var jsonArray = JsonConvert.DeserializeObject<List<CoinMarketCapTicker>>(response.Content);
                list = jsonArray.ToList();
                
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getTickerList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        
        #endregion API_Public

        public static Decimal GetMarketCapBTCAmount(string symbol, Decimal amount)
        {
            if (symbol.ToUpper() != "BTC")
            {
                Decimal value = 0;

                CoinMarketCapTicker listItem = Tickers.FirstOrDefault(item => item.symbol.ToLower() == symbol.ToLower());

                if (listItem != null)
                {
                    //LogManager.AddLogMessage(Name, "GetMarketCapBTCAmount", "PRICE_BTC=" + listItem.price_btc + " | " + symbol, LogManager.LogMessageType.DEBUG);
                    value = amount * listItem.price_btc;
                }
                else
                {
                    //LogManager.AddLogMessage(Name, "GetMarketCapBTCAmount", "IS NULL : symbol=" + symbol + " |amount=" + amount + " |tCount=" + Tickers.Count, LogManager.LogMessageType.DEBUG);
                }
                //LogManager.AddLogMessage(Name, "GetMarketCapBTCAmount", "symbol=" + symbol + " |amount=" + amount + " |value=" + value, LogManager.LogMessageType.DEBUG);
                return value;
            }
            else
            {

                return amount;
            }
        }
        public static Decimal GetMarketCapUSDAmount(string symbol, Decimal amount)
        {
            Decimal value = 0;

            CoinMarketCapTicker listItem = Tickers.FirstOrDefault(item => item.symbol.ToLower() == symbol.ToLower());

            if (listItem != null)
            {
                //LogManager.AddLogMessage(Name, "GetMarketCapUSDAmount", "PRICE_USD=" + listItem.price_usd + " | " + symbol, LogManager.LogMessageType.DEBUG);
                value = amount * listItem.price_usd;
            }
            //LogManager.AddLogMessage(Name, "GetMarketCapUSDAmount", "symbol=" + symbol + " |amount=" + amount + " |value=" + value, LogManager.LogMessageType.DEBUG);
            return value;
        }

        #region ExchangeManager
        public static Decimal getUSDValue(string symbol, Decimal value = 0)
        {
            CoinMarketCapTicker ticker = Tickers.FirstOrDefault(item => item.symbol == symbol);
            /*
            foreach(CoinMarketCapTicker t in Tickers)
            {
                LogManager.AddLogMessage(Name, "getUSDValue", t.rank + " | " + t.price_usd + " | " + t.symbol);
            }
            */
            //LogManager.AddLogMessage(Name, "getUSDValue", Tickers.Count + " | " + symbol + " | " + value + " | ");
            if (ticker != null)
            {
                if (value > 0)
                {
                    // figure out the value in USD
                    //Decimal total = value * 
                    return value * ticker.price_usd;
                }
                else
                {
                    return ticker.price_usd;
                }
            }
            else
            {
                return 0;
            }
        }
        
        public static void updateTickers()
        {
            //LogManager.AddLogMessage(Name, "updateTickers", "UPDATING", LogManager.LogMessageType.OTHER);
            List<CoinMarketCapTicker> tickers = getTickerList(0, 5000);
            if (tickers.Count > 0)
            {
                Tickers = new BlockingCollection<CoinMarketCapTicker>(new ConcurrentQueue<CoinMarketCapTicker>(getTickerList(0, 5000)));
                //PreferenceManager.preferences.CoinMarketCapTickers = tickers;
                //PreferenceManager.UpdatePreferencesFile();
                
            }
        }
        
        #endregion ExchangeManager

        #region DataModels
        public class CoinMarketCapGlobalData
        {
            public double total_market_cap_usd { get; set; }
            public double total_24h_volume_usd { get; set; }
            public double bitcoin_percentage_of_market_cap { get; set; }
            public int active_currencies { get; set; }
            public int active_assets { get; set; }
            public int active_markets { get; set; }
            public int last_updated { get; set; }
        }
        public class CoinMarketCapTicker
        {
            public string id { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
            public int rank { get; set; }
            public Decimal price_usd { get; set; }
            public Decimal price_btc { get; set; }

            //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            [JsonProperty("24h_volume_usd")]
            public Decimal volume_24h { get; set; }

            public Decimal market_cap_usd { get; set; }
            public Decimal available_supply { get; set; }
            public Decimal total_supply { get; set; }


            public Decimal percent_change_1h { get; set; }

            //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal percent_change_24h { get; set; }

            //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Decimal percent_change_7d { get; set; }

            public string last_updated { get; set; }
        }
        #endregion DataModels
    }
}