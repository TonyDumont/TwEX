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
            this.toolStripDropDownButton_widget = new System.Windows.Forms.ToolStripDropDownButton();
            this.panel = new System.Windows.Forms.Panel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_widget});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(771, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton_widget
            // 
            this.toolStripDropDownButton_widget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_widget.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_widget.Image")));
            this.toolStripDropDownButton_widget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_widget.Name = "toolStripDropDownButton_widget";
            this.toolStripDropDownButton_widget.Size = new System.Drawing.Size(103, 22);
            this.toolStripDropDownButton_widget.Text = "Select A Widget";
            this.toolStripDropDownButton_widget.ToolTipText = "Select A Widget";
            this.toolStripDropDownButton_widget.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_widget_DropDownItemClicked);
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(771, 351);
            this.panel.TabIndex = 1;
            // 
            // TradingViewWidgetEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStrip);
            this.Name = "TradingViewWidgetEditorControl";
            this.Size = new System.Drawing.Size(771, 376);
            this.Load += new System.EventHandler(this.TradingViewWidgetEditorControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_widget;
    }
}
