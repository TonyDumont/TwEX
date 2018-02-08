using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static TwEX_API.PreferenceManager;

namespace TwEX_API.Controls
{
    public partial class PreferenceEditorControl : UserControl
    {
        #region Initialize
        public PreferenceEditorControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void PreferenceEditorControl_Load(object sender, System.EventArgs e)
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
                
                var values = EnumUtils.GetValues<PreferenceType>();
                List<TypeListItem> list = new List<TypeListItem>();

                foreach (PreferenceType type in values)
                {
                    //LogManager.AddLogMessage(Name, "UpdateUI", type.ToString() + " | " + type.GetHashCode(), LogManager.LogMessageType.DEBUG);
                    TypeListItem item = new TypeListItem()
                    {
                        Name = type.ToString(),
                        type = type.GetType()
                    };

                    if (item.Name != "None")
                    {
                        list.Add(item);
                    }
                    else
                    {
                        item.Name = "Application";
                        list.Add(item);
                    }
                }
                listView.SetObjects(list);
                //listView.SetObjects(ExchangeManager.Exchanges);
                groupBox.Text = listView.Items.Count + " Preferences";

                if (resize)
                {
                    ResizeUI();
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
                ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                listView.Font = ParentForm.Font;

                column_Name.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                Width = column_Name.Width + (listView.RowHeightEffective * 2);
            }
        }
        #endregion

        #region Getters
        private object aspect_icon(object rowObject)
        {
            //Machine m = (Machine)rowObject;
            TypeListItem item = (TypeListItem)rowObject;
            //int rowheight = listView.RowHeightEffective - 2;
            //string iconName = EnumUtils.GetDescription(item.Name);
            //return ContentManager.ResizeImage(ContentManager.GetIcon(iconName), listView.RowHeightEffective, listView.RowHeightEffective);
            return ContentManager.ResizeImage(ContentManager.GetIcon(item.Name), listView.RowHeightEffective, listView.RowHeightEffective);
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
                        TypeListItem item = listView.SelectedObject as TypeListItem;

                        
                        //CalculatorItem item = listView.SelectedObject as CalculatorItem;
                        ContextMenuStrip menu = new ContextMenuStrip();

                        ToolStripMenuItem importItem = new ToolStripMenuItem() { Text = "Import " + item.Name, Tag = item.Name };
                        importItem.Click += new EventHandler(import_Menu_Click);
                        menu.Items.Add(importItem);

                        ToolStripMenuItem exportItem = new ToolStripMenuItem() { Text = "Export " + item.Name, Tag = item.Name };
                        exportItem.Click += new EventHandler(export_Menu_Click);
                        menu.Items.Add(exportItem);

                        menu.Show(Cursor.Position);
                        
                    }
                }
            }
        }
        private void export_Menu_Click(object sender, EventArgs e)
        {
            TypeListItem item = listView.SelectedObject as TypeListItem;
            //LogManager.AddLogMessage(Name, "export_Menu_Click", item.Name, LogManager.LogMessageType.DEBUG);
            PreferenceType type = (PreferenceType)Enum.Parse(typeof(PreferenceType), item.Name);
            ExportPreferences(type);
        }
        private void import_Menu_Click(object sender, EventArgs e)
        {
            TypeListItem item = listView.SelectedObject as TypeListItem;
            //LogManager.AddLogMessage(Name, "import_Menu_Click", item.Name, LogManager.LogMessageType.DEBUG);
            PreferenceType type = (PreferenceType)Enum.Parse(typeof(PreferenceType), item.Name);
            ImportPreferences(type);
        }
        #endregion
        /*
        #region DataModels
        private class ListItem
        {
            public string Name { get; set; }
            public PreferenceManager.PreferenceType type { get; set; }
        }
        #endregion
    */
    }
}
