using BrightIdeasSoftware;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.Market.CoinMarketCap;

namespace TwEX_API.Controls
{
    public partial class CoinMarketCapControl : UserControl
    {
        #region Initialize
        public CoinMarketCapControl()
        {
            InitializeComponent();
            FormManager.coinMarketCapControl = this;
            InitializeColumns();
            InitializeIcons();
        }
        private void CoinMarketCapControl_Load(object sender, EventArgs e)
        {         
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_name.ImageGetter = new ImageGetterDelegate(aspect_icon);
            column_24hchange.AspectGetter = new AspectGetterDelegate(aspect_24hchange);
        }
        private void InitializeIcons()
        {
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripMenuItem_update.Image = ContentManager.GetIcon("Refresh");
            toolStripButton_search.Image = ContentManager.GetIcon("SearchList");
        }
        #endregion

        #region Delegates
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
                //toolStrip.Font = ParentForm.Font;
                //listView.Font = ParentForm.Font;
                int rowHeight = listView.RowHeightEffective;
                int formWidth = 0;

                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + (rowHeight / 2);
                    formWidth += col.Width;
                }
                
                if (Parent.GetType() == typeof(Form))
                {
                    ParentForm.Width = formWidth + 50;
                }
            }
        }

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
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                toolStripLabel_details.Text = PreferenceManager.CoinMarketCapPreferences.Tickers.Count + " Coins (" + PreferenceManager.CoinMarketCapPreferences.Tickers.Sum(t => t.market_cap_usd).ToString("C") + ")";
                listView.SetObjects(PreferenceManager.CoinMarketCapPreferences.Tickers.OrderBy(item => item.rank));
                toolStripLabel_update.Text = DateTime.Now.ToString();

                if (resize)
                {
                    ResizeUI();
                }
            }
        }
        #endregion

        #region Getters
        public object aspect_icon(object rowObject)
        {
            CoinMarketCapTicker e = (CoinMarketCapTicker)rowObject;

            if (e != null)
            {
                return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(e.symbol), listView.RowHeightEffective, listView.RowHeightEffective);
            }
            else
            {
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
            }
        }
        public object aspect_24hchange(object rowObject)
        {
            CoinMarketCapTicker ticker = (CoinMarketCapTicker)rowObject;
            return ticker.percent_change_24h + "%";
        }
        #endregion

        #region Event_Handlers
        private void toolStripDropDownButton_menu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
                //LogManager.AddLogMessage(Name, "toolStripDropDownButton_menu_DropDownItemClicked", menuItem.Tag.ToString() + " | " + menuItem.Text, LogManager.LogMessageType.DEBUG);
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
                        //UpdateUI(true);
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
                        
                    case "Update":
                        updateTickers();
                        UpdateUI();
                        break;

                    default:
                        // NOTHING
                        break;
                }
            }
        }
        private void toolStripLabel_update_Click(object sender, EventArgs e)
        {
            updateTickers();
            UpdateUI();
        }
        private void toolStripTextBox_search_TextChanged(object sender, EventArgs e)
        {
            listView.ModelFilter = TextMatchFilter.Contains(listView, toolStripTextBox_search.Text);
            toolStripLabel_details.Text = PreferenceManager.CoinMarketCapPreferences.Tickers.Count + " Coins (" + PreferenceManager.CoinMarketCapPreferences.Tickers.Sum(t => t.market_cap_usd).ToString("C") + ")";
        }
        #endregion

        #region Formatters
        private void ListView_FormatCell(object sender, FormatCellEventArgs e)
        {
            CoinMarketCapTicker ticker = (CoinMarketCapTicker)e.Model;

            if (e.ColumnIndex == column_24hchange.Index)
            {
                if (ticker.percent_change_24h > 0)
                {
                    e.SubItem.BackColor = PreferenceManager.preferences.Theme.Green;
                }
                else
                {
                    e.SubItem.BackColor = PreferenceManager.preferences.Theme.Red;
                }
            }
        }
        #endregion
    }
}
