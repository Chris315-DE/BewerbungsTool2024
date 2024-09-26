using BewerbungsTool.Contracts;
using BewerbungsTool.DataStore;
using BewerbungsTool.Enums;
using BewerbungsTool.Manager;
using BewerbungsTool.MvvmBasics;
using BewerbungsTool.ViewModel.ControllViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel
{
    public class LebenslaufViewModel : BaseViewModel
    {

        private LebenslaufDataStore _dataStore;

        private LebenslaufViewModel()
        {
            DoneList = new ObservableCollection<bool> { false, false, false, false, false };
            Navigator = NavigationManager.Instance;
            Navigator.LebenslaufUnterViewModel = LebenslaufBerufserfahrungListViewModel.Instance;
            NaviCommand = new(o => navi(o));
            _dataStore = LebenslaufDataStore.Instance;
            _dataStore.LebenslaufUnderItemIsChanged += UnderViewIsRdy;


        }

        private void UnderViewIsRdy(BaseViewModel obj, bool state)
        {

            switch (obj)
            {
                case LebenslaufBerufserfahrungListViewModel:


                    bool b0 = state;
                    bool b1 = DoneList[1];
                    bool b2 = DoneList[2];
                    bool b3 = DoneList[3];
                    bool b4 = DoneList[4];

                    DoneList = new ObservableCollection<bool> { b0, b1, b2, b3, b4 };


                    RaisPropertyChanged(nameof(DoneList));
                    break;
                case LebenslaufBildungsListViewModel:

                    b0 = DoneList[0];
                    b1 = state;
                    b2 = DoneList[2];
                    b3 = DoneList[3];
                    b4 = DoneList[4];

                    DoneList = new() { b0, b1, b2, b3, b4 };
                    RaisPropertyChanged(nameof(DoneList));
                    break;
                case LebenslaufKontaktListViewModel:
                    b0 = DoneList[0];
                    b1 = DoneList[1];
                    b2 = state;
                    b3 = DoneList[3];
                    b4 = DoneList[4];

                    DoneList = new() { b0, b1, b2, b3, b4 };
                    RaisPropertyChanged(nameof(DoneList));
                    break;
                case LebenslaufPersonenInfoViewModel:
                    b0 = DoneList[0];
                    b1 = DoneList[1];
                    b2 = DoneList[2];
                    b3 = state;
                    b4 = DoneList[4];

                    DoneList = new() { b0, b1, b2, b3, b4 };
                    RaisPropertyChanged(nameof(DoneList));
                    break;
                case LebenslaufStatListViewModel:
                    b0 = DoneList[0];
                    b1 = DoneList[1];
                    b2 = DoneList[2];
                    b3 = DoneList[3];
                    b4 = state;

                    DoneList = new() { b0, b1, b2, b3, b4 };
                    RaisPropertyChanged(nameof(DoneList));
                    break;



            }

        }

        private static LebenslaufViewModel _instance;
        public static LebenslaufViewModel Instance => _instance ?? (_instance = new());

        public ObservableCollection<bool> DoneList
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

        private ObservableCollection<bool> _doneList;


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
                        Navigator.LebenslaufUnterViewModel = LebenslaufPersonenInfoViewModel.Instance;
                        break;
                    case LebenslaufView.Stats:
                        Navigator.LebenslaufUnterViewModel = LebenslaufStatListViewModel.Instance;
                        break;
                    case LebenslaufView.Projekt:
                        Navigator.LebenslaufUnterViewModel = LebenslaufProjektListViewModel.Instance;
                        break;
                    default:
                        Debugger.Break();
                        break;
                }
            }

        }
    }
}