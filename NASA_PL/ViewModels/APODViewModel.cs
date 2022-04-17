using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Xaml.Behaviors.Core;
using NASA_BE;
using NASA_PL.Models;

namespace NASA_PL.ViewModels
{
    internal class APODViewModel
    {
        private APOD _apod;
        public APODViewModel()
        {
            Task.Run(InitViewModel).GetAwaiter().GetResult();
        }

        private async Task InitViewModel()
        {
            var model = new APODModel();
            _apod = await model.GetImageOfTheDay();
        }

        public string ImageUrl => _apod.Url;
        public string Title => _apod.Title;
        public string Explanation => _apod.Explanation;
    }
}
