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
            this.logManagerControl = new TwEX_API.Controls.LogManagerControl();
            this.SuspendLayout();
            // 
            // logManagerControl
            // 
            this.logManagerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logManagerControl.Location = new System.Drawing.Point(0, 0);
            this.logManagerControl.Name = "logManagerControl";
            this.logManagerControl.Size = new System.Drawing.Size(892, 276);
            this.logManagerControl.TabIndex = 0;
            // 
            // TwEX_FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 276);
            this.Controls.Add(this.logManagerControl);
            this.Name = "TwEX_FormEditor";
            this.Text = "TwEX Form Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private TwEX_API.Controls.LogManagerControl logManagerControl;
    }
}

