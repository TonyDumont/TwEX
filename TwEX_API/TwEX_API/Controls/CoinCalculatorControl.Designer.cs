﻿namespace TwEX_API.Controls
{
    partial class CoinCalculatorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoinCalculatorControl));
            this.toolStrip_footer = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Font = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FontDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FontUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_AddSymbol = new System.Windows.Forms.ToolStripButton();
            this.toolStripSpringTextBox_symbol = new TwEX_API.ToolStripSpringTextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_value = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.numericUpDown_usd = new System.Windows.Forms.NumericUpDown();
            this.label_usd = new System.Windows.Forms.Label();
            this.numericUpDown_symbol = new System.Windows.Forms.NumericUpDown();
            this.label_symbol = new System.Windows.Forms.Label();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_footer.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_usd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_symbol)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_footer
            // 
            this.toolStrip_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_footer.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip_footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Font,
            this.toolStripSeparator3,
            this.toolStripButton_FontDown,
            this.toolStripSeparator1,
            this.toolStripButton_FontUp,
            this.toolStripSeparator2,
            this.toolStripButton_AddSymbol,
            this.toolStripSpringTextBox_symbol});
            this.toolStrip_footer.Location = new System.Drawing.Point(0, 357);
            this.toolStrip_footer.Name = "toolStrip_footer";
            this.toolStrip_footer.Size = new System.Drawing.Size(453, 39);
            this.toolStrip_footer.TabIndex = 0;
            this.toolStrip_footer.Text = "toolStrip1";
            // 
            // toolStripButton_Font
            // 
            this.toolStripButton_Font.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Font.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Font.Image")));
            this.toolStripButton_Font.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Font.Name = "toolStripButton_Font";
            this.toolStripButton_Font.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Font.Text = "FONT";
            this.toolStripButton_Font.Click += new System.EventHandler(this.toolStripButton_Font_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_FontDown
            // 
            this.toolStripButton_FontDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_FontDown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_FontDown.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_FontDown.Image")));
            this.toolStripButton_FontDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FontDown.Name = "toolStripButton_FontDown";
            this.toolStripButton_FontDown.Size = new System.Drawing.Size(23, 36);
            this.toolStripButton_FontDown.Text = "-";
            this.toolStripButton_FontDown.ToolTipText = "Decrease Font Size";
            this.toolStripButton_FontDown.Click += new System.EventHandler(this.toolStripButton_FontDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_FontUp
            // 
            this.toolStripButton_FontUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_FontUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_FontUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_FontUp.Image")));
            this.toolStripButton_FontUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FontUp.Name = "toolStripButton_FontUp";
            this.toolStripButton_FontUp.Size = new System.Drawing.Size(23, 36);
            this.toolStripButton_FontUp.Text = "+";
            this.toolStripButton_FontUp.ToolTipText = "Increase Font Size";
            this.toolStripButton_FontUp.Click += new System.EventHandler(this.toolStripButton_FontUp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_AddSymbol
            // 
            this.toolStripButton_AddSymbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_AddSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_AddSymbol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddSymbol.Image")));
            this.toolStripButton_AddSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddSymbol.Name = "toolStripButton_AddSymbol";
            this.toolStripButton_AddSymbol.Size = new System.Drawing.Size(76, 36);
            this.toolStripButton_AddSymbol.Text = "Add Symbol";
            this.toolStripButton_AddSymbol.Click += new System.EventHandler(this.toolStripButton_AddSymbol_Click);
            // 
            // toolStripSpringTextBox_symbol
            // 
            this.toolStripSpringTextBox_symbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSpringTextBox_symbol.Name = "toolStripSpringTextBox_symbol";
            this.toolStripSpringTextBox_symbol.Size = new System.Drawing.Size(234, 39);
            this.toolStripSpringTextBox_symbol.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Controls.Add(this.listView, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_usd, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label_usd, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_symbol, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label_symbol, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(453, 357);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_symbol);
            this.listView.AllColumns.Add(this.column_value);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_symbol,
            this.column_value});
            this.tableLayoutPanel.SetColumnSpan(this.listView, 2);
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 55);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(447, 299);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 4;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.SelectionChanged += new System.EventHandler(this.listView_SelectionChanged);
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // column_symbol
            // 
            this.column_symbol.AspectName = "symbol";
            this.column_symbol.MinimumWidth = 130;
            this.column_symbol.Text = "Symbol";
            this.column_symbol.Width = 130;
            // 
            // column_value
            // 
            this.column_value.FillsFreeSpace = true;
            this.column_value.Text = "Value";
            this.column_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDown_usd
            // 
            this.numericUpDown_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_usd.Location = new System.Drawing.Point(3, 3);
            this.numericUpDown_usd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_usd.Name = "numericUpDown_usd";
            this.numericUpDown_usd.Size = new System.Drawing.Size(333, 20);
            this.numericUpDown_usd.TabIndex = 0;
            this.numericUpDown_usd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_usd.ValueChanged += new System.EventHandler(this.numericUpDown_usd_ValueChanged);
            // 
            // label_usd
            // 
            this.label_usd.AutoSize = true;
            this.label_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_usd.Location = new System.Drawing.Point(342, 0);
            this.label_usd.Name = "label_usd";
            this.label_usd.Size = new System.Drawing.Size(108, 26);
            this.label_usd.TabIndex = 1;
            this.label_usd.Text = "USD";
            this.label_usd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_symbol
            // 
            this.numericUpDown_symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_symbol.Location = new System.Drawing.Point(3, 29);
            this.numericUpDown_symbol.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_symbol.Name = "numericUpDown_symbol";
            this.numericUpDown_symbol.Size = new System.Drawing.Size(333, 20);
            this.numericUpDown_symbol.TabIndex = 2;
            this.numericUpDown_symbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_symbol.ValueChanged += new System.EventHandler(this.numericUpDown_symbol_ValueChanged);
            // 
            // label_symbol
            // 
            this.label_symbol.AutoSize = true;
            this.label_symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_symbol.Location = new System.Drawing.Point(342, 26);
            this.label_symbol.Name = "label_symbol";
            this.label_symbol.Size = new System.Drawing.Size(108, 26);
            this.label_symbol.TabIndex = 3;
            this.label_symbol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // CoinCalculatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.toolStrip_footer);
            this.Name = "CoinCalculatorControl";
            this.Size = new System.Drawing.Size(453, 396);
            this.Load += new System.EventHandler(this.CoinCalculatorControl_Load);
            this.toolStrip_footer.ResumeLayout(false);
            this.toolStrip_footer.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_usd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_symbol)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_footer;
        private System.Windows.Forms.ToolStripButton toolStripButton_Font;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.NumericUpDown numericUpDown_usd;
        private System.Windows.Forms.Label label_usd;
        private System.Windows.Forms.NumericUpDown numericUpDown_symbol;
        private System.Windows.Forms.Label label_symbol;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_symbol;
        private BrightIdeasSoftware.OLVColumn column_value;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSpringTextBox toolStripSpringTextBox_symbol;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddSymbol;
    }
}
