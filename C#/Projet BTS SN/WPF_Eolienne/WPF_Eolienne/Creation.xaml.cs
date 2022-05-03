using System;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;


namespace WPF_Eolienne
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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Btn_Instantane(object sender, RoutedEventArgs e)    // On regle le btn nommé button_instantané pour qui ouvre la fenetre intantané "choisit" et on ferme la fenetre actuel
        {
            Instantane instantane = new Instantane();
            instantane.Show();
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

        private void ajout_Scenario(object sender, RoutedEventArgs e)
        {

            string nom = String.Format(txtScenario.Text);
            //   DateTime date_creation = DateTime.Parse(txtDate.Text);


            string sql = "INSERT INTO `scenario` ( nom, date_creation ) VALUES ( '" + nom + "', Now());";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            Creation creation = new Creation();
            creation.Show();
            this.Close();

        }

    }
}
