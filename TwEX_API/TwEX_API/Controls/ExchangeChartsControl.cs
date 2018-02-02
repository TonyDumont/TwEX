using System;
using System.Windows.Forms;
using TwEX_API.Market;
using static TwEX_API.Market.TradingView;

namespace TwEX_API.Controls
{
    public partial class ExchangeChartsControl : UserControl
    {
        #region Properties
        private string symbol = "BTC";
        private string market = "USD";
        private string ExchangeName = String.Empty;
        private ExchangeManager.Exchange Exchange;

        private CryptoCompareWidgetControl cryptoCompare = new CryptoCompareWidgetControl()
        {
            Dock = DockStyle.Fill,
            widgetType = Market.CryptoCompare.CryptoCompareWidgetType.ChartAdvanced
        };
        private TradingViewWidgetControl tradingView = new TradingViewWidgetControl()
        {
            Dock = DockStyle.Fill,
        };
        #endregion

        #region Initialize
        public ExchangeChartsControl()
        {
            InitializeComponent();
        }
        private void ExchangeChartsControl_Load(object sender, EventArgs e)
        {
            toolStripRadioButton_CryptoCompare.Image = ContentManager.GetIcon("CryptoCompare");
            toolStripRadioButton_TradingView.Image = ContentManager.GetIcon("TradingView");

            cryptoCompare.setAdvancedChart("BTC", "USD");

            tabPage_CryptoCompare.Controls.Add(cryptoCompare);
            tabPage_TradingView.Controls.Add(tradingView);

        }
        #endregion

        #region Delegates

        delegate bool SetExchangeCallback(string exchange);
        public bool SetExchange(string exchange)
        {
            if (InvokeRequired)
            {
                SetExchangeCallback d = new SetExchangeCallback(SetExchange);
                Invoke(d, new object[] { });
            }
            else
            {
                ExchangeName = exchange;
                Exchange = ExchangeManager.getExchange(ExchangeName);

                if (Exchange.TradingView.Length > 0)
                {
                    toolStripRadioButton_TradingView.Visible = true;
                    toolStripRadioButton_TradingView.Checked = true;
                    tabControl.SelectedIndex = 1;
                }
                else
                {
                    toolStripRadioButton_TradingView.Visible = false;
                    toolStripRadioButton_CryptoCompare.Checked = true;
                    tabControl.SelectedIndex = 0;
                }
                UpdateUI(true);
            }
            return true;
        }

        delegate bool SetChartsCallback(string targetSymbol, string targetMarket);
        public bool SetCharts(string targetSymbol, string targetMarket)
        {
            if (InvokeRequired)
            {
                SetChartsCallback d = new SetChartsCallback(SetCharts);
                Invoke(d, new object[] { targetSymbol, targetMarket });
            }
            else
            {
                //ExchangeName = exchange;
                symbol = targetSymbol;
                market = targetMarket;

                toolStripLabel_symbol.Text = symbol;
                toolStripLabel_symbol.Image = ContentManager.GetSymbolIcon(symbol);
                toolStripLabel_market.Text = market;
                toolStripLabel_market.Image = ContentManager.GetSymbolIcon(market);

                cryptoCompare.setAdvancedChart(symbol, market);

                if (Exchange.TradingView.Length > 0)
                {
                    TradingViewAdvancedChartParameters parameters = new TradingViewAdvancedChartParameters()
                    {
                        exchange = (TradingViewCryptoExchange)Enum.Parse(typeof(TradingViewCryptoExchange), Exchange.TradingView, true),
                        allow_symbol_change = false,
                        hide_top_toolbar = false,
                        hide_side_toolbar = false,
                        withdateranges = true,
                        symbol = symbol,
                        market = market
                    };
                    tradingView.setAdvancedChart(parameters);
                }

                UpdateUI(true);
            }
            return true;
        }

        delegate bool UpdateUICallback(bool resize = false);
        public bool UpdateUI(bool resize = false)
        {
            if (InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                Invoke(d, new object[] { resize });
            }
            else
            {
                //toolStripLabel_symbol.Text = symbol + " / " + market;
                //cryptoCompare.setAdvancedChart(symbol, market);
                /*
                List<ExchangeManager.ExchangeBalance> list = ExchangeManager.Balances.Where(item => item.Exchange == ExchangeName && item.Balance > 0).ToList();
                listView.SetObjects(list);
                toolStripLabel_title.Text = list.Count + " Balances";
                toolStripLabel_totals.Text = "(" + list.Sum(item => item.TotalInUSD).ToString("C") + ") " + list.Sum(item => item.TotalInBTC).ToString("N8");
                //List<ExchangeManager.ExchangeBalance> list = ExchangeManager.Balances.Where(item => item.Balance > 0).ToList();
                */

                if (resize)
                {
                    ResizeUI();
                }
            }
            return true;
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
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                
                Font = PreferenceManager.preferences.Font;
                toolStrip.Font = Font;
                //listView.Font = Font;
                /*
                Size textSize = TextRenderer.MeasureText("0.00000000", Font);

                int rowHeight = listView.RowHeightEffective;
                int iconSize = rowHeight;

                toolStrip.ImageScalingSize = new Size(iconSize, iconSize);

                column_Symbol.Width = textSize.Width;

                column_Balance.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                column_Orders.Width = textSize.Width;
                column_TotalInBTC.Width = textSize.Width;
                column_TotalInUSD.Width = textSize.Width;

                int listWidth = 0;
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    //col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //col.Width = col.Width + (rowHeight / 2);
                    listWidth += col.Width;
                }
                PreferredWidth = listWidth + (iconSize * 2);
                */
                //LogManager.AddLogMessage(Name, "ResizeUI", "PreferredWidth = " + PreferredWidth);
            }
        }
        #endregion

        #region EventHandlers
        private void radioButton_Click(object sender, EventArgs e)
        {
            ToolStripRadioButton item = (ToolStripRadioButton)sender;

            if (item.Text == "CryptoCompare")
            {
                tabControl.SelectedIndex = 0;
            }
            else
            {
                tabControl.SelectedIndex = 1;
            }

            UpdateUI(true);
        }
        #endregion
    }
}
