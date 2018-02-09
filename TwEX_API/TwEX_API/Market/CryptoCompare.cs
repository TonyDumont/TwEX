using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TwEX_API.Market
{
    public class CryptoCompare
    {
        #region Properties
        public static String Name = "CryptoCompare";
        private static RestClient client = new RestClient("https://min-api.cryptocompare.com");
        // COLLECTIONS
        //public static List<CryptoCompareCoin> CoinList = new List<CryptoCompareCoin>();
        #endregion Properties

        #region Initialize
        public static void Initialize()
        {
            PreferenceManager.CryptoComparePreferences.CoinList = getCoinList();
        }
        #endregion

        #region API_Public
        /// <summary>CoinList
        /// <para>Get general info for all the coins available on the website.</para>
        /// <para>Required : none</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<CryptoCompareCoin> getCoinList()
        {
            List<CryptoCompareCoin> list = new List<CryptoCompareCoin>();
            try
            {
                RestClient tclient = new RestClient("https://www.cryptocompare.com");
                var request = new RestRequest("/api/data/coinlist/", Method.GET);
                //var request = new RestRequest("/data/coinlist/", Method.GET);
                var response = tclient.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getCoinList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                CryptoCompareResult result = jsonObject.ToObject<CryptoCompareResult>();
                if (result.Response.ToLower() == "success")
                {
                    //LogManager.AddLogMessage(thisClassName, "getCoinList", "success : " + jsonObject["Data"].ToString(), LogManager.LogMessageType.DEBUG);
                    var data = JObject.Parse(jsonObject["Data"].ToString());

                    foreach (var item in data)
                    {
                        CryptoCompareCoin coin = data[item.Key].ToObject<CryptoCompareCoin>();
                        list.Add(coin);
                    }
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getCoinList", "success IS FALSE : message=" + result.Message + " | Type=" + result.Type, LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCoinList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        
        /// <summary>Price
        /// <para>Get the latest price for a list of one or more currencies. Really fast, 20-60 ms. Cached each 10 seconds.</para>
        /// <para>Documentation at https://min-api.cryptocompare.com/</para>
        /// <para>Required : fsym - string From Symbol</para>
        /// <para>Required : tsyms - string[] To Symbols, include multiple symbols</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<CryptoComparePrice> getPriceList(string fsym, string[] tsyms)
        {
            List<CryptoComparePrice> list = new List<CryptoComparePrice>();
            try
            {
                string markets = string.Join(",", tsyms);
                var request = new RestRequest("/data/price?fsym=" + fsym + "&tsyms=" + markets, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getCoinList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);

                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(thisClassName, "getPriceList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                    CryptoComparePrice price = new CryptoComparePrice()
                    {
                        symbol = fsym,
                        market = item.Key,
                        value = Convert.ToDecimal(item.Value)
                    };
                    list.Add(price);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCoinList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>pricemulti
        /// <para>Get a matrix of currency prices..</para>
        /// <para>Documentation at https://min-api.cryptocompare.com/</para>
        /// <para>Required : fsym - string[] From Symbol, include multiple symbols</para>
        /// <para>Required : tsyms - string[] To Symbols, include multiple symbols</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<CryptoComparePrice> getPriceMultiList(string[] fsyms, string[] tsyms)
        {
            List<CryptoComparePrice> list = new List<CryptoComparePrice>();
            try
            {
                string symbols = string.Join(",", fsyms);
                string markets = string.Join(",", tsyms);
                var request = new RestRequest("/data/pricemulti?fsyms=" + symbols + "&tsyms=" + markets, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getPriceMultiList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);

                foreach (var item in jsonObject)
                {
                    //LogManager.AddLogMessage(thisClassName, "getPriceMultiList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                    var dataObject = JObject.Parse(jsonObject[item.Key].ToString());
                    foreach (var child in dataObject)
                    {
                        //LogManager.AddLogMessage(thisClassName, "getPriceMultiList", child.Key + " | " + child.Value, LogManager.LogMessageType.DEBUG);
                        CryptoComparePrice price = new CryptoComparePrice()
                        {
                            symbol = item.Key,
                            market = child.Key,
                            value = Convert.ToDecimal(child.Value)
                        };
                        list.Add(price);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getPriceMultiList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>pricemultifull
        /// <para>Get all the current trading info (price, vol, open, high, low etc) of any list of cryptocurrencies in any other currency that you need.</para>
        /// <para>If the crypto does not trade directly into the toSymbol requested, BTC will be used for conversion.</para>
        /// <para>This API also returns Display values for all the fields.If the opposite pair trades we invert it (eg.: BTC-XMR).</para>
        /// <para>Required : fsyms - string[] From Symbol, include multiple symbols</para>
        /// <para>Required : tsyms - string[] To Symbols, include multiple symbols</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static List<CryptoComparePriceFull> getPriceMultiFullList(string[] fsyms, string[] tsyms)
        {
            List<CryptoComparePriceFull> list = new List<CryptoComparePriceFull>();
            try
            {
                string symbols = string.Join(",", fsyms);
                string markets = string.Join(",", tsyms);
                var request = new RestRequest("/data/pricemultifull?fsyms=" + symbols + "&tsyms=" + markets, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getPriceMultiFullList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                var dataObject = JObject.Parse(jsonObject["RAW"].ToString());
                foreach (var item in dataObject)
                {
                    //LogManager.AddLogMessage(thisClassName, "getPriceMultiFullList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                    var priceObject = JObject.Parse(jsonObject["RAW"][item.Key].ToString());
                    foreach (var priceData in priceObject)
                    {
                        //LogManager.AddLogMessage(thisClassName, "getPriceMultiFullList", priceData.Key + " | " + priceData.Value, LogManager.LogMessageType.DEBUG);
                        CryptoComparePriceFull price = priceObject[priceData.Key].ToObject<CryptoComparePriceFull>();
                        //LogManager.AddLogMessage(thisClassName, "getPriceMultiFullList", price.FROMSYMBOL + " | " + price.TOSYMBOL, LogManager.LogMessageType.DEBUG);
                        list.Add(price);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getPriceMultiFullList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        // generateAvg - NEED TO KNOW WHERE LIST OF EXCHANGES CAN BE RETRIEVED

        /// <summary>dayAvg
        /// <para>Get day average price. The values are based on hourly vwap data and the average can be calculated in different waysIt uses BTC conversion if data is not available because the coin is not trading in the specified currency.</para>
        /// <para>If tryConversion is set to false it will give you the direct data.</para>
        /// <para>If no toTS is given it will automatically do the current day. Also for different timezones use the UTCHourDiff paramThe calculation types are: HourVWAP - a VWAP of the hourly close price,MidHighLow - the average between the 24 H high and low.</para>
        /// <para>VolFVolT - the total volume from / the total volume to (only avilable with tryConversion set to false so only for direct trades but the value should be the most accurate price)</para>
        /// <para>Required : fsym - string From Symbol</para>
        /// <para>Required : tsyms - string[] To Symbols, include multiple symbols</para>
        /// <para>Optional : avgType - string (default:HourVWAP) - NEED TO FIND TYPES FOR THIS</para>
        /// <para>Optional : UTCHourDiff - int (default:0)</para>
        /// <para>Optional : toTs - hour unit - timestamp (default:0)</para>
        /// </summary>
        public static Decimal getDayAverage(string fsym, string tsym, int UTCHourDiff=0)
        {
            try
            {
                var request = new RestRequest("/data/dayAvg?fsym=" + fsym.ToUpper() + 
                    "&tsym=" + tsym.ToUpper() +
                    "&UTCHourDiff=" + UTCHourDiff
                    , Method.GET);
                var response = client.Execute(request);
                LogManager.AddLogMessage(Name, "getDayAverage", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                return Convert.ToDecimal(jsonObject[tsym.ToUpper()]);
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getDayAverage", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return 0;
            }
        }

        /// <summary>PriceHistorical
        /// <para>Get the price of any cryptocurrency in any other currency that you need at a given timestamp.</para>
        /// <para>The price comes from the daily info - so it would be the price at the end of the day GMT based on the requested TS.</para>
        /// <para>If the crypto does not trade directly into the toSymbol requested, BTC will be used for conversion.</para>
        /// <para>Tries to get direct trading pair data, if there is none or it is more than 30 days before the ts requested, it uses BTC conversion.</para>
        /// <para>If the opposite pair trades we invert it (eg.: BTC-XMR)</para>
        /// <para>Required : fsym - string From Symbol</para>
        /// <para>Required : tsyms - string[] To Symbols, include multiple symbols</para>
        /// <para>Optional : ts - timestamp</para>
        /// </summary>
        public static List<CryptoComparePrice> getPriceHistoricalList(string fsym, string[] tsyms)
        {
            List<CryptoComparePrice> list = new List<CryptoComparePrice>();
            try
            {
                string markets = string.Join(",", tsyms).ToUpper();
                string symbol = fsym.ToUpper();
                var request = new RestRequest("/data/pricehistorical?fsym=" + symbol + "&tsyms=" + markets, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(thisClassName, "getPriceHistoricalList", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                var dataObject = JObject.Parse(jsonObject[fsym.ToUpper()].ToString());
                foreach (var item in dataObject)
                {
                    //LogManager.AddLogMessage(thisClassName, "getPriceHistoricalList", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                    CryptoComparePrice price = new CryptoComparePrice()
                    {
                        symbol = symbol,
                        market = item.Key.ToUpper(),
                        value = Convert.ToDecimal(item.Value)
                    };
                    list.Add(price);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getPriceHistoricalList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }

        /// <summary>CoinSnapshot
        /// <para>Get data for a currency pair. It returns general block explorer information, aggregated data and individual data for each exchange available.</para>
        /// <para>This api is getting abused and will be moved to a min-api path in the near future. Please try not to use it.</para>
        /// <para>Required : The symbol of the currency you want to get that for</para>
        /// <para>Required : tsym - The symbol of the currency that data will be in.</para>
        /// <para>Optional : none</para>
        /// </summary>
        public static CryptoCompareCoinSnapshot getCoinSnapshot(string fsym, string tsym)
        {
            try
            {
                RestClient tclient = new RestClient("https://www.cryptocompare.com");
                var request = new RestRequest("/api/data/coinsnapshot/?fsym=" + fsym.ToUpper() + "&tsym=" + tsym.ToUpper(), Method.GET);
                var response = tclient.Execute(request);
                LogManager.AddLogMessage(Name, "getCoinSnapshot", "response.Content=" + response.Content, LogManager.LogMessageType.DEBUG);
                var jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<CryptoCompareCoinSnapshot>();
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getDayAverage", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }
        #endregion API_Public

        // TO BE DEVELOPED
        // CoinSnapshotFullById

        // SocialStats

        // HistoMinute

        // HistoHour

        // HistoDay

        // MiningContracts

        // MiningEquipment

        // TopPairs

        #region DataModels
        public class CryptoCompareChartTheme
        {
            public CryptoCompareTheme_General General { get; set; } = new CryptoCompareTheme_General();
            public CryptoCompareTheme_Header Header { get; set; } = new CryptoCompareTheme_Header();
            public CryptoCompareTheme_Followers Followers { get; set; } = new CryptoCompareTheme_Followers();
            public CryptoCompareTheme_Data Data { get; set; } = new CryptoCompareTheme_Data();
            public CryptoCompareTheme_Chart Chart { get; set; } = new CryptoCompareTheme_Chart();
            public CryptoCompareTheme_Trend Trend { get; set; } = new CryptoCompareTheme_Trend();
            public CryptoCompareTheme_Conversion Conversion { get; set; } = new CryptoCompareTheme_Conversion();
        }
        // THEME CATEGORIES
        public class CryptoCompareTheme_General
        {
            public string background { get; set; } = "#FFF";
            public string borderWidth { get; set; } = "1px";
            public string borderColor { get; set; } = "#e0e6ef";
            public string borderRadius { get; set; } = "4px";
        }
        public class CryptoCompareTheme_Header
        {
            public string background { get; set; } = "#f6f9fb";
            public string color { get; set; } = "#000";
            public bool displayFollowers { get; set; } = true;
        }
        public class CryptoCompareTheme_Followers
        {
            public string background { get; set; } = "#FFF";
            public string color { get; set; } = "#337ab7";
            public string borderColor { get; set; } = "#EEE";
            public string counterBorderColor { get; set; } = "#EEE";
            public string counterColor { get; set; } = "#999";
        }
        public class CryptoCompareTheme_Data
        {
            public string priceColor { get; set; } = "#000";
            public string infoLabelColor { get; set; } = "#333";
            public string infoValueColor { get; set; } = "#333";
        }
        public class CryptoCompareTheme_Chart
        {
            public bool animation { get; set; } = false;
            public string fillColor { get; set; } = "rgba(151,187,205,0.2)";
            public string borderColor { get; set; } = "#444";
        }
        public class CryptoCompareTheme_Trend
        {
            public string colorUp { get; set; } = "#3d9400";
            public string colorDown { get; set; } = "#A11B0A";
            public string colorUnchanged { get; set; } = "#2C4C76";
        }
        public class CryptoCompareTheme_Conversion
        {
            public string background { get; set; } = "transparent";
            public string lineHeight { get; set; } = "20px";
            public string color { get; set; } = "#000";
        }       
        // MISC
        public class CryptoCompareCoin
        {
            /// <summary>The internal id, this is used in other calls<para>int</para></summary>
            public string Id { get; set; }
            /// <summary>The url of the coin on cryptocompare<para>string</para></summary>
            public string Url { get; set; }
            /// <summary>The logo image of the coin<para>string</para></summary>
            public string ImageUrl { get; set; }
            /// <summary>The name<para>string</para></summary>
            public string Name { get; set; }
            /// <summary>The symbol<para>string</para></summary>
            public string Symbol { get; set; }
            /// <summary>The Coin Name<para>string</para></summary>
            public string CoinName { get; set; }
            /// <summary>A combination of the name and the symbol<para>string<para>string</para></summary>
            public string FullName { get; set; }
            /// <summary>The algorithm of the cryptocurrency<para>string</para></summary>
            public string Algorithm { get; set; }
            /// <summary>The proof type of the cryptocurrency<para>string</para></summary>
            public string ProofType { get; set; }
            /// <summary><para></para></summary>
            public int FullyPremined { get; set; }
            /// <summary><para></para></summary>
            public string TotalCoinSupply { get; set; }
            /// <summary><para></para></summary>
            public string PreMinedValue { get; set; }
            /// <summary><para></para></summary>
            public string TotalCoinsFreeFloat { get; set; }
            /// <summary>The order we rank the coin inside our internal system<para>int</para></summary>
            public int SortOrder { get; set; }
            /// <summary><para></para></summary>
            public bool Sponsored { get; set; }
        }
        public class CryptoCompareCoinSnapshot
        {
            public string Response { get; set; }
            public string Message { get; set; }
            public CryptoCompareCoinSnapshotData Data { get; set; }
            public int Type { get; set; }
        }
        public class CryptoCompareCoinSnapshotAggregatedData
        {
            public string TYPE { get; set; }
            public string MARKET { get; set; }
            public string FROMSYMBOL { get; set; }
            public string TOSYMBOL { get; set; }
            public string FLAGS { get; set; }
            public string PRICE { get; set; }
            public string LASTUPDATE { get; set; }
            public string LASTVOLUME { get; set; }
            public string LASTVOLUMETO { get; set; }
            public string LASTTRADEID { get; set; }
            public string VOLUMEDAY { get; set; }
            public string VOLUMEDAYTO { get; set; }
            public string VOLUME24HOUR { get; set; }
            public string VOLUME24HOURTO { get; set; }
            public string OPENDAY { get; set; }
            public string HIGHDAY { get; set; }
            public string LOWDAY { get; set; }
            public string OPEN24HOUR { get; set; }
            public string HIGH24HOUR { get; set; }
            public string LOW24HOUR { get; set; }
            public string LASTMARKET { get; set; }
        }
        public class CryptoCompareCoinSnapshotData
        {
            public string Algorithm { get; set; }
            public string ProofType { get; set; }
            public int BlockNumber { get; set; }
            public double NetHashesPerSecond { get; set; }
            public double TotalCoinsMined { get; set; }
            public double BlockReward { get; set; }
            public CryptoCompareCoinSnapshotAggregatedData AggregatedData { get; set; }
            public List<CryptoCompareExchange> Exchanges { get; set; }
        }
        public class CryptoCompareExchange
        {
            public string TYPE { get; set; }
            public string MARKET { get; set; }
            public string FROMSYMBOL { get; set; }
            public string TOSYMBOL { get; set; }
            public string FLAGS { get; set; }
            public string PRICE { get; set; }
            public string LASTUPDATE { get; set; }
            public string LASTVOLUME { get; set; }
            public string LASTVOLUMETO { get; set; }
            public string LASTTRADEID { get; set; }
            public string VOLUME24HOUR { get; set; }
            public string VOLUME24HOURTO { get; set; }
            public string OPEN24HOUR { get; set; }
            public string HIGH24HOUR { get; set; }
            public string LOW24HOUR { get; set; }
        }
        public class CryptoComparePrice
        {
            /// <summary>The Symbol<para>string</para></summary>
            public string symbol { get; set; }
            /// <summary>The Market<para>string</para></summary>
            public string market { get; set; }
            /// <summary>The Value of the symbol in the market<para>string</para></summary>
            public Decimal value { get; set; }
        }
        public class CryptoComparePriceFull
        {
            public string TYPE { get; set; }
            public string MARKET { get; set; }
            public string FROMSYMBOL { get; set; }
            public string TOSYMBOL { get; set; }
            public string FLAGS { get; set; }
            public double PRICE { get; set; }
            public int LASTUPDATE { get; set; }
            public double LASTVOLUME { get; set; }
            public double LASTVOLUMETO { get; set; }
            public string LASTTRADEID { get; set; }
            public double VOLUMEDAY { get; set; }
            public double VOLUMEDAYTO { get; set; }
            public double VOLUME24HOUR { get; set; }
            public double VOLUME24HOURTO { get; set; }
            public double OPENDAY { get; set; }
            public double HIGHDAY { get; set; }
            public double LOWDAY { get; set; }
            public double OPEN24HOUR { get; set; }
            public double HIGH24HOUR { get; set; }
            public double LOW24HOUR { get; set; }
            public string LASTMARKET { get; set; }
            public double CHANGE24HOUR { get; set; }
            public double CHANGEPCT24HOUR { get; set; }
            public double CHANGEDAY { get; set; }
            public double CHANGEPCTDAY { get; set; }
            public double SUPPLY { get; set; }
            public double MKTCAP { get; set; }
            public double TOTALVOLUME24H { get; set; }
            public double TOTALVOLUME24HTO { get; set; }
        }
        public class CryptoCompareResult
        {
            /// <summary>The type of the response (Success or Error)<para>string</para></summary>
            public string Response { get; set; }

            /// <summary>The message for the response<para>string</para></summary>
            public string Message { get; set; }

            /// <summary>The base url for all the images from the ImageUrl field<para>url</para></summary>
            public string BaseImageUrl { get; set; }

            /// <summary>The base url for all the links from the Url field<para>url</para></summary>
            public string BaseLinkUrl { get; set; }

            //public DefaultWatchlist DefaultWatchlist { get; set; }

            /// <summary>Empty if there is no data to return or there is an error<para>Object</para></summary>
            public Object Data { get; set; }

            /// <summary>Integer representing the type of response.<para>integar</para></summary>
            public int Type { get; set; }
        }
        #endregion DataModels

        #region Enums
        public enum CryptoCompareChartPeriod
        {
            [Description("1 Day")]
            Day_1D,
            [Description("1 Week")]
            Week_1W,
            [Description("2 Weeks")]
            Week_2W,
            [Description("1 Month")]
            Month_1M,
            [Description("3 Months")]
            Month_3M,
            [Description("6 Months")]
            Month_6M,
            [Description("1 Year")]
            Year_1Y
        }
        public enum CryptoCompareFeedType
        {
            CoinTelegraph,
            CryptoSource,
            EspacioBit,
            CoreMediaWaves,
            CoreMediaBlockchain,
            CoreMediaSupernet,
            DashPayMagazine,
            CoinJoker
        }
        public enum CryptoCompareWidgetType
        {
            [Description("symbol,market,period")]
            Chart,

            [Description("symbol,market,feedType")]
            NewsFeed,

            [Description("symbol,markets_25")]
            PricesList,

            [Description("symbol,markets_25")]
            PricesTiles,

            [Description("symbols_5,markets_5")]
            Tabbed,

            [Description("symbols_5,markets_5")]
            Horizontal,

            [Description("symbol,markets_25")]
            Summary,

            [Description("symbol,market")]
            Historical,

            [Description("symbol,markets_10")]
            ChartAdvanced,

            [Description("symbol,markets_25")]
            Converter,

            [Description("symbols_5,market_25")]
            HeaderV2,

            [Description("symbols_5,markets_5")]
            HeaderV3
        }
        #endregion
    }
}
/*
public class CryptoCompareChartTheme
{
    public class General
    {
        public string background { get; set; } = "#FFF";
        public string borderWidth { get; set; } = "1px";
        public string borderColor { get; set; } = "#e0e6ef";
        public string borderRadius { get; set; } = "4px";
    }
    public class Header
    {
        public string background { get; set; } = "#f6f9fb";
        public string color { get; set; } = "#000";
        public bool displayFollowers { get; set; } = true;
    }
    public class Followers
    {
        public string background { get; set; } = "#FFF";
        public string color { get; set; } = "#337ab7";
        public string borderColor { get; set; } = "#EEE";
        public string counterBorderColor { get; set; } = "#EEE";
        public string counterColor { get; set; } = "#999";
    }
    public class Data
    {
        public string priceColor { get; set; } = "#000";
        public string infoLabelColor { get; set; } = "#333";
        public string infoValueColor { get; set; } = "#333";
    }
    public class Chart
    {
        public bool animation { get; set; } = false;
        public string fillColor { get; set; } = "rgba(151,187,205,0.2)";
        public string borderColor { get; set; } = "#444";
    }
    public class Trend
    {
        public string colorUp { get; set; } = "#3d9400";
        public string colorDown { get; set; } = "#A11B0A";
        public string colorUnchanged { get; set; } = "#2C4C76";
    }
    public class Conversion
    {
        public string background { get; set; } = "transparent";
        public string lineHeight { get; set; } = "20px";
        public string color { get; set; } = "#000";
    }
}
*/