using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.ExchangeManager;

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
        private Label balanceLabel = new Label()
        {
            Name = "balanceLabel",
            Dock = DockStyle.None,
            //BackColor = Color.Black,
            //ForeColor = Color.White,
            //Width = 65
        };
        public string market { get; set; } = String.Empty;
        public string symbol { get; set; } = String.Empty;
        public ArbitrageManagerControl manager;
        #endregion

        #region Initialize
        public ArbitrageItemControl()
        {
            InitializeComponent();
        }
        private void ArbitrageItemControl_Load(object sender, EventArgs e)
        {         
            panel.Height = PreferenceManager.ArbitragePreferences.minChartHeight + 5;

            //statusLabel.BackgroundImageLayout = ImageLayout.Tile;
            //statusLabel.Parent = panel;
            balanceLabel.AutoSize = true;
            balanceLabel.BorderStyle = BorderStyle.Fixed3D;
            balanceLabel.BackgroundImage = null;
            balanceLabel.BackColor = Color.Transparent;
            balanceLabel.TextAlign = ContentAlignment.MiddleLeft;
            //balanceLabel.Text = "00000.00000000";

            panel.Controls.Add(balanceLabel);
            //statusLabel.Location.Y = panel.Height;
            //statusLabel.Width = panel.Width;
            balanceLabel.Location = new Point(9, panel.Height - (balanceLabel.Height + 10));
            panel.Controls.Add(chart);
            //statusLabel.BringToFront();
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
                        if (manager.WatchList.ShowCharts && chart != null)
                        {
                            chart.updateBrowser();
                            SetBalance();
                        }

                        if (manager.WatchList.ShowLists)
                        {
                            arbitrageListControl_btc.UpdateUI(resize);
                            arbitrageListControl_usd.UpdateUI(resize);
                        }

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
                Width = PreferenceManager.ArbitragePreferences.minChartWidth;  
                int rowHeight = toolStrip.Height;

                int listHeight = 0;

                if (manager.WatchList.ShowLists)
                {
                    arbitrageListControl_btc.Visible = true;
                    arbitrageListControl_usd.Visible = true;
                    listHeight = (PreferenceManager.ArbitragePreferences.maxListCount * rowHeight) + (rowHeight * 3) + (rowHeight / 4);
                }
                else
                {
                    arbitrageListControl_btc.Visible = false;
                    arbitrageListControl_usd.Visible = false;
                }

                if (manager.WatchList.ShowCharts)
                {
                    toolStrip.Visible = false;
                    panel.Visible = true;
                    listHeight = listHeight + PreferenceManager.ArbitragePreferences.minChartHeight + (rowHeight / 4);
                }
                else
                {
                    toolStrip.Visible = true;
                    panel.Visible = false;
                    toolStripLabel_symbol.Text = symbol.ToUpper();
                    toolStripLabel_symbol.Image = ContentManager.GetSymbolIcon(symbol);
                }
                ClientSize = new Size(Width, listHeight);
                Size = new Size(Width, listHeight);
                Visible = true;
            }
        }

        private void SetBalance()
        {
            List<ExchangeBalance> balances = Balances.Where(item => item.Symbol == symbol).ToList();
            List<ExchangeBalance> wallets = WalletManager.GetWalletBalancesBySymbol(symbol);          
            balances.AddRange(wallets);

            Decimal balance = balances.Sum(item => item.Balance);
            Decimal usd = balances.Sum(item => item.TotalInUSD);

            if (balance > 0)
            {
                balanceLabel.Text = balance.ToString("N8") + " (" + usd.ToString("C") + ")";
                balanceLabel.Visible = true;
            }
            else
            {
                balanceLabel.Visible = false;
            }
        }

        delegate void SetDataCallback(string symbol, string market, bool resize = false);
        public void SetData(string newSymbol, string newMarket, bool resize = false)
        {
            if (InvokeRequired)
            {
                SetDataCallback d = new SetDataCallback(SetData);
                Invoke(d, new object[] { symbol, market, resize });
            }
            else
            {            
                symbol = newSymbol;
                market = newMarket;

                arbitrageListControl_btc.SetProperties("BTC", symbol);
                arbitrageListControl_usd.SetProperties("USD", symbol);
                chart.setChart(symbol, market, PreferenceManager.ArbitragePreferences.ChartPeriod);
                UpdateUI(resize);
            }
        }
        #endregion
    }
}