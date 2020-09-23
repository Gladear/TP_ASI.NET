using ClientConvertisseurV2.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Service
{
    class WSService
    {
        static HttpClient client = new HttpClient();

        public static async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            var response = await client.GetAsync("http://localhost:5000/api/currency/");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsAsync<List<Currency>>();
        }

        public static async Task<Currency> GetCurrencyAsync(int id)
        {
            var response = await client.GetAsync("http://localhost:5000/api/currency/" + id);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsAsync<Currency>();
        }
    }
}
