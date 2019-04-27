using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class LandmarksModel
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }
    }




}


