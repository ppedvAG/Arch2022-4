using Microsoft.EntityFrameworkCore;
using ppedv.Hotelity.Model.Contracts.Infrastructure;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Data.EfCore
{
    public class EfBuchungenRepository : EfRepository<Buchung>, IBuchungenRepository
    {
        internal EfBuchungenRepository(EfContext context) : base(context)
        { }

        public IEnumerable<Buchung> GetBuchungenByDateRange(DateOnly start, DateOnly end)
        {
            _context.Database.ExecuteSqlRaw("SELECT * FROM Buchungen");

            return new List<Buchung>();
        }
    }
}
