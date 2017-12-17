using System;
using System.Threading;
using TwEX_API;

namespace TwEX_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //LogManager.ConsoleLogging = true;
            if(ExchangeManager.InitializePreferences())
            {
                //Console.WriteLine("Preferences Initialized : " + ExchangeManager.preferences.apiList.Count + " APIs in list");
                if (ExchangeManager.InitializeExchangeList())
                {
                    //Console.WriteLine("Exchange List Initialized : " + ExchangeManager.exchangeList.Count);
                    //ExchangeManager.updateExchangeTickerList();
                    //ExchangeManager.updateBalanceList();
                    Console.SetCursorPosition(0, 0);
                    Console.Write("--------------------------------");
                    for (int row = 1; row < ExchangeManager.exchangeList.Count + 1; row++)
                    {
                        Console.SetCursorPosition(0, row);
                        Console.Write(ExchangeManager.exchangeList[row - 1].SiteName);
                    }

                    Console.SetCursorPosition(0, ExchangeManager.exchangeList.Count + 1);
                    Console.Write("--------------------------------");

                    int data = 1;
                    System.Diagnostics.Stopwatch clock = new System.Diagnostics.Stopwatch();
                    clock.Start();
                    while (true)
                    {
                        data++;
                        /*
                        Console.SetCursorPosition(1, 2);
                        Console.Write("Current Value: " + data.ToString());
                        Console.SetCursorPosition(1, 3);
                        Console.Write("Running Time: " + clock.Elapsed.TotalSeconds.ToString());
                        Console.SetCursorPosition(1, 4);
                        Console.Write("Balances: " + ExchangeManager.balanceList.Count);
                        */
                        Thread.Sleep(1000);
                    }
                    //Console.ReadKey();
                }
            }
            //Console.ReadLine();
        }
    }
}