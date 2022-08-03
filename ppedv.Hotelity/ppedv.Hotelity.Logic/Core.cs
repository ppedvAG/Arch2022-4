using ppedv.Hotelity.Model;
using ppedv.Hotelity.Model.Contracts;

namespace ppedv.Hotelity.Logic
{
    public class Core
    {

        public IRepository Repository { get; private set; }

        public Core(IRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<Zimmer> GetAvailableRooms(DateTime day)
        {
            return Repository.GetAll<Zimmer>().Where(x => x.Buchung.Count == 0 || 
                                                          x.Buchung.Any(y => y.Buchungsdatum.Value.Date != day.Date));
        }

    }
}