namespace TwEX_API.Controls
{
    partial class ArbitrageManagerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArbitrageManagerControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_chart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_update = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_symbol = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_addSymbol = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_lastUpdate = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripNumberControl_maxItems = new TwEX_API.ToolStripNumberControl();
            this.toolStripLabel_max = new System.Windows.Forms.ToolStripLabel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator2,
            this.toolStripTextBox_symbol,
            this.toolStripSeparator3,
            this.toolStripButton_addSymbol,
            this.toolStripLabel_lastUpdate,
            this.toolStripSeparator4,
            this.toolStripNumberControl_maxItems,
            this.toolStripLabel_max});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(550, 26);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease,
            this.toolStripSeparator5,
            this.toolStripMenuItem_chart,
            this.toolStripSeparator1,
            this.toolStripMenuItem_update});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(29, 23);
            this.toolStripDropDownButton_menu.Text = "OPTIONS";
            this.toolStripDropDownButton_menu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_menu_DropDownItemClicked);
            // 
            // toolStripMenuItem_font
            // 
            this.toolStripMenuItem_font.Name = "toolStripMenuItem_font";
            this.toolStripMenuItem_font.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_font.Tag = "Font";
            this.toolStripMenuItem_font.Text = "Font";
            // 
            // toolStripMenuItem_fontIncrease
            // 
            this.toolStripMenuItem_fontIncrease.Name = "toolStripMenuItem_fontIncrease";
            this.toolStripMenuItem_fontIncrease.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_fontIncrease.Tag = "FontIncrease";
            this.toolStripMenuItem_fontIncrease.Text = "Increase Font";
            // 
            // toolStripMenuItem_fontDecrease
            // 
            this.toolStripMenuItem_fontDecrease.Name = "toolStripMenuItem_fontDecrease";
            this.toolStripMenuItem_fontDecrease.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_fontDecrease.Tag = "FontDecrease";
            this.toolStripMenuItem_fontDecrease.Text = "Decrease Font";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_chart
            // 
            this.toolStripMenuItem_chart.Name = "toolStripMenuItem_chart";
            this.toolStripMenuItem_chart.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_chart.Tag = "Charts";
            this.toolStripMenuItem_chart.Text = "Hide Charts";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // toolStripMenuItem_update
            // 
            this.toolStripMenuItem_update.Name = "toolStripMenuItem_update";
            this.toolStripMenuItem_update.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_update.Tag = "Update";
            this.toolStripMenuItem_update.Text = "Refresh All";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripTextBox_symbol
            // 
            this.toolStripTextBox_symbol.Name = "toolStripTextBox_symbol";
            this.toolStripTextBox_symbol.Size = new System.Drawing.Size(65, 26);
            this.toolStripTextBox_symbol.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButton_addSymbol
            // 
            this.toolStripButton_addSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_addSymbol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_addSymbol.Image")));
            this.toolStripButton_addSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addSymbol.Name = "toolStripButton_addSymbol";
            this.toolStripButton_addSymbol.Size = new System.Drawing.Size(76, 23);
            this.toolStripButton_addSymbol.Text = "Add Symbol";
            this.toolStripButton_addSymbol.Click += new System.EventHandler(this.toolStripButton_addSymbol_Click);
            // 
            // toolStripLabel_lastUpdate
            // 
            this.toolStripLabel_lastUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_lastUpdate.Name = "toolStripLabel_lastUpdate";
            this.toolStripLabel_lastUpdate.Size = new System.Drawing.Size(75, 23);
            this.toolStripLabel_lastUpdate.Text = "Last Update :";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripNumberControl_maxItems
            // 
            this.toolStripNumberControl_maxItems.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripNumberControl_maxItems.Name = "toolStripNumberControl_maxItems";
            this.toolStripNumberControl_maxItems.Size = new System.Drawing.Size(41, 23);
            this.toolStripNumberControl_maxItems.Text = "8";
            this.toolStripNumberControl_maxItems.ValueChanged += new System.EventHandler(this.toolStripNumberControl_maxItems_ValueChanged);
            // 
            // toolStripLabel_max
            // 
            this.toolStripLabel_max.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_max.Name = "toolStripLabel_max";
            this.toolStripLabel_max.Size = new System.Drawing.Size(67, 23);
            this.toolStripLabel_max.Text = "Max Items :";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 26);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(550, 324);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // ArbitrageManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "ArbitrageManagerControl";
            this.Size = new System.Drawing.Size(550, 350);
            this.Load += new System.EventHandler(this.ArbitrageManagerControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ToolStripButton toolStripButton_addSymbol;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_symbol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_update;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_chart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_lastUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private ToolStripNumberControl toolStripNumberControl_maxItems;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_max;
    }
}
