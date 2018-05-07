using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.WalletManager;
using BrightIdeasSoftware;

namespace TwEX_API.Controls
{
    public partial class ForkManagerControl : UserControl
    {
        #region Properties
        private ForkData CurrentFork = new ForkData();
        private bool collapsed = false;
        private Dictionary<string, bool> groupStates = new Dictionary<string, bool>();
        #endregion

        #region Initialize
        public ForkManagerControl()
        {
            InitializeComponent();
            InitializeColumns();
            InitializeIcons();
        }
        private void ForkManagerControl_Load(object sender, EventArgs e)
        {
            listView_Forks.AlwaysGroupByColumn = column_Blockchain;
            listView_Forks.HasCollapsibleGroups = true;
            listView_Forks.ShowGroups = true;

            toolStripButton_collapse.Image = ContentManager.GetIcon("UpDown");
            listView_Forks.GroupExpandingCollapsing += ListView_GroupExpandingCollapsing;
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            //column_SymbolIcon.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
            column_Symbol.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
            //column_Balance.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
            column_Date.ImageGetter = new ImageGetterDelegate(aspect_blockchain);

            column_ForkName.ImageGetter = new ImageGetterDelegate(aspect_walletIcon);
            //column_ForkSymbol.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
        }
        private void InitializeIcons()
        {
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripMenuItem_clear.Image = ContentManager.GetIcon("Remove");
            toolStripLabel_btc.Image = ContentManager.GetSymbolIcon("BTC");
            toolStripLabel_usd.Image = ContentManager.GetIcon("USDSymbol");
        }
        #endregion

        #region Delegates
        delegate void UpdateUICallback(bool resize = false);
        public void UpdateUI(bool resize = false)
        {
            if (InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                Invoke(d, new object[] { resize });
            }
            else
            {
                try
                {
                    //listView_Forks.SetObjects(ForkList.OrderByDescending(item => item.Date).ThenByDescending(item => item.Symbol));
                    listView_Forks.SetObjects(ForkList.OrderByDescending(item => item.Date));
                    //toolStripLabel_totals.Text = listView.OLVGroups.Count + " Addresses | " + PreferenceManager.WalletPreferences.Forks.Sum(item => item.TotalInBTC).ToString("N8") + " | " + PreferenceManager.WalletPreferences.Forks.Sum(item => item.TotalInUSD).ToString("C");


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
                toolStrip.ImageScalingSize = PreferenceManager.preferences.IconSize;
                toolStrip_status.ImageScalingSize = PreferenceManager.preferences.IconSize;

                int padding = listView_Forks.RowHeightEffective * 4;

                foreach (ColumnHeader col in listView_Forks.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + padding;
                }

                foreach (ColumnHeader col in listView_Wallets.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + padding;
                }
            }
        }
        #endregion

        #region Getters
        private void aboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "view=" + view + " | group.count=" + e.Groups.Count, LogManager.LogMessageType.OTHER);
            listView_Forks.GroupImageList = ContentManager.SymbolIconList;
            foreach (OLVGroup group in e.Groups)
            {
                string key = group.Key.ToString();
                /*
                if (!groupStates.ContainsKey(key))
                {
                    groupStates.Add(key, false);
                }
                
                //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.GroupId + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed, LogManager.LogMessageType.OTHER);
                
                List<WalletBalance> symbalances = PreferenceManager.WalletPreferences.WalletForks.Where(item => item.Symbol == key.ToString() && item.Balance > 0).ToList();
                decimal usdTotal = symbalances.Sum(b => b.TotalInUSD);
                decimal btcTotal = symbalances.Sum(b => b.TotalInBTC);
                decimal coinTotal = symbalances.Sum(b => b.Balance);

                CryptoCompareCoin coin = PreferenceManager.CryptoComparePreferences.CoinList.FirstOrDefault(item => item.Symbol == group.Key.ToString());
                CoinMarketCapTicker priceItem = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == key);
                //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "HEADER=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | itemcount=" + group.Items.Count, LogManager.LogMessageType.OTHER);
                string price = "";
                if (priceItem != null)
                {
                    price = " " + priceItem.price_usd.ToString("C");
                }

                if (coin != null)
                {
                    group.Header = coin.FullName + price;
                }
                else
                {
                    group.Header = key + price;
                }
                */
                group.TitleImage = key;
                /*
                if (balances.Count > 1)
                {
                    group.Task = "[" + symbalances.Count + "] " + usdTotal.ToString("C");
                }
                else
                {
                    group.Task = usdTotal.ToString("C");
                }
                group.Subtitle = "(" + coinTotal.ToString("N8") + ")";
                group.Collapsed = groupStates[key];
                */

                /*
                try
                {
                    List<ExchangeBalance> balances = GetBalances();

                    switch (view)
                    {
                        case BalanceViewType.symbol:
                            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "Group Count=" + e.Groups.Count + " | view=" + view + " | params=" + e.Parameters + " | " + e.Groups, LogManager.LogMessageType.OTHER);

                            listView.GroupImageList = ContentManager.SymbolIconList;
                            foreach (OLVGroup group in e.Groups)
                            {
                                string key = group.Key.ToString();

                                if (!groupStates.ContainsKey(key))
                                {
                                    groupStates.Add(key, false);
                                }

                                //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.GroupId + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed, LogManager.LogMessageType.OTHER);
                                List<ExchangeBalance> symbalances = balances.Where(item => item.Symbol == key.ToString() && item.Balance > 0).ToList();
                                decimal usdTotal = symbalances.Sum(b => b.TotalInUSD);
                                decimal btcTotal = symbalances.Sum(b => b.TotalInBTC);
                                decimal coinTotal = symbalances.Sum(b => b.Balance);

                                CryptoCompareCoin coin = PreferenceManager.CryptoComparePreferences.CoinList.FirstOrDefault(item => item.Symbol == group.Key.ToString());
                                CoinMarketCapTicker priceItem = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == key);
                                //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "HEADER=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | itemcount=" + group.Items.Count, LogManager.LogMessageType.OTHER);
                                string price = "";
                                if (priceItem != null)
                                {
                                    price = " " + priceItem.price_usd.ToString("C");
                                }

                                if (coin != null)
                                {
                                    group.Header = coin.FullName + price;
                                }
                                else
                                {
                                    group.Header = key + price;
                                }

                                group.TitleImage = key;

                                if (balances.Count > 1)
                                {
                                    group.Task = "[" + symbalances.Count + "] " + usdTotal.ToString("C");
                                }
                                else
                                {
                                    group.Task = usdTotal.ToString("C");
                                }
                                group.Subtitle = "(" + coinTotal.ToString("N8") + ")";
                                group.Collapsed = groupStates[key];
                            }
                            break;

                        case BalanceViewType.exchange:
                            listView.GroupImageList = ContentManager.ExchangeIconList;

                            foreach (OLVGroup group in e.Groups)
                            {
                                string key = group.Key.ToString();

                                if (!groupStates.ContainsKey(key))
                                {
                                    groupStates.Add(key, false);
                                }
                                //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.Items.Count + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed);
                                decimal usdTotal = balances.Where(item => item.Exchange == group.Key.ToString() && item.Balance > 0).Sum(b => b.TotalInUSD);
                                decimal btcTotal = balances.Where(item => item.Exchange == group.Key.ToString() && item.Balance > 0).Sum(b => b.TotalInBTC);
                                group.Header = group.Header.ToUpper();
                                group.TitleImage = group.Key;

                                if (group.Items.Count > 1)
                                {
                                    group.Task = "[" + group.Items.Count + "] " + usdTotal.ToString("C");
                                }
                                else
                                {
                                    group.Task = usdTotal.ToString("C");
                                }

                                group.Subtitle = "(" + btcTotal.ToString("N8") + ")";
                                group.Collapsed = groupStates[key];
                            }

                            break;

                        case BalanceViewType.balance:
                            // DO NOTHING
                            break;

                        default:
                            // DO NOTHING
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "aboutToCreateGroups", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
                */
            }
        }      
        public object aspect_symbolIcon(object rowObject)
        {
            try
            {
                ForkData fork = (ForkData)rowObject;
                return ContentManager.ResizeImage(ContentManager.GetForkSymbolIcon(fork.Symbol, fork.IconUrl), listView_Forks.RowHeightEffective, listView_Forks.RowHeightEffective);
                /*
                if (balance != null)
                {
                    //return DataManager.ResizeImage(ExchangeManager.GetExchangeImage(e.exchange), 24, 24);
                    return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(balance.Symbol), listView.RowHeightEffective, listView.RowHeightEffective);
                }
                else
                {
                    return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
                }
                */
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "aspect_symbolIcon", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_ERROR, listView_Forks.RowHeightEffective, listView_Forks.RowHeightEffective);
            }
        }
        private object aspect_walletIcon(object rowObject)
        {
            WalletBalance balance = (WalletBalance)rowObject;
            int rowheight = listView_Wallets.RowHeightEffective - 3;
            return ContentManager.ResizeImage(ContentManager.GetWalletIcon(balance.WalletName), rowheight, rowheight);
            //return ContentManager.GetWalletIcon(balance.WalletName);
        }
        public object aspect_blockchain(object rowObject)
        {
            try
            {
                ForkData fork = (ForkData)rowObject;
                return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(fork.Blockchain), listView_Forks.RowHeightEffective, listView_Forks.RowHeightEffective);
                /*
                if (balance != null)
                {
                    return ContentManager.ResizeImage(ContentManager.GetExchangeIcon(balance.Exchange), listView.RowHeightEffective, listView.RowHeightEffective);
                }
                else
                {
                    return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective / 2, listView.RowHeightEffective / 2);
                }
                */
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "aspect_blockchain", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView_Forks.RowHeightEffective / 2, listView_Forks.RowHeightEffective / 2);
            }
        }
        #endregion

        #region EventHandlers
        private void toolStripButton_toggleGroup_Click(object sender, EventArgs e)
        {
            toggleCollapsed();
        }
        private void toggleCollapsed()
        {
            collapsed = !collapsed;
            for (int i = 0; i < listView_Forks.OLVGroups.Count; i++)
            {
                OLVGroup grp = listView_Forks.OLVGroups[i];
                //LogManager.AddLogMessage(Name, "toggleCollapsed", grp.Header + " | " + grp.Collapsed);
                grp.Collapsed = collapsed;
            }
            foreach (var item in groupStates.ToList())
            {
                groupStates[item.Key] = collapsed;
            }
        }
   
        private void ListView_GroupExpandingCollapsing(object sender, GroupExpandingCollapsingEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "ListView_GroupExpandingCollapsing", e.Group.Key + " | " + e.IsExpanding, LogManager.LogMessageType.DEBUG);
            string key = e.Group.Key.ToString();
            if (e.IsExpanding)
            {
                groupStates[key] = false;
            }
            else
            {
                groupStates[key] = true;
            }
        }
        private void toolStripDropDownButton_menu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
                toolStripDropDownButton_menu.HideDropDown();
                //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
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
                        //UpdateUI(true);
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

                    case "ClearData":
                        PreferenceManager.WalletPreferences.WalletForks.Clear();
                        PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Wallet);
                        UpdateUI();
                        break;

                    default:
                        // NOTHING
                        break;
                }
            }
        }

        private void listView_Forks_ItemActivate(object sender, EventArgs e)
        {
            CurrentFork = listView_Forks.SelectedObject as ForkData;
            LoadWallets();
        }

        private void LoadWallets()
        {
            
            toolStripLabel_fork.Image = ContentManager.GetForkSymbolIcon(CurrentFork.Symbol, CurrentFork.IconUrl);
            List<WalletBalance> wallets = PreferenceManager.WalletPreferences.Wallets.Where(item => item.Symbol == CurrentFork.Blockchain).ToList();

            foreach (WalletBalance wallet in wallets)
            {
                WalletBalance walletFork = PreferenceManager.WalletPreferences.WalletForks.FirstOrDefault(item => item.Symbol == CurrentFork.Symbol.ToUpper() && item.Name == wallet.Name);

                if (walletFork == null)
                {
                    WalletBalance newFork = new WalletBalance()
                    {
                        Address = wallet.Address,
                        CoinName = CurrentFork.Name,
                        IsForkBalance = true,
                        Name = wallet.Name,
                        Symbol = CurrentFork.Symbol.ToUpper(),
                        WalletName = wallet.WalletName
                    };
                    PreferenceManager.WalletPreferences.WalletForks.Add(newFork);
                }
            }
            List<WalletBalance> balances = PreferenceManager.WalletPreferences.WalletForks.Where(item => item.Symbol == CurrentFork.Symbol).ToList();
            listView_Wallets.SetObjects(balances);
            toolStripLabel_fork.Text = CurrentFork.Name + " (" + CurrentFork.Symbol + ")";

            toolStripLabel_balance.Image = ContentManager.GetForkSymbolIcon(CurrentFork.Symbol, CurrentFork.IconUrl);
            toolStripLabel_balance.Text = balances.Sum(item => item.Balance).ToString("N8");

            toolStripLabel_btc.Text = balances.Sum(item => item.TotalInBTC).ToString("N8");
            toolStripLabel_usd.Text = balances.Sum(item => item.TotalInUSD).ToString("C");
            /*
            foreach (ColumnHeader col in listView_Wallets.ColumnsInDisplayOrder)
            {
                col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                col.Width = col.Width + (listView_Wallets.RowHeightEffective * 2);
            }
            */
        }

        private void listView_Forks_FormatRow(object sender, FormatRowEventArgs e)
        {
            ForkData fork = (ForkData)e.Model;

            if (fork.Explorer.Length == 0)
            {
                //e.Item.BackColor = PreferenceManager.preferences.Theme.Yellow;
                e.Item.ForeColor = Color.LightSlateGray;
            }

            if (fork.Claimed)
            {
                e.Item.BackColor = PreferenceManager.preferences.Theme.Green;
            }
        }
        private void listView_Forks_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_Forks.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if (listView_Forks.SelectedObject != null)
                    {

                        ForkData item = listView_Forks.SelectedObject as ForkData;
                        ContextMenuStrip menu = new ContextMenuStrip();

                        ToolStripMenuItem menuItem = new ToolStripMenuItem() { Text = "Go To " + item.Url };
                        menuItem.Click += new EventHandler(Url_Menu_Click);
                        menu.Items.Add(menuItem);
                        /*
                        //ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem importItem = new ToolStripMenuItem() { Text = "Check Balance For " + item.Name + "_" + item.Symbol + "_" + item.Address };
                        importItem.Click += new EventHandler(ImportItem_Menu_Click);
                        menu.Items.Add(importItem);
                        */
                        menu.Show(Cursor.Position);

                    }
                }
            }
        }

        private void listView_Wallets_FormatRow(object sender, FormatRowEventArgs e)
        {
            WalletBalance wallet = (WalletBalance)e.Model;

            if (wallet.Verified)
            {
                //e.Item.BackColor = PreferenceManager.preferences.Theme.Yellow;
                e.Item.BackColor = PreferenceManager.preferences.Theme.Green;
            }
        }
        private void listView_Wallets_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_Wallets.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if (listView_Wallets.SelectedObject != null)
                    {

                        WalletBalance item = listView_Wallets.SelectedObject as WalletBalance;
                        ForkData fork = ForkList.FirstOrDefault(f => f.Symbol == item.Symbol && f.Name == item.CoinName);

                        ContextMenuStrip menu = new ContextMenuStrip();

                        ToolStripMenuItem menuItem = new ToolStripMenuItem()
                        {
                            Text = "Copy Address To Clipboard " + item.Address,
                            Image = ContentManager.GetIcon("ClipboardLoad")
                        };

                        menuItem.Click += new EventHandler(CopyItem_Menu_Click);
                        menu.Items.Add(menuItem);



                        if (fork != null)
                        {
                            if (fork.Explorer.Length > 0)
                            {
                                ToolStripMenuItem importItem = new ToolStripMenuItem()
                                {
                                    Text = "Check Balance For " + item.Name + "_" + item.Symbol + "_" + item.Address,
                                    Image = ContentManager.GetIcon("SearchList")
                                };
                                importItem.Click += new EventHandler(CheckItem_Menu_Click);
                                menu.Items.Add(importItem);
                            }
                        }

                        menu.Items.Add(new ToolStripSeparator());

                        ToolStripMenuItem verifyItem = new ToolStripMenuItem()
                        {
                            Text = "Verify " + item.Address,
                            Image = ContentManager.GetIcon("Unknown")
                        };

                        verifyItem.Click += new EventHandler(VerifyItem_Menu_Click);
                        menu.Items.Add(verifyItem);

                        menu.Show(Cursor.Position);

                    }
                }
            }
        }

        private void CopyItem_Menu_Click(object sender, EventArgs e)
        {
            string data = sender.ToString().Replace("Copy Address To Clipboard ", "");
            /*
            string[] split = data.Split('_');
            string name = split[0];
            string symbol = split[1];
            string address = split[2];
            */
            //LogManager.AddLogMessage(Name, "ImportItem_Menu_Click", forkData.Url, LogManager.LogMessageType.DEBUG);
            Clipboard.SetText(data);
        }
        private void CheckItem_Menu_Click(object sender, EventArgs e)
        {
            string data = sender.ToString().Replace("Check Balance For ", "");
            string[] split = data.Split('_');
            string name = split[0];
            string symbol = split[1];
            string address = split[2];

            //LogManager.AddLogMessage(Name, "ImportItem_Menu_Click", "Import For : " + name + " | " + symbol + " | " + address, LogManager.LogMessageType.DEBUG);

            ForkData forkData = ForkList.FirstOrDefault(item => item.Symbol == symbol);

            if (forkData != null)
            {
                //LogManager.AddLogMessage(Name, "ImportItem_Menu_Click", forkData.Url, LogManager.LogMessageType.DEBUG);
                Clipboard.SetText(address);
                FormManager.OpenUrl(forkData.Explorer);
            }
        }
        private void Url_Menu_Click(object sender, EventArgs e)
        {
            string data = sender.ToString().Replace("Go To ", "");
            FormManager.OpenUrl(data);
            /*
            string[] split = data.Split('_');
            string name = split[0];
            string symbol = split[1];
            string address = split[2];
            */
            //LogManager.AddLogMessage(Name, "ImportItem_Menu_Click", forkData.Url, LogManager.LogMessageType.DEBUG);
            //Clipboard.SetText(data);
        }
        private void VerifyItem_Menu_Click(object sender, EventArgs e)
        {
            string data = sender.ToString().Replace("Verify ", "");

            if (listView_Wallets.SelectedObject != null)
            {
                WalletBalance balance = listView_Wallets.SelectedObject as WalletBalance;
                //balance.Verified = true;
                WalletBalance listItem = PreferenceManager.WalletPreferences.WalletForks.FirstOrDefault(item => item.Symbol == balance.Symbol && item.Name == balance.Name);

                if (listItem != null)
                {
                    listItem.Verified = true;
                    PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Wallet);
                    LoadWallets();
                }

                
            }
        }

        #endregion

        private void listView_Wallets_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            WalletBalance balance = listView_Wallets.SelectedObject as WalletBalance;

            if (balance != null)
            {
                WalletBalance listItem = PreferenceManager.WalletPreferences.WalletForks.FirstOrDefault(item => item.Symbol == balance.Symbol && item.Name == balance.Name);
                if (listItem != null)
                {

                    try
                    {
                        Decimal newValue = Convert.ToDecimal(e.Control.Text);
                        //LogManager.AddLogMessage(Name, "listView_Wallets_CellEditFinishing", balance.Symbol + " | " + e.Control.Text + " | " + e.Value, LogManager.LogMessageType.DEBUG);
                        listItem.Balance = newValue;
                        PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Wallet);
                        LoadWallets();
                    }
                    catch (Exception ex)
                    {
                        LogManager.AddLogMessage(Name, "listView_Wallets_CellEditFinishing", ex.Message, LogManager.LogMessageType.EXCEPTION);
                    }
                }             
            }
            //LogManager.AddLogMessage(Name, "listView_Wallets_CellEditFinishing", sender + " | " + e.Control.Text + " | " + e.Value, LogManager.LogMessageType.DEBUG);
        }
    }
}
