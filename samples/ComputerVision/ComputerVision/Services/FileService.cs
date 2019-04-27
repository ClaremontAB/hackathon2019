using ComputerVision.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Search;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace ComputerVision
{
    public class FileService : IFileService
    {
        public async Task<BitmapImage> GetBitmapImage(ImageFile imageFile)
        {
            StorageFile storageFile = await StorageFile.GetFileFromPathAsync(imageFile.Path);
            IRandomAccessStream fileStream = await storageFile.OpenAsync(FileAccessMode.Read);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.SetSource(fileStream);
            return bitmapImage;
        }

        //public async Task TranscodeImageFile(string path)
        //{
           
        //    StorageFile imageFile = await StorageFile.GetFileFromPathAsync(path);
        //    BasicProperties basicProperties = await imageFile.GetBasicPropertiesAsync();
        //    while (basicProperties.Size > 20000)
        //    {

        //        using (IRandomAccessStream fileStream = await imageFile.OpenAsync(FileAccessMode.ReadWrite))
        //        {
        //            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream);
        //            var memStream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
        //            BitmapEncoder encoder = await BitmapEncoder.CreateForTranscodingAsync(memStream, decoder);

        //            encoder.BitmapTransform.ScaledWidth = decoder.OrientedPixelWidth / 2;
        //            encoder.BitmapTransform.ScaledHeight = decoder.OrientedPixelHeight / 2;

        //            await encoder.FlushAsync();

        //            memStream.Seek(0);
        //            fileStream.Seek(0);
        //            fileStream.Size = 0;
        //            await RandomAccessStream.CopyAsync(memStream, fileStream);

        //            memStream.Dispose();
        //        }
        //        basicProperties = await imageFile.GetBasicPropertiesAsync();
        //    }
        //}

        //public static async Task<BitmapImage> ResizedImage(StorageFile ImageFile, int maxWidth, int maxHeight)
        //{
        //    IRandomAccessStream inputstream = await ImageFile.OpenReadAsync();
        //    BitmapImage sourceImage = new BitmapImage();
        //    sourceImage.SetSource(inputstream);
        //    var origHeight = sourceImage.PixelHeight;
        //    var origWidth = sourceImage.PixelWidth;
        //    var ratioX = maxWidth / (float)origWidth;
        //    var ratioY = maxHeight / (float)origHeight;
        //    var ratio = Math.Min(ratioX, ratioY);
        //    var newHeight = (int)(origHeight * ratio);
        //    var newWidth = (int)(origWidth * ratio);

        //    sourceImage.DecodePixelWidth = newWidth;
        //    sourceImage.DecodePixelHeight = newHeight;


        //    return sourceImage;
        //}


        public async Task<byte[]> GetImageAsByteArray(string imageFilePath)
        {
            StorageFile storageFile = await StorageFile.GetFileFromPathAsync(imageFilePath);
            using (var stream = await storageFile.OpenStreamForReadAsync())
            {
                BinaryReader binaryReader = new BinaryReader(stream);
                return binaryReader.ReadBytes((int)stream.Length);
            }
        }

        public async Task<StorageFolder> GetPickedFolder()
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");
            //folderPicker.FileTypeFilter.Add(".jpg");
            //folderPicker.FileTypeFilter.Add(".gif");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            return folder;
        }

        public async Task<List<ImageFile>> GetImageFiles(StorageFolder folder)
        {
            // https://docs.microsoft.com/en-us/windows/uwp/files/fast-file-properties
            Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);

            IndexedState folderIndexedState = await folder.GetIndexedStateAsync();
            if (folderIndexedState == IndexedState.NotIndexed || folderIndexedState == IndexedState.Unknown)
            {
                return null;
            }

            QueryOptions picturesQuery = GetPicturesQuery(folder);
            List<ImageFile> imageFiles = await GetPicturesQueryResult(folder, picturesQuery);

            return imageFiles;
        }

        private QueryOptions GetPicturesQuery(StorageFolder folder)
        {
            QueryOptions picturesQuery = new QueryOptions()
            {
                FolderDepth = FolderDepth.Deep,
                ApplicationSearchFilter = "System.Security.EncryptionOwners:[]",
                IndexerOption = IndexerOption.OnlyUseIndexerAndOptimizeForIndexedProperties
            };

            picturesQuery.FileTypeFilter.Add(".jpg");
            picturesQuery.FileTypeFilter.Add(".gif");
            string[] otherProperties = new string[]
            {
                SystemProperties.GPS.LatitudeDecimal,
                SystemProperties.GPS.LongitudeDecimal
            };

            picturesQuery.SetPropertyPrefetch(PropertyPrefetchOptions.BasicProperties | PropertyPrefetchOptions.ImageProperties,
             otherProperties);
            SortEntry sortOrder = new SortEntry()
            {
                AscendingOrder = true,
                PropertyName = "System.FileName"
            };
            picturesQuery.SortOrder.Add(sortOrder);

            if (!folder.AreQueryOptionsSupported(picturesQuery))
            {
                picturesQuery.SortOrder.Clear();
            }

            return picturesQuery;
        }

        private async Task<List<ImageFile>> GetPicturesQueryResult(StorageFolder folder, QueryOptions picturesQuery)
        {
            List<ImageFile> imageFiles = new List<ImageFile>();
            uint index = 0;
            const uint stepSize = 100;
            StorageFileQueryResult queryResult = folder.CreateFileQueryWithOptions(picturesQuery);
            IReadOnlyList<StorageFile> images = await queryResult.GetFilesAsync(index, stepSize);
            while (images.Count != 0 || index < 10000)
            {
                foreach (StorageFile storageFile in images)
                {
                    imageFiles.Add(await GetImageFile(storageFile));
                }
                index += stepSize;
                images = await queryResult.GetFilesAsync(index, stepSize);
            }
            return imageFiles;
        }

        private async Task<ImageFile> GetImageFile(StorageFile file)
        {
            ImageProperties imageProperties = await file.Properties.GetImagePropertiesAsync();
            BasicProperties basicProperties = await file.GetBasicPropertiesAsync();
            string hashString = await GetHashString(file.Path);

            ImageFile imageFile = new ImageFile
            {
                HashString = hashString,

                CameraManufacturer = imageProperties.CameraManufacturer,
                CameraModel = imageProperties.CameraModel,
                DateTaken = imageProperties.DateTaken,
                Height = imageProperties.Height,
                Latitude = imageProperties.Latitude,
                Longitude = imageProperties.Longitude,
                Orientation = imageProperties.Orientation.ToString(),
                Rating = imageProperties.Rating,
                Title = imageProperties.Title,
                Width = imageProperties.Width,

                ContentType = file.ContentType,
                DateCreated = file.DateCreated,
                DisplayName = file.DisplayName,
                DisplayType = file.DisplayType,
                FileType = file.FileType,
                FolderRelativeId = file.FolderRelativeId,
                IsAvailable = file.IsAvailable,
                Name = file.Name,
                Path = file.Path,
                Size = basicProperties.Size,
                DateModified = basicProperties.DateModified,
                ItemDate = basicProperties.ItemDate,
            };
            return imageFile;

        }

        private async Task<string> GetHashString(string path)
        {
            using (var md5 = MD5.Create())
            {
                StorageFile storageFile = await StorageFile.GetFileFromPathAsync(path);
                using (var stream = await storageFile.OpenStreamForReadAsync())
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public async Task<StorageFolder> GetFolder(string path)
        {
            return await StorageFolder.GetFolderFromPathAsync(path);
        }
    }
}
