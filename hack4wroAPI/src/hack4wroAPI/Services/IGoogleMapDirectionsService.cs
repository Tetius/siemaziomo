using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hack4wroAPI.Services
{
    public interface IGoogleMapDirectionsService
    {
        Task<dynamic> GibensRoute(Coords origin, Coords destination, IEnumerable<Coords> waypoints);
    }
}
