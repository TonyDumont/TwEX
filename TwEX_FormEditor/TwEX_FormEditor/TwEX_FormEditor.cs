using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwEX_API;
using TwEX_API.Faucet;
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
            FormManager.toolStrip = toolStrip;

            if (LogManager.InitializeLogManager())
            {
                if (InitializePreferences())
                {
                    Task.Factory.StartNew(() => ExchangeManager.InitializeExchangeList());
                    /*
                    if (ExchangeManager.InitializeExchangeList())
                    {
                        if(ExchangeManager.InitializeTimer())
                        {
                            //ExchangeManager.updateControls();
                        }
                    }
                    */
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
            
            toolStripButton_ExchangeEditor.Image = ContentManager.ResizeImage(ContentManager.GetIconByUrl(ExchangeManager.IconUrl), 32, 32);
            //toolStripButton_CryptoCompare.Image = ContentManager.GetIconByUrl(CryptoCompare.IconUrl);
            //toolStripButton_TradingView.Image = ContentManager.GetIconByUrl(TradingView.IconUrl);
            //toolStripButton_CoinMarketCap.Image = ContentManager.GetIconByUrl(CoinMarketCap.IconUrl);
            toolStripButton_Balance.Image = ContentManager.ResizeImage(ContentManager.GetIconByUrl(ContentManager.BalanceIconUrl), 32, 32);
            //toolStripButton_Log.Image = ContentManager.GetIconByUrl(LogManager.IconUrl);
            toolStripButton_Calculator.Image = ContentManager.GetIconByUrl(ContentManager.CalculatorIconUrl);
            //toolStripButton_Arbitrage.Image = ContentManager.GetIconByUrl(ContentManager.ArbitrageIconUrl);
            toolStripButton_Wallet.Image = ContentManager.GetIconByUrl(ContentManager.WalletIconUrl);
            //toolStripButton_EarnGG.Image = ContentManager.GetIconByUrl(EarnGG.IconUrl);

            toolStripDropDownButton_menu.Image = ContentManager.GetIconByUrl(ContentManager.PreferenceIconUrl);

            toolStripMenuItem_LogManager.Image = ContentManager.GetIconByUrl(LogManager.IconUrl);

            toolStripMenuItem_ArbitrageManager.Image = ContentManager.GetIconByUrl(ContentManager.ArbitrageIconUrl);
            toolStripMenuItem_CoinMarketCap.Image = ContentManager.GetIconByUrl(CoinMarketCap.IconUrl);
            toolStripMenuItem_CryptoCompare.Image = ContentManager.GetIconByUrl(CryptoCompare.IconUrl);
            toolStripMenuItem_EarnGG.Image = ContentManager.GetIconByUrl(EarnGG.IconUrl);
            toolStripMenuItem_TradingView.Image = ContentManager.GetIconByUrl(TradingView.IconUrl);

            toolStripMenuItem_import.Image = ContentManager.GetIconByUrl(ContentManager.ImportIconUrl);
            toolStripMenuItem_export.Image = ContentManager.GetIconByUrl(ContentManager.ExportIconUrl);

            

            
            ExchangeManager.InitializeSymbolImageList();
            //CoinMarketCap.updateTickers();
            CryptoCompare.Initialize();
            //ExchangeManager.updateControls();
            

            foreach (FormPreference pref in preferences.FormPreferences)
            {
                //LogManager.AddLogMessage(Name, "InitializePreferences", pref.Name + " | " + pref.Open, LogMessageType.DEBUG);
                if (pref.Open)
                {
                    FormManager.OpenForm(pref.Name, pref.Name);
                }
            }

            //FormManager.UpdateForms();
            //Task.Factory.StartNew(() => ExchangeManager.InitializeExchangeList());
            LogManager.AddLogMessage(this.Name, "TwEX_FormEditor_Load", "Load Complete", LogManager.LogMessageType.LOG);
        }
        private void TwEX_FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // SNAPSHOTS
            PreferenceManager.UpdatePreferenceSnapshots();
        }
        #endregion

        #region EventHandlers
        private void toolStripButton_Form_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            //string name = button.Tag.ToString();

            FormManager.OpenForm(button.Tag.ToString(), button.Text); 
        }
        private void toolStripDropDownButton_menu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", e.GetType() + " | " + e.ClickedItem.GetType(), LogManager.LogMessageType.DEBUG);

            if (e.ClickedItem.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
                //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
                toolStripDropDownButton_menu.HideDropDown();
                FormManager.OpenForm(menuItem.Tag.ToString(), menuItem.Text);
                
            }
        }
        #endregion
    }
}