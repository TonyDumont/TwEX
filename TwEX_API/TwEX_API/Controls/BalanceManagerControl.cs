using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using static TwEX_API.Market.CryptoCompare;
using TwEX_API.Market;

namespace TwEX_API.Controls
{
    public partial class BalanceManagerControl : UserControl
    {
        #region Properties
        private string view = "balance";
        private bool collapsed = true;
        #endregion

        #region Initialize
        public BalanceManagerControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void BalanceManagerControl_Load(object sender, EventArgs e)
        {
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            //toolStripButton_Font.Image = ContentManager.GetIcon("Font");
            toolStripRadioButton_balance.Image = ContentManager.GetIcon("BalanceManager");
            toolStripRadioButton_exchange.Image = ContentManager.GetIcon("ExchangeEditor");
            toolStripRadioButton_symbol.Image = ContentManager.GetIcon("Symbol");
            toolStripButton_collapse.Image = ContentManager.GetIcon("UpDown");
            toolStripRadioButton_balance.Checked = true;

            UpdateUI(true);
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
                    List<ExchangeManager.ExchangeBalance> list = ExchangeManager.Balances.Where(item => item.Balance > 0).ToList();
                    List<ExchangeManager.ExchangeBalance> wallets = WalletManager.GetWalletBalances();
                    list.AddRange(wallets);

                    var roots = list.Select(b => b.Symbol).Distinct();

                    toolStripLabel_CoinCount.Text = roots.Count() + " Coins | " + list.Sum(b => b.TotalInBTC).ToString("N8") + " | " + list.Sum(b => b.TotalInUSD).ToString("C");

                    switch (view)
                    {
                        case "symbol":                      
                            listView.AlwaysGroupByColumn = column_Symbol;
                            listView.HasCollapsibleGroups = true;
                            listView.ShowGroups = true;

                            column_Symbol.IsVisible = false;
                            column_SymbolIcon.IsVisible = false;
                            column_ExchangeIcon.IsVisible = true;
                            column_Balance.IsVisible = true;

                            listView.RebuildColumns();
                            listView.SetObjects(list);
                            listView.Sort(column_Symbol, SortOrder.Ascending);                          
                            break;

                        case "exchange":
                            listView.AlwaysGroupByColumn = column_Exchange;
                            listView.HasCollapsibleGroups = true;
                            listView.ShowGroups = true;

                            column_Symbol.IsVisible = true;
                            column_SymbolIcon.IsVisible = true;
                            column_ExchangeIcon.IsVisible = false;
                            column_Balance.IsVisible = true;

                            listView.RebuildColumns();
                            listView.SetObjects(list);
                            listView.Sort(column_Exchange, SortOrder.Ascending);
                            break;

                        case "balance":
                            listView.AlwaysGroupByColumn = null;
                            listView.HasCollapsibleGroups = false;
                            listView.ShowGroups = false;
                            
                            column_Symbol.IsVisible = true;
                            column_SymbolIcon.IsVisible = true;
                            column_ExchangeIcon.IsVisible = true;
                            column_Balance.IsVisible = true;

                            listView.RebuildColumns();
                            listView.SetObjects(list);
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
            if (this.InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                this.Invoke(d, new object[] { });
            }
            else
            {
                ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                toolStrip.Font = ParentForm.Font;
                //toolStrip_footer.Font = ParentForm.Font;

                toolStrip.ImageScalingSize = PreferenceManager.preferences.IconSize;

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
                /*
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    //col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //col.Width = col.Width + (rowHeight * 2);
                    formWidth += col.Width;
                }
                

                //ParentForm.Width = formWidth + 50;
                //PreferenceManager.UpdateFormPreferences(ParentForm, true);
                */
                if (view != "balance")
                {
                    collapsed = false;
                    toggleCollapsed();
                    toolStripButton_collapse.Enabled = true;
                }
                else
                {
                    toolStripButton_collapse.Enabled = false;
                }

            }
        }
        #endregion

        #region Getters
        private void aboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "view=" + view + "params=" + e.Parameters + " | group.count=" + e.Groups.Count, LogManager.LogMessageType.OTHER);
            List<ExchangeManager.ExchangeBalance> balances = ExchangeManager.GetBalances();

            switch (view)
            {
                case "symbol":
                    //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "Group Count=" + e.Groups.Count + " | view=" + view + " | params=" + e.Parameters + " | " + e.Groups, LogManager.LogMessageType.OTHER);
                    //ImageList imageList = ExchangeManager.symbolIconList;
                    //imageList. .Images.AddRange(WalletManager.WalletIconList.Images);
                    listView.GroupImageList = ContentManager.SymbolIconList;
                    //listView.GroupImageList. .Images.AddRange(WalletManager.WalletIconList.Images);


                    foreach (OLVGroup group in e.Groups)
                    {
                        //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.GroupId + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed, LogManager.LogMessageType.OTHER);
                        //List<ExchangeManager.ExchangeBalance> balances = ExchangeManager.Balances.Where(item => item.Symbol == group.Key.ToString() && item.Balance > 0).ToList();
                        List<ExchangeManager.ExchangeBalance> symbalances = balances.Where(item => item.Symbol == group.Key.ToString() && item.Balance > 0).ToList();
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

                case "exchange":

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

                case "balance":
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
                ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;

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
                ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;

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
        /*
        private void toolStripButton_FontUp_Click(object sender, EventArgs e)
        {
            ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style);
            UpdateUI(true);
        }
        private void toolStripButton_Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = ParentForm.Font;
            DialogResult result = fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ParentForm.Font = fontDialog.Font;
            }
            UpdateUI(true);
        }
        private void toolStripButton_FontDown_Click(object sender, EventArgs e)
        {
            ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style);
            UpdateUI(true);
        }
        */
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
                            ParentForm.Font = dialog.Font;
                        }
                        UpdateUI(true);
                        break;

                    case "FontIncrease":
                        ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style);
                        UpdateUI(true);
                        break;

                    case "FontDecrease":
                        ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style);
                        UpdateUI(true);
                        break;

                    default:
                        // NOTHING
                        break;
                }
            }
        }
        private void toolStripRadioButton_view_Click(object sender, EventArgs e)
        {
            ToolStripRadioButton button = sender as ToolStripRadioButton;
            //LogManager.AddLogMessage(Name, "toolStripRadioButton_view_Click", "Changing View to : " + button.Tag, LogManager.LogMessageType.DEBUG);
            
            view = button.Tag.ToString();
            UpdateUI(true);

            
            //tabControl.SelectTab("tabPage_" + view);
            
            
        }
        private void toolStripButton_toggleGroup_Click(object sender, EventArgs e)
        {
            toggleCollapsed();
        }
        private void toggleCollapsed()
        {
            collapsed = !collapsed;
            /*
            if (collapsed)
            {
                //toolStripButton_expand.Image = Properties.Resources.expandicon;
            }
            else
            {
                //toolStripButton_expand.Image = Properties.Resources.collapseicon;
            }
            */
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