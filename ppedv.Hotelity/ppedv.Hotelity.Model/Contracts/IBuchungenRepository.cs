using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Model.Contracts
{
    public interface IBuchungenRepository : IRepository<Buchung>
    {
        IEnumerable<Buchung> GetBuchungenByDateRange(DateOnly start, DateOnly end);
    }
}
