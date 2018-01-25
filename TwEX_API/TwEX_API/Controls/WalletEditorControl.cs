using System;
using System.Linq;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class WalletEditorControl : UserControl
    {
        #region Initialize
        public WalletEditorControl()
        {
            InitializeComponent();
        }
        private void WalletEditorControl_Load(object sender, EventArgs e)
        {
            UpdateUI(true);
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
                ParentForm.ClientSize = tableLayoutPanel.PreferredSize;
            }
        }

        delegate void UpdateDataCallback(WalletManager.WalletBalance wallet);
        public void UpdateData(WalletManager.WalletBalance wallet)
        {
            if (this.InvokeRequired)
            {
                UpdateDataCallback d = new UpdateDataCallback(UpdateData);
                this.Invoke(d, new object[] { wallet });
            }
            else
            {
                //ParentForm.ClientSize = tableLayoutPanel.PreferredSize;
                textBox_Address.Text = wallet.Address;
                textBox_Address.Enabled = false;
                textBox_Symbol.Text = wallet.Symbol;
                textBox_Symbol.Enabled = false;

                textBox_Api.Text = wallet.Api;
                textBox_Name.Text = wallet.Name;
                textBox_WalletName.Text = wallet.WalletName;
                numericUpDown_Balance.Value = wallet.Balance;

                UpdateUI(true);
            }
        }
        #endregion

        #region EventHandler
        private void button_save_Click(object sender, EventArgs e)
        {
            WalletManager.WalletBalance wallet = new WalletManager.WalletBalance()
            {
                Api = textBox_Api.Text,
                Address = textBox_Address.Text,
                Balance = numericUpDown_Balance.Value,
                Name = textBox_Name.Text,
                Symbol = textBox_Symbol.Text,
                WalletName = textBox_WalletName.Text
            };

            WalletManager.WalletBalance listItem = PreferenceManager.WalletPreferences.Wallets.FirstOrDefault(b => b.Address == wallet.Address && b.Symbol == wallet.Symbol);

            if (listItem == null)
            {
                PreferenceManager.WalletPreferences.Wallets.Add(wallet);
            }
            else
            {
                listItem.Api = wallet.Api;
                listItem.Balance = wallet.Balance;
                listItem.Name = wallet.Name;
                listItem.WalletName = wallet.WalletName;
            }
            //PreferenceManager.UpdatePreferenceSnapshots();
            PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Wallet);
            //WalletManager.UpdateUI();
            FormManager.UpdateWalletManager();
            ParentForm.Close();
        }
        #endregion
    }
}
