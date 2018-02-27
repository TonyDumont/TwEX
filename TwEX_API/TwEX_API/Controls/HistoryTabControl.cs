using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class HistoryTabControl : UserControl
    {
        private ExchangeManager.Exchange Exchange;
        private int originalHeight = 0;

        #region Initialize
        public HistoryTabControl()
        {
            InitializeComponent();
        }
        private void HistoryTabControl_Load(object sender, EventArgs e)
        {
            toolStripButton_toggleHeight.Image = ContentManager.GetIcon("UpDown");
            toolStripRadioButton_deposits.Image = ContentManager.GetIcon("Deposit");
            toolStripRadioButton_withdrawals.Image = ContentManager.GetIcon("Withdrawal");
            toolStripButton_refresh.Image = ContentManager.GetIcon("Refresh");
            toolStripRadioButton_open.Image = Properties.Resources.ConnectionStatus_ACTIVE;
            toolStripRadioButton_closed.Image = Properties.Resources.ConnectionStatus_ERROR;

            toolStripButton_toggleHeight.Image = ContentManager.GetIcon("Down");
            createOrderControl_buy.SetView("buy");
            createOrderControl_sell.SetView("sell");
            createOrderControl_stop.SetView("stop-limit");
            /*
            if (Height != toolStrip.Height)
            {
                //originalHeight = Height;
                //Size = new Size(Width, toolStrip.Height);
                toolStripButton_toggleHeight.Image = ContentManager.GetIcon("Up");
            }
            else
            {
                //Size = new Size(Width, originalHeight);
                toolStripButton_toggleHeight.Image = ContentManager.GetIcon("Down");
            }
            //UpdateUI(true);
            */
        }
        #endregion

        #region Delegates
        
        delegate bool SetExchangeCallback(ExchangeManager.Exchange exchange);
        public bool SetExchange(ExchangeManager.Exchange exchange)
        {
            if (InvokeRequired)
            {
                SetExchangeCallback d = new SetExchangeCallback(SetExchange);
                Invoke(d, new object[] { exchange });
            }
            else
            {
                Exchange = exchange;
                //ExchangeName = exchange;
                ordersListControl_open.OpenOrders = true;
                ordersListControl_closed.OpenOrders = false;
                transactionsListControl_deposits.type = ExchangeManager.ExchangeTransactionType.deposit;
                transactionsListControl_withdraw.type = ExchangeManager.ExchangeTransactionType.withdrawal;

                ordersListControl_open.SetExchange(Exchange);
                ordersListControl_closed.SetExchange(Exchange);
                transactionsListControl_deposits.SetExchange(Exchange);
                transactionsListControl_withdraw.SetExchange(Exchange);
                symbolHistoryListControl.SetExchange(Exchange);
                createOrderControl_buy.SetExchange(Exchange);
                createOrderControl_sell.SetExchange(Exchange);
                createOrderControl_stop.SetExchange(Exchange);

                toolStripRadioButton_symbol.Checked = true;
                tabControl.SelectedIndex = 4;

                UpdateUI(true);
            }
            return true;
        }
        
        delegate bool UpdateUICallback(bool resize = false);
        public bool UpdateUI(bool resize = false)
        {
            if (InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                Invoke(d, new object[] { resize });
            }
            else
            {
                toolStripRadioButton_open.Text = ExchangeManager.Orders.Where(item => item.exchange == Exchange.Name && item.open == true).Count() + " OPEN";
                toolStripRadioButton_closed.Text = ExchangeManager.Orders.Where(item => item.exchange == Exchange.Name && item.open == false).Count() + " CLOSED";
                toolStripRadioButton_deposits.Text = ExchangeManager.Transactions.Where(item => item.exchange == Exchange.Name && item.type == ExchangeManager.ExchangeTransactionType.deposit).Count() + " DEPOSITS";
                toolStripRadioButton_withdrawals.Text = ExchangeManager.Transactions.Where(item => item.exchange == Exchange.Name && item.type == ExchangeManager.ExchangeTransactionType.withdrawal).Count() + " WITHDRAWALS";

                toolStripRadioButton_symbol.Text = Exchange.CurrentTicker.symbol;
                toolStripRadioButton_symbol.Image = ContentManager.GetSymbolIcon(Exchange.CurrentTicker.symbol);

                ordersListControl_open.UpdateUI(resize);
                ordersListControl_closed.UpdateUI(resize);
                transactionsListControl_deposits.UpdateUI(resize);
                transactionsListControl_withdraw.UpdateUI(resize);
                symbolHistoryListControl.UpdateUI(resize);
                createOrderControl_buy.UpdateUI(resize);
                createOrderControl_sell.UpdateUI(resize);
                createOrderControl_stop.UpdateUI(resize);

                if (resize)
                {
                    ResizeUI();
                }
            }
            return true;
        }

        delegate bool ResetUICallback();
        public bool ResetUI()
        {
            if (InvokeRequired)
            {
                ResetUICallback d = new ResetUICallback(ResetUI);
                Invoke(d, new object[] { });
            }
            else
            {
                createOrderControl_buy.ResetUI();
                createOrderControl_sell.ResetUI();
                createOrderControl_stop.ResetUI();
                //return true;
            }
            return true;
        }

        delegate void ResizeUICallback();
        public void ResizeUI()
        {
            if (InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {
                //Font = PreferenceManager.GetFormFont(ParentForm);
                //toolStrip.Font = Font;
            }
        }
        #endregion

        #region EventHandlers
        private void toolStripButton_toggleHeight_Click(object sender, EventArgs e)
        {
            
            if (Height != toolStrip.Height)
            {
                originalHeight = Height;
                Size = new Size(Width, toolStrip.Height);
                toolStripButton_toggleHeight.Image = ContentManager.GetIcon("Up");
            }
            else
            {
                Size = new Size(Width, originalHeight);
                toolStripButton_toggleHeight.Image = ContentManager.GetIcon("Down");
            } 
        }
        private void toolStripRadioButton_Click(object sender, EventArgs e)
        {
            ToolStripRadioButton button = sender as ToolStripRadioButton;
            int index = Convert.ToInt16(button.Tag);
            //LogManager.AddLogMessage(Name, "toolStripRadioButton_Click", sender.ToString() + " | " + index, LogManager.LogMessageType.DEBUG);
            tabControl.SelectedIndex = index;

        }

        private void toolStripButton_refresh_Click(object sender, EventArgs e)
        {
            UpdateUI(true);
        }
        #endregion
    }
}
