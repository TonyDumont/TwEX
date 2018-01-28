namespace TwEX_FormEditor
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
            this.twEXTraderControl = new TwEX_API.Controls.TwEXTraderControl();
            this.walletManagerControl = new TwEX_API.Controls.WalletManagerControl();
            this.earnGGManagerControl = new TwEX_API.Controls.EarnGGManagerControl();
            this.SuspendLayout();
            // 
            // twEXTraderControl
            // 
            this.twEXTraderControl.AutoSize = true;
            this.twEXTraderControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.twEXTraderControl.Location = new System.Drawing.Point(0, 0);
            this.twEXTraderControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.twEXTraderControl.Name = "twEXTraderControl";
            this.twEXTraderControl.Size = new System.Drawing.Size(579, 410);
            this.twEXTraderControl.TabIndex = 0;
            // 
            // walletManagerControl
            // 
            this.walletManagerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.walletManagerControl.Location = new System.Drawing.Point(0, 410);
            this.walletManagerControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.walletManagerControl.Name = "walletManagerControl";
            this.walletManagerControl.Size = new System.Drawing.Size(579, 135);
            this.walletManagerControl.TabIndex = 1;
            // 
            // earnGGManagerControl
            // 
            this.earnGGManagerControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.earnGGManagerControl.Location = new System.Drawing.Point(0, 478);
            this.earnGGManagerControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.earnGGManagerControl.Name = "earnGGManagerControl";
            this.earnGGManagerControl.Size = new System.Drawing.Size(579, 67);
            this.earnGGManagerControl.TabIndex = 2;
            // 
            // TwEX_FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 545);
            this.Controls.Add(this.earnGGManagerControl);
            this.Controls.Add(this.walletManagerControl);
            this.Controls.Add(this.twEXTraderControl);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(5992, 5828);
            this.MinimumSize = new System.Drawing.Size(517, 39);
            this.Name = "TwEX_FormEditor";
            this.Text = "TwEX Trader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TwEX_FormEditor_FormClosing);
            this.Load += new System.EventHandler(this.TwEX_FormEditor_Load);
            this.Shown += new System.EventHandler(this.TwEX_FormEditor_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TwEX_API.Controls.TwEXTraderControl twEXTraderControl;
        private TwEX_API.Controls.WalletManagerControl walletManagerControl;
        private TwEX_API.Controls.EarnGGManagerControl earnGGManagerControl;
    }
}

