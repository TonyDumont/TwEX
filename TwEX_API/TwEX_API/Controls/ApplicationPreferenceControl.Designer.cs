namespace TwEX_API.Controls
{
    partial class ApplicationPreferenceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationPreferenceControl));
            this.checkBox_font = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox_theme = new System.Windows.Forms.GroupBox();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_Name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.button_SetTheme = new System.Windows.Forms.Button();
            this.checkBox_AlternatingColors = new System.Windows.Forms.CheckBox();
            this.checkBox_GridLines = new System.Windows.Forms.CheckBox();
            this.button_font = new System.Windows.Forms.Button();
            this.toolStrip_footer = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_FlushData = new System.Windows.Forms.ToolStripButton();
            this.groupBox.SuspendLayout();
            this.groupBox_theme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.toolStrip_footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_font
            // 
            this.checkBox_font.AutoSize = true;
            this.checkBox_font.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_font.Location = new System.Drawing.Point(5, 18);
            this.checkBox_font.Name = "checkBox_font";
            this.checkBox_font.Padding = new System.Windows.Forms.Padding(5);
            this.checkBox_font.Size = new System.Drawing.Size(150, 27);
            this.checkBox_font.TabIndex = 0;
            this.checkBox_font.Text = "Use Global Font";
            this.checkBox_font.UseVisualStyleBackColor = true;
            this.checkBox_font.CheckedChanged += new System.EventHandler(this.checkBox_font_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.groupBox_theme);
            this.groupBox.Controls.Add(this.toolStrip_footer);
            this.groupBox.Controls.Add(this.checkBox_AlternatingColors);
            this.groupBox.Controls.Add(this.checkBox_GridLines);
            this.groupBox.Controls.Add(this.button_font);
            this.groupBox.Controls.Add(this.checkBox_font);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox.Size = new System.Drawing.Size(160, 356);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Application Settings";
            // 
            // groupBox_theme
            // 
            this.groupBox_theme.Controls.Add(this.listView);
            this.groupBox_theme.Controls.Add(this.button_SetTheme);
            this.groupBox_theme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_theme.Location = new System.Drawing.Point(5, 122);
            this.groupBox_theme.Name = "groupBox_theme";
            this.groupBox_theme.Size = new System.Drawing.Size(150, 204);
            this.groupBox_theme.TabIndex = 2;
            this.groupBox_theme.TabStop = false;
            this.groupBox_theme.Text = "Theme";
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_Name);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Name});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 16);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectColumnsOnRightClick = false;
            this.listView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView.ShowFilterMenuOnRightClick = false;
            this.listView.ShowGroups = false;
            this.listView.ShowImagesOnSubItems = true;
            this.listView.Size = new System.Drawing.Size(144, 162);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 6;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // column_Name
            // 
            this.column_Name.AspectName = "Name";
            this.column_Name.FillsFreeSpace = true;
            this.column_Name.MinimumWidth = 100;
            this.column_Name.Text = "Name";
            this.column_Name.Width = 100;
            // 
            // button_SetTheme
            // 
            this.button_SetTheme.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_SetTheme.Location = new System.Drawing.Point(3, 178);
            this.button_SetTheme.Name = "button_SetTheme";
            this.button_SetTheme.Size = new System.Drawing.Size(144, 23);
            this.button_SetTheme.TabIndex = 7;
            this.button_SetTheme.Text = "Set Theme";
            this.button_SetTheme.UseVisualStyleBackColor = true;
            this.button_SetTheme.Click += new System.EventHandler(this.button_SetTheme_Click);
            // 
            // checkBox_AlternatingColors
            // 
            this.checkBox_AlternatingColors.AutoSize = true;
            this.checkBox_AlternatingColors.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_AlternatingColors.Location = new System.Drawing.Point(5, 95);
            this.checkBox_AlternatingColors.Name = "checkBox_AlternatingColors";
            this.checkBox_AlternatingColors.Padding = new System.Windows.Forms.Padding(5);
            this.checkBox_AlternatingColors.Size = new System.Drawing.Size(150, 27);
            this.checkBox_AlternatingColors.TabIndex = 4;
            this.checkBox_AlternatingColors.Text = "Alternating Row Colors";
            this.checkBox_AlternatingColors.UseVisualStyleBackColor = true;
            this.checkBox_AlternatingColors.CheckedChanged += new System.EventHandler(this.checkBox_AlternatingColors_CheckedChanged);
            // 
            // checkBox_GridLines
            // 
            this.checkBox_GridLines.AutoSize = true;
            this.checkBox_GridLines.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_GridLines.Location = new System.Drawing.Point(5, 68);
            this.checkBox_GridLines.Name = "checkBox_GridLines";
            this.checkBox_GridLines.Padding = new System.Windows.Forms.Padding(5);
            this.checkBox_GridLines.Size = new System.Drawing.Size(150, 27);
            this.checkBox_GridLines.TabIndex = 3;
            this.checkBox_GridLines.Text = "Show Grid Lines";
            this.checkBox_GridLines.UseVisualStyleBackColor = true;
            this.checkBox_GridLines.CheckedChanged += new System.EventHandler(this.checkBox_GridLines_CheckedChanged);
            // 
            // button_font
            // 
            this.button_font.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_font.Location = new System.Drawing.Point(5, 45);
            this.button_font.Name = "button_font";
            this.button_font.Size = new System.Drawing.Size(150, 23);
            this.button_font.TabIndex = 1;
            this.button_font.Text = "Change Font";
            this.button_font.UseVisualStyleBackColor = true;
            this.button_font.Click += new System.EventHandler(this.button_font_Click);
            // 
            // toolStrip_footer
            // 
            this.toolStrip_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_FlushData});
            this.toolStrip_footer.Location = new System.Drawing.Point(5, 326);
            this.toolStrip_footer.Name = "toolStrip_footer";
            this.toolStrip_footer.Size = new System.Drawing.Size(150, 25);
            this.toolStrip_footer.TabIndex = 5;
            this.toolStrip_footer.Text = "toolStrip1";
            // 
            // toolStripButton_FlushData
            // 
            this.toolStripButton_FlushData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_FlushData.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_FlushData.Image")));
            this.toolStripButton_FlushData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FlushData.Name = "toolStripButton_FlushData";
            this.toolStripButton_FlushData.Size = new System.Drawing.Size(66, 22);
            this.toolStripButton_FlushData.Text = "Flush Data";
            this.toolStripButton_FlushData.Click += new System.EventHandler(this.toolStripButton_FlushData_Click);
            // 
            // ApplicationPreferenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "ApplicationPreferenceControl";
            this.Size = new System.Drawing.Size(160, 356);
            this.Load += new System.EventHandler(this.ApplicationPreferenceControl_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox_theme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.toolStrip_footer.ResumeLayout(false);
            this.toolStrip_footer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_font;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button button_font;
        private System.Windows.Forms.GroupBox groupBox_theme;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_Name;
        private System.Windows.Forms.Button button_SetTheme;
        private System.Windows.Forms.CheckBox checkBox_GridLines;
        private System.Windows.Forms.CheckBox checkBox_AlternatingColors;
        private System.Windows.Forms.ToolStrip toolStrip_footer;
        private System.Windows.Forms.ToolStripButton toolStripButton_FlushData;
    }
}
