using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using hack4wroAPI.Models.Google;

namespace hack4wroAPI.Services
{
    public class GoogleMapDirectionsService : IGoogleMapDirectionsService
 {
     private const string ApiKey = "AIzaSyDJHGBQFL-q4BTb1sjuoKNa6j25iQ-OYl0";
     private readonly Uri apiUrl = new Uri("https://maps.googleapis.com/maps/api/");
     
     public async Task<GoogleResponse> GibensRoute(Coords origin, Coords destination, IEnumerable<Coords> waypoints)
     {
            using (HttpClient client = new HttpClient())
            {
                var waypointStr= string.Join("|",waypoints.Select(x=>x.Latitude.ToString(CultureInfo.InvariantCulture)+","+x.Longitude.ToString(CultureInfo.InvariantCulture)));
                client.BaseAddress = apiUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                var path = string.Format($"directions/json?origin={origin.Latitude.ToString(CultureInfo.InvariantCulture)},{origin.Longitude.ToString(CultureInfo.InvariantCulture)}&destination={destination.Latitude.ToString(CultureInfo.InvariantCulture)},{destination.Longitude.ToString(CultureInfo.InvariantCulture)}&mode=walking&waypoints={waypointStr}&key={ApiKey}");
                var response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return await Task.Run(() => JsonConvert.DeserializeObject<GoogleResponse>(responseJson));
                }
                throw new InvalidOperationException();
            }
         
     }
 }
}