using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class FaceRectangle
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "left")]
        public int Left { get; set; }
        [JsonProperty(PropertyName = "top")]
        public int Top { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
    }




}


