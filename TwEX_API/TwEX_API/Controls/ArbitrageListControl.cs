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
            toolStripLabel_btc.Image = ContentManager.GetSymbolIcon("BTC");
            toolStripLabel_usd.Image = ContentManager.GetSymbolIcon("USDT");
            toolStripLabel_symbol.Image = ContentManager.GetSymbolIcon(symbol);
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
                toolStripLabel_symbol.Image = ContentManager.GetSymbolIcon(symbol);
                UpdateUI(true);
            }
        }

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
                            if (list.Count > PreferenceManager.ArbitragePreferences.maxListCount)
                            {
                                PreferenceManager.ArbitragePreferences.maxListCount = list.Count;
                            }
                            //arbitrageItem.SetListCount(listView.Items.Count);

                            toolStripLabel_symbol.Text = CoinMarketCap.GetMarketCapBTCAmount(symbol, spread).ToString("N8");
                            //LogManager.AddLogMessage(Name, "UpdateUI", "symbol=" + symbol + " | " + market + " | " + high + " | " + low + " | " + spread);

                            if (market.Contains("USD"))
                            {
                                // SPREAD IS IN USD
                                //LogManager.AddLogMessage(Name, "UpdateUI", "SPREAD IN USD - symbol=" + symbol + " | " + market + " | " + high + " | " + low + " | " + spread);
                                toolStripLabel_usd.Text = spread.ToString("C");
                                toolStripLabel_btc.Text = CoinMarketCap.GetMarketCapBTCAmount("USDT", spread).ToString("N8");
                                toolStripLabel_symbol.Text = CoinMarketCap.GetMarketCapCoinAmount(symbol, "USDT", spread).ToString("N8");
                            }
                            else
                            {
                                // SPREAD IS IN BTC
                                //LogManager.AddLogMessage(Name, "UpdateUI", "SPREAD IN BTC - symbol=" + symbol + " | " + market + " | " + high + " | " + low + " | " + spread);
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
                }
                catch (Exception ex)
                {
                    //LogManager.AddLogMessage(Name, "UpdateUI", symbol + " | " + market + " | " + ex.Message, LogManager.LogMessageType.EXCEPTION);
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
                ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                toolStrip_btc.Font = ParentForm.Font;
                toolStrip_usd.Font = ParentForm.Font;
                toolStripLabel_symbol.Font = ParentForm.Font;
                
                int rowHeight = toolStrip_usd.Height;

                //int listHeight = ExchangeManager.Exchanges.Where(exchange => exchange.Active).Count() * rowHeight;
                int listHeight = PreferenceManager.ArbitragePreferences.maxListCount * rowHeight;
                
                int newHeight = rowHeight + listHeight;
                ClientSize = new Size(Width, newHeight);
                Size = new Size(Width, newHeight);
                
            }
        }
        #endregion

        #region Getters
        public object aspect_icon(object rowObject)
        {
            ExchangeManager.ExchangeTicker ticker = (ExchangeManager.ExchangeTicker)rowObject;

            if (ticker.last > 0)
            {
                if (ticker != null)
                {
                    return ContentManager.ResizeImage(ContentManager.GetExchangeIcon(ticker.exchange), listView.RowHeightEffective, listView.RowHeightEffective);
                }
                else
                {
                    return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
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