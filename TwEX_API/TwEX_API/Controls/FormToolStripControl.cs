using System;
using System.Windows.Forms;
using TwEX_API.Market;
using TwEX_API.Faucet;

namespace TwEX_API.Controls
{
    public partial class FormToolStripControl : UserControl
    {
        #region Initialize
        public FormToolStripControl()
        {
            InitializeComponent();
            FormManager.mainToolStrip = this;
        }
        private void FormToolStripControl_Load(object sender, EventArgs e)
        {
            toolStripButton_ExchangeEditor.Image = ContentManager.ResizeImage(ContentManager.GetIconByUrl(ExchangeManager.IconUrl), 32, 32);
            toolStripButton_Balance.Image = ContentManager.ResizeImage(ContentManager.GetIconByUrl(ContentManager.BalanceIconUrl), 32, 32);
            toolStripButton_Calculator.Image = ContentManager.GetIconByUrl(ContentManager.CalculatorIconUrl);
            toolStripButton_Wallet.Image = ContentManager.GetIconByUrl(ContentManager.WalletIconUrl);

            //toolStripDropDownButton_menu.Image = ContentManager.GetIconByUrl(ContentManager.PreferenceIconUrl);
            toolStripDropDownButton_menu.Image = Properties.Resources.TwEX_RoundIcon.ToBitmap();

            toolStripMenuItem_LogManager.Image = ContentManager.GetIconByUrl(LogManager.IconUrl);
            toolStripMenuItem_ArbitrageManager.Image = ContentManager.GetIconByUrl(ContentManager.ArbitrageIconUrl);
            toolStripMenuItem_CoinMarketCap.Image = ContentManager.GetIconByUrl(CoinMarketCap.IconUrl);
            toolStripMenuItem_CryptoCompare.Image = ContentManager.GetIconByUrl(CryptoCompare.IconUrl);
            toolStripMenuItem_EarnGG.Image = ContentManager.GetIconByUrl(EarnGG.IconUrl);
            toolStripMenuItem_TradingView.Image = ContentManager.GetIconByUrl(TradingView.IconUrl);

            toolStripMenuItem_import.Image = ContentManager.GetIconByUrl(ContentManager.ImportIconUrl);
            toolStripMenuItem_export.Image = ContentManager.GetIconByUrl(ContentManager.ExportIconUrl);
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
            if (this.InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                this.Invoke(d, new object[] { });
            }
            else
            {

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
