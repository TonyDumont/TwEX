using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TwEX_API.ExchangeManager;
using BrightIdeasSoftware;

namespace TwEX_API.Controls
{
    public partial class TransactionsListControl : UserControl
    {
        #region Properties
        private string ExchangeName = String.Empty;
        public ExchangeTransactionType type = ExchangeTransactionType.deposit;
        //public bool OpenOrders = false;
        //public int PreferredWidth = 0;
        #endregion

        #region Initialize
        public TransactionsListControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void TransactionsListControl_Load(object sender, EventArgs e)
        {
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            
            //column_Icon.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            //column_Symbol.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            column_currency.ImageGetter = new ImageGetterDelegate(aspect_currency);
            /*
            column_market.ImageGetter = new ImageGetterDelegate(aspect_market);
            //column_Status.ImageGetter = new ImageGetterDelegate(aspect_Status);
            //column_Tickers.AspectGetter = new AspectGetterDelegate(aspect_TickerCount);
            column_amount.AspectGetter = new AspectGetterDelegate(aspect_amount);
            column_rate.AspectGetter = new AspectGetterDelegate(aspect_rate);
            column_total.AspectGetter = new AspectGetterDelegate(aspect_total);
            //column_TotalInBTC.AspectGetter = new AspectGetterDelegate(aspect_TotalInBTC);
            //column_TotalInUSD.AspectGetter = new AspectGetterDelegate(aspect_TotalInUSD);
            */
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
                listView.SetObjects(Transactions.Where(item => item.type == type && item.exchange == ExchangeName));

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
                
                Font = PreferenceManager.preferences.Font;
                listView.Font = Font;
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

        #region Getters
        private object aspect_currency(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            ExchangeTransaction transaction = (ExchangeTransaction)rowObject;
            int rowheight = listView.RowHeightEffective;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(transaction.currency), rowheight, rowheight);
            //return ContentManager.GetExchangeIcon(exchange.Name);
        }
        /*
        private object aspect_market(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            ExchangeManager.ExchangeOrder order = (ExchangeManager.ExchangeOrder)rowObject;
            int rowheight = listView.RowHeightEffective;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(order.market), rowheight, rowheight);
            //return ContentManager.GetExchangeIcon(exchange.Name);
        }
        */
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
            if (order.market.Contains("USD"))
            {
                return order.rate.ToString("C");
            }
            else
            {
                return order.rate.ToString("N8");
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
