namespace TwEX_API.Controls
{
    partial class TradingViewOverviewsListEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradingViewOverviewsListEditorControl));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_symbol = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_symbol = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_market = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_market = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton_exchange = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton_timespan = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_tabName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel_name = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_add = new System.Windows.Forms.ToolStripButton();
            this.listView = new BrightIdeasSoftware.FastObjectListView();
            this.column_symbol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_market = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_exchange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_interval = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.column_name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_symbol,
            this.toolStripTextBox_symbol,
            this.toolStripSeparator1,
            this.toolStripLabel_market,
            this.toolStripTextBox_market,
            this.toolStripSeparator2,
            this.toolStripDropDownButton_exchange,
            this.toolStripSeparator3,
            this.toolStripDropDownButton_timespan,
            this.toolStripSeparator4,
            this.toolStripButton_add,
            this.toolStripSeparator5,
            this.toolStripTextBox_tabName,
            this.toolStripLabel_name});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(707, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
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
            // toolStripDropDownButton_exchange
            // 
            this.toolStripDropDownButton_exchange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_exchange.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_exchange.Image")));
            this.toolStripDropDownButton_exchange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_exchange.Name = "toolStripDropDownButton_exchange";
            this.toolStripDropDownButton_exchange.Size = new System.Drawing.Size(104, 22);
            this.toolStripDropDownButton_exchange.Text = "Select Exchange";
            this.toolStripDropDownButton_exchange.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_exchange_DropDownItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton_timespan
            // 
            this.toolStripDropDownButton_timespan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_timespan.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_timespan.Image")));
            this.toolStripDropDownButton_timespan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_timespan.Name = "toolStripDropDownButton_timespan";
            this.toolStripDropDownButton_timespan.Size = new System.Drawing.Size(106, 22);
            this.toolStripDropDownButton_timespan.Text = "Select Timespan";
            this.toolStripDropDownButton_timespan.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton_timespan_DropDownItemClicked);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox_tabName
            // 
            this.toolStripTextBox_tabName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox_tabName.Name = "toolStripTextBox_tabName";
            this.toolStripTextBox_tabName.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox_tabName.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripLabel_name
            // 
            this.toolStripLabel_name.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_name.Name = "toolStripLabel_name";
            this.toolStripLabel_name.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel_name.Text = "Tab Name:";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_add
            // 
            this.toolStripButton_add.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_add.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_add.Image")));
            this.toolStripButton_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_add.Name = "toolStripButton_add";
            this.toolStripButton_add.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_add.Text = "ADD";
            this.toolStripButton_add.Click += new System.EventHandler(this.toolStripButton_add_Click);
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.column_symbol);
            this.listView.AllColumns.Add(this.column_market);
            this.listView.AllColumns.Add(this.column_interval);
            this.listView.AllColumns.Add(this.column_exchange);
            this.listView.AllColumns.Add(this.column_name);
            this.listView.CellEditUseWholeCell = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_symbol,
            this.column_market,
            this.column_interval,
            this.column_exchange,
            this.column_name});
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HasCollapsibleGroups = false;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectColumnsOnRightClick = false;
            this.listView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.listView.ShowFilterMenuOnRightClick = false;
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(707, 223);
            this.listView.SortGroupItemsByPrimaryColumn = false;
            this.listView.TabIndex = 4;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.UseFiltering = true;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
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
            // column_exchange
            // 
            this.column_exchange.AspectName = "exchange";
            this.column_exchange.AspectToStringFormat = "";
            this.column_exchange.MinimumWidth = 100;
            this.column_exchange.Text = "Exchange";
            this.column_exchange.Width = 100;
            // 
            // column_interval
            // 
            this.column_interval.AspectName = "interval";
            this.column_interval.AspectToStringFormat = "";
            this.column_interval.MinimumWidth = 65;
            this.column_interval.Text = "Time";
            this.column_interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.column_interval.Width = 65;
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
            // TradingViewOverviewsListEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "TradingViewOverviewsListEditorControl";
            this.Size = new System.Drawing.Size(707, 248);
            this.Load += new System.EventHandler(this.TradingViewOverviewsListEditorControl_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_symbol;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_symbol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_market;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_market;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_exchange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_timespan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_tabName;
        private System.Windows.Forms.ToolStripButton toolStripButton_add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_name;
        private BrightIdeasSoftware.FastObjectListView listView;
        private BrightIdeasSoftware.OLVColumn column_symbol;
        private BrightIdeasSoftware.OLVColumn column_market;
        private BrightIdeasSoftware.OLVColumn column_exchange;
        private BrightIdeasSoftware.OLVColumn column_interval;
        private BrightIdeasSoftware.OLVColumn column_name;
    }
}
