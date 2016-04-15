using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using hack4wroAPI.Services;
using hack4WroAPI.Models.Response;

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
            var center = new Coords();
            center.Latitude = (parameters.origin.Latitude + parameters.destination.Latitude) / 2;
            center.Longitude = (parameters.origin.Longitude + parameters.destination.Longitude) / 2;
            var distance = DistanceUtil.CalculateDistance(parameters.origin, parameters.destination);
            var instagramPosts = await _instagramService.GetMedia(center, distance, InstagramAccessToken);

            var instagramPostCoordinates = instagramPosts.data.Select(x => new Coords(x.location.latitude, x.location.longitude));
            var googleResponse = await _googleRouteService.GibensRoute(parameters.origin, parameters.destination, instagramPostCoordinates);
            
            var finalResponse = new ComplexResponse{
                Posts = instagramPosts.data.Select(x=>new SlimInstagramPost(x)).ToList(),
                Directions = new SlimGoogleDirections(googleResponse.routes.First())
            };
            
            return Json(finalResponse);
        }


    }
}
