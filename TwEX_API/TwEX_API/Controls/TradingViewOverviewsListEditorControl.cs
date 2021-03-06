﻿using System;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.Market.TradingView;

namespace TwEX_API.Controls
{
    public partial class TradingViewOverviewsListEditorControl : UserControl
    {
        #region Properties
        public TradingViewManagerControl tradingViewManagerControl;
        #endregion

        #region Initialize
        public TradingViewOverviewsListEditorControl()
        {
            InitializeComponent();
            InitializeIcons();
            InitializeExchangeMenu();
            InitializeTimespanMenu();
        }
        private void TradingViewOverviewsListEditorControl_Load(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = (int)(splitContainer.ClientSize.Height * 0.70);
            UpdateUI();
        }
        private void InitializeExchangeMenu()
        {
            var values = EnumUtils.GetValues<TradingViewCryptoExchange>();
            toolStripDropDownButton_exchange.DropDownItems.Clear();

            foreach (TradingViewCryptoExchange type in values)
            {
                //LogManager.AddLogMessage(Name, "InitializeExchangeMenu", "type=" + type.ToString(), LogManager.LogMessageType.DEBUG);
                if (type.ToString() != "none")
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem()
                    {
                        Text = type.ToString(),
                        //Tag = type.GetHashCode(),
                        //Checked = isSelected
                    };
                    toolStripDropDownButton_exchange.DropDownItems.Add(menuItem);
                }
            }
        }
        private void InitializeIcons()
        {
            toolStripButton_addSymbol.Image = ContentManager.GetIcon("Add");
            toolStripButton_addList.Image = ContentManager.GetIcon("Add");
        }
        private void InitializeTimespanMenu()
        {
            var list = EnumUtils.GetAllDescriptions<TradingViewSymbolOverviewInterval>();
            foreach (var item in list)
            {
                LogManager.AddLogMessage(Name, "InitializeTimespanMenu", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                ToolStripMenuItem menuItem = new ToolStripMenuItem()
                {
                    Text = item.Value,
                    Tag = item.Key
                };
                toolStripDropDownButton_timespan.DropDownItems.Add(menuItem);
            }
        }
        private void updateOverviews()
        {
            if (tradingViewManagerControl != null)
            {
                tradingViewManagerControl.UpdateOverviews();
            }
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
                listView_lists.SetObjects(PreferenceManager.TradingViewPreferences.WatchLists);
                //listView_symbols.SetObjects(PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols);
                //groupBox.Text = listView.Items.Count + " Exchanges";

                if (resize)
                {
                    ResizeUI();
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
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                //Font = ParentForm.Font;
                //toolStrip.Font = ParentForm.Font;
                Width = PreferredSize.Width;
                
                //column_Name.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                //Width = column_Name.Width + (listView.RowHeightEffective);
            }
        }
        #endregion

        #region EventHandlers
        private void listView_lists_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_lists.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if (listView_lists.SelectedObject != null)
                    {

                        //CalculatorItem item = listView.SelectedObject as CalculatorItem;
                        TradingViewSymbolList item = listView_lists.SelectedObject as TradingViewSymbolList;
                        ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem menuItem = new ToolStripMenuItem()
                        {
                            Text = "Remove " + item.Name,
                            Tag = item.Name
                        };
                        menuItem.Click += new EventHandler(RemoveListItem_Menu_Click);
                        menu.Items.Add(menuItem);
                        menu.Show(Cursor.Position);

                    }
                }
            }
        }
        private void listView_lists_SelectionChanged(object sender, EventArgs e)
        {
            if (listView_lists.SelectedObject != null)
            {
                TradingViewSymbolList item = listView_lists.SelectedObject as TradingViewSymbolList;
                listView_symbols.SetObjects(item.Items);
            }
        }
        private void listView_symbols_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_symbols.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if (listView_symbols.SelectedObject != null)
                    {

                        //CalculatorItem item = listView.SelectedObject as CalculatorItem;
                        TradingViewSymbolOverview item = listView_symbols.SelectedObject as TradingViewSymbolOverview;
                        ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem menuItem = new ToolStripMenuItem()
                        {
                            Text = "Remove " + item.tabName,
                            Tag = item.tabName
                        };
                        menuItem.Click += new EventHandler(RemoveSymbolItem_Menu_Click);
                        menu.Items.Add(menuItem);
                        menu.Show(Cursor.Position);

                    }
                }
            }
        }
        private void RemoveListItem_Menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            //LogManager.AddLogMessage(Name, "RemoveItem_Menu_Click", "Removing " + menuItem.Text + " From List", LogManager.LogMessageType.DEBUG);          
            //TradingViewSymbolList listItem = PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.FirstOrDefault(item => item.tabName == menuItem.Tag.ToString());
            TradingViewSymbolList listItem = PreferenceManager.TradingViewPreferences.WatchLists.FirstOrDefault(item => item.Name == menuItem.Tag.ToString());

            if (listItem != null)
            {
                //PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.Remove(listItem);
                DialogResult result = MessageBox.Show("Remove " + listItem.Name + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    PreferenceManager.TradingViewPreferences.WatchLists.Remove(listItem);
                    PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
                    listView_symbols.Clear();
                    updateOverviews();
                    UpdateUI();
                } 
            }

        }
        private void RemoveSymbolItem_Menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            if (listView_lists.SelectedObject != null)
            {
                TradingViewSymbolList watchlistItem = listView_lists.SelectedObject as TradingViewSymbolList;
                TradingViewSymbolOverview listItem = watchlistItem.Items.FirstOrDefault(item => item.tabName == menuItem.Tag.ToString());
                if (listItem != null)
                {
                    DialogResult result = MessageBox.Show("Remove " + listItem.tabName + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        //PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.Remove(listItem);
                        watchlistItem.Items.Remove(listItem);
                        PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
                        listView_symbols.SetObjects(watchlistItem.Items);
                        updateOverviews();
                        //UpdateUI();
                        /*
                        PreferenceManager.TradingViewPreferences.WatchLists.Remove(listItem);
                        PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
                        listView_symbols.Clear();
                        updateOverviews();
                        UpdateUI();
                        */
                    }

                    
                }
            }
            //LogManager.AddLogMessage(Name, "RemoveItem_Menu_Click", "Removing " + sender.ToString() + " From List" + " | " + menuItem.Tag.ToString(), LogManager.LogMessageType.DEBUG);          
            //TradingViewSymbolOverview listItem = PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.FirstOrDefault(item => item.tabName == menuItem.Tag.ToString());
            //TradingViewSymbolOverview listItem = PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.FirstOrDefault(item => item.tabName == menuItem.Tag.ToString());
            /*
            if (listItem != null)
            {
                PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.Remove(listItem);
                PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
                updateOverviews();
                UpdateUI();
            }
            */
        }
        private void toolStripButton_addList_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox_listName.Text.Length > 0)
            {
                TradingViewSymbolList listItem = PreferenceManager.TradingViewPreferences.WatchLists.FirstOrDefault(item => item.Name == toolStripTextBox_listName.Text);
                if (listItem == null)
                {
                    TradingViewSymbolList list = new TradingViewSymbolList() { Name = toolStripTextBox_listName.Text };
                    toolStripTextBox_listName.Text = String.Empty;
                    PreferenceManager.TradingViewPreferences.WatchLists.Add(list);
                    PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
                    tradingViewManagerControl.UpdateWatchlists();
                    UpdateUI();
                }
            }
        }
        private void toolStripButton_addSymbol_Click(object sender, EventArgs e)
        {
            //LogManager.AddLogMessage(Name, "toolStripButton_add_Click", sender.ToString(), LogManager.LogMessageType.DEBUG);
            try
            {
                //TradingViewSymbolOverview listItem = PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.FirstOrDefault(item => item.tabName == toolStripTextBox_tabName.Text);
                if (listView_lists.SelectedObject != null)
                {
                    TradingViewSymbolList symbolList = listView_lists.SelectedObject as TradingViewSymbolList;
                    TradingViewSymbolOverview listItem = symbolList.Items.FirstOrDefault(item => item.tabName == toolStripTextBox_tabName.Text);

                    if (listItem != null)
                    {
                        MessageBox.Show("Already a Tab with this name.", "Duplicate");
                    }
                    else
                    {
                        TradingViewSymbolOverview item = new TradingViewSymbolOverview()
                        {
                            symbol = toolStripTextBox_symbol.Text.ToUpper(),
                            market = toolStripTextBox_market.Text.ToUpper(),
                            exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), toolStripDropDownButton_exchange.Text, true),
                            interval = (TradingViewSymbolOverviewInterval)Enum.Parse(typeof(TradingViewSymbolOverviewInterval), toolStripDropDownButton_timespan.Text, true),
                            tabName = toolStripTextBox_tabName.Text
                        };
                        //LogManager.AddLogMessage(Name, "toolStripButton_add_Click", item.symbol + " | " + item.market + " | " + item.exchange + " | " + item.interval + " | " + item.tabName);
                        //PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.Add(item);
                        symbolList.Items.Add(item);
                        
                        updateOverviews();
                        listView_symbols.SetObjects(symbolList.Items);
                        //UpdateUI();
                        PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
                    }
                }      
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "toolStripButton_add_Click", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
        }
        private void toolStripDropDownButton_exchange_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_exchange.Text = e.ClickedItem.Text;
        }
        private void toolStripDropDownButton_timespan_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_timespan.Text = e.ClickedItem.Tag.ToString();
        }
        #endregion
    }
}
