using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Controls
{
    public partial class BalanceManagerControl : UserControl
    {
        #region Initialize
        public BalanceManagerControl()
        {
            InitializeComponent();       
        }
        private void BalanceManagerControl_Load(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = (int)(splitContainer.ClientSize.Height * 0.75);
            InitializeViews();
            //InitializeChart2();
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripRadioButton_balance.Image = ContentManager.GetIcon("BalanceManager");
            toolStripRadioButton_exchange.Image = ContentManager.GetIcon("Exchange");
            toolStripRadioButton_symbol.Image = ContentManager.GetIcon("Symbol");
            chart.Palette = ChartColorPalette.EarthTones;
            toolStripRadioButton_balance.Checked = true;
            SetTabButton();
            UpdateUI(true);
        }        
        private void InitializeViews()
        {
            var values = EnumUtils.GetValues<BalanceViewType>();
            foreach (var item in values)
            {
                //LogManager.AddLogMessage(Name, "InitializeViews", item.ToString() + " | " + item.GetHashCode(), LogManager.LogMessageType.DEBUG);
                TabPage tabPage = new TabPage()
                {
                    Name = item.ToString(),
                    Text = item.ToString(),
                    Margin = new Padding(0,0,0,0),
                    Padding = new Padding(0,0,0,0)
                };

                BalanceViewControl view = new BalanceViewControl()
                {
                    Dock = DockStyle.Fill,
                    view = item,
                    Margin = new Padding(0, 0, 0, 0),
                    Padding = new Padding(0, 0, 0, 0)
                };
                view.SetView();
                tabPage.Controls.Add(view);
                tabControl.TabPages.Add(tabPage);
            }
        }
        #endregion

        #region Setters
        private void SetExchangeChart()
        {
            List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0).ToList();
            List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
            list.AddRange(wallets);

            var roots = list.Select(b => b.Exchange).Distinct();

            List<string> exchanges = new List<string>();
            List<decimal> totals = new List<decimal>();

            foreach (string exchange in roots)
            {
                //LogManager.AddLogMessage(Name, "InitializeChart", exchange, LogManager.LogMessageType.DEBUG);
                exchanges.Add(exchange);
                totals.Add(list.Where(balance => balance.Exchange == exchange).Sum(balance => balance.TotalInUSD));
            }

            decimal[] yValues = totals.ToArray();
            string[] xValues = exchanges.ToArray();

            chart.Series["Default"].Font = PreferenceManager.GetFormFont(ParentForm);
            chart.Titles[0].Font = chart.Series["Default"].Font;
            chart.Titles[0].Text = "EXCHANGES BY PERCENTAGE";
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
            // Standard palette
            //chart.Palette = ChartColorPalette.EarthTones;
        }
        private void SetSymbolChart()
        {


            List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0).ToList();
            List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
            list.AddRange(wallets);

            var roots = list.Select(b => b.Symbol).Distinct();

            List<string> symbols = new List<string>();
            List<decimal> totals = new List<decimal>();

            foreach (string symbol in roots)
            {
                //LogManager.AddLogMessage(Name, "InitializeChart2", symbol, LogManager.LogMessageType.DEBUG);
                symbols.Add(symbol);
                totals.Add(list.Where(balance => balance.Symbol == symbol).Sum(balance => balance.TotalInUSD));
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
        private void SetTabButton()
        {
            switch (PreferenceManager.preferences.BalanceView)
            {
                case BalanceViewType.symbol:
                    toolStripRadioButton_symbol.Checked = true;
                    break;

                case BalanceViewType.exchange:
                    toolStripRadioButton_exchange.Checked = true;
                    break;

                case BalanceViewType.balance:
                    toolStripRadioButton_balance.Checked = true;
                    break;

                default:

                    break;
            }
        }
        #endregion

        #region Delegates
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
                    tabControl.SelectedIndex = PreferenceManager.preferences.BalanceView.GetHashCode();
                    if (tabControl.SelectedIndex != 1)
                    {
                        SetSymbolChart();
                    }
                    else
                    {
                        SetExchangeChart();
                    }
                    BalanceViewControl control = tabControl.SelectedTab.Controls[0] as BalanceViewControl;
                    control.UpdateUI(resize);
                    
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
            if (InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                //toolStrip.Font = ParentForm.Font;
                toolStrip.ImageScalingSize = PreferenceManager.preferences.IconSize;
            }
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
        private void toolStripRadioButton_view_Click(object sender, EventArgs e)
        {
            ToolStripRadioButton button = sender as ToolStripRadioButton;
            PreferenceManager.preferences.BalanceView = (BalanceViewType)Enum.Parse(typeof(BalanceViewType), button.Tag.ToString());
            PreferenceManager.UpdatePreferenceFile();
            UpdateUI(true);
        }
        #endregion
    }
}