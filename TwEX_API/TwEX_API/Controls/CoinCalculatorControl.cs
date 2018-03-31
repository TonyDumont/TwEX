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
        private string sort = "Symbol";
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
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripButton_AddSymbol.Image = ContentManager.GetIcon("Add");

            Size iconSize = PreferenceManager.preferences.IconSize;

            pictureBox_usd.Size = PreferenceManager.preferences.IconSize;
            pictureBox_symbol.Size = PreferenceManager.preferences.IconSize;
            pictureBox_usd.Image = ContentManager.ResizeImage(ContentManager.GetIcon("USDSymbol"), iconSize.Width, iconSize.Height);
            //label_usd.Image = ContentManager.ResizeImage(ContentManager.GetIcon("USD"), iconSize.Width, iconSize.Height);
            label_symbol.Text = PreferenceManager.preferences.CalculatorSymbol;
            pictureBox_symbol.Image = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(PreferenceManager.preferences.CalculatorSymbol), iconSize.Width, iconSize.Height);
            //label_symbol.Image = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(PreferenceManager.preferences.CalculatorSymbol), iconSize.Width, iconSize.Height);
            numericUpDown_symbol.Maximum = Decimal.MaxValue;
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_symbol.ImageGetter = new ImageGetterDelegate(aspect_icon);
            column_value.AspectGetter = new AspectGetterDelegate(aspect_value);
            column_price.AspectGetter = new AspectGetterDelegate(aspect_price);
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
            if (InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                Invoke(d, new object[] { resize });
            }
            else
            {
                try
                {
                    if (sort == "Symbol")
                    {
                        listView.SetObjects(symbolList.OrderBy(item => item.symbol));
                    }
                    else
                    {
                        listView.SetObjects(symbolList.OrderBy(item => item.value));
                    }

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
            if (InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                //toolStrip.Font = ParentForm.Font;
                //toolStrip.ImageScalingSize = PreferenceManager.preferences.IconSize;
                toolStrip_footer.ImageScalingSize = PreferenceManager.preferences.IconSize;

                column_symbol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column_price.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                column_symbol.Width = column_symbol.Width + listView.RowHeightEffective;
                column_price.Width = column_symbol.Width + listView.RowHeightEffective;
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
        /*
        public object aspect_symbol(object rowObject)
        {
            CalculatorItem listItem = (CalculatorItem)rowObject;

            CoinMarketCapTicker priceItem = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == listItem.symbol);
            Decimal total = 0;
            string price = "";

            if (priceItem != null)
            {
                total = numericUpDown_usd.Value / priceItem.price_usd;
                listItem.value = total;
                price = priceItem.price_usd.ToString("C");
            }
            return listItem.symbol + " (" + price + ")";
        }
        */
        public object aspect_price(object rowObject)
        {
            CalculatorItem listItem = (CalculatorItem)rowObject;

            CoinMarketCapTicker priceItem = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == listItem.symbol);
            Decimal total = 0;
            string price = "";

            if (priceItem != null)
            {
                total = numericUpDown_usd.Value / priceItem.price_usd;
                listItem.value = total;
                price = priceItem.price_usd.ToString("C");
            }
            return price;
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
                pictureBox_symbol.Image = ContentManager.ResizeImage(ContentManager.GetSymbolIcon(item.symbol), PreferenceManager.preferences.IconSize.Width, PreferenceManager.preferences.IconSize.Height);
            }
            else
            {
                LogManager.AddLogMessage(Name, "listView_SelectionChanged", "IS NULL", LogManager.LogMessageType.DEBUG);
            }
        }
        private void numericUpDown_symbol_ValueChanged(object sender, EventArgs e)
        {
            CoinMarketCapTicker priceItem = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == label_symbol.Text);

            if (priceItem != null)
            {
                numericUpDown_usd.Value = priceItem.price_usd * numericUpDown_symbol.Value;
            }
            UpdateUI();
        }
        private void numericUpDown_usd_ValueChanged(object sender, EventArgs e)
        {
            CoinMarketCapTicker priceItem = PreferenceManager.CoinMarketCapPreferences.Tickers.FirstOrDefault(item => item.symbol == label_symbol.Text);

            if (priceItem != null)
            {
                numericUpDown_symbol.Value = numericUpDown_usd.Value / priceItem.price_usd;
            }
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

                    case "RemoveAll":
                        //ToggleCharts();
                        PreferenceManager.preferences.SymbolWatchList.Clear();
                        PreferenceManager.UpdatePreferenceFile();
                        InitializeSymbolList();
                        break;
                        
                    case "SortSymbol":
                        sort = "Symbol";
                        UpdateUI();
                        break;

                    case "SortValue":
                        sort = "Value";
                        UpdateUI();
                        break;

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
