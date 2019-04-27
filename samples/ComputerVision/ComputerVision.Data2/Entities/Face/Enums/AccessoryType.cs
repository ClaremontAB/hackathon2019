using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ComputerVision.Data2.Entities.Face.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccessoryType
    {
        HeadWear = 0,
        Glasses = 1,
        Mask = 2
    }
}
