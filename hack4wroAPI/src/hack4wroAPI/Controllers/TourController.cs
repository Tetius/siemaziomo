﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using hack4wroAPI.Services;

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
        private readonly IInstagramService _instagramService;
        private readonly IGoogleMapDirectionsService _googleRouteService;

        public TourController(IInstagramService instagramService, IGoogleMapDirectionsService googleRouteService)
        {
            _instagramService = instagramService;
            _googleRouteService = googleRouteService;
        }
        // GET: api/tour
        [HttpGet]
        public async Task<dynamic> Get([FromBody] GetParams parameters)
        {
            //return await _googleRouteService.GibensRoute(new Coords(51.1065776,17.0769447), new Coords(51.0844,17.06529), new[] {new Coords(51.079897166, 17.06529) });
            return await _instagramService.GetMedia(new Coords(51.1065776,17.0769447), 1000, "3138468373.3422eb9.143f3edb429a491fa815b9d981a3fcb1");
        }
    }
}
