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
                LebenslaufStatList.Add(new LebenslaufStatsItemViewModel());
            });
        }

        private void manageSelectedItem(LebenslaufStatsItemViewModel obj)
        {
           
            int index = LebenslaufStatList.IndexOf(obj);

            SelectedItem = obj;

            if (index == -1) return;

            foreach (var item in LebenslaufStatList)
            {
                item.isSelected = false;
            }
            LebenslaufStatList[index].isSelected = true;

        }


        private static LebenslaufStatListViewModel _instance;

        public static LebenslaufStatListViewModel Instance => _instance ?? (_instance = new());

        public DelegateCommand AddItemCommand { get; set; }

    }
}
