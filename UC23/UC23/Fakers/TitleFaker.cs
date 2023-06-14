using Bogus;
using UC23.Entities;

namespace UC23.Fakers
{
    internal class TitleFaker : Faker<Titles>
    {
        private const int YearOfTheFirstMovie = 1895;
        private const int DurationOfTheLongestMovie = 400;
        private const int MaxNamberOfGenres = 10;
        private const int MaxCountOfWordsInTitle = 10;
        private const int MaxNumberOfSeasons = 25;

        public TitleFaker(){}

        public static Faker<Titles> GetTitlesGenerator()
        {
            return  new Faker<Titles>()
                .RuleFor(t => t.Id, f => f.Random.Int(0))
                .RuleFor(t => t.Title, f => f.Lorem.Sentence(f.Random.Number(1, MaxCountOfWordsInTitle)))
                .RuleFor(t => t.Description, f => f.Lorem.Text())
                .RuleFor(t => t.ReleaseYear, f => f.Date.Random.Int(YearOfTheFirstMovie, DateTime.Now.Year))
                .RuleFor(t => t.AgeSertification, f => f.PickRandom(Constants.TitleAgeSertification))
                .RuleFor(t => t.Runtime, f => f.Random.Number(1, DurationOfTheLongestMovie))
                .RuleFor(t => t.Genres, f => f.Make(f.Random.Number(1, MaxNamberOfGenres), () => f.PickRandom(Constants.TitlesGenres)))
                .RuleFor(t => t.ProductionCountry, f => f.Address.CountryCode(Bogus.DataSets.Iso3166Format.Alpha3))
                .RuleFor(t => t.Seasons, f => f.Random.Int(1, MaxNumberOfSeasons).OrNull(f, .5f));
        }
    }
}
