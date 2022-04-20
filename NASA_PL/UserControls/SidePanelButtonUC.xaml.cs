using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
using CommunityToolkit.Mvvm.ComponentModel;
using MaterialDesignThemes.Wpf;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;

namespace NASA_PL.UserControls
{
    /// <summary>
    /// Interaction logic for SidePanelButtonUC.xaml
    /// </summary>
    [INotifyPropertyChanged]
    public partial class SidePanelButtonUC : UserControl
    {
        public string TextBlockText { get; set; }
        public string TextBlockMargin { get; set; }
        public string PackIconMargin { get; set; }
        public string PackIconKind { get; set; }
        public string Tooltip { get; set; }

        public SidePanelButtonUC()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
