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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.exchangePreferenceEditorControl1 = new TwEX_API.Controls.ExchangePreferenceControl();
            this.formPreferenceEditorControl1 = new TwEX_API.Controls.FormPreferenceControl();
            this.preferenceEditorControl = new TwEX_API.Controls.PreferenceEditorControl();
            this.applicationPreferenceControl1 = new TwEX_API.Controls.ApplicationPreferenceControl();
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
            this.tableLayoutPanel.Controls.Add(this.exchangePreferenceEditorControl1, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.formPreferenceEditorControl1, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.preferenceEditorControl, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.applicationPreferenceControl1, 3, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(750, 450);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel.SetColumnSpan(this.pictureBox, 5);
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Image = global::TwEX_API.Properties.Resources.TwEX_Header;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(744, 124);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // exchangePreferenceEditorControl1
            // 
            this.exchangePreferenceEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exchangePreferenceEditorControl1.Location = new System.Drawing.Point(3, 133);
            this.exchangePreferenceEditorControl1.Name = "exchangePreferenceEditorControl1";
            this.exchangePreferenceEditorControl1.Size = new System.Drawing.Size(125, 314);
            this.exchangePreferenceEditorControl1.TabIndex = 0;
            // 
            // formPreferenceEditorControl1
            // 
            this.formPreferenceEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPreferenceEditorControl1.Location = new System.Drawing.Point(134, 133);
            this.formPreferenceEditorControl1.Name = "formPreferenceEditorControl1";
            this.formPreferenceEditorControl1.Size = new System.Drawing.Size(138, 314);
            this.formPreferenceEditorControl1.TabIndex = 0;
            // 
            // preferenceEditorControl
            // 
            this.preferenceEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preferenceEditorControl.Location = new System.Drawing.Point(278, 133);
            this.preferenceEditorControl.Name = "preferenceEditorControl";
            this.preferenceEditorControl.Size = new System.Drawing.Size(122, 314);
            this.preferenceEditorControl.TabIndex = 1;
            // 
            // applicationPreferenceControl1
            // 
            this.applicationPreferenceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applicationPreferenceControl1.Location = new System.Drawing.Point(406, 133);
            this.applicationPreferenceControl1.Name = "applicationPreferenceControl1";
            this.applicationPreferenceControl1.Size = new System.Drawing.Size(130, 314);
            this.applicationPreferenceControl1.TabIndex = 2;
            // 
            // PreferenceManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(750, 0);
            this.Name = "PreferenceManagerControl";
            this.Size = new System.Drawing.Size(750, 450);
            this.Load += new System.EventHandler(this.PreferenceManagerControl_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox;
        private FormPreferenceControl formPreferenceEditorControl1;
        private ExchangePreferenceControl exchangePreferenceEditorControl1;
        private PreferenceEditorControl preferenceEditorControl;
        private ApplicationPreferenceControl applicationPreferenceControl1;
    }
}
