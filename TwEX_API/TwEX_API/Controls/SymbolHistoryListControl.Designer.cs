namespace TwEX_API.Controls
{
    partial class SymbolHistoryListControl
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
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_date = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_amount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_rate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_total = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_market = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_date);
            this.listView.AllColumns.Add(this.column_type);
            this.listView.AllColumns.Add(this.column_amount);
            this.listView.AllColumns.Add(this.column_symbol);
            this.listView.AllColumns.Add(this.column_rate);
            this.listView.AllColumns.Add(this.column_total);
            this.listView.AllColumns.Add(this.column_market);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_date,
            this.column_type,
            this.column_amount,
            this.column_symbol,
            this.column_rate,
            this.column_total,
            this.column_market});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectColumnsOnRightClick = false;
            this.listView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView.ShowFilterMenuOnRightClick = false;
            this.listView.ShowGroups = false;
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(489, 229);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 5;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ListView_FormatCell);
            // 
            // column_date
            // 
            this.column_date.AspectName = "date";
            this.column_date.AspectToStringFormat = "{0:MM/dd/yyyy HH:mm tt}";
            this.column_date.Text = "Date";
            // 
            // column_symbol
            // 
            this.column_symbol.AspectName = "";
            this.column_symbol.Text = "";
            this.column_symbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_symbol.Width = 35;
            // 
            // column_amount
            // 
            this.column_amount.AspectName = "amount";
            this.column_amount.AspectToStringFormat = "";
            this.column_amount.Text = "Amount";
            this.column_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_type
            // 
            this.column_type.AspectName = "type";
            this.column_type.AspectToStringFormat = "";
            this.column_type.FillsFreeSpace = true;
            this.column_type.Text = "Type";
            this.column_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_rate
            // 
            this.column_rate.AspectName = "rate";
            this.column_rate.AspectToStringFormat = "";
            this.column_rate.Text = "Rate";
            this.column_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_total
            // 
            this.column_total.AspectName = "total";
            this.column_total.AspectToStringFormat = "";
            this.column_total.Text = "Total";
            this.column_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_market
            // 
            this.column_market.AspectName = "";
            this.column_market.Text = "";
            this.column_market.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_market.Width = 35;
            // 
            // SymbolHistoryListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Name = "SymbolHistoryListControl";
            this.Size = new System.Drawing.Size(489, 229);
            this.Load += new System.EventHandler(this.SymbolHistoryListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_date;
        private BrightIdeasSoftware.OLVColumn column_symbol;
        private BrightIdeasSoftware.OLVColumn column_market;
        private BrightIdeasSoftware.OLVColumn column_amount;
        private BrightIdeasSoftware.OLVColumn column_type;
        private BrightIdeasSoftware.OLVColumn column_rate;
        private BrightIdeasSoftware.OLVColumn column_total;
    }
}
