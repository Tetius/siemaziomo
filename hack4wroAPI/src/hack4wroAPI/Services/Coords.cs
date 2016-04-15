namespace hack4wroAPI.Services
{
    public struct Coords{
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public Coords(double latitude, double longitude){
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}