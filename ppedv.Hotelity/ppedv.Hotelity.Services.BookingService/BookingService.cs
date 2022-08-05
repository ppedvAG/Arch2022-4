using ppedv.Hotelity.Model.Contracts.Infrastructure;
using ppedv.Hotelity.Model.Contracts.Services;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IMainRepository repository;

        public BookingService(IMainRepository repository)
        {
            this.repository = repository;
        }

        public decimal CalculateCosts(Buchung buchung)
        {
            return (decimal)(buchung.Bis.Value - buchung.Von.Value).TotalDays * 30;
        }
    }
}