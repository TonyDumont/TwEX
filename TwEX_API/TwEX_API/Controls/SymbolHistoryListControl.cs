using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace TwEX_API.Controls
{
    public partial class SymbolHistoryListControl : UserControl
    {
        #region Properties
        private ExchangeManager.Exchange Exchange;
        //public bool OpenOrders = false;
        #endregion

        #region Initialize
        public SymbolHistoryListControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void SymbolHistoryListControl_Load(object sender, EventArgs e)
        {

        }
        private void InitializeColumns()
        {
            column_symbol.ImageGetter = new ImageGetterDelegate(aspect_symbol);
            column_market.ImageGetter = new ImageGetterDelegate(aspect_market);
            column_amount.AspectGetter = new AspectGetterDelegate(aspect_amount);
            column_rate.AspectGetter = new AspectGetterDelegate(aspect_rate);
            column_total.AspectGetter = new AspectGetterDelegate(aspect_total);
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
                //if (Exchange != null)
                //{
                    List<ExchangeManager.ExchangeOrder> orders = ExchangeManager.Orders.Where(item => item.exchange == Exchange.Name && item.symbol == Exchange.CurrentTicker.symbol).ToList();
                    List<ExchangeManager.ExchangeTransaction> transactions = ExchangeManager.Transactions.Where(item => item.exchange == Exchange.Name && item.currency == Exchange.CurrentTicker.symbol).ToList();

                    foreach (ExchangeManager.ExchangeTransaction transaction in transactions)
                    {
                        ExchangeManager.ExchangeOrder newItem = new ExchangeManager.ExchangeOrder()
                        {
                            id = transaction.id,
                            type = transaction.type.ToString(),
                            amount = transaction.amount,
                            total = transaction.amount,
                            date = transaction.datetime,
                            symbol = transaction.currency,
                            market = transaction.currency,
                            open = false
                        };
                        orders.Add(newItem);
                    }

                    listView.SetObjects(orders.OrderByDescending(item => item.date));

                    if (resize)
                    {
                        ResizeUI();
                    }
                //}
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
                //Font = PreferenceManager.preferences.Font;
                //listView.Font = Font;
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + listView.RowHeightEffective;
                    //listWidth += col.Width;
                }
                //column_market.Width += listView.RowHeightEffective;
                //column_symbol.Width += listView.RowHeightEffective;
            }
        }
        #endregion

        #region Formatters
        private void ListView_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == column_type.Index)
            {
                ExchangeManager.ExchangeOrder item = (ExchangeManager.ExchangeOrder)e.Model;

                switch (item.type)
                {
                    case "deposit":
                    case "payin":
                    case "buy":
                        e.SubItem.BackColor = PreferenceManager.preferences.Theme.Green;
                        break;

                    case "withdrawal":
                    case "fee":
                    case "payout":
                    case "sell":
                        e.SubItem.BackColor = PreferenceManager.preferences.Theme.Red;
                        break;

                    default:
                        e.SubItem.BackColor = PreferenceManager.preferences.Theme.Yellow;
                        break;
                }
            }
        }
        #endregion

        #region Getters
        private object aspect_symbol(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            ExchangeManager.ExchangeOrder order = (ExchangeManager.ExchangeOrder)rowObject;
            int rowheight = listView.RowHeightEffective;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(order.symbol), rowheight, rowheight);
            //return ContentManager.GetExchangeIcon(exchange.Name);
        }
        private object aspect_market(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            ExchangeManager.ExchangeOrder order = (ExchangeManager.ExchangeOrder)rowObject;
            int rowheight = listView.RowHeightEffective;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(order.market), rowheight, rowheight);
            //return ContentManager.GetExchangeIcon(exchange.Name);
        }
        public object aspect_amount(object rowObject)
        {
            ExchangeManager.ExchangeOrder order = (ExchangeManager.ExchangeOrder)rowObject;
            return order.amount.ToString("N8");
            /*
            if (order.market.Contains("USD"))
            {
                return order.amount.ToString("C");
            }
            else
            {
                return order.amount.ToString("N8");
            }
            */
        }
        public object aspect_rate(object rowObject)
        {
            ExchangeManager.ExchangeOrder order = (ExchangeManager.ExchangeOrder)rowObject;
            if (order.rate > 0)
            {
                if (order.market.Contains("USD"))
                {
                    return order.rate.ToString("C");
                }
                else
                {
                    return order.rate.ToString("N8");
                }
            }
            else
            {
                return String.Empty;
            }
        }
        public object aspect_total(object rowObject)
        {
            ExchangeManager.ExchangeOrder order = (ExchangeManager.ExchangeOrder)rowObject;
            if (order.market.Contains("USD"))
            {
                return order.total.ToString("C");
            }
            else
            {
                return order.total.ToString("N8");
            }
        }
        /*
        public object aspect_TotalInBTC(object rowObject)
        {
            ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;
            return balance.TotalInBTC.ToString("N8");
        }
        public object aspect_TotalInUSD(object rowObject)
        {
            ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;
            return balance.TotalInUSD.ToString("C");
        }
        */
        #endregion
    }
}
