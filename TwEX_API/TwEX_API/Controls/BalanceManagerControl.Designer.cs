namespace TwEX_API.Controls
{
    partial class BalanceManagerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceManagerControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_CoinCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_collapse = new System.Windows.Forms.ToolStripButton();
            this.toolStripRadioButton_symbol = new TwEX_API.ToolStripRadioButton();
            this.toolStripRadioButton_exchange = new TwEX_API.ToolStripRadioButton();
            this.toolStripRadioButton_balance = new TwEX_API.ToolStripRadioButton();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_Exchange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_SymbolIcon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_ExchangeIcon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Balance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInBTC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInUSD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator4,
            this.toolStripLabel_CoinCount,
            this.toolStripButton_collapse,
            this.toolStripSeparator1,
            this.toolStripRadioButton_symbol,
            this.toolStripRadioButton_exchange,
            this.toolStripRadioButton_balance});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(777, 39);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(45, 36);
            this.toolStripDropDownButton_menu.Text = "OPTIONS";
            this.toolStripDropDownButton_menu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_menu_DropDownItemClicked);
            // 
            // toolStripMenuItem_font
            // 
            this.toolStripMenuItem_font.Name = "toolStripMenuItem_font";
            this.toolStripMenuItem_font.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_font.Tag = "Font";
            this.toolStripMenuItem_font.Text = "Font";
            // 
            // toolStripMenuItem_fontIncrease
            // 
            this.toolStripMenuItem_fontIncrease.Name = "toolStripMenuItem_fontIncrease";
            this.toolStripMenuItem_fontIncrease.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_fontIncrease.Tag = "FontIncrease";
            this.toolStripMenuItem_fontIncrease.Text = "Increase Font";
            // 
            // toolStripMenuItem_fontDecrease
            // 
            this.toolStripMenuItem_fontDecrease.Name = "toolStripMenuItem_fontDecrease";
            this.toolStripMenuItem_fontDecrease.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_fontDecrease.Tag = "FontDecrease";
            this.toolStripMenuItem_fontDecrease.Text = "Decrease Font";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel_CoinCount
            // 
            this.toolStripLabel_CoinCount.Name = "toolStripLabel_CoinCount";
            this.toolStripLabel_CoinCount.Size = new System.Drawing.Size(80, 36);
            this.toolStripLabel_CoinCount.Text = "COIN COUNT";
            // 
            // toolStripButton_collapse
            // 
            this.toolStripButton_collapse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_collapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_collapse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_collapse.Image")));
            this.toolStripButton_collapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_collapse.Name = "toolStripButton_collapse";
            this.toolStripButton_collapse.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_collapse.Text = "Expand/Collapse";
            this.toolStripButton_collapse.Click += new System.EventHandler(this.toolStripButton_toggleGroup_Click);
            // 
            // toolStripRadioButton_symbol
            // 
            this.toolStripRadioButton_symbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRadioButton_symbol.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_symbol.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_symbol.CheckOnClick = true;
            this.toolStripRadioButton_symbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_symbol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_symbol.Image")));
            this.toolStripRadioButton_symbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_symbol.Name = "toolStripRadioButton_symbol";
            this.toolStripRadioButton_symbol.RadioButtonGroupId = 0;
            this.toolStripRadioButton_symbol.Size = new System.Drawing.Size(36, 36);
            this.toolStripRadioButton_symbol.Tag = "symbol";
            this.toolStripRadioButton_symbol.Text = "Symbol View";
            this.toolStripRadioButton_symbol.Click += new System.EventHandler(this.toolStripRadioButton_view_Click);
            // 
            // toolStripRadioButton_exchange
            // 
            this.toolStripRadioButton_exchange.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRadioButton_exchange.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_exchange.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_exchange.CheckOnClick = true;
            this.toolStripRadioButton_exchange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_exchange.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_exchange.Image")));
            this.toolStripRadioButton_exchange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_exchange.Name = "toolStripRadioButton_exchange";
            this.toolStripRadioButton_exchange.RadioButtonGroupId = 0;
            this.toolStripRadioButton_exchange.Size = new System.Drawing.Size(36, 36);
            this.toolStripRadioButton_exchange.Tag = "exchange";
            this.toolStripRadioButton_exchange.Text = "Exchange View";
            this.toolStripRadioButton_exchange.Click += new System.EventHandler(this.toolStripRadioButton_view_Click);
            // 
            // toolStripRadioButton_balance
            // 
            this.toolStripRadioButton_balance.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRadioButton_balance.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_balance.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_balance.CheckOnClick = true;
            this.toolStripRadioButton_balance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRadioButton_balance.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_balance.Image")));
            this.toolStripRadioButton_balance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_balance.Name = "toolStripRadioButton_balance";
            this.toolStripRadioButton_balance.RadioButtonGroupId = 0;
            this.toolStripRadioButton_balance.Size = new System.Drawing.Size(36, 36);
            this.toolStripRadioButton_balance.Tag = "balance";
            this.toolStripRadioButton_balance.Text = "Balance View";
            this.toolStripRadioButton_balance.Click += new System.EventHandler(this.toolStripRadioButton_view_Click);
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_Exchange);
            this.listView.AllColumns.Add(this.column_SymbolIcon);
            this.listView.AllColumns.Add(this.column_Symbol);
            this.listView.AllColumns.Add(this.column_ExchangeIcon);
            this.listView.AllColumns.Add(this.column_Balance);
            this.listView.AllColumns.Add(this.column_TotalInBTC);
            this.listView.AllColumns.Add(this.column_TotalInUSD);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Exchange,
            this.column_SymbolIcon,
            this.column_Symbol,
            this.column_ExchangeIcon,
            this.column_Balance,
            this.column_TotalInBTC,
            this.column_TotalInUSD});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 39);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.ShowImagesOnSubItems = true;
            this.listView.ShowItemCountOnGroups = true;
            this.listView.Size = new System.Drawing.Size(777, 315);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 5;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.AboutToCreateGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.aboutToCreateGroups);
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
            // column_SymbolIcon
            // 
            this.column_SymbolIcon.Text = "";
            this.column_SymbolIcon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_Symbol
            // 
            this.column_Symbol.AspectName = "Symbol";
            this.column_Symbol.MinimumWidth = 90;
            this.column_Symbol.Text = "Symbol";
            this.column_Symbol.Width = 90;
            // 
            // column_ExchangeIcon
            // 
            this.column_ExchangeIcon.AspectName = "";
            this.column_ExchangeIcon.MinimumWidth = 32;
            this.column_ExchangeIcon.Text = "";
            this.column_ExchangeIcon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_ExchangeIcon.Width = 32;
            // 
            // column_Balance
            // 
            this.column_Balance.AspectName = "Balance";
            this.column_Balance.AspectToStringFormat = "{0:N8}";
            this.column_Balance.Text = "Coin Total";
            this.column_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // BalanceManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "BalanceManagerControl";
            this.Size = new System.Drawing.Size(777, 354);
            this.Load += new System.EventHandler(this.BalanceManagerControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CoinCount;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_Symbol;
        private BrightIdeasSoftware.OLVColumn column_ExchangeIcon;
        private BrightIdeasSoftware.OLVColumn column_Balance;
        private BrightIdeasSoftware.OLVColumn column_TotalInBTC;
        private BrightIdeasSoftware.OLVColumn column_TotalInUSD;
        private ToolStripRadioButton toolStripRadioButton_symbol;
        private ToolStripRadioButton toolStripRadioButton_exchange;
        private ToolStripRadioButton toolStripRadioButton_balance;
        private BrightIdeasSoftware.OLVColumn column_SymbolIcon;
        private BrightIdeasSoftware.OLVColumn column_Exchange;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_collapse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
