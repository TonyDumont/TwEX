namespace TwEX_API.Controls
{
    partial class ExchangeTradingControl
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
            this.balanceListControl = new TwEX_API.Controls.BalanceListControl();
            this.tickerListControl = new TwEX_API.Controls.TickerListControl();
            this.historyTabControl = new TwEX_API.Controls.HistoryTabControl();
            this.exchangeChartsControl = new TwEX_API.Controls.ExchangeChartsControl();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.balanceListControl, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tickerListControl, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.historyTabControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.exchangeChartsControl, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(1406, 545);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // balanceListControl
            // 
            this.balanceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balanceListControl.Location = new System.Drawing.Point(5, 5);
            this.balanceListControl.Name = "balanceListControl";
            this.balanceListControl.Size = new System.Drawing.Size(494, 303);
            this.balanceListControl.TabIndex = 0;
            // 
            // tickerListControl
            // 
            this.tickerListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tickerListControl.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.tickerListControl.Location = new System.Drawing.Point(508, 6);
            this.tickerListControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tickerListControl.Name = "tickerListControl";
            this.tickerListControl.Size = new System.Drawing.Size(504, 301);
            this.tickerListControl.TabIndex = 1;
            // 
            // historyTabControl
            // 
            this.tableLayoutPanel.SetColumnSpan(this.historyTabControl, 2);
            this.historyTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyTabControl.Location = new System.Drawing.Point(5, 316);
            this.historyTabControl.Name = "historyTabControl";
            this.historyTabControl.Size = new System.Drawing.Size(1008, 224);
            this.historyTabControl.TabIndex = 2;
            // 
            // exchangeChartsControl
            // 
            this.exchangeChartsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exchangeChartsControl.Location = new System.Drawing.Point(1021, 5);
            this.exchangeChartsControl.Name = "exchangeChartsControl";
            this.tableLayoutPanel.SetRowSpan(this.exchangeChartsControl, 2);
            this.exchangeChartsControl.Size = new System.Drawing.Size(380, 535);
            this.exchangeChartsControl.TabIndex = 3;
            // 
            // ExchangeTradingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ExchangeTradingControl";
            this.Size = new System.Drawing.Size(1406, 545);
            this.Load += new System.EventHandler(this.ExchangeTradingControl_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private BalanceListControl balanceListControl;
        private TickerListControl tickerListControl;
        private HistoryTabControl historyTabControl;
        private ExchangeChartsControl exchangeChartsControl;
    }
}
