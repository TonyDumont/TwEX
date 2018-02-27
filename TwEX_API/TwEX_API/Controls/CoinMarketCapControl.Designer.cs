namespace TwEX_API.Controls
{
    partial class CoinMarketCapControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoinMarketCapControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_update = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_details = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_update = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_search = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_search = new System.Windows.Forms.ToolStripButton();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_rank = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_market_cap_usd = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_price_usd = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_price_btc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_volume = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_24hchange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator1,
            this.toolStripLabel_details,
            this.toolStripLabel_update,
            this.toolStripSeparator2,
            this.toolStripTextBox_search,
            this.toolStripButton_search});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(679, 25);
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
            this.toolStripSeparator4,
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
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_update
            // 
            this.toolStripMenuItem_update.Name = "toolStripMenuItem_update";
            this.toolStripMenuItem_update.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_update.Tag = "Update";
            this.toolStripMenuItem_update.Text = "Refresh All";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_details
            // 
            this.toolStripLabel_details.Name = "toolStripLabel_details";
            this.toolStripLabel_details.Size = new System.Drawing.Size(106, 22);
            this.toolStripLabel_details.Text = "Market Cap Details";
            // 
            // toolStripLabel_update
            // 
            this.toolStripLabel_update.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_update.Name = "toolStripLabel_update";
            this.toolStripLabel_update.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel_update.Text = "Last Update";
            this.toolStripLabel_update.Click += new System.EventHandler(this.toolStripLabel_update_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox_search
            // 
            this.toolStripTextBox_search.Name = "toolStripTextBox_search";
            this.toolStripTextBox_search.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox_search.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolStripTextBox_search.TextChanged += new System.EventHandler(this.toolStripTextBox_search_TextChanged);
            // 
            // toolStripButton_search
            // 
            this.toolStripButton_search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_search.Enabled = false;
            this.toolStripButton_search.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_search.Image")));
            this.toolStripButton_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_search.Name = "toolStripButton_search";
            this.toolStripButton_search.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_search.Text = "SEARCH";
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_rank);
            this.listView.AllColumns.Add(this.column_symbol);
            this.listView.AllColumns.Add(this.column_name);
            this.listView.AllColumns.Add(this.column_market_cap_usd);
            this.listView.AllColumns.Add(this.column_price_usd);
            this.listView.AllColumns.Add(this.column_price_btc);
            this.listView.AllColumns.Add(this.column_volume);
            this.listView.AllColumns.Add(this.column_24hchange);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_rank,
            this.column_symbol,
            this.column_name,
            this.column_market_cap_usd,
            this.column_price_usd,
            this.column_price_btc,
            this.column_volume,
            this.column_24hchange});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectColumnsOnRightClick = false;
            this.listView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView.ShowFilterMenuOnRightClick = false;
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(679, 362);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 3;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ListView_FormatCell);
            // 
            // column_rank
            // 
            this.column_rank.AspectName = "rank";
            this.column_rank.Text = "";
            this.column_rank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_rank.Width = 40;
            // 
            // column_symbol
            // 
            this.column_symbol.AspectName = "symbol";
            this.column_symbol.MinimumWidth = 60;
            this.column_symbol.Text = "";
            // 
            // column_name
            // 
            this.column_name.AspectName = "name";
            this.column_name.MinimumWidth = 100;
            this.column_name.Text = "Name";
            this.column_name.Width = 100;
            // 
            // column_market_cap_usd
            // 
            this.column_market_cap_usd.AspectName = "market_cap_usd";
            this.column_market_cap_usd.AspectToStringFormat = "{0:C}";
            this.column_market_cap_usd.MinimumWidth = 100;
            this.column_market_cap_usd.Text = "Market Cap";
            this.column_market_cap_usd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_market_cap_usd.Width = 100;
            // 
            // column_price_usd
            // 
            this.column_price_usd.AspectName = "price_usd";
            this.column_price_usd.AspectToStringFormat = "{0:C}";
            this.column_price_usd.MinimumWidth = 65;
            this.column_price_usd.Text = "USD";
            this.column_price_usd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_price_usd.Width = 65;
            // 
            // column_price_btc
            // 
            this.column_price_btc.AspectName = "price_btc";
            this.column_price_btc.AspectToStringFormat = "{0:N8}";
            this.column_price_btc.MinimumWidth = 100;
            this.column_price_btc.Text = "BTC";
            this.column_price_btc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_price_btc.Width = 100;
            // 
            // column_volume
            // 
            this.column_volume.AspectName = "volume_24h";
            this.column_volume.AspectToStringFormat = "{0:C}";
            this.column_volume.MinimumWidth = 100;
            this.column_volume.Text = "Volume (24h)";
            this.column_volume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_volume.Width = 100;
            // 
            // column_24hchange
            // 
            this.column_24hchange.AspectName = "percent_change_24h";
            this.column_24hchange.AspectToStringFormat = "";
            this.column_24hchange.MinimumWidth = 60;
            this.column_24hchange.Text = "(24h %)";
            this.column_24hchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CoinMarketCapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "CoinMarketCapControl";
            this.Size = new System.Drawing.Size(679, 387);
            this.Load += new System.EventHandler(this.CoinMarketCapControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_details;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_update;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_rank;
        private BrightIdeasSoftware.OLVColumn column_name;
        private BrightIdeasSoftware.OLVColumn column_market_cap_usd;
        private BrightIdeasSoftware.OLVColumn column_price_usd;
        private BrightIdeasSoftware.OLVColumn column_price_btc;
        private BrightIdeasSoftware.OLVColumn column_volume;
        private BrightIdeasSoftware.OLVColumn column_24hchange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private BrightIdeasSoftware.OLVColumn column_symbol;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_update;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_search;
        private System.Windows.Forms.ToolStripButton toolStripButton_search;
    }
}
