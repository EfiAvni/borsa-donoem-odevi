using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borsa
{
    public partial class News : Form
    {
        public News()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private async void News_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);

            // Web sayfasını yükleyin
            webView21.Source = new Uri("https://www.bloomberght.com/haberler");
        }
    }
}
