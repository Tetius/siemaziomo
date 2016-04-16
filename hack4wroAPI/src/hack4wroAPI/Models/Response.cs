using System.Collections.Generic;
using hack4wroAPI.Models.Google;
using hack4wroAPI.Models.Instagram;

namespace hack4WroAPI.Models.Response
{
    public class SlimInstagramPost{
        
        public List<string> tags { get; set; }
        
        public Location location { get; set; }
        
        public int likes { get; set; }

        public string author { get; set; }
        
        public string image { get; set; }
        public string thumbnail { get; set; }
        
        public SlimInstagramPost(Datum datum){
            tags = datum.tags;
            location = datum.location;
            likes = datum.likes.count;
            image = datum.images.standard_resolution.url;
            thumbnail = datum.images.thumbnail.url;
            author = datum.user.username;
        }
    }
    
    public class SlimGoogleDirections{
        public Bounds bounds { get; set; }
        
        public string polyline { get; set; }
        
        public SlimGoogleDirections(Route route){
            bounds = route.bounds;
            polyline = route.overview_polyline.points;
        }
    }
    
    public class ComplexResponse{
        public SlimGoogleDirections directions {get;set;}
        public List<SlimInstagramPost> posts { get; set; }
    }
}