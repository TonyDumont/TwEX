using System;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.ExchangeManager;
using static TwEX_API.PreferenceManager;

namespace TwEX_API.Controls
{
    public partial class ArbitrageWatchListEditorControl : UserControl
    {
        #region Properties
        //public ArbitrageWatchListEditorControl arbitrageWatchListControl;
        public ArbitrageManagerControl arbitrageManagerControl;
        #endregion

        #region Initialize
        public ArbitrageWatchListEditorControl()
        {
            InitializeComponent();
            InitializeIcons();
        }
        private void ArbitrageWatchListEditorControl_Load(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = (int)(splitContainer.ClientSize.Height * 0.70);
            UpdateUI(true);
        }
        private void InitializeIcons()
        {
            toolStripButton_addSymbol.Image = ContentManager.GetIcon("Add");
            toolStripButton_addList.Image = ContentManager.GetIcon("Add");
        }
        private void updateOverviews()
        {
            if (arbitrageManagerControl != null)
            {
                //tradingViewManagerControl.UpdateOverviews();
                arbitrageManagerControl.UpdateOverviews();
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
                listView_lists.SetObjects(ArbitragePreferences.WatchLists);

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
                Width = PreferredSize.Width;
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
                        ArbitrageWatchList item = listView_lists.SelectedObject as ArbitrageWatchList;
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
                ArbitrageWatchList item = listView_lists.SelectedObject as ArbitrageWatchList;
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
                        ExchangeTicker item = listView_symbols.SelectedObject as ExchangeTicker;
                        ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem menuItem = new ToolStripMenuItem()
                        {
                            Text = "Remove " + item.symbol + "/" + item.market,
                            Tag = item.symbol + "_" + item.market
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
            ArbitrageWatchList listItem = ArbitragePreferences.WatchLists.FirstOrDefault(item => item.Name == menuItem.Tag.ToString());

            if (listItem != null)
            {
                //PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.Remove(listItem);
                DialogResult result = MessageBox.Show("Remove " + listItem.Name + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ArbitragePreferences.WatchLists.Remove(listItem);
                    UpdatePreferenceFile(PreferenceType.Arbitrage);
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
                ArbitrageWatchList watchlistItem = listView_lists.SelectedObject as ArbitrageWatchList;
                string[] pairs = menuItem.Tag.ToString().Split('_');
                ExchangeTicker listItem = watchlistItem.Items.FirstOrDefault(item => item.symbol == pairs[0] && item.market == pairs[1]);
                if (listItem != null)
                {
                    DialogResult result = MessageBox.Show("Remove " + menuItem.Tag.ToString() + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        //PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.Remove(listItem);
                        watchlistItem.Items.Remove(listItem);
                        UpdatePreferenceFile(PreferenceType.Arbitrage);
                        listView_symbols.SetObjects(watchlistItem.Items);
                        

                        updateOverviews();
                        //UpdateUI();
                    }


                }
            }
            //LogManager.AddLogMessage(Name, "RemoveItem_Menu_Click", "Removing " + sender.ToString() + " From List" + " | " + menuItem.Tag.ToString(), LogManager.LogMessageType.DEBUG);          
        }
        private void toolStripButton_addList_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox_listName.Text.Length > 0)
            {
                ArbitrageWatchList listItem = ArbitragePreferences.WatchLists.FirstOrDefault(item => item.Name == toolStripTextBox_listName.Text);
                if (listItem == null)
                {
                    ArbitrageWatchList list = new ArbitrageWatchList() { Name = toolStripTextBox_listName.Text };
                    toolStripTextBox_listName.Text = String.Empty;
                    ArbitragePreferences.WatchLists.Add(list);
                    UpdatePreferenceFile(PreferenceType.Arbitrage);
                    //tradingViewManagerControl.UpdateWatchlists(); --> CHANGE TO ARBITRAGE
                    arbitrageManagerControl.UpdateWatchlists();
                    //arbitrageManagerControl.UpdateWatchlists();
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
                    ArbitrageWatchList symbolList = listView_lists.SelectedObject as ArbitrageWatchList;

                    ExchangeTicker listItem = symbolList.Items.FirstOrDefault(item => item.symbol == toolStripTextBox_symbol.Text.ToUpper() && item.market == toolStripTextBox_market.Text.ToUpper());

                    if (listItem != null)
                    {
                        MessageBox.Show("Already an Item with this name.", "Duplicate");
                    }
                    else
                    {
                        ExchangeTicker item = new ExchangeTicker()
                        {
                            symbol = toolStripTextBox_symbol.Text.ToUpper(),
                            market = toolStripTextBox_market.Text.ToUpper(),
                            //exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), toolStripDropDownButton_exchange.Text, true),
                            //interval = (TradingViewSymbolOverviewInterval)Enum.Parse(typeof(TradingViewSymbolOverviewInterval), toolStripDropDownButton_timespan.Text, true),
                            //tabName = toolStripTextBox_tabName.Text
                        };
                        //LogManager.AddLogMessage(Name, "toolStripButton_add_Click", item.symbol + " | " + item.market + " | " + item.exchange + " | " + item.interval + " | " + item.tabName);
                        //PreferenceManager.TradingViewPreferences.SymbolOverviewParameters.symbols.Add(item);
                        symbolList.Items.Add(item);

                        updateOverviews();
                        listView_symbols.SetObjects(symbolList.Items);
                        //UpdateUI();
                        UpdatePreferenceFile(PreferenceType.Arbitrage);
                        ParentForm.Focus();
                        //Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "toolStripButton_add_Click", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }
        }
        /*
        private void toolStripDropDownButton_exchange_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_exchange.Text = e.ClickedItem.Text;
        }
        private void toolStripDropDownButton_timespan_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_timespan.Text = e.ClickedItem.Tag.ToString();
        }
        */
        #endregion

    }
}