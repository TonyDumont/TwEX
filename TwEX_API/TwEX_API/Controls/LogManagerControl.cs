using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TwEX_API.Market;
using static TwEX_API.LogManager;
using static TwEX_API.Market.CryptoCompare;

namespace TwEX_API.Controls
{
    public partial class LogManagerControl : UserControl
    {
        // INITIALIZE
        public LogManagerControl()
        {
            InitializeComponent();
        }
        private void LogManagerControl_Load(object sender, EventArgs e)
        {
            listView.DataSource = LogManager.LogMessageList;
        }
        // EVENT HANDLERS
        private void listView_SelectionChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                LogMessage logMessage = listView.SelectedObject as LogMessage;
                textBox.Text = logMessage.Message;
            }
        }
        private void toolStripButton_update_Click(object sender, EventArgs e)
        {
            //AddLogMessage(this.Name, "toolStripButton_update_Click", "message", LogManager.LogMessageType.OTHER);    
            //long unixStart = ((DateTimeOffset)new DateTime(2017, 9, 1)).ToUnixTimeSeconds();
            //long unixEnd = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            
            string[] symbolarray = { "ETH", "LTC", "DASH" };
            string[] marketarray = { "BTC", "USD", "EUR" };
            List<CryptoComparePrice> list = CryptoCompare.getPriceHistoricalList("ETH", marketarray);
            AddLogMessage(this.Name, "toolStripButton_update_Click", "count=" + list.Count, LogManager.LogMessageType.DEBUG);
        }
    }
}