using BrightIdeasSoftware;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TwEX_API.Market;

namespace TwEX_API.Controls
{
    public partial class CryptoCompareControl : UserControl
    {
        #region Properties
        CryptoCompareWidgetControl widget = new CryptoCompareWidgetControl() { Dock = DockStyle.Fill };
        CryptoCompare.CryptoCompareFeedType feedType = CryptoCompare.CryptoCompareFeedType.CoinTelegraph;
        #endregion

        #region Initialize
        public CryptoCompareControl()
        {
            InitializeComponent();
            FormManager.cryptoCompareControl = this;
            InitializeColumns();
        }
        private void CryptoCompareControl_Load(object sender, EventArgs e)
        {

            LogManager.AddLogMessage(Name, "CryptoCompareControl_Load", "LOADED : " + PreferenceManager.CryptoComparePreferences.Symbol + " | " + PreferenceManager.CryptoComparePreferences.WidgetType, LogManager.LogMessageType.OTHER);
            toolStripDropDownButton_widget.Text = PreferenceManager.CryptoComparePreferences.WidgetType.ToString();
            //PreferenceManager.CryptoComparePreferences.WidgetType = (CryptoCompare.CryptoCompareWidgetType)Enum.Parse(typeof(CryptoCompare.CryptoCompareWidgetType), widgetName);
            //widget.widgetType = PreferenceManager.CryptoComparePreferences.WidgetType;
            //widget.widgetType = CryptoCompare.CryptoCompareWidgetType.ChartAdvanced;

            toolStripTextBox_symbol.Text = PreferenceManager.CryptoComparePreferences.Symbol;
            toolStripTextBox_market.Text = "USD";
            //setWidget();
            //setWidget();
            //widget.setAdvancedChart(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
            panel.Controls.Add(widget);
            //widget.setAdvancedChart(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
            UpdateUI(true);
        }

        private void InitializeColumns()
        {
            column_FullyPremined.AspectGetter = new AspectGetterDelegate(aspect_FullyPremined);         
            column_TotalCoinSupply.AspectGetter = new AspectGetterDelegate(aspect_TotalCoinSupply);
            column_Name.ImageGetter = new ImageGetterDelegate(aspect_Icon);
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
                listView.SetObjects(PreferenceManager.CryptoComparePreferences.CoinList.OrderBy(item => item.SortOrder));
                setWidget();

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
                this.Invoke(d, new object[] { });
            }
            else
            {
                ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                listView.Font = ParentForm.Font;
                Size textSize = TextRenderer.MeasureText("O", ParentForm.Font);
                
                int listWidth = 0;
                
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    listWidth += col.Width;
                }

                column_Name.Width = column_Name.Width + listView.RowHeightEffective;
                listWidth += listView.RowHeightEffective;
                //splitContainer.Panel1MinSize = formWidth;
                tableLayoutPanel.ColumnStyles[0].Width = listWidth + (textSize.Width * 2);
                setWidget();
            }
        }
        #endregion

        #region Getters
        private string getFirstSymbol(string textString)
        {
            if (textString.Contains(","))
            {
                string[] symbols = textString.Split(',');
                return symbols[0];
            }
            else
            {
                return textString;
            }
        }
        public object aspect_FullyPremined(object rowObject)
        {
            CryptoCompare.CryptoCompareCoin coin = (CryptoCompare.CryptoCompareCoin)rowObject;

            if (coin.FullyPremined != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object aspect_TotalCoinSupply(object rowObject)
        {
            CryptoCompare.CryptoCompareCoin coin = (CryptoCompare.CryptoCompareCoin)rowObject;

            var isNumeric = int.TryParse(coin.TotalCoinSupply, out int n);
            if (isNumeric)
            {
                return Convert.ToInt64(coin.TotalCoinSupply).ToString("n");
            }
            else
            {
                return coin.TotalCoinSupply;
            }
        }
        private object aspect_Icon(object rowObject)
        {
            CryptoCompare.CryptoCompareCoin coin = (CryptoCompare.CryptoCompareCoin)rowObject;
            int rowheight = listView.RowHeightEffective;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(coin.Symbol), rowheight, rowheight);
            //return ContentManager.GetWalletIcon(balance.WalletName);
        }
        #endregion

        private void setWidget()
        {
            //LogManager.AddLogMessage(Name, "setWidget", toolStripTextBox_symbol.Text + " | " + toolStripTextBox_market.Text + " | " + PreferenceManager.CryptoComparePreferences.WidgetType, LogManager.LogMessageType.OTHER);
            switch (PreferenceManager.CryptoComparePreferences.WidgetType)
            {
                case CryptoCompare.CryptoCompareWidgetType.Chart:
                    widget.setChart(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text, PreferenceManager.CryptoComparePreferences.PeriodType);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.NewsFeed:
                    widget.setNewsFeed(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text, feedType);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.PricesList:
                    widget.setPricesList(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.PricesTiles:
                    widget.setPricesTiles(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Tabbed:
                    widget.setTabbed(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Horizontal:
                    widget.setHorizontal(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Summary:
                    widget.setSummary(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Historical:
                    widget.setHistorical(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.ChartAdvanced:
                    LogManager.AddLogMessage(Name, "setWidget", toolStripTextBox_symbol.Text + " | " + toolStripTextBox_market.Text + " | " + PreferenceManager.CryptoComparePreferences.WidgetType, LogManager.LogMessageType.OTHER);
                    widget.setAdvancedChart(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Converter:
                    widget.setConverter(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.HeaderV2:
                    // Header V2 - SYMBOLS , MARKETS
                    //LogManager.AddLogMessage(Name, "updateUI", widgetType.ToString(), LogManager.LogMessageType.DEBUG);
                    widget.setHeaderV2(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.HeaderV3:
                    // Header V3 - SYMBOLS , MARKETS
                    LogManager.AddLogMessage(Name, "updateUI", PreferenceManager.CryptoComparePreferences.WidgetType.ToString(), LogManager.LogMessageType.DEBUG);
                    widget.setHeaderV3(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                default:
                    LogManager.AddLogMessage(Name, "updateUI", "type NOT DEFINED : " + PreferenceManager.CryptoComparePreferences.WidgetType, LogManager.LogMessageType.DEBUG);
                    break;
            }
            //widget.updateBrowser();
            //widget.Refresh();
            //Refresh();
        }
        /*
        #region Updaters
        private void updateUI()
        {
            listView.SetObjects(PreferenceManager.CryptoComparePreferences.CoinList);

            switch (PreferenceManager.CryptoComparePreferences.WidgetType)
            {
                case CryptoCompare.CryptoCompareWidgetType.Chart:
                    widget.setChart(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text, PreferenceManager.CryptoComparePreferences.PeriodType);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.NewsFeed:
                    widget.setNewsFeed(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text, feedType);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.PricesList:
                    widget.setPricesList(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.PricesTiles:
                    widget.setPricesTiles(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Tabbed:
                    widget.setTabbed(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Horizontal:
                    widget.setHorizontal(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Summary:
                    widget.setSummary(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Historical:
                    widget.setHistorical(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.ChartAdvanced:
                    widget.setAdvancedChart(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Converter:
                    widget.setConverter(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.HeaderV2:
                    // Header V2 - SYMBOLS , MARKETS
                    //LogManager.AddLogMessage(Name, "updateUI", widgetType.ToString(), LogManager.LogMessageType.DEBUG);
                    widget.setHeaderV2(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                case CryptoCompare.CryptoCompareWidgetType.HeaderV3:
                    // Header V3 - SYMBOLS , MARKETS
                    LogManager.AddLogMessage(Name, "updateUI", PreferenceManager.CryptoComparePreferences.WidgetType.ToString(), LogManager.LogMessageType.DEBUG);
                    widget.setHeaderV3(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                default:
                    LogManager.AddLogMessage(Name, "updateUI", "type NOT DEFINED : " + PreferenceManager.CryptoComparePreferences.WidgetType, LogManager.LogMessageType.DEBUG);
                    break;
            }
        }
        #endregion
        */
        #region EventHandlers
        private void toolStripDropDownButton_period_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_period.Text = e.ClickedItem.Text;
            CryptoCompare.CryptoCompareChartPeriod type = (CryptoCompare.CryptoCompareChartPeriod)Enum.Parse(typeof(CryptoCompare.CryptoCompareChartPeriod), e.ClickedItem.Tag.ToString());
            PreferenceManager.CryptoComparePreferences.PeriodType = type;
            UpdateUI();
        }
        private void toolStripDropDownButton_FeedSource_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_FeedSource.Text = e.ClickedItem.Tag.ToString();
            CryptoCompare.CryptoCompareFeedType type = (CryptoCompare.CryptoCompareFeedType)Enum.Parse(typeof(CryptoCompare.CryptoCompareFeedType), e.ClickedItem.Text);
            feedType = type;
            UpdateUI();
        }
        private void toolStripDropDownButton_widget_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string widgetName = e.ClickedItem.Tag.ToString();
            toolStripDropDownButton_widget.Text = widgetName;
            PreferenceManager.CryptoComparePreferences.WidgetType = (CryptoCompare.CryptoCompareWidgetType) Enum.Parse(typeof(CryptoCompare.CryptoCompareWidgetType), widgetName);

            switch (PreferenceManager.CryptoComparePreferences.WidgetType)
            {
                case CryptoCompare.CryptoCompareWidgetType.Chart:
                    // SYMBOL , MARKET , PERIOD 
                    toolStripLabel_symbol.Text = "Symbol:";
                    toolStripLabel_market.Text = "Market:";

                    toolStripTextBox_symbol.Text = getFirstSymbol(toolStripTextBox_symbol.Text);
                    toolStripTextBox_market.Text = getFirstSymbol(toolStripTextBox_market.Text);

                    toolStripDropDownButton_period.Enabled = true;
                    toolStripDropDownButton_FeedSource.Enabled = false;
                    break;

                case CryptoCompare.CryptoCompareWidgetType.NewsFeed:
                    // SYMBOL , MARKET , FEEDTYPE
                    toolStripLabel_symbol.Text = "Symbol:";
                    toolStripLabel_market.Text = "Market:";

                    toolStripTextBox_symbol.Text = getFirstSymbol(toolStripTextBox_symbol.Text);
                    toolStripTextBox_market.Text = getFirstSymbol(toolStripTextBox_market.Text);

                    toolStripDropDownButton_period.Enabled = false;
                    toolStripDropDownButton_FeedSource.Enabled = true;
                    break;

                case CryptoCompare.CryptoCompareWidgetType.PricesList:
                case CryptoCompare.CryptoCompareWidgetType.PricesTiles:
                case CryptoCompare.CryptoCompareWidgetType.Summary:
                case CryptoCompare.CryptoCompareWidgetType.Converter:
                    // Price List - SYMBOL , MARKETS (25)
                    toolStripLabel_symbol.Text = "Symbol:";
                    toolStripLabel_market.Text = "Markets(25):";

                    toolStripTextBox_symbol.Text = getFirstSymbol(toolStripTextBox_symbol.Text);

                    toolStripDropDownButton_period.Enabled = false;
                    toolStripDropDownButton_FeedSource.Enabled = false;
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Tabbed:
                    // Tabbed - SYMBOLS (5) , MARKETS (5)
                    toolStripLabel_symbol.Text = "Symbols(5):";
                    toolStripLabel_market.Text = "Markets(5):";

                    toolStripDropDownButton_period.Enabled = false;
                    toolStripDropDownButton_FeedSource.Enabled = false;
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Horizontal:
                    // Horizontal - SYMBOL , MARKETS (4 - 1/2 - 3/4)
                    toolStripLabel_symbol.Text = "Symbol:";
                    toolStripLabel_market.Text = "Markets(4):";

                    toolStripTextBox_symbol.Text = getFirstSymbol(toolStripTextBox_symbol.Text);

                    toolStripDropDownButton_period.Enabled = false;
                    toolStripDropDownButton_FeedSource.Enabled = false;
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Historical:
                case CryptoCompare.CryptoCompareWidgetType.ChartAdvanced:
                    // Historical - SYMBOL , MARKET
                    toolStripLabel_symbol.Text = "Symbol:";
                    toolStripLabel_market.Text = "Market:";

                    toolStripTextBox_symbol.Text = getFirstSymbol(toolStripTextBox_symbol.Text);
                    toolStripTextBox_market.Text = getFirstSymbol(toolStripTextBox_market.Text);

                    toolStripDropDownButton_period.Enabled = false;
                    toolStripDropDownButton_FeedSource.Enabled = false;
                    break;

                case CryptoCompare.CryptoCompareWidgetType.HeaderV2:
                case CryptoCompare.CryptoCompareWidgetType.HeaderV3:
                    // Header V2 - SYMBOLS(5) , MARKETS(25)
                    toolStripLabel_symbol.Text = "Symbols(5):";
                    toolStripLabel_market.Text = "Markets(25):";

                    toolStripDropDownButton_period.Enabled = false;
                    toolStripDropDownButton_FeedSource.Enabled = false;
                    break;

                default:
                    LogManager.AddLogMessage(Name, "toolStripDropDownButton_widget_DropDownItemClicked", "type NOT DEFINED : " + PreferenceManager.CryptoComparePreferences.WidgetType, LogManager.LogMessageType.DEBUG);
                    break;
            }
            UpdateUI();
        }
        private void toolStripTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateUI();
            }          
        }
        #endregion

        private void listView_ItemActivate(object sender, EventArgs e)
        {
            if (listView.SelectedObject != null)
            {
                CryptoCompare.CryptoCompareCoin coin = listView.SelectedObject as CryptoCompare.CryptoCompareCoin;
                LogManager.AddLogMessage(Name, "listView_ItemActivate", coin.Symbol, LogManager.LogMessageType.DEBUG);
                toolStripTextBox_symbol.Text = coin.Symbol;
                UpdateUI();
            }
        }
    }
}