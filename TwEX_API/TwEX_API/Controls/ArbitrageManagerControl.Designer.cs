namespace TwEX_API.Controls
{
    partial class ArbitrageManagerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArbitrageManagerControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_chart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_list = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_update = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator_left3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_lastUpdate = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator_right1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripNumberControl_maxItems = new TwEX_API.ToolStripNumberControl();
            this.toolStripLabel_max = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator_right2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton_period = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_1D = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_1W = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_2W = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_1M = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_3M = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_6M = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_1Y = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel_period = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton_market = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_btc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_usd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton_watchlists = new System.Windows.Forms.ToolStripDropDownButton();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator_left3,
            this.toolStripLabel_lastUpdate,
            this.toolStripSeparator_right1,
            this.toolStripNumberControl_maxItems,
            this.toolStripLabel_max,
            this.toolStripSeparator_right2,
            this.toolStripDropDownButton_period,
            this.toolStripLabel_period,
            this.toolStripSeparator3,
            this.toolStripDropDownButton_market,
            this.toolStripDropDownButton_watchlists});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(804, 26);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease,
            this.toolStripSeparator5,
            this.toolStripMenuItem_chart,
            this.toolStripSeparator1,
            this.toolStripMenuItem_list,
            this.toolStripSeparator2,
            this.toolStripMenuItem_update});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(29, 23);
            this.toolStripDropDownButton_menu.Text = "OPTIONS";
            this.toolStripDropDownButton_menu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_menu_DropDownItemClicked);
            // 
            // toolStripMenuItem_font
            // 
            this.toolStripMenuItem_font.Name = "toolStripMenuItem_font";
            this.toolStripMenuItem_font.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_font.Tag = "Font";
            this.toolStripMenuItem_font.Text = "Font";
            // 
            // toolStripMenuItem_fontIncrease
            // 
            this.toolStripMenuItem_fontIncrease.Name = "toolStripMenuItem_fontIncrease";
            this.toolStripMenuItem_fontIncrease.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_fontIncrease.Tag = "FontIncrease";
            this.toolStripMenuItem_fontIncrease.Text = "Increase Font";
            // 
            // toolStripMenuItem_fontDecrease
            // 
            this.toolStripMenuItem_fontDecrease.Name = "toolStripMenuItem_fontDecrease";
            this.toolStripMenuItem_fontDecrease.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_fontDecrease.Tag = "FontDecrease";
            this.toolStripMenuItem_fontDecrease.Text = "Decrease Font";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_chart
            // 
            this.toolStripMenuItem_chart.Name = "toolStripMenuItem_chart";
            this.toolStripMenuItem_chart.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_chart.Tag = "Charts";
            this.toolStripMenuItem_chart.Text = "Hide Charts";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_list
            // 
            this.toolStripMenuItem_list.Name = "toolStripMenuItem_list";
            this.toolStripMenuItem_list.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_list.Tag = "Lists";
            this.toolStripMenuItem_list.Text = "Hide Lists";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_update
            // 
            this.toolStripMenuItem_update.Name = "toolStripMenuItem_update";
            this.toolStripMenuItem_update.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_update.Tag = "Update";
            this.toolStripMenuItem_update.Text = "Refresh All";
            // 
            // toolStripSeparator_left3
            // 
            this.toolStripSeparator_left3.Name = "toolStripSeparator_left3";
            this.toolStripSeparator_left3.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripLabel_lastUpdate
            // 
            this.toolStripLabel_lastUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_lastUpdate.Name = "toolStripLabel_lastUpdate";
            this.toolStripLabel_lastUpdate.Size = new System.Drawing.Size(75, 23);
            this.toolStripLabel_lastUpdate.Text = "Last Update :";
            // 
            // toolStripSeparator_right1
            // 
            this.toolStripSeparator_right1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator_right1.Name = "toolStripSeparator_right1";
            this.toolStripSeparator_right1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripNumberControl_maxItems
            // 
            this.toolStripNumberControl_maxItems.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripNumberControl_maxItems.Name = "toolStripNumberControl_maxItems";
            this.toolStripNumberControl_maxItems.Size = new System.Drawing.Size(41, 23);
            this.toolStripNumberControl_maxItems.Text = "8";
            this.toolStripNumberControl_maxItems.ValueChanged += new System.EventHandler(this.toolStripNumberControl_maxItems_ValueChanged);
            // 
            // toolStripLabel_max
            // 
            this.toolStripLabel_max.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_max.Name = "toolStripLabel_max";
            this.toolStripLabel_max.Size = new System.Drawing.Size(67, 23);
            this.toolStripLabel_max.Text = "Max Items :";
            // 
            // toolStripSeparator_right2
            // 
            this.toolStripSeparator_right2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator_right2.Name = "toolStripSeparator_right2";
            this.toolStripSeparator_right2.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripDropDownButton_period
            // 
            this.toolStripDropDownButton_period.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton_period.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_period.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_1D,
            this.toolStripMenuItem_1W,
            this.toolStripMenuItem_2W,
            this.toolStripMenuItem_1M,
            this.toolStripMenuItem_3M,
            this.toolStripMenuItem_6M,
            this.toolStripMenuItem_1Y});
            this.toolStripDropDownButton_period.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripDropDownButton_period.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_period.Image")));
            this.toolStripDropDownButton_period.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_period.Name = "toolStripDropDownButton_period";
            this.toolStripDropDownButton_period.Size = new System.Drawing.Size(51, 23);
            this.toolStripDropDownButton_period.Text = "1 Day";
            this.toolStripDropDownButton_period.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_period_DropDownItemClicked);
            // 
            // toolStripMenuItem_1D
            // 
            this.toolStripMenuItem_1D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem_1D.Name = "toolStripMenuItem_1D";
            this.toolStripMenuItem_1D.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_1D.Tag = "Day_1D";
            this.toolStripMenuItem_1D.Text = "1 Day";
            // 
            // toolStripMenuItem_1W
            // 
            this.toolStripMenuItem_1W.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem_1W.Name = "toolStripMenuItem_1W";
            this.toolStripMenuItem_1W.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_1W.Tag = "Week_1W";
            this.toolStripMenuItem_1W.Text = "1 Week";
            // 
            // toolStripMenuItem_2W
            // 
            this.toolStripMenuItem_2W.Name = "toolStripMenuItem_2W";
            this.toolStripMenuItem_2W.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_2W.Tag = "Week_2W";
            this.toolStripMenuItem_2W.Text = "2 Weeks";
            // 
            // toolStripMenuItem_1M
            // 
            this.toolStripMenuItem_1M.Name = "toolStripMenuItem_1M";
            this.toolStripMenuItem_1M.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_1M.Tag = "Month_1M";
            this.toolStripMenuItem_1M.Text = "1 Month";
            // 
            // toolStripMenuItem_3M
            // 
            this.toolStripMenuItem_3M.Name = "toolStripMenuItem_3M";
            this.toolStripMenuItem_3M.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_3M.Tag = "Month_3M";
            this.toolStripMenuItem_3M.Text = "3 Months";
            // 
            // toolStripMenuItem_6M
            // 
            this.toolStripMenuItem_6M.Name = "toolStripMenuItem_6M";
            this.toolStripMenuItem_6M.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_6M.Tag = "Month_6M";
            this.toolStripMenuItem_6M.Text = "6 Months";
            // 
            // toolStripMenuItem_1Y
            // 
            this.toolStripMenuItem_1Y.Name = "toolStripMenuItem_1Y";
            this.toolStripMenuItem_1Y.Size = new System.Drawing.Size(126, 22);
            this.toolStripMenuItem_1Y.Tag = "Year_1Y";
            this.toolStripMenuItem_1Y.Text = "1 Year";
            // 
            // toolStripLabel_period
            // 
            this.toolStripLabel_period.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_period.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripLabel_period.Name = "toolStripLabel_period";
            this.toolStripLabel_period.Size = new System.Drawing.Size(44, 23);
            this.toolStripLabel_period.Text = "Period:";
            // 
            // toolStripDropDownButton_market
            // 
            this.toolStripDropDownButton_market.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton_market.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_btc,
            this.toolStripMenuItem_usd});
            this.toolStripDropDownButton_market.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_market.Image")));
            this.toolStripDropDownButton_market.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_market.Name = "toolStripDropDownButton_market";
            this.toolStripDropDownButton_market.Size = new System.Drawing.Size(58, 23);
            this.toolStripDropDownButton_market.Text = "USD";
            this.toolStripDropDownButton_market.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_market_DropDownItemClicked);
            // 
            // toolStripMenuItem_btc
            // 
            this.toolStripMenuItem_btc.Name = "toolStripMenuItem_btc";
            this.toolStripMenuItem_btc.Size = new System.Drawing.Size(96, 22);
            this.toolStripMenuItem_btc.Text = "BTC";
            // 
            // toolStripMenuItem_usd
            // 
            this.toolStripMenuItem_usd.Name = "toolStripMenuItem_usd";
            this.toolStripMenuItem_usd.Size = new System.Drawing.Size(96, 22);
            this.toolStripMenuItem_usd.Text = "USD";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripDropDownButton_watchlists
            // 
            this.toolStripDropDownButton_watchlists.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_watchlists.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_watchlists.Image")));
            this.toolStripDropDownButton_watchlists.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_watchlists.Name = "toolStripDropDownButton_watchlists";
            this.toolStripDropDownButton_watchlists.Size = new System.Drawing.Size(106, 23);
            this.toolStripDropDownButton_watchlists.Text = "Select WatchList";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 26);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(804, 418);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // ArbitrageManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "ArbitrageManagerControl";
            this.Size = new System.Drawing.Size(804, 444);
            this.Load += new System.EventHandler(this.ArbitrageManagerControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_update;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_chart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_lastUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_right1;
        private ToolStripNumberControl toolStripNumberControl_maxItems;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_max;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_right2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_period;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_period;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_1D;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_1W;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_2W;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_1M;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_3M;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_6M;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_1Y;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_left3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_market;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_btc;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_usd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_list;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_watchlists;
    }
}
