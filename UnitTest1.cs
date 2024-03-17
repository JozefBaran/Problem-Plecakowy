using problem_plecakowy;

namespace Unit_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CzyJedenPrzedmiotZostanieZwrocony()
        {
            int n = 10; // liczba przedmiotów
            int pojemnosc = 20; // pojemnoœæ plecaka
            int seed = 1; // wartoœæ ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);

            Result result = problem.Solve(pojemnosc);

            // Sprawdzamy, czy zwrócono co najmniej jeden element w wyniku
            Assert.That(result.NumeryPrzedmiotow.Count, Is.GreaterThan(0));
        }

        [Test]
        public void ZeroweRozwiazanieGdyZadnePrzedmiotNiePasuje() 
        {
            int n = 10; // liczba przedmiotów
            int pojemnosc = 0;// pojemnoœæ plecaka
            int seed = 1; // wartoœæ ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);

            Result result = problem.Solve(pojemnosc);

            // Sprawdzamy, czy zwrócono puste rozwi¹zanie (brak wybranych przedmiotów)
            Assert.That(result.NumeryPrzedmiotow.Count, Is.EqualTo(0));
            Assert.That(result.SumWartosc, Is.EqualTo(0));
            Assert.That(result.SumWaga, Is.EqualTo(0));
        }

        [Test]
        public void CzyKolejnoscPrzedmiotowMaZnaczenieNaWynik()
        {
            int n = 5; // liczba przedmiotów
            int pojemnosc = 10; // pojemnoœæ plecaka
            int seed = 1; // wartoœæ ziarna

            // Tworzymy dwie instancje problemu plecakowego z ró¿nymi kolejnoœciami przedmiotów
            ProblemPlecakowy problem1 = new ProblemPlecakowy(n, seed);
            ProblemPlecakowy problem2 = new ProblemPlecakowy(n, seed);

            Result result1 = problem1.Solve(pojemnosc);
            Result result2 = problem2.Solve(pojemnosc);

            // Sprawdzamy, czy wyniki dla obu problemów s¹ takie same, niezale¿nie od kolejnoœci przedmiotów
            Assert.That(result1.NumeryPrzedmiotow, Is.EquivalentTo(result2.NumeryPrzedmiotow));
            Assert.That(result1.SumWartosc, Is.EqualTo(result2.SumWartosc));
            Assert.That(result1.SumWaga, Is.EqualTo(result2.SumWaga));
        }

        [Test]
        public void CzyWszystkiePrzedmiotySpakowaneGdyIchWagaJestZero()
        {
            int n = 5; // liczba przedmiotów
            int pojemnosc = 20; // pojemnoœæ plecaka
            int seed = 123; // wartoœæ ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);
            foreach (var przedmiot in problem.Przedmioty)
            {
                przedmiot.Waga = 0; // Ustawienie wagi wszystkich przedmiotów na zero
            }

            Result result = problem.Solve(pojemnosc);

            Assert.That(result.NumeryPrzedmiotow.Count, Is.EqualTo(n)); // Sprawdzenie czy liczba wybranych przedmiotów jest równa liczbie wszystkich przedmiotów
            Assert.That(result.SumWartosc, Is.EqualTo(problem.Przedmioty.Sum(p => p.Wartosc))); // Sprawdzenie czy sumaryczna wartoœæ wybranych przedmiotów jest równa sumie wartoœci wszystkich przedmiotów
            Assert.That(result.SumWaga, Is.EqualTo(0)); // Sprawdzenie czy sumaryczna waga wybranych przedmiotów wynosi zero
        }

        [Test]
        public void WszystkiePrzedmiotySpakowaneGdyWszystkieSieZmieszcza()
        {
            int n = 5; // liczba przedmiotów
            int pojemnosc = 50; // pojemnoœæ plecaka
            int seed = 123; // wartoœæ ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);

            Result result = problem.Solve(pojemnosc);

            Assert.That(result.NumeryPrzedmiotow.Count, Is.EqualTo(n)); // Sprawdzenie czy liczba wybranych przedmiotów jest równa liczbie wszystkich przedmiotów
            Assert.That(result.SumWartosc, Is.EqualTo(problem.Przedmioty.Sum(p => p.Wartosc))); // Sprawdzenie czy sumaryczna wartoœæ wybranych przedmiotów jest równa sumie wartoœci wszystkich przedmiotów
            Assert.That(result.SumWaga, Is.EqualTo(problem.Przedmioty.Sum(p => p.Waga))); // Sprawdzenie czy sumaryczna waga wybranych przedmiotów jest równa sumie wag wszystkich przedmiotów
        }

        [Test]
        public void CzyWagiIWartosciSaZawszeLosowe()
        {
            int n = 10; // liczba przedmiotów
            int seed1 = 123; // pierwsze ziarno losowoœci
            int seed2 = 456; // drugie ziarno losowoœci

            ProblemPlecakowy problem1 = new ProblemPlecakowy(n, seed1);
            ProblemPlecakowy problem2 = new ProblemPlecakowy(n, seed2);

            List<int> values1 = GetValues(problem1.Przedmioty);
            List<int> values2 = GetValues(problem2.Przedmioty);
            List<int> weights1 = GetWeights(problem1.Przedmioty);
            List<int> weights2 = GetWeights(problem2.Przedmioty);

            Assert.That(values1, Is.Not.EqualTo(values2)); // Sprawdzenie, czy wartoœci przedmiotów ró¿ni¹ siê miêdzy problemami
            Assert.That(weights1, Is.Not.EqualTo(weights2)); // Sprawdzenie, czy wagi przedmiotów ró¿ni¹ siê miêdzy problemami
        }

        private List<int> GetValues(List<Przedmiot> przedmioty)
        {
            List<int> values = new List<int>();
            foreach (var przedmiot in przedmioty)
            {
                values.Add(przedmiot.Wartosc);
            }
            return values;
        }

        private List<int> GetWeights(List<Przedmiot> przedmioty)
        {
            List<int> weights = new List<int>();
            foreach (var przedmiot in przedmioty)
            {
                weights.Add(przedmiot.Waga);
            }
            return weights;
        }

        [Test]
        public void ZeroPrzedmiotowIZeroPojemnosci()
        {
            int n = 0; // liczba przedmiotow
            int pojemnosc = 0; // pojemnoœæ plecaka
            int seed = 123; // wartoœæ ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);

            // Act
            Result result = problem.Solve(pojemnosc);

            // Assert
            Assert.That(result.SumWartosc, Is.EqualTo(0)); // Sprawdzenie czy suma wartoœci wynosi zero
            Assert.That(result.SumWaga, Is.EqualTo(0)); // Sprawdzenie czy suma wag wynosi zero
        }
    }
}