using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class Category
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "score")]
        public double Score { get; set; }
        [JsonProperty(PropertyName = "detail")]
        public CategoryDetail Detail { get; set; }
    }




}


