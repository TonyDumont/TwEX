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
        //private string ExchangeName = String.Empty;
        private ExchangeManager.Exchange Exchange;
        //private string CurrentMarket = "ALL";
        public int PreferredWidth = 0;

        public ExchangeChartsControl chartControl;
        public HistoryTabControl historyTabControl;
        #endregion

        #region Initialize
        public TickerListControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void TickerListControl_Load(object sender, EventArgs e)
        {
            //UpdateUI(true);
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
        delegate bool SetExchangeCallback(ExchangeManager.Exchange exchange);
        public bool SetExchange(ExchangeManager.Exchange exchange)
        {
            if (InvokeRequired)
            {
                SetExchangeCallback d = new SetExchangeCallback(SetExchange);
                Invoke(d, new object[] { exchange });
            }
            else
            {
                Visible = false;
                Exchange = exchange;
                List<ExchangeTicker> list = Tickers.Where(item => item.exchange == Exchange.Name).ToList();
                //LogManager.AddDebugMessage(this.Name, "ExchangeTickerListControl_Load", "list count=" + list.Count + " | " + exchange);
                var markets = list.Select(p => p.market).OrderByDescending(m => m).Distinct();
                // CLEAR MARKET BUTTONS
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item.Alignment == ToolStripItemAlignment.Right)
                    {
                        toolStrip.Items.Remove(item);
                    }
                }
                // REBUILD BUTTONS
                foreach (string market in markets)
                {
                    ToolStripRadioButton button = new ToolStripRadioButton()
                    {
                        Text = market,
                        RadioButtonGroupId = 1,
                        Alignment = ToolStripItemAlignment.Right,
                        Image = ContentManager.GetSymbolIcon(market),
                        Checked = IsMarketButton(market)
                    };
                    button.Click += new EventHandler(marketButton_Click);
                    toolStrip.Items.Add(button);
                    toolStrip.Items.Add(new ToolStripSeparator() { Alignment = ToolStripItemAlignment.Right });                   
                }

                ToolStripRadioButton allButton = new ToolStripRadioButton()
                {
                    Text = "ALL",
                    RadioButtonGroupId = 1,
                    Image = Properties.Resources.ConnectionStatus_ACTIVE,
                    Checked = IsMarketButton("ALL"),
                    Alignment = ToolStripItemAlignment.Right
                };
                allButton.Click += new EventHandler(marketButton_Click);
                toolStrip.Items.Add(allButton);
                Visible = true;
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
                List<ExchangeTicker> list = Tickers.Where(item => item.exchange == Exchange.Name).OrderBy(item => item.symbol).ToList();
                //LogManager.AddLogMessage(Name, "UpdateUI", "selectedMarket=" + CurrentMarket, LogManager.LogMessageType.DEBUG);

                if (Exchange.CurrentMarket == "ALL")
                {
                    column_market.IsVisible = true;
                    listView.SetObjects(list);
                }
                else
                {
                    // FILTER BY MARKET SYMBOL
                    column_market.IsVisible = false;
                    listView.SetObjects(list.Where(item => item.market == Exchange.CurrentMarket));
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
                Visible = false;
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

                column_symbol.Width += (iconSize * 2);
                listWidth += (iconSize * 2);
                PreferredWidth = listWidth + (iconSize * 2);
                //LogManager.AddLogMessage(Name, "ResizeUI", "PreferredWidth = " + PreferredWidth);
                Visible = true;
            }
        }
        #endregion

        #region Getters
        public object aspect_change(object rowObject)
        {
            ExchangeTicker item = (ExchangeTicker)rowObject;
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
            ExchangeTicker item = (ExchangeTicker)rowObject;

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
                ExchangeTicker item = (ExchangeTicker)rowObject;
                return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(item.symbol), listView.RowHeightEffective, listView.RowHeightEffective);
            }
            catch (Exception)
            {
                //LogManager.AddLogMessage(Name, "aspect_symbol", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
            }
        }
        public object aspect_market(object rowObject)
        {
            try
            {
                ExchangeTicker item = (ExchangeTicker)rowObject;
                return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(item.market), listView.RowHeightEffective, listView.RowHeightEffective);
            }
            catch (Exception)
            {
                //LogManager.AddLogMessage(Name, "aspect_symbol", ex.Message, LogManager.LogMessageType.EXCEPTION);
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
            }
        }
        private bool IsMarketButton(string market)
        {
            if (market == Exchange.CurrentMarket)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region EventHandlers
        private void listView_ItemActivate(object sender, EventArgs e)
        {
            if (listView.SelectedObject != null)
            {
                ExchangeTicker ticker = listView.SelectedObject as ExchangeTicker;
                //LogManager.AddLogMessage(Name, "listView_ItemActivate", ticker.exchange + " | " + ticker.symbol + " | " + ticker.market);
                if (chartControl != null && historyTabControl != null)
                {
                    Exchange.CurrentTicker = ticker;
                    Exchange.AdvancedChartParameters.symbol = ticker.symbol;
                    Exchange.AdvancedChartParameters.market = ticker.market;
                    PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Exchange);
                    chartControl.SetCharts();
                    if (historyTabControl.ResetUI())
                    {
                        historyTabControl.UpdateUI();
                    }
                }
            }
        }
        private void marketButton_Click(object sender, EventArgs e)
        {
            ToolStripRadioButton item = (ToolStripRadioButton)sender;
            Exchange.CurrentMarket = item.Text;
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Exchange);
            //LogManager.AddLogMessage(Name, "marketButton_Click", "marketClicked=" + marketClicked);
            UpdateUI(true);
        }
        #endregion

        #region Formatters
        private void ListView_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == column_change.Index)
            {
                ExchangeTicker item = (ExchangeTicker)e.Model;
                if (item.change > 0)
                {
                    e.SubItem.BackColor = PreferenceManager.preferences.Theme.Green;
                }
                else
                {
                    e.SubItem.BackColor = PreferenceManager.preferences.Theme.Red;
                }
            }
        }
        #endregion

        
    }
}
