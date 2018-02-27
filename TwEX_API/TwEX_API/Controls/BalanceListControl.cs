using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using static TwEX_API.ExchangeManager;
using System.Windows.Forms.DataVisualization.Charting;

namespace TwEX_API.Controls
{
    public partial class BalanceListControl : UserControl
    {
        #region Properties
        private ExchangeManager.Exchange Exchange;
        public int PreferredWidth = 0;
        public ExchangeTradingControl exchangeTradingControl;
        #endregion

        #region Initialize
        public BalanceListControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void BalanceListControl_Load(object sender, EventArgs e)
        {
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            chart.Palette = ChartColorPalette.EarthTones;
            splitContainer.SplitterDistance = (int)(splitContainer.ClientSize.Height * 0.50);
        }
        private void InitializeColumns()
        {
            column_Symbol.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            column_Orders.AspectGetter = new AspectGetterDelegate(aspect_TotalInBTCOrders);
            column_TotalInBTC.AspectGetter = new AspectGetterDelegate(aspect_TotalInBTC);
            column_TotalInUSD.AspectGetter = new AspectGetterDelegate(aspect_TotalInUSD);
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
                Exchange = exchange;
                //ExchangeName = exchange;
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
                List<ExchangeBalance> list = Balances.Where(item => item.Exchange == Exchange.Name && item.Balance > 0).OrderByDescending(item => item.TotalInBTC).ToList();

                if (list.Sum(item => item.TotalInBTCOrders) > 0)
                {
                    column_Orders.IsVisible = true;
                }
                else
                {
                    column_Orders.IsVisible = false;
                }
                listView.RebuildColumns();
                listView.SetObjects(list);

                toolStripLabel_title.Text = list.Count + " Balances";
                toolStripLabel_totals.Text = "(" + list.Sum(item => item.TotalInUSD).ToString("C") + ") " + list.Sum(item => item.TotalInBTC).ToString("N8");
                SetSymbolChart();

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
                
                try
                {
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
                        listWidth += col.Width;
                    }
                    PreferredWidth = listWidth + (iconSize * 2);
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "ResizeUI", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
                
                //LogManager.AddLogMessage(Name, "ResizeUI", "PreferredWidth = " + PreferredWidth);
            }
        }
        #endregion

        #region Getters
        private object aspect_Icon(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;
            int rowheight = listView.RowHeightEffective;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(balance.Symbol), rowheight, rowheight);
            //return ContentManager.GetExchangeIcon(exchange.Name);
        }
        public object aspect_TotalInBTCOrders(object rowObject)
        {
            ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;
            return balance.TotalInBTCOrders.ToString("N8");
        }
        public object aspect_TotalInBTC(object rowObject)
        {
            ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;
            return balance.TotalInBTC.ToString("N8");
        }
        public object aspect_TotalInUSD(object rowObject)
        {
            ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;
            return balance.TotalInUSD.ToString("C");
        }
        #endregion

        #region Setters
        private void SetSymbolChart()
        {
            List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0 && item.Exchange == Exchange.Name).ToList();
            //List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
            //list.AddRange(wallets);
            
            //var roots = list.Select(b => b.Symbol).Distinct();

            List<string> symbols = new List<string>();
            List<decimal> totals = new List<decimal>();
            /*
            foreach (string symbol in roots)
            {
                //LogManager.AddLogMessage(Name, "InitializeChart2", symbol, LogManager.LogMessageType.DEBUG);
                symbols.Add(symbol);
                totals.Add(list.Where(balance => balance.Symbol == symbol).Sum(balance => balance.TotalInUSD));
            }
            */
            foreach (ExchangeBalance balance in list)
            {
                symbols.Add(balance.Symbol);
                totals.Add(balance.TotalInUSD);
            }

            decimal[] yValues = totals.ToArray();
            string[] xValues = symbols.ToArray();

            Series series1 = chart.Series[0];

            // Set the threshold under which all points will be collected
            series1["CollectedThreshold"] = "1";

            // Set the threshold type to be a percentage of the pie
            // When set to false, this property uses the actual value to determine the collected threshold
            series1["CollectedThresholdUsePercent"] = "true";

            // Set the label of the collected pie slice
            series1["CollectedLabel"] = "Below 1%";

            // Set the legend text of the collected pie slice
            series1["CollectedLegendText"] = "Below 1%";

            // Set the collected pie slice to be exploded
            //series1["CollectedSliceExploded"] = "true";

            // Set the color of the collected pie slice
            series1["CollectedColor"] = "Red";

            // Set the tooltip of the collected pie slice
            series1["CollectedToolTip"] = "Below 1%";

            chart.Series["Default"].Font = PreferenceManager.GetFormFont(ParentForm);
            chart.Titles[0].Font = chart.Series["Default"].Font;
            chart.Titles[0].Text = "SYMBOLS BY PERCENTAGE";
            //chart.Series["Default"].
            chart.Series["Default"].Points.DataBindXY(xValues, yValues);
            chart.Series["Default"].ChartType = SeriesChartType.Pie;
            chart.Series["Default"]["PieLabelStyle"] = "Outside";
            chart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

            chart.Series[0].ToolTip = "Percent: #PERCENT";
            chart.Series[0].LabelToolTip = "#PERCENT";
            //chart.Series[0].Label = "#VALX" + " : " + "#PERCENT" + " (" + "#VALY" + ")";
            chart.Series[0].Label = "#VALX" + " (" + "#PERCENT" + ")";

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].Area3DStyle.Inclination = 0;
        }
        #endregion

        #region EventHandlers
        private void toolStripDropDownButton_menu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
                toolStripDropDownButton_menu.HideDropDown();
                //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
                switch (menuItem.Tag.ToString())
                {
                    case "Font":
                        FontDialog dialog = new FontDialog() { Font = ParentForm.Font };
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            if (PreferenceManager.SetFormFont(ParentForm, dialog.Font))
                            {
                                UpdateUI(true);
                            }
                        }
                        //UpdateUI(true);
                        break;

                    case "FontIncrease":
                        if (PreferenceManager.SetFormFont(ParentForm, new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style)))
                        {
                            UpdateUI(true);
                        }
                        break;

                    case "FontDecrease":
                        if (PreferenceManager.SetFormFont(ParentForm, new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style)))
                        {
                            UpdateUI(true);
                        }
                        break;

                    default:
                        // NOTHING
                        break;
                }
            }
        }
        #endregion
    }
}
