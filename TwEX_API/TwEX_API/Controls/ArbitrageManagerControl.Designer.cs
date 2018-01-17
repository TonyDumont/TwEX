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
            this.toolStripButton_addSymbol = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox_symbol = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_charts = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripButton_Font = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_FontDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FontUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_addSymbol,
            this.toolStripTextBox_symbol,
            this.toolStripButton_Font,
            this.toolStripSeparator1,
            this.toolStripButton_FontDown,
            this.toolStripSeparator3,
            this.toolStripButton_FontUp,
            this.toolStripSeparator2,
            this.toolStripButton_charts});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(550, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton_addSymbol
            // 
            this.toolStripButton_addSymbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_addSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_addSymbol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_addSymbol.Image")));
            this.toolStripButton_addSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addSymbol.Name = "toolStripButton_addSymbol";
            this.toolStripButton_addSymbol.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_addSymbol.Text = "Add Symbol";
            this.toolStripButton_addSymbol.Click += new System.EventHandler(this.toolStripButton_addSymbol_Click);
            // 
            // toolStripTextBox_symbol
            // 
            this.toolStripTextBox_symbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox_symbol.Name = "toolStripTextBox_symbol";
            this.toolStripTextBox_symbol.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButton_charts
            // 
            this.toolStripButton_charts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_charts.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_charts.Image")));
            this.toolStripButton_charts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_charts.Name = "toolStripButton_charts";
            this.toolStripButton_charts.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton_charts.Text = "Hide Charts";
            this.toolStripButton_charts.Click += new System.EventHandler(this.toolStripButton_charts_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(550, 325);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // toolStripButton_Font
            // 
            this.toolStripButton_Font.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Font.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Font.Image")));
            this.toolStripButton_Font.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Font.Name = "toolStripButton_Font";
            this.toolStripButton_Font.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Font.Text = "FONT";
            this.toolStripButton_Font.Click += new System.EventHandler(this.toolStripButton_Font_Click);
            // 
            // toolStripButton_FontDown
            // 
            this.toolStripButton_FontDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_FontDown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_FontDown.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_FontDown.Image")));
            this.toolStripButton_FontDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FontDown.Name = "toolStripButton_FontDown";
            this.toolStripButton_FontDown.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_FontDown.Text = "-";
            this.toolStripButton_FontDown.ToolTipText = "Decrease Font Size";
            this.toolStripButton_FontDown.Click += new System.EventHandler(this.toolStripButton_FontDown_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_FontUp
            // 
            this.toolStripButton_FontUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_FontUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_FontUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_FontUp.Image")));
            this.toolStripButton_FontUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FontUp.Name = "toolStripButton_FontUp";
            this.toolStripButton_FontUp.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_FontUp.Text = "+";
            this.toolStripButton_FontUp.ToolTipText = "Increase Font Size";
            this.toolStripButton_FontUp.Click += new System.EventHandler(this.toolStripButton_FontUp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ArbitrageManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "ArbitrageManagerControl";
            this.Size = new System.Drawing.Size(550, 350);
            this.Load += new System.EventHandler(this.ArbitrageManagerControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ToolStripButton toolStripButton_addSymbol;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_symbol;
        private System.Windows.Forms.ToolStripButton toolStripButton_charts;
        private System.Windows.Forms.ToolStripButton toolStripButton_Font;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FontDialog fontDialog;
    }
}
