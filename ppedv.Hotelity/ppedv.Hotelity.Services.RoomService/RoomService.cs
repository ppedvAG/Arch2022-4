using ppedv.Hotelity.Model.Contracts.Infrastructure;
using ppedv.Hotelity.Model.Contracts.Services;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Services.RoomService
{
    public class RoomService:IRoomService
    {
        private readonly IMainRepository mainRepository;

        public RoomService(IMainRepository mainRepository)
        {
            this.mainRepository = mainRepository;
        }

        public IEnumerable<Zimmer> GetAvailableRooms(DateTime day)
        {
            return mainRepository.GetRepo<Zimmer>().Query().Where(x => x.Buchung.Count == 0 ||
                                                                   x.Buchung.Any(y => y.Buchungsdatum.Value.Date != day.Date));
        }
    }
}