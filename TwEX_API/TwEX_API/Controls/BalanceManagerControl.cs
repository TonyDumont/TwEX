using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static TwEX_API.ExchangeManager;
using static TwEX_API.LogManager;
using static TwEX_API.WalletManager;

namespace TwEX_API.Controls
{
    public partial class BalanceManagerControl : UserControl
    {
        #region Properties
        //private bool loaded = false;
        #endregion

        #region Initialize
        public BalanceManagerControl()
        {
            InitializeComponent();
            FormManager.balanceManagerControl = this;
            InitializeIcons();
        }
        private void BalanceManagerControl_Load(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = (int)(splitContainer.ClientSize.Height * 0.70);
            InitializeViews();
            
            chart.Palette = ChartColorPalette.EarthTones;
            toolStripRadioButton_balance.Checked = true;
            SetTabButton();
            
            //UpdateUI(true);
        }
        private void InitializeIcons()
        {
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripRadioButton_balance.Image = ContentManager.GetIcon("BalanceManager");
            toolStripRadioButton_exchange.Image = ContentManager.GetIcon("Exchange");
            toolStripRadioButton_symbol.Image = ContentManager.GetIcon("Symbol");
            toolStripRadioButton_orders.Image = ContentManager.GetIcon("Orders");
            toolStripRadioButton_fork.Image = ContentManager.GetIcon("Fork");
        }
        private void InitializeViews()
        {
            var values = EnumUtils.GetValues<BalanceViewType>();
            // BALANCES
            foreach (var item in values)
            {
                //LogManager.AddLogMessage(Name, "InitializeViews", item.ToString() + " | " + item.GetHashCode(), LogManager.LogMessageType.DEBUG);
                switch (item)
                {
                    case BalanceViewType.balance:
                    case BalanceViewType.exchange:
                    case BalanceViewType.symbol:
                        TabPage tabPage = new TabPage()
                        {
                            Name = item.ToString(),
                            Text = item.ToString(),
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(0, 0, 0, 0)
                        };

                        BalanceViewControl view = new BalanceViewControl()
                        //BalanceDataViewControl view = new BalanceDataViewControl()
                        {
                            Dock = DockStyle.Fill,
                            view = item,
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(0, 0, 0, 0),
                            manager = this
                        };
                        view.SetView();
                        tabPage.Controls.Add(view);
                        tabControl.TabPages.Add(tabPage);
                        break;

                    case BalanceViewType.orders:
                        TabPage orderTabPage = new TabPage()
                        {
                            Name = item.ToString(),
                            Text = item.ToString(),
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(0, 0, 0, 0)
                        };

                        OrderViewControl orderview = new OrderViewControl()
                        {
                            Dock = DockStyle.Fill,
                            //view = item,
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(0, 0, 0, 0),
                            //manager = this
                        };
                        //view.SetView();
                        orderview.UpdateUI(true);
                        orderTabPage.Controls.Add(orderview);
                        tabControl.TabPages.Add(orderTabPage);
                        break;

                    case BalanceViewType.forks:
                        TabPage forkTabPage = new TabPage()
                        {
                            Name = item.ToString(),
                            Text = item.ToString(),
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(0, 0, 0, 0)
                        };

                        ForkListControl forkview = new ForkListControl()
                        {
                            Dock = DockStyle.Fill,
                            //view = item,
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(0, 0, 0, 0),
                            //manager = this
                        };
                        //view.SetView();
                        forkview.UpdateUI(true);
                        forkTabPage.Controls.Add(forkview);
                        tabControl.TabPages.Add(forkTabPage);
                        break;

                    default:
                        //AddLogMessage(Name, "SetView", "VIEW NOT DEFINED!!! : " + PreferenceManager.preferences.BalanceView, LogMessageType.DEBUG);
                        break;
                }
                
            }
            //SetView(true);
        }
        #endregion

        #region Setters
        private void SetExchangeChart(string exchange)
        {
            List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0 && item.Exchange == exchange).ToList();
            List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
            list.AddRange(wallets.Where(balance => balance.Exchange == exchange));

            List<string> symbols = new List<string>();
            List<decimal> totals = new List<decimal>();

            foreach (ExchangeBalance balance in list.OrderByDescending(item => item.TotalInBTC))
            {
                symbols.Add(balance.Symbol);
                totals.Add(balance.TotalInUSD);
            }

            decimal[] yValues = totals.ToArray();
            string[] xValues = symbols.ToArray();
            
            Series series1 = chart.Series[0];
            series1["CollectedThreshold"] = "1";
            series1["CollectedThresholdUsePercent"] = "true";
            series1["CollectedLabel"] = "Below 1%";
            series1["CollectedLegendText"] = "Below 1%";
            series1["CollectedColor"] = "Red";
            series1["CollectedToolTip"] = "Below 1%";
            
            chart.Series["Default"].Font = PreferenceManager.GetFormFont(ParentForm);
            chart.Titles[0].Font = chart.Series["Default"].Font;
            chart.Titles[0].Text = symbols.Count + " " + exchange + " BALANCES BY PERCENTAGE (" + list.Sum(balance => balance.TotalInUSD).ToString("C") + ")";

            chart.Series["Default"].Points.DataBindXY(xValues, yValues);
            chart.Series["Default"].ChartType = SeriesChartType.Pie;
            chart.Series["Default"]["PieLabelStyle"] = "Outside";
            chart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

            chart.Series[0].ToolTip = "Percent: #PERCENT";
            chart.Series[0].ToolTip = "#VALX" + " : " + "#PERCENT" + " (" + "#VALY{$#,##0.00}" + ")";
            chart.Series[0].LabelToolTip = "#VALY{$#,##0.00}";
            chart.Series[0].Label = "#VALX" + " (" + "#PERCENT" + ")";

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].Area3DStyle.Inclination = 0;
        }
        private void SetExchangesChart()
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
            chart.Titles[0].Text = exchanges.Count + " EXCHANGES BY PERCENTAGE (" + list.Sum(balance => balance.TotalInUSD).ToString("C") + ")";
            chart.Series["Default"].Points.DataBindXY(xValues, yValues);
            chart.Series["Default"].ChartType = SeriesChartType.Pie;
            chart.Series["Default"]["PieLabelStyle"] = "Outside";
            chart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

            chart.Series[0].ToolTip = "Percent: #PERCENT";
            chart.Series[0].ToolTip = "#VALX" + " : " + "#PERCENT" + " (" + "#VALY{$#,##0.00}" + ")";
            chart.Series[0].LabelToolTip = "#VALY{$#,##0.00}";
            chart.Series[0].Label = "#VALX" + " (" + "#PERCENT" + ")";

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].Area3DStyle.Inclination = 0;
        }
        private void SetForksChart()
        {
            
            List<WalletBalance> list = PreferenceManager.WalletPreferences.WalletForks.Where(item => item.TotalInBTC > 0).ToList();
            //List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
            //list.AddRange(wallets);

            var roots = list.Select(fork => fork.Symbol).Distinct();

            List<string> wallets = new List<string>();
            List<decimal> totals = new List<decimal>();

            foreach (string wallet in roots)
            {
                //LogManager.AddLogMessage(Name, "InitializeChart", exchange, LogManager.LogMessageType.DEBUG);
                wallets.Add(wallet);
                totals.Add(list.Where(balance => balance.Symbol == wallet).Sum(balance => balance.TotalInBTC));
            }

            decimal[] yValues = totals.ToArray();
            string[] xValues = wallets.ToArray();

            chart.Series["Default"].Font = PreferenceManager.GetFormFont(ParentForm);
            chart.Titles[0].Font = chart.Series["Default"].Font;
            chart.Titles[0].Text = wallets.Count + " FORKS BY PERCENTAGE (" + list.Sum(balance => balance.TotalInBTC).ToString("N8") + ")";
            chart.Series["Default"].Points.DataBindXY(xValues, yValues);
            chart.Series["Default"].ChartType = SeriesChartType.Pie;
            chart.Series["Default"]["PieLabelStyle"] = "Outside";
            chart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

            chart.Series[0].ToolTip = "Percent: #PERCENT";
            chart.Series[0].ToolTip = "#VALX" + " : " + "#PERCENT" + " (" + "#VALY{$#,##0.00}" + ")";
            chart.Series[0].LabelToolTip = "#VALY{$#,##0.00}";
            chart.Series[0].Label = "#VALX" + " (" + "#PERCENT" + ")";

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].Area3DStyle.Inclination = 0;
            
        }
        private void SetOrdersChart()
        {
            //List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0).ToList();
            List<ExchangeOrder> list = Orders.Where(order => order.open == true).ToList();
            //List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
            //list.AddRange(wallets);

            var roots = list.Select(b => b.symbol).Distinct();

            List<string> symbols = new List<string>();
            List<decimal> totals = new List<decimal>();

            foreach (string symbol in roots)
            {
                //LogManager.AddLogMessage(Name, "InitializeChart2", symbol, LogManager.LogMessageType.DEBUG);
                symbols.Add(symbol);
                totals.Add(list.Where(order => order.symbol == symbol).Sum(order => Convert.ToDecimal(order.total)));
            }

            decimal[] yValues = totals.ToArray();
            string[] xValues = symbols.ToArray();
            
            Series series1 = chart.Series[0];
            series1["CollectedThresholdUsePercent"] = "false";
            series1["CollectedThreshold"] = "0";
            /*
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
            */
            chart.Series["Default"].Font = PreferenceManager.GetFormFont(ParentForm);
            chart.Titles[0].Font = chart.Series["Default"].Font;
            chart.Titles[0].Text = list.Count + " ORDERS BY PERCENTAGE (" + list.Sum(order => order.total).ToString("C") + ")";
            //chart.Series["Default"].
            chart.Series["Default"].Points.DataBindXY(xValues, yValues);
            chart.Series["Default"].ChartType = SeriesChartType.Pie;
            chart.Series["Default"]["PieLabelStyle"] = "Outside";
            chart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

            chart.Series[0].ToolTip = "Percent: #PERCENT";
            chart.Series[0].ToolTip = "#VALX" + " : " + "#PERCENT" + " (" + "#VALY{$#,##0.00}" + ")";
            chart.Series[0].LabelToolTip = "#VALY{$#,##0.00}";
            chart.Series[0].Label = "#VALX" + " (" + "#PERCENT" + ")";

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].Area3DStyle.Inclination = 0;
        }
        private void SetSymbolChart(string symbol)
        {
            List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0 && item.Symbol == symbol).ToList();
            List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
            list.AddRange(wallets.Where(wallet => wallet.Symbol == symbol));

            List<string> exchanges = new List<string>();
            List<decimal> totals = new List<decimal>();

            foreach (ExchangeBalance balance in list.OrderByDescending(item => item.TotalInBTC))
            {
                exchanges.Add(balance.Exchange);
                totals.Add(balance.TotalInUSD);
            }

            decimal[] yValues = totals.ToArray();
            string[] xValues = exchanges.ToArray();

            Series series1 = chart.Series[0];
            series1["CollectedThreshold"] = "1";
            series1["CollectedThresholdUsePercent"] = "true";
            //series1["CollectedThresholdUsePercent"] = "false";
            series1["CollectedLabel"] = "Below 1%";
            series1["CollectedLegendText"] = "Below 1%";
            series1["CollectedColor"] = "Red";
            series1["CollectedToolTip"] = "Below 1%";

            chart.Series["Default"].Font = PreferenceManager.GetFormFont(ParentForm);
            chart.Titles[0].Font = chart.Series["Default"].Font;
            chart.Titles[0].Text = exchanges.Count + " " + symbol + " BALANCES BY PERCENTAGE (" + list.Sum(balance => balance.TotalInUSD).ToString("C") + ")";

            chart.Series["Default"].Points.DataBindXY(xValues, yValues);
            chart.Series["Default"].ChartType = SeriesChartType.Pie;
            chart.Series["Default"]["PieLabelStyle"] = "Outside";
            chart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";
            /*
            chart.Series[0].ToolTip = "Percent: #PERCENT";
            chart.Series[0].LabelToolTip = "#PERCENT";
            chart.Series[0].Label = "#VALX" + " (" + "#PERCENT" + ")";
            */
            chart.Series[0].ToolTip = "Percent: #PERCENT";
            chart.Series[0].ToolTip = "#VALX" + " : " + "#PERCENT" + " (" + "#VALY{$#,##0.00}" + ")";
            chart.Series[0].LabelToolTip = "#VALY{$#,##0.00}";
            chart.Series[0].Label = "#VALX" + " (" + "#PERCENT" + ")";

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].Area3DStyle.Inclination = 0;
        }
        private void SetSymbolsChart()
        {
            List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0).ToList();
            List<ExchangeBalance> wallets = WalletManager.GetWalletBalances();
            list.AddRange(wallets);

            var roots = list.OrderByDescending(item => item.TotalInBTC).Select(b => b.Symbol).Distinct();

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
            chart.Titles[0].Text = symbols.Count + " SYMBOLS BY PERCENTAGE (" + list.Sum(balance => balance.TotalInUSD).ToString("C") + ")";
            //chart.Series["Default"].
            chart.Series["Default"].Points.DataBindXY(xValues, yValues);
            chart.Series["Default"].ChartType = SeriesChartType.Pie;
            chart.Series["Default"]["PieLabelStyle"] = "Outside";
            chart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

            chart.Series[0].ToolTip = "Percent: #PERCENT";
            chart.Series[0].ToolTip = "#VALX" + " : " + "#PERCENT" + " (" + "#VALY{$#,##0.00}" + ")";
            chart.Series[0].LabelToolTip = "#VALY{$#,##0.00}";
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

                case BalanceViewType.orders:
                    toolStripRadioButton_orders.Checked = true;
                    break;

                case BalanceViewType.forks:
                    toolStripRadioButton_fork.Checked = true;
                    break;

                default:

                    break;
            }
        }
        private void SetView(bool resize = false)
        {
            //tabControl.SelectedIndex = PreferenceManager.preferences.BalanceView.GetHashCode();
            try
            {
                //LogManager.AddLogMessage(Name, "SetView", "index:" + tabControl.SelectedIndex, LogMessageType.DEBUG);
                switch (PreferenceManager.preferences.BalanceView)
                {
                    case BalanceViewType.balance:
                        //tabControl.SelectedIndex = 0;
                        SetSymbolsChart();
                        BalanceViewControl balancecontrol = tabControl.SelectedTab.Controls[0] as BalanceViewControl;
                        balancecontrol.UpdateUI(resize);
                        break;

                    case BalanceViewType.exchange:
                        //tabControl.SelectedIndex = 1;
                        SetExchangesChart();
                        BalanceViewControl exchangecontrol = tabControl.SelectedTab.Controls[0] as BalanceViewControl;
                        exchangecontrol.UpdateUI(resize);
                        break;

                    case BalanceViewType.symbol:
                        //tabControl.SelectedIndex = 2;
                        SetSymbolsChart();
                        BalanceViewControl symbolcontrol = tabControl.SelectedTab.Controls[0] as BalanceViewControl;
                        symbolcontrol.UpdateUI(resize);
                        break;

                    case BalanceViewType.orders:
                        //tabControl.SelectedIndex = 3;
                        //SetOrdersChart();
                        OrderViewControl orderscontrol = tabControl.SelectedTab.Controls[0] as OrderViewControl;
                        orderscontrol.UpdateUI(resize);
                        break;

                    case BalanceViewType.forks:
                        //tabControl.SelectedIndex = 4;
                        SetForksChart();
                        ForkListControl forkcontrol = tabControl.SelectedTab.Controls[0] as ForkListControl;
                        forkcontrol.UpdateUI(resize);
                        break;

                    default:
                        AddLogMessage(Name, "SetView", "VIEW NOT DEFINED!!! : " + PreferenceManager.preferences.BalanceView, LogMessageType.DEBUG);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLogMessage(Name, "SetView", ex.Message, LogMessageType.EXCEPTION);
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
                    
                    List<ExchangeBalance> list = Balances.Where(item => item.Balance > 0).ToList();
                    List<ExchangeBalance> wallets = GetWalletBalances();
                    list.AddRange(wallets);

                    var roots = list.Select(b => b.Symbol).Distinct();
                    toolStripLabel_count.Text = roots.Count() + " Coins";
                    toolStripLabel_btc.Text = list.Sum(b => b.TotalInBTC).ToString("N8");
                    toolStripLabel_usd.Text = list.Sum(b => b.TotalInUSD).ToString("C");

                    //AddLogMessage(Name, "UpdateUI", PreferenceManager.preferences.BalanceView.GetHashCode().ToString() + " | " + tabControl.TabPages.Count, LogMessageType.DEBUG);
                    //if (tabControl.TabPages.Count > 0)
                    //{
                    tabControl.SelectedIndex = PreferenceManager.preferences.BalanceView.GetHashCode();
                    //tabControl.SelectedIndex = 1;
                    //}
                    //tabControl.SelectedIndex = PreferenceManager.preferences.BalanceView.GetHashCode();
                    //tabControl.SelectedIndex = 0;
                    SetView(resize);
                    
                    if (resize)
                    {
                        ResizeUI();
                    }
                }
                catch (Exception ex)
                {
                    AddLogMessage(Name, "UpdateUI", "EXCEPTION : " + ex.Message, LogMessageType.EXCEPTION);
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

        delegate void SetChartCallback(BalanceViewType viewType, string name);
        public void SetChart(BalanceViewType viewType, string name)
        {
            if (InvokeRequired)
            {
                SetChartCallback d = new SetChartCallback(SetChart);
                Invoke(d, new object[] { viewType, name });
            }
            else
            {
                try
                {
                    //LogManager.AddLogMessage(Name, "SetChart", "viewType=" + viewType + " | " + name, LogManager.LogMessageType.EXCEPTION);
                    switch (viewType)
                    {
                        case BalanceViewType.balance:
                            SetSymbolChart(name);
                            break;

                        case BalanceViewType.exchange:
                            SetExchangeChart(name);
                            break;

                        case BalanceViewType.symbol:
                            SetSymbolChart(name);
                            break;

                        case BalanceViewType.orders:
                            SetOrdersChart();
                            break;

                        case BalanceViewType.forks:
                            SetForksChart();
                            break;

                        default:
                            AddLogMessage(Name, "SetChart", "UNDEFINED viewType=" + viewType, LogMessageType.OTHER);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    AddLogMessage(Name, "SetChart", ex.Message, LogMessageType.EXCEPTION);
                }
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
            string view = button.Tag.ToString();
            PreferenceManager.preferences.BalanceView = (BalanceViewType)Enum.Parse(typeof(BalanceViewType), view);
            PreferenceManager.UpdatePreferenceFile();
            UpdateUI(true);
        }
        #endregion       
    }
}