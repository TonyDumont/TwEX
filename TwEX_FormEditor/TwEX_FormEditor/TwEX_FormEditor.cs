using System;
using System.Windows.Forms;
using TwEX_API;
using TwEX_API.Controls;

namespace TwEX_FormEditor
{
    public partial class TwEX_FormEditor : Form
    {
        // INITIALIZE
        public TwEX_FormEditor()
        {
            InitializeComponent();
        }
        private void TwEX_FormEditor_Load(object sender, EventArgs e)
        {
            LogManager.AddLogMessage(this.Name, "TwEX_FormEditor_Load", "Load Complete");
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            //cryptoCompareWidgetControl.SetChartAdvanced("BTC");
            Form form = new Form();
            form.Size = new System.Drawing.Size(950, 450);
            CryptoCompareWidgetEditorControl control = new CryptoCompareWidgetEditorControl();
            form.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            form.Show();
        }

        private void toolStripButton_CCWidgetEditor_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Size = new System.Drawing.Size(950, 550);
            form.Text = "CryptoCompare Widget Editor";
            CryptoCompareWidgetEditorControl control = new CryptoCompareWidgetEditorControl();
            form.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            form.Show();
        }
    }
}