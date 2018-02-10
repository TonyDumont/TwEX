using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static TwEX_API.PreferenceManager;

namespace TwEX_API.Controls
{
    public partial class ApplicationPreferenceControl : UserControl
    {
        #region Initialize
        public ApplicationPreferenceControl()
        {
            InitializeComponent();
            InitializeThemes();
        }
        private void ApplicationPreferenceControl_Load(object sender, EventArgs e)
        {
            checkBox_font.Checked = preferences.UseGlobalFont;
            checkBox_GridLines.Checked = preferences.ShowGridLines;
            checkBox_AlternatingColors.Checked = preferences.UseAlternatingBackColors;
            button_font.Enabled = checkBox_font.Checked;
            button_font.Font = preferences.Font;
        }
        private void InitializeThemes()
        {
            var values = EnumUtils.GetValues<ThemeType>();
            List<TypeListItem> list = new List<TypeListItem>();

            foreach (ThemeType type in values)
            {
                //LogManager.AddLogMessage(Name, "UpdateUI", type.ToString() + " | " + type.GetHashCode(), LogManager.LogMessageType.DEBUG);
                TypeListItem item = new TypeListItem()
                {
                    Name = type.ToString(),
                    type = type.GetType()
                };
                list.Add(item);
            }
            listView.SetObjects(list);
            listView.SelectedIndex = preferences.Theme.type.GetHashCode();
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
                Font = ParentForm.Font;
                listView.Font = ParentForm.Font;
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
        private void button_SetTheme_Click(object sender, EventArgs e)
        {
            TypeListItem item = listView.SelectedObject as TypeListItem;
            ThemeType type = (ThemeType)Enum.Parse(typeof(ThemeType), item.Name);
            if (SetTheme(type))
            {
                listView.SelectedIndex = preferences.Theme.type.GetHashCode();
            }
        }
        private void checkBox_font_CheckedChanged(object sender, EventArgs e)
        {
            button_font.Enabled = checkBox_font.Checked;
            preferences.UseGlobalFont = checkBox_font.Checked;
            UpdatePreferenceFile();
            UpdateFontPreferences();
        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedObject != null)
            {
                TypeListItem item = listView.SelectedObject as TypeListItem;
                ThemeType type = (ThemeType)Enum.Parse(typeof(ThemeType), item.Name);
                SetTheme(type, ParentForm);

            }
        }
        private void checkBox_GridLines_CheckedChanged(object sender, EventArgs e)
        {
            preferences.ShowGridLines = checkBox_GridLines.Checked;
            SetTheme(preferences.Theme.type);
        }
        #endregion

        private void checkBox_AlternatingColors_CheckedChanged(object sender, EventArgs e)
        {
            preferences.UseAlternatingBackColors = checkBox_AlternatingColors.Checked;
            SetTheme(preferences.Theme.type);
        }
    }
}

/*
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
        */
