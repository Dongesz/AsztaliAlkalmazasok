using System;
using System.Collections.Generic;
using System.Linq;

namespace dolgozat
{
    public class AutoJeladas
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
                return new List<AutoJeladas>();
            }

            return jeladasok
                .OrderByDescending(j => j.Ora)
                .ThenByDescending(j => j.Perc)
                .Take(db)
                .ToList();
        }

        public static string ElsoJarmuJelzesei(List<AutoJeladas> jeladasok)
        {
            if (jeladasok == null || jeladasok.Count == 0)
            {
                return "Nincs adat";
            }

            string elsoJarmuRendszam = jeladasok[0].Rendszam;

            var idopontok = jeladasok
                .Where(j => j.Rendszam == elsoJarmuRendszam)
                .Select(j => $"{j.Ora}:{j.Perc}")
                .ToList();

            return string.Join(" ", idopontok);
        }

        public static int IdopontJelzeseinekSzama(List<AutoJeladas> jeladasok, int ora, int perc)
        {
            if (jeladasok == null || jeladasok.Count == 0)
            {
                return 0;
            }

            return jeladasok
                .Count(j => j.Ora == ora && j.Perc == perc);
        }
    }
}
