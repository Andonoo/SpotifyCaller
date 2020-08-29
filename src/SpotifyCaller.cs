using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
namespace SpotifyNotifierConsole
{
    public class SpotifyCaller
    {
        private string _token;
        private HttpClient _httpClient;

        public SpotifyCaller(string clientKey, string clientSecret)
        {
            _httpClient = new HttpClient();
            Authorize(clientKey, clientSecret);
        }

        private async void Authorize(string clientKey, string clientSecret)
        {
            var base64Creds = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientKey}:{clientSecret}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Creds);

            var content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = _httpClient.PostAsync("https://accounts.spotify.com/api/token", content).Result;
            var responseContents = JObject.Parse(await response.Content.ReadAsStringAsync());

            var token = responseContents["access_token"];
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());
        }

        public async void findAlbums(String artist)
        {
            var getMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.spotify.com/v1/search?q={artist}&type=artist");

            var response = _httpClient.SendAsync(getMessage).Result;

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    } 
}
