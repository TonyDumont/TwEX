using System;
using System.Windows.Forms;
using static TwEX_API.WalletManager;
using Newtonsoft.Json;
using System.Collections.Generic;
using BrightIdeasSoftware;
using static TwEX_API.Market.CoinMarketCap;
using System.Linq;
using static TwEX_API.Market.CryptoCompare;

namespace TwEX_API.Controls
{
    public partial class ImportForksControl : UserControl
    {
        #region Properties
        private List<WalletBalance> balances = new List<WalletBalance>();
        private List<Fork> forks = new List<Fork>();
        public WalletBalance wallet;
        #endregion

        #region Initialize
        public ImportForksControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void ImportForksControl_Load(object sender, EventArgs e)
        {
            textBox.MaxLength = Int32.MaxValue;
            splitContainer.SplitterDistance = (int)(splitContainer.ClientSize.Width * 0.50);
            toolStripButton_load.Image = ContentManager.GetIcon("ClipboardLoad");
            toolStripButton_view.Image = ContentManager.GetIcon("CoinNinja");
        }
        private void InitializeColumns()
        {
            /*
            column_Name.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            column_Symbol.ImageGetter = new ImageGetterDelegate(aspect_Symbol);
            column_CoinName.AspectGetter = new AspectGetterDelegate(aspect_CoinName);
            */
            column_ticker.ImageGetter = new ImageGetterDelegate(aspect_Symbol);
            column_Balance.AspectGetter = new AspectGetterDelegate(aspect_Balance);
            column_TotalInBTC.AspectGetter = new AspectGetterDelegate(aspect_btc);
            column_TotalInUSD.AspectGetter = new AspectGetterDelegate(aspect_usd);
        }
        #endregion

        #region Delegates
        delegate bool UpdateUICallback(bool resize = false);
        public bool UpdateUI(bool resize = false)
        {
            if (InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                Invoke(d, new object[] { resize });
            }
            else
            {
                /*
                listView.SetObjects(PreferenceManager.WalletPreferences.Wallets);
                //listView.SetObjects(PreferenceManager.WalletPreferences.Wallets.OrderBy(wallet => wallet.WalletName));
                //listView.Sort(column_TotalInBTC, SortOrder.Descending);

                toolStripLabel_title.Text = PreferenceManager.WalletPreferences.Wallets.Count + " Wallets";
                toolStripLabel_btc.Text = PreferenceManager.WalletPreferences.Wallets.Sum(b => b.TotalInBTC).ToString("N8");
                toolStripLabel_usd.Text = PreferenceManager.WalletPreferences.Wallets.Sum(b => b.TotalInUSD).ToString("C");

                toolStripButton_timer.Checked = (PreferenceManager.preferences.TimerFlags & ExchangeTimerType.WALLETS) != ExchangeTimerType.NONE;
                //toolStripButton_Tickers.Text = "TICKERS (" + ExchangeManager.Tickers.Count + ")";
                toolStripButton_timer.Image = ContentManager.GetActiveIcon(toolStripButton_timer.Checked);
                //LogManager.AddLogMessage(Name, "UpdateUI", "Updating - " + resize, LogManager.LogMessageType.DEBUG);
                */
                if (resize)
                {
                    ResizeUI();
                }
            }
            return true;
        }

        delegate void ResizeUICallback();
        public void ResizeUI()
        {
            if (InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {

                //LogManager.AddLogMessage(Name, "ResizeUI", "RESIZING", LogManager.LogMessageType.DEBUG);
                int rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;
                /*
                Size textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);
                int rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;
                int iconSize = rowHeight - 2;
                //int listWidth = 0;
                int listHeight = 0;

                toolStrip.ImageScalingSize = new Size(iconSize, iconSize);

                column_Symbol.Width = iconSize;
                column_TotalInUSD.Width = textSize.Width;
                column_TotalInBTC.Width = textSize.Width;
                column_Balance.Width = textSize.Width + (textSize.Width / 2);

                listView.Height = listHeight;
                ClientSize = new Size(Width, listHeight + (toolStrip.Height * 2) - (listView.RowHeightEffective / 2));
                Size = new Size(Width, listHeight + (toolStrip.Height * 2) - (listView.RowHeightEffective / 2));
                */


                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + rowHeight;
                    //listWidth += col.Width;
                }
                /*
                column_Name.Width = column_Name.Width + iconSize;
                listWidth += iconSize;

                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 3];
                    listHeight = listView.Top + last.Bounds.Bottom;
                }
                */

            
            }
        }
        #endregion

        #region Getters
        /*
        private object aspect_Icon(object rowObject)
        {
            WalletManager.WalletBalance balance = (WalletManager.WalletBalance)rowObject;
            int rowheight = listView.RowHeightEffective - 3;
            return ContentManager.ResizeImage(ContentManager.GetWalletIcon(balance.WalletName), rowheight, rowheight);
            //return ContentManager.GetWalletIcon(balance.WalletName);
        }
        
        public object aspect_CoinName(object rowObject)
        {
            WalletBalance listItem = (WalletBalance)rowObject;
            string coinName = string.Empty;
            CoinMarketCapTicker ticker = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == listItem.Symbol);
            //Decimal total = 0;
            //string price = "";

            if (ticker != null)
            {
                coinName = ticker.name;
            }
            
            return coinName;
        }
        */
        private object aspect_Symbol(object rowObject)
        {
            Fork listItem = (Fork)rowObject;
            int rowheight = listView.RowHeightEffective - 3;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(listItem.ticker), rowheight, rowheight);
        }

        public object aspect_Balance(object rowObject)
        {
            Fork listItem = (Fork)rowObject;

            Decimal balance = Decimal.Parse(listItem.balance.expected.ToString(), System.Globalization.NumberStyles.Float) / 100000000;

            if (balance > 0)
            {
                return balance.ToString("N8");
            }
            else
            {
                return string.Empty;
            }
        }
        public object aspect_btc(object rowObject)
        {
            Fork listItem = (Fork)rowObject;
            Decimal balance = Decimal.Parse(listItem.balance.expected.ToString(), System.Globalization.NumberStyles.Float) / 100000000;
            CoinMarketCapTicker ticker = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == listItem.ticker.ToUpper() && item.name == listItem.name);
            decimal total = 0;

            if (ticker != null)
            {
                total = balance * ticker.price_btc;
            }
            /*
            else
            {
                CryptoCompareCoin coin = PreferenceManager.CryptoComparePreferences.CoinList.FirstOrDefault(item => item.Name == listItem.ticker.ToUpper() && item.CoinName == listItem.name);
                if (coin != null)
                {
                    LogManager.AddLogMessage(Name, "aspect_btc", "coin=" + coin.Name, LogManager.LogMessageType.DEBUG);
                }
            }
            */
            if (total > 0)
            {
                return total.ToString("N8");
            }
            else
            {
                return String.Empty;
            }
        }
        public object aspect_usd(object rowObject)
        {
            Fork listItem = (Fork)rowObject;
            Decimal balance = Decimal.Parse(listItem.balance.expected.ToString(), System.Globalization.NumberStyles.Float) / 100000000;
            CoinMarketCapTicker ticker = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == listItem.ticker.ToUpper() && item.name == listItem.name);
            decimal total = 0;

            if (ticker != null)
            {
                total = balance * ticker.price_usd;
            }

            if (total > 0)
            {
                return total.ToString("C");
            }
            else
            {
                return String.Empty;
            }
        }
        #endregion

        #region EventHandlers
        private void toolStripButton_load_Click(object sender, EventArgs e)
        {
            //LogManager.AddLogMessage(Name, "toolStripButton_load_Click", "IMPORTING", LogManager.LogMessageType.DEBUG);
            
            try
            {
                string clipboardData = Clipboard.GetText();
                //LogManager.AddLogMessage(Name, "toolStripButton_load_Click", clipboardData, LogManager.LogMessageType.DEBUG);

                if (clipboardData != null && clipboardData.Length > 0)
                {
                    //int startIndex = clipboardData.
                    int endIndex = clipboardData.LastIndexOf(']');
                    string data = clipboardData.Substring(0, endIndex);
                    int startIndex = data.LastIndexOf("```");
                    data = data.Substring(startIndex + 3);
                    data = data.Substring(data.IndexOf('{')-1);
                    //LogManager.AddLogMessage(Name, "toolStripButton_load_Click", data, LogManager.LogMessageType.DEBUG);

                    textBox.Text = data;
                    balances.Clear();
                    ForkImport import = JsonConvert.DeserializeObject<ForkImport>(textBox.Text);
                    //LogManager.AddLogMessage(Name, "toolStripButton_load_Click", import.addr + " | " + import.forks.Count, LogManager.LogMessageType.DEBUG);
                    forks.Clear();
                    foreach (Fork fork in import.forks)
                    {
                        if (fork.balance.expected > 0)
                        {
                            forks.Add(fork);
                        }
                    }
                    listView.SetObjects(forks);
                    UpdateUI(true);
                }
                else
                {
                    MessageBox.Show("Make sure you copied 'Full Report' from FindMyCoins.ninja", "CLIPBOARD IS EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }     
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "toolStripButton_load_Click", ex.Message, LogManager.LogMessageType.EXCEPTION);
                MessageBox.Show("Make sure you copied 'Full Report' from FindMyCoins.ninja", "INVALID DATA IN CLIPBOARD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }          
        }
        private void toolStripButton_view_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(wallet.Address);
            FormManager.OpenUrl("http://www.findmycoins.ninja/");
            //LogManager.AddLogMessage(Name, "toolStripButton_view_Click", wallet.Symbol + " | " + wallet.Address, LogManager.LogMessageType.DEBUG);
        }
        #endregion

        private void toolStripButton_save_Click(object sender, EventArgs e)
        {
            foreach (Fork fork in forks)
            {
                Fork listItem = PreferenceManager.WalletPreferences.Forks.FirstOrDefault(item => item.addr == fork.addr && item.ticker == fork.ticker);

                if (listItem == null)
                {
                    fork.id = wallet.Name;

                    Decimal balance = Decimal.Parse(fork.balance.expected.ToString(), System.Globalization.NumberStyles.Float) / 100000000;
                    CoinMarketCapTicker ticker = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == fork.ticker.ToUpper() && item.name == fork.name);
                    //decimal btcTotal = 0;
                    //decimal usdTotal = 0;

                    if (ticker != null)
                    {
                        fork.TotalInBTC = balance * ticker.price_btc;
                        fork.TotalInUSD = balance * ticker.price_usd;
                    }

                    PreferenceManager.WalletPreferences.Forks.Add(fork);
                }
                else
                {
                    Decimal balance = Decimal.Parse(fork.balance.expected.ToString(), System.Globalization.NumberStyles.Float) / 100000000;
                    CoinMarketCapTicker ticker = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == fork.ticker.ToUpper() && item.name == fork.name);
                    if (ticker != null)
                    {
                        listItem.balance = fork.balance;
                        listItem.TotalInBTC = balance * ticker.price_btc;
                        listItem.TotalInUSD = balance * ticker.price_usd;
                    }
                }
                
                PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Wallet);
                FormManager.UpdateBalanceManager(true);
                //FormManager.UpdateWalletManager();
                if (ParentForm != null)
                {
                    ParentForm.Close();
                }
                
            }
        }

        /*
        private void toolStripButton_save_Click(object sender, EventArgs e)
        {
            foreach (Fork fork in forks)
            {
                Decimal balance = Decimal.Parse(fork.balance.expected.ToString(), System.Globalization.NumberStyles.Float) / 100000000;
                CoinMarketCapTicker ticker = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == fork.ticker.ToUpper() && item.name == fork.name);
                decimal btcTotal = 0;
                decimal usdTotal = 0;

                if (ticker != null)
                {
                    btcTotal = balance * ticker.price_btc;
                    usdTotal = balance * ticker.price_usd;
                }

                if (balance > 0)
                {
                    WalletBalance wbalance = new WalletBalance()
                    {
                        Address = wallet.Address,
                        Balance = balance,
                        CoinName = fork.name,
                        Symbol = fork.ticker.ToUpper(),
                        IsForkBalance = true,
                        Name = wallet.Name,
                        WalletName = wallet.WalletName,
                        TotalInBTC = btcTotal,
                        TotalInUSD = usdTotal
                    };

                    WalletBalance listItem = PreferenceManager.WalletPreferences.Wallets.FirstOrDefault(b => b.Address == wbalance.Address && b.Symbol == wbalance.Symbol);

                    if (listItem == null)
                    {
                        PreferenceManager.WalletPreferences.Wallets.Add(wbalance);
                    }
                    
                }
                PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Wallet);
                FormManager.UpdateBalanceManager();
                FormManager.UpdateWalletManager();
                //ParentForm.Close();
            }
        }
        */
    }
}

/*
                Decimal balance = Decimal.Parse(fork.balance.expected.ToString(), System.Globalization.NumberStyles.Float) / 100000000;
                CoinMarketCapTicker ticker = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == fork.ticker.ToUpper() && item.name == fork.name);
                decimal btcTotal = 0;
                decimal usdTotal = 0;

                if (ticker != null)
                {
                    btcTotal = balance * ticker.price_btc;
                    usdTotal = balance * ticker.price_usd;
                }

                if (balance > 0)
                {
                    WalletBalance wbalance = new WalletBalance()
                    {
                        Address = wallet.Address,
                        Balance = balance,
                        CoinName = fork.name,
                        Symbol = fork.ticker.ToUpper(),
                        IsForkBalance = true,
                        Name = wallet.Name,
                        WalletName = wallet.WalletName,
                        TotalInBTC = btcTotal,
                        TotalInUSD = usdTotal
                    };

                    WalletBalance listItem = PreferenceManager.WalletPreferences.Wallets.FirstOrDefault(b => b.Address == wbalance.Address && b.Symbol == wbalance.Symbol);

                    if (listItem == null)
                    {
                        PreferenceManager.WalletPreferences.Wallets.Add(wbalance);
                    }

                }
                */

/*
                balances.Clear();
                ForkImport import = JsonConvert.DeserializeObject<ForkImport>(textBox.Text);
                LogManager.AddLogMessage(Name, "toolStripButton_load_Click", import.addr + " | " + import.forks.Count, LogManager.LogMessageType.DEBUG);

                //forks = import.forks;
                forks.Clear();
                foreach(Fork fork in import.forks)
                {
                    if (fork.balance.expected > 0)
                    {
                        forks.Add(fork);
                    }
                }
                listView.SetObjects(forks);
                UpdateUI(true);
                */

/*
                foreach(Fork fork in import.forks)
                {
                    Decimal balance = Decimal.Parse(fork.balance.expected.ToString(), System.Globalization.NumberStyles.Float) / 100000000;
                    CoinMarketCapTicker priceItem = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == fork.ticker.ToUpper());
                    decimal btcTotal = 0;
                    decimal usdTotal = 0;
                    //Decimal total = 0;
                    //string price = "";

                    if (priceItem != null)
                    {
                        btcTotal = priceItem.price_btc;
                        usdTotal = priceItem.price_usd;

                    }

                    LogManager.AddLogMessage(Name, "toolStripButton_load_Click", fork.ticker + " | " + balance, LogManager.LogMessageType.DEBUG);
                    if (balance > 0)
                    {
                        WalletBalance wBalance = new WalletBalance()
                        {
                            Name = wallet.Name,
                            WalletName = wallet.WalletName,
                            Address = wallet.Address,
                            Balance = balance,
                            Symbol = fork.ticker.ToUpper(),
                            TotalInBTC = btcTotal,
                            TotalInUSD = usdTotal
                        };
                        balances.Add(wBalance);
                    }
                }
                listView.SetObjects(balances);
                */
