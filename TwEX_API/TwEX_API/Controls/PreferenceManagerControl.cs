using System;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class PreferenceManagerControl : UserControl
    {
        public PreferenceManagerControl()
        {
            InitializeComponent();
        }

        private void PreferenceManagerControl_Load(object sender, EventArgs e)
        {
            UpdateUI(true);
        }

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
                ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                
            }
        }
        #endregion


    }
}
