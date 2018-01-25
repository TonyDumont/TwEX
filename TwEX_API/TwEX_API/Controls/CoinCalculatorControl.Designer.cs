namespace TwEX_API.Controls
{
    partial class CoinCalculatorControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoinCalculatorControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_AddSymbol = new System.Windows.Forms.ToolStripButton();
            this.toolStripSpringTextBox_symbol = new TwEX_API.ToolStripSpringTextBox();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_usd = new System.Windows.Forms.NumericUpDown();
            this.label_usd = new System.Windows.Forms.Label();
            this.numericUpDown_symbol = new System.Windows.Forms.NumericUpDown();
            this.label_symbol = new System.Windows.Forms.Label();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_value = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_usd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_symbol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_AddSymbol,
            this.toolStripSpringTextBox_symbol,
            this.toolStripDropDownButton_menu});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(241, 39);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton_AddSymbol
            // 
            this.toolStripButton_AddSymbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_AddSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddSymbol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddSymbol.Image")));
            this.toolStripButton_AddSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddSymbol.Name = "toolStripButton_AddSymbol";
            this.toolStripButton_AddSymbol.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_AddSymbol.Text = "Add Symbol";
            this.toolStripButton_AddSymbol.Click += new System.EventHandler(this.toolStripButton_AddSymbol_Click);
            // 
            // toolStripSpringTextBox_symbol
            // 
            this.toolStripSpringTextBox_symbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSpringTextBox_symbol.Name = "toolStripSpringTextBox_symbol";
            this.toolStripSpringTextBox_symbol.Size = new System.Drawing.Size(129, 52);
            this.toolStripSpringTextBox_symbol.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease,
            this.toolStripSeparator4});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(45, 49);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_usd, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label_usd, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_symbol, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label_symbol, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.listView, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(241, 357);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // numericUpDown_usd
            // 
            this.numericUpDown_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_usd.Location = new System.Drawing.Point(3, 3);
            this.numericUpDown_usd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_usd.Name = "numericUpDown_usd";
            this.numericUpDown_usd.Size = new System.Drawing.Size(199, 20);
            this.numericUpDown_usd.TabIndex = 0;
            this.numericUpDown_usd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_usd.ValueChanged += new System.EventHandler(this.numericUpDown_usd_ValueChanged);
            // 
            // label_usd
            // 
            this.label_usd.AutoSize = true;
            this.label_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_usd.Location = new System.Drawing.Point(208, 0);
            this.label_usd.Name = "label_usd";
            this.label_usd.Size = new System.Drawing.Size(30, 26);
            this.label_usd.TabIndex = 1;
            this.label_usd.Text = "USD";
            this.label_usd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_symbol
            // 
            this.numericUpDown_symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_symbol.Location = new System.Drawing.Point(3, 29);
            this.numericUpDown_symbol.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_symbol.Name = "numericUpDown_symbol";
            this.numericUpDown_symbol.Size = new System.Drawing.Size(199, 20);
            this.numericUpDown_symbol.TabIndex = 2;
            this.numericUpDown_symbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_symbol.ValueChanged += new System.EventHandler(this.numericUpDown_symbol_ValueChanged);
            // 
            // label_symbol
            // 
            this.label_symbol.AutoSize = true;
            this.label_symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_symbol.Location = new System.Drawing.Point(208, 26);
            this.label_symbol.Name = "label_symbol";
            this.label_symbol.Size = new System.Drawing.Size(30, 26);
            this.label_symbol.TabIndex = 3;
            this.label_symbol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_symbol);
            this.listView.AllColumns.Add(this.column_value);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_symbol,
            this.column_value});
            this.tableLayoutPanel.SetColumnSpan(this.listView, 2);
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 55);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(235, 299);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 4;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.SelectionChanged += new System.EventHandler(this.listView_SelectionChanged);
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // column_symbol
            // 
            this.column_symbol.AspectName = "symbol";
            this.column_symbol.Text = "Symbol";
            this.column_symbol.Width = 50;
            // 
            // column_value
            // 
            this.column_value.FillsFreeSpace = true;
            this.column_value.Text = "Value";
            this.column_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_value.Width = 50;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // CoinCalculatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "CoinCalculatorControl";
            this.Size = new System.Drawing.Size(241, 396);
            this.Load += new System.EventHandler(this.CoinCalculatorControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_usd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_symbol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.NumericUpDown numericUpDown_usd;
        private System.Windows.Forms.Label label_usd;
        private System.Windows.Forms.NumericUpDown numericUpDown_symbol;
        private System.Windows.Forms.Label label_symbol;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_symbol;
        private BrightIdeasSoftware.OLVColumn column_value;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSpringTextBox toolStripSpringTextBox_symbol;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddSymbol;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
