using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class ImageCaption
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }
    }




}


