using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using TwEX_API;
using TwEX_API.Market;
using static TwEX_API.Market.CryptoCompare;

namespace TwEX_Console
{
    public class Program
    {
        // COLORS
        private static ConsoleColor delimiterColor = ConsoleColor.DarkYellow;
        // WINDOW
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        // THREAD
        static void Main(string[] args)
        {
            //Console.Title = typeof(Program).Name;
            Console.Title = "TwEX Console";
            LogManager.ConsoleLogging = true;
            Console.BufferWidth = Console.WindowWidth = 150;
            Console.BufferHeight = Console.WindowHeight = 45;
            Console.CursorVisible = false;

            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                //DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }

            //List<CryptoComparePrice> priceTicker = CryptoCompare.getPriceList("BTC", new string[] { "USD" });
            //LogManager.AddLogMessage("Program", "Main", "count=" + priceTicker.Count + " | " + priceTicker[0].value);

            if (ExchangeManager.InitializePreferences())
            {
                //Console.WriteLine("Preferences Initialized : " + ExchangeManager.preferences.apiList.Count + " APIs in list");
                LogManager.AddLogMessage("Program", "Main", "Preferences Initialized : " + ExchangeManager.preferences.apiList.Count + " APIs in list");

                if (ExchangeManager.InitializeExchangeList())
                {
                    ExchangeManager.InitializeTimer();
                    
                    Run();
                }
            }
        }
        // LOOP
        static void Run()
        {
            //int data = 1;
            //System.Diagnostics.Stopwatch clock = new System.Diagnostics.Stopwatch();
            //clock.Start();
            while (true)
            {
                ReDraw();
                /*
                data++;
                Console.Clear();
                Console.SetCursorPosition(1, 2);
                Console.Write("Current Value: " + data.ToString());
                Console.SetCursorPosition(1, 3);
                Console.Write("Running Time: " + clock.Elapsed.TotalSeconds.ToString());
                Console.SetCursorPosition(1, 4);
                Console.Write("Balances: " + ExchangeManager.balanceList.Count);
                
                var consoleInput = LogManager.ReadFromConsole();
                if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                try
                {
                    // Execute the command:
                    string result = LogManager.Execute(consoleInput);
                    // Write out the result:
                    //Console.SetCursorPosition(0, Console.BufferHeight - 1);
                    LogManager.WriteToConsole(result);
                }
                catch (Exception ex)
                {
                    // OOPS! Something went wrong - Write out the problem:
                    LogManager.WriteToConsole(ex.Message);
                }
                */
                

            }
        }
        // DRAW
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        static void ReDraw()
        {
            //int row = 0;

            // HEADER
            //Console.Clear();
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            ColoredConsoleWrite(ConsoleColor.Cyan, DateTime.Now.ToString());
            ColumnBreak();
            //Console.WriteLine(ExchangeManager.exchangeList.Count + " Exchanges | " + ExchangeManager.Tickers.Count + " Tickers | " + CoinMarketCap.Tickers.Count + " Market Caps");
            Console.Write(ExchangeManager.exchangeList.Count + " Exchanges");
            ColumnBreak();
            Console.Write(ExchangeManager.Tickers.Count + " Tickers");
            ColumnBreak();
            Console.Write(CoinMarketCap.Tickers.Count + " Market Caps");
            ColumnBreak();
            ColoredConsoleWrite(ConsoleColor.DarkCyan, ExchangeManager.exchangeList.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInBTC)).ToString("N8"));
            //Console.Write(ExchangeManager.exchangeList.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInBTC)).ToString("N8") + " BTC");
            ColumnBreak();
            //Console.Write(ExchangeManager.exchangeList.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInUSD)).ToString("C") + " USD");
            ColoredConsoleWrite(ConsoleColor.DarkGreen, ExchangeManager.exchangeList.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInUSD)).ToString("C") + " USD\r\n");

            //RowBreak();

            // EXCHANGE HEADER
            
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = delimiterColor;
            Console.WriteLine(new String('#', Console.WindowWidth-1));
            
            Console.SetCursorPosition(0, 2);
            Console.ResetColor();
            Console.WriteLine(String.Format("{0,-10} | {1,5} | {2,5} | {3,10} | {4,10}", "Exchange", "Tkrs", "Coins", "Total BTC", "Total USD"));

            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = delimiterColor;
            Console.WriteLine(new String('-', Console.WindowWidth));
            
            // EXCHANGE LIST
            int row = 4;
            Console.ForegroundColor = ConsoleColor.White;
            foreach (ExchangeManager.Exchange exchange in ExchangeManager.exchangeList.OrderByDescending(item => item.BalanceList.Sum(balance => balance.TotalInBTC)))
            {
                Console.SetCursorPosition(0, row);
                //ClearCurrentConsoleLine();
                Console.WriteLine(String.Format("{0,-10} | {1,5} | {2,5} | {3,10} | {4,10}", 
                    exchange.Name, 
                    exchange.TickerList.Count,
                    exchange.BalanceList.FindAll(e => e.Balance > 0).Count,
                    exchange.BalanceList.Sum(balance => balance.TotalInBTC).ToString("N8"),
                    exchange.BalanceList.Sum(balance => balance.TotalInUSD).ToString("C")
                    ));
                row++;
            }

            Console.SetCursorPosition(0, row++);
            Console.ForegroundColor = delimiterColor;
            Console.WriteLine(new String('-', Console.WindowWidth));
            
            Console.ForegroundColor = ConsoleColor.Gray;
            int spread = (Console.WindowHeight - 3) - row;
            var messages = LogManager.MessageList.Skip(Math.Max(0, LogManager.MessageList.Count() - spread));
            //Console.ResetColor();

            foreach (var message in messages)
            {
                Console.SetCursorPosition(0, row);
                //ClearCurrentConsoleLine();
                Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}",
                    message.TimeStamp,
                    message.Source,
                    message.FunctionCall,
                    message.Message,
                    new string(' ', 1)
                    ));
                row++;
            }
            /*
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.WriteLine(new String('#', Console.WindowWidth));
            */
        }
        public static void ColoredConsoleWrite(ConsoleColor color, string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = originalColor;
        }
        public static void ColumnBreak()
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = delimiterColor;
            Console.Write(" | ");
            Console.ForegroundColor = originalColor;
        }
        public static void RowBreak()
        {
            //Console.Write("\r\n");
            //Console.SetCursorPosition(0, row);
            Console.ForegroundColor = delimiterColor;
            Console.WriteLine(new String('-', Console.WindowWidth));
            Console.ResetColor();
        }
    }
}

//Console.Write("--------------------------------");
//Console.WriteLine("Exchange | USD/T  |   Url");
//Console.WriteLine("--------------------------------");

/*
            //LogManager.ConsoleLogging = true;
            if(ExchangeManager.InitializePreferences())
            {
                //Console.WriteLine("Preferences Initialized : " + ExchangeManager.preferences.apiList.Count + " APIs in list");
                if (ExchangeManager.InitializeExchangeList())
                {
                    ExchangeManager.InitializeTimer();
                    //Console.WriteLine("Exchange List Initialized : " + ExchangeManager.exchangeList.Count);
                    //ExchangeManager.updateExchangeTickerList();
                    //ExchangeManager.updateBalanceList();
                    Console.SetCursorPosition(0, 0);
                    //Console.Write("--------------------------------");
                    //Console.WriteLine("Exchange | USD/T  |   Url");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10}", "Exchange", "USD/T", "Url"));
                    Console.WriteLine("--------------------------------");

                    Console.SetCursorPosition(0, ExchangeManager.exchangeList.Count + 1);
                    Console.Write("--------------------------------");

                    int data = 1;
                    System.Diagnostics.Stopwatch clock = new System.Diagnostics.Stopwatch();
                    clock.Start();
                    while (true)
                    {
                        data++;
                        
                        Console.SetCursorPosition(1, 2);
                        Console.Write("Current Value: " + data.ToString());
                        Console.SetCursorPosition(1, 3);
                        Console.Write("Running Time: " + clock.Elapsed.TotalSeconds.ToString());
                        Console.SetCursorPosition(1, 4);
                        Console.Write("Balances: " + ExchangeManager.balanceList.Count);
                        
                        Thread.Sleep(1000);
                    }
                    //Console.ReadKey();
                }
            }
            //Console.ReadLine();
            */


/*
        int origWidth, width;
        int origHeight, height;
        string m1 = "The current window width is {0}, and the " +
                    "current window height is {1}.";
        string m2 = "The new window width is {0}, and the new " +
                    "window height is {1}.";
        string m4 = "  (Press any key to continue...)";
        //
        // Step 1: Get the current window dimensions.
        //
        origWidth = Console.WindowWidth;
        origHeight = Console.WindowHeight;
        Console.WriteLine(m1, Console.WindowWidth,
                              Console.WindowHeight);
        Console.WriteLine(m4);
        Console.ReadKey(true);
        //
        // Step 2: Cut the window to 1/4 its original size.
        //
        width = origWidth / 2;
        height = origHeight / 2;
        Console.SetWindowSize(width, height);
        Console.WriteLine(m2, Console.WindowWidth,
                              Console.WindowHeight);
        Console.WriteLine(m4);
        Console.ReadKey(true);
        //
        // Step 3: Restore the window to its original size.
        //
        Console.SetWindowSize(origWidth, origHeight);
        Console.WriteLine(m1, Console.WindowWidth,
                              Console.WindowHeight);
                              */

//int index = 0;
/*
for (int i = 0; i < spread; i++)
{
    Console.SetCursorPosition(0, row);
    LogManager.LogMessage message = LogManager.LogMessageList.ElementAt(i);
    if (message != null)
    {
        Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10} | {3,-10}",
            message.TimeStamp,
            message.Source,
            message.FunctionCall,
            message.Message
            ));
        row++;
    }
}*/
//int index = 0;
/*
            Console.ForegroundColor = delimiterColor;
            Console.WriteLine(new String('-', Console.WindowWidth));
            Console.ResetColor();
            */


/*
Console.SetCursorPosition(0, row++);
Console.WriteLine(DateTime.Now);
Console.SetCursorPosition(0, row++);
Console.WriteLine(new String('-', Console.WindowWidth));
//Console.SetCursorPosition(0, row++);
*/
