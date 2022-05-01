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

        private void btn_accueil(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /*  private void Button_Instantane(object sender, RoutedEventArgs e)    // On regle le btn nommé button_instantané pour qui ouvre la fenetre intantané "choisit" et on ferme la fenetre actuel
           {
               Instantane instantane = new Instantane();
               instantane.Show();
               this.Close();
           }




           private void Button_Creation(object sender, RoutedEventArgs e)
           {
               Creation creation = new Creation();
               creation.Show();
               this.Close();
           }

           private void Button_Close(object sender, RoutedEventArgs e)
           {
               Close(); // Ferme la fenetre
           }

           private void Button_Réduit_Fenetre(object sender, RoutedEventArgs e)
           {
               this.WindowState = WindowState.Minimized; // on réduit la fenetre
           }

           private void Button_Pleine_Ecran(object sender, RoutedEventArgs e)
           {
               this.WindowState = WindowState.Maximized; // On agrandi la fenetre
           }
        */

    }
}
