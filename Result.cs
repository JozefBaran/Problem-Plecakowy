using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem_plecakowy
{
    public class Result
    {
        public List<int> NumeryPrzedmiotow { get; set; }
        public int SumWartosc { get; set; }
        public int SumWaga { get; set; }

        public Result(List<int> numeryPrzedmiotow, int sumWartosc, int sumWaga)
        {
            NumeryPrzedmiotow = numeryPrzedmiotow;
            SumWartosc = sumWartosc;
            SumWaga = sumWaga;
        }
        public override string ToString()
        {
            return $"Kolejność przedmiotów: {string.Join(", ", NumeryPrzedmiotow)}, Całkowita wartość: {SumWartosc}, Całkowita waga: {SumWaga}";
        }
    }
}