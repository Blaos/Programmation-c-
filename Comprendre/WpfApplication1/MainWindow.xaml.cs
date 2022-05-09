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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<PeriodeItem> olPeriodsList = new List<PeriodeItem>();
            olPeriodsList.Add(new PeriodeItem() { Duree = "10 secondes", Puissance = "2%" });
            olPeriodsList.Add(new PeriodeItem() { Duree = "20 secondes", Puissance = "3%" });
            olPeriodsList.Add(new PeriodeItem() { Duree = "30 secondes", Puissance = "4%" });

            PeriodsList.ItemsSource = olPeriodsList;
        }

        public class PeriodeItem
        {
            public string Duree { get; set; }
            public string Puissance { get; set; }
        }
    }
}
