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
            this.groupBox_theme = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_theme = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton_default = new System.Windows.Forms.RadioButton();
            this.radioButton_dark = new System.Windows.Forms.RadioButton();
            this.groupBox.SuspendLayout();
            this.groupBox_theme.SuspendLayout();
            this.flowLayoutPanel_theme.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_font
            // 
            this.checkBox_font.AutoSize = true;
            this.checkBox_font.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox_font.Location = new System.Drawing.Point(3, 18);
            this.checkBox_font.Name = "checkBox_font";
            this.checkBox_font.Size = new System.Drawing.Size(154, 17);
            this.checkBox_font.TabIndex = 0;
            this.checkBox_font.Text = "Use Global Font";
            this.checkBox_font.UseVisualStyleBackColor = true;
            this.checkBox_font.CheckedChanged += new System.EventHandler(this.checkBox_font_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.groupBox_theme);
            this.groupBox.Controls.Add(this.button_font);
            this.groupBox.Controls.Add(this.checkBox_font);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox.Size = new System.Drawing.Size(160, 304);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Application Settings";
            // 
            // button_font
            // 
            this.button_font.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_font.Location = new System.Drawing.Point(3, 35);
            this.button_font.Name = "button_font";
            this.button_font.Size = new System.Drawing.Size(154, 23);
            this.button_font.TabIndex = 1;
            this.button_font.Text = "Change Font";
            this.button_font.UseVisualStyleBackColor = true;
            this.button_font.Click += new System.EventHandler(this.button_font_Click);
            // 
            // groupBox_theme
            // 
            this.groupBox_theme.Controls.Add(this.flowLayoutPanel_theme);
            this.groupBox_theme.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_theme.Location = new System.Drawing.Point(3, 58);
            this.groupBox_theme.Name = "groupBox_theme";
            this.groupBox_theme.Size = new System.Drawing.Size(154, 49);
            this.groupBox_theme.TabIndex = 2;
            this.groupBox_theme.TabStop = false;
            this.groupBox_theme.Text = "Theme";
            // 
            // flowLayoutPanel_theme
            // 
            this.flowLayoutPanel_theme.Controls.Add(this.radioButton_default);
            this.flowLayoutPanel_theme.Controls.Add(this.radioButton_dark);
            this.flowLayoutPanel_theme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_theme.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_theme.Name = "flowLayoutPanel_theme";
            this.flowLayoutPanel_theme.Size = new System.Drawing.Size(148, 30);
            this.flowLayoutPanel_theme.TabIndex = 0;
            // 
            // radioButton_default
            // 
            this.radioButton_default.AutoSize = true;
            this.radioButton_default.Checked = true;
            this.radioButton_default.Location = new System.Drawing.Point(3, 3);
            this.radioButton_default.Name = "radioButton_default";
            this.radioButton_default.Size = new System.Drawing.Size(59, 17);
            this.radioButton_default.TabIndex = 0;
            this.radioButton_default.TabStop = true;
            this.radioButton_default.Text = "Default";
            this.radioButton_default.UseVisualStyleBackColor = true;
            this.radioButton_default.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton_dark
            // 
            this.radioButton_dark.AutoSize = true;
            this.radioButton_dark.Location = new System.Drawing.Point(68, 3);
            this.radioButton_dark.Name = "radioButton_dark";
            this.radioButton_dark.Size = new System.Drawing.Size(48, 17);
            this.radioButton_dark.TabIndex = 1;
            this.radioButton_dark.Text = "Dark";
            this.radioButton_dark.UseVisualStyleBackColor = true;
            this.radioButton_dark.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // ApplicationPreferenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "ApplicationPreferenceControl";
            this.Size = new System.Drawing.Size(160, 304);
            this.Load += new System.EventHandler(this.ApplicationPreferenceControl_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox_theme.ResumeLayout(false);
            this.flowLayoutPanel_theme.ResumeLayout(false);
            this.flowLayoutPanel_theme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_font;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button button_font;
        private System.Windows.Forms.GroupBox groupBox_theme;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_theme;
        private System.Windows.Forms.RadioButton radioButton_default;
        private System.Windows.Forms.RadioButton radioButton_dark;
    }
}
