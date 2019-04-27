using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComputerVision.Data2
{
    public class CategoryDetail
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "celebrities")]
        public IList<CelebritiesModel> Celebrities { get; set; }
        [JsonProperty(PropertyName = "landmarks")]
        public IList<LandmarksModel> Landmarks { get; set; }
    }




}


