using System;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace TwEX_API.Controls
{
    public partial class ExchangePreferenceControl : UserControl
    {
        #region Initialize
        public ExchangePreferenceControl()
        {
            InitializeComponent();
            InitializeColumns();
        }
        private void ExchangePreferenceEditorControl_Load(object sender, EventArgs e)
        {
            
            listView.BooleanCheckStateGetter = delegate (Object rowObject) {
                return ((ExchangeManager.Exchange)rowObject).Active;
            };

            listView.BooleanCheckStatePutter = delegate (Object rowObject, bool newValue) {
                //ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)rowObject;

                ((ExchangeManager.Exchange)rowObject).Active = newValue;
                //LogManager.AddLogMessage(Name, "CheckPutter", "toogle : " + newValue + " | " + exchange.Active);
                FormManager.UpdateExchangeManager();
                return newValue; // return the value that you want the control to use
            };
            
            //PreferenceManager.UpdateExchangePreferencesFile();
            UpdateUI(true);
        }
        private void InitializeColumns()
        {
            column_Name.ImageGetter = new ImageGetterDelegate(aspect_icon);
        }
        #endregion

        #region Delegates
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
                column_Name.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                Width = column_Name.Width + (listView.RowHeightEffective);
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
                listView.SetObjects(ExchangeManager.Exchanges);
                groupBox.Text = listView.Items.Count + " Exchanges";
                
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
            ExchangeManager.Exchange exchange = (ExchangeManager.Exchange)rowObject;

            if (exchange != null)
            {
                return ContentManager.ResizeImage(ContentManager.GetExchangeIcon(exchange.Name), listView.RowHeightEffective, listView.RowHeightEffective);
            }
            else
            {
                return ContentManager.ResizeImage(Properties.Resources.ConnectionStatus_DISABLED, listView.RowHeightEffective, listView.RowHeightEffective);
            }
        }
        #endregion
    }
}
