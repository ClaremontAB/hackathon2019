using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class FaceDescription
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public Gender? Gender { get; set; }
        [JsonProperty(PropertyName = "faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }
    }




}


