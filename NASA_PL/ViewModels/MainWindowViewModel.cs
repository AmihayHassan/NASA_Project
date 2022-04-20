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
        public ICommand CloseWindowCommand { get; private set; }
        public ICommand RestoreWindowCommand { get; private set; }
        public ICommand MinimizeWindowCommand { get; private set; }

        public ICommand OpenApodPageCommand { get; private set; }
        public ICommand OpenSearchPageCommand { get; private set; }
        public ICommand OpenPlanetsPageCommand { get; private set; }
        public ICommand OpenNeosPageCommand { get; private set; }

        public ICommand OpenInfoWindowCommand { get; private set; }

        private readonly MainWindowModel _model;

        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
            CloseWindowCommand = new RelayCommand<Window>(CloseWindow);
            RestoreWindowCommand = new RelayCommand<Window>(RestoreWindow);
            MinimizeWindowCommand = new RelayCommand<Window>(MinimizeWindow);

            OpenApodPageCommand = new RelayCommand<Frame>(OpenApodPage, frame => !(frame.Content is APODView));
            OpenSearchPageCommand = new RelayCommand<Frame>(OpenSearchPage, frame => !(frame.Content is SearchView));
            OpenPlanetsPageCommand = new RelayCommand<Frame>(OpenPlanetsPage, frame => !(frame.Content is PlanetsView));
            OpenNeosPageCommand = new RelayCommand<Frame>(OpenNeosPage, frame => !(frame.Content is NEOsView));

            OpenInfoWindowCommand = new RelayCommand(() =>
            {
                var infoWindow = new InfoView();
                infoWindow.ShowDialog();
            });
        }



        private void CloseWindow(Window window)
        {
            window?.Close();
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

        private void OpenApodPage(Frame frame)
        {
            frame.Content = new APODView();
        }

        private void OpenSearchPage(Frame frame)
        {
            frame.Content = new SearchView();
        }

        private void OpenPlanetsPage(Frame frame)
        {
            frame.Content = new PlanetsView();
        }

        private void OpenNeosPage(Frame frame)
        {
            frame.Content = new NEOsView();
        }
    }
}
