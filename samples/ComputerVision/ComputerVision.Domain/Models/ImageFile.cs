using System;

namespace ComputerVision.Domain
{

    public class ImageFile
    {
        public string HashString { get; set; }

        public string CameraManufacturer { get; set; }
        public string CameraModel { get; set; }
        public DateTimeOffset DateTaken { get; set; }
        public uint Height { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Orientation { get; set; }
        public uint Rating { get; set; }
        public string Title { get; set; }
        public uint Width { get; set; }

        public string ContentType { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string DisplayName { get; set; }
        public string DisplayType { get; set; }
        public string FileType { get; set; }
        public string FolderRelativeId { get; set; }
        public bool IsAvailable { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset ItemDate { get; set; }
        public ulong Size { get; set; }

        public string ImageUri { get; set; }
        public string ImageSasToken { get; set; }
        public string ImageUriWithSasToken { get; set; }
      
    }
}