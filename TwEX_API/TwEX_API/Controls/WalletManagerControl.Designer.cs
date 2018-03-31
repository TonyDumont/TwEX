namespace TwEX_API.Controls
{
    partial class WalletManagerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalletManagerControl));
            this.column_WalletName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_Name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Balance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInBTC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInUSD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_update = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_timer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_title = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_collapse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_usd = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_btc = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // column_WalletName
            // 
            this.column_WalletName.AspectName = "WalletName";
            this.column_WalletName.DisplayIndex = 1;
            this.column_WalletName.IsVisible = false;
            this.column_WalletName.Text = "Wallet Name";
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_Name);
            this.listView.AllColumns.Add(this.column_Balance);
            this.listView.AllColumns.Add(this.column_Symbol);
            this.listView.AllColumns.Add(this.column_TotalInBTC);
            this.listView.AllColumns.Add(this.column_TotalInUSD);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Name,
            this.column_Balance,
            this.column_Symbol,
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
            this.listView.Size = new System.Drawing.Size(812, 316);
            this.listView.TabIndex = 4;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseHotControls = false;
            this.listView.UseOverlays = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.AboutToCreateGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.aboutToCreateGroups);
            this.listView.ItemActivate += new System.EventHandler(this.listView_ItemActivate);
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // column_Name
            // 
            this.column_Name.AspectName = "Name";
            this.column_Name.FillsFreeSpace = true;
            this.column_Name.Text = "Name";
            // 
            // column_Balance
            // 
            this.column_Balance.AspectName = "Balance";
            this.column_Balance.AspectToStringFormat = "{0:N8}";
            this.column_Balance.Text = "Balance";
            this.column_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_Symbol
            // 
            this.column_Symbol.AspectName = "";
            this.column_Symbol.Text = "";
            this.column_Symbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_Symbol.Width = 25;
            // 
            // column_TotalInBTC
            // 
            this.column_TotalInBTC.AspectName = "TotalInBTC";
            this.column_TotalInBTC.AspectToStringFormat = "{0:N8}";
            this.column_TotalInBTC.Text = "BTC";
            this.column_TotalInBTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_TotalInUSD
            // 
            this.column_TotalInUSD.AspectName = "TotalInUSD";
            this.column_TotalInUSD.AspectToStringFormat = "{0:C}";
            this.column_TotalInUSD.Text = "USD";
            this.column_TotalInUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator1,
            this.toolStripButton_timer,
            this.toolStripSeparator4,
            this.toolStripLabel_title,
            this.toolStripButton_collapse,
            this.toolStripSeparator3,
            this.toolStripLabel_usd,
            this.toolStripSeparator2,
            this.toolStripLabel_btc});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(812, 25);
            this.toolStrip.TabIndex = 5;
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease,
            this.toolStripSeparator5,
            this.toolStripMenuItem_add,
            this.toolStripMenuItem_update});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton_menu.Text = "OPTIONS";
            this.toolStripDropDownButton_menu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_menu_DropDownItemClicked);
            // 
            // toolStripMenuItem_font
            // 
            this.toolStripMenuItem_font.Name = "toolStripMenuItem_font";
            this.toolStripMenuItem_font.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_font.Tag = "Font";
            this.toolStripMenuItem_font.Text = "Font";
            this.toolStripMenuItem_font.Visible = false;
            // 
            // toolStripMenuItem_fontIncrease
            // 
            this.toolStripMenuItem_fontIncrease.Name = "toolStripMenuItem_fontIncrease";
            this.toolStripMenuItem_fontIncrease.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_fontIncrease.Tag = "FontIncrease";
            this.toolStripMenuItem_fontIncrease.Text = "Increase Font";
            this.toolStripMenuItem_fontIncrease.Visible = false;
            // 
            // toolStripMenuItem_fontDecrease
            // 
            this.toolStripMenuItem_fontDecrease.Name = "toolStripMenuItem_fontDecrease";
            this.toolStripMenuItem_fontDecrease.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_fontDecrease.Tag = "FontDecrease";
            this.toolStripMenuItem_fontDecrease.Text = "Decrease Font";
            this.toolStripMenuItem_fontDecrease.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(150, 6);
            this.toolStripSeparator5.Visible = false;
            // 
            // toolStripMenuItem_add
            // 
            this.toolStripMenuItem_add.Name = "toolStripMenuItem_add";
            this.toolStripMenuItem_add.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_add.Tag = "AddWallet";
            this.toolStripMenuItem_add.Text = "Add Wallet";
            // 
            // toolStripMenuItem_update
            // 
            this.toolStripMenuItem_update.Name = "toolStripMenuItem_update";
            this.toolStripMenuItem_update.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem_update.Tag = "UpdateWallets";
            this.toolStripMenuItem_update.Text = "Update Wallets";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_timer
            // 
            this.toolStripButton_timer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_timer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_timer.Image")));
            this.toolStripButton_timer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_timer.Name = "toolStripButton_timer";
            this.toolStripButton_timer.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_timer.Tag = "WALLETS";
            this.toolStripButton_timer.Text = "TIMER";
            this.toolStripButton_timer.ToolTipText = "TIMER";
            this.toolStripButton_timer.Click += new System.EventHandler(this.toolStripButton_timer_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_title
            // 
            this.toolStripLabel_title.Name = "toolStripLabel_title";
            this.toolStripLabel_title.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel_title.Text = "# Wallets";
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
            this.toolStripButton_collapse.Click += new System.EventHandler(this.toolStripButton_toggleGroup_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_usd
            // 
            this.toolStripLabel_usd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_usd.Name = "toolStripLabel_usd";
            this.toolStripLabel_usd.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel_usd.Text = "USD";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_btc
            // 
            this.toolStripLabel_btc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_btc.Name = "toolStripLabel_btc";
            this.toolStripLabel_btc.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel_btc.Text = "BTC";
            // 
            // WalletManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "WalletManagerControl";
            this.Size = new System.Drawing.Size(812, 341);
            this.Load += new System.EventHandler(this.WalletManagerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BrightIdeasSoftware.OLVColumn column_WalletName;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_Name;
        private BrightIdeasSoftware.OLVColumn column_Symbol;
        private BrightIdeasSoftware.OLVColumn column_Balance;
        private BrightIdeasSoftware.OLVColumn column_TotalInBTC;
        private BrightIdeasSoftware.OLVColumn column_TotalInUSD;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_timer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_usd;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_title;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_add;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_update;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_btc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_collapse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
