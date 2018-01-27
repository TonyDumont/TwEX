﻿using System;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using TwEX_API.Market;
using static TwEX_API.Market.CryptoCompare;
using System.Text;

namespace TwEX_API.Controls
{
    public partial class CryptoCompareWidgetControl : UserControl
    {
        #region Properties
        public ChromiumWebBrowser browser;
        private string symbol = string.Empty;
        private string market = string.Empty;
        public bool hideScrollbars = false;
        public CryptoCompareWidgetType widgetType = CryptoCompareWidgetType.Chart;
        private CryptoCompareChartPeriod period = CryptoCompareChartPeriod.Day_1D;
        private CryptoCompareFeedType feedType = CryptoCompareFeedType.CoinTelegraph;
        #endregion Properties

        #region Initialize
        public CryptoCompareWidgetControl()
        {
            InitializeComponent();
            InitializeBrowser();
        }
        private void CryptoCompareWidgetControl_Load(object sender, EventArgs e)
        {
            // LOAD
            /*
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            var missingDeps = CefSharp.DependencyChecker.CheckDependencies(true, false, dir, string.Empty,
                Path.Combine(dir, "CefSharp.BrowserSubprocess.exe"));
            if (missingDeps?.Count > 0)
                throw new InvalidOperationException("Missing components:\r\n  " + string.Join("\r\n  ", missingDeps));
            // ReSharper disable once UnusedVariable
            var browser = new CefSharp.Wpf.ChromiumWebBrowser(); //test, if browser can be instantiated
            */
            //updateBrowser();
        }
        public void InitializeBrowser()
        {
            //Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser(String.Empty) { Dock = DockStyle.Fill };
            browser.FrameLoadEnd += OnBrowserFrameLoadEnd;
            browser.LoadingStateChanged += OnLoadingStateChanged;
            panel.Controls.Add(browser);
            //browser.Dock = DockStyle.Fill;
        }
        private void OnBrowserFrameLoadEnd(object sender, FrameLoadEndEventArgs args)
        {
            //LogManager.AddLogMessage(Name, "OnBrowserFrameLoadEnd", sender.ToString() + " | " + args.Frame.IsMain, LogManager.LogMessageType.DEBUG);
            if (args.Frame.IsMain && hideScrollbars)
            {
                args
                    .Browser
                    .MainFrame
                    .ExecuteJavaScriptAsync(
                    "document.body.style.overflow = 'hidden'");
            }
        }
        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            //Wait for while page to finish loading not just the first frame
            //LogManager.AddLogMessage(Name, "OnLoadingStateChanged", sender.ToString() + " | " + args.IsLoading, LogManager.LogMessageType.DEBUG);

            if (!args.IsLoading)
            {
                browser.LoadingStateChanged -= OnLoadingStateChanged;
                //LogManager.AddLogMessage(Name, "OnLoadingStateChanged", "LOADED!!!", LogManager.LogMessageType.DEBUG);
                //This is required when using a standard TaskCompletionSource
                //Extension method found in the CefSharp.Internals namespace
                //tcs.TrySetResultAsync(true);
            }
        }
        #endregion Initialize

        #region Getters
        private string getHtmlString()
        {
            string html =

                    "<html>" +
                    "<head></head>" +
                    "<body>" +
                    //"<body bgcolor=\"" + ColorTranslator.ToHtml(ApplicationManager.BackgroundColor_browser) + "\">" +
                    "<body bgcolor=\"" + PreferenceManager.preferences.BrowserBackgroundColor + "\">" +

                    "<div id = \"container\">" +

                    "<script type=\"text/javascript\">" +
                    "baseUrl=\"https://widgets.cryptocompare.com/\";" +
                    "var scripts = document.getElementsByTagName(\"script\");" +
                    "var embedder = scripts[scripts.length - 1];" +

                    GetThemeString() +

                    "(function(){" +
                        "var appName = encodeURIComponent(window.location.hostname);" +
                        "if (appName == \"\") { appName = \"local\"; }" +
                        "var s = document.createElement(\"script\");" +
                        "s.type = \"text/javascript\";" +
                        "s.async = true;" +

                        // THIS IS WHAT NEEDS TO BE CONDITIONED
                        //"var theUrl = baseUrl + 'serve/v1/coin/feed?fsym=" + symbol + "&tsym=" + market + "&feedType=CoinTelegraph'';" +
                        getUrl() +

                        "s.src = theUrl + (theUrl.indexOf(\"?\") >= 0 ? \"&\" : \"?\") + \"app=\" + appName;" +
                        "embedder.parentNode.appendChild(s);" +
                        "})();" +
                    "</script>" +

                    "</div>" +
                    "</body></html>";

            return html;
        }
        private string getUrl()
        {
            string url = string.Empty;
            switch (widgetType)
            {
                case CryptoCompare.CryptoCompareWidgetType.Chart:
                    if (period != CryptoCompareChartPeriod.Day_1D)
                    {
                        //string description = EnumUtils.GetDescription(period);
                        string[] periodSplit = period.ToString().Split('_');
                        url = "var theUrl=baseUrl+'serve/v1/coin/chart?fsym=" + symbol + "&tsym=" + market + "&period=" + periodSplit[1] + "';";
                    }
                    else
                    {
                        url = "var theUrl=baseUrl+'serve/v1/coin/chart?fsym=" + symbol + "&tsym=" + market + "';";
                    }
                    break;

                case CryptoCompare.CryptoCompareWidgetType.NewsFeed:
                    url = "var theUrl=baseUrl+'serve/v1/coin/feed?fsym=" + symbol + "&tsym=" + market + "&feedType=" + feedType + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.PricesList:
                    url = "var theUrl=baseUrl+'serve/v1/coin/list?fsym=" + symbol + "&tsyms=" + market + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.PricesTiles:
                    url = "var theUrl=baseUrl+'serve/v1/coin/tiles?fsym=" + symbol + "&tsyms=" + market + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Tabbed:
                    url = "var theUrl=baseUrl+'serve/v1/coin/multi?fsyms=" + symbol + "&tsyms=" + market + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Horizontal:
                    url = "var theUrl=baseUrl+'serve/v1/coin/header?fsym=" + symbol + "&tsyms=" + market + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Summary:
                    url = "var theUrl=baseUrl+'serve/v1/coin/summary?fsym=" + symbol + "&tsyms=" + market + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Historical:
                    url = "var theUrl=baseUrl+'serve/v1/coin/histo_week?fsym=" + symbol + "&tsym=" + market + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.ChartAdvanced:
                    url = "var theUrl=baseUrl+'serve/v3/coin/chart?fsym=" + symbol + "&tsyms=" + market + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.Converter:
                    url = "var theUrl=baseUrl+'serve/v1/coin/converter?fsym=" + symbol + "&tsyms=" + market + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.HeaderV2:
                    url = "var theUrl=baseUrl+'serve/v2/coin/header?fsyms=" + symbol + "&tsyms=" + market + "';";
                    break;

                case CryptoCompare.CryptoCompareWidgetType.HeaderV3:
                    url = "var theUrl=baseUrl+'serve/v3/coin/header?fsyms=" + symbol + "&tsyms=" + market + "';";
                    break;

                default:
                    LogManager.AddLogMessage(Name, "getUrl", "type NOT DEFINED : " + widgetType, LogManager.LogMessageType.DEBUG);
                    break;
            }
            return url;
        }
        private string GetThemeString()
        {
            
            if (PreferenceManager.CryptoComparePreferences.Theme != "Default")
            {

                StringBuilder builder = new StringBuilder();
                builder.Append("var cccTheme = ");
                builder.Append("{\"General\":{\"background\":\"#333\",\"borderColor\":\"#545454\",\"borderRadius\":\"4px 4px 0 0\"},");
                builder.Append("\"Header\":{\"background\":\"#000\",\"color\":\"#FFF\",\"displayFollowers\":false},");
                builder.Append("\"Followers\":{\"background\":\"#f7931a\",\"color\":\"#FFF\",\"borderColor\":\"#e0bd93\",\"counterBorderColor\":\"#fdab48\",\"counterColor\":\"#f5d7b2\"},");
                builder.Append("\"Data\":{\"priceColor\":\"#FFF\",\"infoLabelColor\":\"#CCC\",\"infoValueColor\":\"#CCC\"},");
                builder.Append("\"Chart\":{\"fillColor\":\"rgba(86,202,158,0.5)\",\"borderColor\":\"#56ca9e\"},\"Conversion\":{\"background\":\"#000\",\"color\":\"#999\"}};");


                //var cccTheme = 
                //{ "General":{ "background":"#333","borderColor":"#545454","borderRadius":"4px 4px 0 0"},
                //"Header":{ "background":"#000","color":"#FFF"},
                //"Followers":{ "background":"#f7931a","color":"#FFF","borderColor":"#e0bd93","counterBorderColor":"#fdab48","counterColor":"#f5d7b2"},
                //"Data":{ "priceColor":"#FFF","infoLabelColor":"#CCC","infoValueColor":"#CCC"},
                //"Chart":{ "fillColor":"rgba(86,202,158,0.5)","borderColor":"#56ca9e"},"Conversion":{ "background":"#000","color":"#999"}};


            //builder.AppendLine();
            //builder.Append("1 cat").AppendLine();

            // Get a reference to the StringBuilder's buffer content.
            //string innerString = builder.ToString();
            //string script = @"var cccTheme={"General":{"background":"#333","borderColor":"#545454","borderRadius":"4px 4px 0 0"},"Header":{ "background":"#000","color":"#FFF"},"Followers":{ "background":"#f7931a","color":"#FFF","borderColor":"#e0bd93","counterBorderColor":"#fdab48","counterColor":"#f5d7b2"},"Data":{ "priceColor":"#FFF","infoLabelColor":"#CCC","infoValueColor":"#CCC"},"Chart":{ "fillColor":"rgba(86,202,158,0.5)","borderColor":"#56ca9e"},"Conversion":{ "background":"#000","color":"#999"}";
            //return "var cccTheme={\"General\":{\"background\":\"#333\",\"borderColor\":\"#545454\",\"borderRadius\":\"4px 4px 0 0\"},\"Header\":{ \"background\":\"#000\",\"color\":\"#FFF\"},\"Followers\":{ \"background\":\"#f7931a\",\"color\":\"#FFF\",\"borderColor\":\"#e0bd93\",\"counterBorderColor\":\"#fdab48\",\"counterColor\":\"#f5d7b2\"},\"Data\":{\"priceColor\":\"#FFF\",\"infoLabelColor\":\"#CCC\",\"infoValueColor\":\"#CCC\"},\"Chart\":{\"fillColor\":\"rgba(86,202,158,0.5)\",\"borderColor\":\"#56ca9e\"},\"Conversion\":{\"background\":\"#000\",\"color\":\"#999\"};";
            return builder.ToString();
            }
            else
            {
                return String.Empty;
            }
            
            //return String.Empty;
        }
        #endregion Getters

        #region Updaters
        delegate void updateBrowserCallback();
        public void updateBrowser()
        {
            if (this.browser.InvokeRequired)
            {
                updateBrowserCallback d = new updateBrowserCallback(updateBrowser);
                this.browser.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    string html = getHtmlString();
                    browser.LoadHtml(html, "http://rendering/");
                    browser.Refresh();
                    //browser.Refresh();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "updateBrowser", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }
        #endregion

        #region Delegates
        // DELEGATE (Chart Widget)
        delegate void setChartCallback(string newSymbol, string newMarket, CryptoCompareChartPeriod newPeriod);
        public void setChart(string newSymbol, string newMarket, CryptoCompareChartPeriod newPeriod)
        {
            if (this.InvokeRequired)
            {
                setChartCallback d = new setChartCallback(setChart);
                this.Invoke(d, new object[] { newSymbol, newMarket, newPeriod });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    period = newPeriod;
                    widgetType = CryptoCompareWidgetType.Chart;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setChartWidget", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (News Feed)
        delegate void setNewsFeedCallback(string newSymbol, string newMarket, CryptoCompareFeedType newFeedType);
        public void setNewsFeed(string newSymbol, string newMarket, CryptoCompareFeedType newFeedType)
        {
            if (this.InvokeRequired)
            {
                setNewsFeedCallback d = new setNewsFeedCallback(setNewsFeed);
                this.Invoke(d, new object[] { newSymbol, newMarket, newFeedType });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    feedType = newFeedType;
                    widgetType = CryptoCompareWidgetType.NewsFeed;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setNewsFeed", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Prices List Widget)
        delegate void setPricesListCallback(string newSymbol, string newMarket);
        public void setPricesList(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setPricesListCallback d = new setPricesListCallback(setPricesList);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.PricesList;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setPricesList", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Prices Tiles Widget)
        delegate void setPricesTilesCallback(string newSymbol, string newMarket);
        public void setPricesTiles(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setPricesTilesCallback d = new setPricesTilesCallback(setPricesTiles);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.PricesTiles;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setPricesTiles", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Tabbed Widget)
        delegate void setTabbedCallback(string newSymbol, string newMarket);
        public void setTabbed(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setTabbedCallback d = new setTabbedCallback(setTabbed);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.Tabbed;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setTabbed", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Horizontal Widget)
        delegate void setHorizontalCallback(string newSymbol, string newMarket);
        public void setHorizontal(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setHorizontalCallback d = new setHorizontalCallback(setHorizontal);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.Horizontal;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setHorizontal", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Summary Widget)
        delegate void setSummaryCallback(string newSymbol, string newMarket);
        public void setSummary(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setSummaryCallback d = new setSummaryCallback(setSummary);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.Summary;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setTabbed", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Historical Widget)
        delegate void setHistoricalCallback(string newSymbol, string newMarket);
        public void setHistorical(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setHistoricalCallback d = new setHistoricalCallback(setHistorical);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.Historical;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setHistorical", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Advanced Chart Widget)
        delegate void setAdvancedChartCallback(string newSymbol, string newMarket);
        public void setAdvancedChart(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setAdvancedChartCallback d = new setAdvancedChartCallback(setAdvancedChart);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.ChartAdvanced;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setAdvancedChart", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Converter Widget)
        delegate void setConverterCallback(string newSymbol, string newMarket);
        public void setConverter(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setConverterCallback d = new setConverterCallback(setConverter);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.Converter;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setAdvancedChart", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Header V2 Widget)
        delegate void setHeaderV2Callback(string newSymbol, string newMarket);
        public void setHeaderV2(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setHeaderV2Callback d = new setHeaderV2Callback(setHeaderV2);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.HeaderV2;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setHeaderV2", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        // DELEGATE (Header V3 Widget)
        delegate void setHeaderV3Callback(string newSymbol, string newMarket);
        public void setHeaderV3(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                setHeaderV3Callback d = new setHeaderV3Callback(setHeaderV3);
                this.Invoke(d, new object[] { newSymbol, newMarket });
            }
            else
            {
                try
                {
                    symbol = newSymbol;
                    market = newMarket;
                    widgetType = CryptoCompareWidgetType.HeaderV3;
                    updateBrowser();
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(this.Name, "setHeaderV3", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }
        #endregion
    }

}


/*
                    if (ApplicationManager.NightMode == true)
                    {
                        browser.BackColor = Color.Black;
                    }else
                    {
                        browser.BackColor = Color.White;
                    }
                    */
//LogManager.AddDebugMessage(Name, "UpdateUI", "1 colcount=" + listView.OLVGroups. .CollapsedGroups.Count());

/*
                string html =
                "<html>" +
                "<head></head>" +
                "<body>" +
                //"<body bgcolor=\"" + ColorTranslator.ToHtml(ApplicationManager.BackgroundColor_browser) + "\">" +

                "<div id = \"container\">" +

                "<script type=\"text/javascript\">" +
                "baseUrl=\"https://widgets.cryptocompare.com/\";" +
                "var scripts = document.getElementsByTagName(\"script\");" +
                "var embedder = scripts[scripts.length - 1];" +

                //GetThemeString() +

                "(function(){" +
                    "var appName = encodeURIComponent(window.location.hostname);" +
                    "if (appName == \"\") { appName = \"local\"; }" +
                    "var s = document.createElement(\"script\");" +
                    "s.type = \"text/javascript\";" +
                    "s.async = true;" +
                    "var theUrl = baseUrl + 'serve/v1/coin/chart?fsym=" + symbol + "&tsym=" + market + "';" +
                    "s.src = theUrl + (theUrl.indexOf(\"?\") >= 0 ? \"&\" : \"?\") + \"app=\" + appName;" +
                    "embedder.parentNode.appendChild(s);" +
                    "})();" +
                "</script>" +

                "</div>" +
                "</body></html>";
                */

/*
// DELEGATE (Chart Advanced)
delegate void SetChartAdvancedCallback(string symbol);
public void SetChartAdvanced(string symbol)
{
    if (this.InvokeRequired)
    {
        SetChartAdvancedCallback d = new SetChartAdvancedCallback(SetChartAdvanced);
        this.Invoke(d, new object[] { symbol });
    }
    else
    {
        string html =
        "<html>" +
        "<head></head>" +
        "<body>" +
        //GetBodyString() +
        //"<body bgcolor=\"" + ColorTranslator.ToHtml(ApplicationManager.BackgroundColor_browser) + "\">" +

        "<div id = \"container\">" +

        "<script type=\"text/javascript\">" +
        "baseUrl=\"https://widgets.cryptocompare.com/\";" +
        "var scripts = document.getElementsByTagName(\"script\");" +
        "var embedder = scripts[scripts.length - 1];" +

        //GetThemeString() +

        "(function(){" +
            "var appName = encodeURIComponent(window.location.hostname);" +
            "if(appName==\"\"){appName=\"local\";}" +
            "var s = document.createElement(\"script\");" +
            "s.type = \"text/javascript\";" +
            "s.async = true;" +
            "var theUrl = baseUrl+'serve/v3/coin/chart?fsym=" + symbol + "&tsyms=USD,BTC,CAD';" +
            "s.src = theUrl+(theUrl.indexOf(\"?\") >= 0 ? \"&\" : \"?\") + \"app=\" + appName;" +
            "embedder.parentNode.appendChild(s);" +
        "})();" +
        "</script>" +

        "</div>" +
        "</body></html>";

        browser.LoadHtml(html, "http://rendering/");
    }
}

// DELEGATE (News Feed)
delegate void setNewsFeedCallback(string symbol, string market);
public void setNewsFeed(string symbol, string market)
{
    if (this.InvokeRequired)
    {
        setNewsFeedCallback d = new setNewsFeedCallback(setNewsFeed);
        this.Invoke(d, new object[] { symbol, market });
    }
    else
    {
        try
        {
            string html =

            "<html>" +
            "<head></head>" +
            "<body>" +
            //"<body bgcolor=\"" + ColorTranslator.ToHtml(ApplicationManager.BackgroundColor_browser) + "\">" +

            "<div id = \"container\">" +

            "<script type=\"text/javascript\">" +
            "baseUrl=\"https://widgets.cryptocompare.com/\";" +
            "var scripts = document.getElementsByTagName(\"script\");" +
            "var embedder = scripts[scripts.length - 1];" +

            //GetThemeString() +

            "(function(){" +
                "var appName = encodeURIComponent(window.location.hostname);" +
                "if (appName == \"\") { appName = \"local\"; }" +
                "var s = document.createElement(\"script\");" +
                "s.type = \"text/javascript\";" +
                "s.async = true;" +



                "var theUrl = baseUrl + 'serve/v1/coin/feed?fsym=" + symbol + "&tsym=" + market + "&feedType=CoinTelegraph'';" +



                "s.src = theUrl + (theUrl.indexOf(\"?\") >= 0 ? \"&\" : \"?\") + \"app=\" + appName;" +
                "embedder.parentNode.appendChild(s);" +
                "})();" +
            "</script>" +

            "</div>" +
            "</body></html>";

            browser.LoadHtml(html, "http://rendering/");

        }
        catch (Exception ex)
        {
            LogManager.AddLogMessage(this.Name, "setChartWidget", ex.Message, LogManager.LogMessageType.EXCEPTION);
        }
    }
}

// DELEGATE (setWidget)
delegate void setWidgetCallback(string symbol, string market);
public void setWidget(string symbol, string market)
{
    if (this.InvokeRequired)
    {
        setWidgetCallback d = new setWidgetCallback(setWidget);
        this.Invoke(d, new object[] { symbol, market });
    }
    else
    {
        try
        {
            string html =

            "<html>" +
            "<head></head>" +
            "<body>" +
            //"<body bgcolor=\"" + ColorTranslator.ToHtml(ApplicationManager.BackgroundColor_browser) + "\">" +

            "<div id = \"container\">" +

            "<script type=\"text/javascript\">" +
            "baseUrl=\"https://widgets.cryptocompare.com/\";" +
            "var scripts = document.getElementsByTagName(\"script\");" +
            "var embedder = scripts[scripts.length - 1];" +

            //GetThemeString() +

            "(function(){" +
                "var appName = encodeURIComponent(window.location.hostname);" +
                "if (appName == \"\") { appName = \"local\"; }" +
                "var s = document.createElement(\"script\");" +
                "s.type = \"text/javascript\";" +
                "s.async = true;" +



                "var theUrl = baseUrl + 'serve/v1/coin/feed?fsym=" + symbol + "&tsym=" + market + "&feedType=CoinTelegraph'';" +



                "s.src = theUrl + (theUrl.indexOf(\"?\") >= 0 ? \"&\" : \"?\") + \"app=\" + appName;" +
                "embedder.parentNode.appendChild(s);" +
                "})();" +
            "</script>" +

            "</div>" +
            "</body></html>";

            browser.LoadHtml(html, "http://rendering/");

        }
        catch (Exception ex)
        {
            LogManager.AddLogMessage(this.Name, "setChartWidget", ex.Message, LogManager.LogMessageType.EXCEPTION);
        }
    }

}
*/
