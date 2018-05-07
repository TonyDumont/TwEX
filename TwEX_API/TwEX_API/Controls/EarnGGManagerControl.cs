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
            InitializeIcons();
            //toggleView();
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_active.ImageGetter = new ImageGetterDelegate(aspect_active);
            column_balance.AspectGetter = new AspectGetterDelegate(aspect_balance);
            column_lastLogin.AspectGetter = new AspectGetterDelegate(aspect_lastLogin);
            column_email.AspectGetter = new AspectGetterDelegate(aspect_email);
        }
        private void InitializeIcons()
        {
            toolStripButton_toggleHeight.Image = ContentManager.GetIcon("Down");
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");

            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripMenuItem_AddAccount.Image = ContentManager.GetIcon("AddWallet");
            toolStripMenuItem_update.Image = ContentManager.GetIcon("Refresh");
        }
        #endregion

        #region Delegates
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
                toolStripButton_timer.Checked = (PreferenceManager.preferences.TimerFlags & ExchangeManager.ExchangeTimerType.EARNGG) != ExchangeManager.ExchangeTimerType.NONE;
                toolStripButton_timer.Image = ContentManager.GetActiveIcon(toolStripButton_timer.Checked);

                listView.SetObjects(PreferenceManager.EarnGGPreferences.EarnGGAccounts.OrderByDescending(item => item.lastBalanceChange));
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
                int rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;
                int iconSize = rowHeight - 2;

                //int listHeight = 0;

                column_email.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_email.Width = column_email.Width + (padding * 3);
                column_balance.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_balance.Width += padding;
                column_lastIP.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_lastIP.Width += padding;
                /*
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    //listWidth += col.Width;
                }
                */
                toggleView();
                /*
                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 1];
                    listHeight = listView.Top + last.Bounds.Bottom + (listView.RowHeightEffective / 2);
                    //LogManager.AddLogMessage(Name, "ResizeUI", listView.Top + " | " + last.Bounds.Bottom + " | " + listHeight);
                }

                listView.Height = listHeight;
                ClientSize = new Size(Width, listHeight);
                Size = new Size(Width, listHeight);
                */
            }
        }
        #endregion

        #region Getters
        private object aspect_active(object rowObject)
        {
            EarnGGAccount account = (EarnGGAccount)rowObject;
            TimeSpan loginspan = DateTime.Now - account.lastBalanceChange.ToLocalTime();

            int change = account.balance - account.lastBalance;
            int iconSize = listView.RowHeightEffective - 4;

            if (loginspan.Hours < 1)
            {
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_ACTIVE, iconSize, iconSize);
            }
            else
            {
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
        public object aspect_email(object rowObject)
        {
            EarnGGAccount account = (EarnGGAccount)rowObject;

            EarnGGMachine machine = PreferenceManager.EarnGGPreferences.Machines.FirstOrDefault(item => item.email == account.email);

            if (machine != null)
            {
                return machine.name;
            }
            else
            {
                return account.email;
            }
        }
        public object aspect_lastLogin(object rowObject)
        {
            EarnGGAccount account = (EarnGGAccount)rowObject;
            TimeSpan loginspan = DateTime.Now - account.lastBalanceChange.ToLocalTime();

            int change = account.balance - account.lastBalance;

            if (loginspan.Hours < 1)
            {
                return "(" + change + ") " + loginspan.Minutes + " Minutes Ago";
            }
            else if (loginspan.Days < 1)
            {
                return "(" + change + ") " + loginspan.Hours + " Hours Ago";
            }
            else
            {
                return "(" + change + ") " + loginspan.Days + " Days Ago";
                //return account.lastLogin;
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
        private void toolStripButton_toggleHeight_Click(object sender, EventArgs e)
        {
            /*
            EarnGGAccount account = PreferenceManager.EarnGGPreferences.EarnGGAccounts.Find(item => item.email == "grrinder@live.com");

            if (account != null)
            {
                LogManager.AddLogMessage(Name, "toolStripButton_toggleHeight_Click", account.email + " | ", LogManager.LogMessageType.DEBUG);
            }
            */
            
            PreferenceManager.EarnGGPreferences.collapsed = !PreferenceManager.EarnGGPreferences.collapsed;
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.EarnGG);
            toggleView();
            
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
        private void toggleView()
        {
            if (PreferenceManager.EarnGGPreferences.collapsed)
            {
                Height = toolStrip.Height;
                toolStripButton_toggleHeight.Image = ContentManager.GetIcon("Up");
            }
            else
            {
                Height = toolStrip.Height + (toolStrip.Height * PreferenceManager.EarnGGPreferences.EarnGGAccounts.Count);
                toolStripButton_toggleHeight.Image = ContentManager.GetIcon("Down");
            }
        }
        #endregion
    }
}
