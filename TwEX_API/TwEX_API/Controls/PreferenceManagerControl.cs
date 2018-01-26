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
            if (InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {
                ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                tableLayoutPanel.RowStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanel.RowStyles[0].Height = 125;

                tableLayoutPanel.RowStyles[1].SizeType = SizeType.Absolute;
                tableLayoutPanel.RowStyles[1].Height = 300;

                ParentForm.Size = new System.Drawing.Size(775, 525);
            }
        }
        #endregion


    }
}
