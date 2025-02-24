using System;
using System.Collections.Generic;
using System.Linq;

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
            var adatok = sor.Split('\t');
            Rendszam = adatok[0];
            Ora = int.Parse(adatok[1]);
            Perc = int.Parse(adatok[2]);
            Sebesseg = int.Parse(adatok[3]);
        }

        public override string ToString()
        {
            return $"{Rendszam} {Ora}:{Perc} - {Sebesseg} km/h";
        }

        public static List<AutoJeladas> LegutobbiJeladasok(List<AutoJeladas> jeladasok, int db = 8)
        {
            if (jeladasok == null || jeladasok.Count == 0)
            {
                return new List<AutoJeladas>(); // Ha nincs adat, üres listát adunk vissza
            }

            return jeladasok
                .OrderByDescending(j => j.Ora)   // Legnagyobb óra előre
                .ThenByDescending(j => j.Perc)   // Ha az óra megegyezik, akkor perc alapján
                .Take(db)                        // Az első `db` darabot vesszük (alapértelmezett 8)
                .ToList();
        }

    }
}
