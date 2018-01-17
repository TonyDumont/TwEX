using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using TwEX_API.Controls;

namespace TwEX_API.Faucet
{
    public class EarnGG
    {
        #region Properties
        private static string Name { get; } = "EarnGG";
        public static string IconUrl { get; } = "https://earn.gg/img/favicon-32x32.png";
        public static EarnGGManagerControl earnGGManagerControl { get; set; }
        public static List<EarnGGAccount> Accounts { get; set; } = new List<EarnGGAccount>();
        #endregion

        #region Getters
        public static EarnGGAccount GetAccount(string key, string secret)
        {
            try
            {
                //LogManager.AddDebugMessage(thisClassName, "UpdateEarnGGMachines", "Name=" + machine.machineName + " | " + machine.key + " | " + machine.secret);
                RestClient client = new RestClient("https://api.earn.gg");
                var request = new RestRequest("/account/get?key=" + key + "&secret=" + secret, Method.GET);
                var response = client.Execute(request);
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
            foreach(EarnGGAccount account in Accounts)
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


/*
public static BindingList<EarnGGProfile> EarnGGAccountList = new BindingList<EarnGGProfile>()
{
    // PokerXchange@gmail.com
    new EarnGGProfile() { key="82164f20-33bc-46b7-b0f5-8b47bccafc7c", secret="f792bd40f03b79fe3a3a59f94a11682f",
        machines = new List<EarnGGMachine>() { new EarnGGMachine() { name="DELILAH", task="adscend" } },
        data = new EarnGGAccount() { email="PokerXchange@gmail.com" } },
    // friscoBTC@gmail.com
    new EarnGGProfile() { key="ef4e3e74-25d9-4114-9097-4fa8b51083a8", secret="b2350a08b1e1c5b1c1af8a34115006dd",
        machines = new List<EarnGGMachine>() { new EarnGGMachine() { name="FRISCO", task="adscend" } },
        data = new EarnGGAccount() { email="friscoBTC@gmail.com" } },
    // minionBTC@gmail.com
    new EarnGGProfile() { key="7ef0938c-0354-446e-a340-4df800514198", secret="a11d2249827fc24943d012e12f8aa851",
        machines = new List<EarnGGMachine>() { new EarnGGMachine() { name="MINION", task="adscend" } },
        data = new EarnGGAccount() { email="minionBTC@gmail.com" } },
    // delawareus@savethesmiles.org
    new EarnGGProfile() { key="043195d8-7b05-4a0f-b2bc-c42d5dba6909", secret="3de42851b04d07f50597b4a8be638414",
        machines = new List<EarnGGMachine>() { new EarnGGMachine() { name="PAVILION", task="adscend" } },
        data = new EarnGGAccount() { email="delawareus@savethesmiles.org" } },
    // tonyrdumont@gmail.com
    new EarnGGProfile() { key="d01ca321-f9d6-4947-b2fa-a539d1a2eda8", secret="aebf4ec96a95faad6475418563f8ba93",
        machines = new List<EarnGGMachine>() { new EarnGGMachine() { name="HERMES", task="adscend" } },
        data = new EarnGGAccount() { email="tonyrdumont@gmail.com" } },
    // l1lrascal@comcast.net
    new EarnGGProfile() { key="7628e127-320b-4ace-9653-dc6a53f03eb4", secret="217878c405242ef81a8d9eebc6c8fa40",
        machines = new List<EarnGGMachine>() { new EarnGGMachine() { name="ROVER", task="adscend" } },
        data = new EarnGGAccount() { email="l1lrascal@comcast.net" } },
    // grrinder@live.com
    new EarnGGProfile() { key="08afbd58-94ec-4b4e-91c4-4068d19b2691", secret="57d5fd79b86b0a74a162df226ea00a76",
        machines = new List<EarnGGMachine>() { new EarnGGMachine() { name="SAMSON", task="adscend" } },
        data = new EarnGGAccount() { email="grrinder@live.com" } },
    // TonisD1@gmail.com
    new EarnGGProfile() { key="522d27c9-dd73-4aad-8ec7-362bdcb47c82", secret="12bf915c6af40d7c17d388f67d24bfc8",
        machines = new List<EarnGGMachine>() { new EarnGGMachine() { name="GOLIATH", task="adscend" } },
        data = new EarnGGAccount() { email="TonisD1@gmail.com" } },
    // tonisd100@gmail.com
    new EarnGGProfile() { key="79aca030-d667-406f-b0d1-9b58198c7ca9", secret="b98131dd3d12fd3653f454c387e987c6",
        machines = new List<EarnGGMachine>() { new EarnGGMachine() { name="VAIO", task="adscend" } },
    data = new EarnGGAccount() { email="tonisd100@gmail.com" } }
};
*/
/*
public class EarnGGProfile
{
    // KEYS
    public string key { get; set; }
    public string secret { get; set; }
    // API DATA
    public EarnGGAccount data { get; set; } = new EarnGGAccount();
    // LOCAL DATA
    public List<EarnGGMachine> machines { get; set; }
    public Boolean active { get; set; } = false;
}
*/
