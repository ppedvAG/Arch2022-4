using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Model.Contracts.Services
{
    public interface IBookingService
    {
        decimal CalculateCosts(Buchung buchung);
    }
}
