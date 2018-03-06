using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TwEX_API.ExchangeManager;
using BrightIdeasSoftware;
using static TwEX_API.Market.CryptoCompare;
using System.Collections.ObjectModel;

namespace TwEX_API.Controls
{
    public partial class BalanceDataViewControl : UserControl
    {
        #region Properties
        public BalanceViewType view = BalanceViewType.balance;
        public BalanceManagerControl manager;
        //private bool initialized = false;
        private bool collapsed = false;

        private ObservableCollection<ExchangeBalance> BalanceList = new ObservableCollection<ExchangeBalance>();
        //private BindingList<ExchangeBalance> BalanceList = new BindingList<ExchangeBalance>();
        #endregion

        #region Initialize
        public BalanceDataViewControl()
        {
            InitializeComponent();
            InitializeColumns();
            
        }

        private void BalanceDataViewControl_Load(object sender, EventArgs e)
        {
            toolStripButton_collapse.Image = ContentManager.GetIcon("UpDown");
            //column_SymbolIcon.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
            //column_Balance.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
            //column_ExchangeIcon.ImageGetter = new ImageGetterDelegate(aspect_exchangeIcon);
            //listView.DataSource = BalanceList;
            SetView();
            //listView.SetObjects(BalanceList);
        }
        private void InitializeColumns()
        {
            column_SymbolIcon.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
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
                    List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
                    list.AddRange(wallets);

                    //var roots = list.Select(b => b.Symbol).Distinct();

                    foreach(ExchangeBalance balance in list)
                    {
                        ExchangeBalance listItem = BalanceList.FirstOrDefault(item => item.Exchange == balance.Exchange && item.Symbol == balance.Symbol);

                        if (listItem != null)
                        {
                            // update
                            listItem.Balance = balance.Balance;
                            listItem.OnOrders = balance.OnOrders;
                            listItem.TotalInBTC = balance.TotalInBTC;
                            listItem.TotalInBTCOrders = balance.TotalInBTCOrders;
                            listItem.TotalInUSD = balance.TotalInUSD;
                        }
                        else
                        {
                            BalanceList.Add(balance);
                        }
                    }
                    //listView.setO
                    //listView.DataSource = list;
                    listView.DataSource = BalanceList;
                    //toolStripLabel_totals.Text = roots.Count() + " Coins | " + list.Sum(b => b.TotalInBTC).ToString("N8") + " | " + list.Sum(b => b.TotalInUSD).ToString("C");
                    //toolStripLabel_CoinCount.Text = roots.Count() + " Coins | " + list.Sum(b => b.TotalInBTC).ToString("N8") + " | " + list.Sum(b => b.TotalInUSD).ToString("C");
                    //LogManager.AddLogMessage(Name, "UpdateUI", "LISTVIEW COUNT=" + listView.Items.Count, LogManager.LogMessageType.DEBUG);
                    /*
                    if (listView.Items.Count > 0)
                    {
                        listView.RefreshObjects(list);
                        //listView.Refresh();
                        //listView.Refresh();
                        //listView.RedrawItems(0, listView.Items.Count, true);
                        if (!initialized)
                        {
                            switch (view)
                            {
                                case BalanceViewType.symbol:
                                    listView.Sort(column_Symbol, SortOrder.Ascending);
                                    toolStripLabel_totals.Text = "";
                                    break;

                                case BalanceViewType.exchange:
                                    listView.Sort(column_Exchange, SortOrder.Ascending);
                                    toolStripLabel_totals.Text = Exchanges.Count + " Exchanges";
                                    break;

                                case BalanceViewType.balance:
                                    listView.Sort(column_TotalInBTC, SortOrder.Descending);
                                    toolStripLabel_totals.Text = "";
                                    break;

                                default:

                                    break;

                            }
                            listView.BuildList();
                            initialized = true;
                        }

                        UpdateGroups();
                        //LogManager.AddLogMessage(Name, "UpdateUI", "REFRESHED=" + listView.Items.Count, LogManager.LogMessageType.DEBUG);
                    }
                    else
                    {
                        listView.SetObjects(list);
                        switch (view)
                        {
                            case BalanceViewType.symbol:
                                listView.Sort(column_Symbol, SortOrder.Ascending);
                                toolStripLabel_totals.Text = "";
                                break;

                            case BalanceViewType.exchange:
                                listView.Sort(column_Exchange, SortOrder.Ascending);
                                toolStripLabel_totals.Text = Exchanges.Count + " Exchanges";
                                break;

                            case BalanceViewType.balance:
                                listView.Sort(column_TotalInBTC, SortOrder.Descending);
                                toolStripLabel_totals.Text = "";
                                break;

                            default:

                                break;

                        }
                        //ResizeUI();
                    }
                    */



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
                //Visible = false;
                int rowHeight = listView.RowHeightEffective;
                //int formWidth = 0;

                if (column_SymbolIcon.IsVisible)
                {
                    column_SymbolIcon.Width = listView.RowHeightEffective + 5;
                }

                if (column_ExchangeIcon.IsVisible)
                {
                    column_ExchangeIcon.Width = listView.RowHeightEffective + 5;
                }

                column_Symbol.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                column_Balance.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_Balance.Width = column_Balance.Width + listView.RowHeightEffective;
                column_TotalInBTC.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_TotalInBTC.Width = column_TotalInBTC.Width + listView.RowHeightEffective;
                column_TotalInUSD.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_TotalInUSD.Width = column_TotalInUSD.Width + listView.RowHeightEffective;
                /*
                if (view != BalanceViewType.balance)
                {
                    groups = true;
                    collapsed = false;
                    toggleCollapsed();
                }
                else
                {
                    groups = false;
                }
                */
                //Visible = true;
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
                        column_SymbolIcon.IsVisible = false;
                        column_ExchangeIcon.IsVisible = true;
                        column_Balance.IsVisible = true;

                        //listView.RebuildColumns();
                        toolStripButton_collapse.Visible = true;
                        listView.BackColor = PreferenceManager.preferences.Theme.AlternateBackground;
                        //listView.BackgroundImage = null;
                        //listView.BackColor = Color.LightGray;
                        BackColor = PreferenceManager.preferences.Theme.AlternateBackground;

                        //BackgroundImage = null;
                        //BackColor = Color.LightGray;
                        //listView.SetObjects(list);
                        //listView.Sort(column_Symbol, SortOrder.Ascending);

                        //groups = true;
                        //collapsed = false;
                        //toggleCollapsed();    

                        break;

                    case BalanceViewType.exchange:
                        listView.AlwaysGroupByColumn = column_Exchange;
                        listView.HasCollapsibleGroups = true;
                        listView.ShowGroups = true;

                        column_Symbol.IsVisible = true;
                        column_SymbolIcon.IsVisible = true;
                        column_ExchangeIcon.IsVisible = false;
                        column_Balance.IsVisible = true;

                        //listView.RebuildColumns();
                        toolStripButton_collapse.Visible = true;
                        listView.BackColor = PreferenceManager.preferences.Theme.AlternateBackground;
                        BackColor = PreferenceManager.preferences.Theme.AlternateBackground;
                        //listView.SetObjects(list);
                        //listView.Sort(column_Exchange, SortOrder.Ascending);
                        //groups = true;
                        //collapsed = false;
                        //toggleCollapsed();
                        break;

                    case BalanceViewType.balance:
                        listView.AlwaysGroupByColumn = null;
                        listView.HasCollapsibleGroups = false;
                        listView.ShowGroups = false;

                        column_Symbol.IsVisible = true;
                        column_SymbolIcon.IsVisible = true;
                        column_ExchangeIcon.IsVisible = true;
                        column_Balance.IsVisible = true;

                        //listView.RebuildColumns();
                        toolStripButton_collapse.Visible = false;
                        listView.BackColor = PreferenceManager.preferences.Theme.FormBackground;
                        BackColor = PreferenceManager.preferences.Theme.FormBackground;
                        //listView.SetObjects(list);
                        //listView.Sort(column_TotalInBTC, SortOrder.Descending);

                        //groups = true;
                        //collapsed = false;
                        //toggleCollapsed();

                        //groups = false;

                        break;

                    default:

                        break;

                }
                UpdateUI(true);
            }
        }
        #endregion

        #region Getters
        private void aboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "view=" + view + " | group.count=" + e.Groups.Count, LogManager.LogMessageType.OTHER);
            List<ExchangeBalance> balances = GetBalances();

            switch (view)
            {
                case BalanceViewType.symbol:
                    //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "Group Count=" + e.Groups.Count + " | view=" + view + " | params=" + e.Parameters + " | " + e.Groups, LogManager.LogMessageType.OTHER);
                    listView.GroupImageList = ContentManager.SymbolIconList;
                    foreach (OLVGroup group in e.Groups)
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
                    break;

                case BalanceViewType.exchange:
                    listView.GroupImageList = ContentManager.ExchangeIconList;
                    foreach (OLVGroup group in e.Groups)
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
                    break;

                case BalanceViewType.balance:
                    // DO NOTHING
                    break;

                default:
                    // DO NOTHING
                    break;
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
        private void ListView_GroupExpandingCollapsing(object sender, GroupExpandingCollapsingEventArgs e)
        {
            //throw new NotImplementedException();
            //var list = listView.Groups;
            //LogManager.AddLogMessage(Name, "ListView_GroupExpandingCollapsing", e.Group.Key + " | " + e.IsExpanding, LogManager.LogMessageType.DEBUG);
            //ResizeUI();
            //BrightIdeasSoftware.OLVGroup groups = listView.OLVGroups;
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
            //if (listView.OLVGroups != null)
            //{
            //LogManager.AddLogMessage(Name, "toggleCollapsed", collapsed + " | " + listView.OLVGroups.Count, LogManager.LogMessageType.DEBUG);
            collapsed = !collapsed;
            //LogManager.AddLogMessage(Name, "toggleCollapsed2", collapsed + " | " + listView.OLVGroups.Count, LogManager.LogMessageType.DEBUG);
            for (int i = 0; i < listView.OLVGroups.Count; i++)
            {
                OLVGroup grp = listView.OLVGroups[i];
                //LogManager.AddLogMessage(Name, "toggleCollapsed", grp.Header + " | " + grp.Collapsed);
                grp.Collapsed = collapsed;
            }
            //UpdateUI(true);
            //}
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
        #endregion
    }
}
