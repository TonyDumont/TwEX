namespace TwEX_API.Controls
{
    partial class ExchangeManagerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExchangeManagerControl));
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_Icon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Tickers = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Coins = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Orders = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInBTC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_TotalInUSD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip_header = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Tickers = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Balances = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_Orders = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_History = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Orders = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_Exchanges = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_header2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_API = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Totals = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.toolStrip_header.SuspendLayout();
            this.toolStrip_header2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_Icon);
            this.listView.AllColumns.Add(this.column_Name);
            this.listView.AllColumns.Add(this.column_Tickers);
            this.listView.AllColumns.Add(this.column_Coins);
            this.listView.AllColumns.Add(this.column_Orders);
            this.listView.AllColumns.Add(this.column_TotalInBTC);
            this.listView.AllColumns.Add(this.column_TotalInUSD);
            this.listView.AllColumns.Add(this.column_Status);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Icon,
            this.column_Name,
            this.column_Tickers,
            this.column_Coins,
            this.column_Orders,
            this.column_TotalInBTC,
            this.column_TotalInUSD,
            this.column_Status});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 53);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectColumnsOnRightClick = false;
            this.listView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView.ShowFilterMenuOnRightClick = false;
            this.listView.ShowGroups = false;
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(765, 358);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.SelectionChanged += new System.EventHandler(this.listView_SelectionChanged);
            // 
            // column_Icon
            // 
            this.column_Icon.Text = "";
            this.column_Icon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_Icon.Width = 25;
            // 
            // column_Name
            // 
            this.column_Name.AspectName = "Name";
            this.column_Name.Text = "Name";
            this.column_Name.Width = 80;
            // 
            // column_Tickers
            // 
            this.column_Tickers.DisplayIndex = 6;
            this.column_Tickers.MaximumWidth = 0;
            this.column_Tickers.MinimumWidth = 0;
            this.column_Tickers.Text = "Tickers";
            this.column_Tickers.Width = 0;
            // 
            // column_Coins
            // 
            this.column_Coins.AspectName = "CoinCount";
            this.column_Coins.DisplayIndex = 2;
            this.column_Coins.Text = "#";
            this.column_Coins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_Coins.Width = 35;
            // 
            // column_Orders
            // 
            this.column_Orders.AspectName = "";
            this.column_Orders.AspectToStringFormat = "{0:N8}";
            this.column_Orders.DisplayIndex = 3;
            this.column_Orders.MinimumWidth = 100;
            this.column_Orders.Text = "Orders";
            this.column_Orders.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_Orders.Width = 100;
            // 
            // column_TotalInBTC
            // 
            this.column_TotalInBTC.AspectName = "";
            this.column_TotalInBTC.AspectToStringFormat = "";
            this.column_TotalInBTC.DisplayIndex = 4;
            this.column_TotalInBTC.MinimumWidth = 100;
            this.column_TotalInBTC.Text = "BTC";
            this.column_TotalInBTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_TotalInBTC.Width = 100;
            // 
            // column_TotalInUSD
            // 
            this.column_TotalInUSD.AspectName = "";
            this.column_TotalInUSD.AspectToStringFormat = "";
            this.column_TotalInUSD.DisplayIndex = 5;
            this.column_TotalInUSD.MinimumWidth = 100;
            this.column_TotalInUSD.Text = "USD";
            this.column_TotalInUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_TotalInUSD.Width = 100;
            // 
            // column_Status
            // 
            this.column_Status.Text = "";
            this.column_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_Status.Width = 35;
            // 
            // toolStrip_header
            // 
            this.toolStrip_header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip_header.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Tickers,
            this.toolStripButton_Balances,
            this.toolStripLabel_Orders,
            this.toolStripButton_History,
            this.toolStripButton_Orders,
            this.toolStripLabel_Exchanges});
            this.toolStrip_header.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_header.Name = "toolStrip_header";
            this.toolStrip_header.Size = new System.Drawing.Size(771, 25);
            this.toolStrip_header.TabIndex = 3;
            this.toolStrip_header.Text = "toolStrip1";
            // 
            // toolStripButton_Tickers
            // 
            this.toolStripButton_Tickers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Tickers.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Tickers.Image")));
            this.toolStripButton_Tickers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Tickers.Name = "toolStripButton_Tickers";
            this.toolStripButton_Tickers.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Tickers.Tag = "TICKERS";
            this.toolStripButton_Tickers.Text = "TICKERS";
            this.toolStripButton_Tickers.ToolTipText = "Tickers";
            this.toolStripButton_Tickers.Click += new System.EventHandler(this.toolStripButton_TimerItem_Click);
            // 
            // toolStripButton_Balances
            // 
            this.toolStripButton_Balances.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Balances.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Balances.Image")));
            this.toolStripButton_Balances.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Balances.Name = "toolStripButton_Balances";
            this.toolStripButton_Balances.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Balances.Tag = "BALANCES";
            this.toolStripButton_Balances.Text = "BALANCES";
            this.toolStripButton_Balances.ToolTipText = "Balances";
            this.toolStripButton_Balances.Click += new System.EventHandler(this.toolStripButton_TimerItem_Click);
            // 
            // toolStripLabel_Orders
            // 
            this.toolStripLabel_Orders.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_Orders.Name = "toolStripLabel_Orders";
            this.toolStripLabel_Orders.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel_Orders.Text = "ORDERS";
            // 
            // toolStripButton_History
            // 
            this.toolStripButton_History.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_History.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_History.Image")));
            this.toolStripButton_History.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_History.Name = "toolStripButton_History";
            this.toolStripButton_History.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_History.Tag = "HISTORY";
            this.toolStripButton_History.Text = "HISTORY";
            this.toolStripButton_History.ToolTipText = "History";
            this.toolStripButton_History.Click += new System.EventHandler(this.toolStripButton_TimerItem_Click);
            // 
            // toolStripButton_Orders
            // 
            this.toolStripButton_Orders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Orders.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Orders.Image")));
            this.toolStripButton_Orders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Orders.Name = "toolStripButton_Orders";
            this.toolStripButton_Orders.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Orders.Tag = "ORDERS";
            this.toolStripButton_Orders.Text = "ORDERS";
            this.toolStripButton_Orders.ToolTipText = "Orders";
            this.toolStripButton_Orders.Click += new System.EventHandler(this.toolStripButton_TimerItem_Click);
            // 
            // toolStripLabel_Exchanges
            // 
            this.toolStripLabel_Exchanges.Name = "toolStripLabel_Exchanges";
            this.toolStripLabel_Exchanges.Size = new System.Drawing.Size(72, 22);
            this.toolStripLabel_Exchanges.Text = "# Exchanges";
            // 
            // toolStrip_header2
            // 
            this.toolStrip_header2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip_header2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator1,
            this.toolStripButton_API,
            this.toolStripButton_Totals,
            this.toolStripSeparator4});
            this.toolStrip_header2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip_header2.Name = "toolStrip_header2";
            this.toolStrip_header2.Size = new System.Drawing.Size(771, 25);
            this.toolStrip_header2.TabIndex = 4;
            this.toolStrip_header2.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_API
            // 
            this.toolStripButton_API.Enabled = false;
            this.toolStripButton_API.Image = global::TwEX_API.Properties.Resources.ConnectionStatus_DISABLED;
            this.toolStripButton_API.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_API.Name = "toolStripButton_API";
            this.toolStripButton_API.Size = new System.Drawing.Size(45, 22);
            this.toolStripButton_API.Text = "API";
            this.toolStripButton_API.Click += new System.EventHandler(this.toolStripButton_API_Click);
            // 
            // toolStripButton_Totals
            // 
            this.toolStripButton_Totals.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Totals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Totals.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Totals.Image")));
            this.toolStripButton_Totals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Totals.Name = "toolStripButton_Totals";
            this.toolStripButton_Totals.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton_Totals.Text = "TOTALS";
            this.toolStripButton_Totals.Click += new System.EventHandler(this.toolStripButton_BTCTotal_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip_header, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip_header2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(771, 414);
            this.tableLayoutPanel1.TabIndex = 5;
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
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton_menu.Text = "OPTIONS";
            this.toolStripDropDownButton_menu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_menu_DropDownItemClicked);
            // 
            // toolStripMenuItem_font
            // 
            this.toolStripMenuItem_font.Name = "toolStripMenuItem_font";
            this.toolStripMenuItem_font.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_font.Tag = "Font";
            this.toolStripMenuItem_font.Text = "Font";
            // 
            // toolStripMenuItem_fontIncrease
            // 
            this.toolStripMenuItem_fontIncrease.Name = "toolStripMenuItem_fontIncrease";
            this.toolStripMenuItem_fontIncrease.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_fontIncrease.Tag = "FontIncrease";
            this.toolStripMenuItem_fontIncrease.Text = "Increase Font";
            // 
            // toolStripMenuItem_fontDecrease
            // 
            this.toolStripMenuItem_fontDecrease.Name = "toolStripMenuItem_fontDecrease";
            this.toolStripMenuItem_fontDecrease.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_fontDecrease.Tag = "FontDecrease";
            this.toolStripMenuItem_fontDecrease.Text = "Decrease Font";
            // 
            // ExchangeEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExchangeEditorControl";
            this.Size = new System.Drawing.Size(771, 414);
            this.Load += new System.EventHandler(this.ExchangeEditorControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.toolStrip_header.ResumeLayout(false);
            this.toolStrip_header.PerformLayout();
            this.toolStrip_header2.ResumeLayout(false);
            this.toolStrip_header2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_Name;
        private BrightIdeasSoftware.OLVColumn column_Coins;
        private BrightIdeasSoftware.OLVColumn column_Orders;
        private BrightIdeasSoftware.OLVColumn column_TotalInBTC;
        private BrightIdeasSoftware.OLVColumn column_TotalInUSD;
        private BrightIdeasSoftware.OLVColumn column_Icon;
        private System.Windows.Forms.ToolStrip toolStrip_header;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Exchanges;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Orders;
        private BrightIdeasSoftware.OLVColumn column_Tickers;
        private System.Windows.Forms.ToolStrip toolStrip_header2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Totals;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_API;
        private BrightIdeasSoftware.OLVColumn column_Status;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_Tickers;
        private System.Windows.Forms.ToolStripButton toolStripButton_Balances;
        private System.Windows.Forms.ToolStripButton toolStripButton_History;
        private System.Windows.Forms.ToolStripButton toolStripButton_Orders;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
    }
}
