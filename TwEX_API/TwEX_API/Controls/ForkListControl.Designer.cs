namespace TwEX_API.Controls
{
    partial class ForkListControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForkListControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_totals = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_collapse = new System.Windows.Forms.ToolStripButton();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_ticker = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Balance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInBTC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInUSD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_id = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_totals,
            this.toolStripButton_collapse});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(390, 25);
            this.toolStrip.TabIndex = 1;
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
            this.toolStripButton_collapse.Click += new System.EventHandler(this.toolStripButton_collapse_Click);
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_id);
            this.listView.AllColumns.Add(this.column_ticker);
            this.listView.AllColumns.Add(this.column_Name);
            this.listView.AllColumns.Add(this.column_Balance);
            this.listView.AllColumns.Add(this.column_TotalInBTC);
            this.listView.AllColumns.Add(this.column_TotalInUSD);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_id,
            this.column_ticker,
            this.column_Name,
            this.column_Balance,
            this.column_TotalInBTC,
            this.column_TotalInUSD});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.IsSearchOnSortColumn = false;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectColumnsOnRightClick = false;
            this.listView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView.ShowFilterMenuOnRightClick = false;
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(390, 435);
            this.listView.TabIndex = 6;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseHotControls = false;
            this.listView.UseOverlays = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.AboutToCreateGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.aboutToCreateGroups);
            // 
            // column_ticker
            // 
            this.column_ticker.AspectName = "ticker";
            this.column_ticker.Text = "Ticker";
            this.column_ticker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_ticker.Width = 50;
            // 
            // column_Name
            // 
            this.column_Name.AspectName = "name";
            this.column_Name.FillsFreeSpace = true;
            this.column_Name.Text = "Name";
            // 
            // column_Balance
            // 
            this.column_Balance.AspectName = "";
            this.column_Balance.AspectToStringFormat = "";
            this.column_Balance.Text = "Balance";
            this.column_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_TotalInBTC
            // 
            this.column_TotalInBTC.AspectName = "";
            this.column_TotalInBTC.AspectToStringFormat = "";
            this.column_TotalInBTC.Text = "BTC";
            this.column_TotalInBTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_TotalInUSD
            // 
            this.column_TotalInUSD.AspectName = "";
            this.column_TotalInUSD.AspectToStringFormat = "";
            this.column_TotalInUSD.Text = "USD";
            this.column_TotalInUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_id
            // 
            this.column_id.AspectName = "id";
            this.column_id.MaximumWidth = 0;
            this.column_id.MinimumWidth = 0;
            this.column_id.Text = "";
            this.column_id.Width = 0;
            // 
            // ForkListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "ForkListControl";
            this.Size = new System.Drawing.Size(390, 460);
            this.Load += new System.EventHandler(this.ForkListControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_totals;
        private System.Windows.Forms.ToolStripButton toolStripButton_collapse;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_ticker;
        private BrightIdeasSoftware.OLVColumn column_Name;
        private BrightIdeasSoftware.OLVColumn column_Balance;
        private BrightIdeasSoftware.OLVColumn column_TotalInBTC;
        private BrightIdeasSoftware.OLVColumn column_TotalInUSD;
        private BrightIdeasSoftware.OLVColumn column_id;
    }
}
