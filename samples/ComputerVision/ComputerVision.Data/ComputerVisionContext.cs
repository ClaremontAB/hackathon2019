using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace ComputerVision.Data
{
    public class ComputerVisionContext : DbContext
    {
        public DbSet<ImageFile> ImageFile{ get; set; }
        public DbSet<ImageAnalysis> ImageAnalysis { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryDetail> CategoryDetail { get; set; }
        public DbSet<LandmarksModel> LandmarksModel { get; set; }
        public DbSet<CelebritiesModel> CelebritiesModel { get; set; }
        public DbSet<FaceRectangle> FaceRectangle { get; set; }
        public DbSet<AdultInfo> AdultInfo { get; set; }
        public DbSet<ColorInfo> ColorInfo { get; set; }
        public DbSet<ImageType> ImageType { get; set; }
        public DbSet<ImageTag> ImageTag { get; set; }
        public DbSet<ImageDescriptionDetails> ImageDescriptionDetails { get; set; }
        public DbSet<ImageCaption> ImageCaption { get; set; }
        public DbSet<FaceDescription> FaceDescription { get; set; }
        public DbSet<ImageMetadata> ImageMetadata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:computervision.database.windows.net,1433;Initial Catalog=ComputerVision;Persist Security Info=False;User ID=cvadmin;Password=tV3wZD6LZe9AhidRHP6u;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
    public class ImageFile
    {
        public int Id { get; set; }

        public string HashString { get; internal set; }

        public string CameraManufacturer { get; set; }
        public string CameraModel { get; set; }
        public DateTimeOffset DateTaken { get; set; }
        public uint Height { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        //public PhotoOrientation Orientation { get; set; }
        public uint Rating { get; set; }
        public string Title { get; set; }
        public uint Width { get; set; }

        //public FileAttributes Attributes { get; set; }
        public string ContentType { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string DisplayName { get; set; }
        public string DisplayType { get; set; }
        public string FileType { get; set; }
        public string FolderRelativeId { get; set; }
        public bool IsAvailable { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class ImageAnalysis
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<Category> Categories { get; set; }
        [JsonProperty(PropertyName = "adult")]
        public AdultInfo Adult { get; set; }
        [JsonProperty(PropertyName = "color")]
        public ColorInfo Color { get; set; }
        [JsonProperty(PropertyName = "imageType")]
        public ImageType ImageType { get; set; }
        [JsonProperty(PropertyName = "tags")]
        public IList<ImageTag> Tags { get; set; }
        [JsonProperty(PropertyName = "description")]
        public ImageDescriptionDetails Description { get; set; }
        [JsonProperty(PropertyName = "faces")]
        public IList<FaceDescription> Faces { get; set; }
        [JsonProperty(PropertyName = "requestId")]
        public string RequestId { get; set; }
        [JsonProperty(PropertyName = "metadata")]
        public ImageMetadata Metadata { get; set; }
    }

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

    public class CategoryDetail
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "celebrities")]
        public IList<CelebritiesModel> Celebrities { get; set; }
        [JsonProperty(PropertyName = "landmarks")]
        public IList<LandmarksModel> Landmarks { get; set; }
    }

    public class LandmarksModel
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }
    }

    public class CelebritiesModel
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }
        [JsonProperty(PropertyName = "faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }
    }

    public class FaceRectangle
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "left")]
        public int Left { get; set; }
        [JsonProperty(PropertyName = "top")]
        public int Top { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
    }

    public class AdultInfo
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "isAdultContent")]
        public bool IsAdultContent { get; set; }
        [JsonProperty(PropertyName = "isRacyContent")]
        public bool IsRacyContent { get; set; }
        [JsonProperty(PropertyName = "adultScore")]
        public double AdultScore { get; set; }
        [JsonProperty(PropertyName = "racyScore")]
        public double RacyScore { get; set; }
    }

    public class ColorInfo
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "dominantColorForeground")]
        public string DominantColorForeground { get; set; }
        [JsonProperty(PropertyName = "dominantColorBackground")]
        public string DominantColorBackground { get; set; }
        [JsonProperty(PropertyName = "dominantColors")]
        public IList<string> DominantColors { get; set; }
        [JsonProperty(PropertyName = "accentColor")]
        public string AccentColor { get; set; }
        [JsonProperty(PropertyName = "isBWImg")]
        public bool IsBWImg { get; set; }
    }

    public class ImageType
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "clipArtType")]
        public int ClipArtType { get; set; }
        [JsonProperty(PropertyName = "lineDrawingType")]
        public int LineDrawingType { get; set; }
    }

    public class ImageTag
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }
        [JsonProperty(PropertyName = "hint")]
        public string Hint { get; set; }
    }

    public class ImageDescriptionDetails
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public IList<string> Tags { get; set; }
        [JsonProperty(PropertyName = "captions")]
        public IList<ImageCaption> Captions { get; set; }
    }

    public class ImageCaption
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "confidence")]
        public double Confidence { get; set; }
    }

    public class FaceDescription
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public Gender? Gender { get; set; }
        [JsonProperty(PropertyName = "faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public class ImageMetadata
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }
    }




}
