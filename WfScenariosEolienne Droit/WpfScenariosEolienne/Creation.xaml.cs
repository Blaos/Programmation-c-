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
                    int id = Int32.Parse(rdr["id"].ToString());
                    var nom = string.Format(rdr["nom"].ToString());              

                    listScenario.Items.Add(new ListBoxItemPhase(idPhase,nom, id, this));
                }
            }
            conn.Close();


        }

        public void supprimerPhase(int id)
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

     public class ListBoxItemPhase : ListBoxItem
     {
         private Creation creation;
         private StackPanel sp;
         private Label txtNom;
         private Button btnSuppr;
         private int idPhase;

         public ListBoxItemPhase(int idPhase, int nom, int id,  Creation creation)
         {
             this.creation = creation;
             this.idPhase = idPhase;

            sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            txtNom = new Label();
            btnSuppr = new Button();
            btnSuppr.Click += BtnSupprimer_Click;


            btnSuppr.Content = "Suppr.";

            sp.Children.Add(btnSuppr);
            sp.Children.Add(txtNom);


            this.AddChild(sp);
         }

         private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
         {
             MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer cette phase ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Question);
 
             if (result == MessageBoxResult.Yes)
             {
                 creation.supprimerPhase(idPhase);
             }
         }
         

     }

}
