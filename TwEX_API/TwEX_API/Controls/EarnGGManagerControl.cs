﻿using System;
using System.Windows.Forms;
using TwEX_API.Faucet;
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
            EarnGG.earnGGManagerControl = this;
            InitializeColumns();
        }
        private void EarnGGManagerControl_Load(object sender, EventArgs e)
        {
            toolStripButton_Font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
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

                listView.SetObjects(Accounts.OrderByDescending(item => item.lastLogin));
                int totalPoints = Accounts.Sum(item => item.balance);
                toolStripLabel_title.Text = Accounts.Count + " EarnGG Accounts : " + decimal.Multiply(totalPoints, .00001M).ToString("C");               
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
                this.Invoke(d, new object[] { });
            }
            else
            {
                toolStrip.Font = ParentForm.Font;
                listView.Font = ParentForm.Font;
                //LogManager.AddLogMessage(Name, "ResizeUI", "RESIZING", LogManager.LogMessageType.DEBUG);
                //Size textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);
                int rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;
                int iconSize = rowHeight - 2;
                int listWidth = 0;
                int listHeight = 0;

                column_active.Width = iconSize + padding;

                column_email.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_email.Width = column_email.Width + padding;
                column_balance.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_balance.Width = column_balance.Width + padding;

                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    listWidth += col.Width;
                }

                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 1];
                    listHeight = listView.Top + last.Bounds.Bottom;
                }
                //column_Name.Width = column_Name.Width + iconSize + 2;
                ParentForm.ClientSize = new Size(listWidth + (padding * 2), toolStrip.Height + listHeight + (padding));
                //UpdateUI();
                
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
        private void toolStripButton_AddAccount_Click(object sender, EventArgs e)
        {
            Form form = new Form() { Text = "EarnGG Account Editor" };
            EarnGGAccountEditorControl control = new EarnGGAccountEditorControl() { Dock = DockStyle.Fill };
            form.Controls.Add(control);
            form.Show();
        }
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
        private void toolStripButton_timer_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ExchangeManager.ExchangeTimerType type = ExchangeManager.getExchangeTimerType(button.Tag.ToString());
            PreferenceManager.toggleTimerPreference(type);
            UpdateUI();
        }
        #endregion
    }
}
