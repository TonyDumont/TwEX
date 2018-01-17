namespace TwEX_API.Controls
{
    partial class TradingViewManagerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradingViewManagerControl));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_full = new System.Windows.Forms.TabPage();
            this.tabPage_btc = new System.Windows.Forms.TabPage();
            this.tabPage_usd = new System.Windows.Forms.TabPage();
            this.tabPage_custom = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_exchange = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_market = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel_market = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_symbol = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel_symbol = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton_options = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_hide_top_toolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_withdateranges = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_allow_symbol_change = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_save_image = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_hide_side_toolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_hideideas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_hideideasbutton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_enable_publishing = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ShowWatchlist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ShowIndicators = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_details = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_stocktwits = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_headlines = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_hotlist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_calendar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton_style = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage_full);
            this.tabControl.Controls.Add(this.tabPage_btc);
            this.tabControl.Controls.Add(this.tabPage_usd);
            this.tabControl.Controls.Add(this.tabPage_custom);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(989, 420);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_full
            // 
            this.tabPage_full.Location = new System.Drawing.Point(4, 29);
            this.tabPage_full.Name = "tabPage_full";
            this.tabPage_full.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_full.Size = new System.Drawing.Size(981, 387);
            this.tabPage_full.TabIndex = 0;
            this.tabPage_full.Text = "FULL";
            this.tabPage_full.UseVisualStyleBackColor = true;
            // 
            // tabPage_btc
            // 
            this.tabPage_btc.Location = new System.Drawing.Point(4, 29);
            this.tabPage_btc.Name = "tabPage_btc";
            this.tabPage_btc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_btc.Size = new System.Drawing.Size(981, 390);
            this.tabPage_btc.TabIndex = 1;
            this.tabPage_btc.Text = "BTC";
            this.tabPage_btc.UseVisualStyleBackColor = true;
            // 
            // tabPage_usd
            // 
            this.tabPage_usd.Location = new System.Drawing.Point(4, 29);
            this.tabPage_usd.Name = "tabPage_usd";
            this.tabPage_usd.Size = new System.Drawing.Size(981, 390);
            this.tabPage_usd.TabIndex = 2;
            this.tabPage_usd.Text = "USD";
            this.tabPage_usd.UseVisualStyleBackColor = true;
            // 
            // tabPage_custom
            // 
            this.tabPage_custom.Location = new System.Drawing.Point(4, 29);
            this.tabPage_custom.Name = "tabPage_custom";
            this.tabPage_custom.Size = new System.Drawing.Size(981, 387);
            this.tabPage_custom.TabIndex = 3;
            this.tabPage_custom.Text = "CUSTOM";
            this.tabPage_custom.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_options,
            this.toolStripButton_refresh,
            this.toolStripSeparator3,
            this.toolStripDropDownButton_exchange,
            this.toolStripSeparator2,
            this.toolStripTextBox_market,
            this.toolStripLabel_market,
            this.toolStripSeparator1,
            this.toolStripTextBox_symbol,
            this.toolStripLabel_symbol,
            this.toolStripSeparator9,
            this.toolStripDropDownButton_style});
            this.toolStrip.Location = new System.Drawing.Point(398, 3);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip.Size = new System.Drawing.Size(588, 29);
            this.toolStrip.TabIndex = 2;
            // 
            // toolStripDropDownButton_exchange
            // 
            this.toolStripDropDownButton_exchange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripDropDownButton_exchange.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_exchange.Image")));
            this.toolStripDropDownButton_exchange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_exchange.Name = "toolStripDropDownButton_exchange";
            this.toolStripDropDownButton_exchange.Size = new System.Drawing.Size(124, 26);
            this.toolStripDropDownButton_exchange.Text = "EXCHANGE";
            this.toolStripDropDownButton_exchange.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripDropDownButton_exchange.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_exchange_DropDownItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripButton_refresh
            // 
            this.toolStripButton_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_refresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_refresh.Name = "toolStripButton_refresh";
            this.toolStripButton_refresh.Size = new System.Drawing.Size(41, 26);
            this.toolStripButton_refresh.Text = "SET";
            this.toolStripButton_refresh.Click += new System.EventHandler(this.toolStripButton_refresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripTextBox_market
            // 
            this.toolStripTextBox_market.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripTextBox_market.Name = "toolStripTextBox_market";
            this.toolStripTextBox_market.Size = new System.Drawing.Size(70, 29);
            this.toolStripTextBox_market.Text = "USDT";
            this.toolStripTextBox_market.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripLabel_market
            // 
            this.toolStripLabel_market.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripLabel_market.Name = "toolStripLabel_market";
            this.toolStripLabel_market.Size = new System.Drawing.Size(62, 26);
            this.toolStripLabel_market.Text = ":Market";
            this.toolStripLabel_market.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripTextBox_symbol
            // 
            this.toolStripTextBox_symbol.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripTextBox_symbol.Name = "toolStripTextBox_symbol";
            this.toolStripTextBox_symbol.Size = new System.Drawing.Size(70, 29);
            this.toolStripTextBox_symbol.Text = "BTC";
            this.toolStripTextBox_symbol.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripLabel_symbol
            // 
            this.toolStripLabel_symbol.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripLabel_symbol.Name = "toolStripLabel_symbol";
            this.toolStripLabel_symbol.Size = new System.Drawing.Size(66, 26);
            this.toolStripLabel_symbol.Text = ":Symbol";
            this.toolStripLabel_symbol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripDropDownButton_options
            // 
            this.toolStripDropDownButton_options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_hide_top_toolbar,
            this.toolStripMenuItem_hide_side_toolbar,
            this.toolStripMenuItem_withdateranges,
            this.toolStripSeparator4,
            this.toolStripMenuItem_allow_symbol_change,
            this.toolStripMenuItem_save_image,
            this.toolStripSeparator5,
            this.toolStripMenuItem_hideideas,
            this.toolStripMenuItem_hideideasbutton,
            this.toolStripSeparator6,
            this.toolStripMenuItem_enable_publishing,
            this.toolStripSeparator7,
            this.toolStripMenuItem_ShowWatchlist,
            this.toolStripMenuItem_ShowIndicators,
            this.toolStripSeparator8,
            this.toolStripMenuItem_details,
            this.toolStripMenuItem_stocktwits,
            this.toolStripMenuItem_headlines,
            this.toolStripMenuItem_hotlist,
            this.toolStripMenuItem_calendar});
            this.toolStripDropDownButton_options.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_options.Image")));
            this.toolStripDropDownButton_options.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_options.Name = "toolStripDropDownButton_options";
            this.toolStripDropDownButton_options.Size = new System.Drawing.Size(29, 26);
            this.toolStripDropDownButton_options.Text = "OPTIONS";
            this.toolStripDropDownButton_options.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_options_DropDownItemClicked);
            // 
            // toolStripMenuItem_hide_top_toolbar
            // 
            this.toolStripMenuItem_hide_top_toolbar.Name = "toolStripMenuItem_hide_top_toolbar";
            this.toolStripMenuItem_hide_top_toolbar.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_hide_top_toolbar.Tag = "hide_top_toolbar";
            this.toolStripMenuItem_hide_top_toolbar.Text = "Hide Top Toolbar";
            // 
            // toolStripMenuItem_withdateranges
            // 
            this.toolStripMenuItem_withdateranges.Name = "toolStripMenuItem_withdateranges";
            this.toolStripMenuItem_withdateranges.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_withdateranges.Tag = "withdateranges";
            this.toolStripMenuItem_withdateranges.Text = "Show Date Ranges";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripMenuItem_allow_symbol_change
            // 
            this.toolStripMenuItem_allow_symbol_change.Name = "toolStripMenuItem_allow_symbol_change";
            this.toolStripMenuItem_allow_symbol_change.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_allow_symbol_change.Tag = "allow_symbol_change";
            this.toolStripMenuItem_allow_symbol_change.Text = "Allow Symbol Change";
            // 
            // toolStripMenuItem_save_image
            // 
            this.toolStripMenuItem_save_image.Name = "toolStripMenuItem_save_image";
            this.toolStripMenuItem_save_image.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_save_image.Tag = "save_image";
            this.toolStripMenuItem_save_image.Text = "Show Save Image Button";
            // 
            // toolStripMenuItem_hide_side_toolbar
            // 
            this.toolStripMenuItem_hide_side_toolbar.Name = "toolStripMenuItem_hide_side_toolbar";
            this.toolStripMenuItem_hide_side_toolbar.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_hide_side_toolbar.Tag = "hide_side_toolbar";
            this.toolStripMenuItem_hide_side_toolbar.Text = "Hide Drawing Toolbar";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripMenuItem_hideideas
            // 
            this.toolStripMenuItem_hideideas.Name = "toolStripMenuItem_hideideas";
            this.toolStripMenuItem_hideideas.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_hideideas.Tag = "hideideas";
            this.toolStripMenuItem_hideideas.Text = "Hide Ideas";
            // 
            // toolStripMenuItem_hideideasbutton
            // 
            this.toolStripMenuItem_hideideasbutton.Name = "toolStripMenuItem_hideideasbutton";
            this.toolStripMenuItem_hideideasbutton.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_hideideasbutton.Tag = "hideideasbutton";
            this.toolStripMenuItem_hideideasbutton.Text = "Hide Ideas Button";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripMenuItem_enable_publishing
            // 
            this.toolStripMenuItem_enable_publishing.Name = "toolStripMenuItem_enable_publishing";
            this.toolStripMenuItem_enable_publishing.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_enable_publishing.Tag = "enable_publishing";
            this.toolStripMenuItem_enable_publishing.Text = "Enable Publishing";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripMenuItem_ShowWatchlist
            // 
            this.toolStripMenuItem_ShowWatchlist.Name = "toolStripMenuItem_ShowWatchlist";
            this.toolStripMenuItem_ShowWatchlist.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_ShowWatchlist.Tag = "ShowWatchlist";
            this.toolStripMenuItem_ShowWatchlist.Text = "Show Watch Lists";
            // 
            // toolStripMenuItem_ShowIndicators
            // 
            this.toolStripMenuItem_ShowIndicators.Name = "toolStripMenuItem_ShowIndicators";
            this.toolStripMenuItem_ShowIndicators.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_ShowIndicators.Tag = "ShowIndicators";
            this.toolStripMenuItem_ShowIndicators.Text = "Show Indicators";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(202, 6);
            // 
            // toolStripMenuItem_details
            // 
            this.toolStripMenuItem_details.Name = "toolStripMenuItem_details";
            this.toolStripMenuItem_details.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_details.Tag = "details";
            this.toolStripMenuItem_details.Text = "Show Details";
            // 
            // toolStripMenuItem_stocktwits
            // 
            this.toolStripMenuItem_stocktwits.Name = "toolStripMenuItem_stocktwits";
            this.toolStripMenuItem_stocktwits.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_stocktwits.Tag = "stocktwits";
            this.toolStripMenuItem_stocktwits.Text = "Show StockTwits";
            // 
            // toolStripMenuItem_headlines
            // 
            this.toolStripMenuItem_headlines.Name = "toolStripMenuItem_headlines";
            this.toolStripMenuItem_headlines.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_headlines.Tag = "headlines";
            this.toolStripMenuItem_headlines.Text = "Show Headlines";
            // 
            // toolStripMenuItem_hotlist
            // 
            this.toolStripMenuItem_hotlist.Name = "toolStripMenuItem_hotlist";
            this.toolStripMenuItem_hotlist.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_hotlist.Tag = "hotlist";
            this.toolStripMenuItem_hotlist.Text = "Show Hot List";
            // 
            // toolStripMenuItem_calendar
            // 
            this.toolStripMenuItem_calendar.Name = "toolStripMenuItem_calendar";
            this.toolStripMenuItem_calendar.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem_calendar.Tag = "calendar";
            this.toolStripMenuItem_calendar.Text = "Show Calendar";
            // 
            // toolStripDropDownButton_style
            // 
            this.toolStripDropDownButton_style.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_style.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton_style.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_style.Image")));
            this.toolStripDropDownButton_style.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_style.Name = "toolStripDropDownButton_style";
            this.toolStripDropDownButton_style.Size = new System.Drawing.Size(55, 26);
            this.toolStripDropDownButton_style.Text = "Bars";
            this.toolStripDropDownButton_style.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_style_DropDownItemClicked);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 29);
            // 
            // TradingViewManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tabControl);
            this.Name = "TradingViewManagerControl";
            this.Size = new System.Drawing.Size(992, 426);
            this.Load += new System.EventHandler(this.TradingViewManagerControl_Load);
            this.tabControl.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_full;
        private System.Windows.Forms.TabPage tabPage_btc;
        private System.Windows.Forms.TabPage tabPage_usd;
        private System.Windows.Forms.TabPage tabPage_custom;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_exchange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_refresh;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_market;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_market;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_symbol;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_symbol;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_options;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_hide_top_toolbar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_hide_side_toolbar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_withdateranges;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_allow_symbol_change;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_save_image;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_hideideas;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_hideideasbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_enable_publishing;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowWatchlist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ShowIndicators;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_details;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_stocktwits;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_headlines;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_hotlist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_calendar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_style;
    }
}
