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
                string filePath = "C:\\Users\\Tanulo\\source\\repos\\dolgozat\\dolgozat\\jeladas.txt";

                if (!File.Exists(filePath))
                {
                    MessageBox.Show("A 'jeladas.txt' fájl nem található!");
                    return;
                }

                string[] sorok = File.ReadAllLines(filePath);
                jeladasok = sorok
                    .Where(sor => !string.IsNullOrWhiteSpace(sor))
                    .Select(sor => new AutoJeladas(sor))
                    .ToList();

                LstAdatok.ItemsSource = jeladasok;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a fájl beolvasásakor: " + ex.Message);
            }
        }

        private void BtnUtolsoJeladas_Click(object sender, RoutedEventArgs e)
        {
            if (jeladasok == null || jeladasok.Count == 0)
            {
                MessageBox.Show("Nincs betöltött adat! Először töltse be a fájlt.");
                return;
            }

            List<AutoJeladas> utolsoJeladasok = AutoJeladas.LegutobbiJeladasok(jeladasok);

            if (utolsoJeladasok.Count > 0)
            {
                LstAdatok.ItemsSource = utolsoJeladasok
                    .Select(j => $"{j.Ora}:{j.Perc} - {j.Rendszam} ({j.Sebesseg} km/h)")
                    .ToList();
            }
            else
            {
                MessageBox.Show("Nincs elérhető jelzés!");
            }
        }

        private void BtnElsoJarmu_Click(object sender, RoutedEventArgs e)
        {
            if (jeladasok == null || jeladasok.Count == 0)
            {
                MessageBox.Show("Nincs betöltött adat! Először töltse be a fájlt.");
                return;
            }

            string idopontok = AutoJeladas.ElsoJarmuJelzesei(jeladasok);

            LblElsoJarmu.Content = $"Első jármű jelzései: {idopontok}";
        }
    }
}
