using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.ExchangeManager;
using BrightIdeasSoftware;
using static TwEX_API.Market.CryptoCompare;

namespace TwEX_API.Controls
{
    public partial class BalanceViewControl : UserControl
    {
        #region Properties
        public BalanceViewType view = BalanceViewType.balance;
        private bool collapsed = true;
        #endregion

        #region Initialize
        public BalanceViewControl()
        {
            InitializeComponent();
            InitializeColumns();
            //InitializeView();
            SetView();
        }
        private void BalanceViewControl_Load(object sender, EventArgs e)
        {
            //InitializeView();
            //UpdateUI(true);
            toolStripButton_collapse.Image = ContentManager.GetIcon("UpDown");

        }
        private void InitializeColumns()
        {
            column_SymbolIcon.ImageGetter = new ImageGetterDelegate(aspect_symbolIcon);
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

                    var roots = list.Select(b => b.Symbol).Distinct();
                    toolStripLabel_totals.Text = view.ToString() + " : " + roots.Count() + " Coins | " + list.Sum(b => b.TotalInBTC).ToString("N8") + " | " + list.Sum(b => b.TotalInUSD).ToString("C");
                    //toolStripLabel_CoinCount.Text = roots.Count() + " Coins | " + list.Sum(b => b.TotalInBTC).ToString("N8") + " | " + list.Sum(b => b.TotalInUSD).ToString("C");
                    listView.SetObjects(list);

                    switch (view)
                    {
                        case BalanceViewType.symbol:
                            listView.Sort(column_Symbol, SortOrder.Ascending);
                            break;

                        case BalanceViewType.exchange:
                            listView.Sort(column_Exchange, SortOrder.Ascending);
                            break;

                        case BalanceViewType.balance:
                            listView.Sort(column_TotalInBTC, SortOrder.Descending);
                            break;

                        default:

                            break;

                    }

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
                
                ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                toolStrip.Font = ParentForm.Font;

                //toolStrip.ImageScalingSize = PreferenceManager.preferences.IconSize;

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

                //column_Symbol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_Symbol.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                //column_Symbol.Width = column_Symbol.Width + listView.RowHeightEffective;

                column_Balance.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_Balance.Width = column_Balance.Width + listView.RowHeightEffective;

                column_TotalInBTC.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_TotalInBTC.Width = column_TotalInBTC.Width + listView.RowHeightEffective;

                column_TotalInUSD.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_TotalInUSD.Width = column_TotalInUSD.Width + listView.RowHeightEffective;
                
                if (view != BalanceViewType.balance)
                {
                    collapsed = false;
                    toggleCollapsed();
                    //toolStripButton_collapse.Enabled = true;
                }
                else
                {
                    //toolStripButton_collapse.Enabled = false;
                }
                
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

                        listView.RebuildColumns();
                        toolStripButton_collapse.Visible = true;
                        //listView.SetObjects(list);
                        //listView.Sort(column_Symbol, SortOrder.Ascending);
                        break;

                    case BalanceViewType.exchange:
                        listView.AlwaysGroupByColumn = column_Exchange;
                        listView.HasCollapsibleGroups = true;
                        listView.ShowGroups = true;

                        column_Symbol.IsVisible = true;
                        column_SymbolIcon.IsVisible = true;
                        column_ExchangeIcon.IsVisible = false;
                        column_Balance.IsVisible = true;

                        listView.RebuildColumns();
                        toolStripButton_collapse.Visible = true;
                        //listView.SetObjects(list);
                        //listView.Sort(column_Exchange, SortOrder.Ascending);
                        break;

                    case BalanceViewType.balance:
                        listView.AlwaysGroupByColumn = null;
                        listView.HasCollapsibleGroups = false;
                        listView.ShowGroups = false;

                        column_Symbol.IsVisible = true;
                        column_SymbolIcon.IsVisible = true;
                        column_ExchangeIcon.IsVisible = true;
                        column_Balance.IsVisible = true;

                        listView.RebuildColumns();
                        toolStripButton_collapse.Visible = false;
                        //listView.SetObjects(list);
                        //listView.Sort(column_TotalInBTC, SortOrder.Descending);
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
            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "view=" + view + "params=" + e.Parameters + " | group.count=" + e.Groups.Count, LogManager.LogMessageType.OTHER);
            List<ExchangeBalance> balances = GetBalances();

            switch (view)
            {
                case BalanceViewType.symbol:
                    //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "Group Count=" + e.Groups.Count + " | view=" + view + " | params=" + e.Parameters + " | " + e.Groups, LogManager.LogMessageType.OTHER);
                    //ImageList imageList = ExchangeManager.symbolIconList;
                    //imageList. .Images.AddRange(WalletManager.WalletIconList.Images);
                    listView.GroupImageList = ContentManager.SymbolIconList;
                    //listView.GroupImageList. .Images.AddRange(WalletManager.WalletIconList.Images);


                    foreach (OLVGroup group in e.Groups)
                    {
                        //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.GroupId + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed, LogManager.LogMessageType.OTHER);
                        //List<ExchangeManager.ExchangeBalance> balances = ExchangeManager.Balances.Where(item => item.Symbol == group.Key.ToString() && item.Balance > 0).ToList();
                        List<ExchangeBalance> symbalances = balances.Where(item => item.Symbol == group.Key.ToString() && item.Balance > 0).ToList();
                        //<ExchangeManager.ExchangeBalance> balances = ExchangeManager.GetBalances();
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

                    //listView.HasCollapsibleGroups = true;
                    //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "groups.count=" + e.Groups.Count, LogManager.LogMessageType.OTHER);
                    listView.GroupImageList = ContentManager.ExchangeIconList;

                    foreach (OLVGroup group in e.Groups)
                    {
                        //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.Items.Count + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed);
                        //LogManager.AddLogMessage(Name, "aboutToCreateGroups", group.Key + " | has " + group.Items.Count + " Items", LogManager.LogMessageType.OTHER);


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
                    //return ContentManager.ResizeImage(ExchangeManager.getExchange(balance.Exchange).Icon, listView.RowHeightEffective, listView.RowHeightEffective);
                    return ContentManager.ResizeImage(ContentManager.GetExchangeIcon(balance.Exchange), listView.RowHeightEffective, listView.RowHeightEffective);
                    //return ContentManager.GetExchangeIcon(balance.Exchange);
                }
                else
                {
                    return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective / 2, listView.RowHeightEffective / 2);
                    //return Properties.Resources.ConnectionStatus_DISABLED;
                }

                //return ContentManager.ResizeImage(ExchangeManager.getExchangeIcon( , listView.RowHeightEffective, listView.RowHeightEffective);
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "aspect_exchangeIcon", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective / 2, listView.RowHeightEffective / 2);
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

            for (int i = 0; i < listView.OLVGroups.Count; i++)
            {
                OLVGroup grp = listView.OLVGroups[i];
                //LogManager.AddDebugMessage(Name, "toolStripButton_collapse_Click", grp.Header + " | " + grp.Collapsed);
                grp.Collapsed = collapsed;
            }

        }
        #endregion
    }
}
