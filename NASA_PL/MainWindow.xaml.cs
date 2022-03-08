using NASA_DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NASA_PL
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
            var db = myBl.GetSolarSystem();
            var imageOfTheDay = Task.Run(() => myBl.GetAPOD()).Result;
            var sr = Task.Run(async () => await myBl.GetSearchResult("neptune")).Result;
            int y = 4;

            Console.ReadKey();
            Trace.WriteLine("finished");
        }
    }
}
