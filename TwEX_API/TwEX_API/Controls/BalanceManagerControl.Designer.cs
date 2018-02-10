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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceManagerControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripRadioButton_balance = new TwEX_API.ToolStripRadioButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRadioButton_exchange = new TwEX_API.ToolStripRadioButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRadioButton_symbol = new TwEX_API.ToolStripRadioButton();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.toolStrip.SuspendLayout();
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
            this.toolStripDropDownButton_menu});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(777, 39);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
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
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(0, 39);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(777, 315);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 6;
            // 
            // BalanceManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BalanceManagerControl";
            this.Size = new System.Drawing.Size(777, 354);
            this.Load += new System.EventHandler(this.BalanceManagerControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
    }
}
