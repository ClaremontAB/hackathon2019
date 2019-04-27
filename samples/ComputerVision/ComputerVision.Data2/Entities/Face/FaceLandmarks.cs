using Newtonsoft.Json;

namespace ComputerVision.Data2
{
    public class FaceLandmarks
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "upperLipBottom")]
        public Coordinate UpperLipBottom { get; set; }
        [JsonProperty(PropertyName = "upperLipTop")]
        public Coordinate UpperLipTop { get; set; }
        [JsonProperty(PropertyName = "noseRightAlarOutTip")]
        public Coordinate NoseRightAlarOutTip { get; set; }
        [JsonProperty(PropertyName = "noseLeftAlarOutTip")]
        public Coordinate NoseLeftAlarOutTip { get; set; }
        [JsonProperty(PropertyName = "noseRightAlarTop")]
        public Coordinate NoseRightAlarTop { get; set; }
        [JsonProperty(PropertyName = "noseLeftAlarTop")]
        public Coordinate NoseLeftAlarTop { get; set; }
        [JsonProperty(PropertyName = "noseRootRight")]
        public Coordinate NoseRootRight { get; set; }
        [JsonProperty(PropertyName = "noseRootLeft")]
        public Coordinate NoseRootLeft { get; set; }
        [JsonProperty(PropertyName = "eyeRightOuter")]
        public Coordinate EyeRightOuter { get; set; }
        [JsonProperty(PropertyName = "eyeRightBottom")]
        public Coordinate EyeRightBottom { get; set; }
        [JsonProperty(PropertyName = "eyeRightTop")]
        public Coordinate EyeRightTop { get; set; }
        [JsonProperty(PropertyName = "eyeRightInner")]
        public Coordinate EyeRightInner { get; set; }
        [JsonProperty(PropertyName = "eyebrowRightOuter")]
        public Coordinate EyebrowRightOuter { get; set; }
        [JsonProperty(PropertyName = "eyebrowRightInner")]
        public Coordinate EyebrowRightInner { get; set; }
        [JsonProperty(PropertyName = "eyeLeftInner")]
        public Coordinate EyeLeftInner { get; set; }
        [JsonProperty(PropertyName = "eyeLeftBottom")]
        public Coordinate EyeLeftBottom { get; set; }
        [JsonProperty(PropertyName = "eyeLeftTop")]
        public Coordinate EyeLeftTop { get; set; }
        [JsonProperty(PropertyName = "eyeLeftOuter")]
        public Coordinate EyeLeftOuter { get; set; }
        [JsonProperty(PropertyName = "eyebrowLeftInner")]
        public Coordinate EyebrowLeftInner { get; set; }
        [JsonProperty(PropertyName = "eyebrowLeftOuter")]
        public Coordinate EyebrowLeftOuter { get; set; }
        [JsonProperty(PropertyName = "mouthRight")]
        public Coordinate MouthRight { get; set; }
        [JsonProperty(PropertyName = "mouthLeft")]
        public Coordinate MouthLeft { get; set; }
        [JsonProperty(PropertyName = "noseTip")]
        public Coordinate NoseTip { get; set; }
        [JsonProperty(PropertyName = "pupilRight")]
        public Coordinate PupilRight { get; set; }
        [JsonProperty(PropertyName = "pupilLeft")]
        public Coordinate PupilLeft { get; set; }
        [JsonProperty(PropertyName = "underLipTop")]
        public Coordinate UnderLipTop { get; set; }
        [JsonProperty(PropertyName = "underLipBottom")]
        public Coordinate UnderLipBottom { get; set; }
    }
}


