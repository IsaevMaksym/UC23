using Bogus;
using UC23.Entities;
using UC23.Fakers;
using ServiceStack.Text;

namespace UC23
{
    internal class Generator
    {
        private List<Titles> _titles = new();
        private List<Credits> _credits = new();

        public Tuple<List<Titles>, List<Credits>> GetTitlesAndCredits(int numberOfRows = 100, int? numberCreditsPerTitle = null)
        {
            _titles = GenerateTitles(numberOfRows).ToList();

            foreach (var title in _titles)
            {
                var credits = GenerateCredits(title.Id, null);
                _credits.AddRange(credits);
                title.TitleCredits?.AddRange(credits);
            }
            return Tuple.Create(_titles, _credits);
        }

        private IEnumerable<Titles> GenerateTitles(int numberOfRows)
        {
            var titlesGenerator = TitleFaker.GetTitlesGenerator();

            var titles = titlesGenerator.Generate(numberOfRows);

            return titles;
        }

        private IEnumerable<Credits> GenerateCredits(int titleId, int? numberOfRows)
        {
            var faker = new Faker();

            var creditsGenerator = CreditsFaker.GetCreditsGenerator(titleId);

            var credits = creditsGenerator.Generate(numberOfRows ?? faker.Random.Number(1, 10));

            return credits;
        }
    }
}
