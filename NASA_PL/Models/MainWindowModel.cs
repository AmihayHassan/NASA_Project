using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using NASA_BL;

//TODO - create this class

namespace NASA_PL.Models
{
    public partial class MainWindowModel : ObservableObject
    {
        BL bl;

        [ObservableProperty]
        public bool Hidden;

        public MainWindowModel()
        {
            bl = new BL();
        }
    }
}
