using Bogus;
using UC23.Entities;

namespace UC23.Fakers
{
    internal class CreditsFaker : Faker<Credits>
    {
        public CreditsFaker() { }

        public static Faker<Credits> GetCreditsGenerator(int TitleId)
        {

            var credits = new Faker<Credits>()
                .RuleFor(c => c.Id, f => f.Random.Int(0))
                .RuleFor(c => c.RealName, f => f.Person.FullName)
                .RuleFor(c => c.CharacterName, f => (f.Person.LastName + " " + f.Person.FirstName))
                .RuleFor(c => c.Role, f => f.PickRandom(Constants.CreditsRole))
                .RuleFor(c => c.TitleId, TitleId);
                  
            return credits;
        }
    }
}
