namespace TwEX_API.Controls
{
    partial class LogManagerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogManagerControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_update = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_title = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataListView = new BrightIdeasSoftware.DataListView();
            this.column_TimeStamp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Source = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_FunctionCall = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_message = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_update,
            this.toolStripSeparator1,
            this.toolStripLabel_title});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(688, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton_update
            // 
            this.toolStripButton_update.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_update.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_update.Image")));
            this.toolStripButton_update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_update.Name = "toolStripButton_update";
            this.toolStripButton_update.Size = new System.Drawing.Size(54, 22);
            this.toolStripButton_update.Text = "UPDATE";
            // 
            // toolStripLabel_title
            // 
            this.toolStripLabel_title.Name = "toolStripLabel_title";
            this.toolStripLabel_title.Size = new System.Drawing.Size(73, 22);
            this.toolStripLabel_title.Text = "Debugger(0)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dataListView
            // 
            this.dataListView.AllColumns.Add(this.column_TimeStamp);
            this.dataListView.AllColumns.Add(this.column_type);
            this.dataListView.AllColumns.Add(this.column_Source);
            this.dataListView.AllColumns.Add(this.column_FunctionCall);
            this.dataListView.AllColumns.Add(this.column_message);
            this.dataListView.CellEditUseWholeCell = false;
            this.dataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_TimeStamp,
            this.column_type,
            this.column_Source,
            this.column_FunctionCall,
            this.column_message});
            this.dataListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataListView.DataSource = null;
            this.dataListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListView.GridLines = true;
            this.dataListView.Location = new System.Drawing.Point(0, 25);
            this.dataListView.Name = "dataListView";
            this.dataListView.Size = new System.Drawing.Size(688, 301);
            this.dataListView.TabIndex = 1;
            this.dataListView.UseCompatibleStateImageBehavior = false;
            this.dataListView.View = System.Windows.Forms.View.Details;
            // 
            // column_TimeStamp
            // 
            this.column_TimeStamp.MinimumWidth = 120;
            this.column_TimeStamp.Text = "Time Stamp";
            this.column_TimeStamp.Width = 120;
            // 
            // column_type
            // 
            this.column_type.MinimumWidth = 90;
            this.column_type.Text = "Type";
            this.column_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_type.Width = 90;
            // 
            // column_Source
            // 
            this.column_Source.Text = "Source";
            this.column_Source.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_FunctionCall
            // 
            this.column_FunctionCall.MinimumWidth = 90;
            this.column_FunctionCall.Text = "Function Call";
            this.column_FunctionCall.Width = 90;
            // 
            // column_message
            // 
            this.column_message.FillsFreeSpace = true;
            this.column_message.Text = "Message";
            // 
            // LogManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataListView);
            this.Controls.Add(this.toolStrip);
            this.Name = "LogManagerControl";
            this.Size = new System.Drawing.Size(688, 326);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_update;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_title;
        private BrightIdeasSoftware.DataListView dataListView;
        private BrightIdeasSoftware.OLVColumn column_TimeStamp;
        private BrightIdeasSoftware.OLVColumn column_type;
        private BrightIdeasSoftware.OLVColumn column_Source;
        private BrightIdeasSoftware.OLVColumn column_FunctionCall;
        private BrightIdeasSoftware.OLVColumn column_message;
    }
}
