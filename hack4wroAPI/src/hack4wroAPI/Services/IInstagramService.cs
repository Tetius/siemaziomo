using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hack4wroAPI.Services
{
    public interface IInstagramService
    {
        Task<dynamic> GetLocations(Coords coords, double distance, string accessToken);
        Task<dynamic> GetMedia(Coords coords, double distance, string accessToken);
    }
}
