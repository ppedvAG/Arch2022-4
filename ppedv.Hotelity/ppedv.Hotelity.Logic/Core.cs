using ppedv.Hotelity.Model;
using ppedv.Hotelity.Model.Contracts;

namespace ppedv.Hotelity.Logic
{
    public class Core
    {

        public IUnitOfWork UnitOfWork { get; private set; }

        public Core(IUnitOfWork unitOfWork  )
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