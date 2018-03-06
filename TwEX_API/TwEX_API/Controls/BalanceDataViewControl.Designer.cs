namespace TwEX_API.Controls
{
    partial class BalanceDataViewControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceDataViewControl));
            this.listView = new BrightIdeasSoftware.FastDataListView();
            this.column_Exchange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Balance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_SymbolIcon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInBTC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInUSD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_ExchangeIcon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_totals = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_collapse = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_Exchange);
            this.listView.AllColumns.Add(this.column_Balance);
            this.listView.AllColumns.Add(this.column_SymbolIcon);
            this.listView.AllColumns.Add(this.column_Symbol);
            this.listView.AllColumns.Add(this.column_TotalInBTC);
            this.listView.AllColumns.Add(this.column_TotalInUSD);
            this.listView.AllColumns.Add(this.column_ExchangeIcon);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Exchange,
            this.column_Balance,
            this.column_SymbolIcon,
            this.column_Symbol,
            this.column_TotalInBTC,
            this.column_TotalInUSD,
            this.column_ExchangeIcon});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.DataSource = null;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.ShowImagesOnSubItems = true;
            this.listView.ShowItemCountOnGroups = true;
            this.listView.Size = new System.Drawing.Size(410, 320);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 7;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            // 
            // column_Exchange
            // 
            this.column_Exchange.AspectName = "Exchange";
            this.column_Exchange.MaximumWidth = 0;
            this.column_Exchange.MinimumWidth = 0;
            this.column_Exchange.Text = "";
            this.column_Exchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_Exchange.Width = 0;
            // 
            // column_Balance
            // 
            this.column_Balance.AspectName = "Balance";
            this.column_Balance.AspectToStringFormat = "{0:N8}";
            this.column_Balance.FillsFreeSpace = true;
            this.column_Balance.Text = "Coin Total";
            this.column_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_SymbolIcon
            // 
            this.column_SymbolIcon.Text = "";
            this.column_SymbolIcon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_SymbolIcon.Width = 18;
            // 
            // column_Symbol
            // 
            this.column_Symbol.AspectName = "Symbol";
            this.column_Symbol.MinimumWidth = 90;
            this.column_Symbol.Text = "Symbol";
            this.column_Symbol.Width = 90;
            // 
            // column_TotalInBTC
            // 
            this.column_TotalInBTC.AspectName = "TotalInBTC";
            this.column_TotalInBTC.AspectToStringFormat = "{0:N8}";
            this.column_TotalInBTC.Text = "BTC Total";
            this.column_TotalInBTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_TotalInUSD
            // 
            this.column_TotalInUSD.AspectName = "TotalInUSD";
            this.column_TotalInUSD.AspectToStringFormat = "{0:C}";
            this.column_TotalInUSD.Text = "USD Total";
            this.column_TotalInUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_ExchangeIcon
            // 
            this.column_ExchangeIcon.AspectName = "";
            this.column_ExchangeIcon.MinimumWidth = 32;
            this.column_ExchangeIcon.Text = "";
            this.column_ExchangeIcon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_ExchangeIcon.Width = 32;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_totals,
            this.toolStripButton_collapse});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(410, 25);
            this.toolStrip.TabIndex = 8;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel_totals
            // 
            this.toolStripLabel_totals.Name = "toolStripLabel_totals";
            this.toolStripLabel_totals.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel_totals.Text = "TOTALS";
            // 
            // toolStripButton_collapse
            // 
            this.toolStripButton_collapse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_collapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_collapse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_collapse.Image")));
            this.toolStripButton_collapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_collapse.Name = "toolStripButton_collapse";
            this.toolStripButton_collapse.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_collapse.Text = "Expand/Collapse";
            // 
            // BalanceDataViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "BalanceDataViewControl";
            this.Size = new System.Drawing.Size(410, 345);
            this.Load += new System.EventHandler(this.BalanceDataViewControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView listView;
        private BrightIdeasSoftware.OLVColumn column_Exchange;
        private BrightIdeasSoftware.OLVColumn column_Balance;
        private BrightIdeasSoftware.OLVColumn column_SymbolIcon;
        private BrightIdeasSoftware.OLVColumn column_Symbol;
        private BrightIdeasSoftware.OLVColumn column_TotalInBTC;
        private BrightIdeasSoftware.OLVColumn column_TotalInUSD;
        private BrightIdeasSoftware.OLVColumn column_ExchangeIcon;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_totals;
        private System.Windows.Forms.ToolStripButton toolStripButton_collapse;
    }
}
