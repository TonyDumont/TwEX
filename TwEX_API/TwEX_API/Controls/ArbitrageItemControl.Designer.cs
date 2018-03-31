namespace TwEX_API.Controls
{
    partial class ArbitrageItemControl
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_symbol = new System.Windows.Forms.ToolStripLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.arbitrageListControl_btc = new TwEX_API.Controls.ArbitrageListControl();
            this.arbitrageListControl_usd = new TwEX_API.Controls.ArbitrageListControl();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.tableLayoutPanel.SetColumnSpan(this.toolStrip, 2);
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_symbol});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(301, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel_symbol
            // 
            this.toolStripLabel_symbol.Name = "toolStripLabel_symbol";
            this.toolStripLabel_symbol.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel_symbol.Text = "SYMBOL";
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel.SetColumnSpan(this.panel, 2);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 25);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(301, 163);
            this.panel.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.toolStrip, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.arbitrageListControl_btc, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.arbitrageListControl_usd, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(301, 424);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // arbitrageListControl_btc
            // 
            this.arbitrageListControl_btc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.arbitrageListControl_btc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arbitrageListControl_btc.Location = new System.Drawing.Point(3, 191);
            this.arbitrageListControl_btc.Name = "arbitrageListControl_btc";
            this.arbitrageListControl_btc.Size = new System.Drawing.Size(144, 230);
            this.arbitrageListControl_btc.TabIndex = 2;
            // 
            // arbitrageListControl_usd
            // 
            this.arbitrageListControl_usd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.arbitrageListControl_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arbitrageListControl_usd.Location = new System.Drawing.Point(153, 191);
            this.arbitrageListControl_usd.Name = "arbitrageListControl_usd";
            this.arbitrageListControl_usd.Size = new System.Drawing.Size(145, 230);
            this.arbitrageListControl_usd.TabIndex = 3;
            // 
            // ArbitrageItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "ArbitrageItemControl";
            this.Size = new System.Drawing.Size(301, 424);
            this.Load += new System.EventHandler(this.ArbitrageItemControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_symbol;
        private System.Windows.Forms.Panel panel;
        //private ArbitrageListControl arbitrageListControl_usd;
        //private ArbitrageListControl arbitrageListControl_btc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private ArbitrageListControl arbitrageListControl_btc;
        private ArbitrageListControl arbitrageListControl_usd;
    }
}
