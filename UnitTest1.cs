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
            int n = 10; // liczba przedmiot�w
            int pojemnosc = 20; // pojemno�� plecaka
            int seed = 1; // warto�� ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);

            Result result = problem.Solve(pojemnosc);

            // Sprawdzamy, czy zwr�cono co najmniej jeden element w wyniku
            Assert.That(result.NumeryPrzedmiotow.Count, Is.GreaterThan(0));
        }

        [Test]
        public void ZeroweRozwiazanieGdyZadnePrzedmiotNiePasuje() 
        {
            int n = 10; // liczba przedmiot�w
            int pojemnosc = 0;// pojemno�� plecaka
            int seed = 1; // warto�� ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);

            Result result = problem.Solve(pojemnosc);

            // Sprawdzamy, czy zwr�cono puste rozwi�zanie (brak wybranych przedmiot�w)
            Assert.That(result.NumeryPrzedmiotow.Count, Is.EqualTo(0));
            Assert.That(result.SumWartosc, Is.EqualTo(0));
            Assert.That(result.SumWaga, Is.EqualTo(0));
        }

        [Test]
        public void CzyKolejnoscPrzedmiotowMaZnaczenieNaWynik()
        {
            int n = 5; // liczba przedmiot�w
            int pojemnosc = 10; // pojemno�� plecaka
            int seed = 1; // warto�� ziarna

            // Tworzymy dwie instancje problemu plecakowego z r�nymi kolejno�ciami przedmiot�w
            ProblemPlecakowy problem1 = new ProblemPlecakowy(n, seed);
            ProblemPlecakowy problem2 = new ProblemPlecakowy(n, seed);

            Result result1 = problem1.Solve(pojemnosc);
            Result result2 = problem2.Solve(pojemnosc);

            // Sprawdzamy, czy wyniki dla obu problem�w s� takie same, niezale�nie od kolejno�ci przedmiot�w
            Assert.That(result1.NumeryPrzedmiotow, Is.EquivalentTo(result2.NumeryPrzedmiotow));
            Assert.That(result1.SumWartosc, Is.EqualTo(result2.SumWartosc));
            Assert.That(result1.SumWaga, Is.EqualTo(result2.SumWaga));
        }

        [Test]
        public void CzyWszystkiePrzedmiotySpakowaneGdyIchWagaJestZero()
        {
            int n = 5; // liczba przedmiot�w
            int pojemnosc = 20; // pojemno�� plecaka
            int seed = 123; // warto�� ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);
            foreach (var przedmiot in problem.Przedmioty)
            {
                przedmiot.Waga = 0; // Ustawienie wagi wszystkich przedmiot�w na zero
            }

            Result result = problem.Solve(pojemnosc);

            Assert.That(result.NumeryPrzedmiotow.Count, Is.EqualTo(n)); // Sprawdzenie czy liczba wybranych przedmiot�w jest r�wna liczbie wszystkich przedmiot�w
            Assert.That(result.SumWartosc, Is.EqualTo(problem.Przedmioty.Sum(p => p.Wartosc))); // Sprawdzenie czy sumaryczna warto�� wybranych przedmiot�w jest r�wna sumie warto�ci wszystkich przedmiot�w
            Assert.That(result.SumWaga, Is.EqualTo(0)); // Sprawdzenie czy sumaryczna waga wybranych przedmiot�w wynosi zero
        }

        [Test]
        public void WszystkiePrzedmiotySpakowaneGdyWszystkieSieZmieszcza()
        {
            int n = 5; // liczba przedmiot�w
            int pojemnosc = 50; // pojemno�� plecaka
            int seed = 123; // warto�� ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);

            Result result = problem.Solve(pojemnosc);

            Assert.That(result.NumeryPrzedmiotow.Count, Is.EqualTo(n)); // Sprawdzenie czy liczba wybranych przedmiot�w jest r�wna liczbie wszystkich przedmiot�w
            Assert.That(result.SumWartosc, Is.EqualTo(problem.Przedmioty.Sum(p => p.Wartosc))); // Sprawdzenie czy sumaryczna warto�� wybranych przedmiot�w jest r�wna sumie warto�ci wszystkich przedmiot�w
            Assert.That(result.SumWaga, Is.EqualTo(problem.Przedmioty.Sum(p => p.Waga))); // Sprawdzenie czy sumaryczna waga wybranych przedmiot�w jest r�wna sumie wag wszystkich przedmiot�w
        }

        [Test]
        public void CzyWagiIWartosciSaZawszeLosowe()
        {
            int n = 10; // liczba przedmiot�w
            int seed1 = 123; // pierwsze ziarno losowo�ci
            int seed2 = 456; // drugie ziarno losowo�ci

            ProblemPlecakowy problem1 = new ProblemPlecakowy(n, seed1);
            ProblemPlecakowy problem2 = new ProblemPlecakowy(n, seed2);

            List<int> values1 = GetValues(problem1.Przedmioty);
            List<int> values2 = GetValues(problem2.Przedmioty);
            List<int> weights1 = GetWeights(problem1.Przedmioty);
            List<int> weights2 = GetWeights(problem2.Przedmioty);

            Assert.That(values1, Is.Not.EqualTo(values2)); // Sprawdzenie, czy warto�ci przedmiot�w r�ni� si� mi�dzy problemami
            Assert.That(weights1, Is.Not.EqualTo(weights2)); // Sprawdzenie, czy wagi przedmiot�w r�ni� si� mi�dzy problemami
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
            int pojemnosc = 0; // pojemno�� plecaka
            int seed = 123; // warto�� ziarna

            ProblemPlecakowy problem = new ProblemPlecakowy(n, seed);

            // Act
            Result result = problem.Solve(pojemnosc);

            // Assert
            Assert.That(result.SumWartosc, Is.EqualTo(0)); // Sprawdzenie czy suma warto�ci wynosi zero
            Assert.That(result.SumWaga, Is.EqualTo(0)); // Sprawdzenie czy suma wag wynosi zero
        }
    }
}