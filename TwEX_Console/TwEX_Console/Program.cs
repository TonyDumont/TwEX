using System;
using System.Collections.Generic;
using TwEX_API.Exchange;
using static TwEX_API.Exchange.Bittrex;
using static TwEX_API.Exchange.Poloniex;

namespace TwEX_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TwEX Console");

            List<BittrexMarketSummary> list = Bittrex.getMarketSummariesList();

            foreach (BittrexMarketSummary item in list)
            {
                Console.WriteLine("BITTREX : " + item.MarketName + " | " + item.Last);
            }

            List<PoloniexTicker> list2 = Poloniex.getTickerList();

            foreach (PoloniexTicker ticker in list2)
            {
                Console.WriteLine("POLONIEX : " + ticker.pair + " | " + ticker.last);
            }

            Console.ReadLine();
        }
    }
}
