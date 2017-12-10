namespace TwEX_API.Controls
{
    partial class TradingViewWidgetEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradingViewWidgetEditorControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.panel = new System.Windows.Forms.Panel();
            this.toolStripButton_test = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_test});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(771, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(771, 351);
            this.panel.TabIndex = 1;
            // 
            // toolStripButton_test
            // 
            this.toolStripButton_test.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_test.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_test.Image")));
            this.toolStripButton_test.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_test.Name = "toolStripButton_test";
            this.toolStripButton_test.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton_test.Text = "TEST";
            this.toolStripButton_test.Click += new System.EventHandler(this.toolStripButton_test_Click);
            // 
            // TradingViewWidgetEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStrip);
            this.Name = "TradingViewWidgetEditorControl";
            this.Size = new System.Drawing.Size(771, 376);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripButton toolStripButton_test;
    }
}
