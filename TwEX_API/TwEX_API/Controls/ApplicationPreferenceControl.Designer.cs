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
            this.checkBox_font = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.button_font = new System.Windows.Forms.Button();
            this.label_sample = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_font
            // 
            this.checkBox_font.AutoSize = true;
            this.checkBox_font.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_font.Location = new System.Drawing.Point(3, 18);
            this.checkBox_font.Name = "checkBox_font";
            this.checkBox_font.Size = new System.Drawing.Size(124, 17);
            this.checkBox_font.TabIndex = 0;
            this.checkBox_font.Text = "Use Global Font";
            this.checkBox_font.UseVisualStyleBackColor = true;
            this.checkBox_font.CheckedChanged += new System.EventHandler(this.checkBox_font_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label_sample);
            this.groupBox.Controls.Add(this.button_font);
            this.groupBox.Controls.Add(this.checkBox_font);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox.Size = new System.Drawing.Size(130, 304);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Application Settings";
            // 
            // button_font
            // 
            this.button_font.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_font.Location = new System.Drawing.Point(3, 35);
            this.button_font.Name = "button_font";
            this.button_font.Size = new System.Drawing.Size(124, 23);
            this.button_font.TabIndex = 1;
            this.button_font.Text = "Change Font";
            this.button_font.UseVisualStyleBackColor = true;
            this.button_font.Click += new System.EventHandler(this.button_font_Click);
            // 
            // label_sample
            // 
            this.label_sample.AutoSize = true;
            this.label_sample.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_sample.Location = new System.Drawing.Point(3, 58);
            this.label_sample.Name = "label_sample";
            this.label_sample.Size = new System.Drawing.Size(66, 13);
            this.label_sample.TabIndex = 2;
            this.label_sample.Text = "Sample Text";
            this.label_sample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationPreferenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "ApplicationPreferenceControl";
            this.Size = new System.Drawing.Size(130, 304);
            this.Load += new System.EventHandler(this.ApplicationPreferenceControl_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_font;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button button_font;
        private System.Windows.Forms.Label label_sample;
    }
}
