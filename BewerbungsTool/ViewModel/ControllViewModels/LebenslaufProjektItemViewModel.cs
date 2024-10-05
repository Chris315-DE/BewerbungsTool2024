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


        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    RaisPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Dieser Constructor darf nur durch <see cref="JsonConvert.DeserializeObject{T}(string, JsonSerializerSettings?)"/> 
        /// verwendet werden!
        /// </summary>
        private LebenslaufProjektItemViewModel()
        {
            _store = LebenslaufDataStore.Instance;
            SelectedCommand = new DelegateCommand(o =>
            {
                _store.OnLebenslaufProjektItemChanged(this);
            });
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
