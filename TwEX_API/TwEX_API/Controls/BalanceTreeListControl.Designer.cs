namespace TwEX_API.Controls
{
    partial class BalanceTreeListControl
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
            //this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.listView = new BrightIdeasSoftware.TreeListView();
            this.column_Symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Exchange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Balance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInBTC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInUSD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_Symbol);
            this.listView.AllColumns.Add(this.column_Exchange);
            this.listView.AllColumns.Add(this.column_Balance);
            this.listView.AllColumns.Add(this.column_TotalInBTC);
            this.listView.AllColumns.Add(this.column_TotalInUSD);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Symbol,
            this.column_Exchange,
            this.column_Balance,
            this.column_TotalInBTC,
            this.column_TotalInUSD});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(650, 427);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 6;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            // 
            // column_Symbol
            // 
            this.column_Symbol.AspectName = "Symbol";
            this.column_Symbol.MinimumWidth = 90;
            this.column_Symbol.Text = "Symbol";
            this.column_Symbol.Width = 90;
            // 
            // column_Exchange
            // 
            this.column_Exchange.AspectName = "";
            this.column_Exchange.MinimumWidth = 32;
            this.column_Exchange.Text = "";
            this.column_Exchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_Exchange.Width = 32;
            // 
            // column_Balance
            // 
            this.column_Balance.AspectName = "Balance";
            this.column_Balance.AspectToStringFormat = "{0:N8}";
            this.column_Balance.Text = "Balance";
            this.column_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_TotalInBTC
            // 
            this.column_TotalInBTC.AspectName = "TotalInBTC";
            this.column_TotalInBTC.AspectToStringFormat = "{0:N8}";
            this.column_TotalInBTC.Text = "Total In BTC";
            this.column_TotalInBTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_TotalInUSD
            // 
            this.column_TotalInUSD.AspectName = "TotalInUSD";
            this.column_TotalInUSD.AspectToStringFormat = "{0:C}";
            this.column_TotalInUSD.Text = "Total In USD";
            this.column_TotalInUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BalanceTreeListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Name = "BalanceTreeListControl";
            this.Size = new System.Drawing.Size(650, 427);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.TreeListView listView;
        private BrightIdeasSoftware.OLVColumn column_Symbol;
        private BrightIdeasSoftware.OLVColumn column_Exchange;
        private BrightIdeasSoftware.OLVColumn column_Balance;
        private BrightIdeasSoftware.OLVColumn column_TotalInBTC;
        private BrightIdeasSoftware.OLVColumn column_TotalInUSD;
    }
}
