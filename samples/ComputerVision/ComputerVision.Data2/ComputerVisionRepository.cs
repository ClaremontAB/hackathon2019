using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ComputerVision.Domain;
using Microsoft.EntityFrameworkCore;
using AzureCvModels = Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using AzureFaceModels = Microsoft.Azure.CognitiveServices.Vision.Face.Models;
namespace ComputerVision.Data2
{
    public class ComputerVisionRepository
    {
        private readonly ComputerVisionContext _computerVisionContext;

        public ComputerVisionRepository()
        {
            _computerVisionContext = new ComputerVisionContext();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Domain.ImageFile, ImageFile>();

                // ImageAnalysis
                cfg.CreateMap<ImageAnalysis, AzureCvModels.ImageAnalysis>();
                cfg.CreateMap<Category, AzureCvModels.Category>();
                cfg.CreateMap<CategoryDetail, AzureCvModels.CategoryDetail>();
                cfg.CreateMap<LandmarksModel, AzureCvModels.LandmarksModel>();
                cfg.CreateMap<CelebritiesModel, AzureCvModels.CelebritiesModel>();
                cfg.CreateMap<FaceRectangle, AzureCvModels.FaceRectangle>();
                cfg.CreateMap<AdultInfo, AzureCvModels.AdultInfo>();
                cfg.CreateMap<ColorInfo, AzureCvModels.ColorInfo>()
                    .ForMember(d => d.DominantColors, m => m.MapFrom(s => s.DominantColors.Split(',').ToList()));
                cfg.CreateMap<ImageType, AzureCvModels.ImageType>();
                cfg.CreateMap<ImageTag, AzureCvModels.ImageTag>();
                cfg.CreateMap<ImageDescriptionDetails, AzureCvModels.ImageDescriptionDetails>()
                    .ForMember(d => d.Tags, m => m.MapFrom(s => s.Tags.Split(',').ToList()));
                cfg.CreateMap<ImageCaption, AzureCvModels.ImageCaption>();
                cfg.CreateMap<FaceDescription, AzureCvModels.FaceDescription>();
                cfg.CreateMap<ImageMetadata, AzureCvModels.ImageMetadata>();

                // ImageAnalysis
                cfg.CreateMap<AzureCvModels.ImageAnalysis, ImageAnalysis>();
                cfg.CreateMap<AzureCvModels.Category, Category>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.CategoryDetail, CategoryDetail>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.LandmarksModel, LandmarksModel>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.CelebritiesModel, CelebritiesModel>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.FaceRectangle, FaceRectangle>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.AdultInfo, AdultInfo>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.ColorInfo, ColorInfo>()
                    .ForMember(x => x.Id, y => y.Ignore())
                    .ForMember(d => d.DominantColors, m => m.MapFrom(s => String.Join(", ", s.DominantColors)));
                cfg.CreateMap<AzureCvModels.ImageType, ImageType>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.ImageTag, ImageTag>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.ImageDescriptionDetails, ImageDescriptionDetails>()
                    .ForMember(x => x.Id, y => y.Ignore())
                    .ForMember(d => d.Tags, m => m.MapFrom(s => String.Join(", ", s.Tags)));
                cfg.CreateMap<AzureCvModels.ImageCaption, ImageCaption>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.FaceDescription, FaceDescription>().ForMember(x => x.Id, y => y.Ignore());
                cfg.CreateMap<AzureCvModels.ImageMetadata, ImageMetadata>().ForMember(x => x.Id, y => y.Ignore());

                // RecognitionResult
                cfg.CreateMap<RecognitionResult, AzureCvModels.RecognitionResult>();
                cfg.CreateMap<Line, AzureCvModels.Line>()
                    .ForMember(d => d.BoundingBox, m => m.MapFrom(s => ParseListOfInt(s.BoundingBox)));
                cfg.CreateMap<Word, AzureCvModels.Word>()
                    .ForMember(d => d.BoundingBox, m => m.MapFrom(s => ParseListOfInt(s.BoundingBox)));
               
                // RecognitionResult
                cfg.CreateMap<AzureCvModels.RecognitionResult, RecognitionResult>();
                cfg.CreateMap<AzureCvModels.Line, Line>()
                     .ForMember(d => d.BoundingBox, m => m.MapFrom(s => String.Join(", ", s.BoundingBox))); 
                cfg.CreateMap<AzureCvModels.Word, Word>()
                     .ForMember(d => d.BoundingBox, m => m.MapFrom(s => String.Join(", ", s.BoundingBox)));

                // DetectedFace
                cfg.CreateMap<AzureFaceModels.DetectedFace, DetectedFace>();
                cfg.CreateMap<AzureFaceModels.FaceLandmarks, FaceLandmarks>();
                cfg.CreateMap<AzureFaceModels.FaceRectangle, FaceRectangle>();
                cfg.CreateMap<AzureFaceModels.Coordinate, Coordinate>();
                cfg.CreateMap<AzureFaceModels.FaceAttributes, FaceAttributes>();
                cfg.CreateMap<AzureFaceModels.FacialHair, FacialHair>();
                cfg.CreateMap<AzureFaceModels.HeadPose, HeadPose>();
                cfg.CreateMap<AzureFaceModels.Emotion, Emotion>();
                cfg.CreateMap<AzureFaceModels.Hair, Hair>();
                cfg.CreateMap<AzureFaceModels.HairColor, HairColor>();
                cfg.CreateMap<AzureFaceModels.Makeup, Makeup>();
                cfg.CreateMap<AzureFaceModels.Occlusion, Occlusion>();
                cfg.CreateMap<AzureFaceModels.Accessory, Accessory>();
                cfg.CreateMap<AzureFaceModels.Blur, Blur>();
                cfg.CreateMap<AzureFaceModels.Exposure, Exposure>();
                cfg.CreateMap<AzureFaceModels.Noise, Noise>();

                // DetectedFace
                cfg.CreateMap<DetectedFace, AzureFaceModels.DetectedFace>();
                cfg.CreateMap<FaceLandmarks, AzureFaceModels.FaceLandmarks>();
                cfg.CreateMap<FaceRectangle, AzureFaceModels.FaceRectangle>();
                cfg.CreateMap<Coordinate, AzureFaceModels.Coordinate>();
                cfg.CreateMap<FaceAttributes, AzureFaceModels.FaceAttributes>();
                cfg.CreateMap<FacialHair, AzureFaceModels.FacialHair>();
                cfg.CreateMap<HeadPose, AzureFaceModels.HeadPose>();
                cfg.CreateMap<Emotion, AzureFaceModels.Emotion>();
                cfg.CreateMap<Hair, AzureFaceModels.Hair>();
                cfg.CreateMap<HairColor, AzureFaceModels.HairColor>();
                cfg.CreateMap<Makeup, AzureFaceModels.Makeup>();
                cfg.CreateMap<Occlusion, AzureFaceModels.Occlusion>();
                cfg.CreateMap<Accessory, AzureFaceModels.Accessory>();
                cfg.CreateMap<Blur, AzureFaceModels.Blur>();
                cfg.CreateMap<Exposure, AzureFaceModels.Exposure>();
                cfg.CreateMap<Noise, AzureFaceModels.Noise>();
            }
           );

        }

        private List<int> ParseListOfInt(string boundingBox)
        {
            List<string> bounds = boundingBox.Split(',').ToList();
            List<int> result = bounds.Select(x => Convert.ToInt32(x.Trim())).ToList();
            return result;
                
        }

        #region ImageFile
        public Domain.ImageFile GetImageFile(Domain.ImageFile imageFile)
        {
            ImageFile savedImageFile = _computerVisionContext.ImageFile.SingleOrDefault(x => x.HashString == imageFile.HashString);
            if (savedImageFile != null)
            {
                return Mapper.Map<Domain.ImageFile>(savedImageFile);
            }
            else
            {
                return null;
            }
        }

        public void AddImageFile(Domain.ImageFile imageFile)
        {
            if (imageFile != null)
            {
                ImageFile dbImageFile = Mapper.Map<ImageFile>(imageFile);
                ImageFile addedImageFile = _computerVisionContext.ImageFile.Add(dbImageFile).Entity;
                _computerVisionContext.SaveChanges();

               
            }
        }
        #endregion ImageFile

       

        #region ImageAnalysis
        public AzureCvModels.ImageAnalysis GetImageAnalysis(Domain.ImageFile imageFile)
        {
            ImageFile dbImageFile = _computerVisionContext.ImageFile.SingleOrDefault(x => x.HashString == imageFile.HashString);
            if (dbImageFile != null)
            {
                ImageAnalysis dbImageAnalysis = GetImageAnalysis(dbImageFile);
                AzureCvModels.ImageAnalysis imageAnalysis = null;
                if (dbImageAnalysis != null)
                {
                    imageAnalysis = Mapper.Map<AzureCvModels.ImageAnalysis>(dbImageAnalysis);
                }
                return imageAnalysis;
            }

            return null;
        }

        public void AddImageAnalysis(Domain.ImageFile imageFile, AzureCvModels.ImageAnalysis imageAnalysis)
        {
            ImageAnalysis dbImageAnalysis = Mapper.Map<ImageAnalysis>(imageAnalysis);
            ImageAnalysis addedImageAnalysis = _computerVisionContext.ImageAnalysis.Add(dbImageAnalysis).Entity;
            _computerVisionContext.SaveChanges();
            ImageFile dbImageFile = _computerVisionContext.ImageFile.SingleOrDefault(x => x.HashString == imageFile.HashString);
            if (dbImageFile != null)
            {
                dbImageFile.AnylysisId = addedImageAnalysis.Id;
            }
            _computerVisionContext.SaveChanges();
        }

        

        private ImageAnalysis GetImageAnalysis(ImageFile dbImageFile)
        {
            ImageAnalysis dbImageAnalysis = _computerVisionContext.ImageAnalysis
                    .Include(x => x.Adult)
                    .Include(x => x.Categories)
                        .ThenInclude(y => y.Detail)
                            .ThenInclude(y => y.Celebrities)
                                .ThenInclude(x => x.FaceRectangle)
                    .Include(x => x.Categories)
                        .ThenInclude(y => y.Detail)
                            .ThenInclude(y => y.Landmarks)
                    .Include(x => x.Color)
                    .Include(x => x.Description)
                        .ThenInclude(x => x.Captions)
                    .Include(x => x.ImageType)
                    .Include(x => x.Metadata)
                    .Include(x => x.Tags)
                .SingleOrDefault(x => x.Id == dbImageFile.AnylysisId)
                ;
            return dbImageAnalysis;
        }

       
        #endregion ImageAnalysis

        #region RecognitionResult

        public void AddRecognitionResult(Domain.ImageFile imageFile, AzureCvModels.RecognitionResult recognizeText, AzureCvModels.TextRecognitionMode textRecognitionMode)
        {
            RecognitionResult dbRecognizeText = Mapper.Map<RecognitionResult>(recognizeText);
            RecognitionResult addedRecognizeText = _computerVisionContext.RecognitionResult.Add(dbRecognizeText).Entity;
            _computerVisionContext.SaveChanges();
            ImageFile dbImageFile = _computerVisionContext.ImageFile.SingleOrDefault(x => x.HashString == imageFile.HashString);
            if (dbImageFile != null && textRecognitionMode == AzureCvModels.TextRecognitionMode.Printed)
            {
                dbImageFile.PrintedRecognitionResultId = addedRecognizeText.Id;
            }
            else if (dbImageFile != null && textRecognitionMode == AzureCvModels.TextRecognitionMode.Handwritten)
            {
                dbImageFile.HandwrittenRecognitionResultId = addedRecognizeText.Id;
            }
            _computerVisionContext.SaveChanges();
        }

        public AzureCvModels.RecognitionResult GetRecognitionResult(Domain.ImageFile imageFile, AzureCvModels.TextRecognitionMode textRecognitionMode)
        {
            ImageFile dbImageFile = _computerVisionContext.ImageFile.SingleOrDefault(x => x.HashString == imageFile.HashString);
            if (dbImageFile != null)
            {
                RecognitionResult dbRecognitionResult = GetRecognitionResult(dbImageFile, textRecognitionMode);
                AzureCvModels.RecognitionResult recognitionResult = null;
                if (dbRecognitionResult != null)
                {
                    recognitionResult = Mapper.Map<AzureCvModels.RecognitionResult>(dbRecognitionResult);
                }
                return recognitionResult;
            }

            return null;
        }

        private RecognitionResult GetRecognitionResult(ImageFile dbImageFile, AzureCvModels.TextRecognitionMode textRecognitionMode)
        {
            int? recognitionResultId = textRecognitionMode == AzureCvModels.TextRecognitionMode.Printed ? dbImageFile.PrintedRecognitionResultId : dbImageFile.HandwrittenRecognitionResultId;
            if (recognitionResultId != null)
            {
                RecognitionResult dbImageAnalysis = _computerVisionContext.RecognitionResult
                        .Include(x => x.Lines)
                            .ThenInclude(y => y.Words)
                    .SingleOrDefault(x => x.Id == (int)recognitionResultId);
                return dbImageAnalysis;
            }
            return null;
        }
        #endregion RecognitionResult

        #region Face
        public List<AzureFaceModels.DetectedFace> GetDetectFaces(Domain.ImageFile imageFile)
        {
                List<AzureFaceModels.DetectedFace> result = null;
            ImageFile dbImageFile = _computerVisionContext.ImageFile.SingleOrDefault(x => x.HashString == imageFile.HashString);
            if (dbImageFile != null)
            {
                List<DetectedFace> dbDetectedFaces = GetDetectedFace(dbImageFile);
                if (dbDetectedFaces?.Count > 0)
                {
                    result = Mapper.Map<List<AzureFaceModels.DetectedFace>>(dbDetectedFaces);
                }

                return result;
            }

            return null;
        }

        private List<DetectedFace> GetDetectedFace(ImageFile dbImageFile)
        {
            List<DetectedFace> dbDetectedFaces = _computerVisionContext.DetectedFace
                   .Include(x => x.FaceAttributes)
                   .Include(x => x.FaceLandmarks)
                   .Include(x => x.FaceRectangle)
               .Where(x => x.ImageFileId == dbImageFile.Id).ToList()               ;
            return dbDetectedFaces;
        }

        public void AddDetectFaces(Domain.ImageFile imageFile, List<AzureFaceModels.DetectedFace> detectedFaces)
        {
            ImageFile dbImageFile = _computerVisionContext.ImageFile.SingleOrDefault(x => x.HashString == imageFile.HashString);

            List<DetectedFace> dbDetectedFaces = Mapper.Map<List<DetectedFace>>(detectedFaces);
            dbDetectedFaces.ForEach(x => x.ImageFileId = dbImageFile.Id);
            _computerVisionContext.DetectedFace.AddRange(dbDetectedFaces);
            _computerVisionContext.SaveChanges();
            
        }
        #endregion Face
    }
}
