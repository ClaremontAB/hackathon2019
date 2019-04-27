using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ComputerVision.Data2.Entities.Face.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HairColorType
    {
        Unknown = 0,
        White = 1,
        Gray = 2,
        Blond = 3,
        Brown = 4,
        Red = 5,
        Black = 6,
        Other = 7
    }
}
