using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace TwEX_API.Wallet
{
    class BlockCypher
    {
        #region Properties
        public static string Name { get; } = "BlockCypher";
        public static string Url { get; } = "https://www.blockcypher.com/";
        //public static string IconUrl { get; } = "https://www.blockcypher.com/images/favicon-192x192.png";
        //public static BlockIOApi Api { get; set; } = new BlockIOApi();
        private static RestClient client = new RestClient("https://api.blockcypher.com/v1");
        #endregion Properties

        /// <summary>Address Balance Endpoint
        /// <para>The Address Balance Endpoint is the simplest—and fastest—method to get a subset of information on a public address.</para>
        /// </summary>
        public static decimal getBalance(string symbol, string address)
        {
            try
            {
                var request = new RestRequest("/" + symbol.ToLower() + "/main/addrs/" + address + "/balance", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getTicker", "response.Content=" + response.Content, LogManager.LogMessageType.OTHER);
                var jsonObject = JObject.Parse(response.Content);
                AddressBalanceEndpoint balance = jsonObject.ToObject<AddressBalanceEndpoint>();
                Decimal value = 0;

                if (symbol != "ETH")
                {
                    value = balance.balance / 100000000;
                }
                else
                {
                    value = balance.balance / 1000000000000000000;
                }
                //LogManager.AddLogMessage(Name, "getTicker", "balance=" + balance.balance + " | " + symbol + " | " + value + " | " + address, LogManager.LogMessageType.OTHER);
                return value;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getBalance", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return 0;
            }
        }

        public class AddressBalanceEndpoint
        {
            public string address { get; set; }
            public Decimal total_received { get; set; }
            public Decimal total_sent { get; set; }
            public Decimal balance { get; set; }
            public Decimal unconfirmed_balance { get; set; }
            public Decimal final_balance { get; set; }
            public int n_tx { get; set; }
            public int unconfirmed_n_tx { get; set; }
            public int final_n_tx { get; set; }
        }
    }
}
