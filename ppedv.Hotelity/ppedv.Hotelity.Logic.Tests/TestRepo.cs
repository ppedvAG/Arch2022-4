using FluentAssertions;
using ppedv.Hotelity.Model.Contracts;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Logic.Tests
{

    public class TestUnitOfWork : IMainRepository
    {
        public IRepository<Gast> GastRepository => throw new NotImplementedException();

        public IRepository<Zimmer> ZimmerRepository => throw new NotImplementedException();

        public IBuchungenRepository BuchungenRepository => throw new NotImplementedException();

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            if (typeof(T) == typeof(Zimmer))
                return new TestRepo() as IRepository<T>;

            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }
    }

    public class TestRepo : IRepository<Zimmer>
    {
        public IQueryable<Zimmer> Query()
        {
            var r1 = new Zimmer();
            var r2 = new Zimmer();
            var r3 = new Zimmer();

            r2.Buchung.Add(new Buchung() { Buchungsdatum = DateTime.Now });
            return new[] { r1, r2, r3 }.AsQueryable();
        }

        public void Add(Zimmer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Zimmer entity)
        {
            throw new NotImplementedException();
        }

        public Zimmer GetId(int id)
        {
            throw new NotImplementedException();
        }



        public void Update(Zimmer entity)
        {
            throw new NotImplementedException();
        }
    }
}