using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TwEX_API.Exchange;

namespace TwEX_API.Controls
{
    public partial class HistoryTabControl : UserControl
    {
        private string ExchangeName = String.Empty;
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
            toolStripRadioButton_open.Image = Properties.Resources.ConnectionStatus_UNKNOWN;
            toolStripRadioButton_closed.Image = Properties.Resources.ConnectionStatus_DISABLED;
            ordersListControl_open.OpenOrders = true;
            ordersListControl_closed.OpenOrders = false;
            transactionsListControl_deposits.type = ExchangeManager.ExchangeTransactionType.deposit;
            transactionsListControl_withdraw.type = ExchangeManager.ExchangeTransactionType.withdrawal;
            UpdateUI(true);
        }
        #endregion

        #region Delegates
        
        delegate bool SetExchangeCallback(string exchange);
        public bool SetExchange(string exchange)
        {
            if (InvokeRequired)
            {
                SetExchangeCallback d = new SetExchangeCallback(SetExchange);
                Invoke(d, new object[] { });
            }
            else
            {
                ExchangeName = exchange;
                ordersListControl_open.SetExchange(exchange);
                ordersListControl_closed.SetExchange(exchange);
                transactionsListControl_deposits.SetExchange(exchange);
                transactionsListControl_withdraw.SetExchange(exchange);

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
                toolStripRadioButton_open.Text = ExchangeManager.Orders.Where(item => item.exchange == ExchangeName && item.open == true).Count() + " OPEN";
                toolStripRadioButton_closed.Text = ExchangeManager.Orders.Where(item => item.exchange == ExchangeName && item.open == false).Count() + " CLOSED";
                toolStripRadioButton_deposits.Text = ExchangeManager.Transactions.Where(item => item.exchange == ExchangeName && item.type == ExchangeManager.ExchangeTransactionType.deposit).Count() + " DEPOSITS";
                toolStripRadioButton_withdrawals.Text = ExchangeManager.Transactions.Where(item => item.exchange == ExchangeName && item.type == ExchangeManager.ExchangeTransactionType.withdrawal).Count() + " WITHDRAWALS";

                ordersListControl_open.UpdateUI(resize);
                ordersListControl_closed.UpdateUI(resize);
                transactionsListControl_deposits.UpdateUI(resize);
                transactionsListControl_withdraw.UpdateUI(resize);

                if (resize)
                {
                    ResizeUI();
                }
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
                
            }
        }
        #endregion


        #region EventHandlers
        private void toolStripButton_toggleHeight_Click(object sender, EventArgs e)
        {
            //Bittrex.updateExchangeTransactionList();
            //BleuTrade.updateExchangeTransactionList();
            //Cryptopia.updateExchangeTransactionList();
            //GateIO.updateExchangeTransactionList();
            //GDAX.updateExchangeTransactionList();
            //HitBTC.updateExchangeTransactionList();
            //LiveCoin.updateExchangeTransactionList();
            //Poloniex.updateExchangeTransactionList();
            
            if (Height != toolStrip.Height)
            {
                originalHeight = Height;
                Size = new Size(Width, toolStrip.Height);
            }
            else
            {
                Size = new Size(Width, originalHeight);
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
        /*
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UpdateUI(true);
        }
        */
    }
}
