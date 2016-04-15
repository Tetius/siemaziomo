using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using hack4wroAPI.Services;

namespace hack4wroAPI.Controllers
{
    [Route("api/[controller]")]
    public class TourController : Controller
    {
        private readonly IInstagramService _instagramService;
        private readonly IGoogleMapDirectionsService _googleRouteService;

        public TourController(IInstagramService instagramService, IGoogleMapDirectionsService googleRouteService)
        {
            _instagramService = instagramService;
            _googleRouteService = googleRouteService;
        }
        // GET: api/tour
        [HttpGet]
        public async Task<dynamic> Get()
        {
            return await _googleRouteService.GibensRoute(new Coords(51.1065776,17.0769447), new Coords(51.0844,17.06529), new[] {new Coords(51.079897166, 17.06529) });
        }
    }
}
