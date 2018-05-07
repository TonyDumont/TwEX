namespace TwEX_API.Controls
{
    partial class DBPreferenceControl
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_UseDB = new System.Windows.Forms.CheckBox();
            this.label_DBSource = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DBSource = new System.Windows.Forms.TextBox();
            this.textBox_DBName = new System.Windows.Forms.TextBox();
            this.textBox_DBID = new System.Windows.Forms.TextBox();
            this.textBox_DBPassword = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.tableLayoutPanel);
            this.groupBox.Controls.Add(this.checkBox_UseDB);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(239, 358);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Database";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.textBox_DBPassword, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.textBox_DBID, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.textBox_DBName, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label_DBSource, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.textBox_DBSource, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.button_save, 0, 8);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 10;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(233, 322);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // checkBox_UseDB
            // 
            this.checkBox_UseDB.AutoSize = true;
            this.checkBox_UseDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_UseDB.Location = new System.Drawing.Point(3, 16);
            this.checkBox_UseDB.Name = "checkBox_UseDB";
            this.checkBox_UseDB.Size = new System.Drawing.Size(233, 17);
            this.checkBox_UseDB.TabIndex = 0;
            this.checkBox_UseDB.Text = "Use Database";
            this.checkBox_UseDB.UseVisualStyleBackColor = true;
            this.checkBox_UseDB.Click += new System.EventHandler(this.checkBox_UseDB_Click);
            // 
            // label_DBSource
            // 
            this.label_DBSource.AutoSize = true;
            this.label_DBSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DBSource.Location = new System.Drawing.Point(5, 2);
            this.label_DBSource.Name = "label_DBSource";
            this.label_DBSource.Size = new System.Drawing.Size(223, 13);
            this.label_DBSource.TabIndex = 1;
            this.label_DBSource.Text = "Server Address:";
            this.label_DBSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // textBox_DBSource
            // 
            this.textBox_DBSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DBSource.Location = new System.Drawing.Point(5, 20);
            this.textBox_DBSource.Name = "textBox_DBSource";
            this.textBox_DBSource.Size = new System.Drawing.Size(223, 20);
            this.textBox_DBSource.TabIndex = 6;
            // 
            // textBox_DBName
            // 
            this.textBox_DBName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DBName.Location = new System.Drawing.Point(5, 63);
            this.textBox_DBName.Name = "textBox_DBName";
            this.textBox_DBName.Size = new System.Drawing.Size(223, 20);
            this.textBox_DBName.TabIndex = 7;
            // 
            // textBox_DBID
            // 
            this.textBox_DBID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DBID.Location = new System.Drawing.Point(5, 106);
            this.textBox_DBID.Name = "textBox_DBID";
            this.textBox_DBID.Size = new System.Drawing.Size(223, 20);
            this.textBox_DBID.TabIndex = 8;
            // 
            // textBox_DBPassword
            // 
            this.textBox_DBPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DBPassword.Location = new System.Drawing.Point(5, 149);
            this.textBox_DBPassword.Name = "textBox_DBPassword";
            this.textBox_DBPassword.Size = new System.Drawing.Size(223, 20);
            this.textBox_DBPassword.TabIndex = 9;
            // 
            // button_save
            // 
            this.button_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_save.Location = new System.Drawing.Point(5, 177);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(223, 23);
            this.button_save.TabIndex = 10;
            this.button_save.Text = "Save DB Settings";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // DBPreferenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "DBPreferenceControl";
            this.Size = new System.Drawing.Size(239, 358);
            this.Load += new System.EventHandler(this.DBPreferenceControl_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.CheckBox checkBox_UseDB;
        private System.Windows.Forms.Label label_DBSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_DBPassword;
        private System.Windows.Forms.TextBox textBox_DBID;
        private System.Windows.Forms.TextBox textBox_DBName;
        private System.Windows.Forms.TextBox textBox_DBSource;
        private System.Windows.Forms.Button button_save;
    }
}
