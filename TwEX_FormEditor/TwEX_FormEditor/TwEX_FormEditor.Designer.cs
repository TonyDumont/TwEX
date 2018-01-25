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
            this.formToolStripControl = new TwEX_API.Controls.FormToolStripControl();
            this.SuspendLayout();
            // 
            // formToolStripControl
            // 
            this.formToolStripControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formToolStripControl.Location = new System.Drawing.Point(0, 0);
            this.formToolStripControl.Name = "formToolStripControl";
            this.formToolStripControl.Size = new System.Drawing.Size(334, 41);
            this.formToolStripControl.TabIndex = 0;
            // 
            // TwEX_FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 41);
            this.Controls.Add(this.formToolStripControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.MinimumSize = new System.Drawing.Size(350, 20);
            this.Name = "TwEX_FormEditor";
            this.Text = "TwEX Form Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TwEX_FormEditor_FormClosing);
            this.Load += new System.EventHandler(this.TwEX_FormEditor_Load);
            this.Shown += new System.EventHandler(this.TwEX_FormEditor_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private TwEX_API.Controls.FormToolStripControl formToolStripControl;
    }
}

