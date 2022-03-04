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

namespace Application_SFL1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // La méthode InitializeComponent() (en vb.net et C#/net) est une méthode qui est créer/générée par le concepteur de Windows Forms
                                   // et il défini à peut près tout ce que tu vois/place/affiche sur ton formulaire. Chaque contrôles que tu ajouteras sur un formulaire et toutes les propriétés générerons un code, celui-ci sera traité dans la méthode InitializeComponent.
                                                                         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // je fais une conditions : si le clique chose reste enfoncé la fenetre bouge avec le curseur
            {
                DragMove();
            }
        }
    }
}