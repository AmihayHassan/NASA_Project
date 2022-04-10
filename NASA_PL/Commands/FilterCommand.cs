using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NASA_PL.ViewModels;

namespace NASA_PL.Commands
{
    //TODO add another command

    class FilterCommand : ICommand
    {
        NEOsViewModel neosVM;
        public FilterCommand(NEOsViewModel m)
        {
            neosVM = m;
        }
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool val = bool.Parse(parameter.ToString());
            if (val)
            {
                neosVM.Hazardonly(true);

            }
            else
            {
                neosVM.Hazardonly();
            }

        }
    }
}
