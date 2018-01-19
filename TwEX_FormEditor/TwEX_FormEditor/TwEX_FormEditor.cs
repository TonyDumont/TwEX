using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwEX_API;
using TwEX_API.Market;
using static TwEX_API.PreferenceManager;

namespace TwEX_FormEditor
{
    public partial class TwEX_FormEditor : Form
    {
        #region Initialize
        public TwEX_FormEditor()
        {
            InitializeComponent();
            FormManager.mainForm = this;

            if (LogManager.InitializeLogManager())
            {
                if (InitializePreferences())
                {
                    Task.Factory.StartNew(() => ExchangeManager.InitializeExchangeList());
                }
                else
                {
                    LogManager.AddLogMessage(Name, "TwEX_FormEditor", "Problem Loading Preferences", LogManager.LogMessageType.DEBUG);
                }
            }
        }
        private void TwEX_FormEditor_Load(object sender, EventArgs e)
        {
            FormPreference preference = preferences.FormPreferences.FirstOrDefault(item => item.Name == Name);
            if (preference != null)
            {
                //LogManager.AddLogMessage(Name, "toolStripButton_Form_Click", "FOUND : " + preference.Name + " | " + preference.Font.FontFamily + " | " + preference.Size + " | " + preference.Location);
                SetBounds(preference.Location.X, preference.Location.Y, preference.Size.Width, preference.Size.Height);
                Font = new Font(preference.Font.FontFamily, preference.Font.Size, preference.Font.Style);
            }
            else
            {
                //LogManager.AddLogMessage(Name, "toolStripButton_Form_Click", "NOT FOUND ADDING : " + form.Name + " | " + form.Location);
                UpdateFormPreferences(this, true);
            }

            LocationChanged += delegate { UpdateFormPreferences(this, true); };
            SizeChanged += delegate { UpdateFormPreferences(this, true); };
            FontChanged += delegate { UpdateFormPreferences(this, true); };
            FormClosing += delegate { UpdateFormPreferences(this, false); };

            ExchangeManager.InitializeSymbolImageList();
            //Task.Factory.StartNew(() => ExchangeManager.InitializeSymbolImageList());
            Task.Factory.StartNew(() => CryptoCompare.Initialize());

            LogManager.AddLogMessage(this.Name, "TwEX_FormEditor_Load", "Load Complete", LogManager.LogMessageType.LOG);
        }
        private void TwEX_FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // SNAPSHOTS
            PreferenceManager.UpdatePreferenceSnapshots();
        }
        private void TwEX_FormEditor_Shown(object sender, EventArgs e)
        {
            FormManager.RestoreForms();
        }
        #endregion
    }
}