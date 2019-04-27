using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class ImageMetadata
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }
    }




}


