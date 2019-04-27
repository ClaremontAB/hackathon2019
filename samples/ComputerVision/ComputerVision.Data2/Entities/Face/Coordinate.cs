using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class Coordinate
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "x")]
        public double X { get; set; }
        [JsonProperty(PropertyName = "y")]
        public double Y { get; set; }
    }
}


