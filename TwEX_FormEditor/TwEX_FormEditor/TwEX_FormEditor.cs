using System;
using System.Windows.Forms;
using TwEX_API;

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
    }
}