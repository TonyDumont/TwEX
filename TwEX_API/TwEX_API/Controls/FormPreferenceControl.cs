using System;
using System.Windows.Forms;
using BrightIdeasSoftware;
using static TwEX_API.PreferenceManager;

namespace TwEX_API.Controls
{
    public partial class FormPreferenceControl : UserControl
    {
        #region Initialize
        public FormPreferenceControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void FormPreferenceEditorControl_Load(object sender, EventArgs e)
        {
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_Name.ImageGetter = new ImageGetterDelegate(aspect_icon);
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
                    listView.SetObjects(PreferenceManager.FormPreferences);
                    groupBox.Text = listView.Items.Count + " Forms";

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
                this.Invoke(d, new object[] { });
            }
            else
            {
                listView.Font = ParentForm.Font;

                column_Name.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                Width = column_Name.Width + (listView.RowHeightEffective * 2);
            }
        }
        #endregion

        #region Getters
        private object aspect_icon(object rowObject)
        {
            PreferenceManager.FormPreference preference = (PreferenceManager.FormPreference)rowObject;
            int rowheight = listView.RowHeightEffective - 2;
            return ContentManager.ResizeImage(ContentManager.GetIcon(preference.Name), rowheight, rowheight);
        }
        #endregion

        #region EventHandlers
        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if (listView.SelectedObject != null)
                    {

                        
                        //ListItem item = listView.SelectedObject as ListItem;
                        FormPreference preference = listView.SelectedObject as FormPreference;

                        //CalculatorItem item = listView.SelectedObject as CalculatorItem;
                        ContextMenuStrip menu = new ContextMenuStrip();

                        ToolStripMenuItem menuItem = new ToolStripMenuItem() { Text = "Reset " + preference.Name };
                        menuItem.Click += new EventHandler(reset_Menu_Click);
                        menu.Items.Add(menuItem);
                        /*
                        ToolStripMenuItem exportItem = new ToolStripMenuItem() { Text = "Export " + item.Name, Tag = item.Name };
                        exportItem.Click += new EventHandler(export_Menu_Click);
                        menu.Items.Add(exportItem);
                        */
                        menu.Show(Cursor.Position);
                        
                    }
                }
            }
        }
        
        private void reset_Menu_Click(object sender, EventArgs e)
        {
            FormPreference preference = listView.SelectedObject as FormPreference;
            LogManager.AddLogMessage(Name, "reset_Menu_Click", preference.Name, LogManager.LogMessageType.DEBUG);
            ResetForm(preference);
            //PreferenceManager.ExportPreferences(item.type);
        }
        /*
        private void import_Menu_Click(object sender, EventArgs e)
        {
            ListItem item = listView.SelectedObject as ListItem;
            //LogManager.AddLogMessage(Name, "import_Menu_Click", item.Name, LogManager.LogMessageType.DEBUG);
            PreferenceManager.ImportPreferences(item.type);
        }
        */
        #endregion
    }
}
