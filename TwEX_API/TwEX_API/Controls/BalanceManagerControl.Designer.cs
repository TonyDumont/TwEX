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
            this.toolStrip_footer = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Font = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FontDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FontUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_collapse = new System.Windows.Forms.ToolStripButton();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.toolStrip_header = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CoinCount = new System.Windows.Forms.ToolStripLabel();
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
            this.toolStrip_footer.SuspendLayout();
            this.toolStrip_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_footer
            // 
            this.toolStrip_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_footer.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip_footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Font,
            this.toolStripSeparator3,
            this.toolStripButton_FontDown,
            this.toolStripSeparator1,
            this.toolStripButton_FontUp,
            this.toolStripSeparator2,
            this.toolStripButton_collapse});
            this.toolStrip_footer.Location = new System.Drawing.Point(0, 315);
            this.toolStrip_footer.Name = "toolStrip_footer";
            this.toolStrip_footer.Size = new System.Drawing.Size(777, 39);
            this.toolStrip_footer.TabIndex = 0;
            this.toolStrip_footer.Text = "toolStrip1";
            // 
            // toolStripButton_Font
            // 
            this.toolStripButton_Font.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Font.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Font.Image")));
            this.toolStripButton_Font.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Font.Name = "toolStripButton_Font";
            this.toolStripButton_Font.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Font.Text = "FONT";
            this.toolStripButton_Font.Click += new System.EventHandler(this.toolStripButton_Font_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_FontDown
            // 
            this.toolStripButton_FontDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_FontDown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_FontDown.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_FontDown.Image")));
            this.toolStripButton_FontDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FontDown.Name = "toolStripButton_FontDown";
            this.toolStripButton_FontDown.Size = new System.Drawing.Size(23, 36);
            this.toolStripButton_FontDown.Text = "-";
            this.toolStripButton_FontDown.ToolTipText = "Decrease Font Size";
            this.toolStripButton_FontDown.Click += new System.EventHandler(this.toolStripButton_FontDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_FontUp
            // 
            this.toolStripButton_FontUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_FontUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_FontUp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_FontUp.Image")));
            this.toolStripButton_FontUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FontUp.Name = "toolStripButton_FontUp";
            this.toolStripButton_FontUp.Size = new System.Drawing.Size(23, 36);
            this.toolStripButton_FontUp.Text = "+";
            this.toolStripButton_FontUp.ToolTipText = "Increase Font Size";
            this.toolStripButton_FontUp.Click += new System.EventHandler(this.toolStripButton_FontUp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_collapse
            // 
            this.toolStripButton_collapse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_collapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_collapse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_collapse.Image")));
            this.toolStripButton_collapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_collapse.Name = "toolStripButton_collapse";
            this.toolStripButton_collapse.Size = new System.Drawing.Size(99, 36);
            this.toolStripButton_collapse.Text = "Expand/Collapse";
            this.toolStripButton_collapse.Click += new System.EventHandler(this.toolStripButton_toggleGroup_Click);
            // 
            // toolStrip_header
            // 
            this.toolStrip_header.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip_header.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_CoinCount,
            this.toolStripRadioButton_symbol,
            this.toolStripRadioButton_exchange,
            this.toolStripRadioButton_balance});
            this.toolStrip_header.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_header.Name = "toolStrip_header";
            this.toolStrip_header.Size = new System.Drawing.Size(777, 39);
            this.toolStrip_header.TabIndex = 1;
            this.toolStrip_header.Text = "toolStrip1";
            // 
            // toolStripLabel_CoinCount
            // 
            this.toolStripLabel_CoinCount.Name = "toolStripLabel_CoinCount";
            this.toolStripLabel_CoinCount.Size = new System.Drawing.Size(80, 36);
            this.toolStripLabel_CoinCount.Text = "COIN COUNT";
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
            this.listView.ShowImagesOnSubItems = true;
            this.listView.ShowItemCountOnGroups = true;
            this.listView.Size = new System.Drawing.Size(777, 276);
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
            // BalanceManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip_header);
            this.Controls.Add(this.toolStrip_footer);
            this.Name = "BalanceManagerControl";
            this.Size = new System.Drawing.Size(777, 354);
            this.Load += new System.EventHandler(this.BalanceManagerControl_Load);
            this.toolStrip_footer.ResumeLayout(false);
            this.toolStrip_footer.PerformLayout();
            this.toolStrip_header.ResumeLayout(false);
            this.toolStrip_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_footer;
        private System.Windows.Forms.ToolStripButton toolStripButton_Font;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStrip toolStrip_header;
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
        private System.Windows.Forms.ToolStripButton toolStripButton_collapse;
    }
}
