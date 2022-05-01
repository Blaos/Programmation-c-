using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace WpfScenariosEolienne
{
    /// <summary>
    /// Logique d'interaction pour Periode_scenario.xaml
    /// </summary>
    public partial class Periode_scenario : Window
    {
        private MySqlConnection conn;
        private int idScenario;
        private string nomScenario;

        public Periode_scenario(int iIdScenario, string sNomScenario)
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

            SetNomScenario();

            SetListePeriode();
        }

        private void SetNomScenario()
        {
            txtNomScenario.Text = nomScenario;
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

            SetNomScenario();
        }
    }

    public class ListBoxItemPeriode : ListBoxItem
    {
        private Periode_scenario PeriodeScenario;
        private StackPanel sp;
        private Label txtDuree;
        private Label txtPuissance;
        private Button btnSuppr;
        private int idPeriode;

        public ListBoxItemPeriode(int idPeriode, string duree, string puissance, Periode_scenario PeriodeScenario)
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
