using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static TwEX_API.Market.CoinMarketCap;

namespace TwEX_API.Controls
{
    public partial class CoinMarketCapControl : UserControl
    {
        #region Properties
        private Decimal MarketCap = 0;
        #endregion

        #region Initialize
        public CoinMarketCapControl()
        {
            InitializeComponent();
            FormManager.coinMarketCapControl = this;
            InitializeColumns();
            InitializeIcons();
        }
        private void CoinMarketCapControl_Load(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = (int)(splitContainer.ClientSize.Height * 0.70);
            chart_marketcap.Palette = ChartColorPalette.EarthTones;
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_name.ImageGetter = new ImageGetterDelegate(aspect_icon);
            column_24hchange.AspectGetter = new AspectGetterDelegate(aspect_24hchange);
        }
        private void InitializeIcons()
        {
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripMenuItem_update.Image = ContentManager.GetIcon("Refresh");
            toolStripButton_search.Image = ContentManager.GetIcon("SearchList");
        }
        #endregion

        #region Delegates
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
                int rowHeight = listView.RowHeightEffective;
                int formWidth = 0;
                //int padding = 

                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + (rowHeight);
                    formWidth += col.Width;
                }

                column_market_cap_usd.Width += rowHeight;
                column_volume.Width += rowHeight;
                formWidth += (rowHeight * 2);

                if (Parent.GetType() == typeof(Form))
                {
                    ParentForm.Width = formWidth + 50;
                }
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
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                //Decimal oldValue = listView.Items.Sum(t => t.market_cap_usd);
                Decimal newValue = PreferenceManager.CoinMarketCapPreferences.Tickers.Sum(t => t.market_cap_usd);

                if (newValue > MarketCap)
                {
                    toolStripLabel_total.BackColor = PreferenceManager.preferences.Theme.Green;
                }
                else if (newValue < MarketCap)
                {
                    toolStripLabel_total.BackColor = PreferenceManager.preferences.Theme.Red;
                }
                else
                {
                    toolStripLabel_total.BackColor = PreferenceManager.preferences.Theme.Yellow;
                }

                MarketCap = newValue;
                //toolStripLabel_count.Text = PreferenceManager.CoinMarketCapPreferences.Tickers.Count + " Coins (" + PreferenceManager.CoinMarketCapPreferences.Tickers.Sum(t => t.market_cap_usd).ToString("C") + ")";
                toolStripLabel_count.Text = PreferenceManager.CoinMarketCapPreferences.Tickers.Count + " Coins";
                toolStripLabel_total.Text = MarketCap.ToString("C");
                toolStripLabel_update.Text = DateTime.Now.ToString();

                listView.SetObjects(PreferenceManager.CoinMarketCapPreferences.Tickers.OrderBy(item => item.rank));
                SetMarketCapChart();
                SetVolumeChart();

                if (resize)
                {
                    ResizeUI();
                }
            }
        }
        #endregion

        #region Getters
        public object aspect_icon(object rowObject)
        {
            CoinMarketCapTicker e = (CoinMarketCapTicker)rowObject;

            if (e != null)
            {
                return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(e.symbol), listView.RowHeightEffective, listView.RowHeightEffective);
            }
            else
            {
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
            }
        }
        public object aspect_24hchange(object rowObject)
        {
            CoinMarketCapTicker ticker = (CoinMarketCapTicker)rowObject;
            return ticker.percent_change_24h + "%";
        }
        #endregion

        #region Setters
        private void SetMarketCapChart()
        {
            List<string> symbols = new List<string>();
            List<decimal> totals = new List<decimal>();

            foreach (CoinMarketCapTicker symbol in PreferenceManager.CoinMarketCapPreferences.Tickers)
            {
                symbols.Add(symbol.symbol);
                totals.Add(symbol.market_cap_usd);
            }

            decimal[] yValues = totals.ToArray();
            string[] xValues = symbols.ToArray();

            Series series1 = chart_marketcap.Series[0];
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

            chart_marketcap.Series["Default"].Font = PreferenceManager.GetFormFont(ParentForm);
            chart_marketcap.Titles[0].Font = chart_marketcap.Series["Default"].Font;
            //chart.Titles[0].Text = symbols.Count + " SYMBOLS BY PERCENTAGE (" + PreferenceManager.CoinMarketCapPreferences.Tickers.Sum(ticker => ticker.market_cap_usd).ToString("C") + ")";
            chart_marketcap.Titles[0].Text = "MARKET CAP % (" + MarketCap.ToString("C") + ")";
            chart_marketcap.Series["Default"].Points.DataBindXY(xValues, yValues);
            chart_marketcap.Series["Default"].ChartType = SeriesChartType.Pie;
            chart_marketcap.Series["Default"]["PieLabelStyle"] = "Outside";
            chart_marketcap.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

            chart_marketcap.Series[0].ToolTip = "Percent: #PERCENT";
            chart_marketcap.Series[0].ToolTip = "#VALX" + " : " + "#PERCENT" + " (" + "#VALY{$#,##0.00}" + ")";
            chart_marketcap.Series[0].LabelToolTip = "#VALY{$#,##0.00}";
            chart_marketcap.Series[0].Label = "#VALX" + " (" + "#PERCENT" + ")";

            chart_marketcap.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart_marketcap.ChartAreas[0].Area3DStyle.Inclination = 0;
            chart_marketcap.Series["Default"].Sort(PointSortOrder.Ascending, "Y");
        }
        private void SetVolumeChart()
        {
            List<string> symbols = new List<string>();
            List<decimal> totals = new List<decimal>();

            decimal volume = 0;

            foreach (CoinMarketCapTicker symbol in PreferenceManager.CoinMarketCapPreferences.Tickers)
            {
                symbols.Add(symbol.symbol);
                totals.Add(symbol.volume_24h);
                volume += symbol.volume_24h;
            }

            decimal[] yValues = totals.ToArray();
            string[] xValues = symbols.ToArray();

            Series series1 = chart_volume.Series[0];
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

            chart_volume.Series["Default"].Font = PreferenceManager.GetFormFont(ParentForm);
            chart_volume.Titles[0].Font = chart_marketcap.Series["Default"].Font;
            //chart.Titles[0].Text = symbols.Count + " SYMBOLS BY PERCENTAGE (" + PreferenceManager.CoinMarketCapPreferences.Tickers.Sum(ticker => ticker.market_cap_usd).ToString("C") + ")";
            chart_volume.Titles[0].Text = "VOLUME % (" + volume.ToString("C") + ")";
            chart_volume.Series["Default"].Points.DataBindXY(xValues, yValues);
            chart_volume.Series["Default"].ChartType = SeriesChartType.Pie;
            chart_volume.Series["Default"]["PieLabelStyle"] = "Outside";
            chart_volume.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

            chart_volume.Series[0].ToolTip = "Percent: #PERCENT";
            chart_volume.Series[0].ToolTip = "#VALX" + " : " + "#PERCENT" + " (" + "#VALY{$#,##0.00}" + ")";
            chart_volume.Series[0].LabelToolTip = "#VALY{$#,##0.00}";
            chart_volume.Series[0].Label = "#VALX" + " (" + "#PERCENT" + ")";

            chart_volume.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart_volume.ChartAreas[0].Area3DStyle.Inclination = 0;
            chart_volume.Series["Default"].Sort(PointSortOrder.Ascending, "Y");
        }
        #endregion

        #region Event_Handlers
        private void toolStripDropDownButton_menu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
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
                        
                    case "Update":
                        updateTickers();
                        UpdateUI();
                        break;

                    default:
                        // NOTHING
                        break;
                }
            }
        }
        private void toolStripLabel_update_Click(object sender, EventArgs e)
        {
            updateTickers();
            UpdateUI();
        }
        private void toolStripTextBox_search_TextChanged(object sender, EventArgs e)
        {
            listView.ModelFilter = TextMatchFilter.Contains(listView, toolStripTextBox_search.Text);
            toolStripLabel_count.Text = PreferenceManager.CoinMarketCapPreferences.Tickers.Count + " Coins (" + PreferenceManager.CoinMarketCapPreferences.Tickers.Sum(t => t.market_cap_usd).ToString("C") + ")";
        }
        #endregion

        #region Formatters
        private void ListView_FormatCell(object sender, FormatCellEventArgs e)
        {
            CoinMarketCapTicker ticker = (CoinMarketCapTicker)e.Model;

            if (e.ColumnIndex == column_24hchange.Index)
            {
                if (ticker.percent_change_24h > 0)
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
