using System;
using System.Threading.Tasks;
using ComputerVision.Domain;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ComputerVision.Data2
{
    public class BlobInfo
    {
        public string Uri { get; set; }
        public string SasToken { get; set; }
        public string UriWithSasToken { get; internal set; }
    }

    public class BlobStorageRepository
    {

        private static string _storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=computervisionsa;AccountKey=VnCiJ8rSFPR2FIhG6sJA3c/h/mxp1eoQxDM7AC5hZLox+DAEiqPPNPR+H4mEjPGipurYItmUgpU98n+/AJ0IVg==;EndpointSuffix=core.windows.net";
        public async Task<BlobInfo> AddImageFileIfMissing(Domain.ImageFile imageFile, byte[] bytes)
        {
            CloudStorageAccount storageAccount = null;
            CloudBlobContainer cloudBlobContainer = null;


            if (CloudStorageAccount.TryParse(_storageConnectionString, out storageAccount))
            {
                try
                {
                    CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                    cloudBlobContainer = cloudBlobClient.GetContainerReference("images");
                    await cloudBlobContainer.CreateIfNotExistsAsync();

                    BlobContainerPermissions permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Off
                    };
                    await cloudBlobContainer.SetPermissionsAsync(permissions);

                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageFile.HashString + ".jpg");
                    if (!await cloudBlockBlob.ExistsAsync())
                    {
                        await cloudBlockBlob.UploadFromByteArrayAsync(bytes, 0, bytes.Length);
                    }
                    string sasToken = GetSasToken();
                    string uri = cloudBlockBlob.Uri.ToString();
                    return new BlobInfo
                    {
                        Uri = uri,
                        UriWithSasToken = uri + sasToken,
                        SasToken = sasToken,
                    };
                    //Console.WriteLine("Listing blobs in container.");
                    //BlobContinuationToken blobContinuationToken = null;
                    //do
                    //{
                    //    var results = await cloudBlobContainer.ListBlobsSegmentedAsync(null, blobContinuationToken);
                    //    // Get the value of the continuation token returned by the listing call.
                    //    blobContinuationToken = results.ContinuationToken;
                    //    foreach (IListBlobItem item in results.Results)
                    //    {
                    //        Console.WriteLine(item.Uri);
                    //    }
                    //} while (blobContinuationToken != null); // Loop while the continuation token is not null.
                    //Console.WriteLine();

                    //// Download the blob to a local file, using the reference created earlier. 
                    //// Append the string "_DOWNLOADED" before the .txt extension so that you can see both files in MyDocuments.
                    //destinationFile = sourceFile.Replace(".txt", "_DOWNLOADED.txt");
                    //Console.WriteLine("Downloading blob to {0}", destinationFile);
                    //Console.WriteLine();
                    //await cloudBlockBlob.DownloadToFileAsync(destinationFile, FileMode.Create);
                }
                catch (StorageException ex)
                {
                }

            }
            return null;

        }

        public string GetSasToken()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_storageConnectionString);

            SharedAccessAccountPolicy policy = new SharedAccessAccountPolicy()
            {
                Permissions = SharedAccessAccountPermissions.Read 
                    | SharedAccessAccountPermissions.Write 
                    | SharedAccessAccountPermissions.List,
                Services = SharedAccessAccountServices.Blob 
                    | SharedAccessAccountServices.File,
                ResourceTypes = SharedAccessAccountResourceTypes.Container
                    |SharedAccessAccountResourceTypes.Object 
                    | SharedAccessAccountResourceTypes.Service,
                SharedAccessStartTime = DateTime.Now.AddHours(-3),
                SharedAccessExpiryTime = DateTime.UtcNow.AddYears(1), // TODO SAS Token is valid for one year. - Use some other way to restrict public access and allow access by https?
                Protocols = SharedAccessProtocol.HttpsOnly
            };

            return storageAccount.GetSharedAccessSignature(policy);
        }

    }
}