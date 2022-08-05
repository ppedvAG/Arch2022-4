using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using ppedv.Hotelity.Logic;
using ppedv.Hotelity.Model.DomainModel;
using ppedv.Hotelity.UI.WPF.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ppedv.Hotelity.UI.WPF.ViewModels
{
    internal class BuchungenViewModel : ObservableObject
    {
        //todo di
        Core core = new Core(new Data.EfCore.EfMainRepository());

        //public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Buchung> Buchungen { get; set; }

        private Buchung selecteBuchung;
        public Buchung SelecteBuchung
        {
            get => selecteBuchung;
            set
            {
                SetProperty(ref selecteBuchung, value);
                //selecteBuchung = value;
                //OnPropertyChanging();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelecteBuchung"));
                OnPropertyChanged(nameof(BuchungsAlter));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BuchungsAlter)));

            }
        }

        public ICommand SaveCommand { get; set; }

        public ICommand SaveCommand2 { get; set; }

        public string BuchungsAlter
        {
            get
            {
                if (SelecteBuchung == null)
                    return "---";
                return (DateTime.Now - SelecteBuchung.Buchungsdatum.Value).TotalDays.ToString();
            }
        }

        public BuchungenViewModel()
        {
            Buchungen = new ObservableCollection<Buchung>(core.UnitOfWork.BuchungenRepository.Query().ToList());

            SaveCommand = new SaveCommand(core.UnitOfWork);
            SaveCommand2 = new RelayCommand(() => core.UnitOfWork.SaveAll());
        }
    }
}
