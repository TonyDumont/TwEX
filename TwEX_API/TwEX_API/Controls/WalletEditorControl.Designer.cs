﻿namespace TwEX_API.Controls
{
    partial class WalletEditorControl
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label_Address = new System.Windows.Forms.Label();
            this.label_wallet = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Symbol = new System.Windows.Forms.Label();
            this.textBox_Symbol = new System.Windows.Forms.TextBox();
            this.label_Balance = new System.Windows.Forms.Label();
            this.label_Api = new System.Windows.Forms.Label();
            this.numericUpDown_Balance = new System.Windows.Forms.NumericUpDown();
            this.button_save = new System.Windows.Forms.Button();
            this.comboBox_wallet = new System.Windows.Forms.ComboBox();
            this.comboBox_api = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Balance)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.textBox_Address, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.label_Address, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label_wallet, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.textBox_Name, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label_Name, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label_Symbol, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBox_Symbol, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label_Balance, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.label_Api, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_Balance, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.button_save, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.comboBox_wallet, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.comboBox_api, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(271, 209);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Address.Location = new System.Drawing.Point(60, 87);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(203, 20);
            this.textBox_Address.TabIndex = 9;
            this.textBox_Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Address.Location = new System.Drawing.Point(8, 84);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(46, 26);
            this.label_Address.TabIndex = 8;
            this.label_Address.Text = "Address";
            this.label_Address.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_wallet
            // 
            this.label_wallet.AutoSize = true;
            this.label_wallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_wallet.Location = new System.Drawing.Point(8, 57);
            this.label_wallet.Name = "label_wallet";
            this.label_wallet.Size = new System.Drawing.Size(46, 27);
            this.label_wallet.TabIndex = 6;
            this.label_wallet.Text = "Wallet";
            this.label_wallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Name.Location = new System.Drawing.Point(60, 34);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(203, 20);
            this.textBox_Name.TabIndex = 5;
            this.textBox_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Name.Location = new System.Drawing.Point(8, 31);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(46, 26);
            this.label_Name.TabIndex = 2;
            this.label_Name.Text = "Name";
            this.label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Symbol
            // 
            this.label_Symbol.AutoSize = true;
            this.label_Symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Symbol.Location = new System.Drawing.Point(8, 5);
            this.label_Symbol.Name = "label_Symbol";
            this.label_Symbol.Size = new System.Drawing.Size(46, 26);
            this.label_Symbol.TabIndex = 0;
            this.label_Symbol.Text = "Symbol";
            this.label_Symbol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_Symbol
            // 
            this.textBox_Symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Symbol.Location = new System.Drawing.Point(60, 8);
            this.textBox_Symbol.Name = "textBox_Symbol";
            this.textBox_Symbol.Size = new System.Drawing.Size(203, 20);
            this.textBox_Symbol.TabIndex = 4;
            this.textBox_Symbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Balance
            // 
            this.label_Balance.AutoSize = true;
            this.label_Balance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Balance.Location = new System.Drawing.Point(8, 110);
            this.label_Balance.Name = "label_Balance";
            this.label_Balance.Size = new System.Drawing.Size(46, 26);
            this.label_Balance.TabIndex = 13;
            this.label_Balance.Text = "Balance";
            this.label_Balance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Api
            // 
            this.label_Api.AutoSize = true;
            this.label_Api.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Api.Location = new System.Drawing.Point(8, 136);
            this.label_Api.Name = "label_Api";
            this.label_Api.Size = new System.Drawing.Size(46, 27);
            this.label_Api.TabIndex = 14;
            this.label_Api.Text = "API";
            this.label_Api.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_Balance
            // 
            this.numericUpDown_Balance.DecimalPlaces = 8;
            this.numericUpDown_Balance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_Balance.Location = new System.Drawing.Point(60, 113);
            this.numericUpDown_Balance.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown_Balance.Name = "numericUpDown_Balance";
            this.numericUpDown_Balance.Size = new System.Drawing.Size(203, 20);
            this.numericUpDown_Balance.TabIndex = 15;
            this.numericUpDown_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_save
            // 
            this.button_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_save.Location = new System.Drawing.Point(60, 166);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(203, 37);
            this.button_save.TabIndex = 17;
            this.button_save.Text = "SAVE";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // comboBox_wallet
            // 
            this.comboBox_wallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_wallet.FormattingEnabled = true;
            this.comboBox_wallet.Items.AddRange(new object[] {
            "Armory",
            "BlockIO",
            "Coinomi",
            "CoinPot",
            "CounterWallet",
            "Electrum",
            "Exodus",
            "FreeBitcoin",
            "Ledger",
            "MinerGate",
            "WPN"});
            this.comboBox_wallet.Location = new System.Drawing.Point(60, 60);
            this.comboBox_wallet.Name = "comboBox_wallet";
            this.comboBox_wallet.Size = new System.Drawing.Size(203, 21);
            this.comboBox_wallet.TabIndex = 18;
            // 
            // comboBox_api
            // 
            this.comboBox_api.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_api.FormattingEnabled = true;
            this.comboBox_api.Items.AddRange(new object[] {
            "BlockCypher (BTC/LTC/DOGE/DASH/ETH)",
            "BlockTrail (BTC/BCH)"});
            this.comboBox_api.Location = new System.Drawing.Point(60, 139);
            this.comboBox_api.Name = "comboBox_api";
            this.comboBox_api.Size = new System.Drawing.Size(203, 21);
            this.comboBox_api.TabIndex = 19;
            // 
            // WalletEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "WalletEditorControl";
            this.Size = new System.Drawing.Size(271, 209);
            this.Load += new System.EventHandler(this.WalletEditorControl_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Balance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Symbol;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Symbol;
        private System.Windows.Forms.Label label_wallet;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.Label label_Balance;
        private System.Windows.Forms.Label label_Api;
        private System.Windows.Forms.NumericUpDown numericUpDown_Balance;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.ComboBox comboBox_wallet;
        private System.Windows.Forms.ComboBox comboBox_api;
    }
}
