using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NASA_BE;
using NASA_PL.Commands;
using NASA_PL.Models;

namespace NASA_PL.ViewModels
{
    class NEOsViewModel : INotifyPropertyChanged
    {
        

        public ICommand Filter { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        NEOsModel model = new NEOsModel();
        public NEOsViewModel()
        {
            Filter = new FilterCommand(this);
        }

        private List<NearEarthObject> nearEarthObj;
        public List<NearEarthObject> NearEarthObj
        {
            get
            {
                return nearEarthObj;
            }
            set
            {
                nearEarthObj = value;
                OnPropertyChanged("NearEarthObj");
            }
        }
        public async void SearcNEO(string start, string end, double diameter, bool hazardous)
        {
            NearEarthObj = await model.GetNearEarthObject(start, end, diameter);
            Hazardonly(hazardous);
        }
        public void Hazardonly(bool b = false)
        {

            if (model.neoList != null)
            {

                if (b)
                {
                    NearEarthObj = model.neoList.Where(X => X.Hazardous == true).ToList();
                }
                else
                {

                    NearEarthObj = model.neoList.ToList();
                }
            }

        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

