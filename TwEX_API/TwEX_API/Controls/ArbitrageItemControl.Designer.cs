﻿namespace TwEX_API.Controls
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_symbol = new System.Windows.Forms.ToolStripLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_up = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_down = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.arbitrageListControl_btc = new TwEX_API.Controls.ArbitrageListControl();
            this.arbitrageListControl_usd = new TwEX_API.Controls.ArbitrageListControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip, 2);
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
            this.tableLayoutPanel1.SetColumnSpan(this.panel, 2);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(3, 28);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(295, 163);
            this.panel.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_up,
            this.toolStripMenuItem_down,
            this.toolStripSeparator1,
            this.toolStripMenuItem_remove,
            this.toolStripSeparator2,
            this.toolStripMenuItem_refresh});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(145, 104);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // toolStripMenuItem_up
            // 
            this.toolStripMenuItem_up.Name = "toolStripMenuItem_up";
            this.toolStripMenuItem_up.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_up.Tag = "up";
            this.toolStripMenuItem_up.Text = "Move UP";
            // 
            // toolStripMenuItem_down
            // 
            this.toolStripMenuItem_down.Name = "toolStripMenuItem_down";
            this.toolStripMenuItem_down.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_down.Tag = "down";
            this.toolStripMenuItem_down.Text = "Move DOWN";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripMenuItem_remove
            // 
            this.toolStripMenuItem_remove.Name = "toolStripMenuItem_remove";
            this.toolStripMenuItem_remove.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_remove.Tag = "remove";
            this.toolStripMenuItem_remove.Text = "REMOVE";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripMenuItem_refresh
            // 
            this.toolStripMenuItem_refresh.Name = "toolStripMenuItem_refresh";
            this.toolStripMenuItem_refresh.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_refresh.Tag = "refresh";
            this.toolStripMenuItem_refresh.Text = "REFRESH";
            // 
            // arbitrageListControl_btc
            // 
            this.arbitrageListControl_btc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.arbitrageListControl_btc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arbitrageListControl_btc.Location = new System.Drawing.Point(3, 197);
            this.arbitrageListControl_btc.Name = "arbitrageListControl_btc";
            this.arbitrageListControl_btc.Size = new System.Drawing.Size(144, 353);
            this.arbitrageListControl_btc.TabIndex = 1;
            // 
            // arbitrageListControl_usd
            // 
            this.arbitrageListControl_usd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.arbitrageListControl_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arbitrageListControl_usd.Location = new System.Drawing.Point(153, 197);
            this.arbitrageListControl_usd.Name = "arbitrageListControl_usd";
            this.arbitrageListControl_usd.Size = new System.Drawing.Size(145, 353);
            this.arbitrageListControl_usd.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.arbitrageListControl_usd, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.arbitrageListControl_btc, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(301, 424);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ArbitrageItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "ArbitrageItemControl";
            this.Size = new System.Drawing.Size(301, 424);
            this.Load += new System.EventHandler(this.ArbitrageItemControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_symbol;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_up;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_down;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_remove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ArbitrageListControl arbitrageListControl_usd;
        private ArbitrageListControl arbitrageListControl_btc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_refresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
