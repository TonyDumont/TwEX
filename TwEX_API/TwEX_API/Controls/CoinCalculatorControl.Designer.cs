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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_usd = new System.Windows.Forms.NumericUpDown();
            this.label_usd = new System.Windows.Forms.Label();
            this.numericUpDown_symbol = new System.Windows.Forms.NumericUpDown();
            this.label_symbol = new System.Windows.Forms.Label();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_price = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_value = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pictureBox_usd = new System.Windows.Forms.PictureBox();
            this.pictureBox_symbol = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_footer = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_menu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_font = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_fontDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_removeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_symbol = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_value = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_AddSymbol = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSpringTextBox_symbol = new TwEX_API.ToolStripSpringTextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_usd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_symbol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_usd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_symbol)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip_footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_usd, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label_usd, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown_symbol, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label_symbol, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.listView, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.pictureBox_usd, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.pictureBox_symbol, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(361, 392);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // numericUpDown_usd
            // 
            this.numericUpDown_usd.DecimalPlaces = 2;
            this.numericUpDown_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_usd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_usd.Location = new System.Drawing.Point(3, 3);
            this.numericUpDown_usd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_usd.Name = "numericUpDown_usd";
            this.numericUpDown_usd.Size = new System.Drawing.Size(297, 20);
            this.numericUpDown_usd.TabIndex = 0;
            this.numericUpDown_usd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_usd.ValueChanged += new System.EventHandler(this.numericUpDown_usd_ValueChanged);
            // 
            // label_usd
            // 
            this.label_usd.AutoSize = true;
            this.label_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_usd.Location = new System.Drawing.Point(328, 0);
            this.label_usd.Name = "label_usd";
            this.label_usd.Size = new System.Drawing.Size(30, 26);
            this.label_usd.TabIndex = 1;
            this.label_usd.Text = "USD";
            this.label_usd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_symbol
            // 
            this.numericUpDown_symbol.DecimalPlaces = 8;
            this.numericUpDown_symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_symbol.Increment = new decimal(new int[] {
            1,
            0,
            0,
            524288});
            this.numericUpDown_symbol.Location = new System.Drawing.Point(3, 29);
            this.numericUpDown_symbol.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDown_symbol.Name = "numericUpDown_symbol";
            this.numericUpDown_symbol.Size = new System.Drawing.Size(297, 20);
            this.numericUpDown_symbol.TabIndex = 2;
            this.numericUpDown_symbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_symbol.ValueChanged += new System.EventHandler(this.numericUpDown_symbol_ValueChanged);
            // 
            // label_symbol
            // 
            this.label_symbol.AutoSize = true;
            this.label_symbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_symbol.Location = new System.Drawing.Point(328, 26);
            this.label_symbol.Name = "label_symbol";
            this.label_symbol.Size = new System.Drawing.Size(30, 26);
            this.label_symbol.TabIndex = 3;
            this.label_symbol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_symbol);
            this.listView.AllColumns.Add(this.column_price);
            this.listView.AllColumns.Add(this.column_value);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_symbol,
            this.column_price,
            this.column_value});
            this.tableLayoutPanel.SetColumnSpan(this.listView, 3);
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(3, 55);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(355, 334);
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
            // column_price
            // 
            this.column_price.Text = "Price";
            this.column_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_value
            // 
            this.column_value.FillsFreeSpace = true;
            this.column_value.Text = "Value";
            this.column_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_value.Width = 50;
            // 
            // pictureBox_usd
            // 
            this.pictureBox_usd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_usd.Location = new System.Drawing.Point(306, 3);
            this.pictureBox_usd.Name = "pictureBox_usd";
            this.pictureBox_usd.Size = new System.Drawing.Size(16, 20);
            this.pictureBox_usd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_usd.TabIndex = 5;
            this.pictureBox_usd.TabStop = false;
            // 
            // pictureBox_symbol
            // 
            this.pictureBox_symbol.Location = new System.Drawing.Point(306, 29);
            this.pictureBox_symbol.Name = "pictureBox_symbol";
            this.pictureBox_symbol.Size = new System.Drawing.Size(16, 20);
            this.pictureBox_symbol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_symbol.TabIndex = 6;
            this.pictureBox_symbol.TabStop = false;
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
            // toolStrip_footer
            // 
            this.toolStrip_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_menu,
            this.toolStripSeparator1,
            this.toolStripButton_AddSymbol,
            this.toolStripSeparator2,
            this.toolStripSpringTextBox_symbol});
            this.toolStrip_footer.Location = new System.Drawing.Point(0, 392);
            this.toolStrip_footer.Name = "toolStrip_footer";
            this.toolStrip_footer.Size = new System.Drawing.Size(361, 25);
            this.toolStrip_footer.TabIndex = 2;
            this.toolStrip_footer.Text = "toolStrip1";
            // 
            // toolStripDropDownButton_menu
            // 
            this.toolStripDropDownButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_font,
            this.toolStripMenuItem_fontIncrease,
            this.toolStripMenuItem_fontDecrease,
            this.toolStripSeparator4,
            this.toolStripMenuItem_removeAll,
            this.toolStripSeparator3,
            this.toolStripMenuItem_symbol,
            this.toolStripMenuItem_value});
            this.toolStripDropDownButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_menu.Image")));
            this.toolStripDropDownButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_menu.Name = "toolStripDropDownButton_menu";
            this.toolStripDropDownButton_menu.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton_menu.Text = "OPTIONS";
            this.toolStripDropDownButton_menu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_menu_DropDownItemClicked);
            // 
            // toolStripMenuItem_font
            // 
            this.toolStripMenuItem_font.Name = "toolStripMenuItem_font";
            this.toolStripMenuItem_font.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem_font.Tag = "Font";
            this.toolStripMenuItem_font.Text = "Font";
            // 
            // toolStripMenuItem_fontIncrease
            // 
            this.toolStripMenuItem_fontIncrease.Name = "toolStripMenuItem_fontIncrease";
            this.toolStripMenuItem_fontIncrease.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem_fontIncrease.Tag = "FontIncrease";
            this.toolStripMenuItem_fontIncrease.Text = "Increase Font";
            // 
            // toolStripMenuItem_fontDecrease
            // 
            this.toolStripMenuItem_fontDecrease.Name = "toolStripMenuItem_fontDecrease";
            this.toolStripMenuItem_fontDecrease.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem_fontDecrease.Tag = "FontDecrease";
            this.toolStripMenuItem_fontDecrease.Text = "Decrease Font";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenuItem_removeAll
            // 
            this.toolStripMenuItem_removeAll.Name = "toolStripMenuItem_removeAll";
            this.toolStripMenuItem_removeAll.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem_removeAll.Tag = "RemoveAll";
            this.toolStripMenuItem_removeAll.Text = "Remove All Symbols";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenuItem_symbol
            // 
            this.toolStripMenuItem_symbol.Name = "toolStripMenuItem_symbol";
            this.toolStripMenuItem_symbol.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem_symbol.Tag = "SortSymbol";
            this.toolStripMenuItem_symbol.Text = "Sort By Symbol";
            // 
            // toolStripMenuItem_value
            // 
            this.toolStripMenuItem_value.Name = "toolStripMenuItem_value";
            this.toolStripMenuItem_value.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem_value.Tag = "SortValue";
            this.toolStripMenuItem_value.Text = "Sort By Value";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_AddSymbol
            // 
            this.toolStripButton_AddSymbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_AddSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddSymbol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddSymbol.Image")));
            this.toolStripButton_AddSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddSymbol.Name = "toolStripButton_AddSymbol";
            this.toolStripButton_AddSymbol.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddSymbol.Text = "Add Symbol";
            this.toolStripButton_AddSymbol.Click += new System.EventHandler(this.toolStripButton_AddSymbol_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSpringTextBox_symbol
            // 
            this.toolStripSpringTextBox_symbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSpringTextBox_symbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripSpringTextBox_symbol.Name = "toolStripSpringTextBox_symbol";
            this.toolStripSpringTextBox_symbol.Size = new System.Drawing.Size(254, 25);
            this.toolStripSpringTextBox_symbol.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CoinCalculatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.toolStrip_footer);
            this.Name = "CoinCalculatorControl";
            this.Size = new System.Drawing.Size(361, 417);
            this.Load += new System.EventHandler(this.CoinCalculatorControl_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_usd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_symbol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_usd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_symbol)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip_footer.ResumeLayout(false);
            this.toolStrip_footer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.PictureBox pictureBox_usd;
        private System.Windows.Forms.PictureBox pictureBox_symbol;
        private System.Windows.Forms.ToolStrip toolStrip_footer;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddSymbol;
        private ToolStripSpringTextBox toolStripSpringTextBox_symbol;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_font;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontIncrease;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_fontDecrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_removeAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_symbol;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_value;
        private BrightIdeasSoftware.OLVColumn column_price;
    }
}
