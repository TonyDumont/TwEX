using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.Market.CoinMarketCap;
using BrightIdeasSoftware;

namespace TwEX_API.Controls
{
    public partial class CoinCalculatorControl : UserControl
    {
        #region Properties
        private List<CalculatorItem> symbolList = new List<CalculatorItem>();
        #endregion

        #region Initialize
        public CoinCalculatorControl()
        {
            InitializeComponent();
            InitializeSymbolList();
            InitializeColumns();
        }
        private void CoinCalculatorControl_Load(object sender, EventArgs e)
        {
            //toolStripButton_Font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");

            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            //toolStripMenuItem_add.Image = ContentManager.GetIconByUrl(ContentManager.AddWalletIconUrl);
            toolStripButton_AddSymbol.Image = ContentManager.GetIcon("Add");

            //toolStripMenuItem_update.Image = ContentManager.GetIconByUrl(ContentManager.RefreshIcon);
            //listView.SetObjects(symbolList);
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_symbol.ImageGetter = new ImageGetterDelegate(aspect_icon);
            column_value.AspectGetter = new AspectGetterDelegate(aspect_value);
        }
        private void InitializeSymbolList()
        {
            symbolList.Clear();
            //LogManager.AddLogMessage(Name, "InitializeSymbolList", ExchangeManager.preferences.symbolList.Count + " Symmbols in List", LogManager.LogMessageType.DEBUG);
            foreach (string symbol in PreferenceManager.preferences.SymbolWatchList)
            {
                //LogManager.AddLogMessage(Name, "InitializeSymbolList", symbol, LogManager.LogMessageType.DEBUG);
                CalculatorItem item = new CalculatorItem() { symbol = symbol, value = 0 };
                symbolList.Add(item);
            }
            UpdateUI();
        }
        #endregion

        #region Delegates
        delegate void UpdateUICallback(bool resize = false);
        public void UpdateUI(bool resize = false)
        {
            if (this.InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                this.Invoke(d, new object[] { resize });
            }
            else
            {
                try
                {
                    listView.SetObjects(symbolList);

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
                //Font = this.ParentForm.Font;
                //toolStrip.Font = ParentForm.Font;
                //toolStrip_footer.Font = ParentForm.Font;
                toolStrip.ImageScalingSize = PreferenceManager.preferences.IconSize;
                //toolStripButton_AddSymbol.Font = ParentForm.Font;

                //toolStripSpringTextBox_symbol.Font = ParentForm.Font;
                //toolStripButton_AddSymbol.Font = ParentForm.Font;
                //Size textSize = TextRenderer.MeasureText("OOOOO", ParentForm.Font);
                column_symbol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_symbol.Width = column_symbol.Width + (listView.RowHeightEffective);
                //column_symbol.Width = textSize.Width + (listView.RowHeightEffective * 2);
                //column_symbol.Width = 200;
                /*
                int columnWidth = column_symbol.Width;
                int rowHeight = listView.RowHeightEffective;

                //tableLayoutPanel.ColumnStyles[1].SizeType = SizeType.Absolute;
                tableLayoutPanel.ColumnStyles[1].Width = columnWidth;
                //tableLayoutPanel.RowStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanel.RowStyles[0].Height = rowHeight;
                //tableLayoutPanel.RowStyles[1].SizeType = SizeType.Absolute;
                tableLayoutPanel.RowStyles[1].Height = rowHeight;
                */

                /*
                toolStrip_header.Font = ParentForm.Font;
                toolStrip_footer.Font = ParentForm.Font;

                int rowHeight = listView.RowHeightEffective;

                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + (rowHeight / 2);
                }
                */
                //PreferenceManager.UpdateFormPreferences(ParentForm, true);

            }
        }
        #endregion

        #region AspectGetters
        public object aspect_icon(object rowObject)
        {
            
            //Machine m = (Machine)rowObject;
            CalculatorItem e = (CalculatorItem)rowObject;
            if (e != null)
            {
                //return DataManager.ResizeImage(ExchangeManager.GetExchangeImage(e.exchange), 24, 24);
                return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(e.symbol), listView.RowHeightEffective, listView.RowHeightEffective);
            }
            else
            {
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
            }
            
        }
        public object aspect_symbol(object rowObject)
        {
            CalculatorItem listItem = (CalculatorItem)rowObject;

            CoinMarketCapTicker priceItem = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == listItem.symbol);
            Decimal total = 0;

            if (priceItem != null)
            {
                total = numericUpDown_usd.Value / priceItem.price_usd;
                listItem.value = total;
            }
            return listItem.symbol;
        }
        public object aspect_value(object rowObject)
        {
            CalculatorItem listItem = (CalculatorItem)rowObject;

            CoinMarketCapTicker priceItem = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == listItem.symbol);
            Decimal total = 0;

            if (priceItem != null)
            {
                total = numericUpDown_usd.Value / priceItem.price_usd;
            }
            return total.ToString("N8");
        }
        #endregion

        #region EventHandlers
        private void listView_SelectionChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                CalculatorItem item = listView.SelectedObject as CalculatorItem;
                numericUpDown_symbol.Value = item.value;
                label_symbol.Text = item.symbol;
            }
            else
            {
                LogManager.AddLogMessage(Name, "listView_SelectionChanged", "IS NULL", LogManager.LogMessageType.DEBUG);
            }
        }
        private void numericUpDown_symbol_ValueChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                CalculatorItem listItem = listView.SelectedObject as CalculatorItem;

                CoinMarketCapTicker ticker = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == listItem.symbol);
                //Decimal total = 0;

                if (ticker != null)
                {
                    //total = numericUpDown_symbol.Value * priceItem.price_usd;
                    numericUpDown_usd.Value = numericUpDown_symbol.Value * ticker.price_usd;
                    //listItem.value = total;
                    UpdateUI();
                }
            }
        }
        private void numericUpDown_usd_ValueChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if (listView.SelectedObject != null)
                    {
                        CalculatorItem item = listView.SelectedObject as CalculatorItem;
                        ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem menuItem = new ToolStripMenuItem() { Text = "Remove " + item.symbol };
                        menuItem.Click += new EventHandler(RemoveItem_Menu_Click);
                        menu.Items.Add(menuItem);
                        menu.Show(Cursor.Position);
                    }
                }
            }
        }
        private void RemoveItem_Menu_Click(object sender, EventArgs e)
        {
            string symbol = sender.ToString().Replace("Remove ", "");
            //LogManager.AddLogMessage(Name, "RemoveItem_Menu_Click", "Removing " + symbol + " From Symbol List", LogManager.LogMessageType.DEBUG);
            PreferenceManager.RemoveSymbolFromWatchlist(symbol);
            InitializeSymbolList();
        }
        private void toolStripButton_AddSymbol_Click(object sender, EventArgs e)
        {
            if (toolStripSpringTextBox_symbol.Text.Length > 0)
            {
                PreferenceManager.AddSymbolToWatchlist(toolStripSpringTextBox_symbol.Text.ToUpper());
                toolStripSpringTextBox_symbol.Text = "";
            }
            InitializeSymbolList();
        }
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
                        /*
                    case "Charts":
                        ToggleCharts();
                        break;
                        
                    case "Update":
                        UpdateUI();
                        break;
                        */
                    default:
                        // NOTHING
                        break;
                }

            }
        }
        #endregion
    }

    public class CalculatorItem
    {
        public string symbol { get; set; }
        public Decimal value { get; set; }
    }
}
