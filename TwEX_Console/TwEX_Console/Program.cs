using System;
using System.Linq;
using System.Threading.Tasks;
using TwEX_API;
using TwEX_API.Market;

namespace TwEX_Console
{
    public class Program
    {
        #region Properties
        static ConsoleColor delimiterColor = ConsoleColor.DarkGray;
        static int row = 1;
        #endregion Properties
        
        #region Thread
        static void Main(string[] args)
        {
            if (LogManager.InitializeLogManager())
            {
                Console.Title = "TwEX Console";
                LogManager.ConsoleLogging = true;
                Console.BufferWidth = Console.WindowWidth = 150;
                Console.BufferHeight = Console.WindowHeight = 50;
                Console.CursorVisible = false;
                /*
                IntPtr handle = GetConsoleWindow();
                IntPtr sysMenu = GetSystemMenu(handle, false);

                if (handle != IntPtr.Zero)
                {
                    //DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);
                    DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                    DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                    DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
                }
                */
            }

            if (PreferenceManager.InitializePreferences())
            {
                if (ExchangeManager.InitializeExchangeList())
                {
                    ExchangeManager.InitializeTimer();
                    Run();
                }
            }
        }
        static void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        // TIMER FLAGS
                        case ConsoleKey.B:
                            //LogManager.AddLogMessage("Program", "Run", "Updating All Balances", LogManager.LogMessageType.CONSOLE);
                            Task.Factory.StartNew(() => ExchangeManager.updateBalances());
                            PreferenceManager.toggleTimerPreference(ExchangeManager.ExchangeTimerType.BALANCES);
                            break;

                        case ConsoleKey.T:
                            //LogManager.AddLogMessage("Program", "Run", "Updating All Tickers", LogManager.LogMessageType.CONSOLE);
                            Task.Factory.StartNew(() => ExchangeManager.updateTickers());
                            PreferenceManager.toggleTimerPreference(ExchangeManager.ExchangeTimerType.TICKERS);
                            break;

                        case ConsoleKey.O:
                            PreferenceManager.toggleTimerPreference(ExchangeManager.ExchangeTimerType.ORDERS);
                            break;

                        case ConsoleKey.H:
                            PreferenceManager.toggleTimerPreference(ExchangeManager.ExchangeTimerType.HISTORY);
                            break;

                        // MESSAGE FLAGES
                        case ConsoleKey.L:
                            LogManager.ToggleMessageFlag(LogManager.LogMessageType.LOG);

                            break;

                        case ConsoleKey.C:
                            LogManager.ToggleMessageFlag(LogManager.LogMessageType.CONSOLE);
                            break;

                        case ConsoleKey.D:
                            LogManager.ToggleMessageFlag(LogManager.LogMessageType.DEBUG);
                            break;

                        case ConsoleKey.E:
                            LogManager.ToggleMessageFlag(LogManager.LogMessageType.EXCHANGE);
                            break;

                        case ConsoleKey.R:
                            LogManager.ToggleMessageFlag(LogManager.LogMessageType.OTHER);
                            break;

                        case ConsoleKey.X:
                            LogManager.ToggleMessageFlag(LogManager.LogMessageType.EXCEPTION);
                            break;

                        // IMPORT/EXPORT
                        case ConsoleKey.I:
                            PreferenceManager.ImportPreferences();
                            break;

                        case ConsoleKey.P:
                            PreferenceManager.ExportPreferences();
                            break;

                        default:
                            break;
                    }
                }
                ReDraw();
            }
        }
        #endregion Thread

        #region Draw
        static void ReDraw()
        {
            Console.CursorVisible = false;
            row = 1;
            DrawHeader();
            RowBreak(row++, '#', delimiterColor);
            DrawExchangeList();
            RowBreak(row++, '#', delimiterColor);
            DrawMenu();
            RowBreak(row++, '-', delimiterColor);
            DrawConsole();
            RowBreak(row++, '-', delimiterColor);
            DrawFooter();
        }

        static void DrawHeader()
        {
            Console.SetCursorPosition(1, 0);
            Console.Write(ExchangeManager.Exchanges.Count + " Exchanges");
            ColumnBreak();
            Console.Write(ExchangeManager.Tickers.Count + " Tickers");
            ColumnBreak();
            ConsoleWrite(ConsoleColor.DarkYellow, CoinMarketCap.Tickers.Count + " Market Caps @ " + CoinMarketCap.Tickers.Sum(t => t.market_cap_usd).ToString("C"));

            string btcOrders = ExchangeManager.Exchanges.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInBTCOrders)).ToString("N8");
            string btcTotal = ExchangeManager.Exchanges.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInBTC)).ToString("N8");
            string usdTotal = ExchangeManager.Exchanges.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInUSD)).ToString("C");
            //int rightPadding = Console.WindowWidth - (btcOrders.Length + 3 + btcTotal.Length + 3 + usdTotal.Length + 1);
            int rightPadding = btcOrders.Length + 3 + btcTotal.Length + 3 + usdTotal.Length + 1;
            //Console.SetCursorPosition(Console.WindowWidth - (btcTotal.Length + 3 + usdTotal.Length + 1), 0);
            Console.SetCursorPosition(Console.WindowWidth - rightPadding, 0);
            ConsoleWrite(ConsoleColor.Yellow, btcOrders);
            ColumnBreak();
            //ConsoleWrite(ConsoleColor.DarkCyan, ExchangeManager.Exchanges.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInBTC)).ToString("N8"));
            ConsoleWrite(ConsoleColor.DarkCyan, btcTotal);
            ColumnBreak();
            //ConsoleWrite(ConsoleColor.DarkGreen, ExchangeManager.Exchanges.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInUSD)).ToString("C"));
            ConsoleWrite(ConsoleColor.DarkGreen, usdTotal);
        }
        static void DrawExchangeList()
        {
            // EXCHANGE HEADER
            Console.SetCursorPosition(0, row++);
            Console.ResetColor();
            Console.Write(String.Format("{0,-10} | {1,5} | {2,5} | {3,10} | {4,10} | {5,10} | {6,5} | {7,22} | {8,5}",
                                            " Exchange", "Tkrs", "Coins", "Orders", "Total BTC", "Total USD", "Err.", "Last Update", " Last Message"));
            PadRight(Console.WindowWidth - Console.CursorLeft);
            RowBreak(row++, '-', delimiterColor);
            // EXCHANGE LIST
            Console.ForegroundColor = ConsoleColor.White;
            foreach (ExchangeManager.Exchange exchange in ExchangeManager.Exchanges.OrderByDescending(item => item.BalanceList.Sum(balance => balance.TotalInBTC)))
            {
                Console.SetCursorPosition(1, row);
                string exchangeString = String.Format("{0,-10} | {1,5} | {2,5} | {3,10} | {4,10} | {5,10} | {6,5} | {7,22} | {8,5}",
                    exchange.Name,
                    exchange.TickerList.Count,
                    exchange.BalanceList.FindAll(e => e.Balance > 0).Count,
                    exchange.BalanceList.Sum(balance => balance.TotalInBTCOrders).ToString("N8"),
                    exchange.BalanceList.Sum(balance => balance.TotalInBTC).ToString("N8"),
                    exchange.BalanceList.Sum(balance => balance.TotalInUSD).ToString("C"),
                    exchange.ErrorCount,
                    exchange.LastUpdate,
                    exchange.LastMessage
                    );

                if (exchangeString.Length > Console.WindowWidth)
                {
                    // TRUNCATE
                    exchangeString = exchangeString.Substring(0, Console.WindowWidth);
                }
                else
                {
                    // PAD
                    Console.Write(exchangeString);
                    PadRight(Console.WindowWidth - exchangeString.Length);
                }
                row++;
            }
        }
        static void DrawMenu()
        {
            Console.SetCursorPosition(1, row++);
            ConsoleWrite(delimiterColor, "TOGGLE AUTO UPDATE");
            ColumnBreak();
            //Console.ForegroundColor = getExchangeTimerTypeActiveColor(ExchangeManager.ExchangeTimerType.BALANCES);
            ConsoleWrite(getExchangeTimerTypeActiveColor(ExchangeManager.ExchangeTimerType.BALANCES), "[B]alances");
            ColumnBreak();
            //Console.ForegroundColor = getExchangeTimerTypeActiveColor(ExchangeManager.ExchangeTimerType.BALANCES);
            ConsoleWrite(getExchangeTimerTypeActiveColor(ExchangeManager.ExchangeTimerType.TICKERS), "[T]ickers");
            ColumnBreak();
            //Console.ForegroundColor = getExchangeTimerTypeActiveColor(ExchangeManager.ExchangeTimerType.ORDERS);
            ConsoleWrite(getExchangeTimerTypeActiveColor(ExchangeManager.ExchangeTimerType.ORDERS), "[O]rders");
            ColumnBreak();
            //Console.ForegroundColor = getExchangeTimerTypeActiveColor(ExchangeManager.ExchangeTimerType.HISTORY);
            ConsoleWrite(getExchangeTimerTypeActiveColor(ExchangeManager.ExchangeTimerType.HISTORY), "[H]istory");
            Console.Write(new String(' ', Console.WindowWidth - Console.CursorLeft));
        }
        static void DrawConsole()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, row);
            int consoleHeight = (Console.WindowHeight - 3) - row;
            var messages = (from m in LogManager.MessageList where (m.type & PreferenceManager.preferences.MessageFlags) > 0 select m).Skip(Math.Max(0, LogManager.MessageList.Count() - consoleHeight));
            int emptyLines = 0;

            if (messages.Count() < consoleHeight)
            {
                emptyLines = consoleHeight - messages.Count();
            }

            foreach (var message in messages)
            {
                Console.SetCursorPosition(0, row);
                Console.ForegroundColor = getMessageTypeColor(message.type);

                string msg = String.Format("{0,-1}-> {1,-1}-> {2,-1}-> {3,-1}",
                    message.TimeStamp,
                    message.Source,
                    message.FunctionCall,
                    message.Message
                    );

                if (msg.Length > Console.WindowWidth)
                {
                    // TRUNCATE
                    msg = msg.Substring(0, Console.WindowWidth);
                }
                else
                {
                    // PAD
                    int padWidth = Console.WindowWidth - msg.Length;
                    msg += new String(' ', padWidth);
                }

                Console.Write(msg);
                row++;
            }
            // CLEAR LINES THAT MIGHT HAVE GARBAGE
            if (emptyLines > 0)
            {
                for (int i = 0; i < emptyLines; i++)
                {
                    RowBreak(row++, ' ', ConsoleColor.Black);
                }
            }
        }
        static void DrawFooter()
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 2);

            Console.ForegroundColor = getMessageTypeActiveColor(LogManager.LogMessageType.CONSOLE);
            Console.Write("[C]ONSOLE");
            ColumnBreak();

            Console.ForegroundColor = getMessageTypeActiveColor(LogManager.LogMessageType.DEBUG);
            Console.Write("[D]EBUG");
            ColumnBreak();

            Console.ForegroundColor = getMessageTypeActiveColor(LogManager.LogMessageType.EXCHANGE);
            Console.Write("[E]XCHANGE");
            ColumnBreak();

            Console.ForegroundColor = getMessageTypeActiveColor(LogManager.LogMessageType.OTHER);
            Console.Write("OTHE[R]");
            ColumnBreak();

            Console.ForegroundColor = getMessageTypeActiveColor(LogManager.LogMessageType.EXCEPTION);
            Console.Write("E[X]CEPTION");
            ColumnBreak();

            Console.ForegroundColor = getMessageTypeActiveColor(LogManager.LogMessageType.LOG);
            Console.Write("[L]OG");
            Console.Write(new String(' ', Console.WindowWidth - Console.CursorLeft));

            string date = DateTime.Now.ToLongTimeString();
            Console.SetCursorPosition(Console.WindowWidth - date.Length - 1, Console.WindowHeight - 2);
            ConsoleWrite(ConsoleColor.Cyan, date);
        }

        static void ConsoleWrite(ConsoleColor color, string text)
        {
            //ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            //Console.ForegroundColor = originalColor;
        }
        static void ColumnBreak()
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = delimiterColor;
            Console.Write(" | ");
            Console.ForegroundColor = originalColor;
        }
        static void PadRight(int length)
        {
            Console.Write(new String(' ', length));
        }
        static void RowBreak(int currentRow, char character, ConsoleColor color)
        {
            Console.SetCursorPosition(0, currentRow);
            Console.ForegroundColor = color;
            Console.Write(new String(character, Console.WindowWidth));
            Console.ResetColor();
        }
        #endregion Draw

        #region Getters
        static ConsoleColor getExchangeTimerTypeActiveColor(ExchangeManager.ExchangeTimerType type)
        {
            bool hasType = (PreferenceManager.preferences.TimerFlags & type) != ExchangeManager.ExchangeTimerType.NONE;

            if (hasType)
            {
                return ConsoleColor.White;
            }
            else
            {
                return ConsoleColor.DarkGray;
            }
        }
        static ConsoleColor getMessageTypeColor(LogManager.LogMessageType type)
        {
            switch (type)
            {
                case LogManager.LogMessageType.LOG:
                    return ConsoleColor.DarkGreen;

                case LogManager.LogMessageType.CONSOLE:
                    return ConsoleColor.Gray;

                case LogManager.LogMessageType.DEBUG:
                    return ConsoleColor.Yellow;

                case LogManager.LogMessageType.OTHER:
                    return ConsoleColor.DarkMagenta;

                case LogManager.LogMessageType.EXCEPTION:
                    return ConsoleColor.Red;

                case LogManager.LogMessageType.EXCHANGE:
                    return ConsoleColor.DarkCyan;

                default: return ConsoleColor.DarkGray;
            }
        }
        static ConsoleColor getMessageTypeActiveColor(LogManager.LogMessageType type)
        {
            bool hasType = (PreferenceManager.preferences.MessageFlags & type) != LogManager.LogMessageType.NONE;

            if (hasType)
            {
                return getMessageTypeColor(type);
            }
            else
            {
                return ConsoleColor.DarkGray;
            }
        }
        #endregion Getters
    }
}

/*
    #region DLL_IMPORTS
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
    #endregion DLL_IMPORTS
    */
