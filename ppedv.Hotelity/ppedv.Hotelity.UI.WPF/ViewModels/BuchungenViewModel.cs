using ppedv.Hotelity.Logic;
using ppedv.Hotelity.Model.DomainModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace ppedv.Hotelity.UI.WPF.ViewModels
{
    internal class BuchungenViewModel
    {
        //todo di
        Core core = new Core(new Data.EfCore.EfMainRepository());

        public ObservableCollection<Buchung> Buchungen { get; set; }

        public Buchung SelecteBuchung { get; set; }

        public BuchungenViewModel()
        {
            Buchungen = new ObservableCollection<Buchung>(core.UnitOfWork.BuchungenRepository.Query().ToList());
        }
    }
}
