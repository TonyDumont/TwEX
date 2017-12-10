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
            TradingViewAdvancedChartParameters parameters = new TradingViewAdvancedChartParameters();
            parameters.exchange = TradingViewCryptoExchange.Coinbase;
            parameters.symbol = "ETH";
            parameters.market = "BTC";
            parameters.autosize = true;

            parameters.IndicatorList.Add(TradingViewIndicator.MACD);
            parameters.IndicatorList.Add(TradingViewIndicator.PSAR);
            parameters.IndicatorList.Add(TradingViewIndicator.RSI);
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
            widget.setMarketOverview(parameters);
        }
    }
}
