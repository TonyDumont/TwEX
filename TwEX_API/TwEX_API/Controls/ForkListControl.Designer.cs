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
            this.column_Name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_CoinName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_ForkSymbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.listView.AllColumns.Add(this.column_Name);
            this.listView.AllColumns.Add(this.column_CoinName);
            this.listView.AllColumns.Add(this.column_ForkSymbol);
            this.listView.AllColumns.Add(this.olvColumn1);
            this.listView.AllColumns.Add(this.olvColumn2);
            this.listView.AllColumns.Add(this.olvColumn3);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Name,
            this.column_CoinName,
            this.column_ForkSymbol,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
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
            this.listView.TabIndex = 11;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseHotControls = false;
            this.listView.UseOverlays = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.AboutToCreateGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.aboutToCreateGroups);
            // 
            // column_Name
            // 
            this.column_Name.AspectName = "Name";
            this.column_Name.IsVisible = false;
            this.column_Name.Text = "Name";
            this.column_Name.Width = 0;
            // 
            // column_CoinName
            // 
            this.column_CoinName.AspectName = "CoinName";
            this.column_CoinName.Text = "CoinName";
            // 
            // column_ForkSymbol
            // 
            this.column_ForkSymbol.AspectName = "Symbol";
            this.column_ForkSymbol.Text = "";
            this.column_ForkSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_ForkSymbol.Width = 32;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Balance";
            this.olvColumn1.AspectToStringFormat = "{0:N8}";
            this.olvColumn1.Text = "Balance";
            this.olvColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "TotalInBTC";
            this.olvColumn2.AspectToStringFormat = "{0:N8}";
            this.olvColumn2.Text = "BTC";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "TotalInUSD";
            this.olvColumn3.AspectToStringFormat = "{0:C}";
            this.olvColumn3.Text = "USD";
            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
        private BrightIdeasSoftware.OLVColumn column_Name;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn column_ForkSymbol;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn column_CoinName;
    }
}
