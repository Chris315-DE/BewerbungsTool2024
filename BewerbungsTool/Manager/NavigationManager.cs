using BewerbungsTool.Contracts;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BewerbungsTool.Manager
{
    public class NavigationManager : INavigator, INotifyPropertyChanged
    {

        private BaseViewModel _viewModel;




        public BaseViewModel CurrentViewModel
        {
            get => _viewModel;
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

       

        public ICommand UpdateCurrentViewModel => throw new NotImplementedException();

        public event PropertyChangedEventHandler? PropertyChanged;



        private NavigationManager() { }

        private static INavigator _instance = null!;

        public static INavigator Instance => _instance ?? (_instance = new NavigationManager());


    }
}
