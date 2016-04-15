using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hack4wroAPI.Models.Instagram;

namespace hack4wroAPI.Services
{
    public interface IInstagramService
    {
        Task<dynamic> GetLocations(Coords coords, double distance, string accessToken);
        Task<InstagramResponse> GetMedia(Coords coords, double distance, string accessToken);
    }
}
