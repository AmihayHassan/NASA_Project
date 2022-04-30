using NASA_PL.ViewModels;
using System;
using System.Windows.Input;

namespace NASA_PL.Commands
{

    class FilterCommand : ICommand
    {
        NEOsViewModel neosVM;

        public FilterCommand(NEOsViewModel viewModel)
        {
            neosVM = viewModel;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
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
                neosVM.HazardOnly(true);
            }
            else
            {
                neosVM.HazardOnly();
            }
        }
    }
}
