using ComputerVision.Domain;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerVision
{
    public interface IComputerVisionService
    {
        Task<List<ImageAnalysis>> AnalyzeImageFiles(List<ImageFile> imageFiles);
        Task<ImageAnalysis> AnalyzeImageFile(ImageFile imageFile);
        Task<RecognitionResult> RecognizeText(ImageFile imageFile, TextRecognitionMode textRecognitionMode);
        Task<List<DetectedFace>> DetectFaces(ImageFile imageFile);
        Task<VerifyResult> VerifyFaces(ImageFile imageFile1, ImageFile imageFile2);
        Task BatchProcess(ImageFile imageFile);
    }
}