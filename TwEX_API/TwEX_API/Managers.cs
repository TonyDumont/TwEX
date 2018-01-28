using BrightIdeasSoftware;
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
        // IMAGE LISTS
        public static ImageList ExchangeIconList = new ImageList();
        public static ImageList IconList = new ImageList();
        public static ImageList SymbolIconList = new ImageList();
        public static ImageList WalletIconList = new ImageList();
        // URL LISTS
        public static List<IconFile> IconUrlList = new List<IconFile>()
        {
            new IconFile(){ Name = "Add", Url = "http://files.softicons.com/download/system-icons/ikons-icons-by-studiotwentyeight/png/256/Add.png"},
            new IconFile(){ Name = "AddWallet", Url = "https://cdn2.iconfinder.com/data/icons/finance-solid-icons-vol-3/48/112-256.png" },
            new IconFile(){ Name = "ArbitrageManager", Url = "https://orig00.deviantart.net/1028/f/2015/299/f/6/app_store_look_like_software_center_icon__1024__by_kayover-d9efmjt.png" },
            new IconFile(){ Name = "BalanceManager", Url = "https://i.pinimg.com/originals/22/dd/de/22ddde0fc220582cf3688beca1795683.jpg" },
            new IconFile(){ Name = "BlockCypher", Url = "https://www.blockcypher.com/images/favicon-192x192.png" },
            new IconFile(){ Name = "BlockIO", Url = "https://block.io/favicon.ico" },
            new IconFile(){ Name = "ChartView", Url = "https://cdn1.iconfinder.com/data/icons/web-design-seo/512/26-512.png" },
            new IconFile(){ Name = "CoinCalculator", Url = "http://files.softicons.com/download/system-icons/web0.2ama-icons-by-chrfb/png/256x256/Calculator.png" },
            new IconFile(){ Name = "CoinMarketCap", Url = "https://images-na.ssl-images-amazon.com/images/I/61G3KF2yniL.png" },
            new IconFile(){ Name = "CryptoCompare", Url = "https://www.cryptocompare.com/media/20562/favicon.png?v=2" },
            new IconFile(){ Name = "CustomView", Url ="http://cdn.mysitemyway.com/icons-watermarks/simple-black/bfa/bfa_table/bfa_table_simple-black_512x512.png" },
            new IconFile(){ Name = "EarnGGManager", Url = "https://earn.gg/img/favicon-32x32.png" },
            new IconFile(){ Name = "ExchangeEditor", Url = "https://coinmarketcap.com/static/img/CoinMarketCap.png" },
            new IconFile(){ Name = "ExchangeManager", Url = "https://coinmarketcap.com/static/img/CoinMarketCap.png" },
            new IconFile(){ Name = "Exodus", Url = "https://www.exodus.io/favicon-32x32.png?v=oLLkoG3aJr" },
            new IconFile(){ Name = "Export", Url = "http://files.softicons.com/download/toolbar-icons/mono-general-icons-2-by-custom-icon-design/png/128x128/export.png" },
            new IconFile(){ Name = "Font", Url = "https://cdn0.iconfinder.com/data/icons/exempli_gratia/256/z_File_FONT.png" },
            new IconFile(){ Name = "FontDecrease", Url = "https://glanmirekennels.com.au/wp-content/themes/glanmire-kennels/img/font-smaller.png" },
            new IconFile(){ Name = "FontIncrease", Url = "https://glanmirekennels.com.au/wp-content/themes/glanmire-kennels/img/font-larger.png" },
            
            new IconFile(){ Name = "Import", Url = "http://files.softicons.com/download/toolbar-icons/mono-general-icons-2-by-custom-icon-design/png/128x128/import.png" },
            new IconFile(){ Name = "LogManager", Url = "https://image.flaticon.com/icons/png/512/28/28822.png" },
            
            new IconFile(){ Name = "Options", Url = "http://www.iconeasy.com/icon/png/System/Stainless/preferences.png" },
            new IconFile(){ Name = "PreferenceManager", Url = "http://www.iconeasy.com/icon/png/System/Stainless/preferences.png" },
            new IconFile(){ Name = "Refresh", Url = "https://cdn0.iconfinder.com/data/icons/huge-basic-icons/512/Refresh.png" },
            new IconFile(){ Name = "Remove", Url = "http://files.softicons.com/download/system-icons/ikons-icons-by-studiotwentyeight/png/256/Delete.png"},
            new IconFile(){ Name = "SearchList", Url = "http://icons.iconarchive.com/icons/icons8/windows-8/512/Programming-Search-Property-icon.png"},
            new IconFile(){ Name = "Symbol", Url = "https://cdn2.iconfinder.com/data/icons/bitcoin-and-mining/44/trade-512.png" },
            //new IconFile(){ Name = "TradingView", Url = "https://www.tradingview.com/favicon.ico" },
            new IconFile(){ Name = "TradingView", Url = "http://www.patternsmart.com/cart//image/data/tradingview.png" },
            new IconFile(){ Name = "TwEX_FormEditor", Url = "http://www.iconeasy.com/icon/png/System/Stainless/preferences.png" },
            new IconFile(){ Name = "UpDown", Url = "https://cdn1.iconfinder.com/data/icons/touch-gestures-3/96/Scroll-512.png"},
            new IconFile(){ Name = "USDSymbol", Url = "http://www.tirosagol.com/wp-content/uploads/moneyTAG.jpg"},
            new IconFile(){ Name = "WalletManager", Url = "https://cdn.iconscout.com/public/images/icon/premium/png-512/wallet-3a62a21639a59921-512x512.png" }
        };
        public static List<IconFile> WalletIconUrlList = new List<IconFile>()
        {
            new IconFile(){ Name = "BlockIO", Url = "https://block.io/favicon.ico" },
            new IconFile(){ Name = "Exodus", Url = "https://www.exodus.io/favicon-32x32.png?v=oLLkoG3aJr" }

        };
        #endregion

        #region Initialize
        public static Boolean InitializeExchangeIconList()
        {
            ExchangeIconList.Images.Clear();
            //string path = @"c:\\Windows\\Loader\\Applications\\symbols\\";
            string path = WorkDirectory + "\\exchanges\\";
            string[] filter = { ".png" };

            ExchangeIconList.ImageSize = preferences.IconSize;

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
                            string icon = fi.Name.Split('.')[0];
                            Image img = Image.FromFile(fi.FullName);
                            ExchangeIconList.Images.Add(icon, img);
                        }
                    }
                }
            }
            else
            {
                // CREATE FOLDER
                Directory.CreateDirectory(path);
                foreach (ExchangeManager.Exchange exchange in Exchanges)
                {
                    //AddLogMessage(Name, "SaveIcons", icon.Name + " | " + icon.Url, LogMessageType.DEBUG);
                    GetExchangeIcon(exchange.Name);
                }
            }
            AddLogMessage(Name, "InitializeExchangeIconList", "Exchange Icons Initialized " + ExchangeIconList.Images.Count + " Icons", LogMessageType.LOG);
            return true;
        }
        public static Boolean InitializeIconList()
        {
            IconList.Images.Clear();
            string path = WorkDirectory + "\\icons\\";
            string[] filter = { ".png" };

            IconList.ImageSize = preferences.IconSize;

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
                            string name = fi.Name.Split('.')[0];
                            Image img = Image.FromFile(fi.FullName);
                            IconList.Images.Add(name, img);
                        }
                    }
                }
            }
            else
            {
                // CREATE FOLDER
                AddLogMessage(Name, "SaveIcons", "ICONS folder does not exist - CREATING IT", LogMessageType.LOG);
                Directory.CreateDirectory(path);
                foreach (IconFile icon in IconUrlList)
                {                   
                    GetIcon(icon.Name);
                }
            }
            AddLogMessage(Name, "InitializeIconList", "Icon List Initialized " + IconList.Images.Count + " Icons", LogMessageType.LOG);
            return true;
        }
        public static Boolean InitializeSymbolImageList()
        {
            SymbolIconList.Images.Clear();
            //string path = @"c:\\Windows\\Loader\\Applications\\symbols\\";
            string path = PreferenceManager.WorkDirectory + "\\symbols\\";
            string[] filter = { ".png" };

            SymbolIconList.ImageSize = preferences.IconSize;

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
                            SymbolIconList.Images.Add(symbol, img);
                        }
                    }
                }
            }
            else
            {
                // CREATE FOLDER
                Directory.CreateDirectory(path);
            }
            AddLogMessage(Name, "InitializeIconList", "Symbol Icon List Initialized " + SymbolIconList.Images.Count + " Icons", LogMessageType.LOG);
            return true;
        }
        public static Boolean InitializeWalletImageList()
        {
            WalletIconList.Images.Clear();
            //string path = @"c:\\Windows\\Loader\\Applications\\symbols\\";
            string path = WorkDirectory + "\\wallets\\";
            string[] filter = { ".png" };

            WalletIconList.ImageSize = preferences.IconSize;

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
                            string wallet = fi.Name.Split('.')[0];
                            Image img = Image.FromFile(fi.FullName);
                            WalletIconList.Images.Add(wallet, img);
                        }
                    }
                }
            }
            else
            {
                // CREATE FOLDER
                Directory.CreateDirectory(path);
                foreach (IconFile icon in WalletIconUrlList)
                {
                    GetWalletIcon(icon.Url);
                }
            }
            AddLogMessage(Name, "InitializeWalletIconList", "Wallet Icon List Initialized " + WalletIconList.Images.Count + " Icons", LogMessageType.LOG);
            return true;
        }
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
        /*
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
                AddLogMessage(Name, "GetIconByUrl", ex.Message, LogMessageType.EXCEPTION);
            }
            return icon;
        }
        */
        
        public static Image GetIconByUrl(string url)
        {
            //LogManager.AddLogMessage(Name, "GetExchangeIcon", "getting fav icon : " + url, LogMessageType.DEBUG);
            Bitmap icon = new Bitmap(16, 16);
            //Image icon = new Image();

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
            return (Image)icon;
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
        
        public static Image GetExchangeIcon(string name)
        {
            //Image image = Properties.Resources.ConnectionStatus_DISABLED;
            Image image = GetIcon("WalletManager");

            if (ExchangeIconList.Images.ContainsKey(name))
            {
                return ExchangeIconList.Images[name];
            }
            else if(WalletIconList.Images.ContainsKey(name))
            {
                return WalletIconList.Images[name];
            }
            else
            {
                try
                {
                    ExchangeManager.Exchange exchange = Exchanges.FirstOrDefault(item => item.Name == name);

                    if (exchange != null)
                    {
                        Image icon = GetIconByUrl(exchange.IconUrl);
                        ExchangeIconList.Images.Add(name, icon);
                        icon.Save(WorkDirectory + "\\exchanges\\" + name + ".png", ImageFormat.Png);
                        return icon;
                    }
                    else
                    {
                        return image;
                    }
                }
                catch (Exception ex)
                {
                    AddLogMessage(Name, "GetExchangeIcon", name + " | " + ex.Message, LogMessageType.EXCEPTION);
                    // USE GENERIC ICON
                    return image;
                }
            }
        }
        
        public static Image GetIcon(string name)
        {
            Image image = Properties.Resources.ConnectionStatus_DISABLED;
            // check imagelist for exist
            if (IconList.Images.ContainsKey(name))
            {
                //AddLogMessage(Name, "GetIcon", "Icon List Contains Key " + name + " - Returning Image", LogMessageType.DEBUG);
                return IconList.Images[name];
            }
            else
            {
                // set it up for later
                try
                {
                    IconFile iconFile = IconUrlList.FirstOrDefault(item => item.Name == name);

                    if (iconFile != null)
                    {
                        Image icon = GetIconByUrl(iconFile.Url);
                        IconList.Images.Add(name, icon);
                        icon.Save(WorkDirectory + "\\icons\\" + name + ".png", ImageFormat.Png);
                        AddLogMessage(Name, "GetIcon", "Saving " + name + ".png in ICONS FOLDER", LogMessageType.LOG);
                        return icon;
                    }
                    else
                    {
                        AddLogMessage(Name, "GetIcon", "Unable To Save " + name + ".png in ICONS FOLDER - No Entry In IconUrl List", LogMessageType.LOG);
                        return image;
                    }               
                }
                catch (Exception ex)
                {
                    AddLogMessage(Name, "GetIcon", name + " | " + ex.Message, LogMessageType.EXCEPTION);
                    // USE GENERIC ICON
                    return image;
                }
            }
        }
         
        public static Image GetSymbolIcon(string symbol)
        {
            Image image = Properties.Resources.ConnectionStatus_DISABLED;
            // check imagelist for exist
            if (SymbolIconList.Images.ContainsKey(symbol.ToUpper()))
            {
                return SymbolIconList.Images[symbol];
            }
            else
            {
                // set it up for later
                try
                { 
                    CryptoCompareCoin coin = CryptoComparePreferences.CoinList.FirstOrDefault(listItem => listItem.Name == symbol);

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

                            SymbolIconList.Images.Add(symbol.ToUpper(), img);
                            img.Save(WorkDirectory + "\\symbols\\" + symbol.ToUpper() + ".png", ImageFormat.Png);

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
                    AddLogMessage(Name, "GetSymbolIcon", symbol + " | " + ex.Message, LogMessageType.EXCEPTION);
                    // USE GENERIC ICON
                    return image;
                }
            }
        }
        
        public static Image GetWalletIcon(string name)
        {
            Image image = Properties.Resources.ConnectionStatus_DISABLED;

            if (WalletIconList.Images.ContainsKey(name))
            {
                return WalletIconList.Images[name];
            }
            else
            {
                try
                {
                    IconFile wallet = WalletIconUrlList.FirstOrDefault(item => item.Name == name);

                    if (wallet != null)
                    {
                        Image icon = GetIconByUrl(wallet.Url);
                        WalletIconList.Images.Add(name, icon);
                        icon.Save(WorkDirectory + "\\wallets\\" + name + ".png", ImageFormat.Png);
                        return icon;
                    }
                    else
                    {
                        return image;
                    }
                }
                catch (Exception ex)
                {
                    AddLogMessage(Name, "GetWalletIcon", name + " | " + ex.Message, LogMessageType.EXCEPTION);
                    // USE GENERIC ICON
                    return image;
                }
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

        public static void SaveIcons()
        {
            foreach (IconFile icon in IconUrlList)
            {
                AddLogMessage(Name, "SaveIcons", icon.Name + " | " + icon.Url, LogMessageType.DEBUG);
                GetIcon(icon.Name);
            }
        }
        #endregion

        #region DataModels
        public class IconFile
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
        #endregion
    }
    // -------------------------------
    public class ExchangeManager
    {
        #region Properties
        private static string Name { get; } = "ExchangeManager";
        public static System.Timers.Timer timer = new System.Timers.Timer();
        // COLLECTIONS
        public static BlockingCollection<Exchange> Exchanges = new BlockingCollection<Exchange>();
        public static BlockingCollection<ExchangeBalance> Balances = new BlockingCollection<ExchangeBalance>();
        public static BlockingCollection<ExchangeTicker> Tickers = new BlockingCollection<ExchangeTicker>();
        #endregion Properties

        #region Initialize      
        public static Boolean InitializeExchanges()
        {
            List<string> list = getExchangeList();
            
            //ContentManager.ExchangeIconList.Images.Clear();
            //ContentManager.ExchangeIconList.ImageSize = new Size(32, 32);
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

                        exchange.USDSymbol = type.GetProperty("USDSymbol", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();
                        exchange.TradingView = type.GetProperty("TradingView", BindingFlags.Public | BindingFlags.Static).GetValue(null).ToString();                  
                        //LogManager.AddLogMessage(Name, "InitializeExchangeList", "type !+ null for " + exchange.SiteName + " | " + preferences.apiList.Count, LogManager.LogMessageType.DEBUG);

                        ExchangeApi api = preferences.ApiList.FirstOrDefault(a => a.exchange.ToLower() == exchange.Name.ToLower());
                        if (api != null)
                        {
                            SetExchangeApi(api);
                        }

                        Task.Factory.StartNew(() => type.InvokeMember("InitializeExchange",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
                    }
                    catch (Exception ex)
                    {
                        AddLogMessage(Name, "InitializeExchangeList", ex.Message, LogMessageType.EXCEPTION);
                    }
                }
                else
                {
                    AddLogMessage(Name, "InitializeExchangeList", "PROBLEM : type is NULL : " + exchange.Name, LogMessageType.EXCHANGE);
                }

                Exchange listItem = Exchanges.FirstOrDefault(item => item.Name == exchange.Name);
                if (listItem != null)
                {
                    // UPDATE
                    listItem.IconUrl = exchange.IconUrl;
                    listItem.TradingView = exchange.TradingView;
                    listItem.Url = exchange.Url;
                    listItem.USDSymbol = exchange.USDSymbol;
                }
                else
                {
                    Exchanges.Add(exchange);
                }               
            }

            ExchangePreferences.Exchanges = Exchanges.ToList();
            UpdatePreferenceFile(PreferenceType.Exchange);
            //WalletManager.Initialize();
            InitializeTimer();
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
                //AddLogMessage(Name, "GetPriceOfSymbol", exchange + " | " + market + " | " + symbol, LogMessageType.OTHER);
                if (ticker != null)
                {
                    //AddLogMessage(Name, "GetPriceOfSymbol", exchange + " | " + market + " | " + symbol, LogMessageType.OTHER);
                    //AddLogMessage(Name, "GetPriceOfSymbol", "LAST=" + ticker.last, LogMessageType.OTHER);
                    value = ticker.last;
                }
            }
            catch (Exception ex)
            {
                AddLogMessage(Name, "GetPriceOfSymbol", ex.Message, LogMessageType.EXCEPTION);
            }
            //LogManager.AddLogMessage(Name, "GetPriceOfSymbol", "exchange=" + exchange + " | market=" + market + " | symbol=" + symbol + " | value=" + value);
            return value;
        }

        public static List<ExchangeTicker> GetPriceWatchlist(string market, string symbol)
        {
            //AddLogMessage(Name, "GetPriceWatchlist", "market=" + market + " | " + symbol, LogMessageType.DEBUG);
            List<ExchangeTicker> list = new List<ExchangeTicker>();

            try
            {
                foreach (Exchange exchange in Exchanges)
                {
                    //AddLogMessage(Name, "GetPriceWatchlist", "Exchange : " + exchange.Name + " | USDSymbol=" + exchange.USDSymbol + " | " + symbol + " | " + market, LogMessageType.OTHER);
                    if (market.Contains("USD") && exchange.USDSymbol.Length > 0)
                    {
                        //AddLogMessage(Name, "GetPriceWatchlist", "Exchange : " + exchange.Name + "USD MARKET =" + exchange.USDSymbol + " | " + symbol + " | " + market, LogMessageType.OTHER);
                        market = exchange.USDSymbol;
                        //AddLogMessage(Name, "GetPriceWatchlist", "Exchange : " + exchange.Name + " | USDSymbol=" + exchange.USDSymbol + " | " + symbol + " | " + market, LogMessageType.OTHER);
                    }
                    
                    ExchangeTicker newItem = new ExchangeTicker()
                    {
                        exchange = exchange.Name,
                        market = market,
                        symbol = symbol,
                        last = GetPriceOfSymbol(exchange.Name, market, symbol)
                    };

                    //newItem.market = market;
                    //newItem.symbol = symbol;
                    //newItem.price = GetExchangeUSDValueBySymbol(exchange.SiteName, symbol);
                    //AddLogMessage(Name, "GetPriceWatchlist", exchange.Name + " | " + market + " | " + symbol, LogMessageType.DEBUG);
                    //newItem.last = GetPriceOfSymbol(exchange.Name, market, symbol);

                    list.Add(newItem);
                }
            }
            catch (Exception ex)
            {
                AddLogMessage(Name, "GetPriceWatchlist", ex.Message, LogMessageType.EXCEPTION);
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
            public bool Active { get; set; } = true;
            // TOTALS
            public int CoinCount { get { return BalanceList.FindAll(e => e.Balance > 0).Count; } }
            public Decimal TotalInBTC { get { return BalanceList.Sum(balance => balance.TotalInBTC); } }
            public Decimal TotalInBTCOrders { get { return BalanceList.Sum(balance => balance.TotalInBTCOrders); } }
            public Decimal TotalInUSD { get { return BalanceList.Sum(balance => balance.TotalInUSD); } }
            // COLLECTIONS
            public List<ExchangeBalance> BalanceList { get { return Balances.Where(balance => balance.Exchange == Name).ToList(); } }
            public List<ExchangeTicker> TickerList { get { return Tickers.Where(ticker => ticker.exchange == Name).ToList(); } }
            // STATUS
            public int ErrorCount { get { return Convert.ToInt32(type.GetProperty("ErrorCount", BindingFlags.Public | BindingFlags.Static).GetValue(null)); } }
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
        //public static FormToolStripControl mainToolStrip;
        public static TwEXTraderControl mainControl;

        public static ArbitrageManagerControl arbitrageManagerControl;
        public static CoinMarketCapControl coinMarketCapControl;
        public static CryptoCompareControl cryptoCompareControl;
        public static EarnGGManagerControl earnGGManagerControl;
        public static ExchangeManagerControl exchangeManagerControl;
        public static TradingViewManagerControl tradingViewManagerControl;
        public static WalletManagerControl walletManagerControl;
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
        /*
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
                    return ContentManager.GetIconByUrl(ContentManager.CryptoCompareIconUrl);

                case "CoinMarketCap":
                    return ContentManager.GetIconByUrl(ContentManager.CoinMarketCapIconUrl);

                case "EarnGGManager":
                    //return ContentManager.ResizeImage(ContentManager.GetIconByUrl(ExchangeManager.IconUrl), 32, 32);
                    return ContentManager.GetIconByUrl(ContentManager.EarnGGIconUrl);

                case "ExchangeEditor":
                    //return ContentManager.ResizeImage(ContentManager.GetIconByUrl(ExchangeManager.IconUrl), 32, 32);
                    return ContentManager.GetIconByUrl(ContentManager.ExchangeManagerIconUrl);

                case "LogManager":
                    return ContentManager.GetIconByUrl(ContentManager.LogManagerIconUrl);

                case "TradingView":
                    return ContentManager.GetIconByUrl(ContentManager.TradingViewIconUrl);

                case "WalletManager":
                    return ContentManager.GetIconByUrl(ContentManager.WalletIconUrl);

                default:
                    return Properties.Resources.ConnectionStatus_DISABLED;
            }         
        }
        */
        #endregion

        #region Functions
        public static void OpenForm(string name, string text)
        {
            Form targetForm = GetFormByName(name);
            
            if (targetForm == null)
            {
                Form form = new Form() { Size = new Size(950, 550), Name = name, Text = text, Icon = Icon.FromHandle(new Bitmap(ContentManager.GetIcon(name)).GetHicon()) };
                form.Show();

                FormPreference preference = FormPreferences.FirstOrDefault(item => item.Name == form.Name);

                if (preference != null)
                {
                    //LogManager.AddLogMessage(Name, "toolStripButton_Form_Click", "FOUND : " + preference.Name + " | " + preference.Font.FontFamily + " | " + preference.Size + " | " + preference.Location);
                    form.SetBounds(preference.Location.X, preference.Location.Y, preference.Size.Width, preference.Size.Height);
                        
                    if (preferences.UseGlobalFont)
                    {
                        form.Font = new Font(preferences.Font.FontFamily, preferences.Font.Size, preferences.Font.Style);
                    }
                    else
                    {
                        form.Font = new Font(preference.Font.FontFamily, preference.Font.Size, preference.Font.Style);
                    }     
                        
                }
                else
                {
                    AddLogMessage(Name, "toolStripButton_Form_Click", "PREFERENCE NOT FOUND ADDING : " + form.Name + " | " + form.Location, LogMessageType.DEBUG);
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
                            ArbitrageManagerControl control = new ArbitrageManagerControl() { Dock = DockStyle.Fill };
                        //form.Controls.Add(new ArbitrageManagerControl() { Dock = DockStyle.Fill });
                        form.FormClosing += delegate { arbitrageManagerControl = null; };
                        form.FormClosing += delegate { control.DisposeTimer(); };
                        form.Controls.Add(control);
                            
                        break;

                    case "BalanceManager":
                        form.Controls.Add(new BalanceManagerControl() { Dock = DockStyle.Fill });
                        break;

                    case "CoinCalculator":
                        form.Controls.Add(new CoinCalculatorControl() { Dock = DockStyle.Fill });
                        break;

                    case "CryptoCompare":
                        form.Controls.Add(new CryptoCompareControl() { Dock = DockStyle.Fill });
                        form.FormClosing += delegate { cryptoCompareControl = null; };
                        break;

                    case "CoinMarketCap":
                        form.Controls.Add(new CoinMarketCapControl() { Dock = DockStyle.Fill });
                        form.FormClosing += delegate { coinMarketCapControl = null; };
                        break;
/*
                    case "EarnGGManager":
                        form.Controls.Add(new EarnGGManagerControl() { Dock = DockStyle.Fill });
                        form.FormClosing += delegate { earnGGManagerControl = null; };
                        break;
                        */
/*
                    case "ExchangeEditor":
                        form.Controls.Add(new ExchangeManagerControl() { Dock = DockStyle.Fill });
                        form.FormClosing += delegate { exchangeManagerControl = null; };
                        break;
                        */
                    case "LogManager":
                        form.FormClosing += delegate { logManagerControl = null; };
                        form.Controls.Add(new LogManagerControl() { Dock = DockStyle.Fill });
                        break;

                    case "PreferenceManager":
                        form.Controls.Add(new PreferenceManagerControl() { Dock = DockStyle.Fill });
                        break;

                    case "TradingView":
                        form.Controls.Add(new TradingViewManagerControl() { Dock = DockStyle.Fill });
                        form.FormClosing += delegate { tradingViewManagerControl = null; };
                        break;
/*
                    case "WalletManager":
                        form.Controls.Add(new WalletManagerControl() { Dock = DockStyle.Fill });
                        form.FormClosing += delegate { walletManagerControl = null; };
                        break;
                        */
                    default:
                        AddLogMessage(Name, "OpenForm", "FORM NOT DEFINED!!! : " + name, LogMessageType.DEBUG);
                        break;
                }
            }
            else
            {
                /*
                if (targetForm.WindowState == FormWindowState.Minimized)
                {
                    targetForm.WindowState = FormWindowState.Normal;
                }
                targetForm.Activate();
                */
            }
            UpdateToolStrip();
        }
        public static void RestoreForms()
        {
            foreach (FormPreference pref in FormPreferences)
            {
                //LogManager.AddLogMessage(Name, "InitializePreferences", pref.Name + " | " + pref.Open, LogMessageType.DEBUG);
                if (pref.Open)
                {
                    OpenForm(pref.Name, pref.Name);
                }
            }
        }
        #endregion

        #region Updaters
        public static void UpdateControlUIs(bool resize = false)
        {
            UpdateArbitrageManager(resize);
            UpdateCoinMarketCap(resize);
            UpdateCryptoCompare(resize);
            UpdateEarnGGManager(resize);
            UpdateExchangeManager(resize);
            UpdateTradingViewManager(resize);
            UpdateWalletManager(resize);
            UpdateToolStrip(resize);
        }
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
        public static void UpdateArbitrageManager(bool resize = false)
        {
            if (arbitrageManagerControl != null)
            {
                arbitrageManagerControl.SetWatchlist();
            }
            //UpdatePreferenceFile(PreferenceType.Arbitrage);
        }
        public static void UpdateCoinMarketCap(bool resize = false)
        {
            if (coinMarketCapControl != null)
            {
                coinMarketCapControl.UpdateUI(resize);
            }
            //UpdatePreferenceFile(PreferenceType.CoinMarketCap);
        }
        public static void UpdateCryptoCompare(bool resize = false)
        {
            if (cryptoCompareControl != null)
            {
                cryptoCompareControl.UpdateUI(resize);
            }
            //UpdatePreferenceFile(PreferenceType.CryptoCompare);
        }
        public static void UpdateEarnGGManager(bool resize = false)
        {
            if (earnGGManagerControl != null)
            {
                earnGGManagerControl.UpdateUI(resize);
            }
            //UpdatePreferenceFile(PreferenceType.EarnGG);
        }
        public static void UpdateExchangeManager(bool resize = false)
        {
            if (exchangeManagerControl != null)
            {
                //AddLogMessage(Name, "UpdateExchangeControlsUI", "Updating Exchanges : " + Exchanges.Where(item => item.Active == true).Count() + " Active", LogMessageType.DEBUG);
                exchangeManagerControl.UpdateUI(true);
            }
            //UpdatePreferenceFile(PreferenceType.Exchange);
        }
        public static void UpdateTradingViewManager(bool resize = false)
        {
            if (tradingViewManagerControl != null)
            {
                tradingViewManagerControl.UpdateUI(resize);
            }
            //UpdatePreferenceFile(PreferenceType.TradingView);
        }
        public static void UpdateWalletManager(bool resize = false)
        {
            if (walletManagerControl != null)
            {
                walletManagerControl.UpdateUI(resize);
            }
            //UpdatePreferenceFile(PreferenceType.Wallet);
        }
        public static void UpdateToolStrip(bool resize = false)
        {
            if (mainControl != null)
            {
                mainControl.UpdateUI(resize);
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
            LogMessage logMessage = new LogMessage()
            {
                TimeStamp = DateTime.Now,
                Source = source,
                FunctionCall = functionCall,
                Message = message,
                type = type
            };
            /*
            logMessage.TimeStamp = DateTime.Now;
            logMessage.Source = source;
            logMessage.FunctionCall = functionCall;
            logMessage.Message = message;
            logMessage.type = type;
            //LogMessageList.Insert(0, logMessage);
            */
            MessageList.Add(logMessage);

            if (ConsoleLogging == true && source != "LogManager")
            {
                WriteToLog(logMessage.ToString());
            }

            if (logManagerControl != null)
            {
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
            preferences.MessageFlags ^= type;
            UpdatePreferenceFile();
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
        // PREFERENCES
        public static Preferences preferences = new Preferences();
        public static ArbitragePreference ArbitragePreferences { get; set; } = new ArbitragePreference();
        public static CoinMarketCapPreference CoinMarketCapPreferences { get; set; } = new CoinMarketCapPreference();
        public static CryptoComparePreference CryptoComparePreferences { get; set; } = new CryptoComparePreference();
        public static EarnGGPreference EarnGGPreferences { get; set; } = new EarnGGPreference();
        public static ExchangePreference ExchangePreferences { get; set; } = new ExchangePreference();
        public static List<FormPreference> FormPreferences { get; set; } = new List<FormPreference>();
        public static TradingViewPreference TradingViewPreferences { get; set; } = new TradingViewPreference();
        public static WalletPreference WalletPreferences { get; set; } = new WalletPreference();
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
                AddLogMessage(Name, "LoadPreferences", "PREFERENCES LOADED", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "Preferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile();
            }

            // ARBITRAGE PREFERENCES
            iniPath = WorkDirectory + "\\ArbitragePreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                ArbitragePreferences = JsonConvert.DeserializeObject<ArbitragePreference>(json);
                AddLogMessage(Name, "LoadPreferences", "LOADED " + ArbitragePreferences.ArbitrageWatchList.Count + " Arbitrage Preferences", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "ArbitragePreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.Arbitrage);
            }
            
            // CoinMarketCap PREFERENCES
            iniPath = WorkDirectory + "\\CoinMarketCapPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                CoinMarketCapPreferences = JsonConvert.DeserializeObject<CoinMarketCapPreference>(json);
                AddLogMessage(Name, "LoadPreferences", "LOADED " + CoinMarketCapPreferences.Tickers.Count + " CoinMarketCap Tickers", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "CoinMarketCapPreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.CoinMarketCap);
            }

            // CryptoCompare PREFERENCES
            iniPath = WorkDirectory + "\\CryptoComparePreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                CryptoComparePreferences = JsonConvert.DeserializeObject<CryptoComparePreference>(json);
                AddLogMessage(Name, "LoadPreferences", "LOADED " + CryptoComparePreferences.CoinList.Count + " CryptoCompare Coins", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "CryptoComparePreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.CryptoCompare);
            }

            // EarnGG PREFERENCES
            iniPath = WorkDirectory + "\\EarnGGPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                EarnGGPreferences = JsonConvert.DeserializeObject<EarnGGPreference>(json);
                AddLogMessage(Name, "LoadPreferences", "LOADED " + EarnGGPreferences.EarnGGAccounts.Count + " EarnGG Accounts Loaded", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "EarnGGPreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.EarnGG);
            }

            // Exchange PREFERENCES
            iniPath = WorkDirectory + "\\ExchangePreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                ExchangePreferences = JsonConvert.DeserializeObject<ExchangePreference>(json);
                Exchanges = new BlockingCollection<ExchangeManager.Exchange>(new ConcurrentQueue<ExchangeManager.Exchange>(ExchangePreferences.Exchanges));
                AddLogMessage(Name, "LoadPreferences", "LOADED " + ExchangePreferences.Exchanges.Count + " Exchanges Loaded", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "ExchangePreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.Exchange);
            }

            // FORM PREFERENCES
            iniPath = WorkDirectory + "\\FormPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                FormPreferences = JsonConvert.DeserializeObject<List<FormPreference>>(json);
                AddLogMessage(Name, "LoadPreferences", "LOADED " + FormPreferences.Count + " Form Preferences", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "FormPreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.Form);
            }

            // Trading View PREFERENCES
            iniPath = WorkDirectory + "\\TradingViewPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                TradingViewPreferences = JsonConvert.DeserializeObject<TradingViewPreference>(json);
                AddLogMessage(Name, "LoadPreferences", "LOADED " + TradingViewPreferences.WatchList.Count + " TradingView Preferences", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "TradingViewPreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.TradingView);
            }

            // WALLET PREFERENCES
            iniPath = WorkDirectory + "\\WalletPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                WalletPreferences = JsonConvert.DeserializeObject<WalletPreference>(json);
                AddLogMessage(Name, "LoadPreferences", "LOADED " + WalletPreferences.Wallets.Count + " Wallets", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "WalletPreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.Wallet);
            }
            
            return true;
        }
        public static Boolean SetPreferenceSnapshots()
        {
            AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.ApiList.Count + " APIS", LogMessageType.LOG);
            AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.SymbolWatchList.Count + " Symbols In Watchlist", LogMessageType.LOG);
            
            AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.Balances.Count + " Balances", LogMessageType.LOG);
            if (preferences.Balances.Count > 0)
            {
                Balances = new BlockingCollection<ExchangeBalance>(new ConcurrentQueue<ExchangeBalance>(preferences.Balances));
            }

            AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.Tickers.Count + " Tickers", LogMessageType.LOG);
            if (preferences.Tickers.Count > 0)
            {
                Tickers = new BlockingCollection<ExchangeTicker>(new ConcurrentQueue<ExchangeTicker>(preferences.Tickers));
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
            UpdatePreferenceFile();
        }
        public static void RemoveExchangeApi(string exchange)
        {
            ExchangeApi match = PreferenceManager.preferences.ApiList.FirstOrDefault(item => item.exchange.ToLower() == exchange.ToLower());

            if (match != null)
            {
                LogManager.AddLogMessage(Name, "RemoveExchangeApi", "Removing " + exchange + " from API List", LogManager.LogMessageType.DEBUG);
                PreferenceManager.preferences.ApiList.Remove(match);
                UpdatePreferenceFile();
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
        public static void ExportPreferences(PreferenceType type)
        {
            //string iniPath = WorkDirectory + "\\" + type + "Preferences_EXPORT.ini";
            string json = String.Empty;
            string fileName = "TwEXport_" + type + "Preferences.txt";
            //string iniPath = WorkDirectory + "\\Preferences_export.ini";
            //LogManager.AddLogMessage(Name, "ExportPreferences", "Exporting to iniPath - " + iniPath, LogManager.LogMessageType.DEBUG);
            if (UpdatePreferenceSnapshots())
            {
                switch (type)
                {
                    case PreferenceType.None:
                        //iniPath = WorkDirectory + "\\Preferences.ini";
                        fileName = "TwEXport_Preferences.txt";
                        json = JsonConvert.SerializeObject(preferences);
                        break;

                    case PreferenceType.Arbitrage:
                        json = JsonConvert.SerializeObject(ArbitragePreferences);
                        break;

                    case PreferenceType.CoinMarketCap:
                        json = JsonConvert.SerializeObject(CoinMarketCapPreferences);
                        break;

                    case PreferenceType.CryptoCompare:
                        json = JsonConvert.SerializeObject(CryptoComparePreferences);
                        break;

                    case PreferenceType.EarnGG:
                        json = JsonConvert.SerializeObject(EarnGGPreferences);
                        break;

                    case PreferenceType.Exchange:
                        json = JsonConvert.SerializeObject(ExchangePreferences);
                        break;

                    case PreferenceType.Form:
                        json = JsonConvert.SerializeObject(FormPreferences);
                        break;

                    case PreferenceType.TradingView:
                        json = JsonConvert.SerializeObject(TradingViewPreferences);
                        break;

                    case PreferenceType.Wallet:
                        json = JsonConvert.SerializeObject(WalletPreferences);
                        break;

                    default:
                        AddLogMessage(Name, "ExportPreferences", "Preference Not Defined : " + type, LogMessageType.DEBUG);
                        break;
                }

                //File.WriteAllText(@iniPath, json);
                SaveFileDialog save = new SaveFileDialog()
                {
                    FileName = fileName,
                    Filter = "Text File | *.txt"
                };
                //save.FileName = "TwEXport.txt";
                //save.Filter = "Text File | *.txt";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(save.OpenFile());
                    writer.WriteLine(json);
                    writer.Dispose();
                    writer.Close();
                }
            }    
        }
        public static Boolean ImportPreferences(PreferenceType type)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

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

                            switch (type)
                            {
                                case PreferenceType.None:
                                    preferences = JsonConvert.DeserializeObject<Preferences>(text.ToString());
                                    break;

                                case PreferenceType.Arbitrage:
                                    ArbitragePreferences = JsonConvert.DeserializeObject<ArbitragePreference>(text.ToString());
                                    FormManager.UpdateArbitrageManager();
                                    break;

                                case PreferenceType.CoinMarketCap:
                                    CoinMarketCapPreferences = JsonConvert.DeserializeObject<CoinMarketCapPreference>(text.ToString());
                                    FormManager.UpdateCoinMarketCap();
                                    break;

                                case PreferenceType.CryptoCompare:
                                    CryptoComparePreferences = JsonConvert.DeserializeObject<CryptoComparePreference>(text.ToString());
                                    FormManager.UpdateCryptoCompare();
                                    break;

                                case PreferenceType.EarnGG:
                                    EarnGGPreferences = JsonConvert.DeserializeObject<EarnGGPreference>(text.ToString());
                                    FormManager.UpdateEarnGGManager();
                                    break;

                                case PreferenceType.Exchange:
                                    ExchangePreferences = JsonConvert.DeserializeObject<ExchangePreference>(text.ToString());
                                    FormManager.UpdateExchangeManager();
                                    break;

                                case PreferenceType.Form:
                                    FormPreferences = JsonConvert.DeserializeObject<List<FormPreference>>(text.ToString());
                                    FormManager.UpdateForms();
                                    break;

                                case PreferenceType.TradingView:
                                    TradingViewPreferences = JsonConvert.DeserializeObject<TradingViewPreference>(text.ToString());
                                    FormManager.UpdateTradingViewManager();
                                    break;

                                case PreferenceType.Wallet:
                                    WalletPreferences = JsonConvert.DeserializeObject<WalletPreference>(text.ToString());
                                    FormManager.UpdateWalletManager();
                                    break;

                                default:
                                    AddLogMessage(Name, "ImportPreferences", "Preference Not Defined : " + type, LogMessageType.DEBUG);
                                    break;
                            }

                            AddLogMessage(Name, "ImportPreferences", type + " PREFERENCES IMPORTED", LogMessageType.LOG);
                            if (SetPreferenceSnapshots())
                            {
                                UpdatePreferenceFile(type);
                            }                        
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    AddLogMessage(Name, "ImportPreferences", ex.Message, LogMessageType.EXCEPTION);
                    return false;
                }
            }            
            return true;
        }
        #endregion

        #region ArbitrageWatchList
        public static void AddArbitrageWatchListItem(string symbol, string market)
        {
            ExchangeTicker listItem = ArbitragePreferences.ArbitrageWatchList.Find(item => item.market == market && item.symbol == symbol);
            if (listItem == null)
            {
                ExchangeTicker newItem = new ExchangeTicker()
                {
                    market = market,
                    symbol = symbol
                };
                //newItem.market = market;
                //newItem.symbol = symbol;
                ArbitragePreferences.ArbitrageWatchList.Add(newItem);
                FormManager.UpdateArbitrageManager();
            }
        }
        public static void RemoveWatchlistItem(string market, string symbol)
        {
            ExchangeTicker listItem = ArbitragePreferences.ArbitrageWatchList.Find(item => item.market == market && item.symbol == symbol);
            if (listItem != null)
            {
                ArbitragePreferences.ArbitrageWatchList.Remove(listItem);
                FormManager.UpdateArbitrageManager();
            }
        }
        public static void MoveWatchlistItem(string market, string symbol, string direction)
        {
            //ExchangePrice listItem = symbolPriceLists.Find(item => item.market == market && item.symbol == symbol);
            int index = ArbitragePreferences.ArbitrageWatchList.FindIndex(item => item.market == market && item.symbol == symbol);

            if (index != -1)
            {

                if (direction == "up")
                {
                    if (index > 0)
                    {
                        ArbitragePreferences.ArbitrageWatchList.Move(index, MoveDirection.Up);
                    }

                }
                else
                {
                    if (index < ArbitragePreferences.ArbitrageWatchList.Count - 1)
                    {
                        ArbitragePreferences.ArbitrageWatchList.Move(index, MoveDirection.Down);
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
            UpdatePreferenceFile();
        }
        public static void RemoveSymbolFromWatchlist(string symbol)
        {
            preferences.SymbolWatchList.Remove(symbol);
            UpdatePreferenceFile();
        }
        #endregion

        #region Flags
        public static void toggleTimerPreference(ExchangeTimerType type)
        {
            preferences.TimerFlags ^= type;
            UpdatePreferenceFile();
        }
        #endregion

        #region Getters
        public static Font GetFormFont(Form form)
        {
            if (preferences.UseGlobalFont)
            {
                return preferences.Font;
            }
            else
            {
                FormPreference preference = FormPreferences.FirstOrDefault(item => item.Name == form.Name);

                if (preference != null)
                {
                    return preference.Font;
                }
                else
                {
                    AddLogMessage(Name, "GetFormFont", "No Preference Saved For Form : " + form.Name);
                    return preferences.Font;
                }
            }
        }
        #endregion

        #region Updaters
        public static void ResetForm(FormPreference preference)
        {
            if (preference.Open)
            {
                Form form = FormManager.GetFormByName(preference.Name);
                form.Location = new Point(0, 0);
                form.Size = new Size(900, 500);
                UpdateFormPreferences(form, true);
            }
            else
            {
                FormPreferences.Remove(preference);
            }
        }
        public static void UpdateColorControls(Control myControl)
        {
            myControl.BackColor = preferences.Theme.FormBackground;
            myControl.ForeColor = preferences.Theme.Text;

            if (myControl is FastObjectListView)
            {
                FastObjectListView listView = myControl as FastObjectListView;
                listView.HeaderUsesThemes = false;
                var headerstyle = new HeaderFormatStyle();
                headerstyle.SetBackColor(preferences.Theme.HeaderBackground);
                headerstyle.SetForeColor(preferences.Theme.HeaderText);

                foreach (OLVColumn item in listView.Columns)
                {
                    item.HeaderFormatStyle = headerstyle;
                }
            }
            /*
            switch (myControl)
            {
                case Button b:
                case GroupBox g:
                case Label l:
                case ToolStrip t:
                //case ToolStripDropDown cm:
                    myControl.BackColor = preferences.Theme.FormBackground;
                    myControl.ForeColor = preferences.Theme.Text;
                    break;

                case FastObjectListView f:
                    FastObjectListView listView = myControl as FastObjectListView;
                    listView.HeaderUsesThemes = false;

                    myControl.BackColor = preferences.Theme.FormBackground;
                    myControl.ForeColor = preferences.Theme.Text;

                    var headerstyle = new HeaderFormatStyle();
                    headerstyle.SetBackColor(preferences.Theme.HeaderBackground);
                    headerstyle.SetForeColor(preferences.Theme.HeaderText);

                    foreach (OLVColumn item in listView.Columns)
                    {
                        item.HeaderFormatStyle = headerstyle;
                    }
                    break;

                default:
                    //AddLogMessage(Name, "UpdateColorControls", "CONTROL NOT DEFINED : " + myControl.GetType(), LogMessageType.DEBUG);
                    break;
            }
            */

            /*
            if (myControl is ContextMenuStrip)
            {
                myControl.BackColor = preferences.Theme.FormBackground;
                myControl.ForeColor = preferences.Theme.Text;
            }
            
            // Any other non-standard controls should be implemented here aswell...
            */
            foreach (Control subC in myControl.Controls)
            {
                UpdateColorControls(subC);
            }
            
        }
        public static bool UpdateFontPreferences()
        {
            //AddLogMessage(Name, "UpdateFontPreferences", "FUNCTION NEEDED HERE", LogMessageType.OTHER);
            FormManager.UpdateControlUIs(true);
            return true;
        }
        public static void UpdateFormPreferences(Form form, bool open)
        {
            //LogManager.AddLogMessage(Name, "UpdateFormPreferences", "form : " + form.Name + " | " + form.Font.FontFamily + " | " + form.Size + " | " + form.Location, LogMessageType.DEBUG);
            FormPreference prefs = FormPreferences.FirstOrDefault(item => item.Name == form.Name);

            if (prefs != null)
            {
                prefs.Location = new Point(form.Location.X, form.Location.Y);
                prefs.Size = new Size(form.Size.Width, form.Size.Height);
                prefs.Font = new Font(form.Font.FontFamily, form.Font.Size, form.Font.Style);
                prefs.Open = open;
            }
            else
            {
                FormPreferences.Add(new FormPreference() { Name = form.Name, Location = form.Location, Size = form.Size, Font = form.Font, Open = open });
            }
            UpdatePreferenceFile(PreferenceType.Form);
        }
        public static void UpdatePreferenceFile(PreferenceType type = PreferenceType.None)
        {
            string iniPath = WorkDirectory + "\\" + type + "Preferences.ini";
            string json = String.Empty;

            switch (type)
            {
                case PreferenceType.None:
                    iniPath = WorkDirectory + "\\Preferences.ini";
                    json = JsonConvert.SerializeObject(preferences);
                    break;

                case PreferenceType.Arbitrage:
                    json = JsonConvert.SerializeObject(ArbitragePreferences);
                    break;

                case PreferenceType.CoinMarketCap:
                    json = JsonConvert.SerializeObject(CoinMarketCapPreferences);
                    break;

                case PreferenceType.CryptoCompare:
                    json = JsonConvert.SerializeObject(CryptoComparePreferences);
                    break;

                case PreferenceType.EarnGG:
                    json = JsonConvert.SerializeObject(EarnGGPreferences);
                    break;

                case PreferenceType.Exchange:
                    json = JsonConvert.SerializeObject(ExchangePreferences);
                    break;

                case PreferenceType.Form:
                    json = JsonConvert.SerializeObject(FormPreferences);
                    break;

                case PreferenceType.TradingView:
                    json = JsonConvert.SerializeObject(TradingViewPreferences);
                    break;

                case PreferenceType.Wallet:
                    json = JsonConvert.SerializeObject(WalletPreferences);
                    break;

                default:
                    AddLogMessage(Name, "UpdatePreferenceFile", "Preference Not Defined : " + type, LogMessageType.DEBUG);
                    break;
            }
            //AddLogMessage(Name, "UpdatePreferencesFile", "writing to iniPath - " + iniPath, LogMessageType.DEBUG);
            if (json.Length > 0)
            {
                string text = Encrypt(json);
                File.WriteAllText(@iniPath, text);
            }
        }
        public static bool UpdatePreferenceSnapshots()
        {
            preferences.Balances = Balances.ToList();
            preferences.Tickers = Tickers.ToList();
            ExchangePreferences.Exchanges = Exchanges.ToList();

            foreach (Form form in Application.OpenForms)
            {
                UpdateFormPreferences(form, true);
            }

            var values = EnumUtils.GetValues<PreferenceType>();
            foreach (PreferenceType type in values)
            {
                //AddLogMessage(Name, "UpdatePreferenceSnapshots", type.ToString() + " | " + type.GetHashCode(), LogMessageType.DEBUG);
                UpdatePreferenceFile(type);
            }
            AddLogMessage(Name, "UpdatePreferenceSnapshots", "Snapshots Complete", LogMessageType.LOG);
            return true;
        }
        public static void UpdateTheme(ThemeType type)
        {

            if (type == ThemeType.Dark)
            {
                // DARK MODE
                preferences.Theme = new ThemePreference()
                {
                    type = ThemeType.Dark,
                    Green = Color.DarkGreen,
                    Red = Color.DarkRed,
                    Yellow = Color.DarkGoldenrod,
                    //BrowserBackground = ColorTranslator.FromHtml("#333333"),
                    FormBackground = ColorTranslator.FromHtml("#333333"),
                    Text = ColorTranslator.FromHtml("#eaeaea"),
                    HeaderBackground = ColorTranslator.FromHtml("#444444"),
                    HeaderText = ColorTranslator.FromHtml("#fcfbef")
                };
            }
            else
            {
                // DEFAULT MODE
                preferences.Theme = new ThemePreference()
                {
                    type = ThemeType.Default
                };
            }

            foreach (Form form in Application.OpenForms)
            {
                form.BackColor = preferences.Theme.FormBackground;
                form.ForeColor = preferences.Theme.Text;

                foreach (Control c in form.Controls)
                {
                    UpdateColorControls(c);
                }
            }
            FormManager.UpdateControlUIs();
            UpdatePreferenceFile();
        }
        #endregion

        #region DataModels
        public class Preferences
        {
            public Size IconSize { get; set; } = new Size(32, 32);
            public bool UseGlobalFont { get; set; } = false;
            public Font Font { get; set; } = new Font("Times New Roman", 12.0f);
            public ThemePreference Theme { get; set; } = new ThemePreference();

            public List<ExchangeApi> ApiList { get; set; } = new List<ExchangeApi>();
            public List<string> SymbolWatchList { get; set; } = new List<string>();

            // FLAGS
            public ExchangeTimerType TimerFlags { get; set; } = ExchangeTimerType.NONE;
            public LogMessageType MessageFlags { get; set; } = LogMessageType.NONE;
            // SNAPSHOTS
            public List<ExchangeBalance> Balances { get; set; } = new List<ExchangeBalance>();
            public List<ExchangeTicker> Tickers { get; set; } = new List<ExchangeTicker>();
        }
        // CUSTOM PREFERENCES
        public class ArbitragePreference
        {
            public bool ShowCharts { get; set; } = true;
            public List<ExchangeTicker> ArbitrageWatchList { get; set; } = new List<ExchangeTicker>();
        }
        public class CoinMarketCapPreference
        {
            public List<CoinMarketCapTicker> Tickers = new List<CoinMarketCapTicker>();
        }
        public class CryptoComparePreference
        {
            public string Symbol { get; set; } = "BTC";
            public string Market { get; set; } = "USD";
            public string Theme { get; set; } = "Dark";

            public CryptoCompareWidgetType WidgetType { get; set; } = CryptoCompareWidgetType.ChartAdvanced;
            public CryptoCompareChartPeriod PeriodType { get; set; } = CryptoCompareChartPeriod.Day_1D;
            public CryptoCompareFeedType feedType = CryptoCompareFeedType.CoinTelegraph;
            public List<CryptoCompareCoin> CoinList { get; set; } = new List<CryptoCompareCoin>();
        }
        public class EarnGGPreference
        {
            public List<EarnGG.EarnGGAccount> EarnGGAccounts { get; set; } = new List<EarnGG.EarnGGAccount>();
        }
        public class ExchangePreference
        {
            public List<ExchangeManager.Exchange> Exchanges { get; set; } = new List<ExchangeManager.Exchange>();
        }
        public class FormPreference
        {
            public string Name { get; set; }
            public Point Location { get; set; }
            public Size Size { get; set; }
            public Font Font { get; set; }
            public bool Open { get; set; }
        }      
        public class ThemePreference
        {
            public ThemeType type = ThemeType.Default;
            public Color Green { get; set; } = Color.LightGreen;
            public Color Red { get; set; } = Color.LightPink;
            public Color Yellow { get; set; } = Color.LightGoldenrodYellow;

            public Color FormBackground { get; set; } = Color.White;
            public Color Text { get; set; } = Color.Black;
            public Color HeaderBackground { get; set; } = Color.White;
            public Color HeaderText { get; set; } = Color.Black;
            public string BrowserBackgroundColor
            {
                get
                {
                    return ColorTranslator.ToHtml(FormBackground);
                }
            }
        }
        public class TradingViewPreference
        {
            //public TradingViewAdvancedChartParameters parameters { get; set; } = new TradingViewAdvancedChartParameters();
            public TradingViewAdvancedChartParameters AdvancedChartParameters { get; set; } = new TradingViewAdvancedChartParameters();
            //public TradingViewAdvancedChartParameters CustomParameters { get; set; } = new TradingViewAdvancedChartParameters();
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
        public class WalletPreference
        {
            public List<WalletManager.WalletBalance> Wallets { get; set; } = new List<WalletManager.WalletBalance>();
        }
        #endregion

        #region Enums
        public enum PreferenceType
        {
            [Description("Options")]
            None,

            [Description("ArbitrageManager")]
            Arbitrage,

            [Description("CoinMarketCap")]
            CoinMarketCap,

            [Description("CryptoCompare")]
            CryptoCompare,

            [Description("EarnGGManager")]
            EarnGG,

            [Description("ExchangeManager")]
            Exchange,

            [Description("Options")]
            Form,

            [Description("TradingView")]
            TradingView,

            [Description("WalletManager")]
            Wallet
        }
        public enum ThemeType
        {
            Default,
            Dark
        }
        #endregion
    }
    // -------------------------------
    public class WalletManager
    {
        #region Properties
        private static string Name { get; } = "WalletManager";
        //public static WalletManagerControl walletManagerControl;
        public static ImageList WalletIconList = new ImageList();
        #endregion

        #region Initialize
        /*
        public static void Initialize()
        {
            //WalletIconList.Images.Clear();
            //WalletIconList.ImageSize = new Size(32, 32);

            ContentManager.ExchangeIconList.Images.Add("BlockIO", ContentManager.GetIconByUrl(ContentManager.BlockIOIconUrl));
            ContentManager.ExchangeIconList.Images.Add("Exodus", ContentManager.GetIconByUrl(ContentManager.ExodusIconUrl));
            ContentManager.ExchangeIconList.Images.Add("", ContentManager.GetIconByUrl(ContentManager.WalletIconUrl));
        }
        */
        #endregion

        #region Getters
            /*
        public static Bitmap GetWalletIcon(string walletName)
        {
            switch (walletName)
            {
                case "BlockIO":
                    return ContentManager.GetIconByUrl(ContentManager.BlockIOIconUrl);

                case "Exodus":
                    //return ContentManager.ResizeImage(ContentManager.GetIconByUrl(ContentManager.BalanceIconUrl), 32, 32);
                    return ContentManager.GetIconByUrl(ContentManager.ExodusIconUrl);

                default:
                    return new Bitmap(ContentManager.GetIcon("WalletManager"));
            }
        }
        */
        public static List<ExchangeBalance> GetWalletBalances()
        {
            List<ExchangeBalance> list = new List<ExchangeBalance>();

            foreach (WalletBalance wallet in WalletPreferences.Wallets)
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
        /*
        public static void UpdateUI()
        {
            if (FormManager.walletManagerControl != null)
            {
                FormManager.walletManagerControl.UpdateUI();
            }
        }
        */
        public static bool UpdateWallets()
        {
            foreach (WalletBalance balance in WalletPreferences.Wallets)
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
            //UpdatePreferenceSnapshots();
            UpdatePreferenceFile(PreferenceType.Wallet);
            //UpdateUI();
            FormManager.UpdateWalletManager();
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