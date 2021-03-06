﻿namespace TwEX_API.Controls
{
    partial class ArbitrageWatchListEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArbitrageWatchListEditorControl));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listView_lists = new BrightIdeasSoftware.FastObjectListView();
            this.column_listName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip_lists = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_addList = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox_listName = new System.Windows.Forms.ToolStripTextBox();
            this.listView_symbols = new BrightIdeasSoftware.FastObjectListView();
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_market = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip_symbols = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_symbol = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_symbol = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_market = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_market = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_addSymbol = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_lists)).BeginInit();
            this.toolStrip_lists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_symbols)).BeginInit();
            this.toolStrip_symbols.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listView_lists);
            this.splitContainer.Panel1.Controls.Add(this.toolStrip_lists);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listView_symbols);
            this.splitContainer.Panel2.Controls.Add(this.toolStrip_symbols);
            this.splitContainer.Size = new System.Drawing.Size(983, 478);
            this.splitContainer.SplitterDistance = 204;
            this.splitContainer.TabIndex = 6;
            // 
            // listView_lists
            // 
            this.listView_lists.AllColumns.Add(this.column_listName);
            this.listView_lists.CellEditUseWholeCell = false;
            this.listView_lists.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_listName});
            this.listView_lists.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView_lists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_lists.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_lists.FullRowSelect = true;
            this.listView_lists.GridLines = true;
            this.listView_lists.HasCollapsibleGroups = false;
            this.listView_lists.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_lists.HideSelection = false;
            this.listView_lists.Location = new System.Drawing.Point(0, 25);
            this.listView_lists.MultiSelect = false;
            this.listView_lists.Name = "listView_lists";
            this.listView_lists.SelectColumnsOnRightClick = false;
            this.listView_lists.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView_lists.ShowFilterMenuOnRightClick = false;
            this.listView_lists.ShowGroups = false;
            this.listView_lists.Size = new System.Drawing.Size(204, 453);
            this.listView_lists.SortGroupItemsByPrimaryColumn = false;
            this.listView_lists.TabIndex = 5;
            this.listView_lists.UseCellFormatEvents = true;
            this.listView_lists.UseCompatibleStateImageBehavior = false;
            this.listView_lists.UseFiltering = true;
            this.listView_lists.View = System.Windows.Forms.View.Details;
            this.listView_lists.VirtualMode = true;
            this.listView_lists.SelectionChanged += new System.EventHandler(this.listView_lists_SelectionChanged);
            this.listView_lists.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_lists_MouseClick);
            // 
            // column_listName
            // 
            this.column_listName.AspectName = "Name";
            this.column_listName.FillsFreeSpace = true;
            this.column_listName.MinimumWidth = 60;
            this.column_listName.Text = "List Name";
            // 
            // toolStrip_lists
            // 
            this.toolStrip_lists.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_addList,
            this.toolStripTextBox_listName});
            this.toolStrip_lists.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_lists.Name = "toolStrip_lists";
            this.toolStrip_lists.Size = new System.Drawing.Size(204, 25);
            this.toolStrip_lists.TabIndex = 0;
            this.toolStrip_lists.Text = "toolStrip1";
            // 
            // toolStripButton_addList
            // 
            this.toolStripButton_addList.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_addList.Image")));
            this.toolStripButton_addList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addList.Name = "toolStripButton_addList";
            this.toolStripButton_addList.Size = new System.Drawing.Size(86, 22);
            this.toolStripButton_addList.Text = "List Name :";
            this.toolStripButton_addList.Click += new System.EventHandler(this.toolStripButton_addList_Click);
            // 
            // toolStripTextBox_listName
            // 
            this.toolStripTextBox_listName.Name = "toolStripTextBox_listName";
            this.toolStripTextBox_listName.Size = new System.Drawing.Size(100, 25);
            // 
            // listView_symbols
            // 
            this.listView_symbols.AllColumns.Add(this.column_symbol);
            this.listView_symbols.AllColumns.Add(this.column_market);
            this.listView_symbols.AllColumns.Add(this.column_name);
            this.listView_symbols.CellEditUseWholeCell = false;
            this.listView_symbols.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_symbol,
            this.column_market,
            this.column_name});
            this.listView_symbols.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView_symbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_symbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_symbols.FullRowSelect = true;
            this.listView_symbols.GridLines = true;
            this.listView_symbols.HasCollapsibleGroups = false;
            this.listView_symbols.HideSelection = false;
            this.listView_symbols.Location = new System.Drawing.Point(0, 25);
            this.listView_symbols.MultiSelect = false;
            this.listView_symbols.Name = "listView_symbols";
            this.listView_symbols.SelectColumnsOnRightClick = false;
            this.listView_symbols.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView_symbols.ShowFilterMenuOnRightClick = false;
            this.listView_symbols.ShowGroups = false;
            this.listView_symbols.Size = new System.Drawing.Size(775, 453);
            this.listView_symbols.SortGroupItemsByPrimaryColumn = false;
            this.listView_symbols.TabIndex = 4;
            this.listView_symbols.UseCellFormatEvents = true;
            this.listView_symbols.UseCompatibleStateImageBehavior = false;
            this.listView_symbols.UseFiltering = true;
            this.listView_symbols.View = System.Windows.Forms.View.Details;
            this.listView_symbols.VirtualMode = true;
            this.listView_symbols.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_symbols_MouseClick);
            // 
            // column_symbol
            // 
            this.column_symbol.AspectName = "symbol";
            this.column_symbol.MinimumWidth = 60;
            this.column_symbol.Text = "Symbol";
            this.column_symbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_market
            // 
            this.column_market.AspectName = "market";
            this.column_market.MinimumWidth = 100;
            this.column_market.Text = "Market";
            this.column_market.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_market.Width = 100;
            // 
            // column_name
            // 
            this.column_name.AspectName = "tabName";
            this.column_name.AspectToStringFormat = "";
            this.column_name.FillsFreeSpace = true;
            this.column_name.MinimumWidth = 100;
            this.column_name.Text = "Tab Name";
            this.column_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_name.Width = 100;
            // 
            // toolStrip_symbols
            // 
            this.toolStrip_symbols.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_addSymbol,
            this.toolStripSeparator1,
            this.toolStripLabel_symbol,
            this.toolStripTextBox_symbol,
            this.toolStripSeparator2,
            this.toolStripLabel_market,
            this.toolStripTextBox_market});
            this.toolStrip_symbols.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_symbols.Name = "toolStrip_symbols";
            this.toolStrip_symbols.Size = new System.Drawing.Size(775, 25);
            this.toolStrip_symbols.TabIndex = 0;
            this.toolStrip_symbols.Text = "toolStrip1";
            // 
            // toolStripLabel_symbol
            // 
            this.toolStripLabel_symbol.Name = "toolStripLabel_symbol";
            this.toolStripLabel_symbol.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel_symbol.Text = "Symbol:";
            // 
            // toolStripTextBox_symbol
            // 
            this.toolStripTextBox_symbol.Name = "toolStripTextBox_symbol";
            this.toolStripTextBox_symbol.Size = new System.Drawing.Size(40, 25);
            this.toolStripTextBox_symbol.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_market
            // 
            this.toolStripLabel_market.Name = "toolStripLabel_market";
            this.toolStripLabel_market.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel_market.Text = "Market:";
            // 
            // toolStripTextBox_market
            // 
            this.toolStripTextBox_market.Name = "toolStripTextBox_market";
            this.toolStripTextBox_market.Size = new System.Drawing.Size(40, 25);
            this.toolStripTextBox_market.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_addSymbol
            // 
            this.toolStripButton_addSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_addSymbol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_addSymbol.Image")));
            this.toolStripButton_addSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addSymbol.Name = "toolStripButton_addSymbol";
            this.toolStripButton_addSymbol.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_addSymbol.Text = "ADD";
            this.toolStripButton_addSymbol.Click += new System.EventHandler(this.toolStripButton_addSymbol_Click);
            // 
            // ArbitrageWatchListEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "ArbitrageWatchListEditorControl";
            this.Size = new System.Drawing.Size(983, 478);
            this.Load += new System.EventHandler(this.ArbitrageWatchListEditorControl_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listView_lists)).EndInit();
            this.toolStrip_lists.ResumeLayout(false);
            this.toolStrip_lists.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView_symbols)).EndInit();
            this.toolStrip_symbols.ResumeLayout(false);
            this.toolStrip_symbols.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private BrightIdeasSoftware.FastObjectListView listView_lists;
        private BrightIdeasSoftware.OLVColumn column_listName;
        private System.Windows.Forms.ToolStrip toolStrip_lists;
        private System.Windows.Forms.ToolStripButton toolStripButton_addList;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_listName;
        private BrightIdeasSoftware.FastObjectListView listView_symbols;
        private BrightIdeasSoftware.OLVColumn column_symbol;
        private BrightIdeasSoftware.OLVColumn column_market;
        private BrightIdeasSoftware.OLVColumn column_name;
        private System.Windows.Forms.ToolStrip toolStrip_symbols;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_symbol;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_symbol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_market;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_market;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_addSymbol;
    }
}
