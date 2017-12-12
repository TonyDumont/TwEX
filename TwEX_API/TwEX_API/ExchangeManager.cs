using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using TwEX_API.Exchange;

namespace TwEX_API
{
    public class ExchangeManager
    {
        #region Properties
        public static List<Exchange> exchangeList = new List<Exchange>();
        #endregion Properties

        #region Initialize
        public static Boolean InitializeExchangeList()
        {
            List<string> list = getExchangeList();
            exchangeList.Clear();

            foreach (string name in list)
            {
                //Console.WriteLine("exchange name= " + name);
                Exchange exchange = new Exchange() { SiteName = name };
                Type type = getExchangeType(exchange.SiteName);

                if (type != null)
                {
                    try
                    {
                        exchange.Url = type.GetProperty("Url", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                        exchange.USDSymbol = type.GetProperty("USDSymbol", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("EXCEPTION : " + ex.Message);
                    }
                }
                exchangeList.Add(exchange);
            }
            return true;
        }
        #endregion Initialize

        #region Getters
        /// <summary>Gets Exchange TYPE from TwEX_API.Exchange by name</summary>
        public static Type getExchangeType(string name)
        {
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

            foreach(var type in classList)
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
                    Console.WriteLine(exchange.SiteName + " | " + exchange.USDSymbol);
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
                }
            }
            return list;
        }
        #endregion Getters

        #region DataModels
        public class Exchange
        {
            public string SiteName { get; set; }
            public string Url { get; set; }
            //public string Symbol { get; set; }

            public string USDSymbol { get; set; }
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
