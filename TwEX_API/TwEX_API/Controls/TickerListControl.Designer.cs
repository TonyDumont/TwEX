namespace TwEX_API.Controls
{
    partial class TickerListControl
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
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_market = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_last = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_change = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_volume = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip_footer = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_title = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.toolStrip_footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(504, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_symbol);
            this.listView.AllColumns.Add(this.column_market);
            this.listView.AllColumns.Add(this.column_last);
            this.listView.AllColumns.Add(this.column_change);
            this.listView.AllColumns.Add(this.column_volume);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_symbol,
            this.column_market,
            this.column_last,
            this.column_change,
            this.column_volume});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectColumnsOnRightClick = false;
            this.listView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView.ShowFilterMenuOnRightClick = false;
            this.listView.ShowGroups = false;
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(504, 299);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 4;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ListView_FormatCell);
            this.listView.ItemActivate += new System.EventHandler(this.listView_ItemActivate);
            // 
            // column_symbol
            // 
            this.column_symbol.AspectName = "symbol";
            this.column_symbol.Text = "Symbol";
            this.column_symbol.Width = 80;
            // 
            // column_market
            // 
            this.column_market.AspectName = "";
            this.column_market.AspectToStringFormat = "";
            this.column_market.Text = "";
            this.column_market.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_market.Width = 16;
            // 
            // column_last
            // 
            this.column_last.AspectName = "";
            this.column_last.AspectToStringFormat = "";
            this.column_last.Text = "Last";
            this.column_last.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_last.Width = 100;
            // 
            // column_change
            // 
            this.column_change.AspectName = "";
            this.column_change.AspectToStringFormat = "";
            this.column_change.Text = "Change";
            this.column_change.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_change.Width = 100;
            // 
            // column_volume
            // 
            this.column_volume.AspectName = "volume";
            this.column_volume.AspectToStringFormat = "";
            this.column_volume.FillsFreeSpace = true;
            this.column_volume.Text = "Volume";
            this.column_volume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_volume.Width = 100;
            // 
            // toolStrip_footer
            // 
            this.toolStrip_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_title});
            this.toolStrip_footer.Location = new System.Drawing.Point(0, 324);
            this.toolStrip_footer.Name = "toolStrip_footer";
            this.toolStrip_footer.Size = new System.Drawing.Size(504, 25);
            this.toolStrip_footer.TabIndex = 5;
            this.toolStrip_footer.Text = "toolStrip1";
            // 
            // toolStripLabel_title
            // 
            this.toolStripLabel_title.Name = "toolStripLabel_title";
            this.toolStripLabel_title.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel_title.Text = "0 Tickers";
            // 
            // TickerListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip_footer);
            this.Controls.Add(this.toolStrip);
            this.Name = "TickerListControl";
            this.Size = new System.Drawing.Size(504, 349);
            this.Load += new System.EventHandler(this.TickerListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.toolStrip_footer.ResumeLayout(false);
            this.toolStrip_footer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_symbol;
        private BrightIdeasSoftware.OLVColumn column_market;
        private BrightIdeasSoftware.OLVColumn column_last;
        private BrightIdeasSoftware.OLVColumn column_change;
        private BrightIdeasSoftware.OLVColumn column_volume;
        private System.Windows.Forms.ToolStrip toolStrip_footer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_title;
    }
}
