using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NASA_BE;
using NASA_PL.Views;
using UserControl = System.Windows.Controls.UserControl;

namespace NASA_PL.UserControls
{
    /// <summary>
    /// Interaction logic for PlanetViewUC.xaml
    /// </summary>
    public partial class PlanetViewUC : UserControl
    {
        public PlanetViewUC()
        {
            InitializeComponent();
        }

        public System.Windows.Data.Binding AverageDistanceFromTheSun { get; set; }
        public System.Windows.Data.Binding Aphelion { get; set; }
        public System.Windows.Data.Binding Perihelion { get; set; }
        public System.Windows.Data.Binding Radius { get; set; }
        public System.Windows.Data.Binding Mass { get; set; }
        public System.Windows.Data.Binding AverageSurfaceTemp { get; set; }
        public System.Windows.Data.Binding OrbitalPeriod { get; set; }
        public System.Windows.Data.Binding AverageSpeed { get; set; }
        public System.Windows.Data.Binding RotationPeriod { get; set; }
        public System.Windows.Data.Binding MoonNumber { get; set; }
        public System.Windows.Data.Binding ImageURL { get; set; }
    }
}
