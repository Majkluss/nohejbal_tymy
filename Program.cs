using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nohejbal_tymy
{
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

            int pocetHracu = hraci.Count;
            int pocetTymu = pocetHracu / 3;
            if (pocetHracu % 3 > 0)
            {
                pocetTymu++;
            }

            Console.Write("Hráči: ");
            Console.Write(String.Join(", ", hraci));
            Console.WriteLine("\n");

            var tymy =
                hraci.Select(
                    (a, b) => new { hrac = a, tym = b }
                )
                .GroupBy(x => x.tym / 3)
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
