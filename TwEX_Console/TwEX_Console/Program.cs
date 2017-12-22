using System;
using System.Linq;
using System.Runtime.InteropServices;
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

            if (ExchangeManager.InitializePreferences())
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
                        case ConsoleKey.B:
                            LogManager.AddLogMessage("Program", "Run", "Updating All Balances", LogManager.LogMessageType.CONSOLE);
                            Task.Factory.StartNew(() => ExchangeManager.updateBalances());
                            break;

                        case ConsoleKey.T:
                            LogManager.AddLogMessage("Program", "Run", "Updating All Tickers", LogManager.LogMessageType.CONSOLE);
                            Task.Factory.StartNew(() => ExchangeManager.updateTickers());
                            break;

                        case ConsoleKey.L:
                            LogManager.messageFlags ^= LogManager.LogMessageType.LOG;
                            break;

                        case ConsoleKey.C:
                            //int types = (int)LogManager.messageFlags;
                            LogManager.messageFlags ^= LogManager.LogMessageType.CONSOLE;
                            break;

                        case ConsoleKey.D:
                            //int types = (int)LogManager.messageFlags;
                            LogManager.messageFlags ^= LogManager.LogMessageType.DEBUG;
                            break;

                        case ConsoleKey.E:
                            //int types = (int)LogManager.messageFlags;
                            LogManager.messageFlags ^= LogManager.LogMessageType.EXCHANGE;
                            break;

                        case ConsoleKey.O:
                            //int types = (int)LogManager.messageFlags;
                            LogManager.messageFlags ^= LogManager.LogMessageType.OTHER;
                            break;

                        case ConsoleKey.X:
                            //int types = (int)LogManager.messageFlags;
                            LogManager.messageFlags ^= LogManager.LogMessageType.EXCEPTION;
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
            //Console.ResetColor();
            Console.CursorVisible = false;
            row = 1;
            DrawHeader();
            RowBreak(row++, '#', delimiterColor);
            DrawExchangeList();
            RowBreak(row++, '#', delimiterColor);
            DrawMenu();
            RowBreak(row++, '-', delimiterColor);
            DrawConsole();
            DrawFooter();
            
        }
        public static void ConsoleWrite(ConsoleColor color, string text)
        {
            //ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            //Console.ForegroundColor = originalColor;
        }
        public static void ColumnBreak()
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = delimiterColor;
            Console.Write(" | ");
            Console.ForegroundColor = originalColor;
        }
        static void DrawFooter()
        {
            // FOOTER
            //Console.SetCursorPosition(0, Console.WindowHeight - 2);
            //Console.SetCursorPosition(0, Console.WindowHeight -2);
            //Console.ForegroundColor = delimiterColor;

            RowBreak(Console.WindowHeight - 3, '#', delimiterColor);
            //Console.WriteLine(new String('#', Console.WindowWidth));

            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            ConsoleWrite(delimiterColor, "UPDATE");
            ColumnBreak();
            ConsoleWrite(ConsoleColor.White, "[B]alances");
            ColumnBreak();
            ConsoleWrite(ConsoleColor.White, "[T]ickers");
            //Console.SetCursorPosition(0, 0);
        }
        static void DrawHeader()
        {
            Console.SetCursorPosition(0, 0);
            ConsoleWrite(ConsoleColor.Cyan, DateTime.Now.ToString());
            ColumnBreak();
            Console.Write(ExchangeManager.exchangeList.Count + " Exchanges");
            ColumnBreak();
            Console.Write(ExchangeManager.Tickers.Count + " Tickers");
            ColumnBreak();
            Console.Write(CoinMarketCap.Tickers.Count + " Market Caps");
            ColumnBreak();
            ConsoleWrite(ConsoleColor.DarkCyan, ExchangeManager.exchangeList.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInBTC)).ToString("N8"));
            ColumnBreak();
            ConsoleWrite(ConsoleColor.DarkGreen, ExchangeManager.exchangeList.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInUSD)).ToString("C") + " USD");
            
        }
        static void DrawConsole()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int spread = (Console.WindowHeight - 2) - row;
            var messages = LogManager.MessageList.Where(m => m.type != LogManager.LogMessageType.LOG).Skip(Math.Max(0, LogManager.MessageList.Count() - spread));

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

                Console.WriteLine(msg);
                row++;
            }
            // CLEAR LINES THAT MIGHT HAVE GARBAGE

        }
        static void DrawExchangeList()
        {
            // EXCHANGE HEADER
            Console.SetCursorPosition(0, row++);
            Console.ResetColor();
            Console.WriteLine(String.Format("{0,-10} | {1,5} | {2,5} | {3,10} | {4,10} | {5,5} | {6,5} | {7,5}", "Exchange", "Tkrs", "Coins", "Total BTC", "Total USD", "Errors", "Last Update", " Last Message"));
            RowBreak(row++, '-', delimiterColor);
            // EXCHANGE LIST
            Console.ForegroundColor = ConsoleColor.White;
            foreach (ExchangeManager.Exchange exchange in ExchangeManager.exchangeList.OrderByDescending(item => item.BalanceList.Sum(balance => balance.TotalInBTC)))
            {
                Console.SetCursorPosition(0, row);
                string exchangeLine = String.Format("{0,-10} | {1,5} | {2,5} | {3,10} | {4,10} | {5,5} | {6,5} | {7,5}",
                    exchange.Name,
                    exchange.TickerList.Count,
                    exchange.BalanceList.FindAll(e => e.Balance > 0).Count,
                    exchange.BalanceList.Sum(balance => balance.TotalInBTC).ToString("N8"),
                    exchange.BalanceList.Sum(balance => balance.TotalInUSD).ToString("C"),
                    exchange.ErrorCount,
                    exchange.LastUpdate,
                    exchange.LastMessage
                    );

                if (exchangeLine.Length > Console.WindowWidth)
                {
                    // TRUNCATE
                    exchangeLine = exchangeLine.Substring(0, Console.WindowWidth);
                }
                else
                {
                    // PAD
                    int padWidth = Console.WindowWidth - exchangeLine.Length;
                    exchangeLine += new String(' ', padWidth);
                    Console.WriteLine(exchangeLine);
                }

                row++;
            }
        }
        static void DrawMenu()
        {
            Console.SetCursorPosition(0, row++);
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
            Console.Write("[O]THER");
            ColumnBreak();

            Console.ForegroundColor = getMessageTypeActiveColor(LogManager.LogMessageType.EXCEPTION);
            Console.Write("E[X]CEPTION");
            ColumnBreak();

            Console.ForegroundColor = getMessageTypeActiveColor(LogManager.LogMessageType.LOG);
            Console.Write("[L]OG");

            int menuPadding = Console.WindowWidth - Console.CursorLeft;
            //Console.ForegroundColor = delimiterColor;
            Console.WriteLine(new String(' ', menuPadding));

        }
        public static void RowBreak(int row, char character, ConsoleColor color)
        {
            Console.SetCursorPosition(0, row);
            Console.ForegroundColor = color;
            Console.WriteLine(new String(character, Console.WindowWidth));
            Console.ResetColor();
        }
        #endregion Draw

        #region Getters
        private static ConsoleColor getMessageTypeColor(LogManager.LogMessageType type)
        {
            switch (type)
            {
                case LogManager.LogMessageType.LOG:
                    return ConsoleColor.DarkGreen;

                case LogManager.LogMessageType.CONSOLE:
                    return ConsoleColor.Gray;

                case LogManager.LogMessageType.DEBUG:
                    return ConsoleColor.DarkYellow;

                case LogManager.LogMessageType.OTHER:
                    return ConsoleColor.DarkMagenta;

                case LogManager.LogMessageType.EXCEPTION:
                    return ConsoleColor.Red;

                case LogManager.LogMessageType.EXCHANGE:
                    return ConsoleColor.DarkCyan;

                default: return ConsoleColor.DarkGray;
            }
        }
        private static ConsoleColor getMessageTypeActiveColor(LogManager.LogMessageType type)
        {
            bool hasType = (LogManager.messageFlags & type) != LogManager.LogMessageType.NONE;

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