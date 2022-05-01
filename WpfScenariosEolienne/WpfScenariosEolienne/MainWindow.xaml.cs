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

namespace WpfScenariosEolienne
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySqlConnection conn;

        public MainWindow()
        {
            InitializeComponent();

            string myConnectionString = "server=127.0.0.1;"
                                   
                                              + "uid=root;"
                                              + "pwd=;"
                                              + "database=eoliennedb;"
                                              + "Charset=latin1;";

            conn = new MySqlConnection(myConnectionString);

            MAJListePhases();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            int duree = Int32.Parse(txtDuree.Text);
            int puissance = Int32.Parse(txtPuissance.Text);


            string sql = "INSERT INTO `periode` (`id`, `duree`, `puissance_soufflerie`, `scenario_id`) VALUES (NULL, '" + duree + "', '" + puissance + "', '1');";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MAJListePhases();
        }


        private void MAJListePhases()
        {
            string sql = "SELECT * FROM `periode` ";

            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            lbPhases.Items.Clear();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    int idPhase = Int32.Parse(rdr["id"].ToString());
                    int duree = Int32.Parse(rdr["duree"].ToString());
                    int puissance = Int32.Parse(rdr["puissance_soufflerie"].ToString());

                    lbPhases.Items.Add(new ListBoxItemPhase(idPhase, duree, puissance, this));
                }             
            }

            conn.Close();
        }

        public void supprimerPhase(int id)
        {
            string sql = "DELETE FROM `periode` WHERE `id` =  " + id;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            MAJListePhases();
        }

        private void txtPuissance_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous finaliser votre résultat ?", "Confirmer", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

            }
        }
    }

    public class ListBoxItemPhase : ListBoxItem
    {
        private MainWindow mainWin;

        private StackPanel sp;
        private Label txtDuree;
        private Label txtPuissance;
        private Button btnSupprimer;
        private int idPhase;

        public ListBoxItemPhase(int idPhase, int duree, int puissance, MainWindow mainWin)
        {
            this.mainWin = mainWin;
            this.idPhase = idPhase;

            sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            txtDuree = new Label();
            txtPuissance = new Label();
            btnSupprimer = new Button();
            btnSupprimer.Click += BtnSupprimer_Click;

            txtDuree.Content = duree.ToString() + " secondes";
            txtPuissance.Content = puissance.ToString() + "%";

            btnSupprimer.Content = "Suppr.";

            sp.Children.Add(txtDuree);
            sp.Children.Add(txtPuissance);
            sp.Children.Add(btnSupprimer);

            this.AddChild(sp);
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer cette phase ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(result == MessageBoxResult.Yes)
            {
                mainWin.supprimerPhase(idPhase);
            }
        }
    }
}
