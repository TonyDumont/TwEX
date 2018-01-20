using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            toolStripLabel_btc.Image = ExchangeManager.GetSymbolIcon("BTC");
            toolStripLabel_usd.Image = ExchangeManager.GetSymbolIcon("USDT");
            toolStripLabel_symbol.Image = ExchangeManager.GetSymbolIcon(symbol);
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
                toolStripLabel_symbol.Image = ExchangeManager.GetSymbolIcon(symbol);
                UpdateUI(true);
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

                    if (list.Count > 0)
                    {              
                        toolStrip_btc.Visible = true;
                        toolStrip_usd.Visible = true;
                        toolStrip_symbol.Visible = true;

                        Decimal high = 0;
                        Decimal low = 0;

                        high = list[0].last;

                        foreach (ExchangeManager.ExchangeTicker ticker in list)
                        {
                            if (ticker.last > 0)
                            {
                                low = ticker.last;
                            }
                        }
                            
                        Decimal spread = high - low;
                        listView.SetObjects(list);   
                        toolStripLabel_symbol.Text = CoinMarketCap.GetMarketCapBTCAmount(symbol, spread).ToString("N8");
                        //LogManager.AddLogMessage(Name, "UpdateUI", "symbol=" + symbol + " | " + market + " | " + high + " | " + low + " | " + spread);

                        if (market.Contains("USD"))
                        {
                            // SPREAD IS IN USD
                            LogManager.AddLogMessage(Name, "UpdateUI", "SPREAD IN USD - symbol=" + symbol + " | " + market + " | " + high + " | " + low + " | " + spread);
                            toolStripLabel_usd.Text = spread.ToString("C");
                            toolStripLabel_btc.Text = CoinMarketCap.GetMarketCapBTCAmount("USDT", spread).ToString("N8");
                            toolStripLabel_symbol.Text = CoinMarketCap.GetMarketCapCoinAmount(symbol, "USDT", spread).ToString("N8");
                        }
                        else
                        {
                            // SPREAD IS IN BTC
                            LogManager.AddLogMessage(Name, "UpdateUI", "SPREAD IN BTC - symbol=" + symbol + " | " + market + " | " + high + " | " + low + " | " + spread);
                            toolStripLabel_usd.Text = CoinMarketCap.GetMarketCapUSDAmount("BTC", spread).ToString("C");
                            toolStripLabel_btc.Text = spread.ToString("N8");
                            toolStripLabel_symbol.Text = CoinMarketCap.GetMarketCapCoinAmount(symbol, "BTC", spread).ToString("N8");
                        }               
                    }

                    if (list.Sum(item => item.last) > 0)
                    {
                        Enabled = true;
                    }
                    else
                    {
                        Enabled = false;
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
                toolStrip_btc.Font = ParentForm.Font;
                toolStrip_usd.Font = ParentForm.Font;
                toolStripLabel_symbol.Font = ParentForm.Font;

                textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);
                rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;
                iconSize = rowHeight - 2;

                column_icon.Width = iconSize + 2;
                column_price.Width = textSize.Width + padding;

                int listHeight = 0;
                int listWidth = 0;

                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 1];
                    listHeight = listView.Top + last.Bounds.Bottom + (padding * 2);
                    listWidth = column_icon.Width + column_price.Width + (padding * 2);
                }
                
                ClientSize = new Size(listWidth, listHeight + toolStripLabel_symbol.Height + toolStripLabel_btc.Height + toolStripLabel_usd.Height);
            }
        }
        #endregion

        #region AspectGetters
        public object aspect_icon(object rowObject)
        {
            ExchangeManager.ExchangeTicker ticker = (ExchangeManager.ExchangeTicker)rowObject;
            int size = listView.RowHeightEffective - 4;

            if (ticker.last > 0)
            {
                if (ticker != null)
                {
                    return ContentManager.ResizeImage(ExchangeManager.getExchangeIcon(ticker.exchange), iconSize, iconSize);
                }
                else
                {
                    return Properties.Resources.ConnectionStatus_DISABLED;
                }
            }
            else
            {
                return Properties.Resources.ConnectionStatus_DISABLED;
            }
        }
        public object aspect_price(object rowObject)
        {
            ExchangeManager.ExchangeTicker ticker = (ExchangeManager.ExchangeTicker)rowObject;
            if (ticker.last > 0)
            {
                if (ticker.market.Contains("USD"))
                {
                    return ticker.last.ToString("C");
                }
                else
                {
                    return ticker.last.ToString("N8");
                }
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}