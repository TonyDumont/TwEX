namespace TwEX_API.Controls
{
    partial class ExchangeChartsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExchangeChartsControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_symbol = new System.Windows.Forms.ToolStripLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_CryptoCompare = new System.Windows.Forms.TabPage();
            this.tabPage_TradingView = new System.Windows.Forms.TabPage();
            this.toolStripRadioButton_CryptoCompare = new TwEX_API.ToolStripRadioButton();
            this.toolStripRadioButton_TradingView = new TwEX_API.ToolStripRadioButton();
            this.toolStripLabel_market = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip.SuspendLayout();
            this.panel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRadioButton_CryptoCompare,
            this.toolStripRadioButton_TradingView,
            this.toolStripLabel_symbol,
            this.toolStripSeparator1,
            this.toolStripLabel_market});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(733, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripLabel_symbol
            // 
            this.toolStripLabel_symbol.Name = "toolStripLabel_symbol";
            this.toolStripLabel_symbol.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel_symbol.Text = "SYM";
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.tabControl);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(733, 447);
            this.panel.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabPage_CryptoCompare);
            this.tabControl.Controls.Add(this.tabPage_TradingView);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(729, 443);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            // 
            // tabPage_CryptoCompare
            // 
            this.tabPage_CryptoCompare.Location = new System.Drawing.Point(4, 5);
            this.tabPage_CryptoCompare.Name = "tabPage_CryptoCompare";
            this.tabPage_CryptoCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_CryptoCompare.Size = new System.Drawing.Size(721, 434);
            this.tabPage_CryptoCompare.TabIndex = 0;
            this.tabPage_CryptoCompare.Text = "CryptoCompare";
            this.tabPage_CryptoCompare.UseVisualStyleBackColor = true;
            // 
            // tabPage_TradingView
            // 
            this.tabPage_TradingView.Location = new System.Drawing.Point(4, 5);
            this.tabPage_TradingView.Name = "tabPage_TradingView";
            this.tabPage_TradingView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_TradingView.Size = new System.Drawing.Size(721, 434);
            this.tabPage_TradingView.TabIndex = 1;
            this.tabPage_TradingView.Text = "TradingView";
            this.tabPage_TradingView.UseVisualStyleBackColor = true;
            // 
            // toolStripRadioButton_CryptoCompare
            // 
            this.toolStripRadioButton_CryptoCompare.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRadioButton_CryptoCompare.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_CryptoCompare.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_CryptoCompare.CheckOnClick = true;
            this.toolStripRadioButton_CryptoCompare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_CryptoCompare.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_CryptoCompare.Image")));
            this.toolStripRadioButton_CryptoCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_CryptoCompare.Name = "toolStripRadioButton_CryptoCompare";
            this.toolStripRadioButton_CryptoCompare.RadioButtonGroupId = 0;
            this.toolStripRadioButton_CryptoCompare.Size = new System.Drawing.Size(23, 22);
            this.toolStripRadioButton_CryptoCompare.Tag = "";
            this.toolStripRadioButton_CryptoCompare.Text = "CryptoCompare";
            this.toolStripRadioButton_CryptoCompare.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // toolStripRadioButton_TradingView
            // 
            this.toolStripRadioButton_TradingView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRadioButton_TradingView.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_TradingView.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_TradingView.CheckOnClick = true;
            this.toolStripRadioButton_TradingView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_TradingView.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_TradingView.Image")));
            this.toolStripRadioButton_TradingView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_TradingView.Name = "toolStripRadioButton_TradingView";
            this.toolStripRadioButton_TradingView.RadioButtonGroupId = 0;
            this.toolStripRadioButton_TradingView.Size = new System.Drawing.Size(23, 22);
            this.toolStripRadioButton_TradingView.Text = "TradingView";
            this.toolStripRadioButton_TradingView.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // toolStripLabel_market
            // 
            this.toolStripLabel_market.Name = "toolStripLabel_market";
            this.toolStripLabel_market.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel_market.Text = "MKT";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ExchangeChartsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStrip);
            this.Name = "ExchangeChartsControl";
            this.Size = new System.Drawing.Size(733, 472);
            this.Load += new System.EventHandler(this.ExchangeChartsControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_CryptoCompare;
        private System.Windows.Forms.TabPage tabPage_TradingView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_symbol;
        private ToolStripRadioButton toolStripRadioButton_CryptoCompare;
        private ToolStripRadioButton toolStripRadioButton_TradingView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_market;
    }
}
