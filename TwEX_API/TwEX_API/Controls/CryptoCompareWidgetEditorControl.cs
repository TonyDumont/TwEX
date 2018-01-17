using System;
using System.Windows.Forms;
using TwEX_API.Market;

namespace TwEX_API.Controls
{
    public partial class CryptoCompareWidgetEditorControl : UserControl
    {
        #region Properties
        CryptoCompareWidgetControl widget = new CryptoCompareWidgetControl();
        CryptoCompare.CryptoCompareWidgetType widgetType = CryptoCompare.CryptoCompareWidgetType.Chart;
        CryptoCompare.CryptoCompareChartPeriod periodType = CryptoCompare.CryptoCompareChartPeriod.Day_1D;
        CryptoCompare.CryptoCompareFeedType feedType = CryptoCompare.CryptoCompareFeedType.CoinTelegraph;
        #endregion

        #region Initialize
        public CryptoCompareWidgetEditorControl()
        {
            InitializeComponent();
            widget.Dock = DockStyle.Fill;
            panel.Controls.Add(widget);
        }
        private void CryptoCompareWidgetEditorControl_Load(object sender, System.EventArgs e)
        {

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
        #endregion

        #region Updaters
        private void updateUI()
        {
            listView.SetObjects(CryptoCompare.CoinList);

            switch (widgetType)
            {
                case CryptoCompare.CryptoCompareWidgetType.Chart:
                    widget.setChart(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text, periodType);
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
                    LogManager.AddLogMessage(Name, "updateUI", widgetType.ToString(), LogManager.LogMessageType.DEBUG);
                    widget.setHeaderV3(toolStripTextBox_symbol.Text, toolStripTextBox_market.Text);
                    break;

                default:
                    LogManager.AddLogMessage(Name, "updateUI", "type NOT DEFINED : " + widgetType, LogManager.LogMessageType.DEBUG);
                    break;
            }
        }
        #endregion

        #region EventHandlers
        private void toolStripDropDownButton_period_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_period.Text = e.ClickedItem.Text;
            CryptoCompare.CryptoCompareChartPeriod type = (CryptoCompare.CryptoCompareChartPeriod)Enum.Parse(typeof(CryptoCompare.CryptoCompareChartPeriod), e.ClickedItem.Tag.ToString());
            periodType = type;
            updateUI();
        }
        private void toolStripDropDownButton_FeedSource_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripDropDownButton_FeedSource.Text = e.ClickedItem.Tag.ToString();
            CryptoCompare.CryptoCompareFeedType type = (CryptoCompare.CryptoCompareFeedType)Enum.Parse(typeof(CryptoCompare.CryptoCompareFeedType), e.ClickedItem.Text);
            feedType = type;
            updateUI();
        }
        private void toolStripDropDownButton_widget_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string widgetName = e.ClickedItem.Tag.ToString();
            toolStripDropDownButton_widget.Text = widgetName;
            widgetType = (CryptoCompare.CryptoCompareWidgetType) Enum.Parse(typeof(CryptoCompare.CryptoCompareWidgetType), widgetName);

            switch (widgetType)
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
                    LogManager.AddLogMessage(Name, "toolStripDropDownButton_widget_DropDownItemClicked", "type NOT DEFINED : " + widgetType, LogManager.LogMessageType.DEBUG);
                    break;
            }
            updateUI();
        }
        private void toolStripTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateUI();
            }          
        }
        #endregion
    }
}