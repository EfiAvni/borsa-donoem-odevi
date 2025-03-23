using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace BorsaUygulamasi
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ApiKey = "q20G3auTZ2Zv1M3qd4s87r9sue2rS7jk"; // API key'inizi buraya girin
        private const string ApiUrl = "https://financialmodelingprep.com/api/v3/quote/";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadStockData();
        }

        private async Task LoadStockData()
        {
            try
            {
                // Örnek olarak 50 BIST hissesinin sembollerini belirleyin
                string[] bistStocks = { "AKBNK", "ARCLK", "ASELS", "BIMAS", "EKGYO", "EREGL", "FROTO", "GARAN", "GUBRF", "HALKB", "ISCTR", "KCHOL", "KOZAA", "KOZAL", "KRDMD", "MGROS", "ODAS", "OYAKC", "PETKM", "PGSUS", "SAHOL", "SASA", "SISE", "SKBNK", "TCELL", "THYAO", "TKFEN", "TOASO", "TSKB", "TTKOM", "TUPRS", "VAKBN", "VESTL", "YKBNK", "ZOREN", "ALARK", "ALKIM", "ANACM", "AYGAZ", "BRSAN", "CCOLA", "CEMTS", "DOAS", "EGEEN", "ENJSA", "FENER", "GOODY", "HEKTS", "ISGYO", "KONYA" };

                // API'den hisse verilerini çek
                foreach (var stock in bistStocks)
                {
                    string requestUrl = $"{ApiUrl}{stock}?apikey={ApiKey}";
                    var response = await client.GetStringAsync(requestUrl);
                    var jsonArray = JArray.Parse(response);

                    if (jsonArray.Count > 0)
                    {
                        var stockData = jsonArray[0];
                        dataGridView1.Rows.Add(
                            stockData["symbol"].ToString(),
                            stockData["name"].ToString(),
                            stockData["price"].ToString(),
                            stockData["change"].ToString(),
                            stockData["changesPercentage"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}