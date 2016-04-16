using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using hack4wroAPI.Services;
using hack4WroAPI.Models.Response;
using hack4wroAPI.Models.Google;

namespace hack4wroAPI.Controllers
{
    public class GetParams
    {
        public Coords origin;
        public Coords destination;
        public TimeSpan duration;
    }


    [Route("api/[controller]")]
    public class TourController : Controller
    {
        private const string InstagramAccessToken = "3138468373.3422eb9.143f3edb429a491fa815b9d981a3fcb1";
        private readonly IInstagramService _instagramService;
        private readonly IGoogleMapDirectionsService _googleRouteService;

        public TourController(IInstagramService instagramService, IGoogleMapDirectionsService googleRouteService)
        {
            _instagramService = instagramService;
            _googleRouteService = googleRouteService;
        }
        // GET: api/tour
        [HttpPost]
        public async Task<dynamic> Post([FromBody] GetParams parameters)
        {
            if (parameters == null) return new BadRequestResult();

            var center = new Coords();
            center.Latitude = (parameters.origin.Latitude + parameters.destination.Latitude) / 2;
            center.Longitude = (parameters.origin.Longitude + parameters.destination.Longitude) / 2;
            var distance = DistanceUtil.CalculateDistance(parameters.origin, parameters.destination) /2;
            var instagramPosts = (await _instagramService.GetMedia(center, distance, InstagramAccessToken)).data.Select(x => new SlimInstagramPost(x)).OrderByDescending(x => x.likes).ToList();

            GoogleResponse googleResponse;
            int acceptableDifference = 5 * 60;
            while(true)
            {
                var instagramPostCoordinates = instagramPosts.Select(x => new Coords(x.location.latitude, x.location.longitude));
                googleResponse = await _googleRouteService.GibensRoute(parameters.origin, parameters.destination, instagramPostCoordinates);
                var targetDuration = parameters.duration.TotalSeconds;
                var routeDuration = googleResponse.routes.SelectMany(r => r.legs).Sum(l => l.duration.value) + instagramPosts.Count * 5 * 60;
                if (routeDuration - targetDuration <= acceptableDifference || instagramPosts.Count == 0) break;
                instagramPosts.RemoveAt(instagramPosts.Count - 1);
            }

            var finalResponse = new ComplexResponse{
                posts = instagramPosts,
                directions = new SlimGoogleDirections(googleResponse.routes.First())
            };
            
            return Json(finalResponse);
        }


    }
}
