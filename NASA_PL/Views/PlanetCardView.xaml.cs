using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NASA_BE;

namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for PlanetCardView.xaml
    /// </summary>
    public partial class PlanetCardView : Window
    {
        public PlanetCardView(Planet planet)
        {
            InitializeComponent();
            DataContext=planet;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
