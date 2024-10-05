using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufProjektListViewModel : BaseViewModel
    {
        private ObservableCollection<LebenslaufProjektItemViewModel> _items;
        private LebenslaufDataStore _store;
        private LebenslaufProjektItemViewModel _selectedItem;
        private LebenslaufProjektListViewModel()
        {
            _store = LebenslaufDataStore.Instance;
            _store.LebenslaufProjektItemChanged += _store_LebenslaufProjektItemChanged;
            Items = [];

            AddCommand = new DelegateCommand(o=> isValid(), o => 
            {
                LebenslaufProjektItemViewModel add = new LebenslaufProjektItemViewModel(ProjektName, ProjektBeschreibung);

                if (Items.Count > 0) 
                {
                    foreach (var item in Items)
                    {
                        item.IsSelected = false;

                    }
                }
                add.IsSelected = true;
                Items.Add(add);
                SelectedItem = add;
                DelCommand?.RaiseCanExecuteChanged();

            });

            DelCommand = new DelegateCommand(o => Items.Count > 0, o => 
            {
                
                Items.Remove(SelectedItem);
                if(Items.Count > 0)
                {
                    SelectedItem = Items[0];
                    Items[0].IsSelected = true;
                }

                DelCommand?.RaiseCanExecuteChanged();

            });

        }


        public LebenslaufProjektItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    RaisPropertyChanged();
                }
            }
        }




        public ObservableCollection<LebenslaufProjektItemViewModel> Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    RaisPropertyChanged();
                }
            }
        }



        private void _store_LebenslaufProjektItemChanged(LebenslaufProjektItemViewModel obj)
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



        private static LebenslaufProjektListViewModel instance;

        public static LebenslaufProjektListViewModel Instance { get => instance ?? (instance = new()); }


        private string _ProjektName;
        private string _ProjektBeschreibung;


        public string ProjektName
        {
            get => _ProjektName;
            set
            {
                if (value != _ProjektName)
                {
                    _ProjektName = value;
                    RaisPropertyChanged();
                    AddCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        public string ProjektBeschreibung
        {
            get => _ProjektBeschreibung;
            set
            {
                if (value != _ProjektBeschreibung)
                {
                    _ProjektBeschreibung = value;
                    RaisPropertyChanged();
                    AddCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand DelCommand { get; set; }

        private bool isValid()
        {
            return !string.IsNullOrEmpty(ProjektBeschreibung) && !string.IsNullOrEmpty(ProjektName);
        }



    }
}
