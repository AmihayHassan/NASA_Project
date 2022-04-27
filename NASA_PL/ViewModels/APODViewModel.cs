using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Xaml.Behaviors.Core;
using NASA_BE;
using NASA_BE.Annotations;
using NASA_PL.Models;

namespace NASA_PL.ViewModels
{
    public class APODViewModel : INotifyPropertyChanged
    {
        private APOD _apod;
        public APOD Apod
        {
            get => _apod;
            set
            {
                _apod = value;
                OnPropertyChanged(nameof(Apod));
                OnPropertyChanged(nameof(ImageUrl));
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(Explanation));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public APODViewModel()
        {
            Task.Run(InitViewModel);
        }

        private async Task InitViewModel()
        {
            var model = new APODModel();
            Apod = await model.GetImageOfTheDay();
        }

        public string ImageUrl => Apod == null ? "" : Apod.Url;
        public string Title => Apod == null ? "loading image" : Apod.Title;
        public string Explanation => Apod == null ? "" : Apod.Explanation;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
