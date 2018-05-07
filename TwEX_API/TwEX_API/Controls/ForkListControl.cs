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
            listView.AlwaysGroupByColumn = column_Name;
            listView.HasCollapsibleGroups = true;
            listView.ShowGroups = true;
            /*
            listView_groups.AlwaysGroupByColumn = column_id;
            listView_groups.HasCollapsibleGroups = true;
            listView_groups.ShowGroups = true;
            */
            toolStripButton_collapse.Image = ContentManager.GetIcon("UpDown");
            listView.GroupExpandingCollapsing += ListView_GroupExpandingCollapsing;
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            
            column_CoinName.ImageGetter = new ImageGetterDelegate(aspect_Symbol);
            //column_Balance.AspectGetter = new AspectGetterDelegate(aspect_Balance);
            //column_TotalInBTC.AspectGetter = new AspectGetterDelegate(aspect_btc);
            //column_TotalInUSD.AspectGetter = new AspectGetterDelegate(aspect_usd);
            
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
                    //listView.SetObjects(PreferenceManager.WalletPreferences.Forks);
                    listView.SetObjects(PreferenceManager.WalletPreferences.WalletForks);
                    //toolStripLabel_totals.Text = listView.OLVGroups.Count + " Addresses | " + PreferenceManager.WalletPreferences.Forks.Sum(item => item.TotalInBTC).ToString("N8") + " | " + PreferenceManager.WalletPreferences.Forks.Sum(item => item.TotalInUSD).ToString("C");
                    toolStripLabel_totals.Text = PreferenceManager.WalletPreferences.WalletForks.Count + " Forks : " + PreferenceManager.WalletPreferences.WalletForks.Sum(item => item.TotalInBTC).ToString("N8") + " (" + PreferenceManager.WalletPreferences.WalletForks.Sum(item => item.TotalInUSD).ToString("C") + ")";

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
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + (listView.RowHeightEffective);
                }
                column_Name.Width = 0;
                Visible = true;
            }
        }
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

                
                List<WalletBalance> wallets = PreferenceManager.WalletPreferences.WalletForks.FindAll(item => item.Name == key);


                //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.Items.Count + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed);
                decimal usdTotal = wallets.Sum(item => item.TotalInUSD);
                decimal btcTotal = wallets.Sum(item => item.TotalInBTC);
                group.Header = group.Header + " [" + wallets.Count + " Forks]";
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
            WalletBalance listItem = (WalletBalance)rowObject;
            int rowheight = listView.RowHeightEffective - 3;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(listItem.Symbol), rowheight, rowheight);
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
            PreferenceManager.WalletPreferences.WalletForks.Clear();
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
