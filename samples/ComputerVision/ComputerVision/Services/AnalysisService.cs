using ComputerVision.Domain;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ComputerVision.Services
{
    public class AnalysisService : IAnalysisService
    {
        // https://azure.microsoft.com/en-us/try/cognitive-services/my-apis/?apiSlug=computer-vision
        private const string subscriptionKeyCv = "e05b26d3772f47028c04c3f1c72195f8";// "cd4c1bceb59144a1978734d1209eac6e";  
        private const string subscriptionKeyFace = "dc98fc0e77964819aee81bc071356216";


        // rickard.svensson@claremont.se MS-account
        // Vision
        // Nyckel 1: e05b26d3772f47028c04c3f1c72195f8
        // Nyckel 2: 83d226a394d641a3b90089ca1d1d0666

        // Face
        // Nyckel 1: dc98fc0e77964819aee81bc071356216
        // Nyckel 2: b77b74914ba948eaaf0a289fd96de2d3

        //private const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/analyze";
        private readonly Data2.ComputerVisionRepository _computerVisionRepository;
        private static readonly List<VisualFeatureTypes> features = new List<VisualFeatureTypes>()
        {
            VisualFeatureTypes.Adult,
            VisualFeatureTypes.Categories,
            VisualFeatureTypes.Color,
            VisualFeatureTypes.Description,
            VisualFeatureTypes.Faces,
            VisualFeatureTypes.ImageType,
            VisualFeatureTypes.Tags,
        };

        public AnalysisService(Data2.ComputerVisionRepository computerVisionRepository)
        {
            _computerVisionRepository = computerVisionRepository;
        }
        #region Analyze
        public async Task<ImageAnalysis> AnalyzeRemoteAsync(string imageUrl)
        {
            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
            {
                throw new Exception($"Invalid remoteImageUrl: {imageUrl}");
            }
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    ImageAnalysis analysis = await GetComputerVisionClient().AnalyzeImageAsync(imageUrl, features);
                    return analysis;
                }
                catch (ComputerVisionErrorException ex)
                {
                    await HandleComputerVisionErrorException(ex);
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }

        public async Task<ImageAnalysis> AnalyzeLocalFileAsync(ImageFile imageFile)
        {
            ImageAnalysis imageAnalysis = _computerVisionRepository.GetImageAnalysis(imageFile);

            if (imageAnalysis == null)
            {
                imageAnalysis = await AnalyzeAndAdd(imageFile);
            }
            return imageAnalysis;

        }

        private async Task<ImageAnalysis> AnalyzeAndAdd(ImageFile imageFile)
        {
            ImageAnalysis imageAnalysis;
            StorageFile storageFile = await StorageFile.GetFileFromPathAsync(imageFile.Path);
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    using (Stream imageStream = await storageFile.OpenStreamForReadAsync())
                    {
                        imageAnalysis = await GetComputerVisionClient().AnalyzeImageInStreamAsync(imageStream, features);
                        _computerVisionRepository.AddImageAnalysis(imageFile, imageAnalysis);
                    }
                    return imageAnalysis;
                }
                catch (ComputerVisionErrorException ex)
                {
                    await HandleComputerVisionErrorException(ex);
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }
        #endregion Analyze


        #region RecognizeText
        public async Task<RecognitionResult> RecognizeText(ImageFile imageFile, TextRecognitionMode textRecognitionMode)
        {
            RecognitionResult recognitionResult = _computerVisionRepository.GetRecognitionResult(imageFile, textRecognitionMode);

            if (recognitionResult == null)
            {
                recognitionResult = await RecognizeTextAndAdd(imageFile, textRecognitionMode);
            }
            return recognitionResult;
        }

        private async Task<RecognitionResult> RecognizeTextAndAdd(ImageFile imageFile, TextRecognitionMode textRecognitionMode)
        {
            RecognitionResult recognitionResult = null;
            TextOperationResult textOperationResult = await UploadAndRecognizeImageAsync(imageFile.Path, textRecognitionMode);
            if (textOperationResult.Status == TextOperationStatusCodes.Succeeded)
            {
                recognitionResult = textOperationResult.RecognitionResult;
                _computerVisionRepository.AddRecognitionResult(imageFile, recognitionResult, textRecognitionMode);
            }
            return recognitionResult;
        }

        private async Task<TextOperationResult> UploadAndRecognizeImageAsync(string imageFilePath, TextRecognitionMode textRecognitionMode)
        {
            // https://github.com/Microsoft/Cognitive-Vision-Windows
            StorageFile storageFile = await StorageFile.GetFileFromPathAsync(imageFilePath);
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    using (Stream imageStream = await storageFile.OpenStreamForReadAsync())
                    {
                        return await RecognizeAsync(
                            async (ComputerVisionClient client) => await client.RecognizeTextInStreamAsync(imageStream, textRecognitionMode),
                            headers => headers.OperationLocation);
                    }
                }
                catch (ComputerVisionErrorException ex)
                {
                    await HandleComputerVisionErrorException(ex);
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }

       

        private async Task<TextOperationResult> RecognizeAsync<T>(Func<ComputerVisionClient, Task<T>> GetHeadersAsyncFunc, Func<T, string> GetOperationUrlFunc) where T : new()
        {
            var result = default(TextOperationResult);

            using (var client = GetComputerVisionClient())
            {
                T recognizeHeaders = await GetHeadersAsyncFunc(client);
                string operationUrl = GetOperationUrlFunc(recognizeHeaders);
                string operationId = operationUrl.Substring(operationUrl.LastIndexOf('/') + 1);

                if (operationId != null)
                {
                    result = await GetTextOperationResult(client, operationId);
                }
                return result;
            }
        }

        private async Task<TextOperationResult> GetTextOperationResult(ComputerVisionClient client, string operationId)
        {
            var result = default(TextOperationResult);
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    result = await client.GetTextOperationResultAsync(operationId);
                    if (result.Status == TextOperationStatusCodes.Failed || result.Status == TextOperationStatusCodes.Succeeded)
                    {
                        break;
                    }
                    await Task.Delay(3000);
                    result = await client.GetTextOperationResultAsync(operationId);
                }
                catch (ComputerVisionErrorException ex)
                {
                    await HandleComputerVisionErrorException(ex);
                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }
        #endregion RecognizeText

        #region Face
        public async Task<VerifyResult> VerifyFaces(ImageFile imageFile1, ImageFile imageFile2)
        {
            StorageFile storageFile1 = await StorageFile.GetFileFromPathAsync(imageFile1.Path);
            StorageFile storageFile2 = await StorageFile.GetFileFromPathAsync(imageFile2.Path);
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    using (Stream imageStream1 = await storageFile1.OpenStreamForReadAsync())
                    {
                        using (Stream imageStream2 = await storageFile2.OpenStreamForReadAsync())
                        {
                            FaceClient faceClient = GetFaceClient();
                            Guid? faceId1 = await GetFaceId(imageFile1);
                            Guid? faceId2 = await GetFaceId(imageFile2);
                            if (faceId1 != null && faceId2 != null)
                            {
                                VerifyResult verifyResult = await faceClient.Face.VerifyFaceToFaceAsync((Guid)faceId1, (Guid)faceId2);
                                return verifyResult;
                            }
                        }
                    }
                }
                catch (ComputerVisionErrorException ex)
                {
                    await HandleComputerVisionErrorException(ex);
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }

        private async Task<Guid?> GetFaceId(ImageFile imageFile)
        {
            List<DetectedFace> faces = await DetectFaces(imageFile);
            if (faces?.Count > 0 && faces[0] != null)
            {
                return (Guid)faces[0].FaceId;
            }
            return null;
        }

        public async Task<List<DetectedFace>> DetectFaces(ImageFile imageFile)
        {
            List<DetectedFace> detectedFaces = _computerVisionRepository.GetDetectFaces(imageFile);

            if (detectedFaces == null)
            {
                detectedFaces = await DetectFacesAndAdd(imageFile);
            }
            return detectedFaces;
        }

        private async Task<List<DetectedFace>> DetectFacesAndAdd(ImageFile imageFile)
        {
            // https://docs.microsoft.com/sv-se/azure/cognitive-services/face/quickstarts/csharp-detect-sdk
            List<DetectedFace> detectedFaces = null;

            FaceAttributeType[] faceAttributes = {
                FaceAttributeType.Accessories,
                FaceAttributeType.Age,
                FaceAttributeType.Blur,
                FaceAttributeType.Emotion,
                FaceAttributeType.Exposure,
                FaceAttributeType.FacialHair,
                FaceAttributeType.Gender,
                FaceAttributeType.Glasses,
                FaceAttributeType.Hair,
                FaceAttributeType.HeadPose,
                FaceAttributeType.Makeup,
                FaceAttributeType.Noise,
                FaceAttributeType.Occlusion,
                FaceAttributeType.Smile,
                };

            StorageFile storageFile = await StorageFile.GetFileFromPathAsync(imageFile.Path);
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    using (Stream imageStream = await storageFile.OpenStreamForReadAsync())
                    {
                        IList<DetectedFace> faceList = await GetFaceClient().Face.DetectWithStreamAsync(
                                        imageStream, true, true, faceAttributes);
                        if (faceList?.Count > 0)
                        {
                            detectedFaces = faceList.ToList();
                        }
                        break;
                    }
                }
                catch (ComputerVisionErrorException ex)
                {
                    await HandleComputerVisionErrorException(ex);
                }
                catch (Exception ex)
                {

                }
            }

            if (detectedFaces != null)
            {
                _computerVisionRepository.AddDetectFaces(imageFile, detectedFaces);
            }
            return detectedFaces;
        }


        #endregion Face

        private async Task HandleComputerVisionErrorException(ComputerVisionErrorException ex)
        {
            if (ex.Body.Message.Contains("Rate limit is exceeded."))
            {
                int delayInMs = GetDelay(ex.Body.Message);
                await Task.Delay(delayInMs);
            }
            else
            {
                await Task.Delay(30000);
            }
        }

        private int GetDelay(string message)
        {
            int delayInMs;
            string tryAgain = "Try again in";
            int startSecondsIndex = message.IndexOf(tryAgain) + tryAgain.Length;
            int endSecondsIndex = message.IndexOf("seconds");
            int secondsLength = endSecondsIndex - startSecondsIndex;
            string seconds = message.Substring(startSecondsIndex, secondsLength);
            delayInMs = Convert.ToInt32(seconds) * 1000;
            return delayInMs;

        }

        private FaceClient GetFaceClient()
        {
            FaceClient faceClient = new FaceClient(
               new Microsoft.Azure.CognitiveServices.Vision.Face.ApiKeyServiceClientCredentials(subscriptionKeyFace),
               new DelegatingHandler[] { });
            faceClient.Endpoint = "https://westcentralus.api.cognitive.microsoft.com";
            return faceClient;
        }

        private ComputerVisionClient GetComputerVisionClient()
        {
            ComputerVisionClient computerVisionClient = new ComputerVisionClient(
               new Microsoft.Azure.CognitiveServices.Vision.ComputerVision.ApiKeyServiceClientCredentials(subscriptionKeyCv),
               new DelegatingHandler[] { });
            computerVisionClient.Endpoint = "https://westcentralus.api.cognitive.microsoft.com";
            return computerVisionClient;
        }
    }
}
