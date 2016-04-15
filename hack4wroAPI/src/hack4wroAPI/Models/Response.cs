using System.Collections.Generic;
using hack4wroAPI.Models.Google;
using hack4wroAPI.Models.Instagram;

namespace hack4WroAPI.Models.Response
{
    public class SlimInstagramPost{
        
        public List<string> Tags { get; set; }
        
        public Location Location { get; set; }
        
        public int Likes { get; set; }
        
        public string Image { get; set; }
        public string Thumbnail { get; set; }
        
        public SlimInstagramPost(Datum datum){
            Tags = datum.tags;
            Location = datum.location;
            Likes = datum.likes.count;
            Image = datum.images.standard_resolution.url;
            Thumbnail = datum.images.thumbnail.url;
        }
    }
    
    public class SlimGoogleDirections{
        public Bounds Bounds { get; set; }
        
        public string Polyline { get; set; }
        
        public SlimGoogleDirections(Route route){
            Bounds = route.bounds;
            Polyline = route.overview_polyline.points;
        }
    }
    
    public class ComplexResponse{
        public SlimGoogleDirections Directions {get;set;}
        public List<SlimInstagramPost> Posts { get; set; }
    }
}