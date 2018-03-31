using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using static TwEX_API.ExchangeManager;
using static TwEX_API.Market.CoinMarketCap;
using static TwEX_API.Market.CryptoCompare;

namespace TwEX_API.Controls
{
    public partial class BalanceViewControl : UserControl
    {
        #region Properties
        public BalanceViewType view = BalanceViewType.balance;
        public BalanceManagerControl manager;
        //private bool initialized = false;
        private bool collapsed = false;
        private Dictionary<string, bool> groupStates = new Dictionary<string, bool>();
        #endregion

        #region Initialize
        public BalanceViewControl()
        {
            InitializeComponent();
            InitializeColumns();
            SetView();
        }
        private void BalanceViewControl_Load(object sender, EventArgs e)
        {
            toolStripButton_collapse.Image = ContentManager.GetIcon("UpDown");
            listView.GroupExpandingCollapsing += ListView_GroupExpandingCollapsing;
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            //column_SymbolIcon.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
            column_Symbol.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
            //column_Balance.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
            column_ExchangeIcon.ImageGetter = new ImageGetterDelegate(aspect_exchangeIcon);
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
                    List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0).ToList();
                    //List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
                    list.AddRange(WalletManager.GetWalletBalances());
                    list.AddRange(WalletManager.GetForkBalances());
                    //List<ExchangeBalance> forks = WalletManager.GetForkBalances();
                    listView.SetObjects(list.OrderByDescending(item => item.TotalInBTC));
                    //listView.SetObjects(list.OrderByDescending(item => item.TotalInBTC).ThenByDescending(item => item.Name));
                    
                    switch (view)
                    {
                        case BalanceViewType.symbol:
                            listView.Sort(column_Symbol, SortOrder.Ascending);
                            //listView.SetObjects(list.OrderByDescending(item => item.Symbol));
                            toolStripLabel_totals.Text = "";
                            break;

                        case BalanceViewType.exchange:
                            //listView.Sort(column_Exchange, SortOrder.Ascending);
                            listView.Sort(column_Name, SortOrder.Ascending);
                            //listView.SetObjects(list.OrderByDescending(item => item.Name));
                            toolStripLabel_totals.Text = Exchanges.Count + " Exchanges";
                            break;

                        case BalanceViewType.balance:
                            listView.Sort(column_TotalInBTC, SortOrder.Descending);
                            //listView.SetObjects(list.OrderByDescending(item => item.TotalInBTC));
                            toolStripLabel_totals.Text = "";
                            break;

                        default:

                            break;

                    }
                    
                    //listView.SetObjects(list);

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
                Visible = false;
                int rowHeight = listView.RowHeightEffective;
                int iconSize = listView.RowHeightEffective + 5;

                /*
                if (column_Symbol.IsVisible)
                {
                    column_Symbol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //column_SymbolIcon.Width = iconSize;
                    //column_Symbol.Width = column_Symbol.Width + iconSize;
                }
                else
                {
                    //column_Symbol.Width = 0;
                }
                */

                //int formWidth = 0;
                /*
                if (column_SymbolIcon.IsVisible)
                {
                    column_Symbol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //column_SymbolIcon.Width = iconSize;
                    column_Symbol.Width = column_Symbol.Width + iconSize;
                }
                else
                {
                    column_Symbol.Width = 0;
                }
                */
                if (column_ExchangeIcon.IsVisible)
                {
                    column_ExchangeIcon.Width = iconSize;
                }
                else
                {
                    //column_Exchange.Width = 0;
                }
   
                column_Balance.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_Balance.Width = column_Balance.Width + listView.RowHeightEffective;
                column_TotalInBTC.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_TotalInBTC.Width = column_TotalInBTC.Width + listView.RowHeightEffective;
                column_TotalInUSD.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_TotalInUSD.Width = column_TotalInUSD.Width + listView.RowHeightEffective;
                
                Visible = true;
            }
        }

        delegate void SetViewCallback();
        public void SetView()
        {
            if (InvokeRequired)
            {
                SetViewCallback d = new SetViewCallback(SetView);
                Invoke(d, new object[] { });
            }
            else
            {
                switch (view)
                {
                    case BalanceViewType.symbol:
                        listView.AlwaysGroupByColumn = column_Symbol;
                        listView.HasCollapsibleGroups = true;
                        listView.ShowGroups = true;

                        column_Symbol.IsVisible = false;
                        //column_SymbolIcon.IsVisible = false;
                        column_ExchangeIcon.IsVisible = true;
                        column_Balance.IsVisible = true;

                        listView.RebuildColumns();
                        toolStripButton_collapse.Visible = true;
                        listView.BackColor = PreferenceManager.preferences.Theme.AlternateBackground;

                        //BackColor = PreferenceManager.preferences.Theme.AlternateBackground;
                        break;

                    case BalanceViewType.exchange:
                        listView.AlwaysGroupByColumn = column_Exchange;
                        listView.HasCollapsibleGroups = true;
                        listView.ShowGroups = true;

                        column_Symbol.IsVisible = true;
                        //column_SymbolIcon.IsVisible = true;
                        column_ExchangeIcon.IsVisible = false;
                        column_Balance.IsVisible = true;

                        listView.RebuildColumns();
                        toolStripButton_collapse.Visible = true;
                        listView.BackColor = PreferenceManager.preferences.Theme.AlternateBackground;

                        //BackColor = PreferenceManager.preferences.Theme.AlternateBackground;
                        break;

                    case BalanceViewType.balance:
                        listView.AlwaysGroupByColumn = null;
                        listView.HasCollapsibleGroups = false;
                        listView.ShowGroups = false;

                        column_Symbol.IsVisible = true;
                        //column_SymbolIcon.IsVisible = true;
                        column_ExchangeIcon.IsVisible = true;
                        column_Balance.IsVisible = true;

                        listView.RebuildColumns();
                        toolStripButton_collapse.Visible = false;
                        listView.BackColor = PreferenceManager.preferences.Theme.FormBackground;
                        BackColor = PreferenceManager.preferences.Theme.FormBackground;                      
                        break;

                    default:

                        break;

                }
                /*
                if (listView.Columns.Count > 0)
                {
                    listView.RebuildColumns();
                }
                */
                UpdateUI(true);
            }
        } 
        #endregion

        #region Getters
        private void aboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "view=" + view + " | group.count=" + e.Groups.Count, LogManager.LogMessageType.OTHER);
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
        }      
        public object aspect_symbolIcon(object rowObject)
        {
            try
            {
                ExchangeBalance balance = (ExchangeBalance)rowObject;

                if (balance != null)
                {
                    //return DataManager.ResizeImage(ExchangeManager.GetExchangeImage(e.exchange), 24, 24);
                    return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(balance.Symbol), listView.RowHeightEffective, listView.RowHeightEffective);
                }
                else
                {
                    return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "aspect_symbolIcon", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_ERROR, listView.RowHeightEffective, listView.RowHeightEffective);
            }
        }
        public object aspect_exchangeIcon(object rowObject)
        {
            try
            {
                ExchangeBalance balance = (ExchangeBalance)rowObject;

                if (balance != null)
                {
                    return ContentManager.ResizeImage(ContentManager.GetExchangeIcon(balance.Exchange), listView.RowHeightEffective, listView.RowHeightEffective);
                }
                else
                {
                    return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective / 2, listView.RowHeightEffective / 2);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "aspect_exchangeIcon", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective / 2, listView.RowHeightEffective / 2);
            }
        }
        #endregion

        #region Updaters
        private void UpdateGroups()
        {
            if (view != BalanceViewType.balance)
            {
                //LogManager.AddLogMessage(Name, "UpdateGroups", "view=" + view + " | group.count=" + listView.OLVGroups.Count, LogManager.LogMessageType.OTHER);
                List<ExchangeBalance> balances = GetBalances();

                switch (view)
                {
                    case BalanceViewType.symbol:
                        //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "Group Count=" + e.Groups.Count + " | view=" + view + " | params=" + e.Parameters + " | " + e.Groups, LogManager.LogMessageType.OTHER);
                        listView.GroupImageList = ContentManager.SymbolIconList;

                        foreach (OLVGroup group in listView.OLVGroups)
                        {
                            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.GroupId + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed, LogManager.LogMessageType.OTHER);
                            List<ExchangeBalance> symbalances = balances.Where(item => item.Symbol == group.Key.ToString() && item.Balance > 0).ToList();
                            decimal usdTotal = symbalances.Sum(b => b.TotalInUSD);
                            decimal btcTotal = symbalances.Sum(b => b.TotalInBTC);
                            decimal coinTotal = symbalances.Sum(b => b.Balance);

                            CryptoCompareCoin coin = PreferenceManager.CryptoComparePreferences.CoinList.FirstOrDefault(item => item.Symbol == group.Key.ToString());
                            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "HEADER=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | itemcount=" + group.Items.Count, LogManager.LogMessageType.OTHER);

                            if (coin != null)
                            {
                                group.Header = coin.FullName;
                            }
                            else
                            {
                                group.Header = group.Header.ToUpper();
                            }

                            group.TitleImage = group.Key;

                            if (balances.Count > 1)
                            {
                                group.Task = "[" + symbalances.Count + "] " + usdTotal.ToString("C");
                            }
                            else
                            {
                                group.Task = usdTotal.ToString("C");
                            }
                            group.Subtitle = "(" + coinTotal.ToString("N8") + ")";
                        }
                        //setGroupStates(true);
                        break;

                    case BalanceViewType.exchange:
                        listView.GroupImageList = ContentManager.ExchangeIconList;

                        foreach (OLVGroup group in listView.OLVGroups)
                        {
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
                        }
                        //setGroupStates(true);
                        break;

                    case BalanceViewType.balance:
                        // DO NOTHING
                        break;

                    default:
                        // DO NOTHING
                        break;
                }

            }

        }
        #endregion

        #region EventHandlers
        private void listView_FormatRow(object sender, FormatRowEventArgs e)
        {
            ExchangeBalance balance = (ExchangeBalance)e.Model;

            if (balance.IsFork)
            {
                e.Item.BackColor = PreferenceManager.preferences.Theme.Yellow;
            }

            /*
            if (e.ColumnIndex == column_24hchange.Index)
            {
                if (ticker.percent_change_24h > 0)
                {
                    e.SubItem.BackColor = PreferenceManager.preferences.Theme.Green;
                }
                else
                {
                    e.SubItem.BackColor = PreferenceManager.preferences.Theme.Red;
                }
            }
            */
        }
        private void ListView_GroupExpandingCollapsing(object sender, GroupExpandingCollapsingEventArgs e)
        {
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
        private void listView_GroupStateChanged(object sender, GroupStateChangedEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "listView_GroupStateChanged", sender + " | " + e.Group.Key + " | " + e.Focused + " | " + e.NewState, LogManager.LogMessageType.DEBUG);
            if (e.Focused)
            {
                //LogManager.AddLogMessage(Name, "listView_GroupStateChanged", sender + " | " + e.Group.Key + " | " + e.Focused + " | " + e.NewState, LogManager.LogMessageType.DEBUG);
                if (manager != null)
                {
                    //if (view == BalanceViewType.exchange)
                    manager.SetChart(view, e.Group.Key.ToString());
                }
            }
        }
        private void listView_GroupTaskClicked(object sender, GroupTaskClickedEventArgs e)
        {
            LogManager.AddLogMessage(Name, "listView_GroupTaskClicked", e.Group.GroupId + " | " + e.Group.Header + " | " + e.Group.Id + " | " + e.Group.Key + " | " + e.Group.TopDescription, LogManager.LogMessageType.DEBUG);
            if (manager != null)
            {
                //if (view == BalanceViewType.exchange)
                manager.SetChart(view, e.Group.Key.ToString());
            }
        }      
        private void toolStripButton_toggleGroup_Click(object sender, EventArgs e)
        {
            toggleCollapsed();
        }     
        private void toggleCollapsed()
        {
            collapsed = !collapsed;
            //LogManager.AddLogMessage(Name, "toggleCollapsed2", collapsed + " | " + listView.OLVGroups.Count, LogManager.LogMessageType.DEBUG);
            for (int i = 0; i < listView.OLVGroups.Count; i++)
            {
                OLVGroup grp = listView.OLVGroups[i];
                grp.Collapsed = collapsed;
            }

            foreach (var item in groupStates.ToList())
            {
                groupStates[item.Key] = collapsed;
            }
        }
        #endregion
    }
}

/*
        private void setGroupStates(bool isCollapsed)
        {

            //LogManager.AddLogMessage(Name, "toggleCollapsed", collapsed + " | " + listView.OLVGroups.Count, LogManager.LogMessageType.DEBUG);
            //collapsed = !collapsed;
            //LogManager.AddLogMessage(Name, "toggleCollapsed2", collapsed + " | " + listView.OLVGroups.Count, LogManager.LogMessageType.DEBUG);
            if (listView.OLVGroups != null)
            {
                for (int i = 0; i < listView.OLVGroups.Count; i++)
                {
                    OLVGroup grp = listView.OLVGroups[i];
                    //LogManager.AddLogMessage(Name, "toggleCollapsed", grp.Header + " | " + grp.Collapsed);
                    grp.Collapsed = isCollapsed;
                }
            }
        }
        */
