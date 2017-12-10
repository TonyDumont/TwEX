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

        public TradingViewWidgetEditorControl()
        {
            InitializeComponent();
            widget.Dock = DockStyle.Fill;
            panel.Controls.Add(widget);
        }

        private void toolStripButton_test_Click(object sender, EventArgs e)
        {
            TradingViewCryptocurrencyMarketParameters parameters = new TradingViewCryptocurrencyMarketParameters();
            parameters.autosize = true;
            widget.setCryptocurrencyMarket(parameters);

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

            //parameters.tabs
            /*
            TradingViewAdvancedChartParameters parameters = new TradingViewAdvancedChartParameters();
            parameters.exchange = TradingViewCryptoExchange.Coinbase;
            parameters.symbol = "ETH";
            parameters.market = "BTC";
            parameters.autosize = true;
            */


            /*
            parameters.IndicatorList.Add(TradingViewIndicator.MACD);
            parameters.IndicatorList.Add(TradingViewIndicator.PSAR);
            parameters.IndicatorList.Add(TradingViewIndicator.RSI);
            */
            //parameters.ActivateReferralProgram = true;
            //parameters.referral_id = "TonisD";
            //parameters.ShowHeadlines = true;
            //parameters.ShowStockTwits = true;
            //parameters.LaunchInPopupButton = true;
            /*
            TradingViewWatchlistItem item1 = new TradingViewWatchlistItem(){ exchange = TradingViewCryptoExchange.Coinbase, symbol = "ETH", market = "BTC"};
            TradingViewWatchlistItem item2 = new TradingViewWatchlistItem() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "LTC", market = "BTC" };
            TradingViewWatchlistItem item3 = new TradingViewWatchlistItem() { exchange = TradingViewCryptoExchange.Coinbase, symbol = "BTC", market = "USD" };

            parameters.WatchList.Add(item1);
            parameters.WatchList.Add(item2);
            parameters.WatchList.Add(item3);
            */
            //widget.setAdvancedChart(parameters);
            //widget.setMarketOverview(parameters);
        }
    }
}
