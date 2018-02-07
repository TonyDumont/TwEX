using System;
using System.Drawing;
using System.Windows.Forms;
using static TwEX_API.ExchangeManager;

namespace TwEX_API.Controls
{
    public partial class BalanceManagerControl : UserControl
    {
        #region Initialize
        public BalanceManagerControl()
        {
            InitializeComponent();       
        }
        private void BalanceManagerControl_Load(object sender, EventArgs e)
        {
            InitializeViews();
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripRadioButton_balance.Image = ContentManager.GetIcon("BalanceManager");
            toolStripRadioButton_exchange.Image = ContentManager.GetIcon("ExchangeEditor");
            toolStripRadioButton_symbol.Image = ContentManager.GetIcon("Symbol");
            
            toolStripRadioButton_balance.Checked = true;
            SetTabButton();
            UpdateUI(true);
        }
        private void InitializeViews()
        {
            var values = EnumUtils.GetValues<BalanceViewType>();
            foreach (var item in values)
            {
                LogManager.AddLogMessage(Name, "InitializeViews", item.ToString() + " | " + item.GetHashCode(), LogManager.LogMessageType.DEBUG);
                TabPage tabPage = new TabPage()
                {
                    Name = item.ToString(),
                    Text = item.ToString()
                };

                BalanceViewControl view = new BalanceViewControl()
                {
                    Dock = DockStyle.Fill,
                    view = item
                };
                view.SetView();
                tabPage.Controls.Add(view);
                tabControl.TabPages.Add(tabPage);
            }
        }
        private void SetTabButton()
        {
            switch (PreferenceManager.preferences.BalanceView)
            {
                case BalanceViewType.symbol:
                    toolStripRadioButton_symbol.Checked = true;
                    break;

                case BalanceViewType.exchange:
                    toolStripRadioButton_exchange.Checked = true;
                    break;

                case BalanceViewType.balance:
                    toolStripRadioButton_balance.Checked = true;
                    break;

                default:

                    break;
            }
        }
        #endregion

        #region Delegates
        delegate void UpdateUICallback(bool resize = false);
        public void UpdateUI(bool resize = false)
        {
            if (InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                Invoke(d, new object[] { resize });
            }
            else
            {
                try
                {
                    tabControl.SelectedIndex = PreferenceManager.preferences.BalanceView.GetHashCode();
                    BalanceViewControl control = tabControl.SelectedTab.Controls[0] as BalanceViewControl;
                    control.UpdateUI(resize);
                    
                    if (resize)
                    {
                        ResizeUI();
                    }
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "UpdateUI", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
            }
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
                toolStrip.Font = ParentForm.Font;
                toolStrip.ImageScalingSize = PreferenceManager.preferences.IconSize;
            }
        }
        #endregion

        #region EventHandlers
        private void toolStripDropDownButton_menu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
                toolStripDropDownButton_menu.HideDropDown();
                //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
                switch (menuItem.Tag.ToString())
                {
                    case "Font":
                        FontDialog dialog = new FontDialog() { Font = ParentForm.Font };
                        DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            ParentForm.Font = dialog.Font;
                        }
                        UpdateUI(true);
                        break;

                    case "FontIncrease":
                        ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size + 1, ParentForm.Font.Style);
                        UpdateUI(true);
                        break;

                    case "FontDecrease":
                        ParentForm.Font = new Font(ParentForm.Font.FontFamily, ParentForm.Font.Size - 1, ParentForm.Font.Style);
                        UpdateUI(true);
                        break;

                    default:
                        // NOTHING
                        break;
                }
            }
        }
        private void toolStripRadioButton_view_Click(object sender, EventArgs e)
        {
            ToolStripRadioButton button = sender as ToolStripRadioButton;
            PreferenceManager.preferences.BalanceView = (BalanceViewType)Enum.Parse(typeof(BalanceViewType), button.Tag.ToString());
            UpdateUI(true);
        }
        #endregion
    }
}