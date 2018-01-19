using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TwEX_API.Controls;
using TwEX_API.Faucet;
using TwEX_API.Market;
using TwEX_API.Wallet;
using static TwEX_API.ExchangeManager;
using static TwEX_API.LogManager;
using static TwEX_API.Market.CoinMarketCap;
using static TwEX_API.Market.CryptoCompare;
using static TwEX_API.Market.TradingView;
using static TwEX_API.PreferenceManager;

namespace TwEX_API
{
    // -------------------------------
    public class ContentManager
    {
        #region Properties
        private static string Name = "ContentManager";

        //public static string FontIconUrl = "http://icons.iconarchive.com/icons/paomedia/small-n-flat/1024/file-font-icon.png";
        public static string CalculatorIconUrl = "http://files.softicons.com/download/system-icons/web0.2ama-icons-by-chrfb/png/256x256/Calculator.png";
        //public static string BalanceIconUrl = "http://www.iconarchive.com/download/i14513/icojoy/enjoyment/money.ico";
        public static string BalanceIconUrl = "https://i.pinimg.com/originals/22/dd/de/22ddde0fc220582cf3688beca1795683.jpg";
        public static string SymbolIconUrl = "https://cdn2.iconfinder.com/data/icons/bitcoin-and-mining/44/trade-512.png";
        public static string ArbitrageIconUrl = "https://orig00.deviantart.net/1028/f/2015/299/f/6/app_store_look_like_software_center_icon__1024__by_kayover-d9efmjt.png";
        public static string PreferenceIconUrl = "http://www.iconeasy.com/icon/png/System/Stainless/preferences.png";

        public static string WalletIconUrl = "https://cdn.iconscout.com/public/images/icon/premium/png-512/wallet-3a62a21639a59921-512x512.png";
        public static string AddWalletIconUrl = "https://cdn2.iconfinder.com/data/icons/finance-solid-icons-vol-3/48/112-256.png";

        public static string ExodusIconUrl = "https://www.exodus.io/favicon-32x32.png?v=oLLkoG3aJr";
        public static string ImportIconUrl = "http://files.softicons.com/download/toolbar-icons/mono-general-icons-2-by-custom-icon-design/png/128x128/import.png";
        public static string ExportIconUrl = "http://files.softicons.com/download/toolbar-icons/mono-general-icons-2-by-custom-icon-design/png/128x128/export.png";

        public static string FontIconUrl = "https://cdn0.iconfinder.com/data/icons/exempli_gratia/256/z_File_FONT.png";
        public static string FontIconDecrease = "https://glanmirekennels.com.au/wp-content/themes/glanmire-kennels/img/font-smaller.png";
        public static string FontIconIncrease = "https://glanmirekennels.com.au/wp-content/themes/glanmire-kennels/img/font-larger.png";

        public static string RefreshIcon = "https://cdn0.iconfinder.com/data/icons/huge-basic-icons/512/Refresh.png";
        #endregion

        #region Validators
        public static bool DoesUrlRespond(string url)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "DoesUrlRespond", ex.Message, LogMessageType.EXCEPTION);
                return false;
            }
        }
        #endregion

        #region Getters
        public static Bitmap GetIconByUrl(string url)
        {
            //LogManager.AddLogMessage(Name, "GetExchangeIcon", "getting fav icon : " + url, LogMessageType.DEBUG);
            Bitmap icon = new Bitmap(16, 16);
            using (Graphics gr = Graphics.FromImage(icon))
            {
                gr.Clear(Color.FromKnownColor(KnownColor.Window));
            }

            try
            {
                if (DoesUrlRespond(url))
                {
                    //LogManager.AddLogMessage(Name, "GetExchangeIcon", "URL RESPONSED trying to get favicon : " + url, LogMessageType.DEBUG);
                    Uri thisUrl = new Uri(url);
                    if (thisUrl.HostNameType == UriHostNameType.Dns)
                    {
                        //string iconUrl = "http://" + thisUrl.Host + "/favicon.ico";
                        //string iconUrl =
                        WebRequest req = WebRequest.Create(url);
                        WebResponse resp = req.GetResponse();
                        icon = new Bitmap(Image.FromStream(resp.GetResponseStream()));
                        resp.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "GetIconByUrl", ex.Message, LogMessageType.EXCEPTION);
            }
            return icon;
        }

        public static Image GetActiveIcon(bool active)
        {
            if (active)
            {
                return Properties.Resources.ConnectionStatus_ACTIVE;
            }
            else
            {
                return Properties.Resources.ConnectionStatus_ERROR;
            }
        }
        /*
        private Bitmap GetColorIcon(Color color, int width, int height)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, width, height);
                graph.FillRectangle(color, ImageSize);
            }
            return bmp;
        }
        */
        #endregion

        #region Functions
        public static Bitmap ResizeImage(Image image, int width, int height, bool color = true)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            /*
            if (!color)
            {
                Bitmap grImage = OCRManager.SetGrayscale(new Bitmap(destImage));
                destImage = grImage;
            }
            */
            return destImage;
        }
        #endregion
    }
    // -------------------------------
    public class ExchangeManager
    {
        #region Properties
        private static string Name { get; } = "ExchangeManager";
        public static string IconUrl { get; } = "https://coinmarketcap.com/static/img/CoinMarketCap.png";
        public static System.Timers.Timer timer = new System.Timers.Timer();

        // COLLECTIONS
        public static BlockingCollection<Exchange> Exchanges = new BlockingCollection<Exchange>();
        public static BlockingCollection<ExchangeBalance> Balances = new BlockingCollection<ExchangeBalance>();
        public static BlockingCollection<ExchangeTicker> Tickers = new BlockingCollection<ExchangeTicker>();
        public static ImageList symbolIconList = new ImageList();
        public static ImageList exchangeIconList = new ImageList();
        #endregion Properties

        #region Initialize      
        public static Boolean InitializeExchangeList()
        {
            List<string> list = getExchangeList();
            
            exchangeIconList.Images.Clear();
            exchangeIconList.ImageSize = new Size(32, 32);
            //WalletManager.Initialize();

            foreach (string name in list)
            {
                Exchange exchange = new Exchange() { Name = name };
                Type type = getExchangeType(exchange.Name);

                if (type != null)
                {
                    try
                    {
                        exchange.Url = type.GetProperty("Url", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                        exchange.IconUrl = type.GetProperty("IconUrl", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                        exchange.Icon = ContentManager.GetIconByUrl(exchange.IconUrl);
                        exchange.USDSymbol = type.GetProperty("USDSymbol", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                        exchange.TradingView = type.GetProperty("TradingView", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();

                        exchangeIconList.Images.Add(exchange.Name, exchange.Icon);
                        //LogManager.AddLogMessage(Name, "InitializeExchangeList", "type !+ null for " + exchange.SiteName + " | " + preferences.apiList.Count, LogManager.LogMessageType.DEBUG);

                        ExchangeApi api = PreferenceManager.preferences.ApiList.FirstOrDefault(a => a.exchange.ToLower() == exchange.Name.ToLower());
                        if (api != null)
                        {
                            PreferenceManager.SetExchangeApi(api);
                        }

                        Task.Factory.StartNew(() => type.InvokeMember("InitializeExchange",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
                    }
                    catch (Exception ex)
                    {
                        LogManager.AddLogMessage(Name, "InitializeExchangeList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                    }
                }
                else
                {
                    LogManager.AddLogMessage(Name, "InitializeExchangeList", "PROBLEM : type is NULL : " + exchange.Name, LogManager.LogMessageType.EXCHANGE);
                }

                Exchanges.Add(exchange);
            }

            WalletManager.Initialize();
            InitializeTimer();
            return true;
        }
        public static Boolean InitializeSymbolImageList()
        {
            symbolIconList.Images.Clear();
            //string path = @"c:\\Windows\\Loader\\Applications\\symbols\\";
            string path = PreferenceManager.WorkDirectory + "\\symbols\\";
            string[] filter = { ".png" };

            symbolIconList.ImageSize = new Size(32, 32);

            if (Directory.Exists(path))
            {
                // LOAD ITEMS
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] fileInfo = directoryInfo.GetFiles();
                ArrayList arrayList = new ArrayList();

                foreach (FileInfo fi in fileInfo)
                {
                    foreach (string s in filter)
                    {
                        if (s == fi.Extension)
                        {
                            string symbol = fi.Name.Split('.')[0];
                            Image img = Image.FromFile(fi.FullName);
                            symbolIconList.Images.Add(symbol, img);
                        }
                    }
                }
            }
            else
            {
                // CREATE FOLDER
                Directory.CreateDirectory(path);
            }
            return true;
        }
        #endregion Initialize

        #region Timer
        public static Boolean InitializeTimer()
        {
            timer.Interval = 60000;
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
            LogManager.AddLogMessage(Name, "InitializeTimer", "Exchange Timer Initialized & Started", LogManager.LogMessageType.EXCHANGE);
            timer.Start();
            return true;
        }
        private static void TimerTick(object sender, EventArgs e)
        {
            //LogManager.AddDebugMessage(thisClassName, "OnTimer_clockTick", "Tick:" + now.Minute);
            DateTime now = DateTime.Now;

            switch (now.Minute)
            {
                case 0:

                    //LogManager.AddLogMessage(thisClassName, "TimerTick", "Hourly Check : " + DateTime.Now, LogManager.LogMessageType.DEBUG);

                    if (now.Hour == 0)
                    {
                        //LogManager.AddLogMessage(thisClassName, "TimerTick", "ITS MIDNIGHT : " + DateTime.Now, LogManager.LogMessageType.DEBUG);
                    }
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
                    bool hasBalanceType = (preferences.TimerFlags & ExchangeTimerType.BALANCES) != ExchangeTimerType.NONE;
                    if (hasBalanceType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Exchange Balances", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => updateBalances());
                    }

                    bool hasWalletType = (preferences.TimerFlags & ExchangeTimerType.WALLETS) != ExchangeTimerType.NONE;
                    if (hasWalletType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Wallets", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => WalletManager.UpdateWallets());
                    }

                    bool hasEarnGGType = (preferences.TimerFlags & ExchangeTimerType.EARNGG) != ExchangeTimerType.NONE;
                    if (hasEarnGGType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Wallets", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => EarnGG.UpdateAccounts());
                        
                    }
                    break;

                default:
                    // DO THIS EVERY OTHER MINUTE NOT ON 5 INTERVAL
                    bool hasTickerType = (PreferenceManager.preferences.TimerFlags & ExchangeTimerType.TICKERS) != ExchangeTimerType.NONE;
                    if (hasTickerType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Exchange Tickers", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => updateTickers());
                        Task.Factory.StartNew(() => CoinMarketCap.updateTickers());
                        //Task.Factory.StartNew(() =>
                    }
                    break;
            }

            // EVERY MINUTE

        }
        #endregion

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
                        //Boolean isAsync = Convert.ToBoolean(type.GetProperty("isAsync", BindingFlags.Public | BindingFlags.Static).GetValue(null));
                        //string isAsync = type.GetProperty("isAsync", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                        //LogManager.AddLogMessage(Name, "getCurrencyList", "type is : " + type.Name + " | " + isAsync, LogManager.LogMessageType.DEBUG);
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

        public static List<ExchangeBalance> GetBalances()
        {
            List<ExchangeBalance> list = Balances.ToList();
            list.AddRange(WalletManager.GetWalletBalances());
            return list;
        }

        /// <summary>Gets an Exchange by its name</summary>
        public static Exchange getExchange(string name)
        {
            Exchange exchange = Exchanges.FirstOrDefault(item => item.Name == name);

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

        public static ExchangeApi getExchangeApi(string name)
        {
            ExchangeApi api = PreferenceManager.preferences.ApiList.FirstOrDefault(a => a.exchange.ToLower() == name.ToLower());

            if (api != null)
            {
                return api;
            }
            else
            {
                return new ExchangeApi() { exchange = name };
            }
        }

        public static bool getExchangeHasAPI(Exchange exchange)
        {
            ExchangeManager.ExchangeApi api = PreferenceManager.preferences.ApiList.FirstOrDefault(a => a.exchange.ToLower() == exchange.Name.ToLower());
            bool hasAPI = false;

            if (api != null)
            {
                if (api.key.Length > 0 && api.secret.Length > 0)
                {
                    hasAPI = true;
                }
            }
            return hasAPI;
        }

        /// <summary>Helper to get class name for exchanges ignoring case</summary>
        public static string getExchangeSiteName(string name)
        {
            Exchange exchange = Exchanges.FirstOrDefault(item => item.Name.ToLower() == name.ToLower());
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

            if (exchange != "CryptoCompare" && ticker != null)
            {
                //LogManager.AddLogMessage(Name, "getExchangeTicker", "ticker !null & Not CC : " + ticker.exchange + " | " + ticker.symbol + " | " + ticker.market + " | " + ticker.last);
                return ticker;
            }
            else
            {
                ExchangeTicker ccTicker = new ExchangeTicker();
                List<CryptoComparePrice> priceList = CryptoCompare.getPriceList(symbol, new string[] { market });

                if (priceList.Count > 0)
                {
                    //CryptoComparePrice price = priceList[0];
                    ccTicker.exchange = "CryptoCompare";
                    //ccTicker.exchange = exchange;
                    ccTicker.symbol = symbol;
                    ccTicker.market = market;
                    ccTicker.last = priceList[0].value;
                }
                //LogManager.AddLogMessage(Name, "getExchangeTicker", "ticker NULL or CC : " + ccTicker.exchange + " | " + ccTicker.symbol + " | " + ccTicker.market + " | " + ccTicker.last);
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

        /// <summary>Gets ExchangeTimer TYPE from TwEX_API.Exchange by name</summary>
        public static ExchangeTimerType getExchangeTimerType(string name)
        {
            return (ExchangeTimerType)Enum.Parse(typeof(ExchangeTimerType), name);
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

        public static Bitmap getExchangeIcon(string exchange)
        {
            Exchange item = Exchanges.FirstOrDefault(e => e.Name == exchange);
            if (item != null)
            {
                return item.Icon;
            }
            else
            {
                //return Properties.Resources.ConnectionStatus_DISABLED;
                return WalletManager.GetWalletIcon(exchange);
            }
        }

        public static Image GetSymbolIcon(string symbol)
        {
            Image image = Properties.Resources.ConnectionStatus_DISABLED;

            // check imagelist for exist
            if (symbolIconList.Images.ContainsKey(symbol.ToUpper()))
            {
                //Int32 index = symbolIconList.Images.IndexOfKey("symbol");
                return symbolIconList.Images[symbol];
            }
            else
            {
                // set it up for later
                try
                {
                    //CryptoCompareCoin coin = cryptoCompareCoinList.FirstOrDefault(listItem => listItem.Symbol == symbol);
                    CryptoCompareCoin coin = CryptoCompare.CoinList.FirstOrDefault(listItem => listItem.Name == symbol);

                    if (coin != null)
                    {
                        if (coin.ImageUrl.Length > 0)
                        {
                            string url = "https://www.cryptocompare.com" + coin.ImageUrl;
                            WebClient wc = new WebClient();
                            byte[] bytes = wc.DownloadData(url);
                            MemoryStream ms = new MemoryStream(bytes);
                            Image img = Image.FromStream(ms);

                            if (symbol.Contains("*"))
                            {
                                symbol = symbol.Replace("*", "");
                            }

                            symbolIconList.Images.Add(symbol.ToUpper(), img);
                            img.Save(PreferenceManager.WorkDirectory + "\\symbols\\" + symbol.ToUpper() + ".png", ImageFormat.Png);

                            return img;
                        }
                        else
                        {
                            return image;
                        }
                    }
                    else
                    {
                        return image;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "GetSymbolIcon", symbol + " | " + ex.Message, LogMessageType.EXCEPTION);
                    // USE GENERIC ICON
                    return image;
                }
            }
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
                    foreach (Exchange exchange in Exchanges)
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

        public static Decimal GetPriceOfSymbol(string exchange, string market, string symbol)
        {
            Decimal value = 0;
            //LogManager.AddLogMessage(Name, "GetPriceOfSymbol", "exchange=" + exchange + " | market=" + market + " | symbol=" + symbol);

            try
            {
                ExchangeTicker ticker = Tickers.FirstOrDefault(item => item.exchange == exchange && item.market == market && item.symbol == symbol);
                if (ticker != null)
                {
                    value = ticker.last;
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "GetPriceOfSymbol", ex.Message, LogMessageType.EXCEPTION);
            }
            //LogManager.AddLogMessage(Name, "GetPriceOfSymbol", "exchange=" + exchange + " | market=" + market + " | symbol=" + symbol + " | value=" + value);
            return value;
        }

        public static List<ExchangeTicker> GetPriceWatchlist(string market, string symbol)
        {
            //LogManager.AddLogMessage(Name, "GetPriceWatchlist", "market=" + market + " | " + symbol, LogMessageType.DEBUG);
            List<ExchangeTicker> list = new List<ExchangeTicker>();

            try
            {
                foreach (Exchange exchange in Exchanges)
                {
                    ExchangeTicker newItem = new ExchangeTicker();
                    newItem.exchange = exchange.Name;
                    newItem.market = market;
                    newItem.symbol = symbol;
                    //newItem.price = GetExchangeUSDValueBySymbol(exchange.SiteName, symbol);
                    newItem.last = GetPriceOfSymbol(exchange.Name, market, symbol);

                    list.Add(newItem);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "GetPriceWatchlist", ex.Message, LogMessageType.EXCEPTION);
            }
            return list.OrderByDescending(item => item.last).ToList();
        }

        #endregion Getters

        #region Processors
        public static void processBalance(ExchangeBalance balance)
        {
            //ExchangeBalance listItem = balanceList.FirstOrDefault(b => b.Exchange == balance.Exchange && b.Symbol == balance.Symbol);
            ExchangeBalance listItem = Balances.FirstOrDefault(b => b.Exchange == balance.Exchange && b.Symbol == balance.Symbol);

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
                Balances.Add(balance);
                //LogManager.AddLogMessage(Name, "processBalance", "Added " + balance.Symbol + " for " + balance.Exchange, LogManager.LogMessageType.DEBUG);
            }
            /*
            if (exchangeEditorControl != null)
            {
                exchangeEditorControl.UpdateUI();
            }
            */
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
            /*
            if (exchangeEditorControl != null)
            {
                exchangeEditorControl.UpdateUI();
            }
            */
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
                            Task.Factory.StartNew(() => type.InvokeMember("updateExchangeBalanceList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
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
                    foreach (Exchange exchange in Exchanges)
                    {
                        Type type = getExchangeType(exchange.Name);
                        if (type != null)
                        {
                            //LogManager.AddLogMessage(Name, "updateExchangeBalanceList", "type is : " + type.Name);
                            var api = type.GetProperty("Api", BindingFlags.Public | BindingFlags.Static).GetValue(null);

                            if (api != null)
                            {
                                Task.Factory.StartNew(() => type.InvokeMember("updateExchangeBalanceList",
                                                            BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                                            null,
                                                            type,
                                                            null));
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

            //updateControls();
            FormManager.UpdateForms();
        }



        /// <summary>Updates TICKER COLLECTION for an exchange or does ALL if no name specified</summary>
        public static void updateTickers(string exchangeName = "")
        {
            //CoinMarketCap.updateTickers();

            try
            {
                if (exchangeName.Length > 0)
                {
                    Type type = getExchangeType(exchangeName);
                    if (type != null)
                    {
                        //LogManager.AddLogMessage(Name, "updateExchangeTickerList", "type is : " + type.Name);
                        Task.Factory.StartNew(() => type.InvokeMember("updateExchangeTickerList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
                    }
                    else
                    {
                        LogManager.AddLogMessage(Name, "updateExchangeTickerList", "type is NULL : " + exchangeName, LogManager.LogMessageType.DEBUG);
                    }
                }
                else
                {
                    foreach (Exchange exchange in Exchanges)
                    {
                        Type type = getExchangeType(exchange.Name);
                        if (type != null)
                        {
                            //LogManager.AddLogMessage(Name, "updateExchangeTickerList", "type is : " + type.Name);
                            Task.Factory.StartNew(() => type.InvokeMember("updateExchangeTickerList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
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

            //updateControls();
            FormManager.UpdateForms();
        }
        #endregion Updaters

        #region DataModels
        public class Exchange
        {
            public string Name { get; set; }
            public Type type { get { return getExchangeType(Name); } }
            public string Url { get; set; }
            public string IconUrl { get; set; }
            public string USDSymbol { get; set; }
            public string TradingView { get; set; }
            public Bitmap Icon { get; set; }
            // TOTALS
            public int CoinCount { get { return BalanceList.FindAll(e => e.Balance > 0).Count; } }
            public Decimal TotalInBTC { get { return BalanceList.Sum(balance => balance.TotalInBTC); } }
            public Decimal TotalInBTCOrders { get { return BalanceList.Sum(balance => balance.TotalInBTCOrders); } }
            public Decimal TotalInUSD { get { return BalanceList.Sum(balance => balance.TotalInUSD); } }
            // COLLECTIONS
            public List<ExchangeBalance> BalanceList { get { return ExchangeManager.Balances.Where(balance => balance.Exchange == Name).ToList(); } }
            public List<ExchangeTicker> TickerList { get { return ExchangeManager.Tickers.Where(ticker => ticker.exchange == Name).ToList(); } }
            // STATUS
            public int ErrorCount { get { return Convert.ToInt32(type.GetProperty("ErrorCount", BindingFlags.Public | BindingFlags.Static).GetValue(null)); } }
            //public DateTime LastUpdate { get { return Convert.ToDateTime(type.GetProperty("LastUpdate", BindingFlags.Public | BindingFlags.Static).GetValue(null)); } }
            public DateTime LastUpdate { get { return Convert.ToDateTime(type.GetProperty("LastUpdate", BindingFlags.Public | BindingFlags.Static).GetValue(null)).ToUniversalTime(); } }
            public string LastMessage { get { return type.GetProperty("LastMessage", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString(); } }
        }
        public class ExchangeApi
        {
            public string exchange { get; set; }
            public string key { get; set; }
            public string secret { get; set; }
            // only for GDAX
            public string passphrase { get; set; }
        }
        public class ExchangeBalance
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
            public string Exchange { get; set; }
            public string Wallet { get; set; }

            public Decimal Balance { get; set; } = 0;
            public Decimal OnOrders { get; set; } = 0;

            public Decimal TotalInBTC { get; set; } = 0;
            public Decimal TotalInBTCOrders { get; set; } = 0;
            public Decimal TotalInUSD { get; set; } = 0;
        }
        /*
        public class ExchangePrice
        {
            public string symbol { get; set; }
            public string market { get; set; }
            public string exchange { get; set; }
            public Decimal price { get; set; }
            // CALCULATOR
            public Decimal value { get; set; }
        }
        */
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

        #region Enums
        [Flags]
        public enum ExchangeTimerType
        {
            NONE = 0,           //0
            BALANCES = 1 << 0,  //1
            TICKERS = 1 << 1,   //2
            ORDERS = 1 << 2,    //4
            HISTORY = 1 << 3,   //8
            WALLETS = 1 << 4,   //16
            EARNGG = 1 << 5     //32
        }
        #endregion Enums
    }
    // -------------------------------
    public class FormManager
    {
        #region Properties
        private static string Name = "FormManager";
        public static Form mainForm;
        public static FormToolStripControl mainToolStrip;
        public static ArbitrageManagerControl arbitrageManagerControl;
        public static ExchangeEditorControl exchangeEditorControl;
        //public static ToolStrip toolStrip;
        #endregion

        #region Validators
        public static bool IsFormOpen(string name)
        {
            bool exists = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == name)
                {
                    exists = true;
                }
            }
            return exists;
        }
        #endregion

        #region Getters
        public static Form GetFormByName(string name)
        {
            Form form = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == name)
                {
                    form = item;
                }
            }
            return form;
        }
        public static Bitmap GetFormIcon(string name)
        {   
            switch (name)
            {
                case "ArbitrageManager":
                    return ContentManager.GetIconByUrl(ContentManager.ArbitrageIconUrl);

                case "BalanceManager":
                    //return ContentManager.ResizeImage(ContentManager.GetIconByUrl(ContentManager.BalanceIconUrl), 32, 32);
                    return ContentManager.GetIconByUrl(ContentManager.BalanceIconUrl);

                case "CoinCalculator":
                    return ContentManager.GetIconByUrl(ContentManager.CalculatorIconUrl);

                case "CryptoCompare":
                    return ContentManager.GetIconByUrl(CryptoCompare.IconUrl);

                case "CoinMarketCap":
                    return ContentManager.GetIconByUrl(CoinMarketCap.IconUrl);

                case "EarnGGManager":
                    //return ContentManager.ResizeImage(ContentManager.GetIconByUrl(ExchangeManager.IconUrl), 32, 32);
                    return ContentManager.GetIconByUrl(EarnGG.IconUrl);

                case "ExchangeEditor":
                    //return ContentManager.ResizeImage(ContentManager.GetIconByUrl(ExchangeManager.IconUrl), 32, 32);
                    return ContentManager.GetIconByUrl(ExchangeManager.IconUrl);

                case "LogManager":
                    return ContentManager.GetIconByUrl(LogManager.IconUrl);

                case "TradingView":
                    return ContentManager.GetIconByUrl(TradingView.IconUrl);

                case "WalletManager":
                    return ContentManager.GetIconByUrl(ContentManager.WalletIconUrl);

                default:
                    return Properties.Resources.ConnectionStatus_DISABLED;
            }         
        }
        #endregion

        #region Functions
        public static void OpenForm(string name, string text)
        {
            Form targetForm = GetFormByName(name);
            
            if (targetForm == null)
            {
                if (name != "ImportPreferences" && name != "ExportPreferences")
                {
                    Form form = new Form() { Size = new Size(950, 550), Name = name, Text = text, Icon = Icon.FromHandle(new Bitmap(GetFormIcon(name)).GetHicon()) };
                    form.Show();

                    FormPreference preference = preferences.FormPreferences.FirstOrDefault(item => item.Name == form.Name);
                    if (preference != null)
                    {
                        //LogManager.AddLogMessage(Name, "toolStripButton_Form_Click", "FOUND : " + preference.Name + " | " + preference.Font.FontFamily + " | " + preference.Size + " | " + preference.Location);
                        form.SetBounds(preference.Location.X, preference.Location.Y, preference.Size.Width, preference.Size.Height);
                        form.Font = new Font(preference.Font.FontFamily, preference.Font.Size, preference.Font.Style);
                    }
                    else
                    {
                        AddLogMessage(Name, "toolStripButton_Form_Click", "NOT FOUND ADDING : " + form.Name + " | " + form.Location);
                        UpdateFormPreferences(form, true);
                    }

                    form.LocationChanged += delegate { UpdateFormPreferences(form, true); };
                    form.SizeChanged += delegate { UpdateFormPreferences(form, true); };
                    form.FontChanged += delegate { UpdateFormPreferences(form, true); };
                    form.FormClosing += delegate { UpdateFormPreferences(form, false); };
                    form.FormClosed += delegate { UpdateToolStrip(); };

                    switch (name)
                    {
                        case "ArbitrageManager":
                            form.Controls.Add(new ArbitrageManagerControl() { Dock = DockStyle.Fill });
                            break;

                        case "BalanceManager":
                            form.Controls.Add(new BalanceManagerControl() { Dock = DockStyle.Fill });
                            break;

                        case "CoinCalculator":
                            form.Controls.Add(new CoinCalculatorControl() { Dock = DockStyle.Fill });
                            break;

                        case "CryptoCompare":
                            form.Controls.Add(new CryptoCompareWidgetEditorControl() { Dock = DockStyle.Fill });
                            break;

                        case "CoinMarketCap":
                            form.Controls.Add(new CoinMarketCapControl() { Dock = DockStyle.Fill });
                            break;

                        case "EarnGGManager":
                            form.Controls.Add(new EarnGGManagerControl() { Dock = DockStyle.Fill });
                            break;

                        case "ExchangeEditor":
                            form.Controls.Add(new ExchangeEditorControl() { Dock = DockStyle.Fill });
                            break;

                        case "LogManager":
                            form.FormClosing += delegate { LogManager.logManagerControl = null; };
                            form.Controls.Add(new LogManagerControl() { Dock = DockStyle.Fill });
                            break;

                        case "TradingView":
                            form.Controls.Add(new TradingViewManagerControl() { Dock = DockStyle.Fill });
                            break;

                        case "WalletManager":
                            form.Controls.Add(new WalletManagerControl() { Dock = DockStyle.Fill });
                            break;

                        default:
                            LogManager.AddLogMessage(Name, "OpenForm", "NOTE DEFINED!!! : " + name, LogMessageType.DEBUG);
                            break;
                    }
                }
                else
                {
                    switch (name)
                    {
                        case "ExportPreferences":
                            PreferenceManager.ExportPreferences();
                            break;

                        case "ImportPreferences":
                            PreferenceManager.ImportPreferences();
                            break;

                        default:
                            LogManager.AddLogMessage(Name, "OpenForm", "NOTE DEFINED!!! : " + name, LogMessageType.DEBUG);
                            break;
                    }
                }
            }
            else
            {
                /*
                if (targetForm.WindowState == FormWindowState.Minimized)
                {
                    targetForm.WindowState = FormWindowState.Normal;
                }

                if (targetForm.InvokeRequired)
                {
                    StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate();
                    targetForm.Invoke(d, new object[] { });
                }
                else
                {
                    //this.textBox1.Text = text;
                    targetForm.Activate();
                }
                targetForm.Activate();
                */
            }
            //UpdateUI();
            UpdateToolStrip();
        }
        public static void RestoreForms()
        {
            foreach (FormPreference pref in preferences.FormPreferences)
            {
                //LogManager.AddLogMessage(Name, "InitializePreferences", pref.Name + " | " + pref.Open, LogMessageType.DEBUG);
                if (pref.Open)
                {
                    FormManager.OpenForm(pref.Name, pref.Name);
                }
            }
        }
        #endregion

        #region Updaters
        public static void UpdateForms()
        {
            /*
            if (exchangeEditorControl != null)
            {
                exchangeEditorControl.UpdateUI();
            }
            */
            foreach(Form form in Application.OpenForms)
            {
                /*
                type.InvokeMember("InitializeExchange",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
                                */
                //form.Refresh();
            }

        }
        public static void UpdateArbitrageManager()
        {
            if (arbitrageManagerControl != null)
            {
                arbitrageManagerControl.SetWatchlist();
            }
            UpdatePreferencesFile();
        }
        public static void UpdateToolStrip()
        {
            if (mainToolStrip != null)
            {
                mainToolStrip.UpdateUI();
            }
        }

       // delegate void StringArgReturningVoidDelegate(string text);
        #endregion
    }
    // -------------------------------
    public class LogManager
    {
        #region Properties
        public static Boolean ConsoleLogging = true;
        const string _readPrompt = "TwEX Console : ";
        public static string IconUrl { get; } = "https://image.flaticon.com/icons/png/512/28/28822.png";
        public static StreamWriter logFile;
        public static LogManagerControl logManagerControl;
        public static BlockingCollection<LogMessage> MessageList = new BlockingCollection<LogMessage>();
        #endregion

        #region Initialize
        public static Boolean InitializeLogManager()
        {
            // CLEAR LOGFILE
            File.Create("TwEX_Log.txt").Close();
            return true;
        }
        #endregion

        #region Functions
        public static void AddLogMessage(String source, String functionCall, String message, LogMessageType type = LogMessageType.LOG)
        {
            LogMessage logMessage = new LogMessage();
            logMessage.TimeStamp = DateTime.Now;
            logMessage.Source = source;
            logMessage.FunctionCall = functionCall;
            logMessage.Message = message;
            logMessage.type = type;
            //LogMessageList.Insert(0, logMessage);
            MessageList.Add(logMessage);

            if (ConsoleLogging == true && source != "LogManager")
            {
                WriteToLog(logMessage.ToString());
            }

            if (logManagerControl != null)
            {
                //logManagerControl.Refresh();
                //logManagerControl.Update();
                logManagerControl.UpdateUI();
            }

        }
        public static string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                //MessageBox.Show("Error");
                LogManager.AddLogMessage("LogManager", "StripHTML", "ERROR :" + source, LogMessageType.EXCEPTION);
                return source;
            }
        }
        public static void WriteToLog(string message)
        {
            try
            {

                if (!File.Exists("TwEX_Log.txt"))
                {
                    logFile = new StreamWriter("TwEX_Log.txt");
                }
                else
                {
                    logFile = File.AppendText("TwEX_Log.txt");
                }

                //logFile.WriteLine(DateTime.Now);
                logFile.WriteLine(message);
                //logFile.WriteLine();

                //Console.WriteLine("Log file saved successfully!");

                logFile.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                AddLogMessage("LogManager", "WriteToLog", message + " | " + ex.Message, LogMessageType.EXCEPTION);
                //goto A;
            }
        }
        public static void ToggleMessageFlag(LogMessageType type)
        {
            PreferenceManager.preferences.MessageFlags ^= type;
            PreferenceManager.UpdatePreferencesFile();
        }
        public static bool getMessageTypeActive(string name)
        {
            LogMessageType type = (LogMessageType)System.Enum.Parse(typeof(LogMessageType), name);
            bool hasType = (PreferenceManager.preferences.MessageFlags & type) != LogManager.LogMessageType.NONE;

            if (hasType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Console
        public static string Execute(string command)
        {
            // We'll make this more interesting shortly:
            return string.Format("Executed the {0} Command", command);


        }
        public static void WriteToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                //Console.SetCursorPosition(0, Console.WindowHeight);
                Console.SetCursorPosition(0, Console.BufferHeight - 2);
                Console.WriteLine(message);
            }
        }
        public static string ReadFromConsole(string promptMessage = "")
        {
            // Show a prompt, and get input:
            Console.SetCursorPosition(0, Console.BufferHeight - 1);
            Console.Write(_readPrompt + promptMessage);
            return Console.ReadLine();
        }
        #endregion

        #region Encrypt/Decrypt
        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="originalString">The original string.</param>
        /// <returns>The encrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown when the original string is null or empty.</exception>
        public static string Encrypt(string originalString)
        {
            try
            {
                if (String.IsNullOrEmpty(originalString))
                {
                    AddLogMessage("Encryptor", "Encrypt", "NULL string provided", LogMessageType.EXCEPTION);
                }

                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(ASCIIEncoding.ASCII.GetBytes("TwEX_API"), ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName)), CryptoStreamMode.Write);
                StreamWriter writer = new StreamWriter(cryptoStream);
                writer.Write(originalString);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();

                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            catch (Exception ex)
            {
                AddLogMessage("Encryptor", "Encrypt", ex.Message, LogMessageType.EXCEPTION);
                return ex.Message;
            }
        }

        /// <summary>
        /// Decrypt a crypted string.
        /// </summary>
        /// <param name="cryptedString">The crypted string.</param>
        /// <returns>The decrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown when the crypted string is null or empty.</exception>
        public static string Decrypt(string cryptedString)
        {
            try
            {
                if (String.IsNullOrEmpty(cryptedString))
                {
                    //throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
                    AddLogMessage("Decryptor", "Decrypt", "NULL string provided", LogMessageType.EXCEPTION);
                }

                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
                //CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
                //CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName), ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName)), CryptoStreamMode.Read);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(ASCIIEncoding.ASCII.GetBytes("TwEX_API"), ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName)), CryptoStreamMode.Read);
                //ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName)
                StreamReader reader = new StreamReader(cryptoStream);

                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                AddLogMessage("Decryptor", "Decrypt", ex.Message, LogMessageType.EXCEPTION);
                return ex.Message;
            }



        }
        #endregion

        #region Enums
        [Flags]
        public enum LogMessageType
        {
            [Description("Black")]
            NONE = 0,           //0

            [Description("Gray")]
            CONSOLE = 1 << 0,   //1

            [Description("Yellow")]
            DEBUG = 1 << 1,     //2

            [Description("DarkCyan")]
            EXCHANGE = 1 << 2,  //4

            [Description("Red")]
            EXCEPTION = 1 << 3, //8

            [Description("DarkMagenta")]
            OTHER = 1 << 4,     //16

            [Description("DarkGreen")]
            LOG = 1 << 5        //32
        }
        #endregion

        #region DataModels
        public class LogMessage
        {
            public DateTime TimeStamp { get; set; }
            public string Source { get; set; }
            public string FunctionCall { get; set; }
            public string Message { get; set; }
            public LogMessageType type { get; set; }

            public override string ToString()
            {
                return TimeStamp.ToString() + " | " + type + " | " + Source + " | " + FunctionCall + " | " + Message;
            }
        }
        #endregion
    }
    // -------------------------------
    public class PreferenceManager
    {
        #region Properties
        private static string Name { get; } = "PreferencesManager";
        public static string WorkDirectory = string.Empty;
        public static Preferences preferences = new Preferences();
        // COLORS
        public static bool NightMode = false;

        public static Color BackgroundColor_green = Color.LightGreen;
        public static Color BackgroundColor_red = Color.LightPink;
        public static Color BackgroundColor_yellow = Color.LightGoldenrodYellow;
        public static Color BackgroundColor_browser = Color.White;
        public static Color BackgroundColor_form = Color.White;
        public static Color BackgroundColor_text = Color.Black;

        public static Color BackgroundColor_header = Color.LightGray;
        public static Color BackgroundColor_headerText = Color.DarkGray;
        #endregion

        #region Initialize
        public static Boolean LoadPreferences()
        {
            string path = Assembly.GetExecutingAssembly().CodeBase;
            string targetPath = Path.GetDirectoryName(path);
            WorkDirectory = new Uri(targetPath).LocalPath;

            string iniPath = WorkDirectory + "\\Preferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                preferences = JsonConvert.DeserializeObject<Preferences>(json);
                AddLogMessage(Name, "InitializePreferences", "PREFERENCES INITIALIZED : " + preferences.FormPreferences.Count + " FORMS", LogManager.LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "InitializePreferences", "Preferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferencesFile();
            }
            return true;
        }
        public static Boolean SetPreferenceSnapshots()
        {
            AddLogMessage(Name, "InitializePreferences", "PREFERENCES INITIALIZED : " + preferences.ApiList.Count + " APIS", LogMessageType.LOG);
            AddLogMessage(Name, "InitializePreferences", "PREFERENCES INITIALIZED : " + preferences.SymbolWatchList.Count + " Symbols In Watchlist", LogMessageType.LOG);
            
            AddLogMessage(Name, "InitializePreferences", "PREFERENCES INITIALIZED : " + preferences.Balances.Count + " Balances", LogMessageType.LOG);
            if (preferences.Balances.Count > 0)
            {
                Balances = new BlockingCollection<ExchangeBalance>(new ConcurrentQueue<ExchangeBalance>(preferences.Balances));
            }

            AddLogMessage(Name, "InitializePreferences", "PREFERENCES INITIALIZED : " + preferences.Tickers.Count + " Tickers", LogMessageType.LOG);
            if (preferences.Tickers.Count > 0)
            {
                ExchangeManager.Tickers = new BlockingCollection<ExchangeTicker>(new ConcurrentQueue<ExchangeTicker>(preferences.Tickers));
            }

            AddLogMessage(Name, "InitializePreferences", "PREFERENCES INITIALIZED : " + preferences.CoinMarketCapTickers.Count + " Market Cap Tickers", LogMessageType.LOG);
            if (preferences.CoinMarketCapTickers.Count > 0)
            {
                CoinMarketCap.Tickers = new BlockingCollection<CoinMarketCapTicker>(new ConcurrentQueue<CoinMarketCapTicker>(preferences.CoinMarketCapTickers));
            }

            AddLogMessage(Name, "InitializePreferences", "PREFERENCES INITIALIZED : " + preferences.Wallets.Count + " Wallets", LogMessageType.LOG);
            if (preferences.Wallets.Count > 0)
            {
                WalletManager.Wallets = preferences.Wallets;
            }

            AddLogMessage(Name, "InitializePreferences", "PREFERENCES INITIALIZED : " + preferences.EarnGGAccounts.Count + " EarnGG APIS", LogMessageType.LOG);
            if (preferences.EarnGGAccounts.Count > 0)
            {
                EarnGG.Accounts = preferences.EarnGGAccounts;
            }
            return true;
        }
        public static Boolean InitializePreferences()
        {
            if (LoadPreferences())
            {
                if (SetPreferenceSnapshots())
                {
                    return true;
                }
                else
                {
                    return false;
                }       
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ExchangeAPI
        public static void UpdateExchangeApi(ExchangeApi api)
        {
            ExchangeApi match = PreferenceManager.preferences.ApiList.FirstOrDefault(item => item.exchange.ToLower() == api.exchange.ToLower());

            if (match == null)
            {
                PreferenceManager.preferences.ApiList.Add(api);
                //LogManager.AddLogMessage(Name, "AddExchangeApi", "Added API for " + api.exchange, LogManager.LogMessageType.DEBUG);

            }
            else
            {
                //LogManager.AddLogMessage(Name, "AddExchangeApi", api.exchange + " Already Exists in API List - Replacing Values");
                match.key = api.key;
                match.secret = api.secret;
                match.passphrase = api.passphrase;
            }
            UpdatePreferencesFile();
        }
        public static void RemoveExchangeApi(string exchange)
        {
            ExchangeApi match = PreferenceManager.preferences.ApiList.FirstOrDefault(item => item.exchange.ToLower() == exchange.ToLower());

            if (match != null)
            {
                LogManager.AddLogMessage(Name, "RemoveExchangeApi", "Removing " + exchange + " from API List", LogManager.LogMessageType.DEBUG);
                PreferenceManager.preferences.ApiList.Remove(match);
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
        #endregion

        #region ImportExport
        public static void ExportPreferences()
        {
            string iniPath = WorkDirectory + "\\Preferences_export.ini";
            //LogManager.AddLogMessage(Name, "ExportPreferences", "Exporting to iniPath - " + iniPath, LogManager.LogMessageType.DEBUG);
            if (UpdatePreferenceSnapshots())
            {
                string json = JsonConvert.SerializeObject(preferences);
                //File.WriteAllText(@iniPath, json);
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "TwEXport.txt";
                save.Filter = "Text File | *.txt";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(save.OpenFile());
                    writer.WriteLine(json);
                    writer.Dispose();
                    writer.Close();
                }
            }
        }
        public static Boolean ImportPreferences()
        {
            
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string filename = openFileDialog.FileName;
                            string text = File.ReadAllText(filename);
                            preferences = JsonConvert.DeserializeObject<Preferences>(text.ToString());
                            LogManager.AddLogMessage(Name, "InitializePreferences", "PREFERENCES IMPORTED : " + preferences.ApiList.Count + " APIS", LogManager.LogMessageType.LOG);
                            if (SetPreferenceSnapshots())
                            {
                                UpdatePreferencesFile();
                            }                        
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "ImportPreferences", ex.Message, LogManager.LogMessageType.EXCEPTION);
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region ArbitrageWatchList
        public static void AddArbitrageWatchListItem(string symbol, string market)
        {
            ExchangeTicker listItem = preferences.ArbitragePreferences.ArbitrageWatchList.Find(item => item.market == market && item.symbol == symbol);
            if (listItem == null)
            {
                ExchangeTicker newItem = new ExchangeTicker();
                newItem.market = market;
                newItem.symbol = symbol;
                preferences.ArbitragePreferences.ArbitrageWatchList.Add(newItem);
                FormManager.UpdateArbitrageManager();
            }
        }
        public static void RemoveWatchlistItem(string market, string symbol)
        {
            ExchangeTicker listItem = preferences.ArbitragePreferences.ArbitrageWatchList.Find(item => item.market == market && item.symbol == symbol);
            if (listItem != null)
            {
                preferences.ArbitragePreferences.ArbitrageWatchList.Remove(listItem);
                FormManager.UpdateArbitrageManager();
            }
        }
        public static void MoveWatchlistItem(string market, string symbol, string direction)
        {
            //ExchangePrice listItem = symbolPriceLists.Find(item => item.market == market && item.symbol == symbol);
            int index = preferences.ArbitragePreferences.ArbitrageWatchList.FindIndex(item => item.market == market && item.symbol == symbol);

            if (index != -1)
            {

                if (direction == "up")
                {
                    if (index > 0)
                    {
                        preferences.ArbitragePreferences.ArbitrageWatchList.Move(index, MoveDirection.Up);
                    }

                }
                else
                {
                    if (index < preferences.ArbitragePreferences.ArbitrageWatchList.Count - 1)
                    {
                        preferences.ArbitragePreferences.ArbitrageWatchList.Move(index, MoveDirection.Down);
                    }
                }
                FormManager.UpdateArbitrageManager();
            }

        }
        #endregion

        #region SymbolWatchList
        public static void AddSymbolToWatchlist(string symbol)
        {
            if (!preferences.SymbolWatchList.Contains(symbol.ToUpper()))
            {
                preferences.SymbolWatchList.Add(symbol.ToUpper());
            }
            UpdatePreferencesFile();
        }
        public static void RemoveSymbolFromWatchlist(string symbol)
        {
            preferences.SymbolWatchList.Remove(symbol);
            UpdatePreferencesFile();
        }
        #endregion

        #region Flags
        public static void toggleTimerPreference(ExchangeTimerType type)
        {
            preferences.TimerFlags ^= type;
            UpdatePreferencesFile();
        }
        #endregion

        #region Updaters
        public static void UpdateFormPreferences(Form form, bool open)
        {
            //LogManager.AddLogMessage(Name, "UpdateFormPreferences", "form : " + form.Name + " | " + form.Font.FontFamily + " | " + form.Size + " | " + form.Location, LogMessageType.DEBUG);
            FormPreference prefs = preferences.FormPreferences.FirstOrDefault(item => item.Name == form.Name);

            if (prefs != null)
            {
                //prefs.Location = form.Location;
                prefs.Location = new Point(form.Location.X, form.Location.Y);
                //prefs.Size = form.Size;
                prefs.Size = new Size(form.Size.Width, form.Size.Height);
                //prefs.Font = form.Font;
                //public Font defaultFont = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                prefs.Font = new Font(form.Font.FontFamily, form.Font.Size, form.Font.Style);
                prefs.Open = open;
            }
            else
            {
                preferences.FormPreferences.Add(new FormPreference() { Name = form.Name, Location = form.Location, Size = form.Size, Font = form.Font, Open = open });
            }
            UpdatePreferencesFile();
        }
        public static bool UpdatePreferenceSnapshots()
        {
            preferences.Balances = Balances.ToList();
            preferences.Tickers = ExchangeManager.Tickers.ToList();
            preferences.CoinMarketCapTickers = CoinMarketCap.Tickers.ToList();
            preferences.Wallets = WalletManager.Wallets.ToList();
            preferences.EarnGGAccounts = EarnGG.Accounts;

            foreach (Form form in Application.OpenForms)
            {
                UpdateFormPreferences(form, true);
            }

            AddLogMessage(Name, "UpdatePreferenceSnapshots", "Snapshots Complete", LogMessageType.LOG);
            UpdatePreferencesFile();
            return true;
        }
        public static void UpdatePreferencesFile()
        {
            string iniPath = WorkDirectory + "\\Preferences.ini";
            //LogManager.AddLogMessage(Name, "UpdatePreferencesFile", "writing to iniPath - " + iniPath, LogManager.LogMessageType.DEBUG);
            string json = JsonConvert.SerializeObject(preferences);
            string text = LogManager.Encrypt(json);
            File.WriteAllText(@iniPath, text);
        }
        #endregion

        #region DataModels
        public class ArbitragePreference
        {
            public bool ShowCharts { get; set; } = true;
            public List<ExchangeTicker> ArbitrageWatchList { get; set; } = new List<ExchangeTicker>();
        }
        public class FormPreference
        {
            public string Name { get; set; }
            public Point Location { get; set; }
            public Size Size { get; set; }
            public Font Font { get; set; }
            public bool Open { get; set; }
        }
        public class Preferences
        {
            public List<ExchangeApi> ApiList { get; set; } = new List<ExchangeApi>();
            public List<string> SymbolWatchList { get; set; } = new List<string>();
            
            // CUSTOM
            public ArbitragePreference ArbitragePreferences { get; set; } = new ArbitragePreference();
            public TradingViewPreference TradingViewPreferences { get; set; } = new TradingViewPreference();           
            // FLAGS
            public ExchangeTimerType TimerFlags { get; set; } = ExchangeTimerType.NONE;
            public LogMessageType MessageFlags { get; set; } = LogMessageType.NONE;
            // FORMS
            public List<FormPreference> FormPreferences { get; set; } = new List<FormPreference>();
            // SNAPSHOTS
            public List<ExchangeBalance> Balances { get; set; } = new List<ExchangeBalance>();
            public List<ExchangeTicker> Tickers { get; set; } = new List<ExchangeTicker>();
            public List<CoinMarketCapTicker> CoinMarketCapTickers = new List<CoinMarketCapTicker>();
            public List<WalletManager.WalletBalance> Wallets { get; set; } = new List<WalletManager.WalletBalance>();
            public List<EarnGG.EarnGGAccount> EarnGGAccounts { get; set; } = new List<EarnGG.EarnGGAccount>();
        }
        public class TradingViewPreference
        {
            public TradingViewAdvancedChartParameters parameters { get; set; } = new TradingViewAdvancedChartParameters();

            public List<ExchangeTicker> WatchList { get; set; } = new List<ExchangeTicker>()
            {
                new ExchangeTicker() { symbol="BTC", market="USDT", exchange="POLONIEX" },
                new ExchangeTicker() { symbol="BCH", market="USDT", exchange="POLONIEX" },
                new ExchangeTicker() { symbol="DASH", market="USDT", exchange="POLONIEX" },
                new ExchangeTicker() { symbol="ETH", market="USDT", exchange="POLONIEX" },
                new ExchangeTicker() { symbol="ZEC", market="USDT", exchange="POLONIEX" },
                new ExchangeTicker() { symbol="XMR", market="USDT", exchange="POLONIEX" },
                new ExchangeTicker() { symbol="LTC", market="USDT", exchange="POLONIEX" },
                new ExchangeTicker() { symbol="ETC", market="USDT", exchange="POLONIEX" }
            };
        }
        #endregion
    }
    // -------------------------------
    public class WalletManager
    {
        #region Properties
        private static string Name { get; } = "WalletManager";
        public static List<WalletBalance> Wallets = new List<WalletBalance>();
        public static WalletManagerControl walletManagerControl;
        public static ImageList WalletIconList = new ImageList();
        #endregion

        #region Initialize
        public static void Initialize()
        {
            //WalletIconList.Images.Clear();
            //WalletIconList.ImageSize = new Size(32, 32);
            /*
            WalletIconList.Images.Add("BlockIO", ContentManager.GetIconByUrl(BlockIO.IconUrl));
            WalletIconList.Images.Add("Exodus", ContentManager.GetIconByUrl(ContentManager.ExodusIconUrl));
            WalletIconList.Images.Add("", ContentManager.GetIconByUrl(ContentManager.WalletIconUrl));
            */
            exchangeIconList.Images.Add("BlockIO", ContentManager.GetIconByUrl(BlockIO.IconUrl));
            exchangeIconList.Images.Add("Exodus", ContentManager.GetIconByUrl(ContentManager.ExodusIconUrl));
            exchangeIconList.Images.Add("", ContentManager.GetIconByUrl(ContentManager.WalletIconUrl));
        }
        #endregion

        #region Getters
        public static Bitmap GetWalletIcon(string walletName)
        {
            switch (walletName)
            {
                case "BlockIO":
                    return ContentManager.GetIconByUrl(BlockIO.IconUrl);

                case "Exodus":
                    //return ContentManager.ResizeImage(ContentManager.GetIconByUrl(ContentManager.BalanceIconUrl), 32, 32);
                    return ContentManager.GetIconByUrl(ContentManager.ExodusIconUrl);

                default:
                    return ContentManager.GetIconByUrl(ContentManager.WalletIconUrl);
            }
        }
        public static List<ExchangeBalance> GetWalletBalances()
        {
            List<ExchangeBalance> list = new List<ExchangeBalance>();

            foreach (WalletBalance wallet in Wallets)
            {
                if (wallet.Balance > 0)
                {
                    ExchangeBalance balance = new ExchangeBalance()
                    {
                        Balance = wallet.Balance,
                        Exchange = wallet.WalletName,
                        Symbol = wallet.Symbol,
                        TotalInBTC = wallet.TotalInBTC,
                        TotalInUSD = wallet.TotalInUSD
                    };
                    list.Add(balance);
                }
            }

            return list;
        }
        #endregion

        #region Updaters
        public static void UpdateUI()
        {
            if (walletManagerControl != null)
            {
                walletManagerControl.UpdateUI();
            }
        }
        public static bool UpdateWallets()
        {
            foreach (WalletBalance balance in Wallets)
            {
                if (balance.Api.Length > 0)
                {
                    switch (balance.WalletName)
                    {
                        case "BlockIO":
                            balance.Balance = BlockIO.getBalance(balance.Api);
                            /*
                            if (balance.Symbol != "BTC")
                            {
                                balance.TotalInBTC = GetMarketCapBTCAmount(balance.Symbol, balance.Balance);
                            }
                            else
                            {
                                balance.TotalInBTC = balance.Balance;
                            }
                            */
                            balance.TotalInBTC = GetMarketCapBTCAmount(balance.Symbol, balance.Balance);
                            balance.TotalInUSD = GetMarketCapUSDAmount(balance.Symbol, balance.Balance);
                            break;                     

                        default:
                            //AddLogMessage(Name, "updateWallets", balance.WalletName + " Is GENERIC wallet", LogMessageType.DEBUG);
                            // GENERIC - USE BlockCypher for BTC / LTC / DOGE
                            if (balance.Symbol.ToUpper() == "BTC" || balance.Symbol.ToUpper() == "LTC" || balance.Symbol.ToUpper() == "DOGE")
                            {              
                                balance.Balance = BlockCypher.getBalance(balance.Symbol, balance.Address);
                                //AddLogMessage(Name, "UpdateWallets", "balance=" + balance.Balance, LogMessageType.DEBUG);
                                balance.TotalInBTC = GetMarketCapBTCAmount(balance.Symbol, balance.Balance);
                                balance.TotalInUSD = GetMarketCapUSDAmount(balance.Symbol, balance.Balance);
                            }

                            break;
                    }
                }
                else
                {
                    balance.TotalInBTC = GetMarketCapBTCAmount(balance.Symbol, balance.Balance);
                    balance.TotalInUSD = GetMarketCapUSDAmount(balance.Symbol, balance.Balance);
                }
            }
            UpdatePreferenceSnapshots();
            UpdateUI();
            return true;
        }
        #endregion

        #region DataModels
        public class WalletBalance
        {
            public string Api { get; set; }
            public string Symbol { get; set; }
            public string Name { get; set; }
            public string WalletName { get; set; }
            public string Address { get; set; }
            public Decimal Balance { get; set; } = 0;
            public Decimal TotalInBTC { get; set; } = 0;
            public Decimal TotalInUSD { get; set; } = 0;
        }
        #endregion
    }
    // -------------------------------
}