using BrightIdeasSoftware;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class WalletManagerControl : UserControl
    {
        #region Initialize
        public WalletManagerControl()
        {
            InitializeComponent();
            //WalletManager.walletManagerControl = this;
            FormManager.walletManagerControl = this;
            InitializeColumns();
        }
        private void WalletManagerControl_Load(object sender, EventArgs e)
        {
            //toolStripButton_Font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");

            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripMenuItem_add.Image = ContentManager.GetIcon("AddWallet");
            toolStripMenuItem_update.Image = ContentManager.GetIcon("Refresh");
            //listView.SetObjects(WalletManager.Wallets.Where(item => item.Balance > 0));
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_Name.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            column_Symbol.ImageGetter = new ImageGetterDelegate(aspect_Symbol);
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
                listView.SetObjects(PreferenceManager.WalletPreferences.Wallets);
                listView.Sort(column_TotalInBTC, SortOrder.Descending);

                toolStripLabel_title.Text = PreferenceManager.WalletPreferences.Wallets.Count + " Wallets";
                toolStripLabel_totals.Text = "Totals : (" + PreferenceManager.WalletPreferences.Wallets.Sum(b => b.TotalInUSD).ToString("C") + ") " + PreferenceManager.WalletPreferences.Wallets.Sum(b => b.TotalInBTC).ToString("N8");

                toolStripButton_timer.Checked = (PreferenceManager.preferences.TimerFlags & ExchangeManager.ExchangeTimerType.WALLETS) != ExchangeManager.ExchangeTimerType.NONE;
                //toolStripButton_Tickers.Text = "TICKERS (" + ExchangeManager.Tickers.Count + ")";
                toolStripButton_timer.Image = ContentManager.GetActiveIcon(toolStripButton_timer.Checked);
                //LogManager.AddLogMessage(Name, "UpdateUI", "Updating - " + resize, LogManager.LogMessageType.DEBUG);
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
                Invoke(d, new object[] { });
            }
            else
            {
                ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                toolStrip.Font = ParentForm.Font;
                //toolStrip_footer.Font = ParentForm.Font;
                listView.Font = ParentForm.Font;
                //LogManager.AddLogMessage(Name, "ResizeUI", "RESIZING", LogManager.LogMessageType.DEBUG);
                Size textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);
                int rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;
                int iconSize = rowHeight - 2;         
                //int listWidth = 0;
                int listHeight = 0;

                toolStrip.ImageScalingSize = new Size(iconSize, iconSize);

                column_Symbol.Width = iconSize;
                column_TotalInUSD.Width = textSize.Width;
                column_TotalInBTC.Width = textSize.Width;
                column_Balance.Width = textSize.Width + (textSize.Width / 2);
                /*
                //int listWidth = 0;
                //int listHeight = 0;
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    //col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //col.Width = col.Width + (rowHeight / 2);
                    listWidth += col.Width;
                }
                */


                //column_Tickers.Width = 
                /*
                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 4];
                    listHeight = listView.Top + last.Bounds.Bottom;
                    //listHeight = last.Bounds.Bottom;
                    //LogManager.AddLogMessage(Name, "ResizeUI", listView.Top + " | " + last.Bounds.Bottom + " | " + listHeight);
                }
                */
                listView.Height = listHeight;
                ClientSize = new Size(Width, listHeight + (toolStrip.Height * 2) - (listView.RowHeightEffective / 2));
                Size = new Size(Width, listHeight + (toolStrip.Height * 2) - (listView.RowHeightEffective / 2));


                /*
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + padding;
                    listWidth += col.Width;
                }

                column_Name.Width = column_Name.Width + iconSize;
                listWidth += iconSize;

                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 3];
                    listHeight = listView.Top + last.Bounds.Bottom;
                }
                */





                /*
                Rectangle screenRectangle = RectangleToScreen(ParentForm.ClientRectangle);
                int titleHeight = screenRectangle.Top - ParentForm.Top;
                int formHeight = titleHeight + listHeight;
                int totalHeight = titleHeight + listHeight + toolStrip.Height + padding;
                //LogManager.AddLogMessage(Name, "ResizeUI", "titleHeight=" + titleHeight + " | listHeight=" + listHeight + " | " + toolStrip_header.Height + " | " + toolStrip_header2.Height);
                ParentForm.ClientSize = new Size(listWidth + (padding * 2), totalHeight);
                */
                //UpdateUI();
            }
        }
        #endregion

        #region Getters
        private object aspect_Icon(object rowObject)
        {
            WalletManager.WalletBalance balance = (WalletManager.WalletBalance)rowObject;
            int rowheight = listView.RowHeightEffective - 3;
            return ContentManager.ResizeImage(ContentManager.GetWalletIcon(balance.WalletName), rowheight, rowheight);
            //return ContentManager.GetWalletIcon(balance.WalletName);
        }
        private object aspect_Symbol(object rowObject)
        {
            WalletManager.WalletBalance balance = (WalletManager.WalletBalance)rowObject;
            int rowheight = listView.RowHeightEffective - 3;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(balance.Symbol), rowheight, rowheight);
        }
        #endregion

        #region EventHandlers
        private void listView_ItemActivate(object sender, EventArgs e)
        {
            WalletManager.WalletBalance wallet = listView.SelectedObject as WalletManager.WalletBalance;

            Form form = new Form()
            {
                Text = "Wallet Editor",
                StartPosition = FormStartPosition.CenterScreen,
                Font = ParentForm.Font
            };

            WalletEditorControl control = new WalletEditorControl()
            {
                Dock = DockStyle.Fill
            };

            form.Controls.Add(control);
            control.UpdateData(wallet);
            form.Show();
        }     
        private void toolStripButton_timer_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ExchangeManager.ExchangeTimerType type = ExchangeManager.getExchangeTimerType(button.Tag.ToString());
            PreferenceManager.toggleTimerPreference(type);
            UpdateUI();
        }
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
                        //fontDialog.Font = ParentForm.Font;
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

                    case "AddWallet":
                        Form form = new Form()
                        {
                            Text = "Wallet Editor",
                            StartPosition = FormStartPosition.CenterScreen,
                            Font = ParentForm.Font
                        };

                        WalletEditorControl control = new WalletEditorControl()
                        {
                            Dock = DockStyle.Fill
                        };

                        form.Controls.Add(control);
                        form.Show();
                        break;

                    case "UpdateWallets":
                        if (WalletManager.UpdateWallets())
                        {
                            //UpdateUI();
                        }
                        break;

                    default:
                        // NOTHING
                        break;
                }

            }
        }
        #endregion
    }
}