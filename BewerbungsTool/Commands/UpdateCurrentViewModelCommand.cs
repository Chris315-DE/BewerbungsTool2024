using BewerbungsTool.Contracts;
using BewerbungsTool.Enums;
using BewerbungsTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BewerbungsTool.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private INavigator _Navigator = null!;

        public bool CanExecute(object? parameter) => true;


        public UpdateCurrentViewModelCommand(INavigator navigator)
        {

            _Navigator = navigator;

        }



        public void Execute(object? parameter)
        {

            if (parameter is ViewEnums)
            {
                switch (parameter)
                {
                    case ViewEnums.BriefKopfView:
                        _Navigator.CurrentViewModel = BriefkopfViewModel.Instance;
                        break;

                    case ViewEnums.AnschreibenView:
                        _Navigator.CurrentViewModel = AnschreibenViewModel.Instance;
                        break;
                    case ViewEnums.ÜbersichtView:
                        _Navigator.CurrentViewModel = ÜbersichtsViewModel.Instance;
                        break;

                    default:
                        Debugger.Break();
                        break;
                }

            }

        }
    }
}
