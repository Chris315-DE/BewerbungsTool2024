using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufHobbyListViewModel : BaseViewModel
    {

        LebenslaufDataStore _datastore;

        private LebenslaufHobbyListViewModel()
        {
            _datastore = LebenslaufDataStore.Instance;

            _datastore.LebenslaufHobbyItemChanged += _datastore_LebenslaufHobbyItemChanged;
            Hobbys = [];

            AddCommand = new DelegateCommand(o => !string.IsNullOrEmpty(newHobby), o =>
            {
                LebenslaufHobbyItemViewModel add = new LebenslaufHobbyItemViewModel(newHobby);
                Hobbys.Add(add);
                newHobby = string.Empty;
                RemoveCommand?.RaiseCanExecuteChanged();
                _datastore.OnLebenslaufUnterItemChanged(this,true);


            });


            RemoveCommand = new DelegateCommand(o => Hobbys.Count > 0 && SelectedItem is not null, o =>
            {
                int index = Hobbys.IndexOf(SelectedItem);
                Hobbys.Remove(SelectedItem);
                if (Hobbys.Count > 0)
                {
                    foreach (var item in Hobbys)
                    {
                        item.IsSelected = false;

                    }
                    Hobbys[0].IsSelected = true;
                    SelectedItem = Hobbys[0];
                }
                else
                {
                    _datastore.OnLebenslaufUnterItemChanged(this, false);
                }    




            });





        }

        private void _datastore_LebenslaufHobbyItemChanged(LebenslaufHobbyItemViewModel obj)
        {

            int index = Hobbys.IndexOf(obj);
            if (index == -1)
            {
                return;
            }
            foreach (var item in Hobbys)
            {
                item.IsSelected = false;
            }

            Hobbys[index].IsSelected = true;
            SelectedItem = obj;
            
        }


        private string _newHobby;

        public string newHobby
        {
            get => _newHobby;
            set
            {
                if (value != _newHobby)
                {
                    _newHobby = value;
                    RaisPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private static LebenslaufHobbyListViewModel _instance;
        public static LebenslaufHobbyListViewModel Instance => _instance ?? (_instance = new());


        private ObservableCollection<LebenslaufHobbyItemViewModel> _Hobbys;

        public ObservableCollection<LebenslaufHobbyItemViewModel> Hobbys
        {
            get => _Hobbys;
            set
            {
                if (value != _Hobbys)
                {
                    _Hobbys = value;
                    RaisPropertyChanged();
                }
            }
        }


        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand RemoveCommand { get; set; }

        private LebenslaufHobbyItemViewModel _SelectedItem;

        public LebenslaufHobbyItemViewModel SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (value != _SelectedItem)
                {
                    _SelectedItem = value;
                    RaisPropertyChanged();
                }
            }
        }



    }
}
