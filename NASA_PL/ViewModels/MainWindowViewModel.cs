using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NASA_PL.Models;
using NASA_PL.Views;

namespace NASA_PL.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainWindowViewModel
    {
        public PlanetsView PlanetsPage;
        public SearchView SearchPage;
        public NEOsView NEOsPage;
        public FireBaseImagesView FireBaseImagesPage;

        public ICommand CloseWindowCommand { get; private set; }
        public ICommand RestoreWindowCommand { get; private set; }
        public ICommand MinimizeWindowCommand { get; private set; }

        public ICommand OpenApodPageCommand { get; private set; }
        public ICommand OpenSearchPageCommand { get; private set; }
        public ICommand OpenFireBasePageCommand { get; private set; }
        public ICommand OpenPlanetsPageCommand { get; private set; }
        public ICommand OpenNeosPageCommand { get; private set; }

        public ICommand OpenInfoWindowCommand { get; private set; }

        private readonly MainWindowModel _model;

        public MainWindowViewModel()
        {
            PlanetsPage = new PlanetsView();
            SearchPage = new SearchView();
            NEOsPage = new NEOsView();
            FireBaseImagesPage = new FireBaseImagesView();

            _model = new MainWindowModel();
            CloseWindowCommand = new RelayCommand<Window>(window => window?.Close());
            RestoreWindowCommand = new RelayCommand<Window>(RestoreWindow);
            MinimizeWindowCommand = new RelayCommand<Window>(MinimizeWindow);

            OpenApodPageCommand = new RelayCommand<Frame>(frame =>
            {
                frame.Content = new APODView();
            }
            , frame => frame.Content is not APODView);

            OpenSearchPageCommand = new RelayCommand<Frame>(frame => frame.Content = SearchPage, frame => frame.Content is not SearchView);
            OpenFireBasePageCommand = new RelayCommand<Frame>(frame => frame.Content = FireBaseImagesPage, frame => frame.Content is not FireBaseImagesView);
            
            OpenPlanetsPageCommand = new RelayCommand<Frame>(frame => frame.Content = PlanetsPage, frame => frame.Content is not PlanetsView);
            OpenNeosPageCommand = new RelayCommand<Frame>(frame => frame.Content = NEOsPage, frame => frame.Content is not NEOsView);

            OpenInfoWindowCommand = new RelayCommand(() =>
            {
                var infoWindow = new InfoView();
                infoWindow.ShowDialog();
            });
        }
        
        private void MinimizeWindow(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }

        private void RestoreWindow(Window window)
        {
            switch (window.WindowState)
            {
                case WindowState.Maximized:
                    window.WindowState = WindowState.Normal;
                    break;
                case WindowState.Normal:
                    window.WindowState = WindowState.Maximized;
                    break;
            }
        }
    }
}
