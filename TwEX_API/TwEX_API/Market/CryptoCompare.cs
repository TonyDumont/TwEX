using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace TwEX_API.Market
{
    class CryptoCompare
    {
        #region Properties
        public static String thisClassName = "CryptoCompare";
        //public static string ApiKey = String.Empty;
        //public static string ApiSecret = String.Empty;
        private static RestClient client = new RestClient("https://www.cryptocompare.com");
        #endregion Properties

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
                var request = new RestRequest("/api/data/coinlist/", Method.GET);
                var response = client.Execute(request);
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
                    LogManager.AddLogMessage(thisClassName, "getCoinList", "success IS FALSE : message=" + result.Message + " | Type=" + result.Type, LogManager.LogMessageType.DEBUG);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(thisClassName, "getCoinList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
            return list;
        }
        #endregion API_Public

        #region DataModels
        #region DATAMODELS_Enums
        // ENUMS
        #endregion
        #region DATAMODELS_Public 
        // PUBLIC MODELS
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
            public string FullyPremined { get; set; }
            /// <summary><para></para></summary>
            public string TotalCoinSupply { get; set; }
            /// <summary><para></para></summary>
            public string PreMinedValue { get; set; }
            /// <summary><para></para></summary>
            public string TotalCoinsFreeFloat { get; set; }
            /// <summary>The order we rank the coin inside our internal system<para>int</para></summary>
            public string SortOrder { get; set; }
            /// <summary><para></para></summary>
            public bool Sponsored { get; set; }
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
        #endregion
        #region DATAMODELS_Private
        // PRIVATE MODELS
        #endregion
        #endregion DataModels
    }
}