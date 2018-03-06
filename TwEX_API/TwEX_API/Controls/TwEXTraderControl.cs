using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.ContentManager;

namespace TwEX_API.Controls
{
    public partial class TwEXTraderControl : UserControl
    {
        #region Initialize
        public TwEXTraderControl()
        {
            InitializeComponent();
            FormManager.mainControl = this;
            InitializeIcons();
            
        }
        private void TwEXTraderControl_Load(object sender, EventArgs e)
        {
            InitializeWebsitesMenu();
        }
        private void InitializeIcons()
        {
            toolStripButton_ExchangeEditor.Image = ContentManager.GetIcon("Exchange");
            toolStripButton_Balance.Image = ContentManager.GetIcon("BalanceManager");
            toolStripButton_Calculator.Image = ContentManager.GetIcon("CoinCalculator");
            toolStripButton_Wallet.Image = ContentManager.GetIcon("WalletManager");

            toolStripDropDownButton_menu.Image = Properties.Resources.TwEX_RoundIcon.ToBitmap();
            toolStripDropDownButton_websites.Image = ContentManager.GetIcon("Website");

            toolStripMenuItem_LogManager.Image = ContentManager.GetIcon("LogManager");
            toolStripMenuItem_ArbitrageManager.Image = ContentManager.GetIcon("ArbitrageManager");
            toolStripMenuItem_CoinMarketCap.Image = ContentManager.GetIcon("CoinMarketCap");
            toolStripMenuItem_CryptoCompare.Image = ContentManager.GetIcon("CryptoCompare");
            toolStripMenuItem_EarnGG.Image = ContentManager.GetIcon("EarnGGManager");
            toolStripMenuItem_TradingView.Image = ContentManager.GetIcon("TradingView");

            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");

            toolStripMenuItem_PreferenceManager.Image = ContentManager.GetIcon("Options");
        }
        private void InitializeWebsitesMenu()
        {
            toolStripDropDownButton_websites.DropDown.Items.Clear();

            var roots = WebsiteUrlList.Select(website => website.Category).Distinct();

            foreach (var item in roots)
            {
                //LogManager.AddLogMessage(Name, "InitializeWebsitesMenu", "item=" + item, LogManager.LogMessageType.DEBUG);
                ToolStripMenuItem menuItem = new ToolStripMenuItem()
                {
                    Text = item,
                    Image = GetIcon(item)
                };
                toolStripDropDownButton_websites.DropDown.Items.Add(menuItem);
                //List<Website> websites = WebsiteUrlList.Select(url => url.Category == menuItem.Text);
                var websites = WebsiteUrlList.Where(url => url.Category == menuItem.Text);

                foreach (var website in websites)
                {
                    //LogManager.AddLogMessage(Name, "InitializeWebsitesMenu", website.Name + " | " + website.Url, LogManager.LogMessageType.DEBUG);
                    ToolStripMenuItem subItem = new ToolStripMenuItem()
                    {
                        Text = website.Name,
                        Tag = website.Url,
                        Image = GetWebsiteIcon(website.Name)
                    };
                    subItem.Click += WebsiteItem_Click;
                    menuItem.DropDown.Items.Add(subItem);
                }
                //List<Website> websites = new List<Website>();
                //websites = WebsiteUrlList.Where(url => url.Category == menuItem.Text);
            }

            ToolStripMenuItem exchangeMenuItem = new ToolStripMenuItem()
            {
                Text = "Exchanges",
                Image = GetIcon("Exchange")
            };
            toolStripDropDownButton_websites.DropDown.Items.Add(exchangeMenuItem);

            foreach(ExchangeManager.Exchange exchange in ExchangeManager.Exchanges)
            {
                //LogManager.AddLogMessage(Name, "InitializeWebsitesMenu", "exchange=" + exchange.Name + " | " + exchange.Url, LogManager.LogMessageType.DEBUG);
                ToolStripMenuItem subItem = new ToolStripMenuItem()
                {
                    Text = exchange.Name,
                    Tag = exchange.Url,
                    Image = GetExchangeIcon(exchange.Name)
                };
                subItem.Click += WebsiteItem_Click;
                exchangeMenuItem.DropDown.Items.Add(subItem);
            }
        }

        private void WebsiteItem_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            //LogManager.AddLogMessage(Name, "WebsiteItem_Click", item.Text + " | " + item.Tag, LogManager.LogMessageType.DEBUG);
            FormManager.OpenUrl(item.Tag.ToString());

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
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item.GetType() == typeof(ToolStripButton))
                    {
                        ToolStripButton button = item as ToolStripButton;
                        button.Checked = FormManager.IsFormOpen(button.Tag.ToString());
                    }
                }
                //LogManager.AddLogMessage(Name, "UpdateUI", "done", LogManager.LogMessageType.DEBUG);
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
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                toolStrip.ImageScalingSize = PreferenceManager.preferences.IconSize;
                InitializeIcons();
            }
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
                //if ()
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;

                if (!menuItem.Tag.ToString().Contains("Font"))
                {
                    //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
                    toolStripDropDownButton_menu.HideDropDown();
                    FormManager.OpenForm(menuItem.Tag.ToString(), menuItem.Text);
                }
                else
                {
                    switch (menuItem.Tag.ToString())
                    {
                        case "Font":
                            FontDialog dialog = new FontDialog() { Font = ParentForm.Font };
                            DialogResult result = dialog.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                if (PreferenceManager.SetFormFont(ParentForm, dialog.Font))
                                {
                                    UpdateUI(true);
                                }
                            }
                            UpdateUI(true);
                            break;

                        case "FontIncrease":
                            if (PreferenceManager.SetFormFont(ParentForm, new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style)))
                            {
                                UpdateUI(true);
                            }
                            break;

                        case "FontDecrease":
                            
                            if (PreferenceManager.SetFormFont(ParentForm, new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style)))
                            {
                                UpdateUI(true);
                            }
                            break;

                        default:
                            // NOTHING
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
