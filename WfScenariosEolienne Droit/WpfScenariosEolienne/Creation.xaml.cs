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
    public partial class Creation : Window
    {
        private MySqlConnection conn;

        public Creation()
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

        private void Button_Creation(object sender, RoutedEventArgs e)
        {
            Creation creation = new Creation();
            creation.Show();
            this.Close();
        }

        private void Button_Charger (object sender, RoutedEventArgs e)
        { 
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
            this.Close();
        }
      


        private void MAJListePhases()
        {
            string sql = "SELECT * FROM scenario "
;

            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            listScenario.Items.Clear();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    int idPhase = Int32.Parse(rdr["id"].ToString());
                    string nom = rdr["nom"].ToString();
                    string date = rdr["date_creation"].ToString();

                    listScenario.Items.Add(new ListBoxItemScenario(idPhase, nom, date, this));
                }
            }
            conn.Close();


        }

        public void supprimerScenario(int id)
        {
            string sql = "DELETE FROM `scenario` WHERE `id` = " + id;

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

    public class ListBoxItemScenario : ListBoxItem
    {
        private Creation creation;
        private StackPanel sp;
        private Label txtnom;
        private Label txtdate;
        private Button btnSuppr;
        private Button btnEdit;
        private int idScenario;
        private string nomScenario;

        public ListBoxItemScenario(int idScenario, string name, string date, Creation creation)
        {
            this.creation = creation;
            this.idScenario = idScenario;
            this.nomScenario = name;

            sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            txtnom = new Label();
            txtdate = new Label();
            btnSuppr = new Button();
            btnEdit = new Button();

            btnSuppr.Click += BtnSupprimer_Click;
            btnEdit.Click += BtnEdit_Click;

            txtnom.Content = name;
            txtdate.Content = date;
            btnSuppr.Content = "Suppr.";
            btnEdit.Content = "Edit";

            sp.Children.Add(txtnom);
            sp.Children.Add(txtdate);
            sp.Children.Add(btnSuppr);
            sp.Children.Add(btnEdit);

            this.AddChild(sp);
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
         {
             MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer cette phase ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Question);
 
             if (result == MessageBoxResult.Yes)
             {
                 creation.supprimerScenario(idScenario);
             }
         }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Periode_scenario operiode_scenario = new Periode_scenario(idScenario, nomScenario);
            operiode_scenario.Show();
            creation.Close();
        }

    }

}
