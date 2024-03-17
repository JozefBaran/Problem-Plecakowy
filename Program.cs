using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit tests"), InternalsVisibleTo("GUI")]

namespace problem_plecakowy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe przedmiotów: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj pojemność plecaka: ");
            int p = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj wartość seedu: ");
            int seed = int.Parse(Console.ReadLine());

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);
            Console.WriteLine(problem.ToString());

            var wynik = problem.Solve(p);

            Console.WriteLine(wynik.ToString());
        }
    }
}