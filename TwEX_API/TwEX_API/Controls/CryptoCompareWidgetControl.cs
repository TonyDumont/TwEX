using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;

namespace TwEX_API.Controls
{
    public partial class CryptoCompareWidgetControl : UserControl
    {
        public ChromiumWebBrowser browser = null;

        public CryptoCompareWidgetControl()
        {
            InitializeComponent();
        }

        private void CryptoCompareWidgetControl_Load(object sender, EventArgs e)
        {
            
            //browser = new ChromiumWebBrowser(String.Empty);
            browser = new ChromiumWebBrowser("www.google.com");
            browser.Dock = DockStyle.Fill;
            this.Controls.Add(browser);
            //SetChart("ETH", "USD");
            
        }
    }
}
