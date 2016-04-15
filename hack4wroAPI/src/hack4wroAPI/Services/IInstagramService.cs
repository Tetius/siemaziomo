using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hack4wroAPI.Services
{
    public interface IInstagramService
    {
        Task<dynamic> GetLocations(double lat, double lng, double distance, string accessToken);
    }
}
