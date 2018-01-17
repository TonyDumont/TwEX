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
            this.toolStripButton_Font = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FontUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_FontDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_details = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_update = new System.Windows.Forms.ToolStripLabel();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_rank = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_market_cap_usd = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_price_usd = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_price_btc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_volume = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_24hchange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Font,
            this.toolStripSeparator1,
            this.toolStripButton_FontUp,
            this.toolStripSeparator2,
            this.toolStripButton_FontDown,
            this.toolStripSeparator3,
            this.toolStripLabel_details,
            this.toolStripLabel_update});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(679, 39);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton_Font
            // 
            this.toolStripButton_Font.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Font.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Font.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Font.Image")));
            this.toolStripButton_Font.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Font.Name = "toolStripButton_Font";
            this.toolStripButton_Font.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Font.Text = "FONT";
            this.toolStripButton_Font.Click += new System.EventHandler(this.toolStripButton_Font_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_FontUp
            // 
            this.toolStripButton_FontUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
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
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_FontDown
            // 
            this.toolStripButton_FontDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel_details
            // 
            this.toolStripLabel_details.Name = "toolStripLabel_details";
            this.toolStripLabel_details.Size = new System.Drawing.Size(106, 36);
            this.toolStripLabel_details.Text = "Market Cap Details";
            // 
            // toolStripLabel_update
            // 
            this.toolStripLabel_update.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_update.Name = "toolStripLabel_update";
            this.toolStripLabel_update.Size = new System.Drawing.Size(69, 36);
            this.toolStripLabel_update.Text = "Last Update";
            this.toolStripLabel_update.Click += new System.EventHandler(this.toolStripLabel_update_Click);
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
            this.listView.Location = new System.Drawing.Point(0, 39);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectColumnsOnRightClick = false;
            this.listView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView.ShowFilterMenuOnRightClick = false;
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(679, 348);
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
            // column_symbol
            // 
            this.column_symbol.AspectName = "symbol";
            this.column_symbol.MinimumWidth = 60;
            this.column_symbol.Text = "";
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
        private System.Windows.Forms.ToolStripButton toolStripButton_Font;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_FontUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.FontDialog fontDialog;
        private BrightIdeasSoftware.OLVColumn column_symbol;
    }
}
