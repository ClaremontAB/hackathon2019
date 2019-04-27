using ComputerVision.Domain;
using ComputerVision.Services;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerVision
{
    public class ComputerVisionService : IComputerVisionService
    {
      
        private readonly IAnalysisService _analysisService;
        private readonly IFileService _fileService;
        private readonly Data2.ComputerVisionRepository _computerVisionRepository;
        private readonly Data2.BlobStorageRepository _blobStorageRepository;

        private static ulong _fileSizeLimit = 4194304;
        public ComputerVisionService(
            IFileService fileService, 
            IAnalysisService analysisService,
            Data2.ComputerVisionRepository computerVisionRepository,
            Data2.BlobStorageRepository blobStorageRepository
            )
        {
            _fileService = fileService;
            _analysisService = analysisService;
            _computerVisionRepository = computerVisionRepository;
            _blobStorageRepository = blobStorageRepository;
        }


        public async Task BatchProcess(ImageFile imageFile)
        {
            await AddImageFileIfMissing(imageFile);
            if (imageFile.Size > _fileSizeLimit) return;
            await _analysisService.AnalyzeLocalFileAsync(imageFile);
            await _analysisService.RecognizeText(imageFile, TextRecognitionMode.Handwritten);
            await _analysisService.RecognizeText(imageFile, TextRecognitionMode.Printed);
            await _analysisService.DetectFaces(imageFile);
        }


        public async Task<ImageAnalysis> AnalyzeImageFile(ImageFile imageFile)
        {
            await AddImageFileIfMissing(imageFile);
            if (imageFile.Size > _fileSizeLimit) return null;
            ImageAnalysis analysis = await _analysisService.AnalyzeLocalFileAsync(imageFile);
            return analysis;
        }

       

        public async Task<List<ImageAnalysis>> AnalyzeImageFiles(List<ImageFile> imageFiles)
        {
            List<ImageAnalysis> analyzes = new List<ImageAnalysis>();
            foreach (ImageFile imageFile in imageFiles)
            {
                await AddImageFileIfMissing(imageFile);
                if (imageFile.Size > _fileSizeLimit) continue;
                ImageAnalysis analysis = await _analysisService.AnalyzeLocalFileAsync(imageFile);
                analyzes.Add(analysis);
            }
            return analyzes;
        }

      

        public async Task<RecognitionResult> RecognizeText(ImageFile imageFile, TextRecognitionMode textRecognitionMode)
        {
            await AddImageFileIfMissing(imageFile);
            if (imageFile.Size > _fileSizeLimit) return null;
            RecognitionResult recognitionResult = await _analysisService.RecognizeText(imageFile, textRecognitionMode);
            return recognitionResult;
        }

        private async Task AddImageFileIfMissing(ImageFile imageFile)
        {
            ImageFile savedImageFile = _computerVisionRepository.GetImageFile(imageFile);
            if (savedImageFile == null)
            {
                byte[] bytes = await _fileService.GetImageAsByteArray(imageFile.Path);
                Data2.BlobInfo blobInfo = await _blobStorageRepository.AddImageFileIfMissing(imageFile, bytes);
                imageFile.ImageUri = blobInfo.Uri;
                imageFile.ImageSasToken = blobInfo.SasToken;
                imageFile.ImageUriWithSasToken = blobInfo.UriWithSasToken;
                _computerVisionRepository.AddImageFile(imageFile);
                await _blobStorageRepository.AddImageFileIfMissing(imageFile, bytes);
            }
        }

        public async Task<List<DetectedFace>> DetectFaces(ImageFile imageFile)
        {
            await AddImageFileIfMissing(imageFile);
            if (imageFile.Size > _fileSizeLimit) return null;
            List<DetectedFace> detectFaces = await _analysisService.DetectFaces(imageFile);
            return detectFaces;
        }

        public async Task<VerifyResult> VerifyFaces(ImageFile imageFile1, ImageFile imageFile2)
        {
            await AddImageFileIfMissing(imageFile1);
            await AddImageFileIfMissing(imageFile2);
            if (imageFile1.Size > _fileSizeLimit) return null;
            if (imageFile2.Size > _fileSizeLimit) return null;
            VerifyResult verifyResult = await _analysisService.VerifyFaces(imageFile1, imageFile2);
            return verifyResult;
        }

    }
}
