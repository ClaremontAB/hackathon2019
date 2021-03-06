﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ComputerVision.Data2.Entities.Face.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BlurLevel
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}
