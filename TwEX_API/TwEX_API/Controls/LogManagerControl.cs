using BrightIdeasSoftware;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static TwEX_API.LogManager;

namespace TwEX_API.Controls
{
    public partial class LogManagerControl : UserControl
    {
        #region Initialize
        public LogManagerControl()
        {
            InitializeComponent();
            logManagerControl = this;
        }
        private void LogManagerControl_Load(object sender, EventArgs e)
        {
            var values = EnumUtils.GetValues<LogMessageType>();
            foreach (LogMessageType type in values)
            {
                if (type.ToString() != "NONE")
                {
                    ToolStripButton button = new ToolStripButton() { Text = type.ToString(), DisplayStyle = ToolStripItemDisplayStyle.ImageAndText, Alignment = ToolStripItemAlignment.Right };
                    button.Click += toolStripButton_Click;

                    string colorName = EnumUtils.GetDescription<LogMessageType>(type);
                    Color color = Color.FromName(colorName);
                    Bitmap bmp = new Bitmap(16, 16);
                    using (Graphics gr = Graphics.FromImage(bmp))
                    {
                        gr.Clear(color);
                    }
                    button.Image = bmp;

                    toolStrip.Items.Add(button);
                    toolStrip.Items.Add(new ToolStripSeparator() { Alignment = ToolStripItemAlignment.Right });
                }
            }

            toolStripDropDownButton_menu.Image = ContentManager.GetIcon("Options");
            toolStripMenuItem_font.Image = ContentManager.GetIcon("Font");
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIcon("FontIncrease");
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIcon("FontDecrease");
            //toolStrip_footer.Items.Add(messageTextBox);
            //toolStripButton_Font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            UpdateUI(true);
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
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item.GetType() == typeof(ToolStripButton))
                    {
                        ToolStripButton button = item as ToolStripButton;
                        button.Checked = getMessageTypeActive(button.Text);
                    }
                }

                listView.SetObjects((from m in MessageList where (m.type & PreferenceManager.preferences.MessageFlags) > 0 select m).OrderByDescending(t => t.TimeStamp));

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
                //ParentForm.Font = PreferenceManager.GetFormFont(ParentForm);
                //toolStrip.Font = ParentForm.Font;

                int rowHeight = listView.RowHeightEffective;
                int iconSize = rowHeight - 2;
                int padding = rowHeight / 2;

                toolStrip.ImageScalingSize = new Size(iconSize, iconSize);

                foreach (ColumnHeader col in listView.ColumnsInDisplayOrder)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    col.Width = col.Width + (padding);
                }
            }
        }
        #endregion

        #region EventHandler    
        private void listView_FormatCell(object sender, FormatCellEventArgs e)
        {
            LogMessage message = (LogMessage)e.Model;
            if (e.ColumnIndex == column_TimeStamp.Index)
            {
                string colorName = EnumUtils.GetDescription<LogMessageType>(message.type);
                Color color = Color.FromName(colorName);
                e.SubItem.BackColor = color;
            }   
        }
        private void listView_ItemActivate(object sender, EventArgs e)
        {
            LogMessage message = listView.SelectedObject as LogMessage;
            Clipboard.SetText(message.Message);
        }
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            LogMessageType type = (LogMessageType)Enum.Parse(typeof(LogMessageType), button.Text);
            ToggleMessageFlag(type);
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

                    case "CopyAll": 
                        StringBuilder s = new StringBuilder();

                        foreach (LogMessage message in LogManager.MessageList)
                        {
                            s.AppendLine(message.ToString());
                        }
                        Clipboard.SetText(s.ToString());               
                        break;

                    default:
                        // NOTHING
                        break;
                }

            }
        }
        #endregion
    }
}