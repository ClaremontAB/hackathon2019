using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerVision.Data2.Entities.Face.Enums
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExposureLevel
    {
        UnderExposure = 0,
        GoodExposure = 1,
        OverExposure = 2
    }
}
