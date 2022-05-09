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

            }

            private void Button_Creation(object sender, RoutedEventArgs e)
        {
            Creation creation = new Creation();
            creation.Show();
            this.Close();
        }

        private void Button_Charger(object sender, RoutedEventArgs e)
        { 
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
            this.Close();
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
