using System;
using static TwEX_API.ExchangeManager;

namespace TwEX_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TwEX Console");

            if (InitializeExchangeList())
            {
                Console.WriteLine("Initialized Exchange List : " + exchangeList.Count + " Exchanges");

                foreach (Exchange exchange in exchangeList)
                {
                    Console.WriteLine(exchange.SiteName + " | " + exchange.Url + " | " + exchange.USDSymbol);
                }
            }
            
            Console.ReadLine();
        }
    }
}
