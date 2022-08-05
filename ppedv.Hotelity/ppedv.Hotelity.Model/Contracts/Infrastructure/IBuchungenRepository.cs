using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Model.Contracts.Infrastructure
{
    public interface IBuchungenRepository : IRepository<Buchung>
    {
        IEnumerable<Buchung> GetBuchungenByDateRange(DateOnly start, DateOnly end);
    }
}
