using System.Collections.Generic;
using System.Threading.Tasks;
using hack4wroAPI.Models.Google;

namespace hack4wroAPI.Services
{
    public interface IGoogleMapDirectionsService
    {
        Task<GoogleResponse> GibensRoute(Coords origin, Coords destination, IEnumerable<Coords> waypoints);
    }
}
