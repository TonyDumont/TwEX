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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.logManagerControl = new TwEX_API.Controls.LogManagerControl();
            this.cryptoCompareWidgetControl = new TwEX_API.Controls.CryptoCompareWidgetControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.logManagerControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cryptoCompareWidgetControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 355F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1255, 355);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // logManagerControl
            // 
            this.logManagerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logManagerControl.Location = new System.Drawing.Point(3, 3);
            this.logManagerControl.Name = "logManagerControl";
            this.logManagerControl.Size = new System.Drawing.Size(621, 349);
            this.logManagerControl.TabIndex = 0;
            // 
            // cryptoCompareWidgetControl
            // 
            this.cryptoCompareWidgetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryptoCompareWidgetControl.Location = new System.Drawing.Point(630, 3);
            this.cryptoCompareWidgetControl.Name = "cryptoCompareWidgetControl";
            this.cryptoCompareWidgetControl.Size = new System.Drawing.Size(622, 349);
            this.cryptoCompareWidgetControl.TabIndex = 1;
            // 
            // TwEX_FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 355);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TwEX_FormEditor";
            this.Text = "TwEX Form Editor";
            this.Load += new System.EventHandler(this.TwEX_FormEditor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TwEX_API.Controls.LogManagerControl logManagerControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TwEX_API.Controls.CryptoCompareWidgetControl cryptoCompareWidgetControl;
    }
}

