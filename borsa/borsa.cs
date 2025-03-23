using borsa.Classes;  // CollectApiService ve StockData sınıflarını ekliyoruz
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borsa
{
    public partial class borsa : Form
    {
        private CollectApiService _collectApiService;

        public borsa()
        {
            InitializeComponent();
            _collectApiService = new CollectApiService();  // CollectApiService'i başlatıyoruz
        }

        // Form yüklendiğinde verileri çekiyoruz
        private async void borsa_Load(object sender, EventArgs e)
        {
            // Veriyi çekiyoruz
            var stockData1 = await _collectApiService.GetStockDataAsync("AAPL");  // Apple
            var stockData2 = await _collectApiService.GetStockDataAsync("GOOG");  // Google
            var stockData3 = await _collectApiService.GetStockDataAsync("AMZN");  // Amazon
            var stockData4 = await _collectApiService.GetStockDataAsync("MSFT");  // Microsoft

            // Veriyi formda görüntülüyoruz
            DisplayStockData(groupBox1, stockData1);
            DisplayStockData(groupBox2, stockData2);
            DisplayStockData(groupBox3, stockData3);
            DisplayStockData(groupBox4, stockData4);
        }

        // Veriyi GroupBox içindeki Label'lara yerleştiriyoruz
        private void DisplayStockData(GroupBox groupBox, string stockJsonData)
        {
            // Gelen veriyi kontrol etme
            if (string.IsNullOrWhiteSpace(stockJsonData) || stockJsonData.StartsWith("Error") || stockJsonData.Contains("<html>"))
            {
                MessageBox.Show("Veri alınırken bir hata oluştu. Lütfen API yanıtını kontrol edin.");
                return;
            }

            try
            {
                // JSON verisini deserialize ediyoruz
                var stockData = JsonConvert.DeserializeObject<StockData>(stockJsonData);

                // Burada GroupBox içindeki Label'lara veriyi yerleştiriyoruz
                foreach (var control in groupBox.Controls)
                {
                    if (control is Label label)
                    {
                        // Örneğin; "AAPL: 145.67 USD" formatında bilgi göstermek
                        label.Text = $"{stockData.Symbol}: {stockData.Price} USD";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri işlenirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
