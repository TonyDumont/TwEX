namespace TwEX_API.Controls
{
    partial class PreferenceManagerControl
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
            this.exchangePreferenceEditorControl = new TwEX_API.Controls.ExchangePreferenceControl();
            this.formPreferenceEditorControl = new TwEX_API.Controls.FormPreferenceControl();
            this.preferenceEditorControl = new TwEX_API.Controls.PreferenceEditorControl();
            this.applicationPreferenceControl = new TwEX_API.Controls.ApplicationPreferenceControl();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.dbPreferenceControl = new TwEX_API.Controls.DBPreferenceControl();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.pictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.exchangePreferenceEditorControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.formPreferenceEditorControl, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.preferenceEditorControl, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.applicationPreferenceControl, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.dbPreferenceControl, 4, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(740, 440);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // exchangePreferenceEditorControl
            // 
            this.exchangePreferenceEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exchangePreferenceEditorControl.Location = new System.Drawing.Point(3, 133);
            this.exchangePreferenceEditorControl.Name = "exchangePreferenceEditorControl";
            this.exchangePreferenceEditorControl.Size = new System.Drawing.Size(125, 304);
            this.exchangePreferenceEditorControl.TabIndex = 0;
            // 
            // formPreferenceEditorControl
            // 
            this.formPreferenceEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPreferenceEditorControl.Location = new System.Drawing.Point(134, 133);
            this.formPreferenceEditorControl.Name = "formPreferenceEditorControl";
            this.formPreferenceEditorControl.Size = new System.Drawing.Size(73, 304);
            this.formPreferenceEditorControl.TabIndex = 0;
            // 
            // preferenceEditorControl
            // 
            this.preferenceEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preferenceEditorControl.Location = new System.Drawing.Point(213, 133);
            this.preferenceEditorControl.Name = "preferenceEditorControl";
            this.preferenceEditorControl.Size = new System.Drawing.Size(138, 304);
            this.preferenceEditorControl.TabIndex = 1;
            // 
            // applicationPreferenceControl
            // 
            this.applicationPreferenceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applicationPreferenceControl.Location = new System.Drawing.Point(357, 133);
            this.applicationPreferenceControl.Name = "applicationPreferenceControl";
            this.applicationPreferenceControl.Size = new System.Drawing.Size(130, 304);
            this.applicationPreferenceControl.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.tableLayoutPanel.SetColumnSpan(this.pictureBox, 5);
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Image = global::TwEX_API.Properties.Resources.TwEX_Header;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(734, 124);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // dbPreferenceControl
            // 
            this.dbPreferenceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbPreferenceControl.Location = new System.Drawing.Point(493, 133);
            this.dbPreferenceControl.Name = "dbPreferenceControl";
            this.dbPreferenceControl.Size = new System.Drawing.Size(244, 304);
            this.dbPreferenceControl.TabIndex = 3;
            // 
            // PreferenceManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(750, 350);
            this.Name = "PreferenceManagerControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(750, 450);
            this.Load += new System.EventHandler(this.PreferenceManagerControl_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox;
        private FormPreferenceControl formPreferenceEditorControl;
        private ExchangePreferenceControl exchangePreferenceEditorControl;
        private PreferenceEditorControl preferenceEditorControl;
        private ApplicationPreferenceControl applicationPreferenceControl;
        private DBPreferenceControl dbPreferenceControl;
    }
}
