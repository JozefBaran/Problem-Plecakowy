using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem_plecakowy
{
    public class ProblemPlecakowy
    {
        public int LiczbaPrzedmiotow { get; set; }
        public List<Przedmiot> Przedmioty { get; set; }

        public ProblemPlecakowy(int n, int seed)
        {
            LiczbaPrzedmiotow = n;
            Przedmioty = new List<Przedmiot>();
            Random random = new Random(seed);

            for (int i = 0; i < n; i++)
            {
                int wartosc = random.Next(10);
                int waga = random.Next(10);
                Przedmioty.Add(new Przedmiot(wartosc, waga));
            }
        }
        public override string ToString()
        {
            string result = "";
            foreach (var przedmiot in Przedmioty)
            {
                result += $"Wartość: {przedmiot.Wartosc}, Waga: {przedmiot.Waga}{Environment.NewLine}";
            }
            return result;
        }
        public Result Solve(int pojemnosc)
        {
            var posortowanePrzedmioty = Przedmioty.OrderByDescending(ratio => (double)ratio.Wartosc / ratio.Waga).ToList();
            List<int> numeryPrzedmiotow = new List<int>();
            int sumWartosc = 0;
            int sumWaga = 0;

            foreach (var przedmiot in posortowanePrzedmioty)
            {
                if (sumWaga + przedmiot.Waga <= pojemnosc)
                {
                    numeryPrzedmiotow.Add(Przedmioty.IndexOf(przedmiot) + 1);
                    sumWartosc += przedmiot.Wartosc;
                    sumWaga += przedmiot.Waga;
                }
            }

            return new Result(numeryPrzedmiotow, sumWartosc, sumWaga);
        }
    }

}