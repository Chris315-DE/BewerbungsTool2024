using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufProjektItemViewModel : BaseViewModel
    {
        LebenslaufDataStore _store;
        public DelegateCommand SelectedCommand { get; set; }

        private string _ProjektName;
        private string _Beschreibung;
        public string ProjektName
        {
            get => _ProjektName;
            set
            {
                if (value != _ProjektName)
                {
                    _ProjektName = value;
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






        public LebenslaufProjektItemViewModel(string projektName, string beschreibung)
        {
            _store = LebenslaufDataStore.Instance;
            SelectedCommand = new DelegateCommand(o =>
            {
                _store.OnLebenslaufProjektItemChanged(this);
            });
            ProjektName = projektName;
            Beschreibung = beschreibung;
        }

    }
}
