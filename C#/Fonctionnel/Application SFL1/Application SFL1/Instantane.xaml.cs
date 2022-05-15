using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.IO;

namespace Application_SFL1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    /// 
   
    public partial class Instantane : Window
    {
        public Instantane()
        {
            InitializeComponent();
        }

        private void Button_Accueil(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Button_Instantane(object sender, RoutedEventArgs e)
        {
            Instantane instantane = new Instantane();
            instantane.Show();
            this.Close();
        }

        private void Button_Création(object sender, RoutedEventArgs e)
        {
            Creation creation = new Creation();
            creation.Show();
            this.Close();
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

        private void Button_Arret(object sender, RoutedEventArgs e)
        {
            valeur_slider.Text = "0";
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // je fais une conditions : si le clique chose reste enfoncé la fenetre bouge avec le curseur
            {
                DragMove();
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // On créer un évènement lors du changement de valeur sur le slide 
        {
           
        }
     
    }

}