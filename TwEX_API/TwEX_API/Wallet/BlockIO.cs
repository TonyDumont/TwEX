using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace TwEX_API.Wallet
{
    class BlockIO
    {
        #region Properties
        public static string Name { get; } = "BlockIO";
        public static string Url { get; } = "https://block.io/";
        public static string IconUrl { get; } = "https://block.io/favicon.ico";
        public static BlockIOApi Api { get; set; } = new BlockIOApi();
        private static RestClient client = new RestClient("https://block.io/api/v2");
        #endregion Properties
        /*
        private string getApiKey(string symbol)
        {

        }
        */
        public static decimal getBalance(string key)
        {           
            try
            {
                var request = new RestRequest("/get_balance/?api_key=" + key, Method.GET);
                var response = client.Execute(request);

                //LogManager.AddLogMessage(Name, "getTicker", "response.Content=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                string status = jsonObject["status"].ToString().ToLower();

                if (status == "success")
                {
                    //BittrexTicker ticker = jsonObject["result"].ToObject<BittrexTicker>();
                    //return ticker;
                    BlockIOMessage message = jsonObject.ToObject<BlockIOMessage>();
                    return message.data.available_balance;
                }
                else
                {
                    LogManager.AddLogMessage(Name, "getBalance", "ERROR LOADING : SUCCESS false on key : " + key, LogManager.LogMessageType.OTHER);
                    //return null;
                    return 0;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalance", ex.Message, LogManager.LogMessageType.EXCEPTION);
                //return null;
                return 0;
            }          
        }
        
        #region DataModels
        public class BlockIOApi
        {
            public string BTC { get; set; }
            public string DOGE { get; set; }
            public string LTC { get; set; }
            public bool Active
            {
                get
                {
                    if (BTC.Length > 0 || DOGE.Length > 0 || LTC.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public class BlockIOData
        {
            public string network { get; set; }
            public Decimal available_balance { get; set; }
            public Decimal pending_received_balance { get; set; }
        }
        public class BlockIOMessage
        {
            public string status { get; set; }
            public BlockIOData data { get; set; }
        }
        #endregion
    }
}
