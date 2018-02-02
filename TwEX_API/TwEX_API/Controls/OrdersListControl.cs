using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Controls
{
    public partial class OrdersListControl : UserControl
    {
        #region Properties
        private string ExchangeName = String.Empty;
        public bool OpenOrders = false;
        //public int PreferredWidth = 0;
        #endregion

        #region Initialize
        public OrdersListControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void OpenOrdersListControl_Load(object sender, EventArgs e)
        {
            UpdateUI(true);
        }
        private void InitializeColumns()
        {

            //column_Icon.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            //column_Symbol.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            column_symbol.ImageGetter = new ImageGetterDelegate(aspect_symbol);
            column_market.ImageGetter = new ImageGetterDelegate(aspect_market);
            //column_Status.ImageGetter = new ImageGetterDelegate(aspect_Status);
            //column_Tickers.AspectGetter = new AspectGetterDelegate(aspect_TickerCount);
            column_amount.AspectGetter = new AspectGetterDelegate(aspect_amount);
            column_rate.AspectGetter = new AspectGetterDelegate(aspect_rate);
            column_total.AspectGetter = new AspectGetterDelegate(aspect_total);
            //column_TotalInBTC.AspectGetter = new AspectGetterDelegate(aspect_TotalInBTC);
            //column_TotalInUSD.AspectGetter = new AspectGetterDelegate(aspect_TotalInUSD);
            
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
                listView.SetObjects(ExchangeManager.Orders.Where(item => item.exchange == ExchangeName && item.open == OpenOrders).OrderByDescending(item => item.date));

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
                column_market.Width += listView.RowHeightEffective;
                column_symbol.Width += listView.RowHeightEffective;
            }
        }
        #endregion

        #region Formatters
        private void ListView_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == column_type.Index)
            {
                ExchangeOrder item = (ExchangeOrder)e.Model;
                if (item.type == "buy")
                {
                    e.SubItem.BackColor = PreferenceManager.preferences.Theme.Green;
                }
                else
                {
                    e.SubItem.BackColor = PreferenceManager.preferences.Theme.Red;
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
