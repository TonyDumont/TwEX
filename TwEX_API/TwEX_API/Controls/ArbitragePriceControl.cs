using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TwEX_API.Market;
using BrightIdeasSoftware;

namespace TwEX_API.Controls
{
    public partial class ArbitragePriceControl : UserControl
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
        public ArbitragePriceControl()
        {
            InitializeComponent();
            InitializeColulmns();
        }
        private void ArbitragePriceControl_Load(object sender, EventArgs e)
        {
            panel.Height = PreferenceManager.ArbitragePreferences.minChartHeight;
            panel.Controls.Add(chart);
            UpdateUI(true);
        }
        private void InitializeColulmns()
        {
            column_btc_icon.ImageGetter = new ImageGetterDelegate(aspect_icon);
            column_btc_price.AspectGetter = new AspectGetterDelegate(aspect_price);
            column_usd_icon.ImageGetter = new ImageGetterDelegate(aspect_icon);
            column_usd_price.AspectGetter = new AspectGetterDelegate(aspect_price);
            toolStripLabel_btc_btc.Image = ContentManager.GetSymbolIcon("BTC");
            toolStripLabel_btc_usd.Image = ContentManager.GetSymbolIcon("USDT");
            toolStripLabel_usd_btc.Image = ContentManager.GetSymbolIcon("BTC");
            toolStripLabel_usd_usd.Image = ContentManager.GetSymbolIcon("USDT");
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

                        if (PreferenceManager.ArbitragePreferences.ShowCharts && chart != null)
                        {
                            chart.updateBrowser();
                        }

                        //arbitrageListControl_btc.UpdateUI(resize);
                        UpdateBTCList();
                        UpdateUSDList();
                        //arbitrageListControl_usd.UpdateUI(resize);

                        if (resize)
                        {
                            ResizeUI();
                        }
                    }
                }
                catch (Exception)
                {
                    //LogManager.AddLogMessage(Name, "UpdateUI", symbol + " | " + market + " | " + ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
        }

        private void UpdateBTCList()
        {
            if (symbol.Length > 0 && market.Length > 0)
            {
                List<ExchangeManager.ExchangeTicker> list = ExchangeManager.GetPriceWatchlist("BTC", symbol);

                if (list.Count > 0)
                {
                    toolStrip_btc_btc.Visible = true;
                    toolStrip_btc_usd.Visible = true;
                    toolStrip_btc_symbol.Visible = true;

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
                    
                    toolStripLabel_btc_symbol.Text = CoinMarketCap.GetMarketCapBTCAmount(symbol, spread).ToString("N8");

                    if (listView_btc.Items.Count > 0)
                    {
                        //listView_btc.RefreshObjects(list);
                        listView_btc.BuildList();
                        //listView_btc.UpdateObjects(iEnumerable);
                    }
                    else
                    {
                        listView_btc.SetObjects(list);
                    }
                    //LogManager.AddLogMessage(Name, "UpdateUI", "symbol=" + symbol + " | " + market + " | " + high + " | " + low + " | " + spread);
                    toolStripLabel_btc_usd.Text = CoinMarketCap.GetMarketCapUSDAmount("BTC", spread).ToString("C");
                    toolStripLabel_btc_btc.Text = spread.ToString("N8");
                    toolStripLabel_symbol.Text = CoinMarketCap.GetMarketCapCoinAmount(symbol, "BTC", spread).ToString("N8");
                }

                if (list.Sum(item => item.last) > 0)
                {
                    Enabled = true;
                }
                else
                {
                    Enabled = false;
                }
            }
        }

        private void UpdateUSDList()
        {
            if (symbol.Length > 0 && market.Length > 0)
            {
                List<ExchangeManager.ExchangeTicker> list = ExchangeManager.GetPriceWatchlist("USD", symbol);

                if (list.Count > 0)
                {
                    toolStrip_usd_btc.Visible = true;
                    toolStrip_usd_usd.Visible = true;
                    toolStrip_usd_symbol.Visible = true;

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
                    

                    toolStripLabel_usd_symbol.Text = CoinMarketCap.GetMarketCapBTCAmount(symbol, spread).ToString("N8");
                    //LogManager.AddLogMessage(Name, "UpdateUI", "symbol=" + symbol + " | " + market + " | " + high + " | " + low + " | " + spread);
                    if (listView_usd.Items.Count > 0)
                    {
                        //listView_usd.RefreshObjects(list);
                        listView_usd.BuildList();
                    }
                    else
                    {
                        listView_usd.SetObjects(list);
                    }


                    if (market.Contains("USD"))
                    {
                        // SPREAD IS IN USD
                        //LogManager.AddLogMessage(Name, "UpdateUI", "SPREAD IN USD - symbol=" + symbol + " | " + market + " | " + high + " | " + low + " | " + spread);
                        toolStripLabel_usd_usd.Text = spread.ToString("C");
                        toolStripLabel_usd_btc.Text = CoinMarketCap.GetMarketCapBTCAmount("USDT", spread).ToString("N8");
                        toolStripLabel_usd_symbol.Text = CoinMarketCap.GetMarketCapCoinAmount(symbol, "USDT", spread).ToString("N8");
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
                Visible = false;
                //toolStrip.Font = ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                Width = PreferenceManager.ArbitragePreferences.minChartWidth;
                int rowHeight = toolStrip.Height;
                int listHeight = PreferenceManager.ArbitragePreferences.maxListCount * rowHeight;
                int newHeight = listHeight + (rowHeight * 3) + (rowHeight / 4);

                if (PreferenceManager.ArbitragePreferences.ShowCharts)
                {
                    toolStrip.Visible = false;
                    panel.Visible = true;
                    newHeight = newHeight + PreferenceManager.ArbitragePreferences.minChartHeight + (rowHeight / 4);
                }
                else
                {
                    toolStrip.Visible = true;
                    panel.Visible = false;
                    toolStripLabel_symbol.Text = symbol.ToUpper();
                    toolStripLabel_symbol.Image = ContentManager.GetSymbolIcon(symbol);
                }

                //LogManager.AddLogMessage(Name, "ResizeUI", "tsHeight=" + toolStrip.Height + " | " + listHeight + " | " + newHeight, LogManager.LogMessageType.DEBUG);
                ClientSize = new Size(Width, newHeight);
                Size = new Size(Width, newHeight);
                Visible = true;
            }
        }

        delegate void SetDataCallback(string symbol, string market);
        public void SetData(string newSymbol, string newMarket)
        {
            if (InvokeRequired)
            {
                SetDataCallback d = new SetDataCallback(SetData);
                Invoke(d, new object[] { symbol, market });
            }
            else
            {
                symbol = newSymbol;
                market = newMarket;

                toolStripLabel_symbol.Image = ContentManager.GetSymbolIcon(symbol);
                //arbitrageListControl_btc.SetProperties("BTC", symbol);              
                toolStripLabel_btc_symbol.Image = ContentManager.GetSymbolIcon(symbol);
                //UpdateUI(true);
                toolStripLabel_usd_symbol.Image = ContentManager.GetSymbolIcon(symbol);
                //arbitrageListControl_usd.SetProperties("USD", symbol);

                //LogManager.AddLogMessage(this.Name, "SetData", symbol + " | " + market, LogManager.LogMessageType.DEBUG);
                chart.setChart(symbol, market, CryptoCompare.CryptoCompareChartPeriod.Day_1D);
                UpdateUI();
            }
        }
        #endregion

        #region Getters
        public object aspect_icon(object rowObject)
        {
            ExchangeManager.ExchangeTicker ticker = (ExchangeManager.ExchangeTicker)rowObject;
            int rowHeight = listView_usd.RowHeightEffective;

            if (ticker.last > 0)
            {
                if (ticker != null)
                {
                    return ContentManager.ResizeImage(ContentManager.GetExchangeIcon(ticker.exchange), rowHeight, rowHeight);
                }
                else
                {
                    return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, rowHeight, rowHeight);
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
