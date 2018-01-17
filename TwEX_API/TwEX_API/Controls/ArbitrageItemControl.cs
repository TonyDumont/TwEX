using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class ArbitrageItemControl : UserControl
    {
        #region Properties
        public string market { get; set; } = String.Empty;
        public string symbol { get; set; } = String.Empty;
        private Timer timer = new Timer() { Interval = 60000 };

        private CryptoCompareWidgetControl chart = new CryptoCompareWidgetControl()
        {
            widgetType = Market.CryptoCompare.CryptoCompareWidgetType.Chart,
            Dock = DockStyle.Fill,
            hideScrollbars = true
        };
        #endregion

        #region Initialize
        public ArbitrageItemControl()
        {
            InitializeComponent();
        }
        private void ArbitrageItemControl_Load(object sender, EventArgs e)
        {
            panel.Controls.Add(chart);
            UpdateUI(true);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }
        #endregion

        #region Delegate
        delegate void UpdateUICallback(bool resize = false);
        public void UpdateUI(bool resize = false)
        {
            if (this.InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                this.Invoke(d, new object[] { resize });
            }
            else
            {
                try
                {
                    
                    LogManager.AddLogMessage(Name, "UpdateUI", "symbol=" + symbol + " | market=" + market, LogManager.LogMessageType.OTHER);
                    toolStripLabel_symbol.Text = symbol.ToUpper();

                    if (PreferenceManager.preferences.ArbitragePreferences.ShowCharts)
                    {
                        //panel.Height = Height / 2;
                        //tableLayoutPanel.RowStyles[0].SizeType = SizeType.Percent;
                        //tableLayoutPanel.RowStyles[0].Height = 50;
                        toolStrip.Visible = false;
                        panel.Visible = true;

                        chart.updateBrowser();
                        /*
                        string html =
                        "<html>" +
                        "<head></head>" +

                        "<body bgcolor=\"" + ColorTranslator.ToHtml(PreferenceManager.BackgroundColor_browser) + "\">" +

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
                            "var theUrl = baseUrl + 'serve/v1/coin/chart?fsym=" + symbol + "&tsym=USD';" +
                            "s.src = theUrl + (theUrl.indexOf(\"?\") >= 0 ? \"&\" : \"?\") + \"app=\" + appName;" +
                            "embedder.parentNode.appendChild(s);" +
                            "})();" +
                        "</script>" +

                        "</div>" +
                        "</body></html>";

                        browser.LoadHtml(html, "http://rendering/");
                        browser.Refresh();
                        */
                    }
                    else
                    {
                        //panel.Height = 0;
                        //tableLayoutPanel.RowStyles[0].Height = 0;
                        
                        toolStrip.Visible = true;
                        panel.Visible = false;
                    }

                    arbitrageListControl_btc.UpdateUI(resize);
                    arbitrageListControl_usd.UpdateUI(resize);
                    //arbitrageTableControl_btc.UpdateUI(resize);
                    //arbitrageTableControl_usd.UpdateUI(resize);
                    //arbitrageSpreadControl_btc.UpdateUI(resize);
                    //arbitrageSpreadControl_usd.UpdateUI(resize);
                    if (resize)
                    {
                        ResizeUI();                        
                    }
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "UpdateUI", ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                Size textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);
                int padding = textSize.Height / 4;
                int rowPadding = textSize.Height / 5;
                int rowHeight = textSize.Height + rowPadding;

                int iconSize = rowHeight;

                int newWidth = 0;

                foreach (Control control in flowLayoutPanel.Controls)
                {
                    newWidth += control.Width;
                }

                //Width = (iconSize + textSize.Width + padding) * 2 + (padding * 2);
                Width = newWidth + (padding * 5);

                if (PreferenceManager.preferences.ArbitragePreferences.ShowCharts)
                {
                    toolStrip.Visible = false;
                    panel.Visible = true;
                    panel.Width = Width;
                    panel.Height = Width - (Width / 5);

                    //Height = (rowHeight * (ExchangeManager.Exchanges.Count + 3)) + panel.Height + (rowPadding * 4);
                    //var last = listView.Items[listView.Items.Count - 1];
                    Size = new Size(Width, arbitrageListControl_usd.ClientSize.Height + panel.Height + (rowPadding * 4));
                }
                else
                {
                    toolStrip.Visible = true;
                    panel.Visible = false;
                    panel.Height = 0;
                    Size = new Size(Width, arbitrageListControl_usd.ClientSize.Height + toolStrip.Height + (rowPadding * 4));
                    //Height = (rowHeight * (ExchangeManager.Exchanges.Count + 3)) + toolStrip.Height + (rowPadding * 4);
                }
                UpdateUI();
            }
        }

        delegate void SetDataCallback(string symbol, string market);
        public void SetData(string newSymbol, string newMarket)
        {
            if (this.InvokeRequired)
            {
                SetDataCallback d = new SetDataCallback(SetData);
                this.Invoke(d, new object[] { symbol, market });
            }
            else
            {
                //LogManager.AddDebugMessage(this.Name, "SetPairCallback", symbol);  
                symbol = newSymbol;
                market = newMarket;

                arbitrageListControl_btc.SetProperties("USD", symbol);
                arbitrageListControl_usd.SetProperties("BTC", symbol);

                chart.setChart(symbol, market, Market.CryptoCompare.CryptoCompareChartPeriod.Day_1D);
                //arbitrageTableControl_btc.SetProperties("BTC", symbol);
                //arbitrageTableControl_usd.SetProperties("USD", symbol);
                //arbitrageSpreadControl_btc.SetProperties("BTC", symbol);
                //arbitrageSpreadControl_usd.SetProperties("USD", symbol);
                UpdateUI();
            }
        }
        #endregion

        #region Getters
        private string GetThemeString()
        {

            if (PreferenceManager.NightMode == true)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("var cccTheme = ");
                builder.Append("{\"General\":{\"background\":\"#333\",\"borderColor\":\"#545454\",\"borderRadius\":\"4px 4px 0 0\",\"textColor\":\"" + ColorTranslator.ToHtml(PreferenceManager.BackgroundColor_text) + "\"},");
                builder.Append("\"Header\":{\"background\":\"#000\",\"color\":\"#FFF\",\"displayFollowers\":false},");
                builder.Append("\"Followers\":{\"background\":\"#f7931a\",\"color\":\"#FFF\",\"borderColor\":\"#e0bd93\",\"counterBorderColor\":\"#fdab48\",\"counterColor\":\"#f5d7b2\"},");
                builder.Append("\"Data\":{\"priceColor\":\"#FFF\",\"infoLabelColor\":\"#CCC\",\"infoValueColor\":\"#CCC\"},");
                builder.Append("\"Chart\":{\"fillColor\":\"rgba(86,202,158,0.5)\",\"borderColor\":\"#56ca9e\"},");
                builder.Append("\"Trend\":{\"colorUp\":\"#baffba\",\"colorDown\":\"#ffbaba\"},");
                builder.Append("\"Conversion\":{\"background\":\"#000\",\"color\":\"#999\"}};");
                return builder.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
        #endregion

        #region EventHandlers
        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;

            switch (item.Tag.ToString())
            {
                case "up":
                    PreferenceManager.MoveWatchlistItem(market, symbol, "up");
                    break;

                case "down":
                    PreferenceManager.MoveWatchlistItem(market, symbol, "down");
                    break;

                case "refresh":
                    //PreferenceManager.RemoveWatchlistItem(market, symbol);
                    UpdateUI();
                    break;

                case "remove":
                    PreferenceManager.RemoveWatchlistItem(market, symbol);
                    break;

                default:
                    //icon = Properties.Resources.CardRoom_Unknown;
                    break;
            }
            
        }
        #endregion
    }
}