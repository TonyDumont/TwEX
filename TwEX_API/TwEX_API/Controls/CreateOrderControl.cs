using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class CreateOrderControl : UserControl
    {
        #region Properties
        private ExchangeManager.Exchange Exchange;
        private string View = "buy";
        #endregion

        #region Initialize
        public CreateOrderControl()
        {
            InitializeComponent();
        }
        private void CreateOrderControl_Load(object sender, EventArgs e)
        {
            //toolStripNumberControl_total.NumericUpDownControl. = 100000000;
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
                UpdateUI(true);
            }
            return true;
        }

        delegate bool SetViewCallback(string view);
        public bool SetView(string view)
        {
            if (InvokeRequired)
            {
                SetViewCallback d = new SetViewCallback(SetView);
                Invoke(d, new object[] { view });
            }
            else
            {
                View = view;
                groupBox.Text = View.ToUpper();
                int iconSize = toolStripButton_balance.Height;
                toolStripButton_balance.Image = ContentManager.GetSymbolIcon(Exchange.CurrentTicker.market);
                toolStripButton_last.Image = ContentManager.GetSymbolIcon(Exchange.CurrentTicker.market);
                pictureBox_price.Image = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(Exchange.CurrentTicker.market), iconSize, iconSize);
                pictureBox_amount.Image = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(Exchange.CurrentTicker.symbol), iconSize, iconSize);
                pictureBox_stop.Image = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(Exchange.CurrentTicker.market), iconSize, iconSize);
                pictureBox_stop.Visible = false;
                label_stop.Visible = false;
                numericUpDown_stop.Visible = false;

                pictureBox_total.Image = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(Exchange.CurrentTicker.market), iconSize, iconSize);

                switch (View)
                {
                    case "buy":                     
                        toolStripButton_buy.Visible = true;
                        toolStripButton_sell.Visible = false;
                        toolStripLabel_last.Text = "Lowest Ask:";
                        break;

                    case "sell":
                        toolStripButton_buy.Visible = false;
                        toolStripButton_sell.Visible = true;
                        toolStripLabel_last.Text = "Highest Bid:";
                        break;

                    case "stop-limit":
                        pictureBox_stop.Visible = true;
                        label_stop.Visible = true;
                        numericUpDown_stop.Visible = true;
                        //label_price.Text = "Stop:";
                        toolStripLabel_last.Text = "You Have:";

                        toolTip.SetToolTip(numericUpDown_price, "this is the same thing as the 'Price' on a regular buy or sell order. Once your stop-limit order has been triggered by the highest bid (SELL) or lowest ask (BUY) reaching your stop price, it turns into a buy or sell order for the price you enter here.");
                        toolTip.SetToolTip(numericUpDown_stop, "think of this as the 'trigger price'. If you place a stop-limit order to sell, it will turn into a regular limit order when the highest bid drops to or below the stop. If you place a stop-limit order to buy, it will turn into a regular limit order when the lowest ask raises to or exceeds the stop.");
                        toolTip.SetToolTip(numericUpDown_amount, "this is the same as the 'Amount' on a regular buy or sell order. It indicates the amount of coins you wish to buy or sell should your stop-limit order be triggered.");
                        Enabled = false;
                        break;

                    default:
                        //AddLogMessage(Name, "OpenForm", "FORM NOT DEFINED!!! : " + name, LogMessageType.DEBUG);
                        break;
                }
                //UpdateUI(true);
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
                groupBox.Text = View.ToUpper() + " " + Exchange.CurrentTicker.symbol;

                ExchangeManager.ExchangeBalance marketBalance = ExchangeManager.Balances.FirstOrDefault(balance => 
                                                                                                        balance.Exchange == Exchange.Name &&
                                                                                                        balance.Symbol == Exchange.CurrentTicker.market);

                ExchangeManager.ExchangeBalance symbolBalance = ExchangeManager.Balances.FirstOrDefault(balance =>
                                                                                                        balance.Exchange == Exchange.Name &&
                                                                                                        balance.Symbol == Exchange.CurrentTicker.symbol);
                int iconSize = toolStripButton_balance.Height;
                Image symbolIcon = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(Exchange.CurrentTicker.symbol), iconSize, iconSize);
                Image marketIcon = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(Exchange.CurrentTicker.market), iconSize, iconSize);

                pictureBox_price.Image = marketIcon;
                pictureBox_amount.Image = symbolIcon;
                pictureBox_total.Image = marketIcon;

                if (marketBalance != null && symbolBalance != null)
                {
                    switch (View)
                    {
                        case "buy":
                            toolStripButton_balance.Text = marketBalance.Balance.ToString("N8");
                            toolStripButton_balance.Image = marketIcon;

                            toolStripButton_last.Text = Exchange.CurrentTicker.last.ToString("N8");
                            toolStripButton_last.Image = marketIcon;
                            /*
                            if (numericUpDown_price.Value == 0)
                            {
                                numericUpDown_price.Value = Exchange.CurrentTicker.last;
                            }
                            */
                            break;

                        case "sell":
                            toolStripButton_balance.Text = symbolBalance.Balance.ToString("N8");
                            toolStripButton_balance.Image = symbolIcon;

                            toolStripButton_last.Text = Exchange.CurrentTicker.last.ToString("N8");
                            toolStripButton_last.Image = marketIcon;
                            /*
                            if (numericUpDown_price.Value == 0)
                            {
                                numericUpDown_price.Value = Exchange.CurrentTicker.last;
                            }
                            */
                            break;

                        case "stop-limit":
                            toolStripButton_balance.Text = marketBalance.Balance.ToString("N8");
                            toolStripButton_balance.Image = marketIcon;

                            //toolStripLabel_last.Text
                            toolStripButton_last.Text = symbolBalance.Balance.ToString("N8");
                            toolStripButton_last.Image = symbolIcon;
                            break;

                        default:
                            //AddLogMessage(Name, "OpenForm", "FORM NOT DEFINED!!! : " + name, LogMessageType.DEBUG);
                            break;
                    }

                    if (numericUpDown_price.Value == 0)
                    {
                        numericUpDown_price.Value = Exchange.CurrentTicker.last;
                    }

                }
                /*
                //toolStripButton_balance.Text = Exchange.CurrentTicker.m;
                //toolStripButton_balance.Image = ContentManager.GetSymbolIcon(Exchange.CurrentTicker.symbol);
                
                if (View != "stop-limit")
                {
                    toolStripButton_last.Text = 
                }
                */

                if (resize)
                {
                    ResizeUI();
                }
            }
            return true;
        }

        delegate void ResetUICallback();
        public void ResetUI()
        {
            if (InvokeRequired)
            {
                ResetUICallback d = new ResetUICallback(ResetUI);
                Invoke(d, new object[] { });
            }
            else
            {
                groupBox.Text = View.ToUpper() + " " + Exchange.CurrentTicker.symbol;

                ExchangeManager.ExchangeBalance marketBalance = ExchangeManager.Balances.FirstOrDefault(balance =>
                                                                                                        balance.Exchange == Exchange.Name &&
                                                                                                        balance.Symbol == Exchange.CurrentTicker.market);

                ExchangeManager.ExchangeBalance symbolBalance = ExchangeManager.Balances.FirstOrDefault(balance =>
                                                                                                        balance.Exchange == Exchange.Name &&
                                                                                                        balance.Symbol == Exchange.CurrentTicker.symbol);
                int iconSize = toolStripButton_balance.Height;
                Image symbolIcon = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(Exchange.CurrentTicker.symbol), iconSize, iconSize);
                Image marketIcon = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(Exchange.CurrentTicker.market), iconSize, iconSize);

                pictureBox_price.Image = marketIcon;
                pictureBox_amount.Image = symbolIcon;
                pictureBox_total.Image = marketIcon;

                numericUpDown_price.Value = 0;
                numericUpDown_stop.Value = 0;
                numericUpDown_amount.Value = 0;
                numericUpDown_total.Value = 0;
                UpdateUI();
            }
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
                //toolStrip_balance.Font = Font;
                //toolStrip_last.Font = Font;
                //toolStrip_footer.Font = Font;
                //toolStrip.Font = Font;
            }
        }
        #endregion

        #region EventHandlers
        private void numericUpDown_amount_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_total.Value = numericUpDown_price.Value * numericUpDown_amount.Value;
        }
        private void numericUpDown_price_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_total.Value = numericUpDown_price.Value * numericUpDown_amount.Value;
        }
        private void numericUpDown_total_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_total.Value > 0 && numericUpDown_price.Value > 0)
            {
                numericUpDown_amount.Value = numericUpDown_total.Value / numericUpDown_price.Value;
            }
        }
        private void toolStripButton_balance_Click(object sender, EventArgs e)
        {
            if (View != "sell")
            {
                numericUpDown_total.Value = Convert.ToDecimal(toolStripButton_balance.Text);
            }
            else
            {
                numericUpDown_amount.Value = Convert.ToDecimal(toolStripButton_balance.Text);
            }
        }
        private void toolStripButton_buy_Click(object sender, EventArgs e)
        {
            ExchangeManager.ExchangeBalance marketBalance = ExchangeManager.Balances.FirstOrDefault(balance =>
                                                                                                        balance.Exchange == Exchange.Name &&
                                                                                                        balance.Symbol == Exchange.CurrentTicker.market);

            if (numericUpDown_total.Value == 0 || numericUpDown_amount.Value == 0)
            {
                MessageBox.Show("No Amount Or Total To Process", "EMPTY ORDER");
            }
            else
            {
                if (numericUpDown_total.Value > marketBalance.Balance)
                {
                    MessageBox.Show("Not Enough Funds For This Buy", "INSUFFICIENT FUNDS");
                }
                else
                {
                    if (View != "stop-limit")
                    {
                        string message = "Buy : " + numericUpDown_amount.Value.ToString("N8") + " " + Exchange.CurrentTicker.symbol + " @ Price : " + numericUpDown_price.Value.ToString("N8") + " " + Exchange.CurrentTicker.market;
                        string title = "TOTAL : " + numericUpDown_total.Value.ToString("N8") + " " + Exchange.CurrentTicker.market;
                        DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                            LogManager.AddLogMessage(Name, "toolStripButton_buy_Click", "THIS BUY FUNCTION NEEDS TO BE ENABLED", LogManager.LogMessageType.DEBUG);
                            ExchangeManager.CreateNewOrder(Exchange.Name, ExchangeManager.ExchangeOrderType.buy, Exchange.CurrentTicker.symbol, Exchange.CurrentTicker.market, numericUpDown_price.Value, numericUpDown_amount.Value);

                            numericUpDown_amount.Value = 0;
                            numericUpDown_total.Value = 0;
                        }
                    }
                    else
                    {
                        //string message = "STOP-LIMIT Buy : " + numericUpDown_amount.Value.ToString("N8") + " " + Exchange.CurrentTicker.symbol + 
                        //" @ Price : " + numericUpDown_price.Value.ToString("N8") + " " + Exchange.CurrentTicker.market + 
                        //" With STOP LIMIT OF " + numericUpDown_stop.Value;
                        string message = "If the lowest ask rises to or above " + numericUpDown_stop.Value + " " + Exchange.CurrentTicker.market + 
                                            ", An order to buy " + numericUpDown_amount.Value + " " + Exchange.CurrentTicker.symbol + 
                                            " at a price of " + numericUpDown_price.Value + " " + Exchange.CurrentTicker.market + " will be placed.";

                        string title = "STOP-LIMIT BUY for " + numericUpDown_amount.Value + " " + Exchange.CurrentTicker.symbol + " @ " + numericUpDown_total.Value.ToString("N8") + " " + Exchange.CurrentTicker.market;
                        DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                            LogManager.AddLogMessage(Name, "toolStripButton_buy_Click", "THIS STOP-LIMIT BUY FUNCTION NEEDS TO BE ENABLED", LogManager.LogMessageType.DEBUG);
                            numericUpDown_amount.Value = 0;
                            numericUpDown_total.Value = 0;
                        }
                    }
                    
                }
            }
        }
        private void toolStripButton_last_Click(object sender, EventArgs e)
        {
            if (View != "stop-limit")
            {
                numericUpDown_price.Value = Convert.ToDecimal(toolStripButton_last.Text);
            }
            else
            {
                numericUpDown_amount.Value = Convert.ToDecimal(toolStripButton_last.Text);
            }
        }
        private void toolStripButton_sell_Click(object sender, EventArgs e)
        {
            /*
            ExchangeManager.ExchangeBalance marketBalance = ExchangeManager.Balances.FirstOrDefault(balance =>
                                                                                                        balance.Exchange == Exchange.Name &&
                                                                                                        balance.Symbol == Exchange.CurrentTicker.market);
                                                                                                        */
            ExchangeManager.ExchangeBalance symbolBalance = ExchangeManager.Balances.FirstOrDefault(balance =>
                                                                                                        balance.Exchange == Exchange.Name &&
                                                                                                        balance.Symbol == Exchange.CurrentTicker.symbol);

            if (numericUpDown_total.Value == 0 || numericUpDown_amount.Value == 0)
            {
                MessageBox.Show("No Amount Or Total To Process", "EMPTY ORDER");
            }
            else
            {
                if (numericUpDown_total.Value > symbolBalance.Balance)
                {
                    MessageBox.Show("Not Enough Funds For This Sell", "INSUFFICIENT FUNDS");
                }
                else
                {
                    if (View != "stop-limit")
                    {
                        string message = "Sell : " + numericUpDown_amount.Value.ToString("N8") + " " + Exchange.CurrentTicker.symbol + " @ Price : " + numericUpDown_price.Value.ToString("N8") + " " + Exchange.CurrentTicker.market;
                        string title = "TOTAL : " + numericUpDown_total.Value.ToString("N8") + " " + Exchange.CurrentTicker.market;
                        DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                            LogManager.AddLogMessage(Name, "toolStripButton_sell_Click", "THIS SELL FUNCTION NEEDS TO BE ENABLED", LogManager.LogMessageType.DEBUG);
                            numericUpDown_amount.Value = 0;
                            numericUpDown_total.Value = 0;
                        }
                    }
                    else
                    {
                        //string message = "STOP-LIMIT Buy : " + numericUpDown_amount.Value.ToString("N8") + " " + Exchange.CurrentTicker.symbol + 
                        //" @ Price : " + numericUpDown_price.Value.ToString("N8") + " " + Exchange.CurrentTicker.market + 
                        //" With STOP LIMIT OF " + numericUpDown_stop.Value;
                        string message = "If the highest bid drops to or below " + numericUpDown_stop.Value + " " + Exchange.CurrentTicker.market +
                                            ", An order to sell " + numericUpDown_amount.Value + " " + Exchange.CurrentTicker.symbol +
                                            " at a price of " + numericUpDown_price.Value + " " + Exchange.CurrentTicker.market + " will be placed.";

                        string title = "STOP-LIMIT SELL for " + numericUpDown_amount.Value + " " + Exchange.CurrentTicker.symbol + " @ " + numericUpDown_total.Value.ToString("N8") + " " + Exchange.CurrentTicker.market;
                        DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                            LogManager.AddLogMessage(Name, "toolStripButton_sell_Click", "THIS STOP-LIMIT SELL FUNCTION NEEDS TO BE ENABLED", LogManager.LogMessageType.DEBUG);
                            numericUpDown_amount.Value = 0;
                            numericUpDown_total.Value = 0;
                        }
                    }

                }
            }

            /*
            string title = "Sell " + numericUpDown_amount.Value.ToString("N8") + " " + Exchange.CurrentTicker.symbol + " @ " + numericUpDown_price.Value.ToString("N8");
            string message = "TOTAL : " + numericUpDown_total.Value.ToString("N8") + " " + Exchange.CurrentTicker.market;
            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }



            //MessageBox.Show(message, title);
            */
        }
        #endregion
    }
}
