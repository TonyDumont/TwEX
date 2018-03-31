namespace TwEX_API.Controls
{
    partial class ImportForksControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForksControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_load = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_save = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.textBox = new System.Windows.Forms.TextBox();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_ticker = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Balance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInBTC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInUSD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_view = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_view,
            this.toolStripSeparator1,
            this.toolStripButton_load,
            this.toolStripButton_save});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(668, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_load
            // 
            this.toolStripButton_load.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_load.Image")));
            this.toolStripButton_load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_load.Name = "toolStripButton_load";
            this.toolStripButton_load.Size = new System.Drawing.Size(199, 22);
            this.toolStripButton_load.Text = "Load Full Report From Clipboard";
            this.toolStripButton_load.Click += new System.EventHandler(this.toolStripButton_load_Click);
            // 
            // toolStripButton_save
            // 
            this.toolStripButton_save.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_save.Image")));
            this.toolStripButton_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_save.Name = "toolStripButton_save";
            this.toolStripButton_save.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton_save.Text = "Save";
            this.toolStripButton_save.Click += new System.EventHandler(this.toolStripButton_save_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.textBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView);
            this.splitContainer.Size = new System.Drawing.Size(668, 342);
            this.splitContainer.SplitterDistance = 222;
            this.splitContainer.TabIndex = 1;
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(222, 342);
            this.textBox.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_ticker);
            this.listView.AllColumns.Add(this.column_Name);
            this.listView.AllColumns.Add(this.column_Balance);
            this.listView.AllColumns.Add(this.column_TotalInBTC);
            this.listView.AllColumns.Add(this.column_TotalInUSD);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectColumnsOnRightClick = false;
            this.listView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView.ShowFilterMenuOnRightClick = false;
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(442, 342);
            this.listView.TabIndex = 5;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseHotControls = false;
            this.listView.UseOverlays = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 367);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(668, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_view
            // 
            this.toolStripButton_view.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_view.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_view.Image")));
            this.toolStripButton_view.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_view.Name = "toolStripButton_view";
            this.toolStripButton_view.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_view.Text = "Copies Address To Clipboard and Loads FindMyCoins.ninja";
            this.toolStripButton_view.Click += new System.EventHandler(this.toolStripButton_view_Click);
            // 
            // ImportForksControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ImportForksControl";
            this.Size = new System.Drawing.Size(668, 389);
            this.Load += new System.EventHandler(this.ImportForksControl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_load;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ToolStripButton toolStripButton_save;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_Name;
        private BrightIdeasSoftware.OLVColumn column_Balance;
        private BrightIdeasSoftware.OLVColumn column_ticker;
        private BrightIdeasSoftware.OLVColumn column_TotalInBTC;
        private BrightIdeasSoftware.OLVColumn column_TotalInUSD;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton toolStripButton_view;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
