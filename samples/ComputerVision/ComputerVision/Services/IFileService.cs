using ComputerVision.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace ComputerVision
{
    public interface IFileService
    {
        //Task TranscodeImageFile(string imageFile);
        Task<byte[]> GetImageAsByteArray(string imageFilePath);
        Task<List<ImageFile>> GetImageFiles(StorageFolder folder);
        Task<StorageFolder> GetPickedFolder();
        Task<BitmapImage> GetBitmapImage(ImageFile imageFile);
        Task<StorageFolder> GetFolder(string path);
    }
}