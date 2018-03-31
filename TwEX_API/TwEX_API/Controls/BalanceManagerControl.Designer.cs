namespace TwEX_API.Controls
{
    partial class BalanceManagerControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 65.62D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 75.54D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60.45D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 55.73D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 70.42D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceManagerControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip_status = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_count = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_usd = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_btc = new System.Windows.Forms.ToolStripLabel();
            this.toolStripRadioButton_balance = new TwEX_API.ToolStripRadioButton();
            this.toolStripRadioButton_exchange = new TwEX_API.ToolStripRadioButton();
            this.toolStripRadioButton_symbol = new TwEX_API.ToolStripRadioButton();
            this.toolStripRadioButton_fork = new TwEX_API.ToolStripRadioButton();
            this.toolStripRadioButton_orders = new TwEX_API.ToolStripRadioButton();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.toolStrip_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRadioButton_balance,
            this.toolStripSeparator1,
            this.toolStripRadioButton_exchange,
            this.toolStripSeparator4,
            this.toolStripRadioButton_symbol,
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator5,
            this.toolStripRadioButton_fork,
            this.toolStripSeparator2,
            this.toolStripRadioButton_orders});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(777, 39);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(45, 36);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(773, 127);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 6;
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart.BackSecondaryColor = System.Drawing.Color.White;
            this.chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart.BorderSkin.BorderWidth = 0;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.PointGapDepth = 0;
            chartArea1.Area3DStyle.Rotation = 0;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.CustomProperties = "DoughnutRadius=60, PieDrawingStyle=SoftEdge, PieLabelStyle=Disabled";
            series1.Legend = "Default";
            series1.Name = "Default";
            dataPoint1.CustomProperties = "Exploded=false";
            dataPoint1.Label = "France";
            dataPoint2.CustomProperties = "Exploded=false";
            dataPoint2.Label = "Canada";
            dataPoint3.CustomProperties = "Exploded=false";
            dataPoint3.Label = "UK";
            dataPoint4.CustomProperties = "Exploded=false";
            dataPoint4.Label = "USA";
            dataPoint5.CustomProperties = "Exploded=false";
            dataPoint5.Label = "Italy";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(773, 151);
            this.chart.TabIndex = 7;
            title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title1.Name = "Title_exchange";
            title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.ShadowOffset = 3;
            title1.Text = "Exchanges By Percentage";
            title2.Name = "Title_symbol";
            title2.Text = "Symbols By Percentage";
            title2.Visible = false;
            this.chart.Titles.Add(title1);
            this.chart.Titles.Add(title2);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 39);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabControl);
            this.splitContainer.Panel1.Controls.Add(this.toolStrip_status);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.chart);
            this.splitContainer.Size = new System.Drawing.Size(777, 315);
            this.splitContainer.SplitterDistance = 156;
            this.splitContainer.TabIndex = 8;
            // 
            // toolStrip_status
            // 
            this.toolStrip_status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_count,
            this.toolStripLabel_usd,
            this.toolStripSeparator3,
            this.toolStripLabel_btc});
            this.toolStrip_status.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_status.Name = "toolStrip_status";
            this.toolStrip_status.Size = new System.Drawing.Size(773, 25);
            this.toolStrip_status.TabIndex = 7;
            this.toolStrip_status.Text = "toolStrip1";
            // 
            // toolStripLabel_count
            // 
            this.toolStripLabel_count.Name = "toolStripLabel_count";
            this.toolStripLabel_count.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel_count.Text = "COUNT";
            // 
            // toolStripLabel_usd
            // 
            this.toolStripLabel_usd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_usd.Name = "toolStripLabel_usd";
            this.toolStripLabel_usd.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel_usd.Text = "USD";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_btc
            // 
            this.toolStripLabel_btc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_btc.Name = "toolStripLabel_btc";
            this.toolStripLabel_btc.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel_btc.Text = "BTC";
            // 
            // toolStripRadioButton_balance
            // 
            this.toolStripRadioButton_balance.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_balance.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_balance.CheckOnClick = true;
            this.toolStripRadioButton_balance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_balance.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_balance.Image")));
            this.toolStripRadioButton_balance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_balance.Name = "toolStripRadioButton_balance";
            this.toolStripRadioButton_balance.RadioButtonGroupId = 0;
            this.toolStripRadioButton_balance.Size = new System.Drawing.Size(36, 36);
            this.toolStripRadioButton_balance.Tag = "balance";
            this.toolStripRadioButton_balance.Text = "Balance View";
            this.toolStripRadioButton_balance.Click += new System.EventHandler(this.toolStripRadioButton_view_Click);
            // 
            // toolStripRadioButton_exchange
            // 
            this.toolStripRadioButton_exchange.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_exchange.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_exchange.CheckOnClick = true;
            this.toolStripRadioButton_exchange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_exchange.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_exchange.Image")));
            this.toolStripRadioButton_exchange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_exchange.Name = "toolStripRadioButton_exchange";
            this.toolStripRadioButton_exchange.RadioButtonGroupId = 0;
            this.toolStripRadioButton_exchange.Size = new System.Drawing.Size(36, 36);
            this.toolStripRadioButton_exchange.Tag = "exchange";
            this.toolStripRadioButton_exchange.Text = "Exchange View";
            this.toolStripRadioButton_exchange.Click += new System.EventHandler(this.toolStripRadioButton_view_Click);
            // 
            // toolStripRadioButton_symbol
            // 
            this.toolStripRadioButton_symbol.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_symbol.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_symbol.CheckOnClick = true;
            this.toolStripRadioButton_symbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_symbol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_symbol.Image")));
            this.toolStripRadioButton_symbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_symbol.Name = "toolStripRadioButton_symbol";
            this.toolStripRadioButton_symbol.RadioButtonGroupId = 0;
            this.toolStripRadioButton_symbol.Size = new System.Drawing.Size(36, 36);
            this.toolStripRadioButton_symbol.Tag = "symbol";
            this.toolStripRadioButton_symbol.Text = "Symbol View";
            this.toolStripRadioButton_symbol.Click += new System.EventHandler(this.toolStripRadioButton_view_Click);
            // 
            // toolStripRadioButton_fork
            // 
            this.toolStripRadioButton_fork.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRadioButton_fork.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_fork.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_fork.CheckOnClick = true;
            this.toolStripRadioButton_fork.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_fork.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_fork.Image")));
            this.toolStripRadioButton_fork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_fork.Name = "toolStripRadioButton_fork";
            this.toolStripRadioButton_fork.RadioButtonGroupId = 0;
            this.toolStripRadioButton_fork.Size = new System.Drawing.Size(36, 36);
            this.toolStripRadioButton_fork.Tag = "forks";
            this.toolStripRadioButton_fork.Text = "Forks View";
            this.toolStripRadioButton_fork.Click += new System.EventHandler(this.toolStripRadioButton_view_Click);
            // 
            // toolStripRadioButton_orders
            // 
            this.toolStripRadioButton_orders.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRadioButton_orders.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_orders.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_orders.CheckOnClick = true;
            this.toolStripRadioButton_orders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_orders.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_orders.Image")));
            this.toolStripRadioButton_orders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_orders.Name = "toolStripRadioButton_orders";
            this.toolStripRadioButton_orders.RadioButtonGroupId = 0;
            this.toolStripRadioButton_orders.Size = new System.Drawing.Size(36, 36);
            this.toolStripRadioButton_orders.Tag = "orders";
            this.toolStripRadioButton_orders.Text = "Orders View";
            this.toolStripRadioButton_orders.Click += new System.EventHandler(this.toolStripRadioButton_view_Click);
            // 
            // BalanceManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BalanceManagerControl";
            this.Size = new System.Drawing.Size(777, 354);
            this.Load += new System.EventHandler(this.BalanceManagerControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.toolStrip_status.ResumeLayout(false);
            this.toolStrip_status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private ToolStripRadioButton toolStripRadioButton_symbol;
        private ToolStripRadioButton toolStripRadioButton_exchange;
        private ToolStripRadioButton toolStripRadioButton_balance;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.SplitContainer splitContainer;
        private ToolStripRadioButton toolStripRadioButton_orders;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip_status;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_count;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_usd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_btc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private ToolStripRadioButton toolStripRadioButton_fork;
    }
}
