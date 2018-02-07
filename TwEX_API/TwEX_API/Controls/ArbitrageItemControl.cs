using System;
using System.Drawing;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class ArbitrageItemControl : UserControl
    {
        #region Properties
        private CryptoCompareWidgetControl chart = new CryptoCompareWidgetControl()
        {
            widgetType = Market.CryptoCompare.CryptoCompareWidgetType.Chart,
            Dock = DockStyle.Fill,
            hideScrollbars = true
        };
        public string market { get; set; } = String.Empty;
        public string symbol { get; set; } = String.Empty;
        #endregion

        #region Initialize
        public ArbitrageItemControl()
        {
            InitializeComponent();
        }
        private void ArbitrageItemControl_Load(object sender, EventArgs e)
        {            
            panel.Height = PreferenceManager.ArbitragePreferences.minChartHeight;
            panel.Controls.Add(chart);
            UpdateUI(true);
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
            if (InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                Invoke(d, new object[] { resize });
            }
            else
            {
                try
                {
                    if (symbol.Length > 0 && market.Length > 0)
                    {

                        if (PreferenceManager.ArbitragePreferences.ShowCharts)
                        {
                            toolStrip.Visible = false;
                            panel.Visible = true;
                            
                            if (chart != null)
                            {
                                chart.updateBrowser();
                            }
                        }
                        else
                        {
                            toolStrip.Visible = true;
                            panel.Visible = false;
                            toolStripLabel_symbol.Text = symbol.ToUpper();
                            toolStripLabel_symbol.Image = ContentManager.GetSymbolIcon(symbol);
                        }

                        arbitrageListControl_btc.UpdateUI(resize);
                        arbitrageListControl_usd.UpdateUI(resize);

                        if (resize)
                        {
                            ResizeUI();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "UpdateUI", symbol + " | " + market + " | " + ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        delegate void ResizeUICallback();
        public void ResizeUI()
        {
            if (InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {
                toolStrip.Font = ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                Width = PreferenceManager.ArbitragePreferences.minChartWidth;  
                int rowHeight = toolStrip.Height;
                int listHeight = PreferenceManager.ArbitragePreferences.maxListCount * rowHeight;
                int newHeight = listHeight + (rowHeight * 3) + (rowHeight / 4);
                
                if (PreferenceManager.ArbitragePreferences.ShowCharts)
                {
                    newHeight = newHeight + (rowHeight * 3);
                }
                //LogManager.AddLogMessage(Name, "ResizeUI", "tsHeight=" + toolStrip.Height + " | " + listHeight + " | " + newHeight, LogManager.LogMessageType.DEBUG);
                ClientSize = new Size(Width, newHeight);
                Size = new Size(Width, newHeight);
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
                
                symbol = newSymbol;
                market = newMarket;

                arbitrageListControl_btc.SetProperties("BTC", symbol);
                arbitrageListControl_usd.SetProperties("USD", symbol);
                //LogManager.AddLogMessage(this.Name, "SetData", symbol + " | " + market, LogManager.LogMessageType.DEBUG);
                chart.setChart(symbol, market, Market.CryptoCompare.CryptoCompareChartPeriod.Day_1D);
                UpdateUI(true);
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