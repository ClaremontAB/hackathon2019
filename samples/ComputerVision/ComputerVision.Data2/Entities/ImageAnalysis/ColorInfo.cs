using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class ColorInfo
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "dominantColorForeground")]
        public string DominantColorForeground { get; set; }
        [JsonProperty(PropertyName = "dominantColorBackground")]
        public string DominantColorBackground { get; set; }
        [JsonProperty(PropertyName = "dominantColors")]
        public string DominantColors { get; set; }
        [JsonProperty(PropertyName = "accentColor")]
        public string AccentColor { get; set; }
        [JsonProperty(PropertyName = "isBWImg")]
        public bool IsBWImg { get; set; }
    }




}


