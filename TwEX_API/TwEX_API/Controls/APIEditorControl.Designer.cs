namespace TwEX_API.Controls
{
    partial class APIEditorControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_key = new System.Windows.Forms.Label();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.label_secret = new System.Windows.Forms.Label();
            this.textBox_secret = new System.Windows.Forms.TextBox();
            this.label_passphrase = new System.Windows.Forms.Label();
            this.textBox_passphrase = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.label_key, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_key, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_secret, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_secret, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_passphrase, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_passphrase, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_save, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(487, 179);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_key
            // 
            this.label_key.AutoSize = true;
            this.label_key.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_key.Location = new System.Drawing.Point(8, 5);
            this.label_key.Name = "label_key";
            this.label_key.Size = new System.Drawing.Size(113, 42);
            this.label_key.TabIndex = 0;
            this.label_key.Text = "Key:";
            this.label_key.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox_key
            // 
            this.textBox_key.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_key.Location = new System.Drawing.Point(127, 8);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(352, 20);
            this.textBox_key.TabIndex = 1;
            // 
            // label_secret
            // 
            this.label_secret.AutoSize = true;
            this.label_secret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_secret.Location = new System.Drawing.Point(8, 47);
            this.label_secret.Name = "label_secret";
            this.label_secret.Size = new System.Drawing.Size(113, 42);
            this.label_secret.TabIndex = 2;
            this.label_secret.Text = "Secret:";
            this.label_secret.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox_secret
            // 
            this.textBox_secret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_secret.Location = new System.Drawing.Point(127, 50);
            this.textBox_secret.Name = "textBox_secret";
            this.textBox_secret.Size = new System.Drawing.Size(352, 20);
            this.textBox_secret.TabIndex = 3;
            // 
            // label_passphrase
            // 
            this.label_passphrase.AutoSize = true;
            this.label_passphrase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_passphrase.Location = new System.Drawing.Point(8, 89);
            this.label_passphrase.Name = "label_passphrase";
            this.label_passphrase.Size = new System.Drawing.Size(113, 42);
            this.label_passphrase.TabIndex = 4;
            this.label_passphrase.Text = "Passphrase:";
            this.label_passphrase.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox_passphrase
            // 
            this.textBox_passphrase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_passphrase.Location = new System.Drawing.Point(127, 92);
            this.textBox_passphrase.Name = "textBox_passphrase";
            this.textBox_passphrase.Size = new System.Drawing.Size(352, 20);
            this.textBox_passphrase.TabIndex = 5;
            // 
            // button_save
            // 
            this.button_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_save.Location = new System.Drawing.Point(127, 134);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(352, 37);
            this.button_save.TabIndex = 6;
            this.button_save.Text = "SAVE";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // APIEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "APIEditorControl";
            this.Size = new System.Drawing.Size(487, 179);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_key;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Label label_secret;
        private System.Windows.Forms.TextBox textBox_secret;
        private System.Windows.Forms.Label label_passphrase;
        private System.Windows.Forms.TextBox textBox_passphrase;
        private System.Windows.Forms.Button button_save;
    }
}
