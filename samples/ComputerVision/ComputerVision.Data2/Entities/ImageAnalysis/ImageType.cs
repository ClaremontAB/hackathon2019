using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class ImageType
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "clipArtType")]
        public int ClipArtType { get; set; }
        [JsonProperty(PropertyName = "lineDrawingType")]
        public int LineDrawingType { get; set; }
    }




}


