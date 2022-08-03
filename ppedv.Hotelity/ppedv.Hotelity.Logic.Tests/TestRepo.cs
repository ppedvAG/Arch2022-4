using ppedv.Hotelity.Model;
using ppedv.Hotelity.Model.Contracts;

namespace ppedv.Hotelity.Logic.Tests
{
    public class TestRepo : IRepository
    {

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            if (typeof(T) == typeof(Zimmer))
            {
                var r1 = new Zimmer();
                var r2 = new Zimmer();
                var r3 = new Zimmer();

                r2.Buchung.Add(new Buchung() { Buchungsdatum = DateTime.Now });
                return new[] { r1, r2, r3 }.Cast<T>();
            }
            throw new NotImplementedException();
        }


        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }


        public T GetId<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}