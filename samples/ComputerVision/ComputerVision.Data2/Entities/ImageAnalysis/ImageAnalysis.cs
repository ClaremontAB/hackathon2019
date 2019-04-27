using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComputerVision.Data2
{
    public class ImageAnalysis
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<Category> Categories { get; set; }
        [JsonProperty(PropertyName = "adult")]
        public AdultInfo Adult { get; set; }
        [JsonProperty(PropertyName = "color")]
        public ColorInfo Color { get; set; }
        [JsonProperty(PropertyName = "imageType")]
        public ImageType ImageType { get; set; }
        [JsonProperty(PropertyName = "tags")]
        public IList<ImageTag> Tags { get; set; }
        [JsonProperty(PropertyName = "description")]
        public ImageDescriptionDetails Description { get; set; }
        [JsonProperty(PropertyName = "faces")]
        public IList<FaceDescription> Faces { get; set; }
        [JsonProperty(PropertyName = "requestId")]
        public string RequestId { get; set; }
        [JsonProperty(PropertyName = "metadata")]
        public ImageMetadata Metadata { get; set; }
    }




}


