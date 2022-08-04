using ppedv.Hotelity.Model.Contracts;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Logic
{
    public class Core
    {

        public IMainRepository UnitOfWork { get; private set; }

        public Core(IMainRepository unitOfWork  )
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<Zimmer> GetAvailableRooms(DateTime day)
        {
            return UnitOfWork.GetRepo<Zimmer>().Query().Where(x => x.Buchung.Count == 0 || 
                                                                   x.Buchung.Any(y => y.Buchungsdatum.Value.Date != day.Date));
        }

    }
}