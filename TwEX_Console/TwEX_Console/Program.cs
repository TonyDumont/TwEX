using System;
using System.Collections.Generic;
using TwEX_API;
using static TwEX_API.ExchangeManager;

namespace TwEX_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TwEX Console");
            LogManager.ConsoleLogging = true;
            //Console.SetWindowSize(1200, 800);
            

            if (InitializeExchangeList())
            {
                Console.WriteLine("Initialized Exchange List : " + exchangeList.Count + " Exchanges");
                List<ExchangeTicker> tickerList = ExchangeManager.getTickerList();
                Console.WriteLine(tickerList.Count + " Tickers");    
            }     
            Console.ReadLine();
        }
    }
}
