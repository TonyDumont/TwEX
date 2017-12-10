using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using static TwEX_API.Market.TradingView;

namespace TwEX_API.Controls
{
    public partial class TradingViewWidgetControl : UserControl
    {
        #region Properties
        public ChromiumWebBrowser browser = new ChromiumWebBrowser(String.Empty);
        //private bool AdvancedView = false;
        //private string exchange = string.Empty;
        //private string market = string.Empty;
        //private string symbol = string.Empty;

        //private List<TradingViewWatchlistItem> watchList = new List<TradingViewWatchlistItem>();
        #endregion

        #region Initialize
        public TradingViewWidgetControl()
        {
            InitializeComponent();
            InitializeBrowser();
        }
        public void InitializeBrowser()
        {
            //Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser(String.Empty);
            this.Controls.Add(browser);
            //panel.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }
        #endregion

        #region Getters
        private string GetBoolean(Boolean value)
        {
            return value.ToString().ToLower();
        }
        private string GetInterval(TradingViewChartInterval interval)
        {
            string[] split = interval.ToString().Split('_');
            return split[1];
        }
        private string GetNewsString(Boolean showHeadlines, Boolean showStockTwits)
        {
            
            if (showHeadlines == true || showStockTwits == true)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("\"news\": [");

                if (showHeadlines)
                {
                    builder.Append("\"headlines\"");
                }

                if (showStockTwits && showHeadlines)
                {
                    builder.Append(",\"stocktwits\"");
                }
                else
                {
                    builder.Append("\"stocktwits\"");
                }

                builder.Append("],");
                //LogManager.AddLogMessage(this.Name, "GetWatchlist", builder.ToString(), LogManager.LogMessageType.DEBUG);
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetPopupString(Boolean LaunchInPopupButton, int popupWidth, int popupHeight)
        {
            if (LaunchInPopupButton)
            {
                return "\"show_popup_button\": true,\"popup_width\": \"" + popupWidth + "\",\"popup_height\": \"" + popupHeight + "\",";
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetReferralString(Boolean ActivateReferralProgram, string referral_id)
        {
            if (ActivateReferralProgram)
            {
                return "\"referral_id\": \"" + referral_id + "\",";
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetSizeString(Boolean autosize, int width, int height)
        {
            //int wOffset = 25;
            //int hOffset = 25;


            if (autosize)
            {
                return "\"autosize\": true,";
            }
            else
            {
                return "\"width\": " + width + "," + "\"height\": " + height + ",";
            }
        }
        private string GetStudiesString(List<TradingViewIndicator> list)
        {
            if (list.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("\"studies\": [");

                int index = 1;
                foreach (TradingViewIndicator item in list)
                {
                    builder.Append("\"" + item + "@tv-basicstudies\"");
                    if (index != list.Count)
                    {
                        builder.Append(",");
                    }
                    index++;
                }

                builder.Append("],");
                //LogManager.AddLogMessage(this.Name, "GetWatchlist", builder.ToString(), LogManager.LogMessageType.DEBUG);
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetWatchlistString(List<TradingViewWatchlistItem> watchList)
        {
            if (watchList.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("\"watchlist\": [");

                int index = 1;
                foreach (TradingViewWatchlistItem item in watchList)
                {
                    builder.Append("\"" + item.GetWatchlistString() + "\"");
                    if (index != watchList.Count)
                    {
                        builder.Append(",");
                    }
                    index++;
                }

                builder.Append("],");
                //LogManager.AddLogMessage(this.Name, "GetWatchlist", builder.ToString(), LogManager.LogMessageType.DEBUG);
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region Delegates
        // Advanced Real-Time Chart Widget
        delegate void setAdvancedChartCallback(TradingViewAdvancedChartParameters parameters);
        public void setAdvancedChart(TradingViewAdvancedChartParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setAdvancedChartCallback d = new setAdvancedChartCallback(setAdvancedChart);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    string symbolString = parameters.exchange.ToString().ToUpper() + ":" + parameters.symbol.ToUpper() + parameters.market.ToUpper();

                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +
                    "<div id=\"container\">" +

                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/tv.js\"></script>" +
                    "<script type=\"text/javascript\">" +
                    "new TradingView.widget({" +
                    GetSizeString(parameters.autosize, parameters.width, parameters.height) +
                    "\"symbol\": \"" + symbolString + "\"," +
                    "\"interval\": \"" + GetInterval(parameters.interval) + "\"," +
                    "\"timezone\": \"America/New_York\"," +
                    "\"theme\": \"" + parameters.theme + "\"," +
                    "\"style\": \"" + parameters.style.GetHashCode() + "\"," +
                    "\"locale\": \"en\"," +
                    "\"toolbar_bg\": \"" + parameters.toolbarBackgroundColor + "\"," +
                    "\"enable_publishing\": " + GetBoolean(parameters.EnablePublishing) + "," +
                    "\"withdateranges\": " + GetBoolean(parameters.ShowBottomToolbar) + "," +
                    "\"hide_side_toolbar\": " + GetBoolean(parameters.ShowDrawingToolsBar) + "," +
                    "\"allow_symbol_change\": " + GetBoolean(parameters.AllowSymbolChange) + "," +
                    GetWatchlistString(parameters.WatchList) +
                    "\"details\": " + GetBoolean(parameters.ShowDetails) + "," +
                    "\"hotlists\": " + GetBoolean(parameters.ShowHotlist) + "," +
                    "\"calendar\": " + GetBoolean(parameters.ShowCalendar) + "," +
                    GetNewsString(parameters.ShowHeadlines, parameters.ShowStockTwits) +
                    GetStudiesString(parameters.IndicatorList) +
                    GetPopupString(parameters.LaunchInPopupButton, parameters.popupWidth, parameters.popupHeight) +
                    GetReferralString(parameters.ActivateReferralProgram, parameters.referral_id) +
                    // LAST ENTRY
                    "\"hideideas\": " + GetBoolean(parameters.ShowIdeasButton) +
                    "});" +
                    "</script>" +
                    "</div>" +
                    "</body></html>";
                    //LogManager.AddLogMessage(this.Name, "setAdvancedChart", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // Market Overview Widget
        // Advanced Real-Time Chart Widget
        delegate void setMarketOverviewCallback(TradingViewAdvancedChartParameters parameters);
        public void setMarketOverview(TradingViewAdvancedChartParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setMarketOverviewCallback d = new setMarketOverviewCallback(setMarketOverview);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    //string symbolString = parameters.exchange.ToString().ToUpper() + ":" + parameters.symbol.ToUpper() + parameters.market.ToUpper();

                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    "<span id=\"tradingview-copyright\">" + 
                        "<a ref=\"nofollow noopener\" target=\"_blank\" href=\"http://www.tradingview.com\" style=\"color: rgb(173, 174, 176); font-family: &quot;Trebuchet MS&quot;, Tahoma, Arial, sans-serif; font-size: 13px;\">" +
                         "Market Quotes by <span style=\"color: #3BB3E4\">TradingView</span>" +
                        "</a >" +
                    "</span>" +

                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-market-overview.js\">" +
                    "{" +
                        "\"showChart\": true," +
                        "\"locale\": \"en\"," +
                        "\"width\": \"400\"," +
                        "\"height\": \"660\"," +
                        "\"plotLineColorGrowing\": \"rgba(60, 188, 152, 1)\"," +
                        "\"plotLineColorFalling\": \"rgba(255, 74, 104, 1)\"," +
                        "\"gridLineColor\": \"rgba(233, 233, 234, 1)\"," +
                        "\"scaleFontColor\": \"rgba(218, 221, 224, 1)\"," +
                        "\"belowLineFillColorGrowing\": \"rgba(60, 188, 152, 0.05)\"," +
                        "\"belowLineFillColorFalling\": \"rgba(255, 74, 104, 0.05)\"," +
                        "\"symbolActiveColor\": \"rgba(242, 250, 254, 1)\"," +
                        // TABS
                        "\"tabs\": [{" +
                            "\"title\": \"Equities\"," +
                                "\"symbols\": [{" +

                                "\"s\": \"COINBASE:BTCUSD\"" +

                            "},{" +

                                "\"s\": \"POLONIEX:BTCUSDT\"" +

                            "},{" +

                                "\"s\": \"BITSTAMP:BTCUSD\"" +

                            "}]" +
                        // NEXT TAB
                        "},{" +

                            "\"title\": \"Commodities\"," +
                                "\"symbols\": [{" +

                                "\"s\": \"CME_MINI:ES1!\"," +
                                "\"d\": \"E-Mini S&P\"" +
                            "},{" +
                                "\"s\": \"CME:E61!\"," +
                                "\"d\": \"Euro\"" +
                            "},{" +
                                "\"s\": \"CBOT:ZC1!\"," +
                                "\"d\": \"Corn\"" +
                        "}]" +
                        // LAST TAB
                    "}]}" +
                    "</script>" +
                    "</body></html>";

                                  /*
                                  "<div id=\"container\">" +

                                  "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/tv.js\"></script>" +
                                  "<script type=\"text/javascript\">" +
                                  "new TradingView.widget({" +
                                  GetSizeString(parameters.autosize, parameters.width, parameters.height) +
                                  "\"symbol\": \"" + symbolString + "\"," +
                                  "\"interval\": \"" + GetInterval(parameters.interval) + "\"," +
                                  "\"timezone\": \"America/New_York\"," +
                                  "\"theme\": \"" + parameters.theme + "\"," +
                                  "\"style\": \"" + parameters.style.GetHashCode() + "\"," +
                                  "\"locale\": \"en\"," +
                                  "\"toolbar_bg\": \"" + parameters.toolbarBackgroundColor + "\"," +
                                  "\"enable_publishing\": " + GetBoolean(parameters.EnablePublishing) + "," +
                                  "\"withdateranges\": " + GetBoolean(parameters.ShowBottomToolbar) + "," +
                                  "\"hide_side_toolbar\": " + GetBoolean(parameters.ShowDrawingToolsBar) + "," +
                                  "\"allow_symbol_change\": " + GetBoolean(parameters.AllowSymbolChange) + "," +
                                  GetWatchlistString(parameters.WatchList) +
                                  "\"details\": " + GetBoolean(parameters.ShowDetails) + "," +
                                  "\"hotlists\": " + GetBoolean(parameters.ShowHotlist) + "," +
                                  "\"calendar\": " + GetBoolean(parameters.ShowCalendar) + "," +
                                  GetNewsString(parameters.ShowHeadlines, parameters.ShowStockTwits) +
                                  GetStudiesString(parameters.IndicatorList) +
                                  GetPopupString(parameters.LaunchInPopupButton, parameters.popupWidth, parameters.popupHeight) +
                                  GetReferralString(parameters.ActivateReferralProgram, parameters.referral_id) +
                                  // LAST ENTRY
                                  "\"hideideas\": " + GetBoolean(parameters.ShowIdeasButton) +
                                  "});" +
                                  "</script>" +
                                  "</div>" +
                                  

                                  "</body></html>";
                                  */
                    //LogManager.AddLogMessage(this.Name, "setAdvancedChart", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        #endregion
    }
}






//return string.Empty;
/*
StringBuilder builder = new StringBuilder();
builder.Append("\"watchlist\": [");

List<Exchange> exchangeList = ExchangeManager.exchangeList.Where(item => item.TradingView == true).ToList();

int listCount = 0;
// loop
if (symbol != "BTC")
{
    // BTC
    foreach (Exchange exchange in exchangeList)
    {

        if (listCount < exchangeList.Count)
        {
            string tvSymbol = "\"" + exchange.Symbol + ":" + symbol + "BTC\",";
            builder.Append(tvSymbol);
        }
        else
        {
            string tvSymbol = "\"" + exchange.Symbol + ":" + symbol + "BTC\"";
            builder.Append(tvSymbol);
        }

        listCount++;
    }

    listCount = 0;
    // USD
    foreach (Exchange exchange in exchangeList)
    {

        if (listCount < exchangeList.Count)
        {
            string tvSymbol = "\"" + exchange.Symbol + ":" + symbol + exchange.USDSymbol + "\",";
            builder.Append(tvSymbol);
        }
        else
        {
            string tvSymbol = "\"" + exchange.Symbol + ":" + symbol + exchange.USDSymbol + "\"";
            builder.Append(tvSymbol);
        }

        listCount++;
    }

}
else
{
    // JUST USD
    foreach (Exchange exchange in exchangeList)
    {

        if (listCount < exchangeList.Count)
        {
            string tvSymbol = "\"" + exchange.Symbol + ":" + symbol + exchange.USDSymbol + "\",";
            builder.Append(tvSymbol);
        }
        else
        {
            string tvSymbol = "\"" + exchange.Symbol + ":" + symbol + exchange.USDSymbol + "\"";
            builder.Append(tvSymbol);
        }

        listCount++;
    }
}

builder.Append("],");
//LogManager.AddDebugMessage(this.Name, "GetWatchlist", builder.ToString());
return builder.ToString();
*/
