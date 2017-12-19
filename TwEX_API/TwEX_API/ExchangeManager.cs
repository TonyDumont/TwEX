﻿using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TwEX_API.Exchange;
using TwEX_API.Market;
using static TwEX_API.Market.CryptoCompare;

namespace TwEX_API
{
    public class ExchangeManager
    {
        #region Properties
        private static string Name { get; } = "ExchangeManager";
        private static string WorkDirectory = string.Empty;
        public static ExchangeManagerPreferences preferences = new ExchangeManagerPreferences();
        public static System.Timers.Timer timer = new System.Timers.Timer();
        // COLLECTIONS
        public static List<Exchange> exchangeList = new List<Exchange>();
        public static List<ExchangeBalance> balanceList = new List<ExchangeBalance>();
        public static BlockingCollection<ExchangeTicker> Tickers = new BlockingCollection<ExchangeTicker>();
        public static BlockingCollection<string> Watchlist = new BlockingCollection<string>() { "BTC", "BCH", "ETH", "DASH", "XMR", "LTC", "ETC", "XRP" };
        #endregion Properties

        #region Initialize
        public static Boolean InitializeExchangeList()
        {
            List<string> list = getExchangeList();
            exchangeList.Clear();

            foreach (string name in list)
            {
                Exchange exchange = new Exchange() { Name = name };
                Type type = getExchangeType(exchange.Name);

                if (type != null)
                {
                    try
                    {
                        exchange.Url = type.GetProperty("Url", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                        exchange.USDSymbol = type.GetProperty("USDSymbol", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                        //LogManager.AddLogMessage(Name, "InitializeExchangeList", "type !+ null for " + exchange.SiteName + " | " + preferences.apiList.Count, LogManager.LogMessageType.DEBUG);
                        ExchangeApi api = preferences.apiList.FirstOrDefault(a => a.exchange.ToLower() == exchange.Name.ToLower());
                        if (api != null)
                        {
                            SetExchangeApi(api);
                        }

                        Task.Factory.StartNew(() => type.InvokeMember("InitializeExchange",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
                        /*
                        type.InvokeMember("InitializeExchange",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null);
                                */
                    }
                    catch (Exception ex)
                    {
                        LogManager.AddLogMessage(Name, "InitializeExchangeList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                    }
                }
                else
                {
                    LogManager.AddLogMessage(Name, "InitializeExchangeList", "PROBLEM : type is NULL : " + exchange.Name, LogManager.LogMessageType.DEBUG);
                }
                exchangeList.Add(exchange);
            }
            return true;
        }
        public static Boolean InitializePreferences()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string targetPath = System.IO.Path.GetDirectoryName(path);
            WorkDirectory = new Uri(targetPath).LocalPath;
            
            string iniPath = WorkDirectory + "\\Preferences.ini";
            //LogManager.AddLogMessage(Name, "Initialize", "Checking for Preferences.ini @ " + iniPath);
            if (File.Exists(iniPath))
            {
                //LogManager.AddLogMessage(Name, "Initialize", "There is an ini - reading it", LogManager.LogMessageType.DEBUG);
                string text = File.ReadAllText(iniPath);
                string json = LogManager.Decrypt(text);
                preferences = JsonConvert.DeserializeObject<ExchangeManagerPreferences>(json);
                //LogManager.AddLogMessage(Name, "Initialize", "There is an ini - read it : " + preferences.apiList.Count + " APIS", LogManager.LogMessageType.DEBUG);
                
            }
            else
            {
                LogManager.AddLogMessage(Name, "InitializePreferences", "Preferences.ini doese not exist - Creating It");
                UpdatePreferencesFile();
            }
            return true;
        }
        // TIMER
        public static void InitializeTimer()
        {
            //clockControl = control;
            timer.Interval = 60000;
            timer.Elapsed += new ElapsedEventHandler(OnTimer_tick);
            LogManager.AddLogMessage(Name, "InitializeTimer", "Starting Exchange Manager Clock", LogManager.LogMessageType.EXCHANGE);
            //clockControl.UpdateClock();
            timer.Start();
        }
        private static void OnTimer_tick(object sender, EventArgs e)
        {
            //LogManager.AddDebugMessage(thisClassName, "OnTimer_clockTick", "Tick:" + now.Minute);
            switch (DateTime.Now.Minute)
            {
                case 0:
                    /*
                    LogManager.AddDebugMessage(thisClassName, "OnTimer_clockTick", "Hourly Check : Hour:" + now.Hour);
                    if (AutoUpdate)
                    {
                        Task.Factory.StartNew(() => ExchangeManager.UpdateAllExchangeBalances());
                        //Task.Factory.StartNew(() => FaucetManager.UpdateEarnGGMachines());
                        //Task.Factory.StartNew(() => ExchangeManager.UpdateMarketCaps());
                    }

                    if (now.Hour == 0)
                    {
                        LogManager.AddDebugMessage(thisClassName, "OnTimer_clockTick", "Hour is 0 : SHOULD BE MIDNIGHT - ANYTHING TO RESET?");
                    }
                    */
                    updateBalances();
                    break;

                case 5:
                case 10:
                case 15:
                case 20:
                case 25:
                case 30:
                case 35:
                case 40:
                case 45:
                case 50:
                case 55:
                    updateBalances();
                    /*
                    if (AutoUpdate)
                    {
                        Task.Factory.StartNew(() => UpdateAllExchangeBalances());
                        //Task.Factory.StartNew(() => FaucetManager.UpdateEarnGGMachines());
                        //Task.Factory.StartNew(() => ExchangeManager.UpdateMarketCaps());

                    }
                    */
                    break;

                default:
                    //LogManager.AddDebugMessage(thisClassName, "OnTimer_clockTick", "DEFAULT : " + now.Minute);
                    // DO THIS EVERY OTHER MINUTES
                    //updateBalanceList();
                    /*
                    if (AutoUpdate)
                    {
                        Task.Factory.StartNew(() => UpdateAllExchangeTickers());
                    }
                    */
                    break;
            }

            // EVERY MINUTE
            //Task.Factory.StartNew(() => ExchangeManager.UpdateMarketCaps());
            //LogManager.AddLogMessage(Name, "OnTimer_tick", "timer ticker", LogManager.LogMessageType.EXCHANGE);
            updateTickers();
            CoinMarketCap.updateTickers();
            //updateBalanceList();
            //updateBalanceList();
        }
        #endregion Initialize

        #region Getters
        /// <summary>Gets a LIST of balances for an exchange or gets ALL if no name specified</summary>
        public static List<ExchangeBalance> getBalanceList(string exchangeName = "")
        {
            List<ExchangeBalance> list = new List<ExchangeBalance>();
            
            try
            {
                if (exchangeName.Length > 0)
                {
                    Type type = getExchangeType(exchangeName);
                    if (type != null)
                    {
                        
                        //Boolean isAsync =
                        Boolean isAsync = Convert.ToBoolean(type.GetProperty("isAsync", BindingFlags.Public | BindingFlags.Static).GetValue(null));
                        //string isAsync = type.GetProperty("isAsync", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                        LogManager.AddLogMessage(Name, "getCurrencyList", "type is : " + type.Name + " | " + isAsync, LogManager.LogMessageType.DEBUG);
                        //Console.WriteLine("isAsync = " + isAsync);
                        list = (List<ExchangeBalance>)type.InvokeMember("getExchangeBalanceList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null);
                        /*
                        var tlist = (Task<List<ExchangeBalance>>)type.InvokeMember("getExchangeBalanceList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null);
                        Console.WriteLine(tlist.Count);
                        */
                        /*
                    var tlist = (Task<List<ExchangeBalance>>)type.InvokeMember("getExchangeBalanceList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null);

                        LogManager.AddLogMessage(Name, "getCurrencyList", "type is : " + tlist.Status, LogManager.LogMessageType.DEBUG);
                        */
                        //Console.WriteLine("t: " + tlist.);
                        /*
                        if (!isAsync)
                        {
                            list = (List<ExchangeBalance>)type.InvokeMember("getExchangeBalanceList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null);
                        }
                        else
                        {
                            var tList = (List<ExchangeBalance>)type.InvokeMember("getExchangeBalanceList",
                               BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                               null,
                               type,
                               null);
                            Console.WriteLine("t: " + tList.Count);
                        }
                        */
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "getCurrencyList", "type is NULL : " + exchangeName, LogManager.LogMessageType.DEBUG);
                    }
                }
                else
                {
                    /*
                    foreach (Exchange exchange in exchangeList)
                    {
                        //Console.WriteLine(exchange.SiteName + " | " + exchange.USDSymbol);
                        Type type = getExchangeType(exchange.SiteName);

                        List<ExchangeTicker> itemlist = (List<ExchangeTicker>)type.InvokeMember("getExchangeTickerList",
                            BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                            null,
                            type,
                            null);

                        foreach (ExchangeTicker ticker in itemlist)
                        {
                            list.Add(ticker);
                        }
                        Console.WriteLine(exchange.SiteName + " | " + exchange.USDSymbol + " | " + itemlist.Count + " Tickers");
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrencyList", "EXCEPTION!!! : " + ex.Message);
            }
            
            return list;
        }
        
        /// <summary>Gets an Exchange by its name</summary>
        public static Exchange getExchange(string name)
        {
            Exchange exchange = exchangeList.FirstOrDefault(item => item.Name == name);

            if (exchange != null)
            {
                //exchange.BalanceList = balanceList.FindAll(balance => balance.Exchange == name);
                return exchange;
            }
            else
            {
                return null;
            }
        }

        /// <summary>Helper to get class name for exchanges ignoring case</summary>
        public static string getExchangeSiteName(string name)
        {
            Exchange exchange = exchangeList.FirstOrDefault(item => item.Name.ToLower() == name.ToLower());
            //LogManager.AddLogMessage(Name, "getExchangeSiteName", name + " | " + exchange.SiteName);

            if (exchange != null)
            {
                return exchange.Name;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>Helper to get class name for exchanges ignoring case</summary>
        public static ExchangeTicker getExchangeTicker(string exchange, string symbol, string market)
        {
            ExchangeTicker ticker = Tickers.FirstOrDefault(t => t.exchange == exchange && t.symbol == symbol && t.market == market);
            if (exchange != "CryptoCompare" && ticker != null )
            {
                return ticker;
            }
            else
            {
                ExchangeTicker ccTicker = new ExchangeTicker();
                List<CryptoComparePrice> priceList = CryptoCompare.getPriceList(symbol, new string[] { market });

                if (priceList.Count > 0)
                {
                    //CryptoComparePrice price = priceList[0];
                    ccTicker.exchange = exchange;
                    ccTicker.symbol = symbol;
                    ccTicker.market = market;
                    ccTicker.last = priceList[0].value;
                }
                return ccTicker;
            }
        }

        /// <summary>Gets Exchange TYPE from TwEX_API.Exchange by name</summary>
        public static Type getExchangeType(string name)
        {
            //string exchangeName = getExchangeSiteName(name);
            //Console.WriteLine("getExchangeType.exchangeName=" + exchangeName + " | name=" + name);
            Type myType = Type.GetType("TwEX_API.Exchange." + name);
            return myType;
        }

        /// <summary>Gets a LIST of Exchange classes in TwEX_API.Exchange</summary>
        public static List<string> getExchangeList()
        {
            List<string> list = new List<string>();

            var classList = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(t => t.GetTypes())
                       .Where(t => t.IsClass && t.Namespace == "TwEX_API.Exchange");

            foreach (var type in classList)
            {
                //Console.WriteLine("type=" + type.ToString() + " | " + type.Name + " | " + type.IsNested);
                if (type.IsNested == false && type.Name != "TEMPLATE")
                {
                    list.Add(type.Name);
                }
            }
            return list;
        }

        /// <summary>Gets a new NONCE based on Unix Seconds</summary>
        public static String GetNonce()
        {
            long ms = (long)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            return ms.ToString();
        }

        /// <summary>Gets a LIST of tickers for an exchange or gets ALL if no name specified</summary>
        public static List<ExchangeTicker> getTickerList(string exchangeName = "")
        {
            List<ExchangeTicker> list = new List<ExchangeTicker>();

            try
            {
                if (exchangeName.Length > 0)
                {
                    Type type = getExchangeType(exchangeName);
                    if (type != null)
                    {
                        list = (List<ExchangeTicker>)type.InvokeMember("getExchangeTickerList",
                            BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                            null,
                            type,
                            null);
                    }
                }
                else
                {
                    foreach (Exchange exchange in exchangeList)
                    {
                        //Console.WriteLine(exchange.SiteName + " | " + exchange.USDSymbol);
                        Type type = getExchangeType(exchange.Name);

                        List<ExchangeTicker> itemlist = (List<ExchangeTicker>)type.InvokeMember("getExchangeTickerList",
                            BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                            null,
                            type,
                            null);

                        foreach (ExchangeTicker ticker in itemlist)
                        {
                            list.Add(ticker);
                        }
                        Console.WriteLine(exchange.Name + " | " + exchange.USDSymbol + " | " + itemlist.Count + " Tickers");
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "getCurrencyList", "EXCEPTION!!! : " + ex.Message);
            }

            return list;
        }
        #endregion Getters

        #region Processors
        public static void processBalance(ExchangeBalance balance)
        {
            ExchangeBalance listItem = balanceList.FirstOrDefault(b => b.Exchange == balance.Exchange && b.Symbol == balance.Symbol);

            if (listItem != null)
            {
                // UPDATE
                listItem.Balance = balance.Balance;
                listItem.OnOrders = balance.OnOrders;
                listItem.TotalInBTC = balance.TotalInBTC;
                listItem.TotalInUSD = balance.TotalInUSD;
                //LogManager.AddLogMessage(Name, "processBalance", "Updated " + balance.Symbol + " for " + balance.Exchange, LogManager.LogMessageType.DEBUG);
            }
            else
            {
                // ADD
                balanceList.Add(balance);
                //LogManager.AddLogMessage(Name, "processBalance", "Added " + balance.Symbol + " for " + balance.Exchange, LogManager.LogMessageType.DEBUG);
            }
        }
        public static void processTicker(ExchangeTicker ticker)
        {
            /*
            ExchangeTicker listItem = tickerList.FirstOrDefault(t => t.exchange == ticker.exchange 
            && t.symbol == ticker.symbol 
            && t.market == ticker.market);
            */
            ExchangeTicker listItem = Tickers.FirstOrDefault(t => t.exchange == ticker.exchange
            && t.symbol == ticker.symbol
            && t.market == ticker.market);

            if (listItem != null)
            {
                // UPDATE
                listItem.ask = ticker.ask;
                listItem.bid = ticker.bid;
                listItem.change = ticker.change;
                listItem.high = ticker.high;
                listItem.last = ticker.last;
                listItem.low = ticker.low;
                listItem.volume = ticker.volume;
                //LogManager.AddLogMessage(Name, "processTicker", "Updated " + ticker.symbol + "/" + ticker.market + " for " + ticker.exchange, LogManager.LogMessageType.DEBUG);
            }
            else
            {
                // ADD
                //tickerList.Add(ticker);
                Tickers.Add(ticker);
                //LogManager.AddLogMessage(Name, "processTicker", "Added " + ticker.symbol + "/" + ticker.market + " for " + ticker.exchange, LogManager.LogMessageType.DEBUG);
            }
        }
        #endregion Processors

        #region Updaters
        /// <summary>Updates BALANCE COLLECTION for an exchange or ALL if no name specified</summary>
        public static void updateBalances(string exchangeName = "")
        {
            try
            {
                if (exchangeName.Length > 0)
                {
                    Type type = getExchangeType(exchangeName);
                    if (type != null)
                    {
                        //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "type is : " + type.Name);
                        var api = type.GetProperty("Api", BindingFlags.Public | BindingFlags.Static).GetValue(null);

                        if (api != null)
                        {
                            type.InvokeMember("updateExchangeBalanceList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null);
                        }
                        else
                        {
                            LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "This Method Requires API CREDENTIALS", LogManager.LogMessageType.OTHER);
                        }                    
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "type is NULL : " + exchangeName, LogManager.LogMessageType.DEBUG);
                    }
                }
                else
                {     
                    foreach (Exchange exchange in exchangeList)
                    {
                        Type type = getExchangeType(exchange.Name);
                        if (type != null)
                        {
                            //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "type is : " + type.Name);
                            var api = type.GetProperty("Api", BindingFlags.Public | BindingFlags.Static).GetValue(null);

                            if (api != null)
                            {
                                type.InvokeMember("updateExchangeBalanceList",
                                    BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                    null,
                                    type,
                                    null);
                            }
                            else
                            {
                                LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "Balance List Requires API CREDENTIALS for " + exchange.Name, LogManager.LogMessageType.OTHER);
                            }
                        }
                        else
                        {
                            LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "type is NULL : " + exchangeName, LogManager.LogMessageType.DEBUG);
                        }
                    }  
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "updateBalanceList", "EXCEPTION!!! : " + ex.Message);
            }
        }

        /// <summary>Updates TICKER COLLECTION for an exchange or does ALL if no name specified</summary>
        public static void updateTickers(string exchangeName = "")
        {
            CoinMarketCap.updateTickers();

            try
            {
                if (exchangeName.Length > 0)
                {
                    Type type = getExchangeType(exchangeName);
                    if (type != null)
                    {
                        //LogManager.AddLogMessage(Name, "updateExchangeTickerList", "type is : " + type.Name);

                        type.InvokeMember("updateExchangeTickerList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null);
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "updateExchangeTickerList", "type is NULL : " + exchangeName, LogManager.LogMessageType.DEBUG);
                    }
                }
                else
                {
                    
                    foreach (Exchange exchange in exchangeList)
                    {
                        Type type = getExchangeType(exchange.Name);
                        if (type != null)
                        {
                            //LogManager.AddLogMessage(Name, "updateExchangeTickerList", "type is : " + type.Name);

                            type.InvokeMember("updateExchangeTickerList",
                                    BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                    null,
                                    type,
                                    null);
                        }
                        else
                        {
                            LogManager.AddLogMessage(Name, "updateExchangeTickerList", "type is NULL : " + exchangeName, LogManager.LogMessageType.DEBUG);
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "updateExchangeTickerList", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
        }
        
        #endregion Updaters

        #region Preferences
        public static void AddExchangeApi(ExchangeApi api)
        {
            ExchangeApi match = preferences.apiList.FirstOrDefault(item => item.exchange.ToLower() == api.exchange.ToLower());
            
            if (match == null)
            { 
                preferences.apiList.Add(api);
                LogManager.AddLogMessage(Name, "AddExchangeApi", "Added API for " + api.exchange, LogManager.LogMessageType.DEBUG);
                
            }
            else
            {
                LogManager.AddLogMessage(Name, "AddExchangeApi", api.exchange + " Already Exists in API List - Replacing Values");
                match.key = api.key;
                match.secret = api.secret;
                match.passphrase = api.passphrase;
            }
            UpdatePreferencesFile();
        }
        public static void RemoveExchangeApi(string exchange)
        {
            ExchangeApi match = preferences.apiList.FirstOrDefault(item => item.exchange.ToLower() == exchange.ToLower());

            if (match != null)
            {
                LogManager.AddLogMessage(Name, "RemoveExchangeApi", "Removing " + exchange + " from API List", LogManager.LogMessageType.DEBUG);
                preferences.apiList.Remove(match);
                UpdatePreferencesFile();
            }
            else
            {
                LogManager.AddLogMessage(Name, "AddExchangeApi", exchange + " Does Not Exist in API List - Nothing To Remove");
            }        
        }
        public static void SetExchangeApi(ExchangeApi api)
        {
            //LogManager.AddLogMessage(Name, "SetExchangeApi", api.exchange);
            Type type = getExchangeType(api.exchange);

            if (type != null)
            {
                //LogManager.AddLogMessage(Name, "SetExchangeApi", api.exchange + " | type = " + type.Name + " | " + type.Namespace);
                try
                {
                    PropertyInfo prop = type.GetProperty("Api");
                    prop.SetValue(type, api, null);
                    //LogManager.AddLogMessage(Name, "SetExchangeApi", "Set API for " + api.exchange, LogManager.LogMessageType.DEBUG);
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "SetExchangeApi", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
            else
            {
                LogManager.AddLogMessage(Name, "SetExchangeApi", "PROBLEM : type is NULL : " + api.exchange, LogManager.LogMessageType.DEBUG);
            }
        }
        public static void UpdatePreferencesFile()
        {
            //string targetPath = directory + "\\Preferences.ini";
            //Console.WriteLine("tpath = " + targetPath);
            string iniPath = WorkDirectory + "\\Preferences.ini";
            //LogManager.AddLogMessage(Name, "UpdatePreferencesFile", "writing to iniPath - " + iniPath, LogManager.LogMessageType.DEBUG);
            string json = JsonConvert.SerializeObject(preferences, Formatting.Indented);
            //Console.WriteLine("json = " + json);
            string text = LogManager.Encrypt(json);
            //Console.WriteLine("text = " + text);
            File.WriteAllText(@iniPath, text);
            Console.WriteLine("Preferences Update : " + preferences.apiList.Count);
            /*
            var json = File.ReadAllText(targetPath);
            var customers = JsonConvert.DeserializeObject<ExchangeManagerPreferences>(json);
            customers.Add(newCustomer);
            File.WriteAllText(pathToTheFile", JsonConvert.SerializeObject(customers));
            */

            /*
            string targetPath = directory + "\\Preferences.ini";
            File.WriteAllText(targetPath, preferences.ToString());
            using (StreamWriter file = File.CreateText(targetPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                preferences.WriteTo(writer);
            }
            */


            /*
            string data = JsonConvert.SerializeObject(preferences);

            string readPath = directory + "\\Preferences.ini";
            Console.WriteLine(readPath + " | " + data);
            
            List<string> iniList = new List<string>();
            iniList.Add(data);
            File.WriteAllLines(readPath, iniList.ToArray(), Encoding.UTF8);
            */
        }
        #endregion Preferences

        #region DataModels
        public class Exchange
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string USDSymbol { get; set; }
            // COLLECTIONS
            public List<ExchangeBalance> BalanceList { get { return ExchangeManager.balanceList.FindAll(balance => balance.Exchange == Name); } }
            public List<ExchangeTicker> TickerList { get { return ExchangeManager.Tickers.Where(ticker => ticker.exchange == Name).ToList(); } }
        }
        public class ExchangeApi
        {
            public string exchange { get; set; }
            public string key { get; set; }
            public string secret { get; set; }
            // GDAX
            public string passphrase { get; set; }
        }
        public class ExchangeBalance
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
            public string Exchange { get; set; }
            public string Wallet { get; set; }

            public Decimal Balance { get; set; }
            public Decimal OnOrders { get; set; }
            public Decimal TotalInBTC { get; set; }
            public Decimal TotalInUSD { get; set; }
        }
        public class ExchangeManagerPreferences
        {
            public List<ExchangeApi> apiList { get; set; } = new List<ExchangeApi>();
        }
        public class ExchangeTicker
        {
            // ID
            public string exchange { get; set; }
            public string market { get; set; }
            public string symbol { get; set; }
            // UPDATED
            public Decimal last { get; set; }
            public Decimal ask { get; set; }
            public Decimal bid { get; set; }
            public Decimal change { get; set; }
            public Decimal volume { get; set; }
            public Decimal high { get; set; }
            public Decimal low { get; set; }
        }
        #endregion DataModels

    }
}

/*
        /// <summary>Updates MARKET CAPS COLLECTION from coinmarketcap.com</summary>
        public static void updateMarketCaps()
        {

        }
        */
