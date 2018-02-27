using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using static TwEX_API.Faucet.EarnGG;
using System.Linq;
using System.Drawing;

namespace TwEX_API.Controls
{
    public partial class EarnGGManagerControl : UserControl
    {
        #region Initialize
        public EarnGGManagerControl()
        {
            InitializeComponent();
            earnGGManagerControl = this;
            InitializeColumns();
        }
        private void EarnGGManagerControl_Load(object sender, EventArgs e)
        {
            //toolStripButton_Font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");

            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripMenuItem_AddAccount.Image = ContentManager.GetIcon("AddWallet");
            toolStripMenuItem_update.Image = ContentManager.GetIcon("Refresh");
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_active.ImageGetter = new ImageGetterDelegate(aspect_active);
            column_balance.AspectGetter = new AspectGetterDelegate(aspect_balance);
            column_lastLogin.AspectGetter = new AspectGetterDelegate(aspect_lastLogin);
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
                toolStripButton_timer.Checked = (PreferenceManager.preferences.TimerFlags & ExchangeManager.ExchangeTimerType.EARNGG) != ExchangeManager.ExchangeTimerType.NONE;
                toolStripButton_timer.Image = ContentManager.GetActiveIcon(toolStripButton_timer.Checked);

                listView.SetObjects(PreferenceManager.EarnGGPreferences.EarnGGAccounts.OrderByDescending(item => item.lastLogin));
                int totalPoints = PreferenceManager.EarnGGPreferences.EarnGGAccounts.Sum(item => item.balance);
                toolStripLabel_title.Text = PreferenceManager.EarnGGPreferences.EarnGGAccounts.Count + " EarnGG Accounts";
                toolStripLabel_total.Text = decimal.Multiply(totalPoints, .00001M).ToString("C"); 
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
            if (InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                //toolStrip.Font = ParentForm.Font;
                //listView.Font = ParentForm.Font;

                int rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;
                int iconSize = rowHeight - 2;

                //int listWidth = 0;
                int listHeight = 0;

                column_email.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_balance.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                /*
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    //listWidth += col.Width;
                }
                */
                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 1];
                    listHeight = listView.Top + last.Bounds.Bottom + (listView.RowHeightEffective / 2);
                    //LogManager.AddLogMessage(Name, "ResizeUI", listView.Top + " | " + last.Bounds.Bottom + " | " + listHeight);
                }

                listView.Height = listHeight;
                ClientSize = new Size(Width, listHeight);
                Size = new Size(Width, listHeight);
            }
        }
        #endregion

        #region Getters
        private object aspect_active(object rowObject)
        {
            /*
            ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)rowObject;
            int rowheight = listView.RowHeightEffective - 3;
            return ContentManager.ResizeImage(exchange.Icon, rowheight, rowheight);
            */
            EarnGGAccount account = (EarnGGAccount)rowObject;
            TimeSpan loginspan = DateTime.Now - account.lastLogin.ToLocalTime();
            int iconSize = listView.RowHeightEffective - 5;

            if (loginspan.Hours < 1)
            {
                //return loginspan.Minutes + " Minutes Ago";
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_ACTIVE, iconSize, iconSize);
            }
            else
            {
                //return loginspan.Days + " Days Ago";
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_ERROR, iconSize, iconSize);
            }
        }
        public object aspect_balance(object rowObject)
        {
            EarnGGAccount account = (EarnGGAccount)rowObject;

            Decimal points = account.balance;
            Decimal value = decimal.Multiply(points, .00001M);

            return value.ToString("C");
        }
        public object aspect_lastLogin(object rowObject)
        {
            EarnGGAccount account = (EarnGGAccount)rowObject;
            TimeSpan loginspan = DateTime.Now - account.lastLogin.ToLocalTime();

            if (loginspan.Hours < 1)
            {
                return loginspan.Minutes + " Minutes Ago";
            }
            else if (loginspan.Days < 1)
            {
                return loginspan.Hours + " Hours Ago";
            }
            else
            {
                //return loginspan.Days + " Days Ago";
                return account.lastLogin;
            }
        }
        #endregion

        #region EventHandlers
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
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            if (PreferenceManager.SetFormFont(ParentForm, dialog.Font))
                            {
                                UpdateUI(true);
                            }
                        }
                        UpdateUI(true);
                        break;

                    case "FontIncrease":
                        if (PreferenceManager.SetFormFont(ParentForm, new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style)))
                        {
                            UpdateUI(true);
                        }
                        break;

                    case "FontDecrease":
                        if (PreferenceManager.SetFormFont(ParentForm, new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style)))
                        {
                            UpdateUI(true);
                        }
                        break;

                    case "AddAccount":
                        Form form = new Form() { Text = "EarnGG Account Editor" };
                        EarnGGAccountEditorControl control = new EarnGGAccountEditorControl() { Dock = DockStyle.Fill };
                        form.Controls.Add(control);
                        form.Show();
                        break;

                    case "Update":
                        UpdateUI();
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
