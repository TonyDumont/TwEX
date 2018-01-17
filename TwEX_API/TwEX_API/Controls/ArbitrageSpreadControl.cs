using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class ArbitrageSpreadControl : UserControl
    {

        #region Properties
        public string market = String.Empty;
        public string symbol = String.Empty;

        //public static Size textSize = new Size(10, 10);
        //private int iconSize = 18;
        //private int rowHeight = 10;

        //private ToolTip tooltip = new ToolTip();
        #endregion

        public ArbitrageSpreadControl()
        {
            InitializeComponent();
        }

        private void ArbitrageSpreadControl_Load(object sender, EventArgs e)
        {
            ResizeUI();
        }

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
            if (this.InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                this.Invoke(d, new object[] { resize });
            }
            else
            {
                try
                {
                    List<ExchangeManager.ExchangeTicker> list = ExchangeManager.GetPriceWatchlist(market, symbol);
                    LogManager.AddLogMessage(Name, "UpdateUI", "count=" + list.Count, LogManager.LogMessageType.DEBUG);

                    /*
                    if (list.Count > 0 && tableLayoutPanel.RowCount > 1)
                    {
                        int rowIndex = 0;
                        Decimal high = list[0].last;
                        Decimal low = 0;

                        foreach (ExchangeManager.ExchangeTicker ticker in list)
                        {
                            Button button = tableLayoutPanel.GetControlFromPosition(0, rowIndex) as Button;
                            Label label = tableLayoutPanel.GetControlFromPosition(1, rowIndex) as Label;
                            //Control c = tableLayoutPanel.GetControlFromPosition(1, rowIndex);
                            //LogManager.AddLogMessage(Name, "UpdateUI", "Name=" + c.Name + " | " + c.GetType() + " | " + label.Text, LogManager.LogMessageType.DEBUG);
                            toolTip.SetToolTip(button, ticker.exchange);
                            button.Tag = ticker.exchange;
                            //button.

                            button.BackgroundImage = ContentManager.ResizeImage(ExchangeManager.getExchangeIcon(ticker.exchange), iconSize, iconSize);

                            if (market.Contains("USD"))
                            {
                                //return e.last.ToString("C");
                                label.Text = ticker.last.ToString("C");
                            }
                            else
                            {
                                //return String.Format("{0:#,#.00000000}", e.last);
                                label.Text = ticker.last.ToString("N8");
                            }

                            if (ticker.last > 0)
                            {
                                low = ticker.last;
                            }
                            rowIndex++;
                        }
                        Decimal spread = high - low;

                        Label btcLabel = tableLayoutPanel.GetControlFromPosition(0, list.Count) as Label;
                        Label usdLabel = tableLayoutPanel.GetControlFromPosition(0, list.Count + 1) as Label;

                        if (market.Contains("USD"))
                        {
                            usdLabel.Text = spread.ToString("C");
                            btcLabel.Text = CoinMarketCap.GetMarketCapBTCAmount("BTC", spread).ToString("N8");
                        }
                        else
                        {
                            usdLabel.Text = CoinMarketCap.GetMarketCapUSDAmount("BTC", spread).ToString("C");
                            btcLabel.Text = spread.ToString("N8");
                        }
                    }
                    */
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
                LogManager.AddLogMessage(Name, "ResizeUI", "RESIZING", LogManager.LogMessageType.DEBUG);
                Size textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);

                flowLayoutPanel.Controls.Clear();

                foreach(ExchangeManager.Exchange exchange in ExchangeManager.Exchanges)
                {
                    Button button = new Button() { Text = exchange.Name, Height = textSize.Height, Width = textSize.Width * 2 };
                    flowLayoutPanel.Controls.Add(button);
                }

                flowLayoutPanel.Size = flowLayoutPanel.PreferredSize;
                //Width = flowLayoutPanel.Width;
                //Height = flowLayoutPanel.Height * 2;
                //Size textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);


                //int padding = textSize.Height / 4;
                //int rowPadding = textSize.Height / 5;
                //int rowHeight = textSize.Height + rowPadding;

                //iconSize = rowHeight;

                //int columnCount = 2;
                /*
                int rowCount = ExchangeManager.Exchanges.Count;

                tableLayoutPanel.Controls.Clear();

                tableLayoutPanel.ColumnStyles.Clear();
                tableLayoutPanel.RowStyles.Clear();

                tableLayoutPanel.ColumnCount = columnCount;
                tableLayoutPanel.RowCount = rowCount;

                tableLayoutPanel.Margin = new Padding(0);
                tableLayoutPanel.Padding = new Padding(0);

                for (int x = 0; x < tableLayoutPanel.ColumnCount; x++)
                {
                    // add a column
                    if (x < 1)
                    {
                        // IMAGE
                        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, iconSize));
                    }
                    else
                    {
                        // LABEL
                        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    }

                    for (int y = 0; y < rowCount; y++)
                    {
                        //Next, add a row. Only do this when creating the first column
                        if (x == 0)
                        {
                            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
                        }

                        if (x < 1)
                        {
                            Button button = new Button() { Text = "", Dock = DockStyle.Fill, Margin = new Padding(0), Padding = new Padding(0) };

                            tableLayoutPanel.Controls.Add(button, x, y);
                        }
                        else
                        {
                            Label label = new Label() { TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill };
                            label.Text = string.Format("({0}, {1})", x, y);
                            tableLayoutPanel.Controls.Add(label, x, y);
                        }
                    }
                }
                
                // ADD 2 more rows for BTC / USD spreads
                tableLayoutPanel.RowCount = tableLayoutPanel.RowCount + 1;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
                Label btcLabel = new Label() { Text = "BTC : 0.00000000", Dock = DockStyle.Fill };
                tableLayoutPanel.Controls.Add(btcLabel, 0, tableLayoutPanel.RowCount - 1);
                tableLayoutPanel.SetColumnSpan(btcLabel, 2);

                tableLayoutPanel.RowCount = tableLayoutPanel.RowCount + 1;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
                Label usdLabel = new Label() { Text = "USD : $0.00", Dock = DockStyle.Fill };
                tableLayoutPanel.Controls.Add(usdLabel, 0, tableLayoutPanel.RowCount - 1);
                tableLayoutPanel.SetColumnSpan(usdLabel, 2);
                */


                /*
                Width = iconSize + textSize.Width;
                Height = (rowHeight + rowPadding) * (rowCount + 3);
                    */
/*
                tableLayoutPanel.Size = tableLayoutPanel.PreferredSize;

                Size = tableLayoutPanel.Size;
                UpdateUI();
                */
            }
        }
        #endregion

        
    }
}
