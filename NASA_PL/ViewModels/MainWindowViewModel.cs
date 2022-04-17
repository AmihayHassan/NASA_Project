using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using NASA_BE;
using NASA_PL.Models;


//TODO - create this class
//
//
namespace NASA_PL.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainWindowViewModel
    {
        MainWindowModel model;
        public MainWindowViewModel()
        {
            model = new MainWindowModel();
        }

        #region sidebar commands



        #endregion
    }
}
