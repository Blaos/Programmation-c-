using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.Sockets;
using System;
using System.Text;
using System.Net;
using System.IO;

namespace Application_SFL1
{
    /// <summary>
    /// Logique d'interaction pour Création.xaml
    /// </summary>
    public partial class Creation : Window
    {
        public Creation()
        {
            InitializeComponent();
        }
 

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // je fais une conditions : si le clique chose reste enfoncé la fenetre bouge avec le curseur
            {
                DragMove();
            }
        }

        private void Button_Accueil(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Instantane(object send, RoutedEventArgs e)
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

        private void Button_Reduit_Ecran(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Pliene_Ecran(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Fenetre_Reduit(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Ecran_Plein(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}
