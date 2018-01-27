using System;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class ApplicationPreferenceControl : UserControl
    {
        #region Initialize
        public ApplicationPreferenceControl()
        {
            InitializeComponent();
        }
        private void ApplicationPreferenceControl_Load(object sender, EventArgs e)
        {
            //label_sample.Font = PreferenceManager.preferences.Font;
            checkBox_font.Checked = PreferenceManager.preferences.UseGlobalFont;
            button_font.Enabled = checkBox_font.Checked;
            button_font.Font = PreferenceManager.preferences.Font;

            if (PreferenceManager.preferences.Theme.type == PreferenceManager.ThemeType.Default)
            {
                radioButton_default.Checked = true;
            }
            else
            {
                radioButton_dark.Checked = true;
            }
        }
        #endregion

        #region EventHandlers
        private void button_font_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog() { Font = PreferenceManager.preferences.Font };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PreferenceManager.preferences.Font = dialog.Font;
                PreferenceManager.UpdatePreferenceFile();
                //label_sample.Font = PreferenceManager.preferences.Font;
                button_font.Font = PreferenceManager.preferences.Font;
                PreferenceManager.UpdatePreferenceFile();
                PreferenceManager.UpdateFontPreferences();
                //UpdateUI();
            }
            //UpdateUI(true);
        }
        private void checkBox_font_CheckedChanged(object sender, EventArgs e)
        {
            button_font.Enabled = checkBox_font.Checked;
            PreferenceManager.preferences.UseGlobalFont = checkBox_font.Checked;
            PreferenceManager.UpdatePreferenceFile();
            PreferenceManager.UpdateFontPreferences();
        }
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
 
            if (radioButton.Text == "Default")
            {
                PreferenceManager.UpdateTheme(PreferenceManager.ThemeType.Default);
            }
            else
            {
                PreferenceManager.UpdateTheme(PreferenceManager.ThemeType.Dark);
            }
            //PreferenceManager.UpdatePreferenceFile();
            //FormManager.UpdateControlUIs();
            //PreferenceManager.SetTheme();
        }
        #endregion
    }
}
