using NASA_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NASA_BL;

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
            BL myBl = new BL();
            var imageOfTheDay = Task.Run(() => myBl.GetAPOD()).Result;
            //var results = Task.Run(() => myBl.GetImageTagsFromImagga("https://upload.wikimedia.org/wikipedia/commons/c/cb/The_Blue_Marble_%28remastered%29.jpg")).Result;
            var sr = myBl.GetSearchResult("earth");
            var result = Task.Run(() => myBl.GetNearEarthObject("2022-03-01", "2022-02-25")).Result;


            int y = 4;



        }
    }
}
