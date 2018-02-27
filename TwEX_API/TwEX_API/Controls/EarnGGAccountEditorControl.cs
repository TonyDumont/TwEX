using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TwEX_API.Faucet;
using System.Reflection;
using System.Drawing;
using System.Linq;

namespace TwEX_API.Controls
{
    public partial class EarnGGAccountEditorControl : UserControl
    {
        #region Properties
        EarnGG.EarnGGAccount account = new EarnGG.EarnGGAccount();
        #endregion

        #region Initialize
        public EarnGGAccountEditorControl()
        {
            InitializeComponent();
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
                this.Invoke(d, new object[] { });
            }
            else
            {

                int rowHeight = button_load.Height;
                //listView.Font = ParentForm.Font;
                //LogManager.AddLogMessage(Name, "ResizeUI", "RESIZING", LogManager.LogMessageType.DEBUG); 
                int listWidth = 0;
                int listHeight = 0;

                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    //col.Width = col.Width + padding;
                    listWidth += col.Width;
                }

                if (listView.Items.Count > 0)
                {
                    var last = listView.Items[listView.Items.Count - 1];
                    listHeight = listView.Top + last.Bounds.Bottom;
                    //listView.Size = new Size(listWidth + padding, listHeight);
                }

                ParentForm.ClientSize = new Size(listWidth, (4 * rowHeight) + listHeight);
                //column_Name.Width = column_Name.Width + iconSize + 2;

                //UpdateUI();
                
            }
        }
        #endregion

        #region EventHandlers
        private void button_load_Click(object sender, EventArgs e)
        {
            try
            {
                EarnGG.EarnGGAccount newAccount = EarnGG.GetAccount(textBox_key.Text, textBox_secret.Text);

                if (newAccount != null)
                {
                    //LogManager.AddLogMessage(Name, "button_load_Click", "account=" + account.email, LogManager.LogMessageType.DEBUG);
                    account = newAccount;
                    List<PropertyItem> list = new List<PropertyItem>();

                    PropertyInfo[] properties = typeof(EarnGG.EarnGGAccount).GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        ///LogManager.AddLogMessage(Name, "button_load_Click", property.Name + " | " + property.GetValue(account), LogManager.LogMessageType.DEBUG);
                        PropertyItem item = new PropertyItem() { Name = property.Name };

                        if (property.GetValue(account) != null && item.Name != "api")
                        {
                            item.Value = property.GetValue(account).ToString();
                            list.Add(item);
                        }
                    }
                    listView.SetObjects(list);
                    UpdateUI(true);
                }
            }
            catch (Exception ex)
            {
                LogManager.AddLogMessage(Name, "button_load_Click", ex.Message, LogManager.LogMessageType.EXCEPTION);
            }  
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            //account.api
            if (account.api.key.Length > 0 && account.api.secret.Length > 0)
            {
                EarnGG.EarnGGAccount listItem = PreferenceManager.EarnGGPreferences.EarnGGAccounts.FirstOrDefault(item => item.api.key == account.api.key && item.api.secret == account.api.secret);
                if (listItem == null)
                {
                    PreferenceManager.EarnGGPreferences.EarnGGAccounts.Add(account);
                    //PreferenceManager.UpdatePreferenceSnapshots();
                    PreferenceManager.UpdatePreferenceFile(PreferenceManager.PreferenceType.EarnGG);
                    EarnGG.UpdateUI();
                    ParentForm.Close();
                }
            }
        }
        #endregion

        #region DataModels
        public class PropertyItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        #endregion 
    }
}
