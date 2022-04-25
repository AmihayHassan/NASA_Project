using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private string _start;
        private string _end;
        private int _diameter = 0;
        private bool _hazardous = false;

        public ICommand Filter { get; set; }
        public ICommand UpdateStartDateCommand { get; set; }
        public ICommand UpdateEndDateCommand { get; set; }
        public ICommand UpdateDiameterCommand { get; set; }
        public ICommand UpdateIsHazardousCommand { get; set; }

        public IAsyncRelayCommand SearchNeosCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly NEOsModel _model;

        public NEOsViewModel()
        {
            _model = new NEOsModel();
            Filter = new FilterCommand(this);

            UpdateStartDateCommand = new RelayCommand<DatePicker>(picker =>
            {
                _start = DateTime.Parse(picker.Text).ToString("yyyy-MM-dd");
            });

            UpdateEndDateCommand = new RelayCommand<DatePicker>(picker =>
            {
                _end = DateTime.Parse(picker.Text).ToString("yyyy-MM-dd");
            });

            UpdateDiameterCommand = new RelayCommand<TextBox>(textBox =>
            {
                if (textBox.Text != string.Empty)
                {
                    int.TryParse(textBox.Text, out _diameter);
                }
            }, textBox => textBox.Text != string.Empty);

            UpdateIsHazardousCommand = new RelayCommand<ToggleButton>(toggle =>
            {
                if (toggle.IsChecked != null)
                {
                    _hazardous = toggle.IsChecked.Value;
                }
            });


            SearchNeosCommand = new AsyncRelayCommand(async () =>
            {
                await Task.Run(() => SearchNeo(_start, _end, _diameter, _hazardous));
            }, _start != string.Empty && _end != string.Empty);
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

