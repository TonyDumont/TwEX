﻿using System;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class TwEXTraderControl : UserControl
    {
        #region Initialize
        public TwEXTraderControl()
        {
            InitializeComponent();
            FormManager.mainControl = this;
        }
        private void TwEXTraderControl_Load(object sender, EventArgs e)
        {
            toolStripButton_ExchangeEditor.Image = ContentManager.GetIcon("Exchange");
            toolStripButton_Balance.Image = ContentManager.GetIcon("BalanceManager");
            toolStripButton_Calculator.Image = ContentManager.GetIcon("CoinCalculator");
            toolStripButton_Wallet.Image = ContentManager.GetIcon("WalletManager");

            toolStripDropDownButton_menu.Image = Properties.Resources.TwEX_RoundIcon.ToBitmap();

            toolStripMenuItem_LogManager.Image = ContentManager.GetIcon("LogManager");
            toolStripMenuItem_ArbitrageManager.Image = ContentManager.GetIcon("ArbitrageManager");
            toolStripMenuItem_CoinMarketCap.Image = ContentManager.GetIcon("CoinMarketCap");
            toolStripMenuItem_CryptoCompare.Image = ContentManager.GetIcon("CryptoCompare");
            toolStripMenuItem_EarnGG.Image = ContentManager.GetIcon("EarnGGManager");
            toolStripMenuItem_TradingView.Image = ContentManager.GetIcon("TradingView");

            toolStripMenuItem_PreferenceManager.Image = ContentManager.GetIcon("Options");
            //UpdateUI(true);
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
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item.GetType() == typeof(ToolStripButton))
                    {
                        ToolStripButton button = item as ToolStripButton;
                        button.Checked = FormManager.IsFormOpen(button.Tag.ToString());
                    }
                }
                //LogManager.AddLogMessage(Name, "UpdateUI", "done", LogManager.LogMessageType.DEBUG);
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
                toolStrip.ImageScalingSize = PreferenceManager.preferences.IconSize;
            }
        }
        #endregion

        #region EventHandlers
        private void toolStripButton_Form_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            //string name = button.Tag.ToString();

            FormManager.OpenForm(button.Tag.ToString(), button.Text);
        }
        private void toolStripDropDownButton_menu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", e.GetType() + " | " + e.ClickedItem.GetType(), LogManager.LogMessageType.DEBUG);

            if (e.ClickedItem.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
                //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
                toolStripDropDownButton_menu.HideDropDown();
                FormManager.OpenForm(menuItem.Tag.ToString(), menuItem.Text);

            }
        }
        #endregion
    }
}
