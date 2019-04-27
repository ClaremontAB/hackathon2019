using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ComputerVision.Data2
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        Male = 0,
        Female = 1
    }




}


