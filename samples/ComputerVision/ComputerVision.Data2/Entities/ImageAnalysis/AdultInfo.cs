using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class AdultInfo
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "isAdultContent")]
        public bool IsAdultContent { get; set; }
        [JsonProperty(PropertyName = "isRacyContent")]
        public bool IsRacyContent { get; set; }
        [JsonProperty(PropertyName = "adultScore")]
        public double AdultScore { get; set; }
        [JsonProperty(PropertyName = "racyScore")]
        public double RacyScore { get; set; }
    }




}


