using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class AlphaVantageHelper
{
    private static readonly string ApiKey = "KMS9O7F175T46DTT"; // API key'inizi buraya ekleyin
    private static readonly HttpClient client = new HttpClient();

    public static async Task<JObject> GetStockDataAsync(string symbol)
    {
        string url = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={ApiKey}";

        try
        {
            var response = await client.GetStringAsync(url);
            return JObject.Parse(response);
        }
        catch (Exception ex)
        {
            return JObject.FromObject(new { Error = ex.Message });
        }
    }
}