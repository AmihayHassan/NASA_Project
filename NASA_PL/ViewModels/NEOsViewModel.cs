using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NASA_BE;
using NASA_BE.Annotations;
using NASA_PL.Commands;
using NASA_PL.Models;

namespace NASA_PL.ViewModels
{
    [ObservableObject]
    public class NEOsViewModel : INotifyPropertyChanged
    {
        public ICommand Filter { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly NEOsModel _model;

        public NEOsViewModel()
        {
            _model = new NEOsModel();
            Filter = new FilterCommand(this);
        }

        [ObservableProperty]
        ObservableCollection<NearEarthObject> nearEarthObj;
        public ObservableCollection<NearEarthObject> NearEarthObj
        {
            get => nearEarthObj;
            set
            {
                nearEarthObj = value;
                OnPropertyChanged(nameof(NearEarthObj));
            }
        }


        public async Task SearchNeo(string start, string end, double diameter, bool hazardous)
        {
            NearEarthObj = await _model.GetNearEarthObject(start, end, diameter);
            HazardOnly(hazardous);
        }

        public void HazardOnly(bool hazardous = false)
        {
            if (_model.neoList == null)
            {
                return;
            }
            //NearEarthObj = hazardous ? _model.neoList.Where(neo => neo.Hazardous).ToList() : _model.neoList.ToList();
            NearEarthObj = new ObservableCollection<NearEarthObject>(hazardous ?
                    _model.neoList.Where(neo => neo.Hazardous).ToList()
                    :
                    _model.neoList.ToList());
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

