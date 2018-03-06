namespace TwEX_API.Controls
{
    partial class OrderViewControl
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
            this.toolStripLabel_status = new System.Windows.Forms.ToolStripLabel();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_exchange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_amount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_rate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_market = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_total = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_date = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_status});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(501, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.Visible = false;
            // 
            // toolStripLabel_status
            // 
            this.toolStripLabel_status.Name = "toolStripLabel_status";
            this.toolStripLabel_status.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel_status.Text = "ORDERS";
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_exchange);
            this.listView.AllColumns.Add(this.column_amount);
            this.listView.AllColumns.Add(this.column_symbol);
            this.listView.AllColumns.Add(this.column_rate);
            this.listView.AllColumns.Add(this.column_market);
            this.listView.AllColumns.Add(this.column_total);
            this.listView.AllColumns.Add(this.column_date);
            this.listView.AllColumns.Add(this.column_type);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_exchange,
            this.column_amount,
            this.column_symbol,
            this.column_rate,
            this.column_market,
            this.column_total});
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
            this.listView.Size = new System.Drawing.Size(501, 395);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 5;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ListView_FormatCell);
            // 
            // column_exchange
            // 
            this.column_exchange.Text = "";
            this.column_exchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_amount
            // 
            this.column_amount.AspectName = "amount";
            this.column_amount.AspectToStringFormat = "";
            this.column_amount.Text = "Amount";
            this.column_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_symbol
            // 
            this.column_symbol.AspectName = "symbol";
            this.column_symbol.Text = "";
            this.column_symbol.Width = 35;
            // 
            // column_rate
            // 
            this.column_rate.AspectName = "rate";
            this.column_rate.AspectToStringFormat = "";
            this.column_rate.Text = "Price / Rate";
            this.column_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_market
            // 
            this.column_market.AspectName = "";
            this.column_market.Text = "";
            this.column_market.Width = 35;
            // 
            // column_total
            // 
            this.column_total.AspectName = "total";
            this.column_total.AspectToStringFormat = "";
            this.column_total.FillsFreeSpace = true;
            this.column_total.Text = "Total";
            this.column_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_date
            // 
            this.column_date.AspectName = "date";
            this.column_date.AspectToStringFormat = "{0:MM/dd/yyyy HH:mm tt}";
            this.column_date.DisplayIndex = 3;
            this.column_date.IsVisible = false;
            this.column_date.Text = "Date";
            // 
            // column_type
            // 
            this.column_type.AspectName = "type";
            this.column_type.AspectToStringFormat = "";
            this.column_type.DisplayIndex = 5;
            this.column_type.FillsFreeSpace = true;
            this.column_type.IsVisible = false;
            this.column_type.Text = "Type";
            this.column_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OrderViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "OrderViewControl";
            this.Size = new System.Drawing.Size(501, 420);
            this.Load += new System.EventHandler(this.OrderViewControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_status;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_date;
        private BrightIdeasSoftware.OLVColumn column_type;
        private BrightIdeasSoftware.OLVColumn column_amount;
        private BrightIdeasSoftware.OLVColumn column_symbol;
        private BrightIdeasSoftware.OLVColumn column_rate;
        private BrightIdeasSoftware.OLVColumn column_total;
        private BrightIdeasSoftware.OLVColumn column_market;
        private BrightIdeasSoftware.OLVColumn column_exchange;
    }
}
