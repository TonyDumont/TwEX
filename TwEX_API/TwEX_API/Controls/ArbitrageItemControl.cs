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
        //private Timer timer = new Timer() { Interval = 60000 };

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
            //timer.Tick += new EventHandler(timer_Tick);
            //timer.Start();
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
                    //LogManager.AddLogMessage(Name, "UpdateUI", "symbol=" + symbol + " | market=" + market, LogManager.LogMessageType.OTHER);
                    toolStripLabel_symbol.Text = symbol.ToUpper();

                    if (PreferenceManager.preferences.ArbitragePreferences.ShowCharts)
                    {
                        toolStrip.Visible = false;
                        panel.Visible = true;
                        chart.updateBrowser();
                    }
                    else
                    {
                        toolStrip.Visible = true;
                        panel.Visible = false;
                    }

                    arbitrageListControl_btc.UpdateUI(resize);
                    arbitrageListControl_usd.UpdateUI(resize);

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
                int padding = textSize.Width / 10;
                int rowHeight = textSize.Height;
                int iconSize = rowHeight;

                int newWidth = 0;

                foreach (Control control in flowLayoutPanel.Controls)
                {
                    newWidth += control.Width;
                }

                Width = newWidth + (padding * 2);

                if (PreferenceManager.preferences.ArbitragePreferences.ShowCharts)
                {
                    toolStrip.Visible = false;
                    panel.Visible = true;
                    panel.Width = Width;
                    panel.Height = Width - (Width / 5);
                    Size = new Size(Width, arbitrageListControl_usd.ClientSize.Height + panel.Height + padding);
                }
                else
                {
                    toolStrip.Visible = true;
                    panel.Visible = false;
                    panel.Height = 0;
                    Size = new Size(Width, arbitrageListControl_usd.ClientSize.Height + toolStrip.Height + padding);
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