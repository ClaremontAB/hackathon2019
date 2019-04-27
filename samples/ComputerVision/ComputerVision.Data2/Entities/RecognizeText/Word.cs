using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class Word
    {
        public int Id { get; set; }
        //
        [JsonProperty(PropertyName = "boundingBox")]
        public string BoundingBox { get; set; }
        //
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}


