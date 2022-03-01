using NASA_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace NASA_PL.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Dal my_dal = new Dal();
            //var imageOfTheDay = Task.Run(() => my_dal.GetApodFromNasaApi()).Result;
            //var results = Task.Run(() => my_dal.GetImageTagsFromImagga("https://upload.wikimedia.org/wikipedia/commons/c/cb/The_Blue_Marble_%28remastered%29.jpg")).Result;
            //var sr = Task.Run(() => my_dal.GetSearchResult("earth")).Result;

            var Neos = Task.Run(() => my_dal.GetNearEarthObject("2022-02-28", "2022-03-01")).Result;

            int y = 4;

            //Task.Run((() => my_dal.UploadToFbTask(
            //    @"C:\Users\amiha\OneDrive\שולחן העבודה\לימודים\שנה ד\סמסטר א\הנדסת מערכות חלונות\planets\neptune.jpg",
            //    @"nasa-wpf-ronke-amiha-2022.appspot.com",
            //    @"neptune.jpg"
            //)));

        }
    }
}
