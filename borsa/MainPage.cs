using BorsaUygulamasi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;
using HtmlAgilityPack;
using System.Net.Http;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Diagnostics;
using Label = System.Windows.Forms.Label;

namespace borsa
{
    public partial class AnaSayfa : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Timer _timer;
        public AnaSayfa()
        {
            InitializeComponent();

            _timer = new Timer { Interval = 5000 }; // 5 saniye
            _timer.Tick += Timer_Tick;
            _timer.Start(); // Timer'ı başlat

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Hide();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            string mail = labelMail.Text;
            AccountPage ap = new AccountPage(mail);
            ap.Show();
        }

        public void labelMail_Click(object sender, EventArgs e)
        {
            
        }
        public string MailAddress
        {
            get { return labelMail.Text; }
            set { labelMail.Text = value; }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            string text = labelMail.Text;
            if (text=="Giriş Yapılmadı!")
            {
                MessageBox.Show("Giriş Yapmış kullanıcı yok!");
            }
            else
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonNews_Click(object sender, EventArgs e)
        {
            News news = new News();
            news.Show();
            this.Hide();
        }

        private void buttonGraphics_Click(object sender, EventArgs e)
        {
            //borsa borsa = new borsa();
            //borsa.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            
        }


        private void label16_Click(object sender, EventArgs e)
        {

        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string url = "https://canlidoviz.com/doviz-kurlari";
                string htmlContent = await _httpClient.GetStringAsync(url);

                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(htmlContent);

                // DOLAR (USD) Çekme
                HtmlNode usdNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='USD']]//span[@dt='amount']"
                );
                if (usdNode != null)
                {
                    lbl11.Invoke((MethodInvoker)(() => lbl11.Text = usdNode.InnerText.Trim()));
                }
                else
                {
                    lbl11.Invoke((MethodInvoker)(() => lbl11.Text = "USD bulunamadı!"));
                }

                // EURO (EUR) Çekme
                HtmlNode euroNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='EUR']]//span[@dt='amount']"
                );
                if (euroNode != null)
                {
                    lbl12.Invoke((MethodInvoker)(() => lbl12.Text = euroNode.InnerText.Trim()));
                }
                else
                {
                    lbl12.Invoke((MethodInvoker)(() => lbl12.Text = "EUR bulunamadı!"));
                }

                HtmlNode gbpNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='GBP']]//span[@dt='amount']"
                );
                if (gbpNode != null)
                {
                    lbl13.Invoke((MethodInvoker)(() => lbl13.Text = gbpNode.InnerText.Trim()));
                }
                else
                {
                    lbl13.Invoke((MethodInvoker)(() => lbl13.Text = "GBP bulunamadı!"));
                }

                HtmlNode chfNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='CHF']]//span[@dt='amount']"
                );
                if (chfNode != null)
                {
                    lbl14.Invoke((MethodInvoker)(() => lbl14.Text = chfNode.InnerText.Trim()));
                }
                else
                {
                    lbl14.Invoke((MethodInvoker)(() => lbl14.Text = "CHF bulunamadı!"));
                }

                HtmlNode cadNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='CAD']]//span[@dt='amount']"
                );
                if (cadNode != null)
                {
                    lbl15.Invoke((MethodInvoker)(() => lbl15.Text = cadNode.InnerText.Trim()));
                }
                else
                {
                    lbl15.Invoke((MethodInvoker)(() => lbl15.Text = "CAD bulunamadı!"));
                }

                HtmlNode rubNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='RUB']]//span[@dt='amount']"
                );
                if (rubNode != null)
                {
                    lbl16.Invoke((MethodInvoker)(() => lbl16.Text = rubNode.InnerText.Trim()));
                }
                else
                {
                    lbl16.Invoke((MethodInvoker)(() => lbl16.Text = "RUB bulunamadı!"));
                }

                HtmlNode aedNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='AED']]//span[@dt='amount']"
                );
                if (aedNode != null)
                {
                    lbl17.Invoke((MethodInvoker)(() => lbl17.Text = aedNode.InnerText.Trim()));
                }
                else
                {
                    lbl17.Invoke((MethodInvoker)(() => lbl17.Text = "AED bulunamadı!"));
                }

                HtmlNode audNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='AUD']]//span[@dt='amount']"
                );
                if (audNode != null)
                {
                    lbl18.Invoke((MethodInvoker)(() => lbl18.Text = audNode.InnerText.Trim()));
                }
                else
                {
                    lbl18.Invoke((MethodInvoker)(() => lbl18.Text = "AUD bulunamadı!"));
                }

                HtmlNode dkkNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='DKK']]//span[@dt='amount']"
                );
                if (dkkNode != null)
                {
                    lbl19.Invoke((MethodInvoker)(() => lbl19.Text = dkkNode.InnerText.Trim()));
                }
                else
                {
                    lbl19.Invoke((MethodInvoker)(() => lbl19.Text = "DKK bulunamadı!"));
                }

                HtmlNode sekNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='SEK']]//span[@dt='amount']"
                );
                if (sekNode != null)
                {
                    lbl20.Invoke((MethodInvoker)(() => lbl20.Text = sekNode.InnerText.Trim()));
                }
                else
                {
                    lbl20.Invoke((MethodInvoker)(() => lbl20.Text = "SEK bulunamadı!"));
                }

                HtmlNode nokNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='currency' and @content='NOK']]//span[@dt='amount']"
                );
                if (nokNode != null)
                {
                    lbl21.Invoke((MethodInvoker)(() => lbl21.Text = nokNode.InnerText.Trim()));
                }
                else
                {
                    lbl21.Invoke((MethodInvoker)(() => lbl21.Text = "NOK bulunamadı!"));
                }

                //ALTIN FİYATLARI

                // GRAM ALTIN (GA) Çekme
                HtmlNode goldNode = htmlDoc.DocumentNode.SelectSingleNode(
                    "//tr[.//span[@itemprop='name' and contains(text(), 'Gram Altın')]]//span[@dt='amount']"
                );
                if (goldNode != null)
                {
                    label33.Invoke((MethodInvoker)(() => label33.Text = goldNode.InnerText.Trim()));
                }
                else
                {
                    label33.Invoke((MethodInvoker)(() => label33.Text = "Altın bulunamadı!"));
                }
            }
            catch (Exception ex)
            {
                lbl11.Invoke((MethodInvoker)(() => lbl11.Text = "Hata: " + ex.Message));
                lbl12.Invoke((MethodInvoker)(() => lbl12.Text = "Hata!"));
            }
        }

        // Form kapatılırken temizlik yap
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _httpClient.Dispose();
            _timer.Stop();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void buttonConverter_Click(object sender, EventArgs e)
        {
            GlobalVeri.Label1Metni = lbl11.Text;
            GlobalVeri.Label2Metni = lbl12.Text;
            GlobalVeri.Label3Metni = lbl13.Text;

            CurrencyConverter converter = new CurrencyConverter();
            converter.Show();
        }
        public static class GlobalVeri
        {
            public static string Label1Metni;
            public static string Label2Metni;
            public static string Label3Metni;
        }
    }
}
