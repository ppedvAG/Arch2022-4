using Bogus;
using ppedv.Hotelity.Model.Contracts.Services;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Services.DemoService
{
    public class DemoService : IDemoService
    {
        public IEnumerable<Gast> GetDemoGaeste()
        {
            var gastFaker = new Faker<Gast>("de")
                            .UseSeed(5)
                            .RuleFor(x => x.Name, x => x.Name.FullName())
                            .RuleFor(x => x.GebDatum, x => x.Date.Past(30));

            var buchungFaker = new Faker<Buchung>()
                                .UseSeed(5)
                                .RuleFor(x => x.Buchungsdatum, x => x.Date.Recent(14))
                                .RuleFor(x => x.Von, x => x.Date.Soon(5))
                                .RuleFor(x => x.Bis, x => x.Date.Soon(10));

            gastFaker.RuleFor(x => x.Buchung, x => buchungFaker.Generate(x.Random.Int(1, 3)));

            foreach (var g in gastFaker.Generate(20))
            {
                foreach (var b in g.Buchung)
                {
                    b.Gast = g;
                }
                yield return g;
            }
        }
    }
}