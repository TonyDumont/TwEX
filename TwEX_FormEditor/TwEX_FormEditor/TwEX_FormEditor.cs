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
                    Task.Factory.StartNew(() => ExchangeManager.InitializeExchanges());
                }
                else
                {
                    LogManager.AddLogMessage(Name, "TwEX_FormEditor", "Problem Loading Preferences", LogManager.LogMessageType.DEBUG);
                }
            }
        }
        private void TwEX_FormEditor_Load(object sender, EventArgs e)
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment cd = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                string publishVersion = cd.CurrentVersion.ToString();
                Text = "TwEX Trader : Short Armed Trading Tools Version " + publishVersion;
            }
            else
            {
                Text = "TwEX Trader : Short Armed Trading Tools";
            }
           
            FormPreference preference = FormPreferences.FirstOrDefault(item => item.Name == Name);
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

            ContentManager.Initialize();

            Task.Factory.StartNew(() => CryptoCompare.Initialize());
            //LogManager.AddLogMessage(Name, "TwEX_FormEditor_Load", "Load Complete", LogManager.LogMessageType.LOG);
        }
        private void TwEX_FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdatePreferenceSnapshots();
        }
        private void TwEX_FormEditor_Shown(object sender, EventArgs e)
        {
            //FormManager.RestoreForms();
            SetTheme(preferences.Theme.type, this);
            FormManager.UpdateExchangeManager(true);
            FormManager.UpdateWalletManager(true);
            //FormManager.UpdateMainControl(true);
            twEXTraderControl.UpdateUI(true);
            //FormManager.UpdateControlUIs(true);
        }
        #endregion
    }
}