using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;
using TwEX_API.Market;

namespace TwEX_API.Controls
{
    public partial class ArbitrageListControl : UserControl
    {
        #region Properties
        public string market = String.Empty;
        public string symbol = String.Empty;
        private Size textSize = new Size(10, 10);
        private int iconSize = 18;
        private int rowHeight = 10;
        #endregion

        #region Initialize
        public ArbitrageListControl()
        {
            InitializeComponent();
        }
        private void ArbitrageListControl_Load(object sender, EventArgs e)
        {
            column_icon.ImageGetter = new ImageGetterDelegate(aspect_icon);
            column_price.AspectGetter = new AspectGetterDelegate(aspect_price);
        }
        #endregion

        #region Delegates
        delegate void SetPropertiesCallback(string newMarket, string newSymbol);
        public void SetProperties(string newMarket, string newSymbol)
        {
            if (this.InvokeRequired)
            {
                SetPropertiesCallback d = new SetPropertiesCallback(SetProperties);
                this.Invoke(d, new object[] { newMarket, newSymbol });
            }
            else
            {
                market = newMarket;
                symbol = newSymbol;
            }
        }

        delegate void UpdateUICallback(bool resize = false);
        public void UpdateUI(bool resize = false)
        {
            if (this.listView.InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                this.listView.Invoke(d, new object[] { resize });
            }
            else
            {           
                try
                {
                    List<ExchangeManager.ExchangeTicker> list = ExchangeManager.GetPriceWatchlist(market, symbol);
                    //LogManager.AddLogMessage(Name, "UpdateUI", "count=" + list.Count, LogManager.LogMessageType.DEBUG);

                    if (list.Count > 0)
                    {
                        Decimal high = 0;
                        Decimal low = 0;

                        high = list[0].last;
                        low = list[list.Count - 1].last;

                        Decimal spread = high - low;

                        listView.SetObjects(list);

                        if (market.Contains("USD"))
                        {
                            toolStripLabel_usd.Text = spread.ToString("C");
                            toolStripLabel_btc.Text = CoinMarketCap.GetMarketCapBTCAmount("BTC", spread).ToString("N8");
                        }
                        else
                        {
                            toolStripLabel_usd.Text = CoinMarketCap.GetMarketCapUSDAmount("BTC", spread).ToString("C");
                            toolStripLabel_btc.Text = spread.ToString("N8");
                        }
                    }
                    
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
                textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);
                rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;
                iconSize = rowHeight - 2;

                column_icon.Width = iconSize + 2;
                column_price.Width = textSize.Width + padding;

                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 1];
                    listView.Size = new Size(column_icon.Width + column_price.Width + padding, listView.Top + last.Bounds.Bottom + padding);
                }

                toolStrip_btc.Font = ParentForm.Font;
                toolStrip_usd.Font = ParentForm.Font;
                ClientSize = new Size(listView.Width, listView.Height + toolStripLabel_btc.Height + toolStripLabel_usd.Height + 4);
            }
        }
        #endregion

        #region AspectGetters
        public object aspect_icon(object rowObject)
        {
            ExchangeManager.ExchangeTicker ticker = (ExchangeManager.ExchangeTicker)rowObject;
            int size = listView.RowHeightEffective - 4;

            if (ticker != null)
            {
                return ContentManager.ResizeImage(ExchangeManager.getExchangeIcon(ticker.exchange), iconSize, iconSize);
            }
            else
            {
                return Properties.Resources.ConnectionStatus_DISABLED;
            }
        }
        public object aspect_price(object rowObject)
        {
            ExchangeManager.ExchangeTicker e = (ExchangeManager.ExchangeTicker)rowObject;
            if (e.market.Contains("USD"))
            {
                return e.last.ToString("C");
            }
            else
            {
                return String.Format("{0:#,#.00000000}", e.last);
            }
        }
        #endregion
    }
}