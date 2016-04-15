using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace hack4wroAPI.Services
{
    public class InstagramService : IInstagramService
    {
        string clientId = "3422eb9eb676411a9ba67d9535195810";
        string clientSecret = "5657cfff43d14ff6b20f4804c771cfaa";

        Uri apiUrl = new Uri("https://api.instagram.com/v1/");

        public InstagramService()
        {

        }

        public async Task<dynamic> GetLocations(double lat, double lng, double distance, string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = apiUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                var path = string.Format($"locations/search?distance={distance.ToString(CultureInfo.InvariantCulture)}&lat={lat.ToString(CultureInfo.InvariantCulture)}&lng={lng.ToString(CultureInfo.InvariantCulture)}&access_token={accessToken}");
                var response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return await Task.Run(() => JObject.Parse(responseJson));
                }
                throw new InvalidOperationException();
            }
        }
        
    }
}
