using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using TwEX_API.Market;

namespace TwEX_API.Controls
{
    public partial class ExchangeEditorControl : UserControl
    {
        #region Initialize
        public ExchangeEditorControl()
        {
            InitializeComponent();
            FormManager.exchangeEditorControl = this;
            InitializeColumns();
        }
        private void ExchangeEditorControl_Load(object sender, EventArgs e)
        {
            //toolStripButton_Font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            toolStripDropDownButton_menu.Image = ContentManager.GetIconByUrl(ContentManager.PreferenceIconUrl);
            toolStripMenuItem_font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIconByUrl(ContentManager.FontIconIncrease);
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIconByUrl(ContentManager.FontIconDecrease);
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_Icon.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            column_Status.ImageGetter = new ImageGetterDelegate(aspect_Status);
            column_Tickers.AspectGetter = new AspectGetterDelegate(aspect_TickerCount);
            column_Orders.AspectGetter = new AspectGetterDelegate(aspect_TotalInBTCOrders);
            column_TotalInBTC.AspectGetter = new AspectGetterDelegate(aspect_TotalInBTC);
            column_TotalInUSD.AspectGetter = new AspectGetterDelegate(aspect_TotalInUSD);
        }
        #endregion

        #region Delegates
        delegate bool UpdateUICallback(bool resize = false);
        public bool UpdateUI(bool resize = false)
        {
            if (this.InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                this.Invoke(d, new object[] { resize });
            }
            else
            {
                // HEADER
                toolStripLabel_Exchanges.Text = ExchangeManager.Exchanges.Count + " Exchanges";
                
                Decimal orderBTC = ExchangeManager.Balances.Sum(balance => balance.TotalInBTCOrders);
                Decimal orderUSD = CoinMarketCap.getUSDValue("BTC", orderBTC);
                string orderString = "Orders : (" + orderUSD.ToString("C") + ") " + orderBTC.ToString("N8");
                toolStripLabel_Orders.Text = orderString;
                
                Decimal totalBTC = ExchangeManager.Balances.Sum(balance => balance.TotalInBTC);
                Decimal totalUSD = ExchangeManager.Exchanges.Sum(exchange => exchange.BalanceList.Sum(balance => balance.TotalInUSD));
                toolStripButton_Totals.Text = "Totals : (" + totalUSD.ToString("C") + ") " + totalBTC.ToString("N8");

                // LIST
                listView.SetObjects(ExchangeManager.Exchanges);
                listView.Sort(column_TotalInBTC, SortOrder.Descending);

                // TIMERS
                toolStripButton_Tickers.Checked = (PreferenceManager.preferences.TimerFlags & ExchangeManager.ExchangeTimerType.TICKERS) != ExchangeManager.ExchangeTimerType.NONE;
                toolStripButton_Tickers.Text = "TICKERS (" + ExchangeManager.Tickers.Count + ")";
                toolStripButton_Tickers.Image = ContentManager.GetActiveIcon(toolStripButton_Tickers.Checked);

                toolStripButton_Balances.Checked = (PreferenceManager.preferences.TimerFlags & ExchangeManager.ExchangeTimerType.BALANCES) != ExchangeManager.ExchangeTimerType.NONE;
                toolStripButton_Balances.Text = "BALANCES (" + ExchangeManager.Balances.Count + ")";
                toolStripButton_Balances.Image = ContentManager.GetActiveIcon(toolStripButton_Balances.Checked);

                toolStripButton_Orders.Checked = (PreferenceManager.preferences.TimerFlags & ExchangeManager.ExchangeTimerType.ORDERS) != ExchangeManager.ExchangeTimerType.NONE;
                toolStripButton_Orders.Image = ContentManager.GetActiveIcon(toolStripButton_Orders.Checked);

                toolStripButton_History.Checked = (PreferenceManager.preferences.TimerFlags & ExchangeManager.ExchangeTimerType.HISTORY) != ExchangeManager.ExchangeTimerType.NONE;
                toolStripButton_History.Image = ContentManager.GetActiveIcon(toolStripButton_History.Checked);
                
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
            if (this.InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                this.Invoke(d, new object[] { });
            }
            else
            {
                toolStrip_header.Font = ParentForm.Font;
                toolStrip_header2.Font = ParentForm.Font;
                listView.Font = ParentForm.Font;
                
                Size textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);
                int rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;

                int iconSize = rowHeight - 2;

                toolStrip_header.ImageScalingSize = new Size(iconSize, iconSize);
                toolStrip_header2.ImageScalingSize = new Size(iconSize, iconSize);

                column_Icon.Width = iconSize + 2;
                column_Status.Width = iconSize + 2;
                
                column_Name.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_Name.Width = column_Name.Width + padding;

                column_Coins.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_Orders.Width = textSize.Width;
                column_TotalInBTC.Width = textSize.Width;
                column_TotalInUSD.Width = textSize.Width;

                int listWidth = 0;
                int listHeight = 0;
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    //col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //col.Width = col.Width + (rowHeight / 2);
                    listWidth += col.Width;
                }

                //column_Tickers.Width = 

                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 4];
                    listHeight = listView.Top + last.Bounds.Bottom;
                }
                  
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
            }
        }
        #endregion

        #region Getters
        private object aspect_Icon(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)rowObject;
            int rowheight = listView.RowHeightEffective - 3;
            return ContentManager.ResizeImage(exchange.Icon, rowheight, rowheight);
        }
        private object aspect_Status(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)rowObject;
            int rowheight = listView.RowHeightEffective - 12;

            if (exchange.LastUpdate.ToUniversalTime().AddMinutes(5) < DateTime.UtcNow)
            {
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_ERROR, rowheight, rowheight);
            }
            else
            {
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_ACTIVE, rowheight, rowheight);
            }
        }
        public object aspect_TotalInBTCOrders(object rowObject)
        {
            ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)rowObject;
            return exchange.TotalInBTCOrders.ToString("N8");
        }
        public object aspect_TotalInBTC(object rowObject)
        {
            ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)rowObject;
            return exchange.TotalInBTC.ToString("N8");
        }
        public object aspect_TotalInUSD(object rowObject)
        {
            ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)rowObject;
            return exchange.TotalInUSD.ToString("C");
        }
        private object aspect_TickerCount(object rowObject)
        {
            ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)rowObject;
            return exchange.TickerList.Count;
        }
        /*
        private Image getTimerActiveIcon(bool active)
        {
            if (active)
            {
                return Properties.Resources.ConnectionStatus_ACTIVE;
            }
            else
            {
                return Properties.Resources.ConnectionStatus_ERROR;
            }
        }
        */
        #endregion

        #region Event_Handlers
        private void toolStripButton_API_Click(object sender, EventArgs e)
        {
            if (listView.SelectedObject != null)
            {
                ExchangeManager.Exchange exchange = listView.SelectedObject as ExchangeManager.Exchange;
                Form form = new Form();
                form.Size = new Size(500, 250);
                form.Text = exchange.Name;
                Bitmap bitmap = new Bitmap(exchange.Icon);
                form.Icon = Icon.FromHandle(bitmap.GetHicon());
                APIEditorControl control = new APIEditorControl();
                control.SetApi(ExchangeManager.getExchangeApi(exchange.Name));
                form.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                form.Show();

            }
        }
        private void toolStripButton_BTCTotal_Click(object sender, EventArgs e)
        {
            ExchangeManager.updateBalances();
        }
        /*
        private void toolStripButton_Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = ParentForm.Font;
            DialogResult result = fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ParentForm.Font = fontDialog.Font;
            }
            UpdateUI(true);
        }
        private void toolStripButton_FontDown_Click(object sender, EventArgs e)
        {
            //ExchangeManager.UpdateFont(new Font(ExchangeManager.preferences.defaultFont.FontFamily, ExchangeManager.preferences.defaultFont.Size - 1));
            ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style);
            UpdateUI(true);
        }
        private void toolStripButton_FontUp_Click(object sender, EventArgs e)
        {
            //ExchangeManager.UpdateFont(new Font(ExchangeManager.preferences.defaultFont.FontFamily, ExchangeManager.preferences.defaultFont.Size + 1));
            ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style);
            UpdateUI(true);
        }
        */
        private void toolStripButton_Refresh_Click(object sender, EventArgs e)
        {
            ExchangeManager.updateBalances();
        }
        private void toolStripButton_TickerTotals_Click(object sender, EventArgs e)
        {
            ExchangeManager.updateTickers();
        }
        private void toolStripButton_TimerItem_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ExchangeManager.ExchangeTimerType type = ExchangeManager.getExchangeTimerType(button.Tag.ToString());
            PreferenceManager.toggleTimerPreference(type);
            UpdateUI();
        }

        private void listView_SelectionChanged(object sender, EventArgs e)
        {
            //ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)sender as ExchangeManager.Exchange;
            if (listView.SelectedObject != null)
            {
                toolStripButton_API.Enabled = true;
                ExchangeManager.Exchange exchange = listView.SelectedObject as ExchangeManager.Exchange;

                if (ExchangeManager.getExchangeHasAPI(exchange))
                {
                    toolStripButton_API.Image = Properties.Resources.ConnectionStatus_ACTIVE;
                }
                else
                {
                    toolStripButton_API.Image = Properties.Resources.ConnectionStatus_DISABLED;
                }
            }
            else
            {
                toolStripButton_API.Enabled = false;
                toolStripButton_API.Image = Properties.Resources.ConnectionStatus_DISABLED;
            }
        }
        #endregion

        private void toolStripDropDownButton_menu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
                //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
                switch (menuItem.Tag.ToString())
                {
                    case "Font":
                        FontDialog dialog = new FontDialog() { Font = ParentForm.Font };
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            ParentForm.Font = dialog.Font;
                        }
                        UpdateUI(true);
                        break;

                    case "FontIncrease":
                        ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style);
                        UpdateUI(true);
                        break;

                    case "FontDecrease":
                        ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style);
                        UpdateUI(true);
                        break;

                    default:
                        // NOTHING
                        break;
                }
            }
        }
    }
}

/*
        #region Resize
        private void ResizeUI()
        {
            // MEASURE

            
            toolStrip_header.Font = ParentForm.Font;
            toolStrip_header2.Font = ParentForm.Font;
            listView.Font = ParentForm.Font;
            toolStrip_footer.Font = ParentForm.Font;
            
            int rowHeight = listView.RowHeightEffective;
            
            int nameWidth = column_Name.Width;
            int btcWidth = column_TotalInBTC.Width;

            int listWidth = 0;

            column_Icon.Width = rowHeight;
            column_Status.Width = rowHeight;

            // RESIZE
            //LogManager.AddLogMessage(Name, "ResizeUI", "fontSize = " + fontSize + " | rowHeight = " + rowHeight + " | btcWidth = " + btcWidth);
            column_Name.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            column_TotalInBTC.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            nameWidth = column_Name.Width + 15;
            btcWidth = column_TotalInBTC.Width + 15;
            //LogManager.AddLogMessage(Name, "ResizeUI", "btc post: " + btcWidth + " | " + column_TotalInBTC.CellPadding);
            //LogManager.AddLogMessage(Name, "ResizeUI", "pfontSize = " + fontSize + " | rowHeight = " + rowHeight + " | btcWidth = " + btcWidth);

            column_Name.Width = nameWidth;
            column_Orders.Width = btcWidth;
            column_TotalInBTC.Width = btcWidth;
            column_TotalInUSD.Width = btcWidth;

            foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
            {
                listWidth += col.Width;
            }

            if (this.Parent.GetType() == typeof(Form))
            {
                Form form = this.Parent as Form;
                form.Width = listWidth + 50;

                Rectangle screenRectangle = RectangleToScreen(form.ClientRectangle);
                int titleHeight = screenRectangle.Top - form.Top;
                int formHeight = titleHeight + toolStrip_header.Height + toolStrip_header2.Height + toolStrip_footer.Height;
                formHeight += (ExchangeManager.Exchanges.Count + 4) * rowHeight;
                form.Height = formHeight;
            }
            
        }
        #endregion
    */
