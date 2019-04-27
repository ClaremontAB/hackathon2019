using ComputerVision.Domain;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerVision.Services
{
    public interface IAnalysisService
    {
        Task<ImageAnalysis> AnalyzeRemoteAsync(string imageUrl);
        Task<ImageAnalysis> AnalyzeLocalFileAsync(ImageFile imageFile);
        Task<RecognitionResult> RecognizeText(ImageFile imageFile, TextRecognitionMode textRecognitionMode);
        Task<List<DetectedFace>> DetectFaces(ImageFile imageFile);
        Task<VerifyResult> VerifyFaces(ImageFile imageFile1, ImageFile imageFile2);

    }
}