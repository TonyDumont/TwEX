using System;
using System.Drawing;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class ArbitrageManagerControl : UserControl
    {
        #region Initialize
        public ArbitrageManagerControl()
        {
            InitializeComponent();
            FormManager.arbitrageManagerControl = this;
        }
        private void ArbitrageManagerControl_Load(object sender, EventArgs e)
        {
            toolStripButton_Font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            if (PreferenceManager.preferences.ArbitragePreferences.ShowCharts)
            {
                toolStripButton_charts.Text = "Hide Charts";
            }
            else
            {
                toolStripButton_charts.Text = "Show Charts";
            }
            SetWatchlist();
        }
        #endregion

        #region Delegates
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
                foreach (ExchangeManager.ExchangeTicker item in PreferenceManager.preferences.ArbitragePreferences.ArbitrageWatchList)
                {
                    ArbitrageItemControl control = new ArbitrageItemControl();
                    control.Height = controlHeight;

                    flowLayoutPanel.Controls.Add(control);
                    control.SetData(item.symbol, "USD");
                }
                
                UpdateUI(true);
            }
        }
        #endregion

        #region EventHandlers
        private void toolStripButton_addSymbol_Click(object sender, EventArgs e)
        {
            //LogManager.AddDebugMessage(Name, "toolStripTextBox_addSymbol_Enter", "ENTER KEY : text=" + toolStripTextBox_addSymbol.Text);
            //ExchangeManager.AddWatchlistItem("USD", toolStripTextBox_addSymbol.Text.ToUpper());
            PreferenceManager.AddArbitrageWatchListItem(toolStripTextBox_symbol.Text.ToUpper(), "USD");
            toolStripTextBox_symbol.Text = String.Empty;
        }
        private void toolStripButton_charts_Click(object sender, EventArgs e)
        {
            if (PreferenceManager.preferences.ArbitragePreferences.ShowCharts)
            {
                // Remove Charts
                PreferenceManager.preferences.ArbitragePreferences.ShowCharts = false;
                PreferenceManager.UpdatePreferencesFile();
                toolStripButton_charts.Text = "Show Charts";
                //controlSize = new Size(150, 150);
            }
            else
            {
                // Add Charts
                PreferenceManager.preferences.ArbitragePreferences.ShowCharts = true;
                PreferenceManager.UpdatePreferencesFile();
                toolStripButton_charts.Text = "Hide Charts";
                //controlSize = new Size(150, 300);
            }
            //UpdateUI();
            SetWatchlist();
        }
        private void toolStripButton_FontDown_Click(object sender, EventArgs e)
        {
            ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style);
            UpdateUI(true);
        }
        private void toolStripButton_FontUp_Click(object sender, EventArgs e)
        {
            ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style);
            UpdateUI(true);
        }
        private void toolStripButton_Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = ParentForm.Font;
            DialogResult result = fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ParentForm.Font = fontDialog.Font;
            }
            UpdateUI(true);
        }
        #endregion
    }
}
