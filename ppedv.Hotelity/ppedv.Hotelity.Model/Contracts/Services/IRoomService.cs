using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Model.Contracts.Services
{
    public interface IRoomService
    {
        public IEnumerable<Zimmer> GetAvailableRooms(DateTime day);
    }
}
