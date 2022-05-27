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
using MySql.Data.MySqlClient;

namespace WPF_Eolienne
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Periode_Scenario : Window
    {
        private MySqlConnection conn;
        private int idScenario;
        private string nomScenario;

        public Periode_Scenario (int iIdScenario, string sNomScenario)
        {
            idScenario = iIdScenario;
            nomScenario = sNomScenario;

            InitializeComponent();

            string myConnectionString = "server=127.0.0.1;"

                                              + "uid=root;"
                                              + "pwd=;"
                                              + "database=eoliennedb;"
                                              + "Charset=latin1;";

            conn = new MySqlConnection(myConnectionString);

            SetListePeriode();
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

        private void Btn_Instantane(object sender, RoutedEventArgs e)    // On regle le btn nommé button_instantané pour qui ouvre la fenetre intantané "choisit" et on ferme la fenetre actuel
        {
            Instantane oinstantane = new Instantane();
            oinstantane.Show();
            this.Close();
        }

        private void Btn_Creation(object sender, RoutedEventArgs e)
        {
            Creation ocreation = new Creation();
            ocreation.Show();
            this.Close();
        }

        private void Btn_Charger(object sender, RoutedEventArgs e)
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

        private void Btn_Reduire(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; // On agrandi la fenetre
        }    


        private void SetListePeriode()
        {
            string sql = $"SELECT * FROM  periode where scenario_id = {idScenario}";

            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            listPeriodes.Items.Clear();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    int idPeriode = Int32.Parse(rdr["id"].ToString());
                    string duree = rdr["duree"].ToString();
                    string puissance = rdr["puissance_soufflerie"].ToString();

                    listPeriodes.Items.Add(new ListBoxItemPeriode(idPeriode, duree, puissance, this));
                }
            }
            conn.Close();
        }

        public void supprimerPeriode(int id)
        {
            string sql = $"DELETE FROM periode WHERE id = {id}";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            SetListePeriode();

        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            int duree = Int32.Parse(txtDuree.Text);
            int puissance = Int32.Parse(txtPuissance.Text);


            string sql = $"INSERT INTO periode (duree, puissance_soufflerie, scenario_id) VALUES ({duree}, {puissance}, {idScenario})";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            SetListePeriode();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            nomScenario = txtNomScenario.Text;
            string sql = $"UPDATE scenario SET nom = '{nomScenario}' WHERE id = {idScenario}";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }



    }

    public class ListBoxItemPeriode : ListBoxItem
    {
        private Periode_Scenario PeriodeScenario;
        private StackPanel sp;
        private Label txtDuree;
        private Label txtPuissance;
        private Button btnSuppr;
        private int idPeriode;

        public ListBoxItemPeriode(int idPeriode, string duree, string puissance, Periode_Scenario PeriodeScenario)
        {
            this.PeriodeScenario = PeriodeScenario;
            this.idPeriode = idPeriode;

            sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            txtDuree = new Label();
            txtPuissance = new Label();
            btnSuppr = new Button();

            btnSuppr.Click += BtnSupprimer_Click;


            txtDuree.Content = duree.ToString() + " secondes";
            txtPuissance.Content = puissance.ToString() + "%";
            btnSuppr.Content = "Suppr.";

            sp.Children.Add(txtDuree);
            sp.Children.Add(txtPuissance);
            sp.Children.Add(btnSuppr);

            this.AddChild(sp);
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer cette période ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                PeriodeScenario.supprimerPeriode(idPeriode);
            }
        }
    }
}
