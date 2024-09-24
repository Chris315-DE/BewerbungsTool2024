using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufBerufserfahrungItemViewModel : BaseViewModel
    {

        private LebenslaufDataStore _dataStore;

        private bool _IsSelected;
        private string _Beruf = null!;
        private string _VonBis = null!;
        private string _Arbeitgeber = null!;
        private string _Art = null!;
        private string _Kurzbeschreibung = null!;


        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                if (value != _IsSelected)
                {
                    _IsSelected = value;
                    RaisPropertyChanged();
                }
            }
        }
        public string Beruf
        {
            get => _Beruf;
            set
            {
                if (value != _Beruf)
                {
                    _Beruf = value;
                    RaisPropertyChanged();
                }

            }
        }

        public string VonBis
        {
            get => _VonBis;
            set
            {
                if (value != _VonBis)
                {
                    _VonBis = value;
                    RaisPropertyChanged();
                }

            }
        }
        public string Arbeitgeber
        {
            get => _Arbeitgeber;
            set
            {
                if (value != _Arbeitgeber)
                {
                    _Arbeitgeber = value;
                    RaisPropertyChanged();
                }

            }
        }
        public string Art
        {
            get => _Art;
            set
            {
                if (value != _Art)
                {
                    _Art = value;
                    RaisPropertyChanged();
                }

            }
        }
        public string Kurzbeschreibung
        {
            get => _Kurzbeschreibung;
            set
            {
                if (value != _Kurzbeschreibung)
                {
                    _Kurzbeschreibung = value;
                    RaisPropertyChanged();
                }

            }
        }


        public LebenslaufBerufserfahrungItemViewModel(string beruf, string vonBis,
            string arbeitgeber, string art, string kurzbeschreibung)
        {
            IsSelected = false;
            Beruf = beruf;
            VonBis = vonBis;
            Arbeitgeber = arbeitgeber;
            Art = art;
            Kurzbeschreibung = kurzbeschreibung;
            _dataStore = LebenslaufDataStore.Instance;

            SelectCommand = new DelegateCommand(o =>
            {
                _dataStore.OnSelectedLebenslaufBerufItemChanged(this);
              
            });

        }




        public DelegateCommand SelectCommand { get; set; }
    }
}
