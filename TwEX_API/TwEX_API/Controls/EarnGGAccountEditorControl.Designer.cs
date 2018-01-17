namespace TwEX_API.Controls
{
    partial class EarnGGAccountEditorControl
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label_key = new System.Windows.Forms.Label();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.label_secret = new System.Windows.Forms.Label();
            this.textBox_secret = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_value = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.listView, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label_key, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBox_key, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label_secret, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.textBox_secret, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.button_load, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.button_save, 0, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(459, 405);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // label_key
            // 
            this.label_key.AutoSize = true;
            this.label_key.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_key.Location = new System.Drawing.Point(3, 0);
            this.label_key.Name = "label_key";
            this.label_key.Size = new System.Drawing.Size(56, 26);
            this.label_key.TabIndex = 0;
            this.label_key.Text = "Api Key";
            this.label_key.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_key
            // 
            this.textBox_key.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_key.Location = new System.Drawing.Point(65, 3);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(391, 20);
            this.textBox_key.TabIndex = 1;
            // 
            // label_secret
            // 
            this.label_secret.AutoSize = true;
            this.label_secret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_secret.Location = new System.Drawing.Point(3, 26);
            this.label_secret.Name = "label_secret";
            this.label_secret.Size = new System.Drawing.Size(56, 26);
            this.label_secret.TabIndex = 2;
            this.label_secret.Text = "Api Secret";
            this.label_secret.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_secret
            // 
            this.textBox_secret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_secret.Location = new System.Drawing.Point(65, 29);
            this.textBox_secret.Name = "textBox_secret";
            this.textBox_secret.Size = new System.Drawing.Size(391, 20);
            this.textBox_secret.TabIndex = 3;
            // 
            // button_load
            // 
            this.tableLayoutPanel.SetColumnSpan(this.button_load, 2);
            this.button_load.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_load.Location = new System.Drawing.Point(3, 55);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(453, 23);
            this.button_load.TabIndex = 4;
            this.button_load.Text = "LOAD";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_save
            // 
            this.tableLayoutPanel.SetColumnSpan(this.button_save, 2);
            this.button_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_save.Location = new System.Drawing.Point(3, 379);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(453, 23);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "SAVE";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_name);
            this.listView.AllColumns.Add(this.column_value);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_name,
            this.column_value});
            this.tableLayoutPanel.SetColumnSpan(this.listView, 2);
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 84);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(453, 289);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 6;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            // 
            // column_name
            // 
            this.column_name.AspectName = "Name";
            this.column_name.MinimumWidth = 130;
            this.column_name.Text = "Name";
            this.column_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_name.Width = 130;
            // 
            // column_value
            // 
            this.column_value.AspectName = "Value";
            this.column_value.FillsFreeSpace = true;
            this.column_value.Text = "Value";
            // 
            // EarnGGAccountEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "EarnGGAccountEditorControl";
            this.Size = new System.Drawing.Size(459, 405);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label_key;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Label label_secret;
        private System.Windows.Forms.TextBox textBox_secret;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_save;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_name;
        private BrightIdeasSoftware.OLVColumn column_value;
    }
}
