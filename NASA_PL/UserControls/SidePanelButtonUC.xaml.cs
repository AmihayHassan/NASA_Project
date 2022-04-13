using System;
using System.Collections.Generic;
using System.Globalization;
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
using MaterialDesignThemes.Wpf;
using NASA_PL.Converters;

namespace NASA_PL.UserControls
{
    /// <summary>
    /// Interaction logic for SidePanelButtonUC.xaml
    /// </summary>
    public partial class SidePanelButtonUC : UserControl
    {
        public string TextBlockName { get; set; }
        public string TextBlockText { get; set; }
        public Thickness TextBlockMargin { get; set; }
        public Thickness PackIconMargin { get; set; }
        public string PackIconKind { get; set; }
        public string Tooltip { get; set; }
        public SidePanelButtonUC()
        {
            InitializeComponent();
        }
    }
}
