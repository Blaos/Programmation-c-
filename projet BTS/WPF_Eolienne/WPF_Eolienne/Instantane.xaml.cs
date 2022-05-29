using System;
using System.Windows;
using System.Windows.Input;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WPF_Eolienne
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Instantane : Window
    {
        public double forceVent;
        public double puissance;

        TcpClient oclient = new TcpClient(); // permet de l'avoir pour tous le client qui envoie
        NetworkStream stream;

        public Instantane()
        {
            InitializeComponent();
            oclient.Connect("127.0.0.1", 53); // Connexion 

            forceVent = 0;
            puissance = 0;

        }

        public async Task ClientCommande()
        {
            string message = slValue.Value.ToString(); // message contiendra l'information du TextBox et en plus on choisi seulement d'envoyer le texte contenu dans le text box grâce au ".text", sans ce dernier on envoie tout le contenu du text box.
            // Création de l'objet client
            try
            {   Byte[] data = System.Text.Encoding.ASCII.GetBytes(message); // conversion en ASCII

                stream = oclient.GetStream();
                stream.Write(data, 0, data.Length);

                await ClientAcquisition("127.0.0.1", "L'application est connecte");

                Vent.Content = "force du vent: " + forceVent;
                Puissance.Content = "puissance: " + puissance;
            }

            catch
            {
                MessageBox.Show("La connexion n'a pas était établie", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        public async Task ClientAcquisition(String server, string message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 53;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes); 
                // exemple de trame reçue: {"Vent":26.76,"puissance":4.24}

                string[] subs = responseData.Split(','); // on sépare la trame en 2 par la virgule ','.
                string forceVentSubs = subs[0];     // {"Vent":26.76
                string puissanceSubs = subs[1];     // "puissance":0}
                string[] ventSubs = forceVentSubs.Split(':');  //26.76
                string[] puiSubs = puissanceSubs.Split(':');   // 4.24

                forceVent = Convert.ToDouble(ventSubs[1].Replace(".", ","));  //26,76 type double, convertion de type string a type double .=,
                puissance = Convert.ToDouble(puiSubs[1].Replace(".", ",").Replace("}", "")); // 4,24 convertion de type string a type double .=,

                // Close everything.
                stream.Close();
                client.Close();
            }
            catch 
            {
                MessageBox.Show("La connexion n'a pas était établie", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }         
         
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // je fais une conditions : si le clique au dessus et que je reste enfoncé la fenetre bouge avec le curseur
            {
                DragMove();
            }
        }


        private void Close_Connexion()
        {
            stream.Close();
            oclient.Close();
        }

        private void Btn_Accueil(object sender, RoutedEventArgs e)
        {
            Close_Connexion();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Btn_Instantane(object sender, RoutedEventArgs e)    // On regle le btn nommé button_instantané pour qui ouvre la fenetre intantané "choisit" et on ferme la fenetre actuel
        {
            Close_Connexion();
            Instantane instantane = new Instantane();
            instantane.Show();
            this.Close();
        }

        private void Btn_Creation(object sender, RoutedEventArgs e)
        {
            Close_Connexion();
            Creation ocreation = new Creation();
            ocreation.Show();
            this.Close();
        }

        private void Btn_Charger(object sender, RoutedEventArgs e)
        {
            Close_Connexion();
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

        private void Btn_Reduire(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; // On agrandi la fenetre
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // On créer un évènement lors du changement de valeur sur le slide 
        {
            ClientCommande();
        }       

        private void Button_Arret(object sender, RoutedEventArgs e)
        {
            valeur_slider.Text = "0";
        }

        private void valeur_slider_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}