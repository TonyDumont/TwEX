using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TwEX_API.Market;
using static TwEX_API.ExchangeManager;
using static TwEX_API.PreferenceManager;

namespace TwEX_API.Controls
{
    public partial class ArbitrageManagerControl : UserControl
    {
        #region Properties
        public ArbitrageWatchList WatchList = new ArbitrageWatchList();
        public static Timer timer = new Timer() { Interval = 120000 };
        #endregion

        #region Initialize
        public ArbitrageManagerControl()
        {
            InitializeComponent();
            FormManager.arbitrageManagerControl = this;
            InitializeIcons();
        }
        private void ArbitrageManagerControl_Load(object sender, EventArgs e)
        {
            NumericUpDown num = toolStripNumberControl_maxItems.NumericUpDownControl as NumericUpDown;
            num.Value = ArbitragePreferences.maxListCount;

            toolStripDropDownButton_period.Text = EnumUtils.GetDescription(ArbitragePreferences.ChartPeriod);
            toolStripDropDownButton_market.Text = ArbitragePreferences.market;
            toolStripDropDownButton_market.Image = ContentManager.GetSymbolIcon(ArbitragePreferences.market);
            
            if (ArbitragePreferences.CurrentWatchList.Length > 0)
            {
                if (!ArbitragePreferences.CurrentWatchList.Contains('|'))
                {
                    toolStripDropDownButton_watchlists.Text = ArbitragePreferences.CurrentWatchList;
                }
                else
                {
                    string[] split = ArbitragePreferences.CurrentWatchList.Split('|');

                    if (!split[0].Contains("All"))
                    {
                        toolStripDropDownButton_watchlists.Text = split[0];
                    }
                    else
                    {
                        toolStripDropDownButton_watchlists.Text = split[0] + " " + split[1];
                    }

                    
                }
            }
            else
            {
                toolStripDropDownButton_watchlists.Text = "Select Watchlist";
            }

            UpdateWatchlists();

            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            SetWatchlist(true);
        }
        private void InitializeIcons()
        {
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripMenuItem_update.Image = ContentManager.GetIcon("Refresh");
            toolStripMenuItem_btc.Image = ContentManager.GetSymbolIcon("BTC");
            toolStripMenuItem_usd.Image = ContentManager.GetIcon("USDSymbol");
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //LogManager.AddLogMessage(Name, "timer_Tick", "Ticked", LogManager.LogMessageType.DEBUG);
            UpdateUI();
        }
        #endregion

        #region Delegates
        delegate void DisposeTimerCallback();
        public void DisposeTimer()
        {
            if (InvokeRequired)
            {
                DisposeTimerCallback d = new DisposeTimerCallback(DisposeTimer);
                Invoke(d, new object[] { });
            }
            else
            {
                //toolStrip.Font = ParentForm.Font;
                timer.Stop();
                timer.Tick -= timer_Tick;
                timer.Dispose();
            }
        }

        delegate void UpdateUICallback(bool resize = false);
        public void UpdateUI(bool resize = false)
        {
            if (flowLayoutPanel.InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                flowLayoutPanel.Invoke(d, new object[] { resize });
            }
            else
            {
                try
                {
                    //LogManager.AddDebugMessage(Name, "UpdateUI", "1 colcount=" + listView.OLVGroups. .CollapsedGroups.Count());
                    //grouper.GroupTitle = ExchangeManager.coinBalanceList.Select(s => s.Symbol).Distinct().Count() + " Coins";
                    foreach (Control control in flowLayoutPanel.Controls)
                    {
                        if (control is ArbitrageItemControl)
                        {
                            ArbitrageItemControl item = control as ArbitrageItemControl;
                            item.UpdateUI(resize);
                        }
                    }

                    if (ArbitragePreferences.CurrentWatchList.Contains('|'))
                    {
                        string[] data = ArbitragePreferences.CurrentWatchList.Split('|');
                        string name = data[0];
                        string preset = data[1];
                        toolStripLabel_totals.Text = GetPresetWatchlistTotals(name, preset);
                    }
                    else
                    {
                        toolStripLabel_totals.Text = "NO";
                    }

                    toolStripLabel_lastUpdate.Text = "Last Update : " + DateTime.Now;

                    if (resize)
                    {
                        ResizeUI();
                    }
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "UpdateUI", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
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
                //Font = PreferenceManager.GetFormFont(ParentForm);
                //toolStrip.Font = ParentForm.Font;
                //PreferenceManager.SetControlTheme(this, PreferenceManager.preferences.Theme);
            }
        }

        delegate void RemoveWatchlistItemCallback(ArbitrageItemControl control);
        public void RemoveWatchlistItem(ArbitrageItemControl control)
        {
            if (flowLayoutPanel.InvokeRequired)
            {
                RemoveWatchlistItemCallback d = new RemoveWatchlistItemCallback(RemoveWatchlistItem);
                flowLayoutPanel.Invoke(d, new object[] { control });
            }
            else
            {
                flowLayoutPanel.Controls.Remove(control);
                UpdateUI();
            }
        }

        delegate void SetWatchlistCallback(bool resize = false, bool clear = false);
        public void SetWatchlist(bool resize = false, bool clear = false)
        {
            if (flowLayoutPanel.InvokeRequired)
            {
                SetWatchlistCallback d = new SetWatchlistCallback(SetWatchlist);
                flowLayoutPanel.Invoke(d, new object[] { resize, clear });
            }
            else
            {
                if (clear)
                {
                    flowLayoutPanel.Controls.Clear();
                }
                /*
                if (ArbitragePreferences.CurrentWatchList.Contains('|'))
                {
                    string[] data = ArbitragePreferences.CurrentWatchList.Split('|');
                    string name = data[0];
                    string preset = data[1];
                    toolStripLabel_totals.Text = GetPresetWatchlistTotals(name, preset);
                }
                else
                {
                    toolStripLabel_totals.Text = "NO";
                }
                */
                WatchList = ArbitragePreferences.GetCurrentWatchList();
                SetOptionsMenu();

                foreach (ExchangeTicker ticker in WatchList.Items.OrderByDescending(item => item.last))
                {
                    //LogManager.AddLogMessage(Name, "SetWatchlist", "ticker=" + ticker.symbol + " | " + ticker.market + " | " + ticker.last, LogManager.LogMessageType.DEBUG);
                    Control[] ctrls = flowLayoutPanel.Controls.Find(ticker.symbol, false);

                    if (ctrls.Length > 0)
                    {
                        // UPDATE
                        ArbitrageItemControl control = ctrls[0] as ArbitrageItemControl;
                        //control.UpdateUI();
                        //control.SetData(ticker.symbol, PreferenceManager.ArbitragePreferences.market);
                        if (ticker.symbol != "BTC")
                        {
                            control.SetData(ticker.symbol, ArbitragePreferences.market);
                        }
                        else
                        {
                            control.SetData(ticker.symbol, "USD");
                        }
                    }
                    else
                    {
                        // ADD
                        ArbitrageItemControl control = new ArbitrageItemControl() { Name = ticker.symbol, manager = this };
                        if (ticker.symbol != "BTC")
                        {
                            control.SetData(ticker.symbol, ArbitragePreferences.market);
                        }
                        else
                        {
                            control.SetData(ticker.symbol, "USD");
                        }
                        //PreferenceManager.SetControlTheme(control, PreferenceManager.preferences.Theme, ParentForm);
                        flowLayoutPanel.Controls.Add(control);
                        //LogManager.AddLogMessage(Name, "SetWatchlist", "ticker=" + ticker.symbol + " | " + ticker.market + " | " + ticker.last, LogManager.LogMessageType.DEBUG);
                    }
                }
                UpdateUI(resize);
            }
        }
        /*
        public void SetWatchlist(bool resize = false, bool clear = false)
        {
            if (flowLayoutPanel.InvokeRequired)
            {
                SetWatchlistCallback d = new SetWatchlistCallback(SetWatchlist);
                flowLayoutPanel.Invoke(d, new object[] { resize, clear });
            }
            else
            {
                if (clear)
                {
                    flowLayoutPanel.Controls.Clear();
                }

                foreach (ExchangeTicker ticker in PreferenceManager.ArbitragePreferences.GetCurrentWatchList())
                {
                    //LogManager.AddLogMessage(Name, "SetWatchlist", "ticker=" + ticker.symbol + " | " + ticker.market + " | " + ticker.last, LogManager.LogMessageType.DEBUG);
                    Control[] ctrls = flowLayoutPanel.Controls.Find(ticker.symbol, false);

                    if (ctrls.Length > 0)
                    {
                        // UPDATE
                        ArbitrageItemControl control = ctrls[0] as ArbitrageItemControl;
                        //control.UpdateUI();
                        //control.SetData(ticker.symbol, PreferenceManager.ArbitragePreferences.market);
                        if (ticker.symbol != "BTC")
                        {
                            control.SetData(ticker.symbol, PreferenceManager.ArbitragePreferences.market);
                        }
                        else
                        {
                            control.SetData(ticker.symbol, "USD");
                        }
                    }
                    else
                    {
                        // ADD
                        ArbitrageItemControl control = new ArbitrageItemControl() { Name = ticker.symbol, manager = this };
                        if (ticker.symbol != "BTC")
                        {
                            control.SetData(ticker.symbol, PreferenceManager.ArbitragePreferences.market);
                        }
                        else
                        {
                            control.SetData(ticker.symbol, "USD");
                        }
                        //PreferenceManager.SetControlTheme(control, PreferenceManager.preferences.Theme, ParentForm);
                        flowLayoutPanel.Controls.Add(control);
                        //LogManager.AddLogMessage(Name, "SetWatchlist", "ticker=" + ticker.symbol + " | " + ticker.market + " | " + ticker.last, LogManager.LogMessageType.DEBUG);
                    }
                }
                UpdateUI(resize);
            }
        }
        */
        delegate void UpdateOverviewsCallback();
        public void UpdateOverviews()
        {
            if (InvokeRequired)
            {
                UpdateOverviewsCallback d = new UpdateOverviewsCallback(UpdateOverviews);
                Invoke(d, new object[] { });
            }
            else
            {
                //LogManager.AddLogMessage(Name, "UpdateOverviews", "DOING NOTHING AT THE MOMENT", LogManager.LogMessageType.OTHER);
                SetWatchlist(true, true);
                //overviewsWidget.setSymbolOverview(PreferenceManager.TradingViewPreferences.SymbolOverviewParameters);
                //PreferenceManager.ArbitragePreferences.WatchLists = PreferenceManager.ArbitragePreferences.GetCurrentWatchList();
                //overviewsWidget.setSymbolOverview(PreferenceManager.TradingViewPreferences.SymbolOverviewParameters);
                //SetCustomView();
            }
        }

        delegate void UpdateWatchlistsCallback();
        public void UpdateWatchlists()
        {
            if (InvokeRequired)
            {
                UpdateWatchlistsCallback d = new UpdateWatchlistsCallback(UpdateWatchlists);
                Invoke(d, new object[] { });
            }
            else
            {
                //overviewsWidget.setSymbolOverview(PreferenceManager.TradingViewPreferences.SymbolOverviewParameters);
                
                toolStripDropDownButton_watchlists.DropDown.Items.Clear();
                //List<ExchangeTicker> list = PreferenceManager.ArbitragePreferences.GetCurrentWatchList();

                if (ArbitragePreferences.WatchLists.Count > 0)
                {
                    foreach (ArbitrageWatchList listItem in ArbitragePreferences.WatchLists)
                    {
                        if (!listItem.Name.Contains('|'))
                        {
                            ToolStripMenuItem menuItem = new ToolStripMenuItem() { Text = listItem.Name };
                            menuItem.Click += WatchlistItem_Click;
                            toolStripDropDownButton_watchlists.DropDown.Items.Add(menuItem);
                        }
                    }
                }

                // EDIT
                ToolStripMenuItem editItem = new ToolStripMenuItem() { Text = "Edit Watchlists" };
                toolStripDropDownButton_watchlists.DropDown.Items.Add(editItem);
                editItem.Click += EditWatchlistItem_Click;

                // PRESETS
                ToolStripMenuItem presetItem = new ToolStripMenuItem() { Text = "Presets" };
                // EXCHANGE
                ToolStripMenuItem exchangeInventory = new ToolStripMenuItem() { Text = "Exchange Inventory", Image = ContentManager.GetIcon("Exchange") };
                ToolStripMenuItem exchangeAllItem = new ToolStripMenuItem() { Text = "All" };
                exchangeInventory.DropDown.Items.Add(exchangeAllItem);
                exchangeAllItem.Click += PresetItem_Click;
                foreach (ExchangeManager.Exchange exchange in Exchanges)
                {
                    ToolStripMenuItem exchangeItem = new ToolStripMenuItem() { Text = exchange.Name, Image = ContentManager.GetExchangeIcon(exchange.Name) };
                    exchangeInventory.DropDown.Items.Add(exchangeItem);
                    exchangeItem.Click += PresetItem_Click;
                }
                presetItem.DropDown.Items.Add(exchangeInventory);
                
                // WALLETS
                ToolStripMenuItem walletInventory = new ToolStripMenuItem() { Text = "Wallet Inventory", Image = ContentManager.GetIcon("Wallet") };
                ToolStripMenuItem walletAllItem = new ToolStripMenuItem() { Text = "All" };
                walletInventory.DropDown.Items.Add(walletAllItem);
                walletAllItem.Click += PresetItem_Click;

                var roots = WalletPreferences.Wallets.Select(b => b.WalletName).Distinct();
                
                foreach (var wallet in roots)
                {
                    //LogManager.AddLogMessage(Name, "UpdateWatchlists", "wallet=" + wallet, LogManager.LogMessageType.DEBUG);
                    ToolStripMenuItem walletItem = new ToolStripMenuItem() { Text = wallet, Image = ContentManager.GetWalletIcon(wallet) };
                    walletInventory.DropDown.Items.Add(walletItem);
                    walletItem.Click += PresetItem_Click;

                }
                presetItem.DropDown.Items.Add(walletInventory);
                // FORKS
                ToolStripMenuItem forkInventory = new ToolStripMenuItem() { Text = "Fork Inventory", Image = ContentManager.GetIcon("Forks") };
                ToolStripMenuItem forkAllItem = new ToolStripMenuItem() { Text = "All" };
                forkInventory.DropDown.Items.Add(forkAllItem);
                forkAllItem.Click += PresetItem_Click;

                var forkroots = WalletManager.ForkList.Select(b => b.Blockchain).Distinct();

                foreach (var walletFork in forkroots)
                {
                    //LogManager.AddLogMessage(Name, "UpdateWatchlists", "wallet=" + wallet, LogManager.LogMessageType.DEBUG);
                    ToolStripMenuItem forkItem = new ToolStripMenuItem() { Text = walletFork, Image = ContentManager.GetSymbolIcon(walletFork) };
                    forkInventory.DropDown.Items.Add(forkItem);
                    forkItem.Click += PresetItem_Click;

                }
                presetItem.DropDown.Items.Add(forkInventory);

                // END
                toolStripDropDownButton_watchlists.DropDown.Items.Add(presetItem);               
            }
        }
        #endregion

        #region EventHandlers
        private void EditWatchlistItem_Click(object sender, EventArgs e)
        {
            Form form = new Form()
            {
                Text = "Edit Arbitrage Watchlists",
                Width = 1280,
                Height = 600
            };

            ArbitrageWatchListEditorControl control = new ArbitrageWatchListEditorControl()
            {
                Dock = DockStyle.Fill
            };
            control.arbitrageManagerControl = this;
            form.Controls.Add(control);
            PreferenceManager.SetTheme(PreferenceManager.preferences.Theme.type, form);

            form.Show();

        }
        private void PresetItem_Click(object sender, EventArgs e)
        {
            //LogManager.AddLogMessage(Name, "WatchlistItem_Click", sender.ToString(), LogManager.LogMessageType.DEBUG);
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item.Text.Contains("All"))
            {
                toolStripDropDownButton_watchlists.Text = item.Text + " " + item.OwnerItem.Text;
            }
            else
            {
                toolStripDropDownButton_watchlists.Text = item.Text;
            }
            ArbitragePreferences.CurrentWatchList = item.Text + "|" + item.OwnerItem.Text;
            UpdatePreferenceFile(PreferenceType.Arbitrage);
            SetWatchlist(true, true);
        }
        private void SetOptionsMenu()
        {
            
            if (WatchList.ShowCharts)
            {
                toolStripMenuItem_chart.Text = "Hide Charts";
                toolStripMenuItem_chart.Image = Properties.Resources.ConnectionStatus_ACTIVE;
            }
            else
            {
                toolStripMenuItem_chart.Text = "Show Charts";
                toolStripMenuItem_chart.Image = Properties.Resources.ConnectionStatus_ERROR;
            }

            if (WatchList.ShowLists)
            {
                toolStripMenuItem_list.Text = "Hide Lists";
                toolStripMenuItem_list.Image = Properties.Resources.ConnectionStatus_ACTIVE;
            }
            else
            {
                toolStripMenuItem_list.Text = "Show Lists";
                toolStripMenuItem_list.Image = Properties.Resources.ConnectionStatus_ERROR;
            }
            
        }
        private void ToggleCharts()
        {
            //LogManager.AddLogMessage(Name, "ToggleCharts", PreferenceManager.ArbitragePreferences.ShowCharts.ToString(), LogManager.LogMessageType.DEBUG);
            ArbitrageWatchList watchlist = ArbitragePreferences.GetCurrentWatchList();

            if (WatchList.ShowCharts)
            {
                // Remove Charts
                //WatchList.ShowCharts = false;
                watchlist.ShowCharts = false;
                //UpdatePreferenceFile(PreferenceType.Arbitrage);
                //toolStripButton_charts.Text = "Show Charts";
                //toolStripButton_charts.Image = Properties.Resources.ConnectionStatus_ERROR;
                //controlSize = new Size(150, 150);
                toolStripMenuItem_chart.Text = "Show Charts";
                toolStripMenuItem_chart.Image = Properties.Resources.ConnectionStatus_ERROR;
            }
            else
            {
                // Add Charts
                //WatchList.ShowCharts = true;
                watchlist.ShowCharts = true;
                
                //toolStripButton_charts.Text = "Hide Charts";
                //toolStripButton_charts.Image = Properties.Resources.ConnectionStatus_ACTIVE;
                //controlSize = new Size(150, 300);
                toolStripMenuItem_chart.Text = "Hide Charts";
                toolStripMenuItem_chart.Image = Properties.Resources.ConnectionStatus_ACTIVE;
            }
            UpdatePreferenceFile(PreferenceType.Arbitrage);
            //UpdateUI();
            SetWatchlist(true);
        }
        private void ToggleLists()
        {
            //LogManager.AddLogMessage(Name, "ToggleCharts", PreferenceManager.ArbitragePreferences.ShowCharts.ToString(), LogManager.LogMessageType.DEBUG);
            ArbitrageWatchList watchlist = ArbitragePreferences.GetCurrentWatchList();

            if (watchlist.ShowLists)
            {
                // Remove Lists
                watchlist.ShowLists = false;
                //UpdatePreferenceFile(PreferenceType.Arbitrage);
                toolStripMenuItem_list.Text = "Show Lists";
                toolStripMenuItem_list.Image = Properties.Resources.ConnectionStatus_ERROR;
            }
            else
            {
                // Add Lists
                WatchList.ShowLists = true;              
                toolStripMenuItem_list.Text = "Hide Lists";
                toolStripMenuItem_list.Image = Properties.Resources.ConnectionStatus_ACTIVE;
            }
            UpdatePreferenceFile(PreferenceType.Arbitrage);
            //UpdateUI();
            SetWatchlist(true);
        }
        private void toolStripButton_charts_Click(object sender, EventArgs e)
        {
            ToggleCharts();
        }
        private void toolStripDropDownButton_market_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_market.Text = e.ClickedItem.Text;
            PreferenceManager.ArbitragePreferences.market = e.ClickedItem.Text;
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Arbitrage);
            toolStripDropDownButton_market.Image = e.ClickedItem.Image;
            SetWatchlist();
        }
        private void toolStripDropDownButton_menu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
                //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
                toolStripDropDownButton_menu.DropDown.Hide();
                switch (menuItem.Tag.ToString())
                {
                    case "Font":
                        FontDialog dialog = new FontDialog() { Font = ParentForm.Font };
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            if (PreferenceManager.SetFormFont(ParentForm, dialog.Font))
                            {
                                UpdateUI(true);
                            }
                        }
                        UpdateUI(true);
                        break;

                    case "FontIncrease":
                        if (PreferenceManager.SetFormFont(ParentForm, new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style)))
                        {
                            UpdateUI(true);
                        }
                        break;

                    case "FontDecrease":
                        if (PreferenceManager.SetFormFont(ParentForm, new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style)))
                        {
                            UpdateUI(true);
                        }
                        break;

                    case "Charts":
                        ToggleCharts();
                        break;

                    case "Lists":
                        ToggleLists();
                        break;

                    case "Update":
                        UpdateUI();
                        break;

                    default:
                        // NOTHING
                        break;
                }

            }
        }
        private void toolStripDropDownButton_period_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_period.Text = e.ClickedItem.Text;
            CryptoCompare.CryptoCompareChartPeriod type = (CryptoCompare.CryptoCompareChartPeriod)Enum.Parse(typeof(CryptoCompare.CryptoCompareChartPeriod), e.ClickedItem.Tag.ToString());
            PreferenceManager.ArbitragePreferences.ChartPeriod = type;
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Arbitrage);
            //PreferenceManager.CryptoComparePreferences.PeriodType = type;
            //PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.CryptoCompare);
            //UpdateUI();
            //flowLayoutPanel.Controls.Clear();
            SetWatchlist();
        }
        private void toolStripNumberControl_maxItems_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = toolStripNumberControl_maxItems.NumericUpDownControl as NumericUpDown;
            int value = Convert.ToInt32(num.Value);
            if (PreferenceManager.ArbitragePreferences.maxListCount != value)
            {
                LogManager.AddLogMessage(Name, "toolStripNumberControl_maxItems_ValueChanged", "sender=" + sender + " | " + e.GetType() + " | " + e.GetHashCode() + " | " + value, LogManager.LogMessageType.DEBUG);
                PreferenceManager.ArbitragePreferences.maxListCount = Convert.ToInt32(num.Value);
                PreferenceManager.UpdatePreferenceFile();
                UpdateUI(true);
            }
        }
        private void WatchlistItem_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            //LogManager.AddLogMessage(Name, "WatchlistItem_Click", item.Text, LogManager.LogMessageType.DEBUG);
            toolStripDropDownButton_watchlists.Text = item.Text;
            ArbitragePreferences.CurrentWatchList = item.Text;
            UpdatePreferenceFile(PreferenceType.Arbitrage);
            //UpdateOverviews();
            SetWatchlist(true, true);
        }
        #endregion
    }
}


/*
                else
                {
                    ToolStripMenuItem presetItem = new ToolStripMenuItem() { Text = "Presets" };
                    ToolStripMenuItem exchangeInventory = new ToolStripMenuItem() { Text = "Exchange Inventory" };

                    foreach (ExchangeManager.Exchange exchange in Exchanges)
                    {
                        ToolStripMenuItem exchangeItem = new ToolStripMenuItem() { Text = exchange.Name };
                        exchangeInventory.DropDown.Items.Add(exchangeItem);
                        exchangeItem.Click += ExchangeItem_Click;
                    }
                    presetItem.DropDown.Items.Add(exchangeInventory);
                    toolStripDropDownButton_watchlists.DropDown.Items.Add(presetItem);
                    

                    //editItem.Click += EditWatchlistItem_Click;


                    toolStripDropDownButton_watchlists.Text = "Edit Watchlists";
                    ToolStripMenuItem editItem = new ToolStripMenuItem() { Text = "Edit Watchlists" };
                    toolStripDropDownButton_watchlists.DropDown.Items.Add(editItem);
                    editItem.Click += EditWatchlistItem_Click;
                }
                */
