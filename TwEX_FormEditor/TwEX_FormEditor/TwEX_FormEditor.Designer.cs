﻿namespace TwEX_FormEditor
{
    partial class TwEX_FormEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwEX_FormEditor));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_ExchangeEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Wallet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Balance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Calculator = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_export = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_import = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator_1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_LogManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator_2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ArbitrageManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_CryptoCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EarnGG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_CoinMarketCap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_TradingView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator_3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_ExchangeEditor,
            this.toolStripSeparator1,
            this.toolStripButton_Wallet,
            this.toolStripSeparator2,
            this.toolStripButton_Balance,
            this.toolStripSeparator3,
            this.toolStripButton_Calculator,
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator7});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(984, 39);
            this.toolStrip.TabIndex = 3;
            // 
            // toolStripButton_ExchangeEditor
            // 
            this.toolStripButton_ExchangeEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ExchangeEditor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ExchangeEditor.Image")));
            this.toolStripButton_ExchangeEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ExchangeEditor.Name = "toolStripButton_ExchangeEditor";
            this.toolStripButton_ExchangeEditor.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_ExchangeEditor.Tag = "ExchangeEditor";
            this.toolStripButton_ExchangeEditor.Text = "Exchange Manager";
            this.toolStripButton_ExchangeEditor.Click += new System.EventHandler(this.toolStripButton_Form_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
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
            this.toolStripButton_Wallet.Click += new System.EventHandler(this.toolStripButton_Form_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
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
            this.toolStripMenuItem_import,
            this.toolStripMenuItem_export});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(45, 36);
            this.toolStripDropDownButton_menu.Text = "MENU";
            this.toolStripDropDownButton_menu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_menu_DropDownItemClicked);
            // 
            // toolStripMenuItem_export
            // 
            this.toolStripMenuItem_export.Name = "toolStripMenuItem_export";
            this.toolStripMenuItem_export.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem_export.Tag = "ExportPreferences";
            this.toolStripMenuItem_export.Text = "Export Preferences";
            // 
            // toolStripMenuItem_import
            // 
            this.toolStripMenuItem_import.Name = "toolStripMenuItem_import";
            this.toolStripMenuItem_import.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem_import.Tag = "ImportPreferences";
            this.toolStripMenuItem_import.Text = "Import Preferences";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator_1
            // 
            this.toolStripSeparator_1.Name = "toolStripSeparator_1";
            this.toolStripSeparator_1.Size = new System.Drawing.Size(181, 6);
            // 
            // toolStripMenuItem_LogManager
            // 
            this.toolStripMenuItem_LogManager.Name = "toolStripMenuItem_LogManager";
            this.toolStripMenuItem_LogManager.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem_LogManager.Tag = "LogManager";
            this.toolStripMenuItem_LogManager.Text = "Log Manager";
            // 
            // toolStripSeparator_2
            // 
            this.toolStripSeparator_2.Name = "toolStripSeparator_2";
            this.toolStripSeparator_2.Size = new System.Drawing.Size(181, 6);
            // 
            // toolStripMenuItem_ArbitrageManager
            // 
            this.toolStripMenuItem_ArbitrageManager.Name = "toolStripMenuItem_ArbitrageManager";
            this.toolStripMenuItem_ArbitrageManager.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem_ArbitrageManager.Tag = "ArbitrageManager";
            this.toolStripMenuItem_ArbitrageManager.Text = "Arbitrage Manager";
            // 
            // toolStripMenuItem_CryptoCompare
            // 
            this.toolStripMenuItem_CryptoCompare.Name = "toolStripMenuItem_CryptoCompare";
            this.toolStripMenuItem_CryptoCompare.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem_CryptoCompare.Tag = "CryptoCompare";
            this.toolStripMenuItem_CryptoCompare.Text = "CryptoCompare";
            // 
            // toolStripMenuItem_EarnGG
            // 
            this.toolStripMenuItem_EarnGG.Name = "toolStripMenuItem_EarnGG";
            this.toolStripMenuItem_EarnGG.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem_EarnGG.Tag = "EarnGGManager";
            this.toolStripMenuItem_EarnGG.Text = "EarnGG Manager";
            // 
            // toolStripMenuItem_CoinMarketCap
            // 
            this.toolStripMenuItem_CoinMarketCap.Name = "toolStripMenuItem_CoinMarketCap";
            this.toolStripMenuItem_CoinMarketCap.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem_CoinMarketCap.Tag = "CoinMarketCap";
            this.toolStripMenuItem_CoinMarketCap.Text = "Coin Market Caps";
            // 
            // toolStripMenuItem_TradingView
            // 
            this.toolStripMenuItem_TradingView.Name = "toolStripMenuItem_TradingView";
            this.toolStripMenuItem_TradingView.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem_TradingView.Tag = "TradingView";
            this.toolStripMenuItem_TradingView.Text = "Trading View";
            // 
            // toolStripSeparator_3
            // 
            this.toolStripSeparator_3.Name = "toolStripSeparator_3";
            this.toolStripSeparator_3.Size = new System.Drawing.Size(181, 6);
            // 
            // TwEX_FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 40);
            this.Controls.Add(this.toolStrip);
            this.Name = "TwEX_FormEditor";
            this.Text = "TwEX Form Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TwEX_FormEditor_FormClosing);
            this.Load += new System.EventHandler(this.TwEX_FormEditor_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_ExchangeEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_Calculator;
        private System.Windows.Forms.ToolStripButton toolStripButton_Balance;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_export;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_import;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton_Wallet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LogManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ArbitrageManager;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_CryptoCompare;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EarnGG;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_CoinMarketCap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_TradingView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_3;
    }
}

