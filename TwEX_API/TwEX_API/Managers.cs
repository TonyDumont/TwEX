﻿using BrightIdeasSoftware;
using CefSharp;
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
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
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
        public static List<Image> Images = new List<Image>();
        // URL LISTS
        public static List<ImageFile> IconUrlList = new List<ImageFile>()
        {
            new ImageFile(){ Name = "Add", Url = "http://files.softicons.com/download/system-icons/ikons-icons-by-studiotwentyeight/png/256/Add.png"},
            new ImageFile(){ Name = "AddWallet", Url = "https://cdn2.iconfinder.com/data/icons/finance-solid-icons-vol-3/48/112-256.png" },
            new ImageFile(){ Name = "Arbitrage", Url = "https://orig00.deviantart.net/1028/f/2015/299/f/6/app_store_look_like_software_center_icon__1024__by_kayover-d9efmjt.png" },
            new ImageFile(){ Name = "ArbitrageManager", Url = "https://orig00.deviantart.net/1028/f/2015/299/f/6/app_store_look_like_software_center_icon__1024__by_kayover-d9efmjt.png" },
            new ImageFile(){ Name = "Application", Url = "http://www.iconeasy.com/icon/png/System/Stainless/preferences.png" },
            new ImageFile(){ Name = "BalanceManager", Url = "https://i.pinimg.com/originals/22/dd/de/22ddde0fc220582cf3688beca1795683.jpg" },
            new ImageFile(){ Name = "BlockCypher", Url = "https://www.blockcypher.com/images/favicon-192x192.png" },
            new ImageFile(){ Name = "BlockIO", Url = "https://block.io/favicon.ico" },
            new ImageFile(){ Name = "ChartView", Url = "https://cdn1.iconfinder.com/data/icons/web-design-seo/512/26-512.png" },
            new ImageFile(){ Name = "CoinCalculator", Url = "http://files.softicons.com/download/system-icons/web0.2ama-icons-by-chrfb/png/256x256/Calculator.png" },
            new ImageFile(){ Name = "CoinMarketCap", Url = "https://images-na.ssl-images-amazon.com/images/I/61G3KF2yniL.png" },
            new ImageFile(){ Name = "CryptoCompare", Url = "https://www.cryptocompare.com/media/20562/favicon.png?v=2" },
            new ImageFile(){ Name = "CustomView", Url ="http://cdn.mysitemyway.com/icons-watermarks/simple-black/bfa/bfa_table/bfa_table_simple-black_512x512.png" },
            new ImageFile(){ Name = "Deposit", Url = "https://cdn2.iconfinder.com/data/icons/inverticons-stroke-vol-2/32/money_finance_coins_economy_gold_cash_deposit_income-512.png" },
            new ImageFile(){ Name = "Down", Url = "https://cdn1.iconfinder.com/data/icons/basic-shaded-ui/256/down-512.png" },
            new ImageFile(){ Name = "EarnGG", Url = "https://earn.gg/img/favicon-32x32.png" },
            new ImageFile(){ Name = "EarnGGManager", Url = "https://earn.gg/img/favicon-32x32.png" },
            new ImageFile(){ Name = "Exchange", Url = "http://www.eopcje.pl/wp-content/uploads/2014/12/currency_market.png" },
            //new ImageFile(){ Name = "ExchangeEditor", Url = "http://www.eopcje.pl/wp-content/uploads/2014/12/currency_market.png" },
            new ImageFile(){ Name = "ExchangeManager", Url = "http://www.eopcje.pl/wp-content/uploads/2014/12/currency_market.png" },
            new ImageFile(){ Name = "Exodus", Url = "https://www.exodus.io/favicon-32x32.png?v=oLLkoG3aJr" },
            new ImageFile(){ Name = "Export", Url = "http://files.softicons.com/download/toolbar-icons/mono-general-icons-2-by-custom-icon-design/png/128x128/export.png" },
            new ImageFile(){ Name = "Font", Url = "https://cdn0.iconfinder.com/data/icons/exempli_gratia/256/z_File_FONT.png" },
            new ImageFile(){ Name = "FontDecrease", Url = "https://glanmirekennels.com.au/wp-content/themes/glanmire-kennels/img/font-smaller.png" },
            new ImageFile(){ Name = "FontIncrease", Url = "https://glanmirekennels.com.au/wp-content/themes/glanmire-kennels/img/font-larger.png" },
            new ImageFile(){ Name = "Form", Url = "http://www.iconeasy.com/icon/png/System/Stainless/preferences.png" },
            new ImageFile(){ Name = "Import", Url = "http://files.softicons.com/download/toolbar-icons/mono-general-icons-2-by-custom-icon-design/png/128x128/import.png" },
            new ImageFile(){ Name = "LogManager", Url = "https://image.flaticon.com/icons/png/512/28/28822.png" },

            new ImageFile(){ Name = "Options", Url = "http://www.iconeasy.com/icon/png/System/Stainless/preferences.png" },
            new ImageFile(){ Name = "PreferenceManager", Url = "http://www.iconeasy.com/icon/png/System/Stainless/preferences.png" },
            //new ImageFile(){ Name = "Refresh", Url = "https://cdn0.iconfinder.com/data/icons/huge-basic-icons/512/Refresh.png" },
            new ImageFile(){ Name = "Refresh", Url = "http://download.easyicon.net/png/1072711/128/" },
            new ImageFile(){ Name = "Remove", Url = "http://files.softicons.com/download/system-icons/ikons-icons-by-studiotwentyeight/png/256/Delete.png"},
            new ImageFile(){ Name = "SearchList", Url = "http://icons.iconarchive.com/icons/icons8/windows-8/512/Programming-Search-Property-icon.png"},
            new ImageFile(){ Name = "Symbol", Url = "https://cdn2.iconfinder.com/data/icons/bitcoin-and-mining/44/trade-512.png" },
            new ImageFile(){ Name = "SymbolOverview", Url= "https://cdn0.iconfinder.com/data/icons/seo-and-internet-marketing/70/SEO_and_Internet_Marketing-02-512.png"},
            //new ImageFile(){ Name = "TradingView", Url = "https://www.tradingview.com/favicon.ico" },
            new ImageFile(){ Name = "TradingView", Url = "http://www.patternsmart.com/cart//image/data/tradingview.png" },
            new ImageFile(){ Name = "TwEX_FormEditor", Url = "http://www.iconeasy.com/icon/png/System/Stainless/preferences.png" },
            //new ImageFile(){ Name = "UpDown", Url = "https://cdn1.iconfinder.com/data/icons/touch-gestures-3/96/Scroll-512.png"},
            new ImageFile(){ Name = "UpDown", Url = "http://cdn.mysitemyway.com/etc-mysitemyway/icons/legacy-previews/icons/3d-glossy-green-orbs-icons-arrows/103269-3d-glossy-green-orb-icon-arrows-two-ways-up-down.png"},
            new ImageFile(){ Name = "Up", Url = "https://cdn1.iconfinder.com/data/icons/basic-shaded-ui/256/up-512.png" },
            new ImageFile(){ Name = "USDSymbol", Url = "http://www.tirosagol.com/wp-content/uploads/moneyTAG.jpg"},
            new ImageFile(){ Name = "Wallet", Url = "https://cdn.iconscout.com/public/images/icon/premium/png-512/wallet-3a62a21639a59921-512x512.png" },
            new ImageFile(){ Name = "WalletManager", Url = "https://cdn.iconscout.com/public/images/icon/premium/png-512/wallet-3a62a21639a59921-512x512.png" },
            new ImageFile(){ Name = "Withdrawal", Url = "https://cdn2.iconfinder.com/data/icons/inverticons-stroke-vol-2/32/money_finance_coins_economy_gold_cash_withdraw_expenses-256.png" },

            // IMAGES
            //new ImageFile(){ Name = "WhiteStone", Url = "https://www.brewsterwallcovering.com/data/default/images/catalog/original/OM91808.jpg"}
            //new ImageFile(){ Name = "WhiteStone", Url = "https://www.designertileconcepts.com/media/catalog/product/cache/4/image/700x700/9df78eab33525d08d6e5fb8d27136e95/4/y/4yur0120_3.jpg" }
            //new ImageFile(){ Name = "WhiteStone", Url = "http://1.bp.blogspot.com/-A6jxRCVEt54/UxbiNL3VV7I/AAAAAAAAFSM/S9aEW1ntIg8/s1600/Smooth_stucco_white_paint_dirty_plaster_wall_texture_seamless_tileable.jpg" }
        };
        public static List<ImageFile> ImageUrlList = new List<ImageFile>()
        {

            // IMAGES
            new ImageFile(){ Name = "StonedBackground", Url = "https://www.brewsterwallcovering.com/data/default/images/catalog/original/OM91808.jpg"}
            //new ImageFile(){ Name = "WhiteStone", Url = "https://www.designertileconcepts.com/media/catalog/product/cache/4/image/700x700/9df78eab33525d08d6e5fb8d27136e95/4/y/4yur0120_3.jpg" }
            //new ImageFile(){ Name = "WhiteStone", Url = "http://1.bp.blogspot.com/-A6jxRCVEt54/UxbiNL3VV7I/AAAAAAAAFSM/S9aEW1ntIg8/s1600/Smooth_stucco_white_paint_dirty_plaster_wall_texture_seamless_tileable.jpg" }
        };
        public static List<ImageFile> WalletIconUrlList = new List<ImageFile>()
        {
            new ImageFile(){ Name = "Armory", Url = "https://pbs.twimg.com/profile_images/378800000443755723/365662ad79083b1cf8d1975741bb8d2b_400x400.png" },
            new ImageFile(){ Name = "BlockIO", Url = "https://block.io/favicon.ico" },
            new ImageFile(){ Name = "Electrum", Url = "http://icons.iconarchive.com/icons/alecive/flatwoken/512/Apps-Electrum-icon.png"},
            new ImageFile(){ Name = "Exodus", Url = "https://www.exodus.io/favicon-32x32.png?v=oLLkoG3aJr" }

        };
        #endregion

        #region Initialize
        public static Boolean InitializeExchangeIconList()
        {
            ExchangeIconList.Images.Clear();
            //string path = @"c:\\Windows\\Loader\\Applications\\symbols\\";
            string path = DataDirectory + "\\exchanges\\";
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
            string path = DataDirectory + "\\icons\\";
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
                foreach (ImageFile icon in IconUrlList)
                {                   
                    GetIcon(icon.Name);
                }
            }
            AddLogMessage(Name, "InitializeIconList", "Icon List Initialized " + IconList.Images.Count + " Icons", LogMessageType.LOG);
            return true;
        }
        
        public static Boolean InitializeImages()
        {
            Images.Clear();
            string path = DataDirectory + "\\images\\";
            string[] filter = { ".png" };

            //IconList.ImageSize = preferences.IconSize;

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
                            //IconList.Images.Add(name, img);
                            img.Tag = name;
                        }
                    }
                }
            }
            else
            {
                // CREATE FOLDER
                AddLogMessage(Name, "InitializeImages", "IMAGES folder does not exist - CREATING IT", LogMessageType.LOG);
                Directory.CreateDirectory(path);
                foreach (ImageFile image in ImageUrlList)
                {
                    GetImage(image.Name);
                }
            }
            AddLogMessage(Name, "InitializeImages", "Image List Initialized " + Images.Count + " Images", LogMessageType.LOG);
            return true;
        }
        public static Boolean InitializeSymbolImageList()
        {
            SymbolIconList.Images.Clear();
            //string path = @"c:\\Windows\\Loader\\Applications\\symbols\\";
            string path = PreferenceManager.DataDirectory + "\\symbols\\";
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
            string path = DataDirectory + "\\wallets\\";
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
                            ExchangeIconList.Images.Add(wallet, img);
                        }
                    }
                }
            }
            else
            {
                // CREATE FOLDER
                Directory.CreateDirectory(path);
                foreach (ImageFile icon in WalletIconUrlList)
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
                LogManager.AddLogMessage(Name, "DoesUrlRespond", ex.Message + " | " + url, LogMessageType.EXCEPTION);
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
                        icon.Save(DataDirectory + "\\exchanges\\" + name + ".png", ImageFormat.Png);
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
                    ImageFile ImageFile = IconUrlList.FirstOrDefault(item => item.Name == name);

                    if (ImageFile != null)
                    {
                        Image icon = GetIconByUrl(ImageFile.Url);
                        IconList.Images.Add(name, icon);
                        icon.Save(DataDirectory + "\\icons\\" + name + ".png", ImageFormat.Png);
                        //AddLogMessage(Name, "GetIcon", "Saving " + name + ".png in ICONS FOLDER", LogMessageType.LOG);
                        return icon;
                    }
                    else
                    {
                        //AddLogMessage(Name, "GetIcon", "Unable To Save " + name + ".png in ICONS FOLDER - No Entry In IconUrl List", LogMessageType.LOG);
                        return image;
                    }               
                }
                catch (Exception)
                {
                    //AddLogMessage(Name, "GetIcon", name + " | " + ex.Message, LogMessageType.EXCEPTION);
                    // USE GENERIC ICON
                    return image;
                }
            }
        }

        public static Image GetImage(string name)
        {
            //Image image = Properties.Resources.ConnectionStatus_DISABLED;
            // check imagelist for exist

            Image image = Images.FirstOrDefault(item => item.Tag.ToString() == name);

            if (image != null)
            {
                //AddLogMessage(Name, "GetImage", "Image List Contains Key " + name + " - Returning Image", LogMessageType.DEBUG);
                return image;
            }
            else
            {
                // set it up for later
                //AddLogMessage(Name, "GetImage", "Image List MISSING " + name + " - SETTING UP", LogMessageType.DEBUG);
                try
                {
                    ImageFile ImageFile = ImageUrlList.FirstOrDefault(item => item.Name == name);

                    if (ImageFile != null)
                    {
                        Image newImage = GetIconByUrl(ImageFile.Url);
                        //IconList.Images.Add(name, newImage);
                        newImage.Tag = name;
                        Images.Add(newImage);
                        newImage.Save(DataDirectory + "\\images\\" + name + ".png", ImageFormat.Png);
                        //AddLogMessage(Name, "GetIcon", "Saving " + name + ".png in ICONS FOLDER", LogMessageType.LOG);
                        return newImage;
                    }
                    else
                    {
                        //AddLogMessage(Name, "GetIcon", "Unable To Save " + name + ".png in ICONS FOLDER - No Entry In IconUrl List", LogMessageType.LOG);
                        return null;
                    }
                }
                catch (Exception)
                {
                    //AddLogMessage(Name, "GetIcon", name + " | " + ex.Message, LogMessageType.EXCEPTION);
                    // USE GENERIC ICON
                    return null;
                }
            }
        }

        public static Image GetSymbolIcon(string symbol)
        {
            Image image = Properties.Resources.ConnectionStatus_DISABLED;
            // check imagelist for exist
            if (symbol != null)
            {
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
                                img.Save(DataDirectory + "\\symbols\\" + symbol.ToUpper() + ".png", ImageFormat.Png);

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
            else
            {
                return image;
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
                    ImageFile wallet = WalletIconUrlList.FirstOrDefault(item => item.Name == name);

                    if (wallet != null)
                    {
                        Image icon = GetIconByUrl(wallet.Url);
                        WalletIconList.Images.Add(name, icon);
                        icon.Save(DataDirectory + "\\wallets\\" + name + ".png", ImageFormat.Png);
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
            foreach (ImageFile icon in IconUrlList)
            {
                AddLogMessage(Name, "SaveIcons", icon.Name + " | " + icon.Url, LogMessageType.DEBUG);
                GetIcon(icon.Name);
            }
        }
        #endregion

        #region DataModels
        public class ImageFile
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
        public static BlockingCollection<ExchangeOrder> Orders = new BlockingCollection<ExchangeOrder>();
        public static BlockingCollection<ExchangeTicker> Tickers = new BlockingCollection<ExchangeTicker>();
        public static BlockingCollection<ExchangeTransaction> Transactions = new BlockingCollection<ExchangeTransaction>();
        #endregion Properties

        #region Initialize      
        public static Boolean InitializeExchanges()
        {
            List<string> list = getExchangeList();

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
                            exchange.HasAPI = true;
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
                    listItem.HasAPI = exchange.HasAPI;
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
                case 15:
                case 30:
                case 45:
                    //LogManager.AddLogMessage(thisClassName, "TimerTick", "Hourly Check : " + DateTime.Now, LogManager.LogMessageType.DEBUG);
                    /*
                    if (now.Hour == 0 && now.Minute == 0)
                    {
                        //LogManager.AddLogMessage(thisClassName, "TimerTick", "ITS MIDNIGHT : " + DateTime.Now, LogManager.LogMessageType.DEBUG);
                    }

                    bool hasBalanceType = (preferences.TimerFlags & ExchangeTimerType.BALANCES) != ExchangeTimerType.NONE;
                    if (hasBalanceType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Exchange Balances", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => updateBalances());
                    }

                    bool hasOrderType = (preferences.TimerFlags & ExchangeTimerType.ORDERS) != ExchangeTimerType.NONE;
                    if (hasOrderType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Exchange Orders", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => updateOrders());
                    }
                    */
                    bool hasWalletType = (preferences.TimerFlags & ExchangeTimerType.WALLETS) != ExchangeTimerType.NONE;
                    if (hasWalletType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Wallets", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => WalletManager.UpdateWallets());
                    }
                    /*
                    bool hasHistoryType = (preferences.TimerFlags & ExchangeTimerType.HISTORY) != ExchangeTimerType.NONE;
                    if (hasHistoryType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Wallets", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => updateTransactions());
                    }

                    bool hasEarnGGType = (preferences.TimerFlags & ExchangeTimerType.EARNGG) != ExchangeTimerType.NONE;
                    if (hasEarnGGType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Wallets", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => EarnGG.UpdateAccounts());

                    }
                    */
                    break;

                

                case 5:
                case 10:
                
                case 20:
                case 25:
                
                case 35:
                case 40:
                
                case 50:
                case 55:
                    bool hasBalanceType = (preferences.TimerFlags & ExchangeTimerType.BALANCES) != ExchangeTimerType.NONE;
                    if (hasBalanceType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Exchange Balances", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => updateBalances());
                    }

                    bool hasOrderType = (preferences.TimerFlags & ExchangeTimerType.ORDERS) != ExchangeTimerType.NONE;
                    if (hasOrderType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Exchange Orders", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => updateOrders());
                    }
                    /*
                    bool hasWalletType = (preferences.TimerFlags & ExchangeTimerType.WALLETS) != ExchangeTimerType.NONE;
                    if (hasWalletType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Wallets", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => WalletManager.UpdateWallets());
                    }
                    */
                    bool hasHistoryType = (preferences.TimerFlags & ExchangeTimerType.HISTORY) != ExchangeTimerType.NONE;
                    if (hasHistoryType)
                    {
                        //LogManager.AddLogMessage(Name, "TimerTick", "Updating All Wallets", LogManager.LogMessageType.DEBUG);
                        Task.Factory.StartNew(() => updateTransactions());
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
                        AddLogMessage(Name, "getCurrencyList", "type is NULL : " + exchangeName, LogManager.LogMessageType.DEBUG);
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
                AddLogMessage(Name, "getCurrencyList", "EXCEPTION!!! : " + ex.Message);
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

        public static ExchangeTransactionType GetExchangeTransactionType(string name)
        {
            switch (name.ToLower())
            {
                case "buy":
                    return ExchangeTransactionType.buy;

                case "sell":
                    return ExchangeTransactionType.sell;

                case "deposit":
                case "payin":
                    return ExchangeTransactionType.deposit;         

                case "withdrawal":
                case "withdraw":
                case "payout":
                    return ExchangeTransactionType.withdrawal;

                default:
                    //AddLogMessage(Name, "GetExchangeTransactionType", name + " TYPE NOT DEFINED!!!", LogMessageType.DEBUG);
                    return ExchangeTransactionType.transfer;
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
                    if (newItem.last > 0)
                    {
                        list.Add(newItem);
                    }
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
        public static bool CreateNewOrder(string exchangeName, ExchangeOrderType orderType, string symbol, string market, decimal rate, decimal amount)
        {
            Type exchangeType = getExchangeType(exchangeName);
            if (exchangeType != null)
            {
                AddLogMessage(Name, "CreateNewOrder", "type is : " + exchangeType.Name);
                //CreateOrder(ExchangeOrderType type, string symbol, string market, decimal rate, decimal amount)
                Task.Factory.StartNew(() => exchangeType.InvokeMember("CreateOrder",
                        BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                        null,
                        exchangeType,
                        new object[] { orderType, symbol, market, rate, amount }
                        ));
            }
            else
            {
                AddLogMessage(Name, "updateExchangeBalanceList", "type is NULL : " + exchangeName, LogMessageType.DEBUG);
            }
            return true;
        }
        public static bool ClearBalances(string exchangeName)
        {
            Balances = new BlockingCollection<ExchangeBalance>(new ConcurrentQueue<ExchangeBalance>(Balances.Where(balance => balance.Exchange != exchangeName)));
            return true;
        }
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
        public static void processOrder(ExchangeOrder order)
        {
            ExchangeOrder listItem = Orders.FirstOrDefault(item => item.id == order.id && item.exchange == order.exchange);

            if (listItem != null)
            {
                // UPDATE
                listItem.amount = order.amount;
                listItem.total = order.total;
                listItem.open = order.open;
                listItem.date = order.date;
            }
            else
            {
                Orders.Add(order);
                //AddLogMessage(Name, "processOrder", "Added " + order.symbol + " for " + order.exchange, LogMessageType.DEBUG);
            }
            // UI UPDATE
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
        public static void processTransaction(ExchangeTransaction transaction)
        {
            ExchangeTransaction listItem = Transactions.FirstOrDefault(item => item.id == transaction.id && item.exchange == transaction.exchange);

            if (listItem != null)
            {
                // UPDATE
                listItem.amount = transaction.amount;
                listItem.confirmations = transaction.confirmations;
                listItem.datetime = transaction.datetime;
            }
            else
            {
                Transactions.Add(transaction);
                //AddLogMessage(Name, "processTransaction", "Added " + transaction.id + " for " + transaction.exchange, LogMessageType.DEBUG);
            }
            // UI UPDATE
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
                            AddLogMessage(Name, "updateExchangeBalanceList", "This Method Requires API CREDENTIALS", LogMessageType.OTHER);
                        }
                    }
                    else
                    {
                        AddLogMessage(Name, "updateExchangeBalanceList", "type is NULL : " + exchangeName, LogMessageType.DEBUG);
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
                                AddLogMessage(Name, "updateExchangeBalanceList", "Balance List Requires API CREDENTIALS for " + exchange.Name, LogMessageType.OTHER);
                            }
                        }
                        else
                        {
                            AddLogMessage(Name, "updateExchangeBalanceList", "type is NULL : " + exchangeName, LogMessageType.DEBUG);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddLogMessage(Name, "updateBalanceList", "EXCEPTION!!! : " + ex.Message);
            }

            //updateControls();
            FormManager.UpdateForms();
        }

        /// <summary>Updates ORDERS COLLECTION for an exchange or ALL if no name specified</summary>
        public static void updateOrders(string exchangeName = "")
        {
            try
            {
                if (exchangeName.Length > 0)
                {
                    Type type = getExchangeType(exchangeName);
                    if (type != null)
                    {
                        //LogManager.AddLogMessage(Name, "updateOrders", "type is : " + type.Name);
                        var api = type.GetProperty("Api", BindingFlags.Public | BindingFlags.Static).GetValue(null);

                        if (api != null)
                        {
                            
                            Task.Factory.StartNew(() => type.InvokeMember("updateExchangeOrderList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
                                
                        }
                        else
                        {
                            AddLogMessage(Name, "updateOrders", "This Method Requires API CREDENTIALS", LogMessageType.OTHER);
                        }
                    }
                    else
                    {
                        AddLogMessage(Name, "updateOrders", "type is NULL : " + exchangeName, LogMessageType.DEBUG);
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
                                
                                Task.Factory.StartNew(() => type.InvokeMember("updateExchangeOrderList",
                                                            BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                                            null,
                                                            type,
                                                            null));
                                                            
                            }
                            else
                            {
                                AddLogMessage(Name, "updateOrders", "Order List Requires API CREDENTIALS for " + exchange.Name, LogMessageType.OTHER);
                            }
                        }
                        else
                        {
                            AddLogMessage(Name, "updateOrders", "type is NULL : " + exchangeName, LogMessageType.DEBUG);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddLogMessage(Name, "updateOrders", ex.Message, LogMessageType.EXCEPTION);
            }

            //updateControls();
            //FormManager.UpdateForms();
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
                        AddLogMessage(Name, "updateExchangeTickerList", "type is NULL : " + exchangeName, LogMessageType.DEBUG);
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
                            AddLogMessage(Name, "updateExchangeTickerList", "type is NULL : " + exchangeName, LogMessageType.DEBUG);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddLogMessage(Name, "updateExchangeTickerList", ex.Message, LogMessageType.EXCEPTION);
            }

            //updateControls();
            FormManager.UpdateForms();
        }

        /// <summary>Updates TRANSACTIONS COLLECTION for an exchange or does ALL if no name specified</summary>
        public static void updateTransactions(string exchangeName = "")
        {
            try
            {
                if (exchangeName.Length > 0)
                {
                    
                    Type type = getExchangeType(exchangeName);
                    if (type != null)
                    {
                        //LogManager.AddLogMessage(Name, "updateExchangeTickerList", "type is : " + type.Name);
                        Task.Factory.StartNew(() => type.InvokeMember("updateExchangeTransactionList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
                    }
                    else
                    {
                        AddLogMessage(Name, "updateTransactions", "type is NULL : " + exchangeName, LogManager.LogMessageType.DEBUG);
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
                            Task.Factory.StartNew(() => type.InvokeMember("updateExchangeTransactionList",
                                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                                null,
                                type,
                                null));
                                
                        }
                        else
                        {
                            AddLogMessage(Name, "updateTransactions", "type is NULL : " + exchangeName, LogMessageType.DEBUG);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddLogMessage(Name, "updateTransactions", ex.Message, LogMessageType.EXCEPTION);
            }

            //updateControls();
            //FormManager.UpdateForms();
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

            //public string Symbol { get; set; } = "LTC";
            //public string Market { get; set; } = "BTC";
            public ExchangeTicker CurrentTicker { get; set; } = new ExchangeTicker() { symbol = "LTC", market = "BTC", exchange = "none" };
            public string CurrentMarket { get; set; } = "ALL";
            public int ChartIndex { get; set; } = 0;
            public string TradingView { get; set; }
            public TradingViewAdvancedChartParameters AdvancedChartParameters { get; set; } = new TradingViewAdvancedChartParameters();
            public bool Active { get; set; } = true;
            public bool HasAPI { get; set; } = false;
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
        public class ExchangeOrder
        {
            public string id { get; set; }
            public string type { get; set; } // buy or sell
            public Double rate { get; set; }
            public Double startingAmount { get; set; } // poloniex
            public Double amount { get; set; }
            public Double total { get; set; }
            public DateTime date { get; set; }
            //public int margin { get; set; } // poloniex
            // ADDON
            public string exchange { get; set; }
            public string market { get; set; }
            public string symbol { get; set; }
            public Boolean open { get; set; }
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
        public class ExchangeTransaction
        {
            // KEYS
            public string id { get; set; }
            // STANDARD
            public string currency { get; set; }
            public string address { get; set; }
            public Double amount { get; set; }
            public string confirmations { get; set; }
            public long timestamp { get; set; }
            public DateTime datetime { get; set; }

            public string status { get; set; }
            // ADDON
            public string exchange { get; set; }
            public ExchangeTransactionType type { get; set; }
        }
        #endregion DataModels

        #region Enums
        public enum ExchangeOrderType
        {
            buy,
            sell,
            stop
        }
        public enum BalanceViewType
        {
            balance = 0,
            exchange = 1,
            symbol = 2,
        }

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
        public enum ExchangeTransactionType
        {
            deposit,
            withdrawal,
            transfer,
            fee,
            match,
            payout,
            payin,
            bankToExchange,
            exchangeToBank,
            buy,
            sell
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
        
        public static bool IsCEFDependanciesLoaded()
        {
            var settings = new CefSettings();
            //settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
            
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            //var browser = new BrowserForm();
            //Application.Run(browser);

            return true;
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
            //Form targetForm;
            string formName;
            string formText;
            Icon formIcon;

            if (name != "ExchangeTrading")
            {
                formName = name;
                formText = text;
                formIcon = Icon.FromHandle(new Bitmap(ContentManager.GetIcon(name)).GetHicon());
                //targetForm = GetFormByName(name);
            }
            else
            {
                formName = text;
                formText = text + " Trading";
                formIcon = Icon.FromHandle(new Bitmap(ContentManager.GetExchangeIcon(text)).GetHicon());
                //targetForm = GetFormByName(name + "_" + text);
            }

            Form targetForm = GetFormByName(formName);

            if (targetForm == null)
            {
                Form form = new Form() { Size = new Size(950, 550), Name = formName, Text = formText, Icon = formIcon };
                //SetTheme(preferences.Theme.type, form);
                form.Show();

                FormPreference preference = FormPreferences.FirstOrDefault(item => item.Name == formName);

                if (preference != null)
                {
                    //LogManager.AddLogMessage(Name, "toolStripButton_Form_Click", "FOUND : " + preference.Name + " | " + preference.Font.FontFamily + " | " + preference.Size + " | " + preference.Location);
                    form.SetBounds(preference.Location.X, preference.Location.Y, preference.Size.Width, preference.Size.Height);
                        
                    if (preferences.UseGlobalFont == true)
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
                    AddLogMessage(Name, "toolStripButton_Form_Click", "PREFERENCE NOT FOUND ADDING : " + formName + " | " + formText, LogMessageType.DEBUG);
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

                    case "EarnGGManager":
                        form.Controls.Add(new EarnGGManagerControl() { Dock = DockStyle.Fill });
                        form.FormClosing += delegate { earnGGManagerControl = null; };
                        break;

                        
                    case "ExchangeTrading":
                        ExchangeTradingControl tradeControl = new ExchangeTradingControl() { Dock = DockStyle.Fill };
                        tradeControl.SetExchange(text);
                        form.Controls.Add(tradeControl);
                        
                        break;
                        
                        
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
                SetTheme(preferences.Theme.type, form);
            }
            else
            {
                
                if (targetForm.WindowState == FormWindowState.Minimized)
                {
                    targetForm.WindowState = FormWindowState.Normal;
                }
                targetForm.Activate();
                
            }
            UpdateToolStrip();
        }
        public static void ResetForm(FormPreference preference)
        {
            AddLogMessage(Name, "ResetForm", preference.Name + " | " + preference.Location + " | " + preference.Size + " | " + preference.Open);
            if (preference.Open)
            {
                Form form = GetFormByName(preference.Name);
                form.Location = new Point(0, 0);
                form.Size = new Size(900, 500);
                UpdateFormPreferences(form, true);
            }
            else
            {
                //FormPreferences.Remove(preference);
                preference.Location = new Point(0, 0);
                preference.Size = new Size(900, 500);
                //UpdateFormPreferences(form, true);
            }

            //FormPreferences.Remove(preference);
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
            SetTheme(preferences.Theme.type);
            
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
            UpdateMainControl(resize);
            UpdateTradingViewManager(resize);
            UpdateWalletManager(resize);
            UpdateToolStrip(resize);
        }
        public static void UpdateForms()
        {
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
                //arbitrageManagerControl.SetWatchlist();
                arbitrageManagerControl.UpdateUI(resize);
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
                exchangeManagerControl.UpdateUI(resize);
            }
            //UpdatePreferenceFile(PreferenceType.Exchange);
        }
        public static void UpdateMainControl(bool resize = false)
        {
            if (mainControl != null)
            {
                mainControl.UpdateUI(resize);
            }
            //UpdatePreferenceFile(PreferenceType.TradingView);
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
            string path = Assembly.GetExecutingAssembly().CodeBase;
            string targetPath = Path.GetDirectoryName(path);
            WorkDirectory = new Uri(targetPath).LocalPath;
            DataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\TwEX";

            Directory.CreateDirectory(DataDirectory);
            // CLEAR LOGFILE
            File.Create(DataDirectory + "\\TwEX_Log.txt").Close();
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
                string path = DataDirectory + "\\TwEX_Log.txt";

                if (!File.Exists(path))
                {
                    logFile = new StreamWriter(path);
                }
                else
                {
                    logFile = File.AppendText(path);
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
            /*
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
            */
            return originalString;
        }

        /// <summary>
        /// Decrypt a crypted string.
        /// </summary>
        /// <param name="cryptedString">The crypted string.</param>
        /// <returns>The decrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown when the crypted string is null or empty.</exception>
        public static string Decrypt(string cryptedString)
        {
            /*
            try
            {
                if (String.IsNullOrEmpty(cryptedString))
                {
                    //throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
                    AddLogMessage("Decryptor", "Decrypt", "NULL string provided", LogMessageType.EXCEPTION);
                }

                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(ASCIIEncoding.ASCII.GetBytes("TwEX_API"), ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName)), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptoStream);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                AddLogMessage("Decryptor", "Decrypt", ex.Message, LogMessageType.EXCEPTION);
                return ex.Message;
            }
            */

            return cryptedString;
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
        public static string DataDirectory = string.Empty;
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
            //AddLogMessage(Name, "LoadPreferences", "WorkDirectory = " + WorkDirectory, LogMessageType.LOG);
            //AddLogMessage(Name, "LoadPreferences", "DataDirectory = " + DataDirectory, LogMessageType.LOG);

            string iniPath = WorkDirectory + "\\cef.pak";

            if (!File.Exists(iniPath))
            {
                AddLogMessage(Name, "LoadPreferences", "CEF Dependancies NOT Available - Unzipping Them", LogMessageType.LOG);
                string zipPath = WorkDirectory + "\\Resources\\cef_extensions.zip";
                ZipFile.ExtractToDirectory(zipPath, WorkDirectory);
            }

            iniPath = DataDirectory + "\\Preferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                preferences = JsonConvert.DeserializeObject<Preferences>(json);
                //preferences.SymbolWatchList.Clear();
                AddLogMessage(Name, "LoadPreferences", "PREFERENCES LOADED", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "Preferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile();
            }

            // ARBITRAGE PREFERENCES
            iniPath = DataDirectory + "\\ArbitragePreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                ArbitragePreferences = JsonConvert.DeserializeObject<ArbitragePreference>(json);
                AddLogMessage(Name, "LoadPreferences", ArbitragePreferences.ArbitrageWatchList.Count + " Arbitrage Preferences Loaded", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "ArbitragePreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.Arbitrage);
            }
            
            // CoinMarketCap PREFERENCES
            iniPath = DataDirectory + "\\CoinMarketCapPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                CoinMarketCapPreferences = JsonConvert.DeserializeObject<CoinMarketCapPreference>(json);
                AddLogMessage(Name, "LoadPreferences", CoinMarketCapPreferences.Tickers.Count + " CoinMarketCap Tickers Loaded", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "CoinMarketCapPreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.CoinMarketCap);
            }

            // CryptoCompare PREFERENCES
            iniPath = DataDirectory + "\\CryptoComparePreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                CryptoComparePreferences = JsonConvert.DeserializeObject<CryptoComparePreference>(json);
                AddLogMessage(Name, "LoadPreferences", CryptoComparePreferences.CoinList.Count + " CryptoCompare Coins Loaded", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "CryptoComparePreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.CryptoCompare);
            }

            // EarnGG PREFERENCES
            iniPath = DataDirectory + "\\EarnGGPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                EarnGGPreferences = JsonConvert.DeserializeObject<EarnGGPreference>(json);
                AddLogMessage(Name, "LoadPreferences", EarnGGPreferences.EarnGGAccounts.Count + " EarnGG Accounts Loaded", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "EarnGGPreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.EarnGG);
            }

            // Exchange PREFERENCES
            iniPath = DataDirectory + "\\ExchangePreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                ExchangePreferences = JsonConvert.DeserializeObject<ExchangePreference>(json);
                Exchanges = new BlockingCollection<ExchangeManager.Exchange>(new ConcurrentQueue<ExchangeManager.Exchange>(ExchangePreferences.Exchanges));
                AddLogMessage(Name, "LoadPreferences", ExchangePreferences.Exchanges.Count + " Exchanges Loaded", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "ExchangePreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.Exchange);
            }

            // FORM PREFERENCES
            iniPath = DataDirectory + "\\FormPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                FormPreferences = JsonConvert.DeserializeObject<List<FormPreference>>(json);
                AddLogMessage(Name, "LoadPreferences", FormPreferences.Count + " Form Preferences Loaded", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "FormPreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.Form);
            }

            // Trading View PREFERENCES
            iniPath = DataDirectory + "\\TradingViewPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                TradingViewPreferences = JsonConvert.DeserializeObject<TradingViewPreference>(json);
                AddLogMessage(Name, "LoadPreferences", TradingViewPreferences.WatchList.Count + " TradingView Watchlist Item(s)", LogMessageType.LOG);
            }
            else
            {
                AddLogMessage(Name, "LoadPreferences", "TradingViewPreferences.ini doese not exist - Creating It", LogMessageType.LOG);
                UpdatePreferenceFile(PreferenceType.TradingView);
            }

            // WALLET PREFERENCES
            iniPath = DataDirectory + "\\WalletPreferences.ini";

            if (File.Exists(iniPath))
            {
                string text = File.ReadAllText(iniPath);
                string json = Decrypt(text);
                WalletPreferences = JsonConvert.DeserializeObject<WalletPreference>(json);
                AddLogMessage(Name, "LoadPreferences", WalletPreferences.Wallets.Count + " Wallets Loaded", LogMessageType.LOG);
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
            //AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.ApiList.Count + " APIS", LogMessageType.LOG);
            //AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.SymbolWatchList.Count + " Symbols In Watchlist", LogMessageType.LOG);
            
            //AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.Balances.Count + " Balances", LogMessageType.LOG);
            if (preferences.Balances.Count > 0)
            {
                Balances = new BlockingCollection<ExchangeBalance>(new ConcurrentQueue<ExchangeBalance>(preferences.Balances));
            }

            //AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.Orders.Count + " Balances", LogMessageType.LOG);
            if (preferences.Orders.Count > 0)
            {
                Orders = new BlockingCollection<ExchangeOrder>(new ConcurrentQueue<ExchangeOrder>(preferences.Orders));
            }

            //AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.Tickers.Count + " Tickers", LogMessageType.LOG);
            if (preferences.Tickers.Count > 0)
            {
                Tickers = new BlockingCollection<ExchangeTicker>(new ConcurrentQueue<ExchangeTicker>(preferences.Tickers));
            }
            
            //AddLogMessage(Name, "SetPreferenceSnapshots", "PREFERENCES INITIALIZED : " + preferences.Transactions.Count + " Transactions", LogMessageType.LOG);
            if (preferences.Transactions.Count > 0)
            {
                Transactions = new BlockingCollection<ExchangeTransaction>(new ConcurrentQueue<ExchangeTransaction>(preferences.Transactions));
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
            ExchangeApi match = preferences.ApiList.FirstOrDefault(item => item.exchange.ToLower() == api.exchange.ToLower());

            if (match == null)
            {
                preferences.ApiList.Add(api);
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
            ExchangeApi match = preferences.ApiList.FirstOrDefault(item => item.exchange.ToLower() == exchange.ToLower());

            if (match != null)
            {
                AddLogMessage(Name, "RemoveExchangeApi", "Removing " + exchange + " from API List", LogMessageType.DEBUG);
                preferences.ApiList.Remove(match);
                UpdatePreferenceFile();
            }
            else
            {
                AddLogMessage(Name, "AddExchangeApi", exchange + " Does Not Exist in API List - Nothing To Remove");
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
                    AddLogMessage(Name, "SetExchangeApi", ex.Message, LogMessageType.EXCEPTION);
                }
            }
            else
            {
                AddLogMessage(Name, "SetExchangeApi", "PROBLEM : type is NULL : " + api.exchange, LogMessageType.DEBUG);
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
                UpdatePreferenceFile();
            }
            
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
                try
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
                catch (Exception ex)
                {
                    AddLogMessage(Name, "GetFormFont", ex.Message, LogMessageType.EXCEPTION);
                    return preferences.Font;
                }              
            }
        }      
        public static bool SetFormFont(Form form, Font font)
        {
            form.Font = font;
            //SetTheme(preferences.Theme.type, form);
            foreach (Control c in form.Controls)
            {
                SetControlTheme(c, preferences.Theme, form);
            }
            UpdateFormPreferences(form, true);
            return true;
        }
        #endregion

        #region Updaters
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
            string iniPath = DataDirectory + "\\" + type + "Preferences.ini";
            string json = String.Empty;

            switch (type)
            {
                case PreferenceType.None:
                    iniPath = DataDirectory + "\\Preferences.ini";
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
                    ExchangePreferences.Exchanges = Exchanges.ToList();
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
            preferences.Orders = Orders.Where(order => !order.open).ToList();
            preferences.Tickers = Tickers.ToList();
            preferences.Transactions = Transactions.ToList();
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

        public static bool FlushHistorys()
        {
            preferences.Balances = new List<ExchangeBalance>();
            preferences.Orders = new List<ExchangeOrder>();
            preferences.Transactions = new List<ExchangeTransaction>();
            //public static BlockingCollection<Exchange> Exchanges = new BlockingCollection<Exchange>();
            Balances = new BlockingCollection<ExchangeBalance>();
            Orders = new BlockingCollection<ExchangeOrder>();
            //public static BlockingCollection<ExchangeTicker> Tickers = new BlockingCollection<ExchangeTicker>();
            Transactions = new BlockingCollection<ExchangeTransaction>();

            UpdatePreferenceFile();
            FormManager.UpdateControlUIs();
            AddLogMessage(Name, "FlushSnapshots", "Snapshots Flushed", LogMessageType.LOG);
            return true;
        }
        #endregion

        #region Theme
        public static ThemePreference GetThemePreference(ThemeType type)
        {
            switch (type)
            {
                case ThemeType.Default:
                    return new ThemePreference();
                    
                case ThemeType.Dark:
                    return new ThemePreference()
                    {
                        type = ThemeType.Dark,
                        Green = Color.DarkGreen,
                        Red = Color.DarkRed,
                        Yellow = Color.DarkGoldenrod,
                        FormBackground = ColorTranslator.FromHtml("#333333"),
                        AlternateBackground = ColorTranslator.FromHtml("#3F3F3F"),
                        Text = ColorTranslator.FromHtml("#eaeaea"),
                        HeaderBackground = ColorTranslator.FromHtml("#444444"),
                        HeaderText = ColorTranslator.FromHtml("#fcfbef"),
                        //ShowGridLines = false,
                        cryptoCompareChartTheme = new CryptoCompareChartTheme()
                        {
                            General = new CryptoCompareTheme_General()
                            {
                                background = "#333",
                                borderWidth = "1px",
                                borderColor = "#545454",
                                borderRadius = "4px 4px 0 0"
                            },
                            Header = new CryptoCompareTheme_Header()
                            {
                                background = "#000",
                                color = "#FFF",
                                displayFollowers = true
                            },
                            Followers = new CryptoCompareTheme_Followers()
                            {
                                background = "#f7931a",
                                color = "#FFF",
                                borderColor = "#e0bd93",
                                counterBorderColor = "#fdab48",
                                counterColor = "#f5d7b2"
                            },
                            Data = new CryptoCompareTheme_Data()
                            {
                                priceColor = "#FFF",
                                infoLabelColor = "#CCC",
                                infoValueColor = "#CCC"
                            },
                            Chart = new CryptoCompareTheme_Chart()
                            {
                                animation = false,
                                fillColor = "rgba(86,202,158,0.5)",
                                borderColor = "#56ca9e"
                            },
                            Trend = new CryptoCompareTheme_Trend()
                            {
                                colorUp = "#3d9400",
                                colorDown = "#A11B0A",
                                colorUnchanged = "#2C4C76"
                            },
                            Conversion = new CryptoCompareTheme_Conversion()
                            {
                                background = "#000",
                                lineHeight = "20px",
                                color = "#999"
                            }
                        }
                    };

                case ThemeType.Stoned:
                    return new ThemePreference()
                    {
                        type = ThemeType.Stoned,
                        BackgroundImageName = type + "Background",
                        //Green = Color.DarkGreen,
                        //Red = Color.DarkRed,
                        //Yellow = Color.DarkGoldenrod,
                        FormBackground = ColorTranslator.FromHtml("#EAEAE1"),
                        Text = ColorTranslator.FromHtml("#1E3F16"),
                        HeaderBackground = ColorTranslator.FromHtml("#D4D5C7"),
                        HeaderText = ColorTranslator.FromHtml("#565550"),

                        cryptoCompareChartTheme = new CryptoCompareChartTheme()
                        {
                            General = new CryptoCompareTheme_General()
                            {
                                //background = "#E8E8E8",
                                background = "#EAEAE1",
                                //background = "F4F4F2",
                                borderWidth = "1px",
                                borderColor = "#918E84",
                                borderRadius = "4px 4px 0 0"
                            },
                            Header = new CryptoCompareTheme_Header()
                            {
                                background = "#D4D5C7",
                                color = "#565550",
                                displayFollowers = true
                            },
                            Followers = new CryptoCompareTheme_Followers()
                            {
                                background = "#EDEBDE",
                                color = "#918E84",
                                borderColor = "#EEE",
                                counterBorderColor = "#EEE",
                                counterColor = "#7F7D76"
                            },
                            Data = new CryptoCompareTheme_Data()
                            {
                                priceColor = "#565550",
                                infoLabelColor = "#333",
                                infoValueColor = "#333"
                            },
                            Chart = new CryptoCompareTheme_Chart()
                            {
                                animation = false,
                                //fillColor = "rgba(233,233,223,1)",
                                fillColor = "rgba(232,232,218,1)",
                                borderColor = "#918E84"
                            },
                            Trend = new CryptoCompareTheme_Trend()
                            {
                                colorUp = "#3d9400",
                                colorDown = "#A11B0A",
                                colorUnchanged = "#2C4C76"
                            },
                            Conversion = new CryptoCompareTheme_Conversion()
                            {
                                background = "transparent",
                                lineHeight = "20px",
                                color = "#000"
                            }
                        }
                    };

                default:
                    return new ThemePreference();
                    
            }
        }
        public static void SetControlTheme(Control control, ThemePreference theme, Form form)
        {
            control.BackColor = theme.FormBackground;
            control.ForeColor = theme.Text;
            control.Font = GetFormFont(form);
            
            if (theme.BackgroundImageName.Length > 0)
            {
                control.BackgroundImageLayout = ImageLayout.Tile;
                control.BackgroundImage = ContentManager.GetImage(theme.BackgroundImageName);
            }
            else
            {
                control.BackgroundImage = null;
            }
            
            if (control is FastObjectListView)
            {
                FastObjectListView listView = control as FastObjectListView;
                listView.GridLines = preferences.ShowGridLines;
                listView.UseAlternatingBackColors = preferences.UseAlternatingBackColors;
                listView.AlternateRowBackColor = theme.AlternateBackground;

                listView.BackColor = theme.FormBackground;
                listView.BackgroundImageTiled = true;
                listView.HeaderUsesThemes = false;
                var headerstyle = new HeaderFormatStyle();
                headerstyle.SetBackColor(theme.HeaderBackground);
                headerstyle.SetForeColor(theme.HeaderText);
                
                foreach (OLVColumn item in listView.Columns)
                {
                    item.HeaderFormatStyle = headerstyle;
                }
                //listView.Refresh();
            }

            if (control is ToolStrip)
            {
                ToolStrip toolstrip = control as ToolStrip;
                foreach(ToolStripItem item in toolstrip.Items)
                {
                    if (item.GetType().Name == "ToolStripDropDownButton")
                    {
                        ToolStripDropDownButton button = item as ToolStripDropDownButton;
                        SetControlTheme(button.DropDown, theme, form);
                    }
                }
            }
            // CHILDREN
            foreach (Control subC in control.Controls)
            {
                SetControlTheme(subC, theme, form);
            }
        }
        public static bool SetTheme(ThemeType type, Form target = null)
        {
            ThemePreference theme = GetThemePreference(type);

            if (target != null)
            {
                target.BackColor = theme.FormBackground;
                target.ForeColor = theme.Text;

                if (theme.BackgroundImageName.Length > 0)
                {
                    target.BackgroundImageLayout = ImageLayout.Tile;
                    target.BackgroundImage = ContentManager.GetImage(theme.BackgroundImageName);
                }
                else
                {
                    //target.BackgroundImageLayout = ImageLayout.Tile;
                    target.BackgroundImage = null;
                }

                foreach (Control c in target.Controls)
                {
                    SetControlTheme(c, theme, target);
                }
            }
            else
            {
                foreach (Form form in Application.OpenForms)
                {
                    SetTheme(type, form);
                }
                preferences.Theme = theme;
                FormManager.UpdateControlUIs();
                UpdatePreferenceFile();
            }
            return true;
        }
        #endregion

        #region DataModels
        public class Preferences
        {
            public Size IconSize { get; set; } = new Size(32, 32);
            public bool UseGlobalFont { get; set; } = false;
            //public Font Font { get; set; } = new Font("Times New Roman", 12.0f);
            public Font Font { get; set; } = SystemFonts.MessageBoxFont;
            
            public bool ShowGridLines { get; set; } = false;
            public bool UseAlternatingBackColors { get; set; } = false;
            public ThemePreference Theme { get; set; } = new ThemePreference();
            public BalanceViewType BalanceView { get; set; } = BalanceViewType.balance;

            public bool ShowOnlyAPIExchanges { get; set; } = false;
            public List<ExchangeApi> ApiList { get; set; } = new List<ExchangeApi>();

            // CALCULATOR
            public string CalculatorSymbol { get; set; } = "BTC";
            public List<string> SymbolWatchList { get; set; } = new List<string>();
            /*
            public List<string> SymbolWatchList { get; set; } = new List<string>()
            {
                "BTC","BCH","DASH","DOGE","ETC","ETH","LTC","REP","USDT","XLM","XMR","XRP","ZEC"
            };
            */
            // FLAGS
            public ExchangeTimerType TimerFlags { get; set; } = ExchangeTimerType.NONE;
            public LogMessageType MessageFlags { get; set; } = LogMessageType.CONSOLE | LogMessageType.DEBUG | LogMessageType.EXCEPTION | LogMessageType.EXCHANGE | LogMessageType.LOG | LogMessageType.OTHER;
            // SNAPSHOTS
            public List<ExchangeBalance> Balances { get; set; } = new List<ExchangeBalance>();
            public List<ExchangeOrder> Orders { get; set; } = new List<ExchangeOrder>();
            public List<ExchangeTicker> Tickers { get; set; } = new List<ExchangeTicker>();
            public List<ExchangeTransaction> Transactions { get; set; } = new List<ExchangeTransaction>();
        }
        // CUSTOM PREFERENCES
        public class ArbitragePreference
        {
            public bool ShowCharts { get; set; } = true;
            public int minChartWidth = 300;
            public int minChartHeight = 265;
            public int maxListCount = 8;
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
            public Point Location { get; set; } = new Point(0, 0);
            public Size Size { get; set; } = new Size(800, 600);
            //public float Size { get; set; } = SystemFonts.MessageBoxFont.Size;
            public Font Font { get; set; } = SystemFonts.MessageBoxFont;
            public bool Open { get; set; }
        }      
        public class ThemePreference
        {
            public ThemeType type = ThemeType.Default;
            public Color Green { get; set; } = Color.LightGreen;
            public Color Red { get; set; } = Color.LightPink;
            public Color Yellow { get; set; } = Color.LightGoldenrodYellow;

            //public Color FormBackground { get; set; } = SystemColors.Control;
            public Color FormBackground { get; set; } = SystemColors.Window;
            public Color AlternateBackground { get; set; } = SystemColors.Control;
            public string BackgroundImageName { get; set; } = String.Empty;
            //public Image BackgroundImage { get; set; } = null;
            //public Color Text { get; set; } = Color.Black;
            public Color Text { get; set; } = SystemColors.ControlText;
            // LISTS
            public Color HeaderBackground { get; set; } = SystemColors.Control;
            public Color HeaderText { get; set; } = SystemColors.ControlText;
            //public bool ShowGridLines { get; set; } = false;

            public string BrowserBackgroundColor
            {
                get
                {
                    //return ColorTranslator.ToHtml(FormBackground);
                    return cryptoCompareChartTheme.General.background;
                }
            }
            public CryptoCompareChartTheme cryptoCompareChartTheme { get; set; } = new CryptoCompareChartTheme();
        }
        public class TradingViewPreference
        {
            //public TradingViewAdvancedChartParameters parameters { get; set; } = new TradingViewAdvancedChartParameters();
            public TradingViewAdvancedChartParameters AdvancedChartParameters { get; set; } = new TradingViewAdvancedChartParameters();
            public TradingViewCryptocurrencyMarketParameters CryptocurrencyMarketParameters { get; set; } = new TradingViewCryptocurrencyMarketParameters();
            public TradingViewSymbolOverviewParameters SymbolOverviewParameters { get; set; } = new TradingViewSymbolOverviewParameters();

            //public TradingViewAdvancedChartParameters CustomParameters { get; set; } = new TradingViewAdvancedChartParameters();
            public List<ExchangeTicker> WatchList { get; set; } = new List<ExchangeTicker>();
            /*
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
            */
        }
        public class WalletPreference
        {
            public List<WalletManager.WalletBalance> Wallets { get; set; } = new List<WalletManager.WalletBalance>();
        }

        public class TypeListItem
        {
            public string Name { get; set; }
            public Type type { get; set; }
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
            Default = 0,
            Dark    = 1,
            Stoned  = 2
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
                    Thread.Sleep(2000);
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
        /*
        #region Enum
        public enum WalletAPIType
        {
            none,
            BlockCypher,

        }
        #endregion
    */
    }
    // -------------------------------
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