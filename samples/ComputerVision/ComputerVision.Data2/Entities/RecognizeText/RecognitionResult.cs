using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComputerVision.Data2
{
    public class RecognitionResult
    {
        public int Id { get; set; }

        //
        [JsonProperty(PropertyName = "lines")]
        public List<Line> Lines { get; set; }
    }
}


