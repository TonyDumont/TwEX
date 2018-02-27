namespace TwEX_API.Controls
{
    partial class ArbitragePriceControl
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_symbol = new System.Windows.Forms.ToolStripLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.panel_btc = new System.Windows.Forms.Panel();
            this.panel_usd = new System.Windows.Forms.Panel();
            this.toolStrip_btc_symbol = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_btc_symbol = new System.Windows.Forms.ToolStripLabel();
            this.listView_btc = new BrightIdeasSoftware.FastObjectListView();
            this.column_btc_icon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_btc_price = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip_btc_btc = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_btc_btc = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_btc_usd = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_btc_usd = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_usd_symbol = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_usd_symbol = new System.Windows.Forms.ToolStripLabel();
            this.listView_usd = new BrightIdeasSoftware.FastObjectListView();
            this.column_usd_icon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_usd_price = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip_usd_btc = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_usd_btc = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_usd_usd = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_usd_usd = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panel_btc.SuspendLayout();
            this.panel_usd.SuspendLayout();
            this.toolStrip_btc_symbol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_btc)).BeginInit();
            this.toolStrip_btc_btc.SuspendLayout();
            this.toolStrip_btc_usd.SuspendLayout();
            this.toolStrip_usd_symbol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_usd)).BeginInit();
            this.toolStrip_usd_btc.SuspendLayout();
            this.toolStrip_usd_usd.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.toolStrip, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panel_btc, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.panel_usd, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(330, 420);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // toolStrip
            // 
            this.tableLayoutPanel.SetColumnSpan(this.toolStrip, 2);
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_symbol});
            this.toolStrip.Location = new System.Drawing.Point(2, 2);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(326, 25);
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
            this.panel.Location = new System.Drawing.Point(2, 29);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(326, 163);
            this.panel.TabIndex = 0;
            // 
            // panel_btc
            // 
            this.panel_btc.Controls.Add(this.toolStrip_btc_symbol);
            this.panel_btc.Controls.Add(this.listView_btc);
            this.panel_btc.Controls.Add(this.toolStrip_btc_btc);
            this.panel_btc.Controls.Add(this.toolStrip_btc_usd);
            this.panel_btc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_btc.Location = new System.Drawing.Point(5, 197);
            this.panel_btc.Name = "panel_btc";
            this.panel_btc.Size = new System.Drawing.Size(156, 218);
            this.panel_btc.TabIndex = 2;
            // 
            // panel_usd
            // 
            this.panel_usd.Controls.Add(this.toolStrip_usd_symbol);
            this.panel_usd.Controls.Add(this.listView_usd);
            this.panel_usd.Controls.Add(this.toolStrip_usd_btc);
            this.panel_usd.Controls.Add(this.toolStrip_usd_usd);
            this.panel_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_usd.Location = new System.Drawing.Point(169, 197);
            this.panel_usd.Name = "panel_usd";
            this.panel_usd.Size = new System.Drawing.Size(156, 218);
            this.panel_usd.TabIndex = 3;
            // 
            // toolStrip_btc_symbol
            // 
            this.toolStrip_btc_symbol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_btc_symbol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_btc_symbol});
            this.toolStrip_btc_symbol.Location = new System.Drawing.Point(0, 143);
            this.toolStrip_btc_symbol.Name = "toolStrip_btc_symbol";
            this.toolStrip_btc_symbol.Size = new System.Drawing.Size(156, 25);
            this.toolStrip_btc_symbol.TabIndex = 10;
            this.toolStrip_btc_symbol.Text = "toolStrip1";
            // 
            // toolStripLabel_btc_symbol
            // 
            this.toolStripLabel_btc_symbol.Name = "toolStripLabel_btc_symbol";
            this.toolStripLabel_btc_symbol.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel_btc_symbol.Text = "SYM";
            // 
            // listView_btc
            // 
            this.listView_btc.AllColumns.Add(this.column_btc_icon);
            this.listView_btc.AllColumns.Add(this.column_btc_price);
            this.listView_btc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_btc.CellEditUseWholeCell = false;
            this.listView_btc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_btc_icon,
            this.column_btc_price});
            this.listView_btc.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView_btc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_btc.FullRowSelect = true;
            this.listView_btc.GridLines = true;
            this.listView_btc.HasCollapsibleGroups = false;
            this.listView_btc.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_btc.HideSelection = false;
            this.listView_btc.Location = new System.Drawing.Point(0, 0);
            this.listView_btc.MultiSelect = false;
            this.listView_btc.Name = "listView_btc";
            this.listView_btc.ShowGroups = false;
            this.listView_btc.Size = new System.Drawing.Size(156, 168);
            this.listView_btc.SortGroupItemsByPrimaryColumn = false;
            this.listView_btc.TabIndex = 9;
            this.listView_btc.UseCellFormatEvents = true;
            this.listView_btc.UseCompatibleStateImageBehavior = false;
            this.listView_btc.UseFiltering = true;
            this.listView_btc.View = System.Windows.Forms.View.Details;
            this.listView_btc.VirtualMode = true;
            // 
            // column_btc_icon
            // 
            this.column_btc_icon.AspectName = "";
            this.column_btc_icon.Text = "";
            this.column_btc_icon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_btc_icon.Width = 24;
            // 
            // column_btc_price
            // 
            this.column_btc_price.FillsFreeSpace = true;
            this.column_btc_price.Text = "Price";
            this.column_btc_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip_btc_btc
            // 
            this.toolStrip_btc_btc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_btc_btc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_btc_btc});
            this.toolStrip_btc_btc.Location = new System.Drawing.Point(0, 168);
            this.toolStrip_btc_btc.Name = "toolStrip_btc_btc";
            this.toolStrip_btc_btc.Size = new System.Drawing.Size(156, 25);
            this.toolStrip_btc_btc.TabIndex = 8;
            this.toolStrip_btc_btc.Text = "toolStrip_btc";
            // 
            // toolStripLabel_btc_btc
            // 
            this.toolStripLabel_btc_btc.Name = "toolStripLabel_btc_btc";
            this.toolStripLabel_btc_btc.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel_btc_btc.Text = "BTC";
            // 
            // toolStrip_btc_usd
            // 
            this.toolStrip_btc_usd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_btc_usd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_btc_usd});
            this.toolStrip_btc_usd.Location = new System.Drawing.Point(0, 193);
            this.toolStrip_btc_usd.Name = "toolStrip_btc_usd";
            this.toolStrip_btc_usd.Size = new System.Drawing.Size(156, 25);
            this.toolStrip_btc_usd.TabIndex = 7;
            this.toolStrip_btc_usd.Text = "toolStrip1";
            // 
            // toolStripLabel_btc_usd
            // 
            this.toolStripLabel_btc_usd.Name = "toolStripLabel_btc_usd";
            this.toolStripLabel_btc_usd.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel_btc_usd.Text = "USD";
            // 
            // toolStrip_usd_symbol
            // 
            this.toolStrip_usd_symbol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_usd_symbol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_usd_symbol});
            this.toolStrip_usd_symbol.Location = new System.Drawing.Point(0, 143);
            this.toolStrip_usd_symbol.Name = "toolStrip_usd_symbol";
            this.toolStrip_usd_symbol.Size = new System.Drawing.Size(156, 25);
            this.toolStrip_usd_symbol.TabIndex = 10;
            this.toolStrip_usd_symbol.Text = "toolStrip1";
            // 
            // toolStripLabel_usd_symbol
            // 
            this.toolStripLabel_usd_symbol.Name = "toolStripLabel_usd_symbol";
            this.toolStripLabel_usd_symbol.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel_usd_symbol.Text = "SYM";
            // 
            // listView_usd
            // 
            this.listView_usd.AllColumns.Add(this.column_usd_icon);
            this.listView_usd.AllColumns.Add(this.column_usd_price);
            this.listView_usd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_usd.CellEditUseWholeCell = false;
            this.listView_usd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_usd_icon,
            this.column_usd_price});
            this.listView_usd.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_usd.FullRowSelect = true;
            this.listView_usd.GridLines = true;
            this.listView_usd.HasCollapsibleGroups = false;
            this.listView_usd.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_usd.HideSelection = false;
            this.listView_usd.Location = new System.Drawing.Point(0, 0);
            this.listView_usd.MultiSelect = false;
            this.listView_usd.Name = "listView_usd";
            this.listView_usd.ShowGroups = false;
            this.listView_usd.Size = new System.Drawing.Size(156, 168);
            this.listView_usd.SortGroupItemsByPrimaryColumn = false;
            this.listView_usd.TabIndex = 9;
            this.listView_usd.UseCellFormatEvents = true;
            this.listView_usd.UseCompatibleStateImageBehavior = false;
            this.listView_usd.UseFiltering = true;
            this.listView_usd.View = System.Windows.Forms.View.Details;
            this.listView_usd.VirtualMode = true;
            // 
            // column_usd_icon
            // 
            this.column_usd_icon.AspectName = "";
            this.column_usd_icon.Text = "";
            this.column_usd_icon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_usd_icon.Width = 24;
            // 
            // column_usd_price
            // 
            this.column_usd_price.FillsFreeSpace = true;
            this.column_usd_price.Text = "Price";
            this.column_usd_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip_usd_btc
            // 
            this.toolStrip_usd_btc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_usd_btc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_usd_btc});
            this.toolStrip_usd_btc.Location = new System.Drawing.Point(0, 168);
            this.toolStrip_usd_btc.Name = "toolStrip_usd_btc";
            this.toolStrip_usd_btc.Size = new System.Drawing.Size(156, 25);
            this.toolStrip_usd_btc.TabIndex = 8;
            this.toolStrip_usd_btc.Text = "toolStrip_btc";
            // 
            // toolStripLabel_usd_btc
            // 
            this.toolStripLabel_usd_btc.Name = "toolStripLabel_usd_btc";
            this.toolStripLabel_usd_btc.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel_usd_btc.Text = "BTC";
            // 
            // toolStrip_usd_usd
            // 
            this.toolStrip_usd_usd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_usd_usd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_usd_usd});
            this.toolStrip_usd_usd.Location = new System.Drawing.Point(0, 193);
            this.toolStrip_usd_usd.Name = "toolStrip_usd_usd";
            this.toolStrip_usd_usd.Size = new System.Drawing.Size(156, 25);
            this.toolStrip_usd_usd.TabIndex = 7;
            this.toolStrip_usd_usd.Text = "toolStrip1";
            // 
            // toolStripLabel_usd_usd
            // 
            this.toolStripLabel_usd_usd.Name = "toolStripLabel_usd_usd";
            this.toolStripLabel_usd_usd.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel_usd_usd.Text = "USD";
            // 
            // ArbitragePriceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ArbitragePriceControl";
            this.Size = new System.Drawing.Size(330, 420);
            this.Load += new System.EventHandler(this.ArbitragePriceControl_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel_btc.ResumeLayout(false);
            this.panel_btc.PerformLayout();
            this.panel_usd.ResumeLayout(false);
            this.panel_usd.PerformLayout();
            this.toolStrip_btc_symbol.ResumeLayout(false);
            this.toolStrip_btc_symbol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_btc)).EndInit();
            this.toolStrip_btc_btc.ResumeLayout(false);
            this.toolStrip_btc_btc.PerformLayout();
            this.toolStrip_btc_usd.ResumeLayout(false);
            this.toolStrip_btc_usd.PerformLayout();
            this.toolStrip_usd_symbol.ResumeLayout(false);
            this.toolStrip_usd_symbol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_usd)).EndInit();
            this.toolStrip_usd_btc.ResumeLayout(false);
            this.toolStrip_usd_btc.PerformLayout();
            this.toolStrip_usd_usd.ResumeLayout(false);
            this.toolStrip_usd_usd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_symbol;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel_btc;
        private System.Windows.Forms.Panel panel_usd;
        private System.Windows.Forms.ToolStrip toolStrip_btc_symbol;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_btc_symbol;
        private BrightIdeasSoftware.FastObjectListView listView_btc;
        private BrightIdeasSoftware.OLVColumn column_btc_icon;
        private BrightIdeasSoftware.OLVColumn column_btc_price;
        private System.Windows.Forms.ToolStrip toolStrip_btc_btc;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_btc_btc;
        private System.Windows.Forms.ToolStrip toolStrip_btc_usd;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_btc_usd;
        private System.Windows.Forms.ToolStrip toolStrip_usd_symbol;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_usd_symbol;
        private BrightIdeasSoftware.FastObjectListView listView_usd;
        private BrightIdeasSoftware.OLVColumn column_usd_icon;
        private BrightIdeasSoftware.OLVColumn column_usd_price;
        private System.Windows.Forms.ToolStrip toolStrip_usd_btc;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_usd_btc;
        private System.Windows.Forms.ToolStrip toolStrip_usd_usd;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_usd_usd;
    }
}
