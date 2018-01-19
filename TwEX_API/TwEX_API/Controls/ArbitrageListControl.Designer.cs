namespace TwEX_API.Controls
{
    partial class ArbitrageListControl
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
            this.toolStrip_usd = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_usd = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_btc = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_btc = new System.Windows.Forms.ToolStripLabel();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_icon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_price = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip_symbol = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_symbol = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_usd.SuspendLayout();
            this.toolStrip_btc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.toolStrip_symbol.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_usd
            // 
            this.toolStrip_usd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_usd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_usd});
            this.toolStrip_usd.Location = new System.Drawing.Point(0, 324);
            this.toolStrip_usd.Name = "toolStrip_usd";
            this.toolStrip_usd.Size = new System.Drawing.Size(140, 25);
            this.toolStrip_usd.TabIndex = 0;
            this.toolStrip_usd.Text = "toolStrip1";
            // 
            // toolStripLabel_usd
            // 
            this.toolStripLabel_usd.Name = "toolStripLabel_usd";
            this.toolStripLabel_usd.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel_usd.Text = "USD";
            // 
            // toolStrip_btc
            // 
            this.toolStrip_btc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_btc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_btc});
            this.toolStrip_btc.Location = new System.Drawing.Point(0, 299);
            this.toolStrip_btc.Name = "toolStrip_btc";
            this.toolStrip_btc.Size = new System.Drawing.Size(140, 25);
            this.toolStrip_btc.TabIndex = 1;
            this.toolStrip_btc.Text = "toolStrip_btc";
            // 
            // toolStripLabel_btc
            // 
            this.toolStripLabel_btc.Name = "toolStripLabel_btc";
            this.toolStripLabel_btc.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel_btc.Text = "BTC";
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_icon);
            this.listView.AllColumns.Add(this.column_price);
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_icon,
            this.column_price});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(140, 299);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 5;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            // 
            // column_icon
            // 
            this.column_icon.AspectName = "";
            this.column_icon.Text = "";
            this.column_icon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_icon.Width = 24;
            // 
            // column_price
            // 
            this.column_price.Text = "Price";
            this.column_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip_symbol
            // 
            this.toolStrip_symbol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_symbol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_symbol});
            this.toolStrip_symbol.Location = new System.Drawing.Point(0, 274);
            this.toolStrip_symbol.Name = "toolStrip_symbol";
            this.toolStrip_symbol.Size = new System.Drawing.Size(140, 25);
            this.toolStrip_symbol.TabIndex = 6;
            this.toolStrip_symbol.Text = "toolStrip1";
            // 
            // toolStripLabel_symbol
            // 
            this.toolStripLabel_symbol.Name = "toolStripLabel_symbol";
            this.toolStripLabel_symbol.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel_symbol.Text = "SYM";
            // 
            // ArbitrageListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.toolStrip_symbol);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip_btc);
            this.Controls.Add(this.toolStrip_usd);
            this.Name = "ArbitrageListControl";
            this.Size = new System.Drawing.Size(140, 349);
            this.Load += new System.EventHandler(this.ArbitrageListControl_Load);
            this.toolStrip_usd.ResumeLayout(false);
            this.toolStrip_usd.PerformLayout();
            this.toolStrip_btc.ResumeLayout(false);
            this.toolStrip_btc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.toolStrip_symbol.ResumeLayout(false);
            this.toolStrip_symbol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_usd;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_usd;
        private System.Windows.Forms.ToolStrip toolStrip_btc;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_btc;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_icon;
        private BrightIdeasSoftware.OLVColumn column_price;
        private System.Windows.Forms.ToolStrip toolStrip_symbol;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_symbol;
    }
}
