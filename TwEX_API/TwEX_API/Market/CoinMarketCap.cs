using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TwEX_API.Market
{
    class CoinMarketCap
    {
        #region Properties
        public static String thisClassName = "CoinMarketCap";
        private static RestClient client = new RestClient("https://api.coinmarketcap.com");
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
                LogManager.AddLogMessage(thisClassName, "getGlobalData", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                LogManager.AddLogMessage(thisClassName, "getTicker", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
        public static List<CoinMarketCapTicker> getTickerList(int start=1, int limit=100)
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
                list = jsonArray.ToList();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getTickerList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion API_Public

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

            [JsonProperty("24h_volume_usd")]
            public Decimal volume_24h { get; set; }

            public Decimal market_cap_usd { get; set; }
            public Decimal available_supply { get; set; }
            public Decimal total_supply { get; set; }

            public Decimal percent_change_1h { get; set; }
            public Decimal percent_change_24h { get; set; }
            public Decimal percent_change_7d { get; set; }
            public string last_updated { get; set; }
        }
        #endregion DataModels
    }
}