using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Controls
{
    public partial class OrderViewControl : UserControl
    {
        #region Initialize
        public OrderViewControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void OrderViewControl_Load(object sender, EventArgs e)
        {
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_exchange.ImageGetter = new ImageGetterDelegate(aspect_exchange);
            column_symbol.ImageGetter = new ImageGetterDelegate(aspect_symbol);
            column_market.ImageGetter = new ImageGetterDelegate(aspect_market);
            column_amount.AspectGetter = new AspectGetterDelegate(aspect_amount);
            column_rate.AspectGetter = new AspectGetterDelegate(aspect_rate);
            column_total.AspectGetter = new AspectGetterDelegate(aspect_total);
            //column_spread.AspectGetter = new AspectGetterDelegate(aspect_spread);
        }
        #endregion

        #region Delegates
        /*
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
                UpdateUI(true);
            }
            return true;
        }
        */
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
                //List<ExchangeManager.ExchangeBalance> balances = ExchangeManager.Balances.Where(balance => balance.OnOrders > 0).ToList();
                List<ExchangeOrder> orders = Orders.Where(order => order.open == true).ToList();
                //LogManager.AddLogMessage(Name, "UpdateUI", "count=" + ExchangeManager.Orders.Count + " | " + balances.Count, LogManager.LogMessageType.DEBUG);
                /*
                foreach (ExchangeManager.ExchangeOrder order in orders)
                {
                    LogManager.AddLogMessage(Name, "UpdateUI", "order : " + order.open + " | " + order.exchange + " | " + order.symbol + " | " + order.market + " | " + order.total, LogManager.LogMessageType.DEBUG);
                }
                */
                //listView.SetObjects(ExchangeManager.Orders.Where(item => item.exchange == Exchange.Name && item.open == OpenOrders).OrderByDescending(item => item.date));
                //listView.SetObjects(ExchangeManager.Orders.Where(order => order.open == true));
                listView.SetObjects(orders);

                //toolStripLabel_status.Text = roots.Count() + " Coins | " + list.Sum(b => b.TotalInBTC).ToString("N8") + " | " + list.Sum(b => b.TotalInUSD).ToString("C");

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
                Visible = false;
                //Font = PreferenceManager.preferences.Font;
                int iconSize = listView.RowHeightEffective;
                //listView.Font = Font;

                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + listView.RowHeightEffective;
                    //listWidth += col.Width;
                }
                //column_exchange.Width = iconSize;
                //column_market.Width = iconSize;
                column_rate.Width += iconSize;
                column_symbol.Width += iconSize;
                Visible = true;
            }
        }
        #endregion

        #region Getters
        private object aspect_exchange(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            ExchangeManager.ExchangeOrder order = (ExchangeManager.ExchangeOrder)rowObject;
            int rowheight = listView.RowHeightEffective;
            return ContentManager.ResizeImage(ContentManager.GetExchangeIcon(order.exchange), rowheight, rowheight);
            //return ContentManager.GetExchangeIcon(exchange.Name);
        }
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
            ExchangeOrder order = (ExchangeOrder)rowObject;
            /*
            if (order.market.Contains("USD"))
            {
                return order.rate.ToString("C");
            }
            else
            {
                double rate = order.rate * 100000000;
                return rate + "B";
            }
            */
            //List<ExchangeTicker> list = Tickers.Where(item => item.exchange == order.exchange).ToList();
            //LogManager.AddLogMessage(Name, "aspect_spread", order.exchange + " | " + order.symbol + " | " + order.market + " | " + order.rate + " | " + list.Count, LogManager.LogMessageType.DEBUG);
            ExchangeTicker ticker = Tickers.FirstOrDefault(item => item.exchange == order.exchange && item.symbol == order.symbol && item.market == order.market);

            if (ticker != null)
            {

                if (order.market.Contains("USD"))
                {
                    return  ticker.last.ToString("C") + " / " + order.rate.ToString("C");
                }
                else
                {
                    decimal rate = Convert.ToDecimal(order.rate) * 100000000;
                    decimal last = ticker.last * 100000000;
                    return last.ToString("N0") + " / " + rate.ToString("N0");
                }

                //column_symbol.Width += 
                //LogManager.AddLogMessage(Name, "aspect_spread", "rate=" + order.rate + " | " + ticker.last, LogManager.LogMessageType.DEBUG);
                //return 0;
            }
            else
            {
                //LogManager.AddLogMessage(Name, "aspect_spread", "NO TICKER=" + order.exchange + " | " + order.symbol + " | " + order.market, LogManager.LogMessageType.DEBUG);
                return 0;
            }

        }
        public object aspect_spread(object rowObject)
        {
            ExchangeOrder order = (ExchangeOrder)rowObject;
            //LogManager.AddLogMessage(Name, "aspect_spread", "rate=" + order.symbol + " | " + order.market + " | " + order.amount, LogManager.LogMessageType.DEBUG);
            
            ExchangeTicker ticker = Tickers.FirstOrDefault(item => item.exchange == order.exchange && item.symbol == order.symbol && item.market == order.market);
            if (ticker != null)
            {
                
                if (order.market.Contains("USD"))
                {
                    return ticker.last.ToString("C");
                }
                else
                {
                    return ticker.last.ToString("N8");
                }
                
                //LogManager.AddLogMessage(Name, "aspect_spread", "rate=" + order.rate + " | " + ticker.last, LogManager.LogMessageType.DEBUG);
                //return 0;
            }
            else
            {
                return 0;
            }

            //return "10%";
        }
        public object aspect_total(object rowObject)
        {
            ExchangeOrder order = (ExchangeOrder)rowObject;
            if (order.market.Contains("USD"))
            {
                return order.total.ToString("C");
            }
            else
            {
                return order.total.ToString("N8");
            }
        }
        #endregion

        #region Formatters
        private void ListView_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == column_exchange.Index)
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
