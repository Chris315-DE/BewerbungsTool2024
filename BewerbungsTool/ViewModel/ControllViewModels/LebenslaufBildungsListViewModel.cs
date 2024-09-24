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
    public class LebenslaufBildungsListViewModel : BaseViewModel
    {
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand DelCommand { get; set; }

        private LebenslaufDataStore _data;

        private ObservableCollection<LebenslaufBildungsItemViewModel> _items;

        public ObservableCollection<LebenslaufBildungsItemViewModel> Items
        {
            get => _items;
            set
            {
                if (value != _items)
                {
                    _items = value;
                    RaisPropertyChanged();
                }
            }
        }


        private LebenslaufBildungsItemViewModel _SelectedItem;

        public LebenslaufBildungsItemViewModel SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    RaisPropertyChanged();
                }
            }
        }



        private LebenslaufBildungsListViewModel()
        {
            _data = LebenslaufDataStore.Instance;
            _data.LebenslaufBildungsItemChanged += _data_LebenslaufBildungsItemChanged;

            Items = [];
            AddCommand = new DelegateCommand(o =>
            {
                LebenslaufBildungsItemViewModel model = new LebenslaufBildungsItemViewModel(Datum, Was, Wo, Beschreibung);
                SelectedItem = model;
                Items.Add(model);
                Datum = string.Empty;
                Was = string.Empty;
                Wo = string.Empty;
                Beschreibung = string.Empty;

                DelCommand?.RaiseCanExecuteChanged();
            });

            DelCommand = new DelegateCommand(o => Items.Count > 0, o =>
            {
                Items.Remove(SelectedItem);
                if (Items.Count > 0)
                {
                    SelectedItem = Items[0];
                    Items[0].IsSelected = true;
                }
                DelCommand?.RaiseCanExecuteChanged();

            });

        }

        private void _data_LebenslaufBildungsItemChanged(LebenslaufBildungsItemViewModel obj)
        {

            int index = Items.IndexOf(obj);
            if (index == -1) return;

            foreach (var item in Items)
            {
                item.IsSelected = false;
            }
            Items[index].IsSelected = true;
            SelectedItem = Items[index];

        }

        private static LebenslaufBildungsListViewModel _Instance;

        public static LebenslaufBildungsListViewModel Instance => _Instance ?? (_Instance = _Instance = new LebenslaufBildungsListViewModel());

        private string _Datum;
        private string _Was;
        private string _Wo;
        private string _Beschreibung;


        private bool isValid()
        {
            return !string.IsNullOrEmpty(_Datum)&& !string.IsNullOrEmpty(_Was) && !string.IsNullOrEmpty(_Wo)&&!string.IsNullOrEmpty(_Beschreibung);
        }

        public string Datum
        {
            get => _Datum;
            set
            {
                if (value != _Datum)
                {
                    _Datum = value;
                    RaisPropertyChanged();
                }
            }
        }

        public string Was
        {
            get => _Was;
            set
            {
                if (value != _Was)
                {
                    _Was = value;
                    RaisPropertyChanged();
                }
            }
        }
        public string Wo
        {
            get => _Wo;
            set
            {
                if (value != _Wo)
                {
                    _Wo = value;
                    RaisPropertyChanged();
                }
            }
        }
        public string Beschreibung
        {
            get => _Beschreibung;
            set
            {
                if (value != _Beschreibung)
                {
                    _Beschreibung = value;
                    RaisPropertyChanged();
                }
            }
        }
    }
}
