using System;
using System.Drawing;
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
            InitializeIcons();
        }
        private void TwEXTraderControl_Load(object sender, EventArgs e)
        {
            
        }
        private void InitializeIcons()
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

            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");

            toolStripMenuItem_PreferenceManager.Image = ContentManager.GetIcon("Options");
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
                InitializeIcons();
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
                //if ()
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;

                if (!menuItem.Tag.ToString().Contains("Font"))
                {
                    //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
                    toolStripDropDownButton_menu.HideDropDown();
                    FormManager.OpenForm(menuItem.Tag.ToString(), menuItem.Text);
                }
                else
                {
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

                        default:
                            // NOTHING
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
