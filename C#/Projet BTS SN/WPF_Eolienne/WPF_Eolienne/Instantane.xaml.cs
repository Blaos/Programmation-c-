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
using System.Net.Sockets;

namespace WPF_Eolienne
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Instantane : Window
    {
        public Instantane()
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

        private void Btn_Accueil (object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

          private void Btn_Instantane (object sender, RoutedEventArgs e)    // On regle le btn nommé button_instantané pour qui ouvre la fenetre intantané "choisit" et on ferme la fenetre actuel
           {
               Instantane instantane = new Instantane();
               instantane.Show();
               this.Close();
           }

        /*  private void Button_Creation(object sender, RoutedEventArgs e)
          {
              Creation creation = new Creation();
              creation.Show();
              this.Close();
          } */

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

        private void Btn_Reduire(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; // On agrandi la fenetre
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // On créer un évènement lors du changement de valeur sur le slide 
        {
            EnvoiTcpClient();
            // l'évènement est l'appel de la  fonction EnvoiTcpClient 
            /*   try
               // Le try il essait de faire ce qui est demandé sinon il va dans le catch
               {
                   StreamReader oSR = new StreamReader("Données.jb");
                   // @ evite de écrire le /
                   CapteurAcquisition oCapteurAcquisition = CapteurAcquisition.ToDeserializeCapteurAcquisition(oSR.ReadToEnd());
                   Vent.Content = oCapteurAcquisition.force_vent;
                   Puissance.Content = oCapteurAcquisition.puissance;
                   oSR.Close();
               }

               catch
               // Si n'a pas réussit un message apparaitra pour signaler l'errreur
               {
                   MessageBox.Show("Le fichier Json n'a pas pu être récuperé", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);
               } */
        }

        public void EnvoiTcpClient()
        {
            string message = slValue.Value.ToString(); // message contiendra l'information du TextBox et en plus on choisi seulement d'envoyer le texte contenu dans le text box grâce au ".text", sans ce dernier on envoie tout le contenu du text box.
            TcpClient oclient = new TcpClient();
            // Création de l'objet client
            try
            {
                oclient.Connect("127.0.0.1", 23); // Connexion NE PAS OUBLIER DE GERER LES ERREURS

                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message); // conversion en ASCII

                NetworkStream stream = oclient.GetStream();

                stream.Write(data, 0, data.Length);

                stream.Close();
                oclient.Close();

            }

            catch
            {
                MessageBox.Show("La connection n'a pas était établie", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

    }
}
