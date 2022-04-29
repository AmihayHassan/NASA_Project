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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NASA_PL.ViewModels;

namespace NASA_PL.Views
{
    /// <summary>
    /// Interaction logic for FireBaseImagesView.xaml
    /// </summary>
    public partial class FireBaseImagesView : Page
    {
        public FireBaseImagesView()
        {
            InitializeComponent();
            var ViewModel = new FireBaseImagesViewModel();
            DataContext = ViewModel;
        }
    }
}
