using System;
using System.Drawing;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class ArbitrageManagerControl : UserControl
    {
        public static Timer timer = new Timer() { Interval = 60000 };
        
        #region Initialize
        public ArbitrageManagerControl()
        {
            InitializeComponent();
            FormManager.arbitrageManagerControl = this;
        }
        private void ArbitrageManagerControl_Load(object sender, EventArgs e)
        {
            toolStripDropDownButton_menu.Image = ContentManager.GetIconByUrl(ContentManager.PreferenceIconUrl);

            toolStripMenuItem_font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIconByUrl(ContentManager.FontIconIncrease);
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIconByUrl(ContentManager.FontIconDecrease);
            //toolStripMenuItem_add.Image = ContentManager.GetIconByUrl(ContentManager.AddWalletIconUrl);
            toolStripMenuItem_update.Image = ContentManager.GetIconByUrl(ContentManager.RefreshIcon);

            if (PreferenceManager.preferences.ArbitragePreferences.ShowCharts)
            {
                toolStripMenuItem_chart.Text = "Hide Charts";
                toolStripMenuItem_chart.Image = Properties.Resources.ConnectionStatus_ACTIVE;
            }
            else
            {
                toolStripMenuItem_chart.Text = "Show Charts";
                toolStripMenuItem_chart.Image = Properties.Resources.ConnectionStatus_ERROR;
            }

            //Timer timer = new Timer();
            //timer.Interval = (60 * 1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            SetWatchlist();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            LogManager.AddLogMessage(Name, "timer_Tick", "Ticked", LogManager.LogMessageType.DEBUG);
            UpdateUI();
        }
        #endregion

        #region Delegates
        delegate void DisposeTimerCallback();
        public void DisposeTimer()
        {
            if (this.InvokeRequired)
            {
                DisposeTimerCallback d = new DisposeTimerCallback(DisposeTimer);
                this.Invoke(d, new object[] { });
            }
            else
            {
                //toolStrip.Font = ParentForm.Font;
                timer.Stop();
                timer.Tick -= timer_Tick;
                timer.Dispose();
            }
        }

        delegate void UpdateUICallback(bool resize = false);
        public void UpdateUI(bool resize = false)
        {
            if (this.flowLayoutPanel.InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                this.flowLayoutPanel.Invoke(d, new object[] { resize });
            }
            else
            {
                try
                {
                    //LogManager.AddDebugMessage(Name, "UpdateUI", "1 colcount=" + listView.OLVGroups. .CollapsedGroups.Count());
                    //grouper.GroupTitle = ExchangeManager.coinBalanceList.Select(s => s.Symbol).Distinct().Count() + " Coins";
                    foreach (Control control in flowLayoutPanel.Controls)
                    {
                        if (control is ArbitrageItemControl)
                        {
                            ArbitrageItemControl item = control as ArbitrageItemControl;
                            item.UpdateUI(resize);
                        }
                    }

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
                toolStrip.Font = ParentForm.Font;
            }
        }

        delegate void SetWatchlistCallback();
        public void SetWatchlist()
        {
            if (this.flowLayoutPanel.InvokeRequired)
            {
                SetWatchlistCallback d = new SetWatchlistCallback(SetWatchlist);
                this.flowLayoutPanel.Invoke(d, new object[] { });
            }
            else
            {
                flowLayoutPanel.Controls.Clear();

                int chartHeight = 0;
                int rowHeight = 20;
                int statusHeight = 22;
                int padding = 20;
                int barCount = 2;

                if (PreferenceManager.preferences.ArbitragePreferences.ShowCharts)
                {
                    chartHeight = 275;
                    barCount = 3;
                }

                int controlHeight = chartHeight + (rowHeight * ExchangeManager.Exchanges.Count) + (statusHeight * barCount) + padding;

                // USD
                foreach (ExchangeManager.ExchangeTicker ticker in PreferenceManager.preferences.ArbitragePreferences.ArbitrageWatchList)
                {
                    ArbitrageItemControl control = new ArbitrageItemControl();
                    //LogManager.AddLogMessage(Name, "SetWatchlist", "ticker=" + ticker.symbol + " | " + ticker.market + " | " + ticker.last, LogManager.LogMessageType.DEBUG);
                    control.Height = controlHeight;

                    flowLayoutPanel.Controls.Add(control);
                    control.SetData(ticker.symbol, "USD");
                }
                
                UpdateUI(true);
            }
        }
        #endregion

        #region EventHandlers
        private void ToggleCharts()
        {
            if (PreferenceManager.preferences.ArbitragePreferences.ShowCharts)
            {
                // Remove Charts
                PreferenceManager.preferences.ArbitragePreferences.ShowCharts = false;
                PreferenceManager.UpdatePreferencesFile();
                //toolStripButton_charts.Text = "Show Charts";
                //toolStripButton_charts.Image = Properties.Resources.ConnectionStatus_ERROR;
                //controlSize = new Size(150, 150);
                toolStripMenuItem_chart.Text = "Show Charts";
                toolStripMenuItem_chart.Image = Properties.Resources.ConnectionStatus_ERROR;
            }
            else
            {
                // Add Charts
                PreferenceManager.preferences.ArbitragePreferences.ShowCharts = true;
                PreferenceManager.UpdatePreferencesFile();
                //toolStripButton_charts.Text = "Hide Charts";
                //toolStripButton_charts.Image = Properties.Resources.ConnectionStatus_ACTIVE;
                //controlSize = new Size(150, 300);
                toolStripMenuItem_chart.Text = "Hide Charts";
                toolStripMenuItem_chart.Image = Properties.Resources.ConnectionStatus_ACTIVE;
            }
            //UpdateUI();
            SetWatchlist();
        }
        private void toolStripButton_addSymbol_Click(object sender, EventArgs e)
        {
            //LogManager.AddDebugMessage(Name, "toolStripTextBox_addSymbol_Enter", "ENTER KEY : text=" + toolStripTextBox_addSymbol.Text);
            //ExchangeManager.AddWatchlistItem("USD", toolStripTextBox_addSymbol.Text.ToUpper());
            PreferenceManager.AddArbitrageWatchListItem(toolStripTextBox_symbol.Text.ToUpper(), "USD");
            toolStripTextBox_symbol.Text = String.Empty;
        }
        private void toolStripButton_charts_Click(object sender, EventArgs e)
        {
            ToggleCharts();
        }
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
                            ParentForm.Font = dialog.Font;
                        }
                        UpdateUI(true);
                        break;

                    case "FontIncrease":
                        ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style);
                        UpdateUI(true);
                        break;

                    case "FontDecrease":
                        ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style);
                        UpdateUI(true);
                        break;

                    case "Charts":
                        ToggleCharts();
                        break;

                    case "Update":
                        UpdateUI();
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