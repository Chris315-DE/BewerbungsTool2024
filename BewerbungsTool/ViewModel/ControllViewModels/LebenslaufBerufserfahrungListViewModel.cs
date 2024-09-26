using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufBerufserfahrungListViewModel : BaseViewModel
    {
        private const string ART = "Aufgabenbereiche";
        private string _tätigkeit;
        private string _arbeitgeber;
        private string _vonBis;
        private string _beschreibung;
        private ObservableCollection<LebenslaufBerufserfahrungItemViewModel> _items;
        private LebenslaufDataStore _store;

        private LebenslaufBerufserfahrungListViewModel()
        {

            Items = [];
            _store = LebenslaufDataStore.Instance;
            _store.LebenslaufBerufItemChanged += _store_LebenslaufBerufItemChanged;
            AddCommand = new DelegateCommand(o => isValid(), o =>
            {
                var toadd = new LebenslaufBerufserfahrungItemViewModel(Tätigkeit, VonBis, Arbeitgeber, ART, Beschreibung);
                Items.Add(toadd);
                if (Items.Count > 0)
                {
                    _store.OnLebenslaufUnterItemChanged(this,true);
                }
            });
            RemoveCommand = new DelegateCommand(o => 
            {
                if (Items.Count > 0 && SelectedItem != null)
                {
                    Items.Remove(SelectedItem);
                    if(Items.Count > 0)
                    {
                        SelectedItem = Items[0];
                        Items[0].IsSelected = true;
                    }
                    if(Items.Count == 0)
                    {
                        _store.OnLebenslaufUnterItemChanged(this,false);
                    }
                        
                }
            });
        }

        private LebenslaufBerufserfahrungItemViewModel _selectedItem;

        private void _store_LebenslaufBerufItemChanged(LebenslaufBerufserfahrungItemViewModel obj)
        {

            int index = Items.IndexOf(obj);
            if (index == -1)
                return;
            SelectedItem = obj;
            foreach (var item in Items)
            {
                item.IsSelected = false;
            }
            Items[index].IsSelected = true;
            SelectedItem = Items[index];

        }

        private static LebenslaufBerufserfahrungListViewModel _instance = null!;

        public static LebenslaufBerufserfahrungListViewModel Instance => _instance ?? (_instance = new());

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand RemoveCommand { get; set; }

        public ObservableCollection<LebenslaufBerufserfahrungItemViewModel> Items
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

        public string Tätigkeit
        {
            get => _tätigkeit;
            set
            {
                if (value != _tätigkeit)
                {
                    _tätigkeit = value;
                    RaisPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Arbeitgeber
        {
            get => _arbeitgeber;
            set
            {
                if (value != _arbeitgeber)
                {
                    _arbeitgeber = value;
                    RaisPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string VonBis
        {
            get => _vonBis;
            set
            {
                if (value != _vonBis)
                {
                    _vonBis = value;
                    RaisPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Beschreibung
        {
            get => _beschreibung;
            set
            {
                if (value != _beschreibung)
                {
                    _beschreibung = value;
                    RaisPropertyChanged();
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public LebenslaufBerufserfahrungItemViewModel SelectedItem
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



        private bool isValid()
        {
            return !string.IsNullOrEmpty(Tätigkeit) &&
                !string.IsNullOrEmpty(Arbeitgeber) &&
                !string.IsNullOrEmpty(VonBis)
                && !string.IsNullOrEmpty(Beschreibung);
        }

    }
}
