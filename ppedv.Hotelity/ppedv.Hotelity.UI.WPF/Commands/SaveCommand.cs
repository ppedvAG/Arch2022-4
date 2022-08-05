using ppedv.Hotelity.Model.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.Hotelity.UI.WPF.Commands
{
    internal class SaveCommand : ICommand
    {
        private readonly IMainRepository mainRepo;

        public event EventHandler? CanExecuteChanged;

        public SaveCommand(IMainRepository mainRepo)
        {
            this.mainRepo = mainRepo;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            mainRepo.SaveAll();
        }
    }
}
