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

namespace WPF_Eolienne
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // je fais une conditions : si le clique au dessus et que je reste enfoncé la fenetre bouge avec le curseur
            {
                DragMove();
            }
        }

        private void Btn_Accueil(object sender, RoutedEventArgs e)
        {
            MainWindow omainWindow = new MainWindow();
            omainWindow.Show();
            this.Close();
        }

          private void Btn_Instantane (object sender, RoutedEventArgs e)    // On regle le btn nommé button_instantané pour qui ouvre la fenetre intantané "choisit" et on ferme la fenetre actuel
           {
               Instantane oinstantane = new Instantane();
               oinstantane.Show();
               this.Close();
           }

        private void Btn_Creation(object sender, RoutedEventArgs e)
        {
            Charger ocharger = new Charger();
            ocharger.Show();
            this.Close();
        }

        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            Close(); // Ferme la fenetre
        }

        private void Btn_Agrandir(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Normal)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Btn_Reduire (object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; // On agrandi la fenetre
        }


    }
}
