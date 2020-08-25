using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nohejbal_tymy
{

    public static class Michacka
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<string> hraci = new List<string>();
            hraci.Add("Yoda");
            hraci.Add("Vader");
            hraci.Add("Darth Sidious");
            hraci.Add("Luke");
            hraci.Add("Ben");
            hraci.Add("Mace-Windu");
            hraci.Add("Leia");
            hraci.Add("Han");
            hraci.Add("Chewie");
            hraci.Add("R2D2");
            hraci.Add("C3PO");
            hraci.Add("Quai-Gonn");

            Console.Write("Hráči: ");
            Console.Write(String.Join(", ", hraci));
            Console.WriteLine("\n");

            Michacka.Shuffle(hraci);

            int pocetHracu = hraci.Count;
            int maxHracu = 3;
            int pocetTymu = pocetHracu / maxHracu;
            if (pocetHracu % maxHracu == 1)
            {
                pocetTymu += 2;
                maxHracu = 2;
            }
            else if (pocetHracu % maxHracu == 2)
            {
                pocetTymu++;
            }

            var tymy =
                hraci.Select(
                    (a, b) => new { hrac = a, tym = b }
                )
                .GroupBy(x => x.tym / maxHracu)
                .Select(g => g.Select(y => y.hrac)
                .ToList()).ToList();

            Console.WriteLine("Rozdělení týmů:");
                foreach (var t in tymy)
                {
                    Console.Write(String.Join(", ", t));
                    Console.WriteLine();
                }
            Console.ReadKey();
        }

        
    }
}
