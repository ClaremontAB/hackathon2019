using ComputerVision.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ComputerVision.Data2;
using Microsoft.EntityFrameworkCore;
using ComputerVision.Domain;


namespace ComputerVision
{
    public sealed partial class MainPage : Page
    {
        //https://docs.microsoft.com/en-us/windows/uwp/data-binding/
        public readonly MainPageViewModel MainPageViewModel;
        private readonly ILogger _logger;

        public MainPage()
        {
            try
            {
                ComputerVisionRepository computerVisionRepository = new ComputerVisionRepository();
                BlobStorageRepository blobStorageRepository = new BlobStorageRepository();
                IAnalysisService analysisService = new AnalysisService(computerVisionRepository);
                IFileService fileService = new FileService();
                _logger = new ConsoleLogger();
                IComputerVisionService computerVisionService = new ComputerVisionService(
                    fileService,
                    analysisService,
                    computerVisionRepository,
                    blobStorageRepository);

                this.InitializeComponent();
                this.MainPageViewModel = new MainPageViewModel(Dispatcher, _logger, fileService, computerVisionService);

                Task.Run(() => MainPageViewModel.Init());

                //MainPageViewModel.Init();
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

        private async void Button_RefreshFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await Task.Run(() => MainPageViewModel.RefreshFolder_Click());

                //await MainPageViewModel.RefreshFolder_Click();
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

        private async void Button_ChooseFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainPageViewModel.ChooseFolder_Click();
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

        private async void Button_Analysis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainPageViewModel.Analysis_Click();
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

        private async void Button_BatchProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Domain.ImageFile> imageFiles = GetSelectedImageFiles();
                await MainPageViewModel.BatchProcess_Click(imageFiles);
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

        private void Button_CancelBatchProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainPageViewModel.CancelBatchProcess_Click();
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

        private async void Button_RecognizeText_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainPageViewModel.RecognizeText_Click();
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

        private async void Button_RecognizeHandwrittenText_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainPageViewModel.RecognizeHandwrittenText_Click();
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

        private async void Button_DetectFaces_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainPageViewModel.DetectFaces_Click();
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

        private async void Button_VerifyFaces_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainPageViewModel.VerifyFaces_Click();
            }
            catch (Exception ex)
            {
                _logger.LogEx(ex);
            }
        }

       

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Domain.ImageFile> imageFiles = GetSelectedImageFiles();
            MainPageViewModel.SelectedImageFiles = imageFiles;
            if (e.AddedItems?.Count > 0)
            {
                MainPageViewModel.SelectedImageFile = e.AddedItems[0] as Domain.ImageFile;
            }
        }

        private List<Domain.ImageFile> GetSelectedImageFiles()
        {
            if (ListView_ImageFiles.SelectedItems?.Count > 0)
            {
                List<Domain.ImageFile> result = new List<Domain.ImageFile>();
                foreach (Domain.ImageFile item in ListView_ImageFiles.SelectedItems)
                {
                    result.Add(item);
                }
                return result;
            }
            else
            {
                return null;
            }

        }

       

       
    }
}
