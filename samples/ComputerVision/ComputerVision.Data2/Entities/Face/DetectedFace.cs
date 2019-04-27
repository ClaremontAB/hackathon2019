using ComputerVision.Data2.Entities.Face.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace ComputerVision.Data2
{

    //DetectedFace
    //FaceLandmarks
    // FaceRectangle
    // Coordinate
    // FaceAttributes
    // FacialHair
    // HeadPose
    // Emotion
    // Hair
    // HairColor
    // Makeup
    // Occlusion
    // Accessory
    // Blur
    // Exposure
    // Noise

    // GlassesType
    // NoiseLevel
    // ExposureLevel
    // BlurLevel
    // AccessoryType
    // HairColorType

    public class DetectedFace
    {
        public int Id { get; set; }
        public int ImageFileId { get; set; }
        
        [JsonProperty(PropertyName = "faceId")]
        public Guid? FaceId { get; set; }
        [JsonProperty(PropertyName = "faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }
        [JsonProperty(PropertyName = "faceLandmarks")]
        public FaceLandmarks FaceLandmarks { get; set; }
        [JsonProperty(PropertyName = "faceAttributes")]
        public FaceAttributes FaceAttributes { get; set; }
    }

    public class FaceAttributes
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "age")]
        public double? Age { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public Gender? Gender { get; set; }
        [JsonProperty(PropertyName = "smile")]
        public double? Smile { get; set; }
        [JsonProperty(PropertyName = "facialHair")]
        public FacialHair FacialHair { get; set; }
        [JsonProperty(PropertyName = "glasses")]
        public GlassesType? Glasses { get; set; }
        [JsonProperty(PropertyName = "headPose")]
        public HeadPose HeadPose { get; set; }
        [JsonProperty(PropertyName = "emotion")]
        public Emotion Emotion { get; set; }
        [JsonProperty(PropertyName = "hair")]
        public Hair Hair { get; set; }
        [JsonProperty(PropertyName = "makeup")]
        public Makeup Makeup { get; set; }
        [JsonProperty(PropertyName = "occlusion")]
        public Occlusion Occlusion { get; set; }
        [JsonProperty(PropertyName = "accessories")]
        public IList<Accessory> Accessories { get; set; }
        [JsonProperty(PropertyName = "blur")]
        public Blur Blur { get; set; }
        [JsonProperty(PropertyName = "exposure")]
        public Exposure Exposure { get; set; }
        [JsonProperty(PropertyName = "noise")]
        public Noise Noise { get; set; }
    }

    public class FacialHair
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "moustache")]
        public double Moustache { get; set; }
        [JsonProperty(PropertyName = "beard")]
        public double Beard { get; set; }
        [JsonProperty(PropertyName = "sideburns")]
        public double Sideburns { get; set; }
    }

    public class HeadPose
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "roll")]
        public double Roll { get; set; }
        [JsonProperty(PropertyName = "yaw")]
        public double Yaw { get; set; }
        [JsonProperty(PropertyName = "pitch")]
        public double Pitch { get; set; }
    }

    public class Emotion
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "anger")]
        public double Anger { get; set; }
        [JsonProperty(PropertyName = "contempt")]
        public double Contempt { get; set; }
        [JsonProperty(PropertyName = "disgust")]
        public double Disgust { get; set; }
        [JsonProperty(PropertyName = "fear")]
        public double Fear { get; set; }
        [JsonProperty(PropertyName = "happiness")]
        public double Happiness { get; set; }
        [JsonProperty(PropertyName = "neutral")]
        public double Neutral { get; set; }
        [JsonProperty(PropertyName = "sadness")]
        public double Sadness { get; set; }
        [JsonProperty(PropertyName = "surprise")]
        public double Surprise { get; set; }
    }

    public class Hair
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "bald")]
        public double Bald { get; set; }
        [JsonProperty(PropertyName = "invisible")]
        public bool Invisible { get; set; }
        [JsonProperty(PropertyName = "hairColor")]
        public IList<HairColor> HairColor { get; set; }
    }

    public class HairColor
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "color")]
        public HairColorType Color { get; set; }
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }
    }

    public class Makeup
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "eyeMakeup")]
        public bool EyeMakeup { get; set; }
        [JsonProperty(PropertyName = "lipMakeup")]
        public bool LipMakeup { get; set; }
    }

    public class Occlusion
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "foreheadOccluded")]
        public bool ForeheadOccluded { get; set; }
        [JsonProperty(PropertyName = "eyeOccluded")]
        public bool EyeOccluded { get; set; }
        [JsonProperty(PropertyName = "mouthOccluded")]
        public bool MouthOccluded { get; set; }
    }

    public class Accessory
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public AccessoryType Type { get; set; }
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }
    }

    public class Blur
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "blurLevel")]
        public BlurLevel BlurLevel { get; set; }
        [JsonProperty(PropertyName = "value")]
        public double Value { get; set; }
    }

    public class Exposure
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "exposureLevel")]
        public ExposureLevel ExposureLevel { get; set; }
        [JsonProperty(PropertyName = "value")]
        public double Value { get; set; }
    }

    public class Noise
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "noiseLevel")]
        public NoiseLevel NoiseLevel { get; set; }
        [JsonProperty(PropertyName = "value")]
        public double Value { get; set; }
    }

    
}


