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

                // when property is changed, notify the view
                OnPropertyChanged(nameof(Apod));
                // also notify the view that the image has changed
                OnPropertyChanged(nameof(ImageUrl));
                // and the title
                OnPropertyChanged(nameof(Title));
                // and the explanation
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
        public string Title => Apod == null ? "" : Apod.Title;
        public string Explanation => Apod == null ? "" : Apod.Explanation;

        //public string ImageUrl => _apod.Url;
        //public string Title => _apod.Title;
        //public string Explanation => _apod.Explanation;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
