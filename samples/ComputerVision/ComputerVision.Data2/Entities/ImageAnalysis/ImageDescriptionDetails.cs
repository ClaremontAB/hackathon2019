using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComputerVision.Data2
{
    public class ImageDescriptionDetails
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; set; }
        [JsonProperty(PropertyName = "captions")]
        public IList<ImageCaption> Captions { get; set; }
    }




}


