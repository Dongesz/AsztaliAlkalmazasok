using System;

namespace dolgozat
{
    internal class AutoJeladas
    {
        public string Rendszam { get; set; }
        public int Ora { get; set; }
        public int Perc { get; set; }
        public int Sebesseg { get; set; }

        public AutoJeladas(string sor)
        {
            var adatok = sor.Split('\t'); // Tabulátor alapú feldolgozás
            Rendszam = adatok[0];
            Ora = int.Parse(adatok[1]);
            Perc = int.Parse(adatok[2]);
            Sebesseg = int.Parse(adatok[3]);
        }

        public override string ToString()
        {
            return $"{Rendszam} {Ora}:{Perc} - {Sebesseg} km/h";
        }
    }
}
