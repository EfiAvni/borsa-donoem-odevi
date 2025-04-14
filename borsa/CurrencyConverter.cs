using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static borsa.AnaSayfa;

namespace borsa
{
    public partial class CurrencyConverter : Form
    {
        public CurrencyConverter()
        {
            InitializeComponent();

        }

        private void CurrencyConverter_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void CurrencyConverter_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Türk Lirası");
            comboBox1.Items.Add("Dolar");
            comboBox1.Items.Add("Euro");
            comboBox1.Items.Add("Sterlin");

            label5.Text = dolar;
            label6.Text = euro;
            label7.Text = sterlin;
            label5.Text = label5.Text.Replace(".", ",");
            label6.Text = label6.Text.Replace(".", ",");
            label7.Text = label7.Text.Replace(".", ",");

        }

        public string dolar = GlobalVeri.Label1Metni;
        public string euro = GlobalVeri.Label2Metni;
        public string sterlin = GlobalVeri.Label3Metni;

        private void button1_Click(object sender, EventArgs e)
        {

            // Label'larda bulunan metinleri al
            string labelDolar = label5.Text;
            string labelEuro = label6.Text;
            string labelSterlin = label7.Text;

            // Label'larda boş olup olmadığını kontrol et
            if (string.IsNullOrEmpty(labelDolar) || string.IsNullOrEmpty(labelEuro) || string.IsNullOrEmpty(labelSterlin) || string.IsNullOrEmpty(txtTutar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            double dolar, euro, sterlin, girilen;

            // TryParse ile sayıya dönüştür
            if (!double.TryParse(labelDolar, out dolar))
            {
                MessageBox.Show("Dolar kuru geçerli değil.");
                return;
            }

            if (!double.TryParse(labelEuro, out euro))
            {
                MessageBox.Show("Euro kuru geçerli değil.");
                return;
            }

            if (!double.TryParse(labelSterlin, out sterlin))
            {
                MessageBox.Show("Sterlin kuru geçerli değil.");
                return;
            }

            if (!double.TryParse(txtTutar.Text, out girilen))
            {
                MessageBox.Show("Girilen tutar geçerli değil.");
                return;
            }

            // ComboBox'tan seçilen döviz türünü al
            string selectedText = comboBox1.SelectedItem?.ToString();

            // Seçilen döviz türüne göre işlem yap
            if (selectedText == "Dolar")
            {
                double sonuc = dolar * girilen;
                txtTutar2.Text = sonuc.ToString("0.00");
            }
            else if (selectedText == "Euro")
            {
                double sonuc = euro * girilen;
                txtTutar2.Text = sonuc.ToString("0.00");
            }
            else if (selectedText == "Sterlin")
            {
                double sonuc = sterlin * girilen;
                txtTutar2.Text = sonuc.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Lütfen bir döviz birimi seçin.");
            }
        }
    }
}
