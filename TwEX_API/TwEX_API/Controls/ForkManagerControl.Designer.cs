namespace TwEX_API.Controls
{
    partial class ForkManagerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForkManagerControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_clear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_collapse = new System.Windows.Forms.ToolStripButton();
            this.listView_Forks = new BrightIdeasSoftware.FastObjectListView();
            this.column_Blockchain = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Date = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Conversion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.listView_Wallets = new BrightIdeasSoftware.FastObjectListView();
            this.column_ForkName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Balance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInBTC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInUSD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip_status = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_fork = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_balance = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_btc = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_usd = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_Forks)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_Wallets)).BeginInit();
            this.toolStrip_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_menu,
            this.toolStripButton_collapse});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(350, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease,
            this.toolStripSeparator1,
            this.toolStripMenuItem_clear});
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
            this.toolStripMenuItem_font.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem_font.Tag = "Font";
            this.toolStripMenuItem_font.Text = "Font";
            // 
            // toolStripMenuItem_fontIncrease
            // 
            this.toolStripMenuItem_fontIncrease.Name = "toolStripMenuItem_fontIncrease";
            this.toolStripMenuItem_fontIncrease.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem_fontIncrease.Tag = "FontIncrease";
            this.toolStripMenuItem_fontIncrease.Text = "Increase Font";
            // 
            // toolStripMenuItem_fontDecrease
            // 
            this.toolStripMenuItem_fontDecrease.Name = "toolStripMenuItem_fontDecrease";
            this.toolStripMenuItem_fontDecrease.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem_fontDecrease.Tag = "FontDecrease";
            this.toolStripMenuItem_fontDecrease.Text = "Decrease Font";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // toolStripMenuItem_clear
            // 
            this.toolStripMenuItem_clear.Name = "toolStripMenuItem_clear";
            this.toolStripMenuItem_clear.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem_clear.Tag = "ClearData";
            this.toolStripMenuItem_clear.Text = "Clear All Fork Data";
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
            // listView_Forks
            // 
            this.listView_Forks.AllColumns.Add(this.column_Blockchain);
            this.listView_Forks.AllColumns.Add(this.column_Date);
            this.listView_Forks.AllColumns.Add(this.column_Conversion);
            this.listView_Forks.AllColumns.Add(this.column_Name);
            this.listView_Forks.AllColumns.Add(this.column_Symbol);
            this.listView_Forks.CellEditUseWholeCell = false;
            this.listView_Forks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Blockchain,
            this.column_Date,
            this.column_Conversion,
            this.column_Name,
            this.column_Symbol});
            this.listView_Forks.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView_Forks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Forks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Forks.FullRowSelect = true;
            this.listView_Forks.GridLines = true;
            this.listView_Forks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Forks.HideSelection = false;
            this.listView_Forks.IsSearchOnSortColumn = false;
            this.listView_Forks.LabelWrap = false;
            this.listView_Forks.Location = new System.Drawing.Point(3, 28);
            this.listView_Forks.MultiSelect = false;
            this.listView_Forks.Name = "listView_Forks";
            this.listView_Forks.SelectColumnsOnRightClick = false;
            this.listView_Forks.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView_Forks.ShowFilterMenuOnRightClick = false;
            this.listView_Forks.ShowGroups = false;
            this.listView_Forks.ShowItemCountOnGroups = true;
            this.listView_Forks.Size = new System.Drawing.Size(344, 454);
            this.listView_Forks.TabIndex = 7;
            this.listView_Forks.UseCellFormatEvents = true;
            this.listView_Forks.UseCompatibleStateImageBehavior = false;
            this.listView_Forks.UseHotControls = false;
            this.listView_Forks.UseOverlays = false;
            this.listView_Forks.View = System.Windows.Forms.View.Details;
            this.listView_Forks.VirtualMode = true;
            this.listView_Forks.AboutToCreateGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.aboutToCreateGroups);
            this.listView_Forks.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.listView_Forks_FormatRow);
            this.listView_Forks.ItemActivate += new System.EventHandler(this.listView_Forks_ItemActivate);
            this.listView_Forks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Forks_MouseClick);
            // 
            // column_Blockchain
            // 
            this.column_Blockchain.AspectName = "Blockchain";
            this.column_Blockchain.MaximumWidth = 0;
            this.column_Blockchain.MinimumWidth = 0;
            this.column_Blockchain.Text = "";
            this.column_Blockchain.Width = 0;
            // 
            // column_Date
            // 
            this.column_Date.AspectName = "Date";
            this.column_Date.AspectToStringFormat = "{0:MM/dd/yyyy}";
            this.column_Date.Text = "Date";
            // 
            // column_Conversion
            // 
            this.column_Conversion.AspectName = "Conversion";
            this.column_Conversion.AspectToStringFormat = "";
            this.column_Conversion.Text = "Rate";
            this.column_Conversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_Name
            // 
            this.column_Name.AspectName = "Name";
            this.column_Name.FillsFreeSpace = true;
            this.column_Name.Text = "Name";
            this.column_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_Symbol
            // 
            this.column_Symbol.AspectName = "Symbol";
            this.column_Symbol.Text = "";
            this.column_Symbol.Width = 50;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.listView_Forks, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.listView_Wallets, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.toolStrip, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.toolStrip_status, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(847, 485);
            this.tableLayoutPanel.TabIndex = 8;
            // 
            // listView_Wallets
            // 
            this.listView_Wallets.AllColumns.Add(this.column_ForkName);
            this.listView_Wallets.AllColumns.Add(this.column_Balance);
            this.listView_Wallets.AllColumns.Add(this.column_TotalInBTC);
            this.listView_Wallets.AllColumns.Add(this.column_TotalInUSD);
            this.listView_Wallets.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.listView_Wallets.CellEditUseWholeCell = false;
            this.listView_Wallets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_ForkName,
            this.column_Balance,
            this.column_TotalInBTC,
            this.column_TotalInUSD});
            this.listView_Wallets.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView_Wallets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Wallets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Wallets.FullRowSelect = true;
            this.listView_Wallets.GridLines = true;
            this.listView_Wallets.HideSelection = false;
            this.listView_Wallets.IsSearchOnSortColumn = false;
            this.listView_Wallets.LabelWrap = false;
            this.listView_Wallets.Location = new System.Drawing.Point(353, 28);
            this.listView_Wallets.MultiSelect = false;
            this.listView_Wallets.Name = "listView_Wallets";
            this.listView_Wallets.SelectColumnsOnRightClick = false;
            this.listView_Wallets.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView_Wallets.ShowFilterMenuOnRightClick = false;
            this.listView_Wallets.ShowGroups = false;
            this.listView_Wallets.Size = new System.Drawing.Size(491, 454);
            this.listView_Wallets.TabIndex = 10;
            this.listView_Wallets.UseCellFormatEvents = true;
            this.listView_Wallets.UseCompatibleStateImageBehavior = false;
            this.listView_Wallets.UseHotControls = false;
            this.listView_Wallets.UseOverlays = false;
            this.listView_Wallets.View = System.Windows.Forms.View.Details;
            this.listView_Wallets.VirtualMode = true;
            this.listView_Wallets.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.listView_Wallets_CellEditFinishing);
            this.listView_Wallets.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.listView_Wallets_FormatRow);
            this.listView_Wallets.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Wallets_MouseClick);
            // 
            // column_ForkName
            // 
            this.column_ForkName.AspectName = "Name";
            this.column_ForkName.FillsFreeSpace = true;
            this.column_ForkName.IsEditable = false;
            this.column_ForkName.Text = "Name";
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
            this.column_TotalInBTC.IsEditable = false;
            this.column_TotalInBTC.Text = "BTC";
            this.column_TotalInBTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_TotalInUSD
            // 
            this.column_TotalInUSD.AspectName = "TotalInUSD";
            this.column_TotalInUSD.AspectToStringFormat = "{0:C}";
            this.column_TotalInUSD.IsEditable = false;
            this.column_TotalInUSD.Text = "USD";
            this.column_TotalInUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip_status
            // 
            this.toolStrip_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip_status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_fork,
            this.toolStripLabel_usd,
            this.toolStripSeparator3,
            this.toolStripLabel_btc,
            this.toolStripSeparator2,
            this.toolStripLabel_balance});
            this.toolStrip_status.Location = new System.Drawing.Point(350, 0);
            this.toolStrip_status.Name = "toolStrip_status";
            this.toolStrip_status.Size = new System.Drawing.Size(497, 25);
            this.toolStrip_status.TabIndex = 9;
            this.toolStrip_status.Text = "toolStrip1";
            // 
            // toolStripLabel_fork
            // 
            this.toolStripLabel_fork.Name = "toolStripLabel_fork";
            this.toolStripLabel_fork.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabel_fork.Text = "Select A Fork";
            // 
            // toolStripLabel_balance
            // 
            this.toolStripLabel_balance.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_balance.Name = "toolStripLabel_balance";
            this.toolStripLabel_balance.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel_balance.Text = "BALANCE";
            // 
            // toolStripLabel_btc
            // 
            this.toolStripLabel_btc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_btc.Name = "toolStripLabel_btc";
            this.toolStripLabel_btc.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel_btc.Text = "BTC";
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ForkManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ForkManagerControl";
            this.Size = new System.Drawing.Size(847, 485);
            this.Load += new System.EventHandler(this.ForkManagerControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_Forks)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_Wallets)).EndInit();
            this.toolStrip_status.ResumeLayout(false);
            this.toolStrip_status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private BrightIdeasSoftware.FastObjectListView listView_Forks;
        private BrightIdeasSoftware.OLVColumn column_Symbol;
        private BrightIdeasSoftware.OLVColumn column_Name;
        private BrightIdeasSoftware.OLVColumn column_Date;
        private BrightIdeasSoftware.OLVColumn column_Conversion;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private BrightIdeasSoftware.OLVColumn column_Blockchain;
        private System.Windows.Forms.ToolStripButton toolStripButton_collapse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ToolStrip toolStrip_status;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_fork;
        private BrightIdeasSoftware.FastObjectListView listView_Wallets;
        private BrightIdeasSoftware.OLVColumn column_ForkName;
        private BrightIdeasSoftware.OLVColumn column_Balance;
        private BrightIdeasSoftware.OLVColumn column_TotalInBTC;
        private BrightIdeasSoftware.OLVColumn column_TotalInUSD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_clear;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_balance;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_usd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_btc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
