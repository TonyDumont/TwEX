using System;
using System.Windows.Forms;

namespace TwEX_FormEditor
{
    public partial class TwEX_FormEditor : Form
    {
        public TwEX_FormEditor()
        {
            InitializeComponent();
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            textBox_message.Text = "CLICKED : " + TwEX_API.ExchangeManager.GetNonce();
        }
    }
}
