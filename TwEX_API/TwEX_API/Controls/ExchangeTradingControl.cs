using System;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class ExchangeTradingControl : UserControl
    {
        #region Properties
        private ExchangeManager.Exchange Exchange;
        #endregion

        #region Initialize
        public ExchangeTradingControl()
        {
            InitializeComponent();
            balanceListControl.exchangeTradingControl = this;
        }
        private void ExchangeTradingControl_Load(object sender, EventArgs e)
        {
            tickerListControl.chartControl = exchangeChartsControl;
            tickerListControl.historyTabControl = historyTabControl;
            
            //PreferenceManager.SetTheme(PreferenceManager.preferences.Theme.type, ParentForm);
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
                Exchange = ExchangeManager.getExchange(exchange);
                balanceListControl.SetExchange(Exchange);
                tickerListControl.SetExchange(Exchange);
                historyTabControl.SetExchange(Exchange);
                exchangeChartsControl.SetExchange(Exchange);

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
                if (Exchange != null)
                {
                    balanceListControl.UpdateUI(resize);
                    tickerListControl.UpdateUI(resize);
                    historyTabControl.UpdateUI(resize);
                }

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
                try
                {
                    if (balanceListControl.PreferredWidth > 0)
                    {
                        Visible = false;
                        tableLayoutPanel.ColumnStyles[0].SizeType = SizeType.Absolute;
                        tableLayoutPanel.ColumnStyles[0].Width = balanceListControl.PreferredWidth;

                        tableLayoutPanel.ColumnStyles[1].SizeType = SizeType.Absolute;
                        tableLayoutPanel.ColumnStyles[1].Width = tickerListControl.PreferredWidth;
                        Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.AddLogMessage(Name, "ResizeUI", ex.Message, LogManager.LogMessageType.EXCEPTION);
                }
                
            }
        }
        #endregion
    }
}
