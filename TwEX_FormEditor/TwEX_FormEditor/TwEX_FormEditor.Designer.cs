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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logManagerControl = new TwEX_API.Controls.LogManagerControl();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_CCWidgetEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_TVWidgetEditor = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.logManagerControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.toolStrip, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(858, 355);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // logManagerControl
            // 
            this.logManagerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logManagerControl.Location = new System.Drawing.Point(3, 33);
            this.logManagerControl.Name = "logManagerControl";
            this.logManagerControl.Size = new System.Drawing.Size(852, 319);
            this.logManagerControl.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_CCWidgetEditor,
            this.toolStripSeparator1,
            this.toolStripButton_TVWidgetEditor});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(858, 30);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton_CCWidgetEditor
            // 
            this.toolStripButton_CCWidgetEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_CCWidgetEditor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_CCWidgetEditor.Image")));
            this.toolStripButton_CCWidgetEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CCWidgetEditor.Name = "toolStripButton_CCWidgetEditor";
            this.toolStripButton_CCWidgetEditor.Size = new System.Drawing.Size(171, 27);
            this.toolStripButton_CCWidgetEditor.Text = "CryptoCompare Widget Editor";
            this.toolStripButton_CCWidgetEditor.Click += new System.EventHandler(this.toolStripButton_CCWidgetEditor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton_TVWidgetEditor
            // 
            this.toolStripButton_TVWidgetEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_TVWidgetEditor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_TVWidgetEditor.Image")));
            this.toolStripButton_TVWidgetEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_TVWidgetEditor.Name = "toolStripButton_TVWidgetEditor";
            this.toolStripButton_TVWidgetEditor.Size = new System.Drawing.Size(151, 27);
            this.toolStripButton_TVWidgetEditor.Text = "TradingView Widget Editor";
            this.toolStripButton_TVWidgetEditor.Click += new System.EventHandler(this.toolStripButton_TVWidgetEditor_Click);
            // 
            // TwEX_FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 355);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "TwEX_FormEditor";
            this.Text = "TwEX Form Editor";
            this.Load += new System.EventHandler(this.TwEX_FormEditor_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TwEX_API.Controls.LogManagerControl logManagerControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_CCWidgetEditor;
        private System.Windows.Forms.ToolStripButton toolStripButton_TVWidgetEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

