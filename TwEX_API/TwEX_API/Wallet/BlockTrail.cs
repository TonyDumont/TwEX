using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace TwEX_API.Wallet
{
    class BlockTrail
    {
        #region Properties
        public static string Name { get; } = "BlockTrail";
        public static string Url { get; } = "https://www.blocktrail.com";
        private static RestClient client = new RestClient("https://api.blocktrail.com/v1");
        #endregion Properties

        /// <summary>Address Balance Endpoint
        /// <para>The Address Balance Endpoint is the simplest—and fastest—method to get a subset of information on a public address.</para>
        /// </summary>
        public static decimal getBalance(string symbol, string address)
        {
            try
            {
                if (symbol.ToLower() == "bch")
                {
                    symbol = "bcc";
                }

                var request = new RestRequest("/" + symbol.ToLower() + "/address/" + address + "?api_key=5abc4df2c200059b0ad8ec828269c5670ee1e471", Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "getTicker", "response.Content=" + response.Content, LogManager.LogMessageType.OTHER);
                var jsonObject = JObject.Parse(response.Content);
                
                AddressBalanceEndpoint balance = jsonObject.ToObject<AddressBalanceEndpoint>();
                Decimal value = balance.balance / 100000000;
                //LogManager.AddLogMessage(Name, "getBalance", "balance=" + balance.balance + " | " + value + " | " + symbol, LogManager.LogMessageType.OTHER);
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
            public string hash160 { get; set; }
            public Decimal balance { get; set; }
            public int received { get; set; }
            public int sent { get; set; }
            public int transactions { get; set; }
            public int utxos { get; set; }
            public int unconfirmed_received { get; set; }
            public int unconfirmed_sent { get; set; }
            public int unconfirmed_transactions { get; set; }
            public int unconfirmed_utxos { get; set; }
            public int total_transactions_in { get; set; }
            public int total_transactions_out { get; set; }
            public object category { get; set; }
            public object tag { get; set; }
            public DateTime first_seen { get; set; }
            public DateTime last_seen { get; set; }
        }
    }
}
