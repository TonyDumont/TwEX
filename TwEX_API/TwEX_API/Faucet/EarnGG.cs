using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using TwEX_API.Controls;

namespace TwEX_API.Faucet
{
    public class EarnGG
    {
        #region Properties
        private static string Name { get; } = "EarnGG";
        //public static string IconUrl { get; } = "https://earn.gg/img/favicon-32x32.png";
        public static EarnGGManagerControl earnGGManagerControl { get; set; }
        //public static List<EarnGGAccount> Accounts { get; set; } = new List<EarnGGAccount>();
        #endregion

        #region Getters
        public static EarnGGAccount GetAccount(string key, string secret)
        {
            try
            {
                RestClient client = new RestClient("https://api.earn.gg");
                var request = new RestRequest("/account/get?key=" + key + "&secret=" + secret, Method.GET);
                var response = client.Execute(request);
                //LogManager.AddLogMessage(Name, "UpdateEarnGGMachines", "Name=" + response.Content);
                var jsonObject = JObject.Parse(response.Content);
                EarnGGRootMessage message = jsonObject.ToObject<EarnGGRootMessage>();
                return message.result;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "GetAccount", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return null;
            }
        }
        #endregion

        #region Updaters
        public static void UpdateAccounts()
        {
            foreach(EarnGGAccount account in PreferenceManager.EarnGGPreferences.EarnGGAccounts)
            {
                EarnGGAccount data = GetAccount(account.api.key, account.api.secret);

                if (data != null)
                {
                    account.balance = data.balance;
                    account.frozen = data.frozen;
                    account.frozenAt = data.frozenAt;
                    account.frozenCount = data.frozenCount;
                    account.frozenReason = data.frozenReason;
                    account.lastLogin = data.lastLogin;
                    account.totalEarnings = data.totalEarnings;
                    account.totalWithdrew = data.totalWithdrew;
                }
            }
            UpdateUI();
        }
        public static void UpdateUI(bool resize = false)
        {
            if (earnGGManagerControl != null)
            {
                earnGGManagerControl.UpdateUI(resize);
            }
        }
        #endregion

        #region DataModels
        public class EarnGGAccount
        {
            public EarnGGApi api { get; set; } = new EarnGGApi();
            public string avatar { get; set; }
            public int badIPOffenses { get; set; }
            public int balance { get; set; }
            public string countryCode { get; set; }
            public DateTime createdAt { get; set; }
            public string createdIP { get; set; }
            public string email { get; set; }
            public bool firstIPCheck { get; set; }
            public bool frozen { get; set; }
            public DateTime frozenAt { get; set; }
            public int frozenCount { get; set; }
            public string frozenReason { get; set; }
            public string id { get; set; }
            public string isp { get; set; }
            public string lastIP { get; set; }
            public DateTime lastLogin { get; set; }
            public DateTime lastTrackedLead { get; set; }
            public string name { get; set; }
            public string provider { get; set; }
            public string providerId { get; set; }
            public int refCount { get; set; }
            public int refEarnings { get; set; }
            public bool refEarningsChanged { get; set; }
            public string refID { get; set; }
            public string refUnique { get; set; }
            public int referralEarnings { get; set; }
            //public EarnGGSeenHowTo seenHowTo { get; set; }
            //public EarnGGSettings settings { get; set; }
            public object steamid { get; set; }
            public int totalEarnings { get; set; }
            public int totalWithdrew { get; set; }
            public bool verified { get; set; }
            public string verifiedIP { get; set; }
            public double untrackedLeadsSum { get; set; }
            public string peanutCode { get; set; }
        }
        public class EarnGGApi
        {
            public string key { get; set; }
            public string secret { get; set; }
        }
        public class EarnGGSeenHowTo
        {
        }
        public class EarnGGSettings
        {
            public string theme { get; set; }
        }    
        public class EarnGGRootMessage
        {
            public EarnGGAccount result { get; set; }
        }
        #endregion
    }
}