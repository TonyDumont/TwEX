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
        private string GetCopyrightString()
        {
            string html = "<span id=\"tradingview-copyright\">" +
                            "<a ref=\"nofollow noopener\" target=\"_blank\" href=\"http://www.tradingview.com\" " +
                            "style=\"color: rgb(173, 174, 176); font-family: &quot;Trebuchet MS&quot;, Tahoma, Arial, sans-serif; font-size: 13px;\">" +
                            "Quotes by <span style=\"color: #3BB3E4\">TradingView</span>" +
                            "</a >" +
                            "</span>";
            return html;
        }
        private string GetCurrenciesString(TradingViewCurrency[] array)
        {
            if (array.Count() > 0)
            {
                //"\"currencies\": [" + string.Join(",", parameters.currencies) + "]," +
                StringBuilder builder = new StringBuilder();
                builder.Append("\"currencies\": [");

                int index = 1;
                foreach (TradingViewCurrency item in array)
                {
                    builder.AppendLine("\"" + item + "\"");
                    if (index != array.Count())
                    {
                        builder.AppendLine(",");
                        index++;
                    }
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
        private string GetCurrencyFilter(string currencyFilter)
        {
            if (currencyFilter.Length > 0)
            {
                return "\"currencyFilter\": \"" + currencyFilter + "\",";
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetForexSizeString(Boolean autosize, int width, int height)
        {
            if (autosize)
            {
                return "\"width\": \"100%\", \"height\": \"100%\",";
            }
            else
            {
                return "\"width\": \"" + width + "\", \"height\": \"" + height + "\",";
            }
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
        private string GetMarketOverviewTabsString(List<TradingViewMarketOverviewTab> tabs)
        {
            if (tabs.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("\"tabs\": [");
                int tabindex = 1;
                // LOOP THROUGH TABS
                foreach (TradingViewMarketOverviewTab tab in tabs)
                {
                    builder.AppendLine("{");
                    builder.AppendLine("\"title\": \"" + tab.title + "\",");
                    builder.AppendLine("\"symbols\": [");
                    int symbolindex = 1;
                    // LOOP THROUGH SYMBOLS
                    foreach(TradingViewMarketOverviewTabItem item in tab.symbols)
                    {
                        //LogManager.AddLogMessage(this.Name, "GetTabsString", tab.title + " | " + tab.symbols.Count + " | " + item.s + " | " + item.d, LogManager.LogMessageType.DEBUG);
                        builder.AppendLine("{");
                        builder.AppendLine("\"s\": \"" + item.s + "\",");
                        builder.AppendLine("\"d\": \"" + item.d + "\"");
                        if (symbolindex != tab.symbols.Count)
                        {
                            builder.AppendLine("},");
                            symbolindex++;
                        }
                        else
                        {
                            // LAST SYMBOL
                            builder.AppendLine("}");
                        }
                    }

                    if (tabindex != tabs.Count)
                    {
                        builder.AppendLine("]},");
                        tabindex++;
                    }
                    else
                    {
                        // LAST TAB
                        builder.AppendLine("]}");
                    }
                }
                builder.AppendLine("]");
                LogManager.AddLogMessage(this.Name, "GetTabsString", builder.ToString(), LogManager.LogMessageType.DEBUG);
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetMarketQuotesTabsString(List<TradingViewMarketQuotesTab> tabs)
        {
            if (tabs.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("\"symbolsGroups\": [");
                int tabindex = 1;
                // LOOP THROUGH TABS
                foreach (TradingViewMarketQuotesTab tab in tabs)
                {
                    builder.AppendLine("{");
                    builder.AppendLine("\"name\": \"" + tab.name + "\",");
                    builder.AppendLine("\"symbols\": [");
                    int symbolindex = 1;
                    // LOOP THROUGH SYMBOLS
                    foreach (TradingViewMarketQuotesTabItem item in tab.symbols)
                    {
                        //LogManager.AddLogMessage(this.Name, "GetTabsString", tab.title + " | " + tab.symbols.Count + " | " + item.s + " | " + item.d, LogManager.LogMessageType.DEBUG);
                        builder.AppendLine("{");
                        builder.AppendLine("\"name\": \"" + item.name + "\",");
                        builder.AppendLine("\"displayName\": \"" + item.displayName + "\"");
                        if (symbolindex != tab.symbols.Count)
                        {
                            builder.AppendLine("},");
                            symbolindex++;
                        }
                        else
                        {
                            // LAST SYMBOL
                            builder.AppendLine("}");
                        }
                    }

                    if (tabindex != tabs.Count)
                    {
                        builder.AppendLine("]},");
                        tabindex++;
                    }
                    else
                    {
                        // LAST TAB
                        builder.AppendLine("]}");
                    }
                }
                builder.AppendLine("]");
                LogManager.AddLogMessage(this.Name, "GetMarketQuotesTabsString", builder.ToString(), LogManager.LogMessageType.DEBUG);
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetSymbolOverviewString(List<TradingViewSymbolOverview> list)
        {
            if (list.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("\"symbols\": [");

                int index = 1;
                foreach (TradingViewSymbolOverview item in list)
                {
                    builder.Append("[");
                    builder.Append("\"" + item.tabName + "\",");
                    builder.Append("\"" + item.GetSymbol() + "\"");

                    if (index != list.Count)
                    {
                        builder.Append("],");
                        index++;
                    }
                    else
                    {
                        builder.Append("]");
                    }
                }

                builder.Append("],");
                LogManager.AddLogMessage(this.Name, "GetSymbolOverviewString", builder.ToString(), LogManager.LogMessageType.DEBUG);
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetSymbolOverviewSizeString(Boolean autosize, int width, int height)
        {
            if (autosize)
            {
                return "\"width\": \"100%\", \"height\": \"100%\",";
            }
            else
            {
                return "\"width\": \"" + width + "px\", \"height\": \"" + height + "px\",";
            }
        }
        private string GetTickerString(List<TradingViewTicker> tickers)
        {
            if (tickers.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("\"symbols\": [");

                int index = 1;
                foreach (TradingViewTicker item in tickers)
                {
                    builder.AppendLine("{");
                    builder.AppendLine("\"description\": \"" + item.description + "\",");
                    builder.AppendLine("\"proName\": \"" + item.proName + "\"");
                    if (index != tickers.Count)
                    {
                        builder.AppendLine("},");
                        index++;
                    }
                    else
                    {
                        // LAST SYMBOL
                        builder.AppendLine("}");
                    }
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
        delegate void setMarketOverviewCallback(TradingViewMarketOverviewParameters parameters);
        public void setMarketOverview(TradingViewMarketOverviewParameters parameters)
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
                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    GetCopyrightString() +

                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-market-overview.js\">" +
                    "{" +
                        "\"showChart\": " + GetBoolean(parameters.showChart) + "," +
                        "\"locale\": \"en\"," +
                        GetSizeString(parameters.autosize, parameters.width, parameters.height) +
                        "\"plotLineColorGrowing\": \"" + parameters.plotLineColorGrowing + "\"," +
                        "\"plotLineColorFalling\": \"" + parameters.plotLineColorFalling + "\"," +
                        "\"gridLineColor\": \"" + parameters.gridLineColor + "\"," +
                        "\"scaleFontColor\": \"" + parameters.scaleFontColor + "\"," +
                        "\"belowLineFillColorGrowing\": \"" + parameters.belowLineFillColorGrowing + "\"," +
                        "\"belowLineFillColorFalling\": \"" + parameters.belowLineFillColorFalling + "\"," +
                        "\"symbolActiveColor\": \"" + parameters.symbolActiveColor + "\"," +
                        GetMarketOverviewTabsString(parameters.tabs) +    
                    "}" +
                    "</script>" +
                    "</body></html>";           
                    //LogManager.AddLogMessage(this.Name, "setmarketOverview", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // Market Quotes Widget
        delegate void setMarketQuotesCallback(TradingViewMarketQuotesParameters parameters);
        public void setMarketQuotes(TradingViewMarketQuotesParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setMarketQuotesCallback d = new setMarketQuotesCallback(setMarketQuotes);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    GetCopyrightString() +

                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-market-quotes.js\">" +
                    "{" +
                        GetSizeString(parameters.autosize, parameters.width, parameters.height) +
                        "\"locale\": \"en\"," +                      
                        GetMarketQuotesTabsString(parameters.tabs) +
                    "}" +
                    "</script>" +
                    "</body></html>";
                    //LogManager.AddLogMessage(this.Name, "setmarketOverview", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // Market Movers Widget
        delegate void setMarketMoversCallback(TradingViewMarketMoversParameters parameters);
        public void setMarketMovers(TradingViewMarketMoversParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setMarketMoversCallback d = new setMarketMoversCallback(setMarketMovers);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    GetCopyrightString() +

                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-hotlists.js\">" +
                    "{" +
                        "\"exchange\": \"" + parameters.exchange + "\"," +
                        "\"showChart\": " + GetBoolean(parameters.showChart) + "," +
                        "\"locale\": \"en\"," +
                        GetForexSizeString(parameters.autosize, parameters.width, parameters.height) +
                        "\"plotLineColorGrowing\": \"" + parameters.plotLineColorGrowing + "\"," +
                        "\"plotLineColorFalling\": \"" + parameters.plotLineColorFalling + "\"," +
                        "\"gridLineColor\": \"" + parameters.gridLineColor + "\"," +
                        "\"scaleFontColor\": \"" + parameters.scaleFontColor + "\"," +
                        "\"belowLineFillColorGrowing\": \"" + parameters.belowLineFillColorGrowing + "\"," +
                        "\"belowLineFillColorFalling\": \"" + parameters.belowLineFillColorFalling + "\"," +
                        "\"symbolActiveColor\": \"" + parameters.symbolActiveColor + "\"" +
                        
                    "}" +
                    "</script>" +
                    "</body></html>";
                    //LogManager.AddLogMessage(this.Name, "setMarketMovers", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // Economic Calendar Widget
        delegate void setEconomicCalendarCallback(TradingViewEconomicCalendarParameters parameters);
        public void setEconomicCalendar(TradingViewEconomicCalendarParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setEconomicCalendarCallback d = new setEconomicCalendarCallback(setEconomicCalendar);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    GetCopyrightString() +

                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-events.js\">" +
                    "{" +
                        GetForexSizeString(parameters.autosize, parameters.width, parameters.height) +
                        "\"locale\": \"en\"," +
                        GetCurrencyFilter(parameters.currencyFilter) +
                        "\"importanceFilter\": \"" + parameters.importanceFilter + "\"" +
                    "}" +
                    "</script>" +
                    "</body></html>";
                    //LogManager.AddLogMessage(this.Name, "setmarketOverview", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // Ticker Widget
        delegate void setTickerCallback(TradingViewTickerParameters parameters);
        public void setTicker(TradingViewTickerParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setTickerCallback d = new setTickerCallback(setTicker);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    GetCopyrightString() +

                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-tickers.js\">" +
                    "{" +
                        GetTickerString(parameters.symbols) +
                        "\"locale\": \"en\"" +
                    "}" +
                    "</script>" +
                    "</body></html>";
                    //LogManager.AddLogMessage(this.Name, "setmarketOverview", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // Symbol Overview Widget
        delegate void setSymbolOverviewCallback(TradingViewSymbolOverviewParameters parameters);
        public void setSymbolOverview(TradingViewSymbolOverviewParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setSymbolOverviewCallback d = new setSymbolOverviewCallback(setSymbolOverview);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    "<div id=\"tv-medium-widget-6caf3\"></div>" +
                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/tv.js\"></script>" +
                    "<script type=\"text/javascript\">" +
                    "new TradingView.MediumWidget({" +
                        "\"container_id\": \"tv-medium-widget-6caf3\"," +
                        GetSymbolOverviewString(parameters.symbols) +
                        "\"chartOnly\": " + GetBoolean(parameters.chartOnly) + "," +
                        "\"greyText\": \"Quotes by\"," +
                        "\"gridLineColor\": \"" + parameters.gridLineColor + "\"," +
                        "\"fontColor\": \"" + parameters.fontColor + "\"," +
                        "\"underLineColor\": \"" + parameters.underLineColor + "\"," +
                        "\"trendLineColor\": \"" + parameters.trendLineColor + "\"," +
                        GetSymbolOverviewSizeString(parameters.autosize, parameters.width, parameters.height) +
                        "\"locale\": \"en\"" +
                    "});" +
                    "</script>" +
                    "</body></html>";
                    //LogManager.AddLogMessage(this.Name, "setSymbolOverview", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // FOREX Cross Rates Widget
        delegate void setForexCrossRatesCallback(TradingViewForexParameters parameters);
        public void setForexCrossRates(TradingViewForexParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setForexCrossRatesCallback d = new setForexCrossRatesCallback(setForexCrossRates);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    GetCopyrightString() +

                    "<script src=\"https://s3.tradingview.com/external-embedding/embed-widget-forex-cross-rates.js\">" +
                    "{" + 
                        GetCurrenciesString(parameters.currencies) +
                        GetForexSizeString(parameters.autosize, parameters.width, parameters.height) +
                        "\"locale\": \"en\"" +
                    "}" +
                    "</script>" +
                    "</body></html>";
                    //LogManager.AddLogMessage(this.Name, "setForexCrossRates", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // FOREX Heat Map Widget
        delegate void setForexHeatMapCallback(TradingViewForexParameters parameters);
        public void setForexHeatMap(TradingViewForexParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setForexHeatMapCallback d = new setForexHeatMapCallback(setForexHeatMap);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    GetCopyrightString() +

                    "<script src=\"https://s3.tradingview.com/external-embedding/embed-widget-forex-heat-map.js\">" +
                    "{" +
                        GetCurrenciesString(parameters.currencies) +
                        GetForexSizeString(parameters.autosize, parameters.width, parameters.height) +
                        "\"locale\": \"en\"" +
                    "}" +
                    "</script>" +
                    "</body></html>";
                    //LogManager.AddLogMessage(this.Name, "setForexHeatMap", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // Screener Widget

        // Cryptocurrency Market Widget
        delegate void setCryptocurrencyMarketCallback(TradingViewCryptocurrencyMarketParameters parameters);
        public void setCryptocurrencyMarket(TradingViewCryptocurrencyMarketParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setCryptocurrencyMarketCallback d = new setCryptocurrencyMarketCallback(setCryptocurrencyMarket);
                this.Invoke(d, new object[] { parameters });
            }
            else
            {
                if (browser != null)
                {
                    string html =
                    "<html>" +
                    "<head></head>" +
                    "<body>" +

                    GetCopyrightString() +

                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/external-embedding/embed-widget-screener.js\">" +
                    "{" +

                    GetForexSizeString(parameters.autosize, parameters.width, parameters.height) +
                    "\"defaultColumn\": \"" + parameters.defaultColumn + "\"," +
                    "\"screener_type\": \"crypto_mkt\"," +
                    "\"displayCurrency\": \"" + parameters.displayCurrency + "\"," +
                    "\"locale\": \"en\"" +

                    "}" +
                    "</script>" +
                    "</body></html>";
                    //LogManager.AddLogMessage(this.Name, "setCryptocurrencyMarket", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }

        // Fundamental Chart Widget
        delegate void setFundamentalChartCallback(TradingViewFundamentalChartParameters parameters);
        public void setFundamentalChart(TradingViewFundamentalChartParameters parameters)
        {
            if (this.InvokeRequired)
            {
                setFundamentalChartCallback d = new setFundamentalChartCallback(setFundamentalChart);
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
                    //"<div id=\"container\">" +
                    "<span id=\"tradingview-copyright\">Fundamental data is powered by <a href=\"http://www.tradingview.com\" rel=\"nofollow\" target=\"_blank\" style=\"color: #3BB3E4\">TradingView</a></span>" +
                    "<script type=\"text/javascript\" src=\"https://s3.tradingview.com/tv.js\"></script>" +
                    "<script type=\"text/javascript\">" +
                    "new TradingView.widget({" +
                    GetSizeString(parameters.autosize, parameters.width, parameters.height) +
                    "\"symbol\": \"" + symbolString + "\"," +
                    "\"interval\": \"" + GetInterval(parameters.interval) + "\"," +
                    //"\"timezone\": \"America/New_York\"," +
                    "\"theme\": \"" + parameters.theme + "\"," +
                    //"\"style\": \"" + parameters.style.GetHashCode() + "\"," +
                    
                    "\"toolbar_bg\": \"" + parameters.toolbarBackgroundColor + "\"," +

                    "\"fundamental\": \"Script$EDGR_DEGREE_OF_COMBINED_LEVERAGE_V2@tv-scripting\"," +
                    "\"percentage\": " + GetBoolean(parameters.percentageScale) + "," +

                    //"\"enable_publishing\": " + GetBoolean(parameters.EnablePublishing) + "," +
                    //"\"withdateranges\": " + GetBoolean(parameters.ShowBottomToolbar) + "," +
                    "\"hide_top_toolbar\": " + GetBoolean(parameters.ShowTopToolbar) + "," +
                    "\"hide_side_toolbar\": " + GetBoolean(parameters.ShowDrawingToolsBar) + "," +
                    "\"allow_symbol_change\": " + GetBoolean(parameters.AllowSymbolChange) + "," +
                    "\"save_image\": " + GetBoolean(parameters.GetImageButton) + "," +
                    GetPopupString(parameters.LaunchInPopupButton, parameters.popupWidth, parameters.popupHeight) +
                    GetReferralString(parameters.ActivateReferralProgram, parameters.referral_id) +
                    // LAST ENTRY
                    "\"locale\": \"en\"" +
                    "});" +
                    "</script>" +
                    "</div>" +
                    "</body></html>";
                    LogManager.AddLogMessage(this.Name, "setAdvancedChart", html, LogManager.LogMessageType.DEBUG);
                    browser.LoadHtml(html, "http://rendering/");
                }
            }
        }
        #endregion
    }
}