using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace borsa.Classes
{
    public class CollectApiService
    {
        private readonly string _apiKey = "6V7mqMu8Ux4wNtXMUDSUsU:1SZHb6WSPHq3WmjahxrViF";  // API anahtarınız

        public async Task<string> GetStockDataAsync(string symbol)
        {
            string url = $"https://api.collectapi.com/economy/stock?symbol={symbol}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"apikey {_apiKey}");  // API anahtarını başlığa ekliyoruz

                try
                {
                    var response = await client.GetStringAsync(url);

                    // Gelen yanıtı konsola logluyoruz
                    Console.WriteLine(response);  // Burada gelen yanıtı konsolda görmek için

                    // Yanıtı döndürüyoruz
                    return response;
                }
                catch (Exception ex)
                {
                    // Hata durumunda loglama yapılabilir
                    return $"Error: {ex.Message}";
                }
            }
        }
    }
}
