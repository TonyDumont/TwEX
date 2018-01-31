using System;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class ExchangeTradingControl : UserControl
    {
        private string ExchangeName = String.Empty;

        #region Initialize
        public ExchangeTradingControl()
        {
            InitializeComponent();
        }
        private void ExchangeTradingControl_Load(object sender, EventArgs e)
        {
            UpdateUI(true);
        }
        #endregion

        #region Delegates
        delegate bool SetExchangeCallback(string exchange);
        public bool SetExchange(string exchange)
        {
            if (InvokeRequired)
            {
                SetExchangeCallback d = new SetExchangeCallback(SetExchange);
                Invoke(d, new object[] { });
            }
            else
            {
                ExchangeName = exchange;
                balanceListControl.SetExchange(exchange);
                tickerListControl.SetExchange(exchange);
                historyTabControl.SetExchange(exchange);
                UpdateUI(true);
            }
            return true;
        }

        delegate bool UpdateUICallback(bool resize = false);
        public bool UpdateUI(bool resize = false)
        {
            if (InvokeRequired)
            {
                UpdateUICallback d = new UpdateUICallback(UpdateUI);
                Invoke(d, new object[] { resize });
            }
            else
            {
                balanceListControl.UpdateUI(resize);
                tickerListControl.UpdateUI(resize);
                historyTabControl.UpdateUI(resize);

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
            if (InvokeRequired)
            {
                ResizeUICallback d = new ResizeUICallback(ResizeUI);
                Invoke(d, new object[] { });
            }
            else
            {
                LogManager.AddLogMessage(Name, "ResizeUI", "pref=" + balanceListControl.PreferredWidth);
                tableLayoutPanel.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanel.ColumnStyles[0].Width = balanceListControl.PreferredWidth;

                tableLayoutPanel.ColumnStyles[1].SizeType = SizeType.Absolute;
                tableLayoutPanel.ColumnStyles[1].Width = tickerListControl.PreferredWidth;
            }
        }
        #endregion
    }
}
