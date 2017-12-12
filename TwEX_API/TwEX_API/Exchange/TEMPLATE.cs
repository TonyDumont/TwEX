using RestSharp;
using System;
using System.Collections.Generic;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Exchange
{
    class TEMPLATE // MAKE PUBLIC TO ACCESS
    {
        #region Properties
        // EXCHANGE MANAGER
        public static string Name { get; } = "TEMPLATE";
        public string Url { get; } = "https://TEMPLATE.com/";
        public string USDSymbol { get; } = "USD/USDT/EMPTY";

        // API
        public static string ApiKey { get; set; } = String.Empty;
        public static string ApiSecret { get; set; } = String.Empty;
        private static RestClient client = new RestClient("API_URL");
        #endregion Properties

        #region API_Public
        #region API_PUBLIC_Getters
        // PUBLIC GETTERS
        #endregion
        #endregion API_Public

        #region API_Private
        #region API_PRIVATE_Getters
        // ------------------------
        // PRIVATE AUTH UTILS
        // ------------------------
        // PRIVATE GETTERS
        #endregion
        #region API_PRIVATE_Setters
        // PRIVATE SETTERS
        #endregion
        #region API_PRIVATE_TBD
        // TO BE DEVELOPED
        #endregion
        #endregion API_Private

        #region ExchangeManager
        public static List<ExchangeTicker> getExchangeTickerList()
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();
            /*
            List<> tickerList = getTickerList();

            foreach (PoloniexTicker ticker in tickerList)
            {
                ExchangeTicker eTicker = new ExchangeTicker();
                eTicker.exchange = Name.ToUpper();

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
        #endregion ExchangeManager

        #region DataModels
        #region DATAMODELS_Enums
        // ENUMS
        #endregion
        #region DATAMODELS_Public 
        // PUBLIC MODELS
        #endregion
        #region DATAMODELS_Private
        // PRIVATE MODELS
        #endregion
        #endregion DataModels
    }
}