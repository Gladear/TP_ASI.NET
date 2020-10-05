﻿using MoviesWebApp.Models.EntityFramework;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesClientApp.Services
{
    class WSService
    {
        static HttpClient _client = new HttpClient();

        public async static Task<Compte> GetCompteByEmail(string email)
        {
            var response = await _client.GetAsync($"http://localhost:5000/api/Compte/ByEmail/{email}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsAsync<Compte>();
        }
    }
}