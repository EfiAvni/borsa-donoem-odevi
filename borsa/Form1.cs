using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace BorsaUygulamasi
{
    public partial class Form1 : Form
    {
        // BIST Hisse Listesi (Örnek)
        private readonly string[] bistStocks = {
        "AKBNK.IS", "GARAN.IS", "THYAO.IS", "ASELS.IS", "BIMAS.IS",
        "EREGL.IS", "FROTO.IS", "HEKTS.IS", "KCHOL.IS", "KOZAA.IS"
    };

        public Form1()
        {
            InitializeComponent();
            dataGridViewStocks.Columns.Add("Symbol", "Hisse");
            dataGridViewStocks.Columns.Add("Price", "Fiyat");
            dataGridViewStocks.Columns.Add("Change", "Değişim (%)");
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            dataGridViewStocks.Rows.Clear();

            foreach (var symbol in bistStocks)
            {
                var data = await AlphaVantageHelper.GetStockDataAsync(symbol);

                if (data["Error"] == null)
                {
                    var quote = data["Global Quote"];
                    string price = quote["05. price"]?.ToString();
                    string change = quote["10. change percent"]?.ToString();

                    dataGridViewStocks.Rows.Add(
                        symbol.Replace(".IS", ""), // Sadece hisse adı
                        $"{price} ₺",
                        $"{change}%"
                    );
                }
                else
                {
                    MessageBox.Show($"Hata: {data["Error"]}");
                }
            }
        }
    }
}