using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace WPF_Eolienne
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Charger : Window
    {
        private MySqlConnection conn;

        public Charger()
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
                    int idScenario = Int32.Parse(rdr["id"].ToString());
                    string nom = rdr["nom"].ToString();
                    string date = rdr["date_creation"].ToString();

                    listScenario.Items.Add(new ListBoxItemScenario(idScenario, nom, date, this));
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
        private Charger charger;
        private StackPanel sp;
        private Label txtnom;
        private Label txtdate;
        private Button btnSuppr;
        private Button btnEdit;
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

            btnSuppr.Click += BtnSupprimer_Click;
            btnEdit.Click += BtnEdit_Click;

            txtnom.Content = nomScenario;
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
                charger.supprimerScenario(idScenario);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Periode_Scenario operiode_scenario = new Periode_Scenario(idScenario, nomScenario);
            operiode_scenario.Show();
            charger.Close();
        }

    }

}