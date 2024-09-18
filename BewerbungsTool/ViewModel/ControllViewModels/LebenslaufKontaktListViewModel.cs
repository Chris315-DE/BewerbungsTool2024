using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System.Collections.ObjectModel;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufKontaktListViewModel : BaseViewModel
    {
        #region private Fields
        private ObservableCollection<LebenslaufKontaktItemViewModel> _items;
        private string _SelectedIcon;
        private string _TagValue;
        private string _Beschreibung;
        private LebenslaufKontaktItemViewModel _selectedItem;


        #endregion

        #region Propertys 

        public ObservableCollection<LebenslaufKontaktItemViewModel> Items
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

        public LebenslaufKontaktItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    RaisPropertyChanged();
                    RemoveItemCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string SelectedIcon
        {
            get => _SelectedIcon;
            set
            {
                if (value != _SelectedIcon)
                {
                    _SelectedIcon = value;

                    SwitchTagValue(_SelectedIcon);

                    RaisPropertyChanged();
                    AddItemCommand.RaiseCanExecuteChanged();
                }
            }
        }


        public string TagValue
        {
            get => _TagValue;
            set
            {
                if (value != _TagValue)
                {
                    _TagValue = value;
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
                    AddItemCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public List<string> Symbole { get; set; }

        private LebenslaufDataStore dataStore;

        public DelegateCommand AddItemCommand { get; set; }

        public DelegateCommand RemoveItemCommand { get; set; } 
        #endregion

        #region Ctor

        private LebenslaufKontaktListViewModel()
        {
            Symbole = [];
            Items = [];
            InitUnicode();
            dataStore = LebenslaufDataStore.Instance;

            dataStore.LebenslaufKontaktItemChanged += DataStore_LebenslaufKontaktItemChanged;

            AddItemCommand = new DelegateCommand(o => isValid(), o =>
            {
                Items.Add(new LebenslaufKontaktItemViewModel(SelectedIcon, Beschreibung));
                SelectedIcon = String.Empty;
                Beschreibung = String.Empty;

            });

            RemoveItemCommand = new DelegateCommand(o => SelectedItem != null, o => 
            {
                Items.Remove(SelectedItem);
                if (Items.Count > 0)
                {
                    SelectedItem = Items[0];
                    Items[0].IsSelected = true;
                }
                else
                {
                    SelectedItem = null;
                }
            });
            

        }

        private void DataStore_LebenslaufKontaktItemChanged(LebenslaufKontaktItemViewModel obj)
        {
            int index = Items.IndexOf(obj);
            foreach (var item in Items)
            {
                item.IsSelected = false;
            }
            Items[index].IsSelected = true;
            SelectedItem = obj;
        }

        private static LebenslaufKontaktListViewModel _instance;

        public static LebenslaufKontaktListViewModel Instance => _instance ?? (_instance = new());

        #endregion

        #region Private Methods

        private void SwitchTagValue(string selectedIcon)
        {

            switch (selectedIcon)
            {

                //GitHub
                case "\uf09b":
                    TagValue = "GitHub Url:";
                    break;
                //Mail
                case "\uf0e0":
                    TagValue = "Mail Adresse:";
                    break;
                //Phone
                case "\uf10b":
                    TagValue = "PhoneNumber:";
                    break;
                //Xing
                case "\uf168":
                    TagValue = "Xing Url:";
                    break;
                //Linkedin
                case "\uf0e1":
                    TagValue = "Linkedin Url:";
                    break;
                //Homepage
                case "\uf015":
                    TagValue = "Hompage Url:";
                    break;
                //Map-Marker
                case "\uf041":
                    TagValue = "Straße\nPLZ und Stadt";
                    break;
                default:
                    TagValue = "NV";
                    break;
            }



        }
        private void InitUnicode()
        {
            //Start
            Symbole.Add(String.Empty);
            //GitHub
            Symbole.Add("\uf09b");
            //Mail
            Symbole.Add("\uf0e0");
            //Phone
            Symbole.Add("\uf10b");
            //XING
            Symbole.Add("\uf168");
            //Linkedin
            Symbole.Add("\uf0e1");
            //Homepage
            Symbole.Add("\uf015");
            //Map-Marker
            Symbole.Add("\uf041");

        }

        private bool isValid()
        {
            if (!string.IsNullOrEmpty(SelectedIcon) && !string.IsNullOrEmpty(Beschreibung))
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}


