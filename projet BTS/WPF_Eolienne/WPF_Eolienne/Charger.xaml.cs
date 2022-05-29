using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WPF_Eolienne
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Charger : Window
    {
        private MySqlConnection conn;
        private TcpClient oclient = new TcpClient();
        private NetworkStream stream;

        public Charger()
        {
            InitializeComponent();
            try
            {
                oclient.Connect("127.0.0.1", 53); // Connexion 
                string myConnectionString = "server=127.0.0.1;"

                                                  + "uid=root;"
                                                  + "pwd=;"
                                                  + "database=eoliennedb;"
                                                  + "Charset=latin1;";

                conn = new MySqlConnection(myConnectionString);
                MAJListePhases();
            }           
            catch
            {
                MessageBox.Show("La connexion n'a pu être établie", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
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
            closeConnexion();
            MainWindow omainWindow = new MainWindow();
            omainWindow.Show(); ;
            this.Close();
        }

        private void Btn_Instantane(object sender, RoutedEventArgs e)    // On regle le btn nommé button_instantané pour qui ouvre la fenetre intantané "choisit" et on ferme la fenetre actuel
        {
            closeConnexion();
            Instantane oinstantane = new Instantane();
            oinstantane.Show();
            this.Close();
        }

        private void Btn_Creation(object sender, RoutedEventArgs e)
        {
            closeConnexion();
            Creation ocreation = new Creation();
            ocreation.Show();          
            this.Close();
        }

        private void Btn_Charger(object sender, RoutedEventArgs e)
        {
            closeConnexion();
            Charger ocharger = new Charger();
            ocharger.Show();
            this.Close();
        }

        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            closeConnexion();
            stream.Close();
            oclient.Close();
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


        private void MAJListePhases()
        {
            try
            {
                string sql = "SELECT * FROM scenario ";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                listScenario.Items.Clear();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        int idScenario = Int32.Parse(rdr["id"].ToString());
                        string nom = rdr["nom"].ToString();
                        string date = rdr["date_creation"].ToString();

                        listScenario.Items.Add(new ListBoxItemScenario(idScenario, nom, date, this));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Problème avec la base de données : la table 'scenario' n'est pas accessible ", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            conn.Close();
        }

        public void supprimerScenario(int id)
        {
            try
            {
                string sql = "DELETE FROM `scenario` WHERE `id` = " + id;

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MAJListePhases();
            }
            catch
            {
                MessageBox.Show("Problème avec la base de données : le 'scenario' n'à pas pu être supprimé", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void txtPuissance_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous finaliser votre résultat ?", "Confirmer", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

            }
        }

        public async Task ClientCommande(string puissance_soufflerie,int sec)
        {
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(puissance_soufflerie); // conversion en ASCII
                stream = oclient.GetStream();
                stream.Write(data, 0, data.Length);
                await Task.Delay(1000 * sec);
            }

            catch
            {
                MessageBox.Show("La connexion n'a pas était établie", string.Empty, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


        public async Task lancerScenario(int idScenario) // méthode qui lance le scénario
        {

            string sql = $"SELECT * FROM  periode where scenario_id = {idScenario}"; // requete sql pour recuperer les periodes du scénario
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    int idPeriode = Int32.Parse(rdr["id"].ToString()); //convertion
                    int duree = Int32.Parse(rdr["duree"].ToString());  //convertion
                    string puissance = rdr["puissance_soufflerie"].ToString();  //convertion

                    await ClientCommande(puissance, duree);
                }
                MessageBoxResult result = MessageBox.Show("Votre scénario est fini! Veuillez consulter le site web pour avoir les résultats", "Lancer", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            conn.Close();          

        }

        public void closeConnexion() // méthode qui ferme la connexion Tcp Socket
        {        
            stream.Close(); // faire un if si est pas connecté 
            oclient.Close();
            
        }

        private void listScenario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class ListBoxItemScenario : ListBoxItem
    {
        private Charger charger;
        private StackPanel sp;
        private Label txtnom;
        private Label txtdate;
        private Button btnSuppr;
        private Button btnEdit;
        private Button btnLancer;
        private int idScenario;
        private string nomScenario;
        
        public ListBoxItemScenario(int idScenario, string nomScenario, string date, Charger charger)
        {
            this.charger = charger;
            this.idScenario = idScenario;
            this.nomScenario = nomScenario;

            sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            txtnom = new Label();
            txtdate = new Label();
            btnSuppr = new Button();
            btnEdit = new Button();
            btnLancer = new Button();

            btnSuppr.Click += BtnSupprimer_Click;
            btnEdit.Click += BtnEdit_Click;
            btnLancer.Click += BtnLancer_Click;

            txtnom.Content = nomScenario;
            txtdate.Content = date;
            btnSuppr.Content = "Suppr.";
            btnEdit.Content = "Edit";
            btnLancer.Content = "Lancer";

            sp.Children.Add(txtnom);
            sp.Children.Add(txtdate);
            sp.Children.Add(btnSuppr);
            sp.Children.Add(btnEdit);
            sp.Children.Add(btnLancer);

            this.AddChild(sp);
        }


        private void BtnLancer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous lancer ce scenario ?", "Lancer", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                charger.lancerScenario(idScenario);
            }
        }


        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer cette phase ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                charger.supprimerScenario(idScenario);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Periode_Scenario operiode_scenario = new Periode_Scenario(idScenario, nomScenario);
            operiode_scenario.Show();
            charger.closeConnexion();
            charger.Close();
        }

    }
}