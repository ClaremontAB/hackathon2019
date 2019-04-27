using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ComputerVision.Data2
{
    public class ComputerVisionContext : DbContext
    {
        // https://docs.microsoft.com/en-us/ef/core/get-started/uwp/getting-started
        public DbSet<ImageFile> ImageFile { get; set; }

        #region ImageAnalysis
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
        #endregion ImageAnalysis

        #region RecognizeText
        public DbSet<RecognitionResult> RecognitionResult { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<Line> Line { get; set; }
        #endregion RecognizeText

        #region Face
        public DbSet<DetectedFace> DetectedFace { get; set; }
        public DbSet<FaceLandmarks> FaceLandmarks { get; set; }
        public DbSet<Coordinate> Coordinate { get; set; }
        public DbSet<FaceAttributes> FaceAttributes { get; set; }
        public DbSet<FacialHair> FacialHair { get; set; }
        public DbSet<HeadPose> HeadPose { get; set; }
        public DbSet<Emotion> Emotion { get; set; }
        public DbSet<Hair> Hair { get; set; }
        public DbSet<HairColor> HairColor { get; set; }
        public DbSet<Makeup> Makeup { get; set; }
        public DbSet<Occlusion> Occlusion { get; set; }
        public DbSet<Accessory> Accessory { get; set; }
        public DbSet<Blur> Blur { get; set; }
        public DbSet<Exposure> Exposure { get; set; }
        public DbSet<Noise> Noise { get; set; }

        #endregion Face

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:computervision.database.windows.net,1433;Initial Catalog=ComputerVision;Persist Security Info=False;User ID=cvadmin;Password=tV3wZD6LZe9AhidRHP6u;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }




}


