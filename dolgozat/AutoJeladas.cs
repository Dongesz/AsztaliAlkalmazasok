using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace dolgozat
{
    public partial class MainWindow : Window
    {
        private List<AutoJeladas> jeladasok = new List<AutoJeladas>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBeolvas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Fájl beolvasása
                string[] sorok = File.ReadAllLines("C:\\Users\\Tanulo\\source\\repos\\dolgozat\\dolgozat\\jeladas.txt");

                // Adatok feldolgozása
                jeladasok = sorok.Select(sor => new AutoJeladas(sor)).ToList();

                // Kiírás ListBoxba
                LstAdatok.ItemsSource = jeladasok;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a fájl beolvasásakor: " + ex.Message);
            }
        }
    }
}
