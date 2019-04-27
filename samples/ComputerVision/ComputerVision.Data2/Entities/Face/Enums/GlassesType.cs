using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ComputerVision.Data2.Entities.Face.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GlassesType
    {
        NoGlasses = 0,
        ReadingGlasses = 1,
        Sunglasses = 2,
        SwimmingGoggles = 3
    }
}
