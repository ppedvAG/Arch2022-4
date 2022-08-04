using ppedv.Hotelity.Model.Contracts;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Data.EfCore
{
    public class EfMainRepository : IMainRepository
    {
        EfContext _context = new EfContext();

        public IRepository<Gast> GastRepository => new EfRepository<Gast>(_context);

        public IRepository<Zimmer> ZimmerRepository => new EfRepository<Zimmer>(_context);

        public IBuchungenRepository BuchungenRepository => new EfBuchungenRepository(_context);

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            return new EfRepository<T>(_context);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }
    }
}
