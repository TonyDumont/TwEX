using System;
using System.Windows.Forms;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Controls
{
    public partial class APIEditorControl : UserControl
    {
        private ExchangeApi Api = new ExchangeApi();

        public APIEditorControl()
        {
            InitializeComponent();
        }

        delegate void SetApiCallback(ExchangeApi api);
        public void SetApi(ExchangeApi api)
        {
            if (this.InvokeRequired)
            {
                SetApiCallback d = new SetApiCallback(SetApi);
                this.Invoke(d, new object[] { api });
            }
            else
            {
                Api = api;
                textBox_key.Text = Api.key;
                textBox_secret.Text = Api.secret;
                textBox_passphrase.Text = Api.passphrase;

                if (Api.exchange != "GDAX")
                {
                    textBox_passphrase.Enabled = false;
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            PreferenceManager.UpdateExchangeApi(Api);
        }
    }
}
