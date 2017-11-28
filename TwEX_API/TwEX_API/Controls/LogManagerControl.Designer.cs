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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_title = new System.Windows.Forms.ToolStripLabel();
            this.listView = new BrightIdeasSoftware.DataListView();
            this.column_TimeStamp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Source = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_FunctionCall = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_Message = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.textBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_key = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_key = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_secret = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_secret = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_update,
            this.toolStripSeparator1,
            this.toolStripLabel_title,
            this.toolStripSeparator2,
            this.toolStripLabel_key,
            this.toolStripTextBox_key,
            this.toolStripSeparator3,
            this.toolStripLabel_secret,
            this.toolStripTextBox_secret});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(976, 25);
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
            this.toolStripButton_update.Click += new System.EventHandler(this.toolStripButton_update_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_title
            // 
            this.toolStripLabel_title.Name = "toolStripLabel_title";
            this.toolStripLabel_title.Size = new System.Drawing.Size(73, 22);
            this.toolStripLabel_title.Text = "Debugger(0)";
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_TimeStamp);
            this.listView.AllColumns.Add(this.column_type);
            this.listView.AllColumns.Add(this.column_Source);
            this.listView.AllColumns.Add(this.column_FunctionCall);
            this.listView.AllColumns.Add(this.column_Message);
            this.listView.AutoGenerateColumns = false;
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_TimeStamp,
            this.column_type,
            this.column_Source,
            this.column_FunctionCall,
            this.column_Message});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.DataSource = null;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 3);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(970, 235);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 1;
            this.listView.UseAlternatingBackColors = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectionChanged += new System.EventHandler(this.listView_SelectionChanged);
            // 
            // column_TimeStamp
            // 
            this.column_TimeStamp.AspectName = "TimeStamp";
            this.column_TimeStamp.MinimumWidth = 130;
            this.column_TimeStamp.Text = "Time Stamp";
            this.column_TimeStamp.Width = 130;
            // 
            // column_type
            // 
            this.column_type.AspectName = "type";
            this.column_type.MinimumWidth = 100;
            this.column_type.Text = "Type";
            this.column_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_type.Width = 100;
            // 
            // column_Source
            // 
            this.column_Source.AspectName = "Source";
            this.column_Source.MinimumWidth = 100;
            this.column_Source.Text = "Source";
            this.column_Source.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_Source.Width = 100;
            // 
            // column_FunctionCall
            // 
            this.column_FunctionCall.AspectName = "FunctionCall";
            this.column_FunctionCall.MinimumWidth = 100;
            this.column_FunctionCall.Text = "Function Call";
            this.column_FunctionCall.Width = 100;
            // 
            // column_Message
            // 
            this.column_Message.AspectName = "Message";
            this.column_Message.FillsFreeSpace = true;
            this.column_Message.Text = "Message";
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(3, 244);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(970, 54);
            this.textBox.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.listView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 301);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_key
            // 
            this.toolStripLabel_key.Name = "toolStripLabel_key";
            this.toolStripLabel_key.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel_key.Text = "Key:";
            // 
            // toolStripTextBox_key
            // 
            this.toolStripTextBox_key.AutoSize = false;
            this.toolStripTextBox_key.Name = "toolStripTextBox_key";
            this.toolStripTextBox_key.Size = new System.Drawing.Size(250, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_secret
            // 
            this.toolStripLabel_secret.Name = "toolStripLabel_secret";
            this.toolStripLabel_secret.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel_secret.Text = "Secret:";
            // 
            // toolStripTextBox_secret
            // 
            this.toolStripTextBox_secret.Name = "toolStripTextBox_secret";
            this.toolStripTextBox_secret.Size = new System.Drawing.Size(250, 25);
            // 
            // LogManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip);
            this.Name = "LogManagerControl";
            this.Size = new System.Drawing.Size(976, 326);
            this.Load += new System.EventHandler(this.LogManagerControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_update;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_title;
        private BrightIdeasSoftware.DataListView listView;
        private BrightIdeasSoftware.OLVColumn column_TimeStamp;
        private BrightIdeasSoftware.OLVColumn column_type;
        private BrightIdeasSoftware.OLVColumn column_Source;
        private BrightIdeasSoftware.OLVColumn column_FunctionCall;
        private BrightIdeasSoftware.OLVColumn column_Message;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_key;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_key;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_secret;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_secret;
    }
}
