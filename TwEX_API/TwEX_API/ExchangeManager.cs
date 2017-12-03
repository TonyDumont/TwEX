using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace TwEX_API
{
    public class ExchangeManager
    {
        // GETTERS
        public static String GetNonce()
        {
            long ms = (long)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            return ms.ToString();
        }

        #region DataModels
        public class Exchange
        {
            public string SiteName { get; set; }
            public string Url { get; set; }
            //public string Symbol { get; set; }

            public string USDSymbol { get; set; }
        }
        #endregion DataModels
        
    }

}
