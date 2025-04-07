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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace autofeladat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "server=server.fh2.hu;database=v2labgwj_12b;uid=v2labgwj_12b;password=4W56FNhfKJfeZVhGwasG;";

        public MainWindow()
        {
            InitializeComponent();
            LoadKonyvek();
        }

        private void LoadKonyvek()
        {
            List<Konyv> konyvek = new List<Konyv>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM konyv";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        konyvek.Add(new Konyv
                        {
                            Id = reader.GetInt32("id"),
                            Cim = reader.GetString("cim"),
                            SzerzoId = reader.GetInt32("szerzoId"),
                            Helyezes = reader.GetInt32("helyezes")
                        });
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Hiba: " + ex.Message);
                }
            }

            konyvDataGrid.ItemsSource = konyvek;
        }
    }
}
