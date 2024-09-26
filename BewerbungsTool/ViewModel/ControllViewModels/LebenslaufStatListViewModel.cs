using BewerbungsTool.Controlls;
using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufStatListViewModel : BaseViewModel
    {


        private LebenslaufDataStore _datastore;

        private ObservableCollection<LebenslaufStatsItemViewModel> _LebenslaufStatList;
        public ObservableCollection<LebenslaufStatsItemViewModel> LebenslaufStatList
        {
            get => _LebenslaufStatList;
            set
            {
                if (value != _LebenslaufStatList)
                {
                    _LebenslaufStatList = value;
                    RaisPropertyChanged();
                }
            }
        }

        private LebenslaufStatsItemViewModel _SelectedItem;

        public LebenslaufStatsItemViewModel SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (value != _SelectedItem)
                {
                    _SelectedItem = value;
                    RaisPropertyChanged();
                    if (SelectedItem != null)
                    {
                        Fähigkeit = SelectedItem.Fähigkeit;
                        SliderValue = SelectedItem.SliderValue;

                    }

                }
            }
        }

        private LebenslaufStatListViewModel()
        {

            _datastore = LebenslaufDataStore.Instance;
            LebenslaufStatList = [];

            _datastore.LebenslaufStatItemChanged += manageSelectedItem;

            AddItemCommand = new DelegateCommand(o =>
            {
                var add = new LebenslaufStatsItemViewModel(string.Empty, "1");
                LebenslaufStatList.Insert(0, add);
                manageSelectedItem(add);
                RemoveItemCommand?.RaiseCanExecuteChanged();
                _datastore.OnLebenslaufUnterItemChanged(this, true);


            });

            RemoveItemCommand = new DelegateCommand(o => LebenslaufStatList.Count > 0, o =>
            {
                DelSelectedItem(SelectedItem);
                if (LebenslaufStatList.Count == 0)
                {
                    _datastore.OnLebenslaufUnterItemChanged(this, false);
                }
                RemoveItemCommand?.RaiseCanExecuteChanged();


            });

            SliderValue = "1";
        }

        private void manageSelectedItem(LebenslaufStatsItemViewModel obj)
        {

            int index = LebenslaufStatList.IndexOf(obj);

            SelectedItem = obj;

            if (index == -1) return;

            foreach (var item in LebenslaufStatList)
            {
                item.IsSelected = false;
            }
            LebenslaufStatList[index].IsSelected = true;
            SliderValue = SelectedItem.SliderValue;
            Fähigkeit = SelectedItem.Fähigkeit;



        }

        private void DelSelectedItem(LebenslaufStatsItemViewModel obj)
        {
            var objtodel = obj;

            SelectedItem = null;
            LebenslaufStatList.Remove(objtodel);
            if (LebenslaufStatList.Count > 0)
            {
                SelectedItem = LebenslaufStatList[0];
                LebenslaufStatList[0].IsSelected = true;
            }

        }

        private static LebenslaufStatListViewModel _instance;

        public static LebenslaufStatListViewModel Instance => _instance ?? (_instance = new());

        public DelegateCommand AddItemCommand { get; set; }

        public DelegateCommand RemoveItemCommand { get; set; }

        private string _Fähigkeit;

        public string Fähigkeit
        {
            get => _Fähigkeit;
            set
            {
                if (value != _Fähigkeit)
                {
                    _Fähigkeit = value;
                    RaisPropertyChanged();

                    if (SelectedItem != null)
                    {
                        SelectedItem.Fähigkeit = value;
                    }
                }
            }
        }
        private string _SliderValue;
        public string SliderValue
        {
            get => _SliderValue;
            set
            {
                if (_SliderValue != value)
                {
                    _SliderValue = value;
                    RaisPropertyChanged();

                    if (SelectedItem != null)
                    {
                        SelectedItem.SliderValue = value;
                    }


                }
            }
        }


    }
}
