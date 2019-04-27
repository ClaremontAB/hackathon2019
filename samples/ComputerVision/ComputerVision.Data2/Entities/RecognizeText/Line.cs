using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComputerVision.Data2
{

    public class Line
    {
        public int Id { get; set; }
        //
        [JsonProperty(PropertyName = "boundingBox")]
        public string BoundingBox { get; set; }
        //
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        //
        [JsonProperty(PropertyName = "words")]
        public List<Word> Words { get; set; }

    }
}


