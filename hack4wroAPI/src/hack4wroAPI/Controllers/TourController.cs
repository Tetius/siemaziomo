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

        public TourController(IInstagramService instagramService)
        {
            _instagramService = instagramService;
        }
        // GET: api/tour
        [HttpGet]
        public async Task<dynamic> Get()
        {
            return await _instagramService.GetLocations(51.106865, 17.076974, 1000, "3138468373.3422eb9.143f3edb429a491fa815b9d981a3fcb1");
        }
    }
}
