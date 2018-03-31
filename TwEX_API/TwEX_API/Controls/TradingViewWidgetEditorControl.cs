using System;
using System.Windows.Forms;
using static TwEX_API.Market.TradingView;

namespace TwEX_API.Controls
{
    public partial class TradingViewWidgetEditorControl : UserControl
    {
        #region Properties
        TradingViewWidgetControl widget = new TradingViewWidgetControl();
        TradingViewWidgetType widgetType = TradingViewWidgetType.AdvancedRealTimeChartWidget;
        #endregion Properties

        #region Initialize
        public TradingViewWidgetEditorControl()
        {
            InitializeComponent();
            widget.Dock = DockStyle.Fill;
            panel.Controls.Add(widget);
        }
        private void TradingViewWidgetEditorControl_Load(object sender, EventArgs e)
        {
            var list = EnumUtils.GetAllDescriptions<TradingViewWidgetType>();
            foreach(var item in list)
            {
                //LogManager.AddLogMessage(thisClassName, "TradingViewWidgetEditorControl_Load", item.Key + " | " + item.Value, LogManager.LogMessageType.DEBUG);
                ToolStripMenuItem menuItem = new ToolStripMenuItem() { Text = item.Key.ToString() };
                toolStripDropDownButton_widget.DropDownItems.Add(menuItem);
            }
        }
        #endregion Initialize

        #region Handlers
        private void toolStripDropDownButton_widget_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            /*
            string widgetName = e.ClickedItem.Text;
            toolStripDropDownButton_widget.Text = widgetName;
            widgetType = (TradingViewWidgetType)Enum.Parse(typeof(TradingViewWidgetType), widgetName);
            //LogManager.AddLogMessage(thisClassName, "toolStripDropDownButton_widget_DropDownItemClicked", "widgetType=" + widgetType, LogManager.LogMessageType.DEBUG);

            switch (widgetType)
            {
                case TradingViewWidgetType.AdvancedRealTimeChartWidget:
                    TradingViewAdvancedChartParameters parameters = new TradingViewAdvancedChartParameters() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "ETH", market = "BTC" };
                    widget.setAdvancedChart(parameters);
                    break;

                case TradingViewWidgetType.CryptocurrencyMarketWidget:
                    TradingViewCryptocurrencyMarketParameters cmparameters = new TradingViewCryptocurrencyMarketParameters();
                    widget.setCryptocurrencyMarket(cmparameters);
                    break;

                case TradingViewWidgetType.EconomicCalendarWidget:
                    TradingViewEconomicCalendarParameters ecparameters = new TradingViewEconomicCalendarParameters();
                    widget.setEconomicCalendar(ecparameters);
                    break;

                case TradingViewWidgetType.ForexCrossRatesWidget:
                    TradingViewForexParameters fcrparameters = new TradingViewForexParameters();
                    TradingViewCurrency[] currencies = new TradingViewCurrency[] { TradingViewCurrency.AUD, TradingViewCurrency.CNY, TradingViewCurrency.USD };
                    fcrparameters.currencies = currencies;
                    widget.setForexCrossRates(fcrparameters);
                    break;

                case TradingViewWidgetType.ForexHeatMapWidget:
                    TradingViewForexParameters fhmparameters = new TradingViewForexParameters();
                    TradingViewCurrency[] fhmcurrencies = new TradingViewCurrency[] { TradingViewCurrency.AUD, TradingViewCurrency.CNY, TradingViewCurrency.USD };
                    fhmparameters.currencies = fhmcurrencies;
                    widget.setForexHeatMap(fhmparameters);
                    break;

                case TradingViewWidgetType.FundamentalChartWidget:
                    TradingViewFundamentalChartParameters fparameters = new TradingViewFundamentalChartParameters() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "ETH", market = "BTC" };
                    widget.setFundamentalChart(fparameters);
                    break;

                case TradingViewWidgetType.MarketMoversWidget:
                    TradingViewMarketMoversParameters mmparameters = new TradingViewMarketMoversParameters() { exchange = TradingViewExchange.US };
                    widget.setMarketMovers(mmparameters);
                    break;

                case TradingViewWidgetType.MarketOverviewWidget:
                    TradingViewMarketOverviewParameters movparameters = new TradingViewMarketOverviewParameters();

                    TradingViewMarketOverviewTabItem mbtcItem = new TradingViewMarketOverviewTabItem() { s = "COINBASE:BTCUSD", d = "btc desc" };
                    TradingViewMarketOverviewTabItem methItem = new TradingViewMarketOverviewTabItem() { s = "COINBASE:ETHUSD", d = "eth desc" };
                    TradingViewMarketOverviewTabItem mltcItem = new TradingViewMarketOverviewTabItem() { s = "COINBASE:LTCUSD", d = "ltc desc" };

                    TradingViewMarketOverviewTab mtab1 = new TradingViewMarketOverviewTab() { title = "tab1" };
                    mtab1.symbols.Add(mbtcItem);
                    mtab1.symbols.Add(methItem);
                    mtab1.symbols.Add(mltcItem);

                    TradingViewMarketOverviewTab mtab2 = new TradingViewMarketOverviewTab() { title = "tab2" };
                    mtab2.symbols.Add(mbtcItem);
                    mtab2.symbols.Add(methItem);
                    mtab2.symbols.Add(mltcItem);

                    movparameters.tabs.Add(mtab1);
                    movparameters.tabs.Add(mtab2);
                    widget.setMarketOverview(movparameters);
                    break;

                case TradingViewWidgetType.MarketQuotesWidget:               
                    TradingViewMarketQuotesParameters mqparameters = new TradingViewMarketQuotesParameters();
                    
                    TradingViewMarketQuotesTabItem btcItem = new TradingViewMarketQuotesTabItem(){ name="COINBASE:BTCUSD", displayName = "btc desc"};
                    TradingViewMarketQuotesTabItem ethItem = new TradingViewMarketQuotesTabItem() { name = "COINBASE:ETHUSD", displayName = "eth desc" };
                    TradingViewMarketQuotesTabItem ltcItem = new TradingViewMarketQuotesTabItem() { name = "COINBASE:LTCUSD", displayName = "ltc desc" };

                    TradingViewMarketQuotesTab tab1 = new TradingViewMarketQuotesTab() { name = "tab1" };
                    tab1.symbols.Add(btcItem);
                    tab1.symbols.Add(ethItem);
                    tab1.symbols.Add(ltcItem);

                    TradingViewMarketQuotesTab tab2 = new TradingViewMarketQuotesTab() { name = "tab2" };
                    tab2.symbols.Add(btcItem);
                    tab2.symbols.Add(ethItem);
                    tab2.symbols.Add(ltcItem);

                    mqparameters.tabs.Add(tab1);
                    mqparameters.tabs.Add(tab2);
                    widget.setMarketQuotes(mqparameters);
                    break;

                case TradingViewWidgetType.ScreenerWidget:
                    TradingViewStockScreenerParameters ssparameters = new TradingViewStockScreenerParameters() { exchangeMarket = TradingViewExchangeMarket.market_crypto };
                    widget.setStockScreener(ssparameters);
                    break;

                case TradingViewWidgetType.SymbolOverviewWidget:             
                    TradingViewSymbolOverviewParameters soparameters = new TradingViewSymbolOverviewParameters();
                    TradingViewSymbolOverview item1 = new TradingViewSymbolOverview() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "ETH", market = "BTC", tabName = "tab1", interval = TradingViewSymbolOverviewInterval.month_1m };
                    TradingViewSymbolOverview item2 = new TradingViewSymbolOverview() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "LTC", market = "BTC", tabName = "tab2", interval = TradingViewSymbolOverviewInterval.month_1m };
                    TradingViewSymbolOverview item3 = new TradingViewSymbolOverview() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "BTC", market = "USD", tabName = "tab3", interval = TradingViewSymbolOverviewInterval.max_max };
                    soparameters.symbols.Add(item1);
                    soparameters.symbols.Add(item2);
                    soparameters.symbols.Add(item3);
                    widget.setSymbolOverview(soparameters);
                    break;

                case TradingViewWidgetType.TickerWidget:  
                    TradingViewTickerParameters twparameters = new TradingViewTickerParameters();
                    TradingViewTicker ticker1 = new TradingViewTicker() { proName = "COINBASE:BTCUSD", description = "btc desc" };
                    TradingViewTicker ticker2 = new TradingViewTicker() { proName = "BITFINEX:ETHUSD", description = "eth desc" };
                    TradingViewTicker ticker3 = new TradingViewTicker() { proName = "BITTREX:DASHUSD", description = "dsh desc" };
                    twparameters.symbols.Add(ticker1);
                    twparameters.symbols.Add(ticker2);
                    twparameters.symbols.Add(ticker3);
                    widget.setTicker(twparameters);
                    break;

                default:
                    LogManager.AddLogMessage(Name, "toolStripDropDownButton_widget_DropDownItemClicked", "type NOT DEFINED : " + widgetType, LogManager.LogMessageType.DEBUG);
                    break;
            }
            */
        }
        #endregion Handlers
    }
}