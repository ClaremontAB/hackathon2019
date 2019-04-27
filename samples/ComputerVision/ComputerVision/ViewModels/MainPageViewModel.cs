using ComputerVision.Domain;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ComputerVision
{
    public class MainPageViewModel : BaseViewModel
    {
        private CoreDispatcher _dispatcher;
        private readonly ILogger _logger;
        private readonly IFileService _fileService;
        private readonly IComputerVisionService _computerVisionService;

        private string _SelectedFolder = "";
        public string SelectedFolder
        {
            get { return this._SelectedFolder; }
            set
            {
                this._SelectedFolder = value;
                this.OnPropertyChanged();
            }
        }

        private bool _ProgressRing_ImagesIsActive = false;
        public bool ProgressRing_ImagesIsActive
        {
            get { return this._ProgressRing_ImagesIsActive; }
            set
            {
                this._ProgressRing_ImagesIsActive = value;
                this.OnPropertyChanged();
            }
        }

        

        private bool _ListView_ImageFilesSelectMany = false;
        public bool ListView_ImageFilesSelectMany
        {
            get { return this._ListView_ImageFilesSelectMany; }
            set
            {
                this._ListView_ImageFilesSelectMany = value;
                ListView_ImageFilesSelectionMode = value == true ? "Multiple" : "Single";
                this.OnPropertyChanged("ShowBatchProcess");
                this.OnPropertyChanged();
            }
        }

        private string _ListView_ImageFilesSelectionMode = "Single";
        public string ListView_ImageFilesSelectionMode
        {
            get { return this._ListView_ImageFilesSelectionMode; }
            set
            {
                this._ListView_ImageFilesSelectionMode = value;
                this.OnPropertyChanged();
            }
        }
        
        private List<ImageFile> _ImageFiles = new List<ImageFile>();
        public List<ImageFile> ImageFiles
        {
            get { return this._ImageFiles; }
            set
            {
                this._ImageFiles = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged("ImageFilesCount");
            }
        }

        public string ImageFilesCount
        {
            get
            {
                return this._ImageFiles.Count + " images in folder";
            }
        }

        private List<ImageFile> _SelectedImageFiles;
        public List<ImageFile> SelectedImageFiles
        {
            get { return this._SelectedImageFiles; }
            set
            {
                this._SelectedImageFiles = value;
                SelectedImageFilesChanged(value);
                this.OnPropertyChanged();
            }
        }



        private ImageFile _SelectedImageFile;
        public ImageFile SelectedImageFile
        {
            get { return this._SelectedImageFile; }
            set
            {
                this._SelectedImageFile = value;
                SelectedImageFileChanged(value);
                this.OnPropertyChanged();
            }
        }



        private ImageSource _SelectedImageSource;
        public ImageSource SelectedImageSource
        {
            get
            {
                return _SelectedImageSource;
            }
            set
            {
                if (_SelectedImageSource != value)
                {
                    _SelectedImageSource = value;
                    OnPropertyChanged();
                }
            }
        }



        private string _SelectedImageFileJson;
        public string SelectedImageFileJson
        {
            get { return this._SelectedImageFileJson; }
            set
            {
                this._SelectedImageFileJson = value;
                this.OnPropertyChanged();
            }
        }



        private string _SelectedJson;
        public string SelectedJson
        {
            get { return this._SelectedJson; }
            set
            {
                this._SelectedJson = value;
                this.OnPropertyChanged();
            }
        }


        public bool ShowBatchProcess
        {
            get {
                return ListView_ImageFilesSelectMany || ProgressRing_BatchProcessIsActive;
            }
        }

        private bool _ProgressRing_BatchProcessIsActive = false;
        public bool ProgressRing_BatchProcessIsActive
        {
            get { return this._ProgressRing_BatchProcessIsActive; }
            set
            {
                this._ProgressRing_BatchProcessIsActive = value;
                this.OnPropertyChanged();
            }
        }

        private bool _CancelBatchProcess = false;
        public bool CancelBatchProcess
        {
            get { return this._CancelBatchProcess; }
            set
            {
                this._CancelBatchProcess = value;
                this.OnPropertyChanged();
            }
        }

        private CancellationTokenSource _batchProcessCancellationTokenSource;

        private string _BatchProcessText;
        public string BatchProcessText
        {
            get { return this._BatchProcessText; }
            set
            {
                this._BatchProcessText = value;
                this.OnPropertyChanged();
            }
        }

        private string _StatusBarTex;
        public string StatusBarText
        {
            get { return this._StatusBarTex; }
            set
            {
                this._StatusBarTex = value;
                this.OnPropertyChanged();
            }
        }


        public MainPageViewModel(CoreDispatcher dispatcher, ILogger logger, IFileService fileService, IComputerVisionService computerVisionService)
        {
            this._logger = logger;
            this._dispatcher = dispatcher;
            this._fileService = fileService;
            this._computerVisionService = computerVisionService;
        }

        public async Task Init()
        {
            try
            {
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    ProgressRing_ImagesIsActive = true;
                });
                StorageFolder folder = await KnownFolders.PicturesLibrary.GetFolderAsync("CV");
                await SetSelctedFolder(folder);
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
            finally
            {
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    ProgressRing_ImagesIsActive = false;
                });
            }
        }



        public async Task ChooseFolder_Click()
        {
            StorageFolder folder = await _fileService.GetPickedFolder();
            await SetSelctedFolder(folder);
        }

        public async Task RefreshFolder_Click()
        {
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ProgressRing_ImagesIsActive = true;
            });

            StorageFolder folder = await _fileService.GetFolder(SelectedFolder);
            await SetSelctedFolder(folder);
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ProgressRing_ImagesIsActive = false;
            });
        }


        public async Task Analysis_Click()
        {
            ImageAnalysis analysis = await Task.Run(() => _computerVisionService.AnalyzeImageFile(SelectedImageFile));
            SelectedJson = JsonConvert.SerializeObject(analysis, Formatting.Indented);
        }

        public async Task RecognizeText_Click()
        {
            RecognitionResult recognitionResult = await Task.Run(() => _computerVisionService.RecognizeText(SelectedImageFile, TextRecognitionMode.Printed));
            SelectedJson = JsonConvert.SerializeObject(recognitionResult, Formatting.Indented);
        }

        public async Task RecognizeHandwrittenText_Click()
        {
            RecognitionResult recognitionResult = await Task.Run(() => _computerVisionService.RecognizeText(SelectedImageFile, TextRecognitionMode.Handwritten));
            SelectedJson = JsonConvert.SerializeObject(recognitionResult, Formatting.Indented);
        }

        public async Task DetectFaces_Click()
        {
            List<DetectedFace> detectedFaces = await Task.Run(() => _computerVisionService.DetectFaces(SelectedImageFile));
            SelectedJson = JsonConvert.SerializeObject(detectedFaces, Formatting.Indented);
        }

        public async Task VerifyFaces_Click()
        {
            if (SelectedImageFiles?.Count == 2)
            {
                VerifyResult verifyResult = await Task.Run(() => _computerVisionService.VerifyFaces(SelectedImageFiles[0], SelectedImageFiles[1]));
                SelectedJson = JsonConvert.SerializeObject(verifyResult, Formatting.Indented);
            }
        }

        public async Task BatchProcess_Click(List<ImageFile> imageFiles)
        {
            if (imageFiles?.Count > 0)
            {
                _batchProcessCancellationTokenSource = new CancellationTokenSource();
                await Task.Run(() => BatchProcess(imageFiles));
            }
            else if (ImageFiles?.Count > 0)
            {
                _batchProcessCancellationTokenSource = new CancellationTokenSource();
                await Task.Run(() => BatchProcess(ImageFiles));
            }
        }

        private async Task BatchProcess(List<ImageFile> imageFiles)
        {
            int fileIndex = 1;
            try
            {
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    ProgressRing_BatchProcessIsActive = true;
                });
                foreach (ImageFile imageFile in imageFiles)
                {
                    await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        BatchProcessText = $"Processing file {fileIndex}/{imageFiles.Count}";
                    });
                    await _computerVisionService.BatchProcess(imageFile);
                    if (CancelBatchProcess)
                    {
                        break;
                    }
                    fileIndex++;
                }

                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    BatchProcessText = CancelBatchProcess == false ?
                    $"Processed {imageFiles.Count} files." :
                    $"Batch process cancelled - Processed {fileIndex} files."; 
                });
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    BatchProcessText = $"Batch process failed - Processed {fileIndex} files.";
                });
            }
            finally
            {
                _batchProcessCancellationTokenSource = null;
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    ProgressRing_BatchProcessIsActive = false;
                });
            }
        }

        public void CancelBatchProcess_Click()
        {
            CancelBatchProcess = true;
        }

        private async Task SetSelctedFolder(StorageFolder folder)
        {
            if (folder != null)
            {
                List<ImageFile> imageFiles = await Task.Run(() => _fileService.GetImageFiles(folder));
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    SelectedFolder = folder.Path;
                    ImageFiles = imageFiles;
                });
            }
        }
        private async Task SelectedImageFileChanged(ImageFile imageFile)
        {
            SelectedImageFileJson = JsonConvert.SerializeObject(imageFile, Formatting.Indented);
            SelectedJson = null;
            await GetBitmapImage(imageFile);
        }

        private void SelectedImageFilesChanged(List<ImageFile> imageFiles)
        {
            if (imageFiles?.Count > 0)
            {
                SelectedImageFile = imageFiles[0];
            }
            else
            {
                SelectedImageFile = null;
            }
        }

        private async Task GetBitmapImage(ImageFile imageFile)
        {
            if (imageFile != null)
            {
                this.SelectedImageSource = await _fileService.GetBitmapImage(imageFile);
            }
            else
            {
                this.SelectedImageSource = null;
            }
        }
    }
}