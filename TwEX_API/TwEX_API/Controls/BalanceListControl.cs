using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace TwEX_API.Controls
{
    public partial class BalanceListControl : UserControl
    {
        #region Properties
        private string ExchangeName = String.Empty;
        public int PreferredWidth = 0;
        #endregion

        #region Initialize
        public BalanceListControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void BalanceListControl_Load(object sender, EventArgs e)
        {

        }
        private void InitializeColumns()
        {
            //column_Icon.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            column_Symbol.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            
            //column_Status.ImageGetter = new ImageGetterDelegate(aspect_Status);
            //column_Tickers.AspectGetter = new AspectGetterDelegate(aspect_TickerCount);
            column_Orders.AspectGetter = new AspectGetterDelegate(aspect_TotalInBTCOrders);
            column_TotalInBTC.AspectGetter = new AspectGetterDelegate(aspect_TotalInBTC);
            column_TotalInUSD.AspectGetter = new AspectGetterDelegate(aspect_TotalInUSD);
            
        }
        #endregion

        #region Delegates
        delegate bool SetExchangeCallback(string exchange);
        public bool SetExchange(string exchange)
        {
            if (InvokeRequired)
            {
                SetExchangeCallback d = new SetExchangeCallback(SetExchange);
                Invoke(d, new object[] {  });
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
                List<ExchangeManager.ExchangeBalance> list = ExchangeManager.Balances.Where(item => item.Exchange == ExchangeName && item.Balance > 0).ToList();
                listView.SetObjects(list);
                toolStripLabel_title.Text = list.Count + " Balances";
                toolStripLabel_totals.Text = "(" + list.Sum(item => item.TotalInUSD).ToString("C") + ") " + list.Sum(item => item.TotalInBTC).ToString("N8");
                //List<ExchangeManager.ExchangeBalance> list = ExchangeManager.Balances.Where(item => item.Balance > 0).ToList();


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
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                Font = PreferenceManager.preferences.Font;
                toolStrip.Font = Font;
                //toolStrip_header2.Font = ParentForm.Font;
                listView.Font = Font;
 
                Size textSize = TextRenderer.MeasureText("0.00000000", Font);

                int rowHeight = listView.RowHeightEffective;
                //int padding = rowHeight / 2;

                int iconSize = rowHeight;

                toolStrip.ImageScalingSize = new Size(iconSize, iconSize);

                //column_Symbol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                //column_Symbol.Width = column_Symbol.Width + (iconSize * 2);
                column_Symbol.Width = textSize.Width;

                column_Balance.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                column_Orders.Width = textSize.Width;
                column_TotalInBTC.Width = textSize.Width;
                column_TotalInUSD.Width = textSize.Width;

                
                int listWidth = 0;
                //int listHeight = 0;
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    //col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //col.Width = col.Width + (rowHeight / 2);
                    listWidth += col.Width;
                }
                PreferredWidth = listWidth + (iconSize * 2);
                LogManager.AddLogMessage(Name, "ResizeUI", "PreferredWidth = " + PreferredWidth);
                //listView.Width = listWidth;
                //ClientSize = new Size(listWidth, Height);
                //Size = new Size(listWidth, Height);
                //Size = new Size(listWidth, Height);

                //column_Tickers.Width = 
                /*
                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 1];
                    listHeight = listView.Top + last.Bounds.Bottom;
                    //listHeight = last.Bounds.Bottom;
                    //LogManager.AddLogMessage(Name, "ResizeUI", listView.Top + " | " + last.Bounds.Bottom + " | " + listHeight);
                }
                listHeight += listView.RowHeightEffective;
                //listView.Height = listHeight + listView.RowHeightEffective;
                */

                /*
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //col.Width = col.Width + (rowHeight / 2);
                    //listWidth += col.Width;
                }
                */
                //toolStrip_header2.ImageScalingSize = new Size(iconSize, iconSize);
                /*
                //column_Icon.Width = iconSize + 2;
                column_Status.Width = iconSize + 2;

                column_Name.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_Name.Width = column_Name.Width + padding;
                */

                //column_Coins.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                /*
                
                */



                /*
                if (Parent.GetType() == typeof(Form))
                {
                    Form form = this.Parent as Form;
                    Rectangle screenRectangle = RectangleToScreen(form.ClientRectangle);
                    int titleHeight = screenRectangle.Top - form.Top;
                    int formHeight = titleHeight + listHeight;
                    int totalHeight = titleHeight + listHeight + toolStrip_header.Height + toolStrip_header2.Height + padding;
                    //LogManager.AddLogMessage(Name, "ResizeUI", "titleHeight=" + titleHeight + " | listHeight=" + listHeight + " | " + toolStrip_header.Height + " | " + toolStrip_header2.Height);
                    form.ClientSize = new Size(listWidth + (padding* 2), totalHeight);
                }
                */
            }
        }
        #endregion

        #region Getters
        private object aspect_Icon(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;
            int rowheight = listView.RowHeightEffective;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(balance.Symbol), rowheight, rowheight);
            //return ContentManager.GetExchangeIcon(exchange.Name);
        }
        public object aspect_TotalInBTCOrders(object rowObject)
        {
            ExchangeManager.ExchangeBalance balance = (ExchangeManager.ExchangeBalance)rowObject;
            return balance.TotalInBTCOrders.ToString("N8");
        }
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
        #endregion
    }
}
