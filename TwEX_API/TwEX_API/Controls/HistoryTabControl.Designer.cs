namespace TwEX_API.Controls
{
    partial class HistoryTabControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryTabControl));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_open = new System.Windows.Forms.TabPage();
            this.ordersListControl_open = new TwEX_API.Controls.OrdersListControl();
            this.tabPage_closed = new System.Windows.Forms.TabPage();
            this.ordersListControl_closed = new TwEX_API.Controls.OrdersListControl();
            this.tabPage_deposits = new System.Windows.Forms.TabPage();
            this.transactionsListControl_deposits = new TwEX_API.Controls.TransactionsListControl();
            this.tabPage_withdrawals = new System.Windows.Forms.TabPage();
            this.transactionsListControl_withdraw = new TwEX_API.Controls.TransactionsListControl();
            this.tabPage_symbol = new System.Windows.Forms.TabPage();
            this.symbolHistoryListControl = new TwEX_API.Controls.SymbolHistoryListControl();
            this.tabPage_orders = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_toggleHeight = new System.Windows.Forms.ToolStripButton();
            this.toolStripRadioButton_open = new TwEX_API.ToolStripRadioButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRadioButton_closed = new TwEX_API.ToolStripRadioButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRadioButton_deposits = new TwEX_API.ToolStripRadioButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripRadioButton_withdrawals = new TwEX_API.ToolStripRadioButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRadioButton_symbol = new TwEX_API.ToolStripRadioButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRadioButton_CreateOrder = new TwEX_API.ToolStripRadioButton();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.createOrderControl_buy = new TwEX_API.Controls.CreateOrderControl();
            this.createOrderControl_stop = new TwEX_API.Controls.CreateOrderControl();
            this.createOrderControl_sell = new TwEX_API.Controls.CreateOrderControl();
            this.tabControl.SuspendLayout();
            this.tabPage_open.SuspendLayout();
            this.tabPage_closed.SuspendLayout();
            this.tabPage_deposits.SuspendLayout();
            this.tabPage_withdrawals.SuspendLayout();
            this.tabPage_symbol.SuspendLayout();
            this.tabPage_orders.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabPage_open);
            this.tabControl.Controls.Add(this.tabPage_closed);
            this.tabControl.Controls.Add(this.tabPage_deposits);
            this.tabControl.Controls.Add(this.tabPage_withdrawals);
            this.tabControl.Controls.Add(this.tabPage_symbol);
            this.tabControl.Controls.Add(this.tabPage_orders);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(747, 301);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            // 
            // tabPage_open
            // 
            this.tabPage_open.Controls.Add(this.ordersListControl_open);
            this.tabPage_open.Location = new System.Drawing.Point(4, 5);
            this.tabPage_open.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_open.Name = "tabPage_open";
            this.tabPage_open.Size = new System.Drawing.Size(739, 292);
            this.tabPage_open.TabIndex = 0;
            this.tabPage_open.Text = "OPEN (0)";
            this.tabPage_open.UseVisualStyleBackColor = true;
            // 
            // ordersListControl_open
            // 
            this.ordersListControl_open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersListControl_open.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ordersListControl_open.Location = new System.Drawing.Point(0, 0);
            this.ordersListControl_open.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ordersListControl_open.Name = "ordersListControl_open";
            this.ordersListControl_open.Size = new System.Drawing.Size(739, 292);
            this.ordersListControl_open.TabIndex = 0;
            // 
            // tabPage_closed
            // 
            this.tabPage_closed.Controls.Add(this.ordersListControl_closed);
            this.tabPage_closed.Location = new System.Drawing.Point(4, 5);
            this.tabPage_closed.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_closed.Name = "tabPage_closed";
            this.tabPage_closed.Size = new System.Drawing.Size(739, 292);
            this.tabPage_closed.TabIndex = 1;
            this.tabPage_closed.Text = "CLOSED (0)";
            this.tabPage_closed.UseVisualStyleBackColor = true;
            // 
            // ordersListControl_closed
            // 
            this.ordersListControl_closed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersListControl_closed.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ordersListControl_closed.Location = new System.Drawing.Point(0, 0);
            this.ordersListControl_closed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ordersListControl_closed.Name = "ordersListControl_closed";
            this.ordersListControl_closed.Size = new System.Drawing.Size(739, 292);
            this.ordersListControl_closed.TabIndex = 0;
            // 
            // tabPage_deposits
            // 
            this.tabPage_deposits.Controls.Add(this.transactionsListControl_deposits);
            this.tabPage_deposits.Location = new System.Drawing.Point(4, 5);
            this.tabPage_deposits.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_deposits.Name = "tabPage_deposits";
            this.tabPage_deposits.Size = new System.Drawing.Size(739, 292);
            this.tabPage_deposits.TabIndex = 2;
            this.tabPage_deposits.Text = "DEPOSITS (0)";
            this.tabPage_deposits.UseVisualStyleBackColor = true;
            // 
            // transactionsListControl_deposits
            // 
            this.transactionsListControl_deposits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionsListControl_deposits.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.transactionsListControl_deposits.Location = new System.Drawing.Point(0, 0);
            this.transactionsListControl_deposits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.transactionsListControl_deposits.Name = "transactionsListControl_deposits";
            this.transactionsListControl_deposits.Size = new System.Drawing.Size(739, 292);
            this.transactionsListControl_deposits.TabIndex = 0;
            // 
            // tabPage_withdrawals
            // 
            this.tabPage_withdrawals.Controls.Add(this.transactionsListControl_withdraw);
            this.tabPage_withdrawals.Location = new System.Drawing.Point(4, 5);
            this.tabPage_withdrawals.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_withdrawals.Name = "tabPage_withdrawals";
            this.tabPage_withdrawals.Size = new System.Drawing.Size(739, 292);
            this.tabPage_withdrawals.TabIndex = 3;
            this.tabPage_withdrawals.Text = "WITHDRAWALS (0)";
            this.tabPage_withdrawals.UseVisualStyleBackColor = true;
            // 
            // transactionsListControl_withdraw
            // 
            this.transactionsListControl_withdraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionsListControl_withdraw.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.transactionsListControl_withdraw.Location = new System.Drawing.Point(0, 0);
            this.transactionsListControl_withdraw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.transactionsListControl_withdraw.Name = "transactionsListControl_withdraw";
            this.transactionsListControl_withdraw.Size = new System.Drawing.Size(739, 292);
            this.transactionsListControl_withdraw.TabIndex = 0;
            // 
            // tabPage_symbol
            // 
            this.tabPage_symbol.Controls.Add(this.symbolHistoryListControl);
            this.tabPage_symbol.Location = new System.Drawing.Point(4, 5);
            this.tabPage_symbol.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_symbol.Name = "tabPage_symbol";
            this.tabPage_symbol.Size = new System.Drawing.Size(739, 292);
            this.tabPage_symbol.TabIndex = 4;
            this.tabPage_symbol.Text = "SYMBOL";
            this.tabPage_symbol.UseVisualStyleBackColor = true;
            // 
            // symbolHistoryListControl
            // 
            this.symbolHistoryListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.symbolHistoryListControl.Location = new System.Drawing.Point(0, 0);
            this.symbolHistoryListControl.Name = "symbolHistoryListControl";
            this.symbolHistoryListControl.Size = new System.Drawing.Size(739, 292);
            this.symbolHistoryListControl.TabIndex = 0;
            // 
            // tabPage_orders
            // 
            this.tabPage_orders.Controls.Add(this.tableLayoutPanel);
            this.tabPage_orders.Location = new System.Drawing.Point(4, 5);
            this.tabPage_orders.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_orders.Name = "tabPage_orders";
            this.tabPage_orders.Size = new System.Drawing.Size(739, 292);
            this.tabPage_orders.TabIndex = 5;
            this.tabPage_orders.Text = "orders";
            this.tabPage_orders.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_toggleHeight,
            this.toolStripRadioButton_open,
            this.toolStripSeparator1,
            this.toolStripRadioButton_closed,
            this.toolStripSeparator2,
            this.toolStripRadioButton_deposits,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.toolStripButton_refresh,
            this.toolStripRadioButton_withdrawals,
            this.toolStripSeparator5,
            this.toolStripRadioButton_symbol,
            this.toolStripSeparator6,
            this.toolStripRadioButton_CreateOrder});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(747, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // toolStripButton_toggleHeight
            // 
            this.toolStripButton_toggleHeight.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_toggleHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_toggleHeight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_toggleHeight.Image")));
            this.toolStripButton_toggleHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_toggleHeight.Name = "toolStripButton_toggleHeight";
            this.toolStripButton_toggleHeight.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_toggleHeight.Text = "Toggle Height";
            this.toolStripButton_toggleHeight.Click += new System.EventHandler(this.toolStripButton_toggleHeight_Click);
            // 
            // toolStripRadioButton_open
            // 
            this.toolStripRadioButton_open.Checked = true;
            this.toolStripRadioButton_open.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_open.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_open.CheckOnClick = true;
            this.toolStripRadioButton_open.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripRadioButton_open.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_open.Image")));
            this.toolStripRadioButton_open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_open.Name = "toolStripRadioButton_open";
            this.toolStripRadioButton_open.RadioButtonGroupId = 0;
            this.toolStripRadioButton_open.Size = new System.Drawing.Size(75, 22);
            this.toolStripRadioButton_open.Tag = "0";
            this.toolStripRadioButton_open.Text = "OPEN (0)";
            this.toolStripRadioButton_open.Click += new System.EventHandler(this.toolStripRadioButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripRadioButton_closed
            // 
            this.toolStripRadioButton_closed.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_closed.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_closed.CheckOnClick = true;
            this.toolStripRadioButton_closed.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_closed.Image")));
            this.toolStripRadioButton_closed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_closed.Name = "toolStripRadioButton_closed";
            this.toolStripRadioButton_closed.RadioButtonGroupId = 0;
            this.toolStripRadioButton_closed.Size = new System.Drawing.Size(87, 22);
            this.toolStripRadioButton_closed.Tag = "1";
            this.toolStripRadioButton_closed.Text = "CLOSED (0)";
            this.toolStripRadioButton_closed.Click += new System.EventHandler(this.toolStripRadioButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripRadioButton_deposits
            // 
            this.toolStripRadioButton_deposits.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_deposits.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_deposits.CheckOnClick = true;
            this.toolStripRadioButton_deposits.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_deposits.Image")));
            this.toolStripRadioButton_deposits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_deposits.Name = "toolStripRadioButton_deposits";
            this.toolStripRadioButton_deposits.RadioButtonGroupId = 0;
            this.toolStripRadioButton_deposits.Size = new System.Drawing.Size(96, 22);
            this.toolStripRadioButton_deposits.Tag = "2";
            this.toolStripRadioButton_deposits.Text = "DEPOSITS (0)";
            this.toolStripRadioButton_deposits.Click += new System.EventHandler(this.toolStripRadioButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_refresh
            // 
            this.toolStripButton_refresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_refresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_refresh.Image")));
            this.toolStripButton_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_refresh.Name = "toolStripButton_refresh";
            this.toolStripButton_refresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_refresh.Text = "REFRESH";
            this.toolStripButton_refresh.Click += new System.EventHandler(this.toolStripButton_refresh_Click);
            // 
            // toolStripRadioButton_withdrawals
            // 
            this.toolStripRadioButton_withdrawals.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_withdrawals.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_withdrawals.CheckOnClick = true;
            this.toolStripRadioButton_withdrawals.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_withdrawals.Image")));
            this.toolStripRadioButton_withdrawals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_withdrawals.Name = "toolStripRadioButton_withdrawals";
            this.toolStripRadioButton_withdrawals.RadioButtonGroupId = 0;
            this.toolStripRadioButton_withdrawals.Size = new System.Drawing.Size(127, 22);
            this.toolStripRadioButton_withdrawals.Tag = "3";
            this.toolStripRadioButton_withdrawals.Text = "WITHDRAWALS (0)";
            this.toolStripRadioButton_withdrawals.ToolTipText = "WITHDRAWALS (0)";
            this.toolStripRadioButton_withdrawals.Click += new System.EventHandler(this.toolStripRadioButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripRadioButton_symbol
            // 
            this.toolStripRadioButton_symbol.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRadioButton_symbol.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_symbol.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_symbol.CheckOnClick = true;
            this.toolStripRadioButton_symbol.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_symbol.Image")));
            this.toolStripRadioButton_symbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_symbol.Name = "toolStripRadioButton_symbol";
            this.toolStripRadioButton_symbol.RadioButtonGroupId = 0;
            this.toolStripRadioButton_symbol.Size = new System.Drawing.Size(73, 22);
            this.toolStripRadioButton_symbol.Tag = "4";
            this.toolStripRadioButton_symbol.Text = "SYMBOL";
            this.toolStripRadioButton_symbol.Click += new System.EventHandler(this.toolStripRadioButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripRadioButton_CreateOrder
            // 
            this.toolStripRadioButton_CreateOrder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripRadioButton_CreateOrder.CheckedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(179)))));
            this.toolStripRadioButton_CreateOrder.CheckedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(139)))), ((int)(((byte)(205)))));
            this.toolStripRadioButton_CreateOrder.CheckOnClick = true;
            this.toolStripRadioButton_CreateOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripRadioButton_CreateOrder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRadioButton_CreateOrder.Image")));
            this.toolStripRadioButton_CreateOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRadioButton_CreateOrder.Name = "toolStripRadioButton_CreateOrder";
            this.toolStripRadioButton_CreateOrder.RadioButtonGroupId = 0;
            this.toolStripRadioButton_CreateOrder.Size = new System.Drawing.Size(60, 22);
            this.toolStripRadioButton_CreateOrder.Tag = "5";
            this.toolStripRadioButton_CreateOrder.Text = "Buy / Sell";
            this.toolStripRadioButton_CreateOrder.ToolTipText = "Create A New Order";
            this.toolStripRadioButton_CreateOrder.Click += new System.EventHandler(this.toolStripRadioButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Controls.Add(this.createOrderControl_buy, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.createOrderControl_stop, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.createOrderControl_sell, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(739, 292);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // createOrderControl_buy
            // 
            this.createOrderControl_buy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createOrderControl_buy.Location = new System.Drawing.Point(6, 6);
            this.createOrderControl_buy.Name = "createOrderControl_buy";
            this.createOrderControl_buy.Size = new System.Drawing.Size(236, 280);
            this.createOrderControl_buy.TabIndex = 0;
            // 
            // createOrderControl_stop
            // 
            this.createOrderControl_stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createOrderControl_stop.Location = new System.Drawing.Point(251, 6);
            this.createOrderControl_stop.Name = "createOrderControl_stop";
            this.createOrderControl_stop.Size = new System.Drawing.Size(236, 280);
            this.createOrderControl_stop.TabIndex = 1;
            // 
            // createOrderControl_sell
            // 
            this.createOrderControl_sell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createOrderControl_sell.Location = new System.Drawing.Point(496, 6);
            this.createOrderControl_sell.Name = "createOrderControl_sell";
            this.createOrderControl_sell.Size = new System.Drawing.Size(237, 280);
            this.createOrderControl_sell.TabIndex = 2;
            // 
            // HistoryTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Name = "HistoryTabControl";
            this.Size = new System.Drawing.Size(747, 326);
            this.Load += new System.EventHandler(this.HistoryTabControl_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage_open.ResumeLayout(false);
            this.tabPage_closed.ResumeLayout(false);
            this.tabPage_deposits.ResumeLayout(false);
            this.tabPage_withdrawals.ResumeLayout(false);
            this.tabPage_symbol.ResumeLayout(false);
            this.tabPage_orders.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_open;
        private System.Windows.Forms.TabPage tabPage_closed;
        private System.Windows.Forms.TabPage tabPage_deposits;
        private System.Windows.Forms.TabPage tabPage_withdrawals;
        private OrdersListControl ordersListControl_open;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_toggleHeight;
        private ToolStripRadioButton toolStripRadioButton_open;
        private ToolStripRadioButton toolStripRadioButton_closed;
        private ToolStripRadioButton toolStripRadioButton_deposits;
        private ToolStripRadioButton toolStripRadioButton_withdrawals;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_refresh;
        private OrdersListControl ordersListControl_closed;
        private TransactionsListControl transactionsListControl_deposits;
        private TransactionsListControl transactionsListControl_withdraw;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private ToolStripRadioButton toolStripRadioButton_symbol;
        private System.Windows.Forms.TabPage tabPage_symbol;
        private SymbolHistoryListControl symbolHistoryListControl;
        private ToolStripRadioButton toolStripRadioButton_CreateOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TabPage tabPage_orders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private CreateOrderControl createOrderControl_buy;
        private CreateOrderControl createOrderControl_stop;
        private CreateOrderControl createOrderControl_sell;
    }
}
