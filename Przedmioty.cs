using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem_plecakowy
{
    public class Przedmiot
    {
        public int Waga { get; set; }
        public int Wartosc { get; set; }

        public Przedmiot(int wartosc, int waga)
        {
            Waga = waga;
            Wartosc = wartosc;
        }
    }

}
