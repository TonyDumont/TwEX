using BrightIdeasSoftware;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static TwEX_API.LogManager;

namespace TwEX_API.Controls
{
    public partial class LogManagerControl : UserControl
    {
        //public Font defaultFont = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
        //private ToolStripSpringTextBox messageTextBox = new ToolStripSpringTextBox();

        // INITIALIZE
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
                    ToolStripButton button = new ToolStripButton() { Text = type.ToString(), DisplayStyle = ToolStripItemDisplayStyle.ImageAndText };
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
                    toolStrip.Items.Add(new ToolStripSeparator());
                }
            }

            toolStripDropDownButton_menu.Image = ContentManager.GetIconByUrl(ContentManager.PreferenceIconUrl);
            toolStripMenuItem_font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            toolStripMenuItem_fontIncrease.Image = ContentManager.GetIconByUrl(ContentManager.FontIconIncrease);
            toolStripMenuItem_fontDecrease.Image = ContentManager.GetIconByUrl(ContentManager.FontIconDecrease);
            //toolStrip_footer.Items.Add(messageTextBox);
            //toolStripButton_Font.Image = ContentManager.GetIconByUrl(ContentManager.FontIconUrl);
            UpdateUI(true);
        }

        // DELEGATES
        delegate void ResizeUICallback();
        public void ResizeUI()
        {
            if (this.InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                toolStrip.Font = ParentForm.Font;

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
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item.GetType() == typeof(ToolStripButton))
                    {
                        ToolStripButton button = item as ToolStripButton;
                        button.Checked = LogManager.getMessageTypeActive(button.Text);
                    }
                }

                listView.SetObjects((from m in LogManager.MessageList where (m.type & PreferenceManager.preferences.MessageFlags) > 0 select m).OrderByDescending(t => t.TimeStamp));

                if (resize)
                {
                    ResizeUI();
                }
            }
        }

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
        #endregion
    }
}