using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.WalletManager;
using BrightIdeasSoftware;

namespace TwEX_API.Controls
{
    public partial class ForkListControl : UserControl
    {
        #region Properties
        private bool collapsed = false;
        private Dictionary<string, bool> groupStates = new Dictionary<string, bool>();
        #endregion

        #region Initialize
        public ForkListControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void ForkListControl_Load(object sender, EventArgs e)
        {
            listView.AlwaysGroupByColumn = column_id;
            listView.HasCollapsibleGroups = true;
            listView.ShowGroups = true;

            toolStripButton_collapse.Image = ContentManager.GetIcon("UpDown");
            listView.GroupExpandingCollapsing += ListView_GroupExpandingCollapsing;
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_ticker.ImageGetter = new ImageGetterDelegate(aspect_Symbol);
            column_Balance.AspectGetter = new AspectGetterDelegate(aspect_Balance);
            column_TotalInBTC.AspectGetter = new AspectGetterDelegate(aspect_btc);
            column_TotalInUSD.AspectGetter = new AspectGetterDelegate(aspect_usd);
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
                    listView.SetObjects(PreferenceManager.WalletPreferences.Forks);
                    toolStripLabel_totals.Text = listView.OLVGroups.Count + " Addresses | " + PreferenceManager.WalletPreferences.Forks.Sum(item => item.TotalInBTC).ToString("N8") + " | " + PreferenceManager.WalletPreferences.Forks.Sum(item => item.TotalInUSD).ToString("C");
                    /*
                    List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0).ToList();
                    List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
                    list.AddRange(wallets);

                    listView.SetObjects(list.OrderByDescending(item => item.TotalInBTC));

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

                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + (listView.RowHeightEffective);
                }

                /*
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
                */

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
        /*
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
                        listView.BackColor = PreferenceManager.preferences.Theme.AlternateBackground;

                        //BackColor = PreferenceManager.preferences.Theme.AlternateBackground;
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
                        listView.BackColor = PreferenceManager.preferences.Theme.AlternateBackground;

                        //BackColor = PreferenceManager.preferences.Theme.AlternateBackground;
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
                        listView.BackColor = PreferenceManager.preferences.Theme.FormBackground;
                        BackColor = PreferenceManager.preferences.Theme.FormBackground;
                        break;

                    default:

                        break;

                }
                UpdateUI(true);
            }
        }
        */
        #endregion

        #region Getters
        private void aboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "view=" + view + " | group.count=" + e.Groups.Count, LogManager.LogMessageType.OTHER);
            
            //List<ExchangeBalance> balances = GetBalances();
            listView.GroupImageList = ContentManager.WalletIconList;

            foreach (OLVGroup group in e.Groups)
            {
                string key = group.Key.ToString();
                WalletBalance wallet = PreferenceManager.WalletPreferences.Wallets.FirstOrDefault(item => item.Name == key);

                if (!groupStates.ContainsKey(key))
                {
                    groupStates.Add(key, false);
                }

                List<Fork> forks = PreferenceManager.WalletPreferences.Forks.FindAll(item => item.id == key);
                //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.Items.Count + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed);
                decimal usdTotal = forks.Sum(item => item.TotalInUSD);
                decimal btcTotal = forks.Sum(item => item.TotalInBTC);
                group.Header = group.Header + " [" + forks.Count + " Forks]";
                group.TitleImage = wallet.WalletName;
                /*
                if (group.Items.Count > 1)
                {
                    group.Task = "[" + group.Items.Count + "] " + usdTotal.ToString("C");
                }
                else
                {
                    group.Task = usdTotal.ToString("C");
                }
                */
                group.Task = usdTotal.ToString("C");
                group.Subtitle = "(" + btcTotal.ToString("N8") + ")";

                group.Collapsed = groupStates[key];
            }
            
        }
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
            if (listItem.TotalInBTC > 0)
            {
                return listItem.TotalInBTC.ToString("N8");
            }
            else
            {
                return string.Empty;
            }
            
        }
        public object aspect_usd(object rowObject)
        {
            //Fork listItem = (Fork)rowObject;
            Fork listItem = (Fork)rowObject;
            if (listItem.TotalInUSD > 0)
            {
                return listItem.TotalInUSD.ToString("C");
            }
            else
            {
                return string.Empty;
            }

            /*
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
            */
        }
        #endregion

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
        private void toolStripButton_collapse_Click(object sender, EventArgs e)
        {
            toggleCollapsed();
            /*
            PreferenceManager.WalletPreferences.Forks.Clear();
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Wallet);
            UpdateUI();
            */
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
    }
}
