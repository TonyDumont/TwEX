namespace TwEX_API.Controls
{
    partial class TransactionsListControl
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
            this.column_datetime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_id = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_currency = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_amount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_confirmations = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_address = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_datetime);
            this.listView.AllColumns.Add(this.column_currency);
            this.listView.AllColumns.Add(this.column_amount);
            this.listView.AllColumns.Add(this.column_type);
            this.listView.AllColumns.Add(this.column_address);
            this.listView.AllColumns.Add(this.column_id);
            this.listView.AllColumns.Add(this.column_confirmations);
            this.listView.AllColumns.Add(this.column_status);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_datetime,
            this.column_currency,
            this.column_amount,
            this.column_type,
            this.column_address});
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
            this.listView.Size = new System.Drawing.Size(534, 359);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 5;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            // 
            // column_datetime
            // 
            this.column_datetime.AspectName = "datetime";
            this.column_datetime.Text = "Date";
            // 
            // column_id
            // 
            this.column_id.AspectName = "id";
            this.column_id.DisplayIndex = 3;
            this.column_id.IsVisible = false;
            this.column_id.Text = "Id";
            this.column_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_currency
            // 
            this.column_currency.AspectName = "currency";
            this.column_currency.Text = "Currency";
            this.column_currency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_amount
            // 
            this.column_amount.AspectName = "amount";
            this.column_amount.AspectToStringFormat = "";
            this.column_amount.Text = "Amount";
            this.column_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_confirmations
            // 
            this.column_confirmations.AspectName = "confirmation";
            this.column_confirmations.AspectToStringFormat = "";
            this.column_confirmations.DisplayIndex = 4;
            this.column_confirmations.IsVisible = false;
            this.column_confirmations.Text = "Confirms";
            this.column_confirmations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_status
            // 
            this.column_status.AspectName = "status";
            this.column_status.AspectToStringFormat = "";
            this.column_status.DisplayIndex = 5;
            this.column_status.IsVisible = false;
            this.column_status.Text = "Status";
            this.column_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_type
            // 
            this.column_type.AspectName = "type";
            this.column_type.Text = "Type";
            this.column_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_address
            // 
            this.column_address.AspectName = "address";
            this.column_address.AspectToStringFormat = "";
            this.column_address.FillsFreeSpace = true;
            this.column_address.Text = "Address";
            this.column_address.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TransactionsListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Name = "TransactionsListControl";
            this.Size = new System.Drawing.Size(534, 359);
            this.Load += new System.EventHandler(this.TransactionsListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_datetime;
        private BrightIdeasSoftware.OLVColumn column_id;
        private BrightIdeasSoftware.OLVColumn column_currency;
        private BrightIdeasSoftware.OLVColumn column_address;
        private BrightIdeasSoftware.OLVColumn column_amount;
        private BrightIdeasSoftware.OLVColumn column_confirmations;
        private BrightIdeasSoftware.OLVColumn column_status;
        private BrightIdeasSoftware.OLVColumn column_type;
    }
}
