using System;
using System.Collections.Generic;
using System.Text;
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
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            // La méthode InitializeComponent() (en vb.net et C#/net) est une méthode qui est créer/générée par le concepteur de Windows Forms
            // et il défini à peut près tout ce que tu vois/place/affiche sur ton formulaire. Chaque contrôles que tu ajouteras sur un formulaire et toutes les propriétés générerons un code, celui-ci sera traité dans la méthode InitializeComponent.
            InitializeComponent();
        }

        private void Button_Instantane(object sender, RoutedEventArgs e)    // On regle le btn nommé button_instantané pour qui ouvre la fenetre intantané "choisit" et on ferme la fenetre actuel
        {
            Structure ostructure = new Structure();
            ostructure.Show();
            this.Close();
        }

        private void Button_Accueil(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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

        private void Button_Pleine_Ecran (object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized; // On agrandi la fenetre
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // je fais une conditions : si le clique au dessus et que je reste enfoncé la fenetre bouge avec le curseur
            {
                DragMove();
            }
        }
    }
}