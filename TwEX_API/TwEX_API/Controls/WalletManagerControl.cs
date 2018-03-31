using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TwEX_API.Wallet;
using static TwEX_API.ExchangeManager;
using static TwEX_API.WalletManager;

namespace TwEX_API.Controls
{
    public partial class WalletManagerControl : UserControl
    {
        #region Properties
        private bool collapsed = false;
        private Dictionary<string, bool> groupStates = new Dictionary<string, bool>();
        #endregion

        #region Initialize
        public WalletManagerControl()
        {
            InitializeComponent();
            FormManager.walletManagerControl = this;
            InitializeColumns();
            
        }
        private void WalletManagerControl_Load(object sender, EventArgs e)
        {
            InitializeIcons();

            listView.AlwaysGroupByColumn = column_WalletName;
            listView.HasCollapsibleGroups = true;
            listView.ShowGroups = true;

            toolStripButton_collapse.Image = ContentManager.GetIcon("UpDown");
            listView.GroupExpandingCollapsing += ListView_GroupExpandingCollapsing;
            /*
            column_Symbol.IsVisible = false;
            column_SymbolIcon.IsVisible = false;
            column_ExchangeIcon.IsVisible = true;
            column_Balance.IsVisible = true;

            listView.RebuildColumns();
            toolStripButton_collapse.Visible = true;
            listView.BackColor = PreferenceManager.preferences.Theme.AlternateBackground;
            //listView.BackgroundImage = null;
            //listView.BackColor = Color.LightGray;
            BackColor = PreferenceManager.preferences.Theme.AlternateBackground;
            */
            //listView.SetObjects(WalletManager.Wallets.Where(item => item.Balance > 0));
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_Name.ImageGetter = new ImageGetterDelegate(aspect_Icon);
            column_Symbol.ImageGetter = new ImageGetterDelegate(aspect_Symbol);
        }
        private void InitializeIcons()
        {
            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            toolStripMenuItem_add.Image = ContentManager.GetIcon("AddWallet");
            toolStripMenuItem_update.Image = ContentManager.GetIcon("Refresh");
        }
        #endregion

        #region Delegates
        delegate bool UpdateUICallback(bool resize = false);
        public bool UpdateUI(bool resize = false)
        {
            if (this.InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                this.Invoke(d, new object[] { resize });
            }
            else
            {
                listView.SetObjects(PreferenceManager.WalletPreferences.Wallets);
                //listView.SetObjects(PreferenceManager.WalletPreferences.Wallets.OrderBy(wallet => wallet.WalletName));
                //listView.Sort(column_TotalInBTC, SortOrder.Descending);

                toolStripLabel_title.Text = PreferenceManager.WalletPreferences.Wallets.Count + " Wallets";
                toolStripLabel_btc.Text = PreferenceManager.WalletPreferences.Wallets.Sum(b => b.TotalInBTC).ToString("N8");
                toolStripLabel_usd.Text = PreferenceManager.WalletPreferences.Wallets.Sum(b => b.TotalInUSD).ToString("C");

                toolStripButton_timer.Checked = (PreferenceManager.preferences.TimerFlags & ExchangeTimerType.WALLETS) != ExchangeTimerType.NONE;
                //toolStripButton_Tickers.Text = "TICKERS (" + ExchangeManager.Tickers.Count + ")";
                toolStripButton_timer.Image = ContentManager.GetActiveIcon(toolStripButton_timer.Checked);
                //LogManager.AddLogMessage(Name, "UpdateUI", "Updating - " + resize, LogManager.LogMessageType.DEBUG);
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
            if (this.InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                //toolStrip.Font = ParentForm.Font;
                //toolStrip_footer.Font = ParentForm.Font;
                //listView.Font = ParentForm.Font;
                //LogManager.AddLogMessage(Name, "ResizeUI", "RESIZING", LogManager.LogMessageType.DEBUG);
                Size textSize = TextRenderer.MeasureText("0.00000000", ParentForm.Font);
                int rowHeight = listView.RowHeightEffective;
                int padding = rowHeight / 2;
                int iconSize = rowHeight - 2;         
                //int listWidth = 0;
                int listHeight = 0;

                toolStrip.ImageScalingSize = new Size(iconSize, iconSize);

                column_Symbol.Width = iconSize;
                column_TotalInUSD.Width = textSize.Width;
                column_TotalInBTC.Width = textSize.Width;
                column_Balance.Width = textSize.Width + (textSize.Width / 2);
                /*
                //int listWidth = 0;
                //int listHeight = 0;
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    //col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //col.Width = col.Width + (rowHeight / 2);
                    listWidth += col.Width;
                }
                */


                //column_Tickers.Width = 
                /*
                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 4];
                    listHeight = listView.Top + last.Bounds.Bottom;
                    //listHeight = last.Bounds.Bottom;
                    //LogManager.AddLogMessage(Name, "ResizeUI", listView.Top + " | " + last.Bounds.Bottom + " | " + listHeight);
                }
                */
                listView.Height = listHeight;
                ClientSize = new Size(Width, listHeight + (toolStrip.Height * 2) - (listView.RowHeightEffective / 2));
                Size = new Size(Width, listHeight + (toolStrip.Height * 2) - (listView.RowHeightEffective / 2));


                /*
                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + padding;
                    listWidth += col.Width;
                }

                column_Name.Width = column_Name.Width + iconSize;
                listWidth += iconSize;

                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 3];
                    listHeight = listView.Top + last.Bounds.Bottom;
                }
                */





                /*
                Rectangle screenRectangle = RectangleToScreen(ParentForm.ClientRectangle);
                int titleHeight = screenRectangle.Top - ParentForm.Top;
                int formHeight = titleHeight + listHeight;
                int totalHeight = titleHeight + listHeight + toolStrip.Height + padding;
                //LogManager.AddLogMessage(Name, "ResizeUI", "titleHeight=" + titleHeight + " | listHeight=" + listHeight + " | " + toolStrip_header.Height + " | " + toolStrip_header2.Height);
                ParentForm.ClientSize = new Size(listWidth + (padding * 2), totalHeight);
                */
                //UpdateUI();
            }
        }
        #endregion

        #region Getters
        private void aboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "view=" + view + " | group.count=" + e.Groups.Count, LogManager.LogMessageType.OTHER);
            List<ExchangeBalance> balances = GetBalances();
            listView.GroupImageList = ContentManager.WalletIconList;

            foreach (OLVGroup group in e.Groups)
            {
                string key = group.Key.ToString();

                if (!groupStates.ContainsKey(key))
                {
                    groupStates.Add(key, false);
                }

                //LogManager.AddLogMessage(Name, "aboutToCreateGroups", "GroupId=" + group.Items.Count + " | Header=" + group.Header + " | id=" + group.Id + " | Key=" + group.Key + " | name=" + group.Name + " | " + group.Collapsed);
                decimal usdTotal = balances.Where(item => item.Exchange == key.ToString() && item.Balance > 0).Sum(b => b.TotalInUSD);
                decimal btcTotal = balances.Where(item => item.Exchange == key.ToString() && item.Balance > 0).Sum(b => b.TotalInBTC);
                group.Header = group.Header.ToUpper();
                group.TitleImage = key;

                if (group.Items.Count > 1)
                {
                    group.Task = "[" + group.Items.Count + "] " + usdTotal.ToString("C");
                }
                else
                {
                    group.Task = usdTotal.ToString("C");
                }

                group.Subtitle = "(" + btcTotal.ToString("N8") + ")";
                group.Collapsed = groupStates[key];
            }
        }
        private object aspect_Icon(object rowObject)
        {
            WalletManager.WalletBalance balance = (WalletManager.WalletBalance)rowObject;
            int rowheight = listView.RowHeightEffective - 3;
            return ContentManager.ResizeImage(ContentManager.GetWalletIcon(balance.WalletName), rowheight, rowheight);
            //return ContentManager.GetWalletIcon(balance.WalletName);
        }
        private object aspect_Symbol(object rowObject)
        {
            WalletBalance balance = (WalletBalance)rowObject;
            int rowheight = listView.RowHeightEffective - 3;
            return ContentManager.ResizeImage(ContentManager.GetSymbolIcon(balance.Symbol), rowheight, rowheight);
        }
        #endregion
        
        #region EventHandlers
        private void ListView_GroupExpandingCollapsing(object sender, GroupExpandingCollapsingEventArgs e)
        {
            //throw new NotImplementedException();
            //var list = listView.Groups;
            //LogManager.AddLogMessage(Name, "ListView_GroupExpandingCollapsing", e.Group.Key + " | " + e.IsExpanding, LogManager.LogMessageType.DEBUG);
            string key = e.Group.Key.ToString();

            
            if (e.IsExpanding)
            {
                groupStates[key] = false;
            }
            else
            {
                groupStates[key] = true;
            }
            
            //bool isExpanding = 
            //groupStates[key] = 
            //ResizeUI();
            //BrightIdeasSoftware.OLVGroup groups = listView.OLVGroups;
        }
        private void listView_ItemActivate(object sender, EventArgs e)
        {
            WalletBalance wallet = listView.SelectedObject as WalletBalance;

            Form form = new Form()
            {
                Text = "Wallet Editor",
                StartPosition = FormStartPosition.CenterScreen,
                Font = ParentForm.Font
            };

            WalletEditorControl control = new WalletEditorControl()
            {
                Dock = DockStyle.Fill
            };

            form.Controls.Add(control);
            control.UpdateData(wallet);
            PreferenceManager.SetControlTheme(control, PreferenceManager.preferences.Theme, form);
            form.Show();
        }
        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if (listView.SelectedObject != null)
                    {
                        WalletBalance item = listView.SelectedObject as WalletBalance;
                        ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem menuItem = new ToolStripMenuItem() { Text = "Remove " + item.Name + "_" + item.Symbol + "_" + item.Address };
                        menuItem.Click += new EventHandler(RemoveItem_Menu_Click);
                        menu.Items.Add(menuItem);

                        //ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem importItem = new ToolStripMenuItem() { Text = "Import Forks For " + item.Name + "_" + item.Symbol + "_" + item.Address };
                        importItem.Click += new EventHandler(ImportItem_Menu_Click);
                        menu.Items.Add(importItem);

                        menu.Show(Cursor.Position);

                    }
                }
            }
        }
        private void ImportItem_Menu_Click(object sender, EventArgs e)
        {
            string data = sender.ToString().Replace("Import Forks For ", "");
            string[] split = data.Split('_');
            string name = split[0];
            string symbol = split[1];
            string address = split[2];
            
            WalletBalance wallet = PreferenceManager.WalletPreferences.Wallets.FirstOrDefault(item => item.Name == name && item.Symbol == symbol && item.Address == address);

            if (wallet != null)
            {
                LogManager.AddLogMessage(Name, "ImportItem_Menu_Click", "Import For : " + wallet.Address, LogManager.LogMessageType.DEBUG);
                Form form = new Form()
                {
                    Text = "Import Forks For " + wallet.Address,
                    StartPosition = FormStartPosition.CenterScreen,
                    Font = ParentForm.Font,
                    Width = 1200,
                    Height = 900
                };

                ImportForksControl control = new ImportForksControl()
                {
                    Dock = DockStyle.Fill
                };
                control.wallet = wallet;
                form.Controls.Add(control);
                //control.UpdateData(wallet);
                form.Show();

                /*
                PreferenceManager.WalletPreferences.Wallets.Remove(wallet);
                PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Wallet);
                FormManager.UpdateBalanceManager();
                UpdateUI();
                */
            }
        }
        private void RemoveItem_Menu_Click(object sender, EventArgs e)
        {
            string data = sender.ToString().Replace("Remove ", "");
            string[] split = data.Split('_');
            string name = split[0];
            string symbol = split[1];
            string address = split[2];
            //LogManager.AddLogMessage(Name, "RemoveItem_Menu_Click", "Removing " + symbol + " From Symbol List", LogManager.LogMessageType.DEBUG);
            WalletBalance wallet = PreferenceManager.WalletPreferences.Wallets.FirstOrDefault(item => item.Name == name && item.Symbol == symbol && item.Address == address);

            if (wallet != null)
            {
                PreferenceManager.WalletPreferences.Wallets.Remove(wallet);
                PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.Wallet);
                FormManager.UpdateBalanceManager();
                UpdateUI();
            }
        }
        private void toolStripButton_timer_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ExchangeTimerType type = getExchangeTimerType(button.Tag.ToString());
            PreferenceManager.toggleTimerPreference(type);
            UpdateUI();
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
                        //fontDialog.Font = ParentForm.Font;
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

                    case "AddWallet":
                        Form form = new Form()
                        {
                            Text = "Wallet Editor",
                            StartPosition = FormStartPosition.CenterScreen,
                            Font = ParentForm.Font
                        };

                        WalletEditorControl control = new WalletEditorControl()
                        {
                            Dock = DockStyle.Fill
                        };

                        form.Controls.Add(control);
                        form.Show();
                        break;

                    case "UpdateWallets":

                        
                        if (WalletManager.UpdateWallets())
                        {
                            //UpdateUI();
                        }
                        /*
                        var client = new RestClient("http://public.coindaddy.io");
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("cache-control", "no-cache");
                        //request.AddHeader("authorization", "Basic cnBjOjEyMzQ=");
                        request.AddHeader("authorization", "Basic user=rpc&PASSWORD=");
                        request.AddHeader("content-type", "application/json");
                        request.AddParameter("application/json", "{\r\n  \"method\": \"get_running_info\",\r\n  \"params\": {},\r\n  \"jsonrpc\": \"2.0\",\r\n  \"id\": 1\r\n}", ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);
                        */
                        break;

                    default:
                        // NOTHING
                        break;
                }

            }
        }
        private void toolStripButton_toggleGroup_Click(object sender, EventArgs e)
        {
            toggleCollapsed();
        }
        private void toggleCollapsed()
        {
            
            collapsed = !collapsed;
            
            for (int i = 0; i < listView.OLVGroups.Count; i++)
            {
                OLVGroup grp = listView.OLVGroups[i];
                //LogManager.AddLogMessage(Name, "toggleCollapsed", grp.Header + " | " + grp.Collapsed);
                grp.Collapsed = collapsed;
            }

            foreach (var item in groupStates.ToList())
            {
                groupStates[item.Key] = collapsed;
            }

            //decimal ba = BlockCypher.getBalance("ETH", "0xBf09539E0e928f9Be762240c4a4f5DA7CAf706A6");
            //LogManager.AddLogMessage(Name, "UpdateWallets", "balance=" + ba, LogManager.LogMessageType.DEBUG);

            //balance.TotalInBTC = GetMarketCapBTCAmount(balance.Symbol, balance.Balance);
            //balance.TotalInUSD = GetMarketCapUSDAmount(balance.Symbol, balance.Balance);

            //Decimal value = BlockTrail.getBalance("bcc", "14E9wmAbKPrCpP6XSYaH3u1CbW1suEHwyH");
            //LogManager.AddLogMessage(Name, "toggleCollapsed", "value=" + value.ToString()); 
            /*
            RestClient client = new RestClient("https://www.ub.com/explorer");
            var request = new RestRequest("/address?address=17R9JYUUTq2rzgRq2kxSXPi9597jBjMb2g", Method.GET);
            var response = client.Execute(request);
            LogManager.AddLogMessage(Name, "getTicker", "response.Content=" + response.Content, LogManager.LogMessageType.OTHER);
            //var jsonObject = JObject.Parse(response.Content);

            //AddressBalanceEndpoint balance = jsonObject.ToObject<AddressBalanceEndpoint>();
            //Decimal value = balance.balance / 100000000;
            */
        }
        #endregion
    }
}