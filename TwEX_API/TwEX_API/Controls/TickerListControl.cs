using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Controls
{
    public partial class TickerListControl : UserControl
    {
        #region Properties
        private string ExchangeName = String.Empty;
        private string CurrentMarket = "ALL";
        public int PreferredWidth = 0;

        public ExchangeChartsControl chartControl;
        #endregion

        #region Initialize
        public TickerListControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void TickerListControl_Load(object sender, EventArgs e)
        {
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_symbol.ImageGetter = new ImageGetterDelegate(aspect_symbol);
            column_change.AspectGetter = new AspectGetterDelegate(aspect_change);
            column_last.AspectGetter = new AspectGetterDelegate(aspect_last);
            column_market.ImageGetter = new ImageGetterDelegate(aspect_market);
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

                List<ExchangeManager.ExchangeTicker> list = ExchangeManager.Tickers.Where(item => item.exchange == ExchangeName).ToList();
                //LogManager.AddDebugMessage(this.Name, "ExchangeTickerListControl_Load", "list count=" + list.Count + " | " + exchange);
                var markets = list.Select(p => p.market).OrderByDescending(m => m).Distinct();
                //List<string> markets = list.Select(p => p.market).Distinct().ToList();
                //markets = markets.Sort(item => item.ToString());
                // CLEAR MARKET BUTTONS
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item.Alignment == ToolStripItemAlignment.Right)
                    {
                        toolStrip.Items.Remove(item);
                    }
                }

                

                foreach (string market in markets)
                {
                    //LogManager.AddDebugMessage(this.Name, "ExchangeTickerListControl_Load", "market=" + market.ToString());
                    ToolStripRadioButton button = new ToolStripRadioButton()
                    {
                        Text = market,
                        RadioButtonGroupId = 1,
                        Alignment = ToolStripItemAlignment.Right
                    };
                    button.Click += new EventHandler(marketButton_Click);
                    toolStrip.Items.Add(button);
                    toolStrip.Items.Add(new ToolStripSeparator() { Alignment = ToolStripItemAlignment.Right });
                    
                }

                ToolStripRadioButton allButton = new ToolStripRadioButton()
                {
                    Text = "ALL",
                    RadioButtonGroupId = 1,
                    Checked = true,
                    Alignment = ToolStripItemAlignment.Right
                };
                allButton.Click += new EventHandler(marketButton_Click);
                toolStrip.Items.Add(allButton);

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
                List<ExchangeManager.ExchangeTicker> list = ExchangeManager.Tickers.Where(item => item.exchange == ExchangeName).ToList();
                //LogManager.AddLogMessage(Name, "UpdateUI", "selectedMarket=" + CurrentMarket, LogManager.LogMessageType.DEBUG);

                if (CurrentMarket == "ALL")
                {
                    column_market.IsVisible = true;
                    listView.SetObjects(list);
                }
                else
                {
                    // FILTER BY MARKET SYMBOL
                    column_market.IsVisible = false;
                    listView.SetObjects(list.Where(item => item.market == CurrentMarket));
                }
                toolStripLabel_title.Text = listView.Items.Count + " TICKERS";

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
                //toolStrip_header2.Font = ParentForm.Font;
                listView.RebuildColumns();
                listView.Font = Font;

                Size textSize = TextRenderer.MeasureText("0.00000000", Font);

                int rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;

                int iconSize = rowHeight;

                toolStrip.ImageScalingSize = new Size(iconSize, iconSize);
                int listWidth = 0;

                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + padding;
                    listWidth += col.Width;
                }

                column_symbol.Width += iconSize;
                listWidth += iconSize;
                PreferredWidth = listWidth + (iconSize * 2);
                //LogManager.AddLogMessage(Name, "ResizeUI", "PreferredWidth = " + PreferredWidth);
            }
        }
        #endregion

        #region Getters
        public object aspect_change(object rowObject)
        {
            ExchangeManager.ExchangeTicker item = (ExchangeManager.ExchangeTicker)rowObject;
            Decimal percent = item.change * 100;

            return String.Format("{0:#,#.00}", percent) + "%";
            /*
            if (ticker.pair.Contains("USDT_"))
            {
                //return String.Format("{0:#,#.00}", ticker.last);
                return String.Format("{0:#,#.00}", percent) + "%";
            }
            else
            {
                return String.Format("{0:#,#.00}", percent) + "%";
            }
            */
        }
        public object aspect_last(object rowObject)
        {
            ExchangeManager.ExchangeTicker item = (ExchangeManager.ExchangeTicker)rowObject;

            if (item.market.Contains("USD"))
            {
                return item.last.ToString("C");
            }
            else
            {
                return String.Format("{0:#,#.00000000}", item.last);
            }
        }      
        public object aspect_symbol(object rowObject)
        {
            try
            {
                //ExchangeBalance balance = (ExchangeBalance)rowObject;
                ExchangeManager.ExchangeTicker item = (ExchangeManager.ExchangeTicker)rowObject;
                //return DataManager.ResizeImage(ExchangeManager.GetExchangeImage(e.Exchange), 32, 32);
                return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(item.symbol), listView.RowHeightEffective, listView.RowHeightEffective);
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "aspect_symbol", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
            }
        }
        public object aspect_market(object rowObject)
        {
            try
            {
                //ExchangeBalance balance = (ExchangeBalance)rowObject;
                ExchangeManager.ExchangeTicker item = (ExchangeManager.ExchangeTicker)rowObject;
                //return DataManager.ResizeImage(ExchangeManager.GetExchangeImage(e.Exchange), 32, 32);
                return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(item.market), listView.RowHeightEffective, listView.RowHeightEffective);
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "aspect_symbol", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
            }
        }
        #endregion

        #region EventHandlers
        private void marketButton_Click(object sender, EventArgs e)
        {
            ToolStripRadioButton item = (ToolStripRadioButton)sender;
            CurrentMarket = item.Text;
            //LogManager.AddLogMessage(Name, "marketButton_Click", "marketClicked=" + marketClicked);
            UpdateUI(true);
        }
        #endregion

        private void listView_ItemActivate(object sender, EventArgs e)
        {
            if (listView.SelectedObject != null)
            {
                ExchangeTicker ticker = listView.SelectedObject as ExchangeTicker;
                LogManager.AddLogMessage(Name, "listView_ItemActivate", ticker.exchange + " | " + ticker.symbol + " | " + ticker.market);
                if (chartControl != null)
                {
                    chartControl.SetCharts(ticker.symbol, ticker.market);
                }

            }
        }
    }
}
