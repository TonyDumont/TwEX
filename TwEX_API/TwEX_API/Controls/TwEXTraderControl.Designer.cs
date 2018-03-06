namespace TwEX_API.Controls
{
    partial class TwEXTraderControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwEXTraderControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Balance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Calculator = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Wallet = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ExchangeEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator_1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_LogManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator_2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ArbitrageManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_CoinMarketCap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_CryptoCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EarnGG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_TradingView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator_3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_PreferenceManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exchangeManagerControl = new TwEX_API.Controls.ExchangeManagerControl();
            this.toolStripDropDownButton_websites = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Balance,
            this.toolStripSeparator1,
            this.toolStripButton_Calculator,
            this.toolStripSeparator2,
            this.toolStripButton_Wallet,
            this.toolStripButton_ExchangeEditor,
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator7,
            this.toolStripDropDownButton_websites});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(494, 39);
            this.toolStrip.TabIndex = 5;
            // 
            // toolStripButton_Balance
            // 
            this.toolStripButton_Balance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Balance.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Balance.Image")));
            this.toolStripButton_Balance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Balance.Name = "toolStripButton_Balance";
            this.toolStripButton_Balance.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Balance.Tag = "BalanceManager";
            this.toolStripButton_Balance.Text = "Balance Manager";
            this.toolStripButton_Balance.Click += new System.EventHandler(this.toolStripButton_Form_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_Calculator
            // 
            this.toolStripButton_Calculator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Calculator.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Calculator.Image")));
            this.toolStripButton_Calculator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Calculator.Name = "toolStripButton_Calculator";
            this.toolStripButton_Calculator.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Calculator.Tag = "CoinCalculator";
            this.toolStripButton_Calculator.Text = "Coin Calculator";
            this.toolStripButton_Calculator.Click += new System.EventHandler(this.toolStripButton_Form_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_Wallet
            // 
            this.toolStripButton_Wallet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Wallet.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Wallet.Image")));
            this.toolStripButton_Wallet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Wallet.Name = "toolStripButton_Wallet";
            this.toolStripButton_Wallet.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Wallet.Tag = "WalletManager";
            this.toolStripButton_Wallet.Text = "Wallet Manager";
            this.toolStripButton_Wallet.Visible = false;
            this.toolStripButton_Wallet.Click += new System.EventHandler(this.toolStripButton_Form_Click);
            // 
            // toolStripButton_ExchangeEditor
            // 
            this.toolStripButton_ExchangeEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ExchangeEditor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ExchangeEditor.Image")));
            this.toolStripButton_ExchangeEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ExchangeEditor.Name = "toolStripButton_ExchangeEditor";
            this.toolStripButton_ExchangeEditor.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_ExchangeEditor.Tag = "ExchangeManager";
            this.toolStripButton_ExchangeEditor.Text = "Exchange Manager";
            this.toolStripButton_ExchangeEditor.Visible = false;
            this.toolStripButton_ExchangeEditor.Click += new System.EventHandler(this.toolStripButton_Form_Click);
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator_1,
            this.toolStripMenuItem_LogManager,
            this.toolStripSeparator_2,
            this.toolStripMenuItem_ArbitrageManager,
            this.toolStripMenuItem_CoinMarketCap,
            this.toolStripMenuItem_CryptoCompare,
            this.toolStripMenuItem_EarnGG,
            this.toolStripMenuItem_TradingView,
            this.toolStripSeparator_3,
            this.toolStripMenuItem_PreferenceManager,
            this.toolStripSeparator3,
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(45, 36);
            this.toolStripDropDownButton_menu.Text = "MENU";
            this.toolStripDropDownButton_menu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_menu_DropDownItemClicked);
            // 
            // toolStripSeparator_1
            // 
            this.toolStripSeparator_1.Name = "toolStripSeparator_1";
            this.toolStripSeparator_1.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripMenuItem_LogManager
            // 
            this.toolStripMenuItem_LogManager.Name = "toolStripMenuItem_LogManager";
            this.toolStripMenuItem_LogManager.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_LogManager.Tag = "LogManager";
            this.toolStripMenuItem_LogManager.Text = "Log Manager";
            // 
            // toolStripSeparator_2
            // 
            this.toolStripSeparator_2.Name = "toolStripSeparator_2";
            this.toolStripSeparator_2.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripMenuItem_ArbitrageManager
            // 
            this.toolStripMenuItem_ArbitrageManager.Name = "toolStripMenuItem_ArbitrageManager";
            this.toolStripMenuItem_ArbitrageManager.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_ArbitrageManager.Tag = "ArbitrageManager";
            this.toolStripMenuItem_ArbitrageManager.Text = "Arbitrage Manager";
            // 
            // toolStripMenuItem_CoinMarketCap
            // 
            this.toolStripMenuItem_CoinMarketCap.Name = "toolStripMenuItem_CoinMarketCap";
            this.toolStripMenuItem_CoinMarketCap.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_CoinMarketCap.Tag = "CoinMarketCap";
            this.toolStripMenuItem_CoinMarketCap.Text = "Coin Market Caps";
            // 
            // toolStripMenuItem_CryptoCompare
            // 
            this.toolStripMenuItem_CryptoCompare.Name = "toolStripMenuItem_CryptoCompare";
            this.toolStripMenuItem_CryptoCompare.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_CryptoCompare.Tag = "CryptoCompare";
            this.toolStripMenuItem_CryptoCompare.Text = "CryptoCompare";
            // 
            // toolStripMenuItem_EarnGG
            // 
            this.toolStripMenuItem_EarnGG.Name = "toolStripMenuItem_EarnGG";
            this.toolStripMenuItem_EarnGG.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_EarnGG.Tag = "EarnGGManager";
            this.toolStripMenuItem_EarnGG.Text = "EarnGG Manager";
            // 
            // toolStripMenuItem_TradingView
            // 
            this.toolStripMenuItem_TradingView.Name = "toolStripMenuItem_TradingView";
            this.toolStripMenuItem_TradingView.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_TradingView.Tag = "TradingView";
            this.toolStripMenuItem_TradingView.Text = "Trading View";
            // 
            // toolStripSeparator_3
            // 
            this.toolStripSeparator_3.Name = "toolStripSeparator_3";
            this.toolStripSeparator_3.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripMenuItem_PreferenceManager
            // 
            this.toolStripMenuItem_PreferenceManager.Name = "toolStripMenuItem_PreferenceManager";
            this.toolStripMenuItem_PreferenceManager.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_PreferenceManager.Tag = "PreferenceManager";
            this.toolStripMenuItem_PreferenceManager.Text = "Preference Manager";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripMenuItem_font
            // 
            this.toolStripMenuItem_font.Name = "toolStripMenuItem_font";
            this.toolStripMenuItem_font.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_font.Tag = "Font";
            this.toolStripMenuItem_font.Text = "Font";
            // 
            // toolStripMenuItem_fontIncrease
            // 
            this.toolStripMenuItem_fontIncrease.Name = "toolStripMenuItem_fontIncrease";
            this.toolStripMenuItem_fontIncrease.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_fontIncrease.Tag = "FontIncrease";
            this.toolStripMenuItem_fontIncrease.Text = "Increase Font";
            // 
            // toolStripMenuItem_fontDecrease
            // 
            this.toolStripMenuItem_fontDecrease.Name = "toolStripMenuItem_fontDecrease";
            this.toolStripMenuItem_fontDecrease.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItem_fontDecrease.Tag = "FontDecrease";
            this.toolStripMenuItem_fontDecrease.Text = "Decrease Font";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // exchangeManagerControl
            // 
            this.exchangeManagerControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.exchangeManagerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.exchangeManagerControl.Location = new System.Drawing.Point(0, 39);
            this.exchangeManagerControl.Name = "exchangeManagerControl";
            this.exchangeManagerControl.Size = new System.Drawing.Size(494, 254);
            this.exchangeManagerControl.TabIndex = 6;
            // 
            // toolStripDropDownButton_websites
            // 
            this.toolStripDropDownButton_websites.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton_websites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_websites.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_websites.Image")));
            this.toolStripDropDownButton_websites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_websites.Name = "toolStripDropDownButton_websites";
            this.toolStripDropDownButton_websites.Size = new System.Drawing.Size(45, 36);
            this.toolStripDropDownButton_websites.Text = "Websites";
            // 
            // TwEXTraderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exchangeManagerControl);
            this.Controls.Add(this.toolStrip);
            this.Name = "TwEXTraderControl";
            this.Size = new System.Drawing.Size(494, 484);
            this.Load += new System.EventHandler(this.TwEXTraderControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_ExchangeEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Wallet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Balance;
        private System.Windows.Forms.ToolStripButton toolStripButton_Calculator;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LogManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ArbitrageManager;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_CoinMarketCap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_CryptoCompare;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EarnGG;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TradingView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_PreferenceManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private ExchangeManagerControl exchangeManagerControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_websites;
    }
}
