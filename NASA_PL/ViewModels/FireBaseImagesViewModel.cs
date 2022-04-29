using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using NASA_BE.Annotations;
using NASA_PL.Models;
using NASA_PL.Views;

namespace NASA_PL.ViewModels
{
    public class FireBaseImagesViewModel : INotifyPropertyChanged
    {
        private readonly FireBaseImagesModel _model;
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, string> _resultsDictionary;
        public Dictionary<string, string> ResultsDictionary
        {
            get => _resultsDictionary;
            set
            {
                _resultsDictionary = value;
                OnPropertyChanged(nameof(ResultsDictionary));
            }
        }

        private Visibility _showList;
        public Visibility ShowList
        {
            get => _showList;
            set
            {
                _showList = value;
                OnPropertyChanged(nameof(ShowList));
            }
        }

        public IAsyncRelayCommand UpdateCommand { get; set; }

        public FireBaseImagesViewModel()
        {
            _model = new FireBaseImagesModel();
            ResultsDictionary = null;


            UpdateCommand = new AsyncRelayCommand(async () =>
            {
                ShowList = Visibility.Collapsed;
                ResultsDictionary = new Dictionary<string, string>();
                ResultsDictionary = await Task.Run(() => GetImagesFromFirebase());
                ShowList = Visibility.Visible;
            });
        }
        public async Task<Dictionary<string, string>> GetImagesFromFirebase()
        {
            var result =  _model.GetImagesFromFirebase();

            var imagesDict = new Dictionary<string, string>();
            
            // if no images were found or no image matched the required confidence
            if (result.Count == 0)
            {
                imagesDict.Add(
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6e/NASA_Wormball_logo.svg/768px-NASA_Wormball_logo.svg.png",
                    "");

            }
            else
            {
                foreach (var image in result)
                {
                    imagesDict.Add(image.Url, image.Description);
                }
            }

            return imagesDict;
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
