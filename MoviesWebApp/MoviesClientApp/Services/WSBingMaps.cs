using MoviesClientApp.Models;
using MoviesWebApp.Models.EntityFramework;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesClientApp.Services
{
    class WSBingMaps
    {
        private static HttpClient _client = new HttpClient();
        public static async Task FillCompteLocation(Compte compte)
        {
            var point = await GetPointFromUrl("http://dev.virtualearth.net/REST/v1/Locations/FR/{compte.CP}/{compte.Ville}/{compte.Rue}?maxResults=1");
            compte.Latitude = point.coordinates[0];
            compte.Longitude = point.coordinates[1];
        }

        private static async Task<Point> GetPointFromUrl(string url)
        {
            var apiKey = "your_api_key";
            var response = await _client.GetAsync($"{url}&key={apiKey}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new System.Exception(content);
            }
            var data = await response.Content.ReadAsAsync<Rootobject>();
            return data.resourceSets[0].resources[0].point;
        }
    }
}
