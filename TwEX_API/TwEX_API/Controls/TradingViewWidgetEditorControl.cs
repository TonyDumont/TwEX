using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TwEX_API.Market.TradingView;

namespace TwEX_API.Controls
{
    public partial class TradingViewWidgetEditorControl : UserControl
    {
        TradingViewWidgetControl widget = new TradingViewWidgetControl();
        TradingViewWidgetType widgetType = TradingViewWidgetType.AdvancedRealTimeChartWidget;

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
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = item.Key.ToString();
                toolStripDropDownButton_widget.DropDownItems.Add(menuItem);
            }
        }
        #endregion Initialize

        private void toolStripButton_test_Click(object sender, EventArgs e)
        {
            //parameters.tabs
            /*
            parameters.IndicatorList.Add(TradingViewIndicator.MACD);
            parameters.IndicatorList.Add(TradingViewIndicator.PSAR);
            parameters.IndicatorList.Add(TradingViewIndicator.RSI);
            
            //parameters.ActivateReferralProgram = true;
            //parameters.referral_id = "TonisD";
            //parameters.ShowHeadlines = true;
            //parameters.ShowStockTwits = true;
            //parameters.LaunchInPopupButton = true;
            
            TradingViewWatchlistItem item1 = new TradingViewWatchlistItem(){ exchange = TradingViewCryptoExchange.Coinbase, symbol = "ETH", market = "BTC"};
            TradingViewWatchlistItem item2 = new TradingViewWatchlistItem() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "LTC", market = "BTC" };
            TradingViewWatchlistItem item3 = new TradingViewWatchlistItem() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "BTC", market = "USD" };

            parameters.WatchList.Add(item1);
            parameters.WatchList.Add(item2);
            parameters.WatchList.Add(item3);
            */
            
        }

        private void toolStripDropDownButton_widget_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string widgetName = e.ClickedItem.Text;
            toolStripDropDownButton_widget.Text = widgetName;
            widgetType = (TradingViewWidgetType)Enum.Parse(typeof(TradingViewWidgetType), widgetName);
            LogManager.AddLogMessage(thisClassName, "toolStripDropDownButton_widget_DropDownItemClicked", "widgetType=" + widgetType, LogManager.LogMessageType.DEBUG);

            switch (widgetType)
            {
                case TradingViewWidgetType.AdvancedRealTimeChartWidget:
                    TradingViewAdvancedChartParameters parameters = new TradingViewAdvancedChartParameters();
                    parameters.exchange = TradingViewCryptoExchange.Coinbase;
                    parameters.symbol = "ETH";
                    parameters.market = "BTC";
                    parameters.autosize = true;
                    widget.setAdvancedChart(parameters);
                    break;

                case TradingViewWidgetType.CryptocurrencyMarketWidget:
                    TradingViewCryptocurrencyMarketParameters cmparameters = new TradingViewCryptocurrencyMarketParameters();
                    cmparameters.autosize = true;
                    widget.setCryptocurrencyMarket(cmparameters);
                    break;

                case TradingViewWidgetType.EconomicCalendarWidget:
                    TradingViewEconomicCalendarParameters ecparameters = new TradingViewEconomicCalendarParameters();
                    ecparameters.autosize = true;
                    widget.setEconomicCalendar(ecparameters);
                    break;

                case TradingViewWidgetType.ForexCrossRatesWidget:
                    TradingViewCurrency[] currencies = new TradingViewCurrency[] { TradingViewCurrency.AUD, TradingViewCurrency.CNY, TradingViewCurrency.USD };
                    TradingViewForexParameters fcrparameters = new TradingViewForexParameters();
                    fcrparameters.currencies = currencies;
                    fcrparameters.autosize = true;
                    widget.setForexCrossRates(fcrparameters);
                    break;

                case TradingViewWidgetType.ForexHeatMapWidget:
                    TradingViewCurrency[] fhmcurrencies = new TradingViewCurrency[] { TradingViewCurrency.AUD, TradingViewCurrency.CNY, TradingViewCurrency.USD };
                    TradingViewForexParameters fhmparameters = new TradingViewForexParameters();
                    fhmparameters.currencies = fhmcurrencies;
                    fhmparameters.autosize = true;
                    widget.setForexHeatMap(fhmparameters);
                    break;

                case TradingViewWidgetType.FundamentalChartWidget:
                    TradingViewFundamentalChartParameters fparameters = new TradingViewFundamentalChartParameters();
                    fparameters.exchange = TradingViewCryptoExchange.Coinbase;
                    fparameters.symbol = "ETH";
                    fparameters.market = "BTC";
                    fparameters.autosize = true;
                    widget.setFundamentalChart(fparameters);
                    break;

                case TradingViewWidgetType.MarketMoversWidget:
                    TradingViewMarketMoversParameters mmparameters = new TradingViewMarketMoversParameters();
                    mmparameters.autosize = true;
                    mmparameters.exchange = TradingViewExchange.US;
                    widget.setMarketMovers(mmparameters);
                    break;

                case TradingViewWidgetType.MarketOverviewWidget:
                    TradingViewMarketOverviewParameters movparameters = new TradingViewMarketOverviewParameters();
                    TradingViewMarketOverviewTab mtab1 = new TradingViewMarketOverviewTab();
                    TradingViewMarketOverviewTab mtab2 = new TradingViewMarketOverviewTab();
                    TradingViewMarketOverviewTabItem mbtcItem = new TradingViewMarketOverviewTabItem() { s = "COINBASE:BTCUSD", d = "btc desc" };
                    TradingViewMarketOverviewTabItem methItem = new TradingViewMarketOverviewTabItem() { s = "COINBASE:ETHUSD", d = "eth desc" };
                    TradingViewMarketOverviewTabItem mltcItem = new TradingViewMarketOverviewTabItem() { s = "COINBASE:LTCUSD", d = "ltc desc" };
                    mtab1.title = "tab1";
                    mtab1.symbols.Add(mbtcItem);
                    mtab1.symbols.Add(methItem);
                    mtab1.symbols.Add(mltcItem);
                    mtab2.title = "tab2";
                    mtab2.symbols.Add(mbtcItem);
                    mtab2.symbols.Add(methItem);
                    mtab2.symbols.Add(mltcItem);
                    movparameters.tabs.Add(mtab1);
                    movparameters.tabs.Add(mtab2);
                    widget.setMarketOverview(movparameters);
                    break;

                case TradingViewWidgetType.MarketQuotesWidget:               
                    TradingViewMarketQuotesParameters mqparameters = new TradingViewMarketQuotesParameters();
                    TradingViewMarketQuotesTab tab1 = new TradingViewMarketQuotesTab();
                    TradingViewMarketQuotesTab tab2 = new TradingViewMarketQuotesTab();
                    TradingViewMarketQuotesTabItem btcItem = new TradingViewMarketQuotesTabItem(){ name="COINBASE:BTCUSD", displayName = "btc desc"};
                    TradingViewMarketQuotesTabItem ethItem = new TradingViewMarketQuotesTabItem() { name = "COINBASE:ETHUSD", displayName = "eth desc" };
                    TradingViewMarketQuotesTabItem ltcItem = new TradingViewMarketQuotesTabItem() { name = "COINBASE:LTCUSD", displayName = "ltc desc" };
                    tab1.name = "tab1";
                    tab1.symbols.Add(btcItem);
                    tab1.symbols.Add(ethItem);
                    tab1.symbols.Add(ltcItem);
                    tab2.name = "tab2";
                    tab2.symbols.Add(btcItem);
                    tab2.symbols.Add(ethItem);
                    tab2.symbols.Add(ltcItem);
                    mqparameters.tabs.Add(tab1);
                    mqparameters.tabs.Add(tab2);
                    widget.setMarketQuotes(mqparameters);
                    break;

                case TradingViewWidgetType.ScreenerWidget:
                    // NEED TO ADD
                    break;

                case TradingViewWidgetType.SymbolOverviewWidget:             
                    TradingViewSymbolOverviewParameters soparameters = new TradingViewSymbolOverviewParameters();
                    TradingViewSymbolOverview item1 = new TradingViewSymbolOverview() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "ETH", market = "BTC", tabName = "tab1", interval = TradingViewSymbolOverviewInterval.month_1m };
                    TradingViewSymbolOverview item2 = new TradingViewSymbolOverview() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "LTC", market = "BTC", tabName = "tab2", interval = TradingViewSymbolOverviewInterval.month_1m };
                    TradingViewSymbolOverview item3 = new TradingViewSymbolOverview() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "BTC", market = "USD", tabName = "tab3", interval = TradingViewSymbolOverviewInterval.max_max };
                    soparameters.symbols.Add(item1);
                    soparameters.symbols.Add(item2);
                    soparameters.symbols.Add(item3);
                    soparameters.autosize = true;
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
        }
    }
}


/*
TradingViewAdvancedChartParameters parameters = new TradingViewAdvancedChartParameters();
parameters.exchange = TradingViewCryptoExchange.Coinbase;
parameters.symbol = "ETH";
parameters.market = "BTC";
parameters.autosize = true;
*/
//widget.setAdvancedChart(parameters);


/*
        TradingViewCryptocurrencyMarketParameters parameters = new TradingViewCryptocurrencyMarketParameters();
        parameters.autosize = true;
        widget.setCryptocurrencyMarket(parameters);
        */


/*
        TradingViewCurrency[] currencies = new TradingViewCurrency[] { TradingViewCurrency.AUD, TradingViewCurrency.CNY, TradingViewCurrency.USD };

        TradingViewForexParameters parameters = new TradingViewForexParameters();
        parameters.currencies = currencies;
        parameters.autosize = true;
        widget.setForexHeatMap(parameters);
        */


/*
        TradingViewSymbolOverviewParameters parameters = new TradingViewSymbolOverviewParameters();
        TradingViewSymbolOverview item1 = new TradingViewSymbolOverview() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "ETH", market = "BTC", tabName = "tab1", interval = TradingViewSymbolOverviewInterval.month_1m };
        TradingViewSymbolOverview item2 = new TradingViewSymbolOverview() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "LTC", market = "BTC", tabName = "tab2", interval = TradingViewSymbolOverviewInterval.month_1m };
        TradingViewSymbolOverview item3 = new TradingViewSymbolOverview() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "BTC", market = "USD", tabName = "tab3", interval = TradingViewSymbolOverviewInterval.max_max };

        parameters.symbols.Add(item1);
        parameters.symbols.Add(item2);
        parameters.symbols.Add(item3);
        //parameters.autosize = true;
        widget.setSymbolOverview(parameters);

        */


/*
        TradingViewTickerParameters parameters = new TradingViewTickerParameters();
        TradingViewTicker ticker1 = new TradingViewTicker() { proName = "COINBASE:BTCUSD", description = "btc desc" };
        TradingViewTicker ticker2 = new TradingViewTicker() { proName = "BITFINEX:ETHUSD", description = "eth desc" };
        TradingViewTicker ticker3 = new TradingViewTicker() { proName = "BITTREX:DASHUSD", description = "dsh desc" };
        parameters.symbols.Add(ticker1);
        parameters.symbols.Add(ticker2);
        parameters.symbols.Add(ticker3);
        widget.setTicker(parameters);
        */


/*
        TradingViewMarketQuotesParameters parameters = new TradingViewMarketQuotesParameters();

        TradingViewMarketQuotesTab tab1 = new TradingViewMarketQuotesTab();

        TradingViewMarketQuotesTab tab2 = new TradingViewMarketQuotesTab();

        TradingViewMarketQuotesTabItem btcItem = new TradingViewMarketQuotesTabItem(){ name="COINBASE:BTCUSD", displayName = "btc desc"};
        TradingViewMarketQuotesTabItem ethItem = new TradingViewMarketQuotesTabItem() { name = "COINBASE:ETHUSD", displayName = "eth desc" };
        TradingViewMarketQuotesTabItem ltcItem = new TradingViewMarketQuotesTabItem() { name = "COINBASE:LTCUSD", displayName = "ltc desc" };

        tab1.name = "tab1";
        tab1.symbols.Add(btcItem);
        tab1.symbols.Add(ethItem);
        tab1.symbols.Add(ltcItem);

        tab2.name = "tab2";
        tab2.symbols.Add(btcItem);
        tab2.symbols.Add(ethItem);
        tab2.symbols.Add(ltcItem);

        parameters.tabs.Add(tab1);
        parameters.tabs.Add(tab2);
        widget.setMarketQuotes(parameters);
        */
