using BewerbungsTool.Contracts;
using BewerbungsTool.Enums;
using BewerbungsTool.Manager;
using BewerbungsTool.MvvmBasics;
using BewerbungsTool.ViewModel.ControllViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel
{
    public class LebenslaufViewModel : BaseViewModel
    {

        private LebenslaufViewModel()
        {
            DoneList = new List<bool> { false, false, false, false, false };
            Navigator = NavigationManager.Instance;
            Navigator.LebenslaufUnterViewModel = LebenslaufBerufserfahrungListViewModel.Instance;
            NaviCommand = new(o => navi(o));
        }

        private static LebenslaufViewModel _instance;
        public static LebenslaufViewModel Instance => _instance ?? (_instance = new());

        public List<bool> DoneList
        {
            get => _doneList;
            set
            {
                if (value != _doneList)
                {
                    _doneList = value;
                    RaisPropertyChanged();
                }
            }
        }

        private List<bool> _doneList;


        public DelegateCommand NaviCommand { get; set; }

        public INavigator Navigator { get; set; }


        private void navi(object? parameter)
        {
            if (parameter is LebenslaufView view)
            {
                switch (view)
                {
                    case LebenslaufView.Berufserfahrung:
                        Navigator.LebenslaufUnterViewModel = LebenslaufBerufserfahrungListViewModel.Instance;
                        break;
                    case LebenslaufView.Bildung:
                        Navigator.LebenslaufUnterViewModel = LebenslaufBildungsListViewModel.Instance;
                        break;
                    case LebenslaufView.Kontakt:
                        Navigator.LebenslaufUnterViewModel = LebenslaufKontaktListViewModel.Instance;
                        break;
                    case LebenslaufView.PersonenInfo:
                        Navigator.LebenslaufUnterViewModel =  LebenslaufPersonenInfoViewModel.Instance;
                        break;
                    case LebenslaufView.Stats:
                        Navigator.LebenslaufUnterViewModel = LebenslaufStatListViewModel.Instance;
                        break;
                    default:
                        Debugger.Break();
                        break;
                }
            }

        }
    }
}