using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using static TwEX_API.ExchangeManager;
using static TwEX_API.Market.TradingView;

namespace TwEX_API.Controls
{
    public partial class TradingViewManagerControl : UserControl
    {
        #region Properties
        public static List<ExchangeManager.Exchange> exchanges = new List<ExchangeManager.Exchange>();
        #endregion

        #region Initialize
        public TradingViewManagerControl()
        {
            InitializeComponent();
            FormManager.tradingViewManagerControl = this;
        }
        private void TradingViewManagerControl_Load(object sender, EventArgs e)
        {
            toolStripTextBox_symbol.Text = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.symbol;
            toolStripTextBox_market.Text = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.market;
            toolStripDropDownButton_options.Image = ContentManager.GetIcon("Options");
            toolStripDropDownButton_style.Text = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.style.ToString();



            toolStripRadioButton_full.Image = ContentManager.GetSymbolIcon(PreferenceManager.TradingViewPreferences.AdvancedChartParameters.symbol);
            toolStripRadioButton_btc.Image = ContentManager.GetSymbolIcon("BTC");
            toolStripRadioButton_usd.Image = ContentManager.GetIcon("USDSymbol");
            toolStripRadioButton_custom.Image = ContentManager.GetIcon("CustomView");

            UpdateStyleMenu();
            UpdateExchangeMenus();
            UpdateOptionsMenu();

            SetFullView();
            SetCustomView();
            UpdateUI(true);
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
                //listView.SetObjects(ExchangeManager.Exchanges);
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
            if (this.InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {
                ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                //Font = ParentForm.Font;
                toolStrip.Font = ParentForm.Font;

                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item.GetType() != typeof(ToolStripSeparator))
                    {
                        //ToolStripButton button = item as ToolStripButton;
                        //button.Checked = LogManager.getMessageTypeActive(button.Text);
                        item.Font = ParentForm.Font;
                    }
                }
                //column_Name.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                //Width = column_Name.Width + (listView.RowHeightEffective);
            }
        }
        #endregion

        #region Updaters
        private void UpdateOptionsMenu()
        {
            // BOOLEANS
            foreach (var item in toolStripDropDownButton_options.DropDownItems)
            {
                if (item.GetType().Equals(typeof(ToolStripMenuItem)))
                {
                    ToolStripMenuItem menuItem = item as ToolStripMenuItem;

                    if (menuItem.Tag.ToString() != "theme" && menuItem.Tag.ToString() != "style")
                    {
                        PropertyInfo pi = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.GetType().GetProperty(menuItem.Tag.ToString());
                        menuItem.Checked = (bool)(pi.GetValue(PreferenceManager.TradingViewPreferences.AdvancedChartParameters, null));
                    }
                    //LogManager.AddLogMessage(Name, "UpdateOptionsMenu", menuItem.Text + " | " + menuItem.Tag, LogManager.LogMessageType.DEBUG);
                }
            }
            // THEME
            if (PreferenceManager.TradingViewPreferences.AdvancedChartParameters.theme == TradingViewColorTheme.Light)
            {
                toolStripMenuItem_light.Checked = true;
                toolStripMenuItem_dark.Checked = false;
            }
            else
            {
                toolStripMenuItem_light.Checked = false;
                toolStripMenuItem_dark.Checked = true;
            }
            // STYLE
            foreach (ToolStripMenuItem item in toolStripMenuItem_BarStyle.DropDownItems)
            {
                if (item.Tag.ToString() == PreferenceManager.TradingViewPreferences.AdvancedChartParameters.style.ToString())
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }
        private void UpdateExchangeMenus()
        {
            toolStripDropDownButton_exchange.DropDownItems.Clear();
            exchanges = Exchanges.Where(item => item.TradingView.Length > 0).ToList();

            foreach (ExchangeManager.Exchange exchange in exchanges)
            {
                var newItem = new ToolStripButton(exchange.Name)
                {
                    Image = ContentManager.GetExchangeIcon(exchange.Name),
                    Text = exchange.TradingView
                };
                toolStripDropDownButton_exchange.DropDownItems.Add(newItem);
            }
            SetExchangeMenu();
        }
        private void UpdateStyleMenu()
        {
            var values = EnumUtils.GetValues<TradingViewChartStyle>();
            toolStripDropDownButton_style.DropDownItems.Clear();

            foreach (TradingViewChartStyle type in values)
            {
                bool isSelected = (type == PreferenceManager.TradingViewPreferences.AdvancedChartParameters.style);
                // TOOLSTRIP DROPDOWN
                ToolStripMenuItem menuItem = new ToolStripMenuItem()
                {
                    Text = type.ToString(),
                    Tag = type.GetHashCode(),
                    Checked = isSelected
                };
                toolStripDropDownButton_style.DropDownItems.Add(menuItem);

                // OPTIONS MENU
                ToolStripMenuItem barItem = new ToolStripMenuItem()
                {
                    Text = type.ToString(),
                    Tag = type.GetHashCode(),
                    Checked = isSelected
                };
                toolStripMenuItem_BarStyle.DropDownItems.Add(barItem);

            }
        }
        #endregion

        #region Setters
        private void SetCustomView()
        {
            tabPage_custom.Controls.Clear();
            /*
            TableLayoutPanel table = new TableLayoutPanel() { Dock = DockStyle.Fill };

            int columnCount = GetTableCount("column", PreferenceManager.TradingViewPreferences.WatchList.Count);
            int rowCount = GetTableCount("row", PreferenceManager.TradingViewPreferences.WatchList.Count);

            table.ColumnCount = columnCount;
            table.RowCount = rowCount;

            for (int i = 0; i < columnCount + 1; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            }

            for (int i = 0; i < rowCount + 1; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            }

            int currentColumn = 0;
            int currentRow = 0;

            foreach (ExchangeTicker item in PreferenceManager.TradingViewPreferences.WatchList)
            {
                TradingViewWidgetControl chartWidget = new TradingViewWidgetControl();
                TradingViewAdvancedChartParameters parameters = new TradingView.TradingViewAdvancedChartParameters()
                {
                    symbol = item.symbol,
                    market = item.market,
                    exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), item.exchange, true),
                    hide_top_toolbar = true
                };
                chartWidget.setAdvancedChart(parameters);
                table.Controls.Add(chartWidget, currentColumn, currentRow);

                if (currentColumn < columnCount)
                {
                    currentColumn++;
                }
                else
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }
            tabPage_custom.Controls.Add(table);
            */
        }
        private void SetExchangeMenu()
        {
            foreach (ToolStripButton item in toolStripDropDownButton_exchange.DropDownItems)
            {
                //LogManager.AddDebugMessage(this.Name, "SetExchangeMenu", item.Text + " | " + exchange);
                if (item.Text.ToUpper() == PreferenceManager.TradingViewPreferences.AdvancedChartParameters.exchange.ToString().ToUpper())
                {
                    toolStripDropDownButton_exchange.Image = item.Image;
                    toolStripDropDownButton_exchange.Text = item.Text;

                    if (PreferenceManager.TradingViewPreferences.AdvancedChartParameters.market.Contains("USD"))
                    {
                        ExchangeManager.Exchange listItem = exchanges.FirstOrDefault(i => i.TradingView == PreferenceManager.TradingViewPreferences.AdvancedChartParameters.exchange.ToString().ToUpper());

                        if (listItem != null)
                        {
                            PreferenceManager.TradingViewPreferences.AdvancedChartParameters.market = listItem.USDSymbol;
                            toolStripTextBox_market.Text = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.market;
                        }
                    }
                }
            }
            //UpdateUI();
        }
        private void SetFullView()
        {
            tabPage_full.Controls.Clear();
            TradingViewWidgetControl widget = new TradingViewWidgetControl()
            {
                Dock = DockStyle.Fill
            };
            toolStripRadioButton_full.Image = ContentManager.GetSymbolIcon(PreferenceManager.TradingViewPreferences.AdvancedChartParameters.symbol);
            toolStripRadioButton_full.Text = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.symbol.ToUpper();
            PreferenceManager.TradingViewPreferences.AdvancedChartParameters.WatchList = GetWatchListBySymbol(PreferenceManager.TradingViewPreferences.AdvancedChartParameters.symbol);
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
            widget.setAdvancedChart(PreferenceManager.TradingViewPreferences.AdvancedChartParameters);
            tabPage_full.Controls.Add(widget);
            SetBTCView();
            SetUSDView();
        }
        private void SetBTCView()
        {
            tabPage_btc.Controls.Clear();

            if (PreferenceManager.TradingViewPreferences.AdvancedChartParameters.symbol == "BTC")
            {
                //tabPage_btc.CanSelect = false;
            }

            TableLayoutPanel btcTable = new TableLayoutPanel()
            {
                Name = "btcTable",
                Dock = DockStyle.Fill
            };

            int columnCount = GetTableCount("column", exchanges.Count);
            int rowCount = GetTableCount("row", exchanges.Count);

            btcTable.ColumnCount = columnCount;
            btcTable.RowCount = rowCount;

            for (int i = 0; i < columnCount + 1; i++)
            {
                btcTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            }

            for (int i = 0; i < rowCount + 1; i++)
            {
                btcTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            }

            int currentColumn = 0;
            int currentRow = 0;

            foreach (ExchangeManager.Exchange exchange in exchanges)
            {
                // make a widget
                TradingViewWidgetControl chartWidget = new TradingViewWidgetControl()
                {
                    Dock = DockStyle.Fill
                };

                TradingViewAdvancedChartParameters parameters = new TradingViewAdvancedChartParameters()
                {
                    symbol = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.symbol,
                    market = "BTC",
                    exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), exchange.TradingView, true),
                    hide_top_toolbar = true,
                    theme = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.theme
                };
                chartWidget.setAdvancedChart(parameters);
                //chartWidget.SetPair(exchange.Symbol, symbol, "BTC");

                btcTable.Controls.Add(chartWidget, currentColumn, currentRow);

                if (currentColumn < columnCount)
                {
                    // increment column
                    currentColumn++;
                }
                else
                {
                    // reset column increment row
                    currentColumn = 0;
                    currentRow++;
                }

            }
            tabPage_btc.Controls.Add(btcTable);
        }
        private void SetUSDView()
        {
            // USD
            tabPage_usd.Controls.Clear();

            TableLayoutPanel table = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill
            };

            int columnCount = GetTableCount("column", exchanges.Count);
            int rowCount = GetTableCount("row", exchanges.Count);

            table.ColumnCount = columnCount;
            table.RowCount = rowCount;

            for (int i = 0; i < columnCount + 1; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            }

            for (int i = 0; i < rowCount + 1; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            }

            int currentColumn = 0;
            int currentRow = 0;

            foreach (ExchangeManager.Exchange exchange in exchanges)
            {
                // make a widget
                TradingViewWidgetControl chartWidget = new TradingViewWidgetControl()
                {
                    Dock = DockStyle.Fill
                };

                TradingViewAdvancedChartParameters parameters = new TradingViewAdvancedChartParameters()
                {
                    symbol = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.symbol,
                    market = exchange.USDSymbol,
                    exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), exchange.TradingView, true),
                    hide_top_toolbar = true,
                    theme = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.theme
                };
                chartWidget.setAdvancedChart(parameters);
                //chartWidget.SetPair(exchange.Symbol, symbol, exchange.USDSymbol);

                table.Controls.Add(chartWidget, currentColumn, currentRow);

                if (currentColumn < columnCount)
                {
                    // increment column
                    currentColumn++;
                }
                else
                {
                    // reset column increment row
                    currentColumn = 0;
                    currentRow++;
                }
            }
            tabPage_usd.Controls.Add(table);
        }
        #endregion

        #region Getters
        private int GetTableCount(string target, int listCount)
        {

            int columnCount = 0;
            int rowCount = 0;

            switch (listCount)
            {
                case 1:
                case 2:
                    //LogManager.AddDebugMessage(thisClassName, "UpdateExchangeData", "exchange : " + siteName);
                    columnCount = 2;
                    rowCount = 1;
                    break;

                case 3:
                case 4:
                    //LogManager.AddDebugMessage(thisClassName, "UpdateExchangeData", "exchange : " + siteName);
                    columnCount = 2;
                    rowCount = 2;
                    break;

                case 5:
                case 6:
                    //LogManager.AddDebugMessage(thisClassName, "UpdateExchangeData", "exchange : " + siteName);
                    columnCount = 3;
                    rowCount = 2;
                    break;

                case 7:
                case 8:
                    //LogManager.AddDebugMessage(thisClassName, "UpdateExchangeData", "exchange : " + siteName);
                    columnCount = 4;
                    rowCount = 2;
                    break;

                case 9:
                case 10:
                    //LogManager.AddDebugMessage(thisClassName, "UpdateExchangeData", "exchange : " + siteName);
                    columnCount = 5;
                    rowCount = 2;
                    break;

                default:
                    //LogManager.AddDebugMessage(thisClassName, "UpdateExchangeData", "DEFAULT : NO EXCHANGE DEFINED : exchange=" + siteName);
                    break;
            }

            if (target == "row")
            {
                return rowCount;
            }
            else
            {
                return columnCount;
            }

        }
        #endregion
        
        #region EventHandler
        private void toolStripDropDownButton_exchange_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_exchange.Image = e.ClickedItem.Image;
            toolStripDropDownButton_exchange.Text = e.ClickedItem.Text.ToUpper();

            PreferenceManager.TradingViewPreferences.AdvancedChartParameters.exchange = (TradingViewCryptoExchange)System.Enum.Parse(typeof(TradingViewCryptoExchange), e.ClickedItem.Text, true);
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
            SetFullView();
        }
        private void toolStripButton_refresh_Click(object sender, EventArgs e)
        {
            PreferenceManager.TradingViewPreferences.AdvancedChartParameters.symbol = toolStripTextBox_symbol.Text.ToUpper();
            PreferenceManager.TradingViewPreferences.AdvancedChartParameters.market = toolStripTextBox_market.Text.ToUpper();
            if (PreferenceManager.TradingViewPreferences.AdvancedChartParameters.market.Contains("USD"))
            {
                ExchangeManager.Exchange listItem = exchanges.FirstOrDefault(i => i.TradingView == PreferenceManager.TradingViewPreferences.AdvancedChartParameters.exchange.ToString());

                if (listItem != null)
                {
                    PreferenceManager.TradingViewPreferences.AdvancedChartParameters.market = listItem.USDSymbol;
                }
            }
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
            SetFullView();
        }
        private void toolStripDropDownButton_options_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "toolStripDropDownButton_options_DropDownItemClicked", e.ClickedItem.Text + " | " + e.ClickedItem.Tag, LogManager.LogMessageType.OTHER);
            string propertyName = e.ClickedItem.Tag.ToString();

            switch (propertyName)
            {
                case "hide_top_toolbar":
                case "withdateranges":
                case "allow_symbol_change":
                case "save_image":
                case "hide_side_toolbar":
                case "hideideas":
                case "hideideasbutton":
                case "enable_publishing":
                case "ShowWatchlist":
                case "ShowIndicators":
                case "details":
                case "stocktwits":
                case "headlines":
                case "hotlist":
                case "calendar":
                {
                    Type type = PreferenceManager.TradingViewPreferences.AdvancedChartParameters.GetType();
                    PropertyInfo prop = type.GetProperty(propertyName);
                    bool value = (bool)(prop.GetValue(PreferenceManager.TradingViewPreferences.AdvancedChartParameters, null));
                    prop.SetValue(PreferenceManager.TradingViewPreferences.AdvancedChartParameters, !value, null);
                    //LogManager.AddLogMessage(Name, "toolStripDropDownButton_options_DropDownItemClicked", "SWITCH : " + propertyName + " : " + value, LogManager.LogMessageType.OTHER);
                    UpdateOptionsMenu();
                    PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
                    SetFullView();
                    break;
                }

                case "light":
                case "dark":
                {
                        //LogManager.AddLogMessage(Name, "toolStripDropDownButton_options_DropDownItemClicked", "LIGHT OR DARK : " + propertyName, LogManager.LogMessageType.OTHER);

                        if (propertyName == "light")
                        {
                            PreferenceManager.TradingViewPreferences.AdvancedChartParameters.theme = TradingViewColorTheme.Light;
                        }
                        else
                        {
                            PreferenceManager.TradingViewPreferences.AdvancedChartParameters.theme = TradingViewColorTheme.Dark;
                        }
                        UpdateOptionsMenu();
                        PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
                        SetFullView();
                        SetCustomView();
                        UpdateUI(true);
                        break;
                }
                
                default:
                    {
                        LogManager.AddLogMessage(Name, "toolStripDropDownButton_options_DropDownItemClicked", "NOTDEFINED : " + propertyName, LogManager.LogMessageType.OTHER);
                        break;
                    }

            }
        }
        private void toolStripDropDownButton_style_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "toolStripDropDownButton_style_DropDownItemClicked", e.ClickedItem.Text + " | " + e.ClickedItem.Tag, LogManager.LogMessageType.DEBUG);
            toolStripDropDownButton_style.Text = e.ClickedItem.Text;
            UpdateOptionsMenu();
            /*
            foreach(ToolStripMenuItem item in toolStripMenuItem_BarStyle.DropDownItems)
            {
                if (item.Text == e.ClickedItem.Text)
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
            */
            PreferenceManager.TradingViewPreferences.AdvancedChartParameters.style = (TradingViewChartStyle)Enum.Parse(typeof(TradingViewChartStyle), e.ClickedItem.Text);
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.TradingView);
            SetFullView();
        }
        private void toolStripRadioButton_Click(object sender, EventArgs e)
        {
            ToolStripRadioButton button = sender as ToolStripRadioButton;
            int index = Convert.ToInt16(button.Tag);
            //LogManager.AddLogMessage(Name, "toolStripRadioButton_Click", sender.ToString() + " | " + index, LogManager.LogMessageType.DEBUG);
            tabControl.SelectedIndex = index;

        }
        #endregion
    }
}


//widget.Name = "tv_full";
/*
TradingViewAdvancedChartParameters parameters = new TradingViewAdvancedChartParameters()
{
    symbol = PreferenceManager.TradingViewPreferences. .symbol,
    market = PreferenceManager.preferences.TradingViewPreferences.market,
    exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), PreferenceManager.preferences.TradingViewPreferences.exchange, true),
    withdateranges = true,
    hide_side_toolbar = true,
    ShowWatchlist = true,
    details = true,
    WatchList = TradingView.GetWatchListBySymbol(PreferenceManager.preferences.TradingViewPreferences.symbol),
    stocktwits = true,
    headlines = true,
    calendar = true,
    hide_top_toolbar = true,
    hotlist = true
    //ShowIndicators = true
};

widget.setAdvancedChart(parameters);
*/
//PreferenceManager.TradingViewPreferences.parameters.WatchList = TradingView.GetWatchListBySymbol(PreferenceManager.preferences.TradingViewPreferences.symbol),