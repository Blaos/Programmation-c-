using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Sockets;
using System;
using System.Text;
using System.Net;
using System.IO;

namespace Application_SFL1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
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
            EnvoiTcpClient();
            // l'évènement est l'appel de la  fonction EnvoiTcpClient 
            try
            // Le try il essait de faire ce qui est demandé sinon il va dans le catch
            { 
                StreamReader oSR = new StreamReader(@"C:\Users\curtis.bordeau\Documents\GitHub\SN22_SFL1_2022\Développement\Aymeric (étudiant2)\MODULE ACQUISITION\module_aquisition\capteurs.JSON");
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
            }
        }

        public void EnvoiTcpClient()
        {
            string message = slValue.Value.ToString(); // message contiendra l'information du TextBox et en plus on choisi seulement d'envoyer le texte contenu dans le text box grâce au ".text", sans ce dernier on envoie tout le contenu du text box.
            TcpClient oclient = new TcpClient(); 
            // Création de l'objet client
            try
            { 
                oclient.Connect("127.0.0.1", 20); // Connexion NE PAS OUBLIER DE GERER LES ERREURS

                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message); // conversion en ASCII

                NetworkStream stream = oclient.GetStream();

                stream.Write(data, 0, data.Length);

                stream.Close(); 
                oclient.Close(); // on ferme le client
            }

            catch
            {
                MessageBox.Show("La connection n'a pas était établie", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        } 

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}


