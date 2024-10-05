using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufPersonenInfoViewModel : BaseViewModel
    {
        private LebenslaufDataStore _store;
        private static LebenslaufPersonenInfoViewModel _instance;

        public static LebenslaufPersonenInfoViewModel Instance => _instance ?? (_instance = new LebenslaufPersonenInfoViewModel());



        private LebenslaufPersonenInfoViewModel()
        {
            _store = LebenslaufDataStore.Instance;
        }

        private string _Name;
        private string _Beruf;
        private string _GeburtsDaten;
        private string _Nationalität;
        private string _Familienstand;


        public string Name
        {
            get => _Name; set
            {
                if (value != _Name)
                {
                    _Name = value;
                    RaisPropertyChanged();
                    IsValid();
                }
            }
        }
        public string Beruf
        {
            get => _Beruf; set
            {
                if (value != _Beruf)
                {
                    _Beruf = value;
                    RaisPropertyChanged();
                    IsValid();
                }
            }
        }
        public string GeburtsDaten
        {
            get => _GeburtsDaten; set
            {
                if (value != _GeburtsDaten)
                {
                    _GeburtsDaten = value;
                    RaisPropertyChanged();
                    IsValid();
                }
            }
        }
        public string Nationalität
        {
            get => _Nationalität; set
            {
                if (value != _Nationalität)
                {
                    _Nationalität = value;
                    RaisPropertyChanged();
                    IsValid();
                }
            }
        }
        public string Familienstand
        {
            get => _Familienstand; set
            {
                if (value != _Familienstand)
                {
                    _Familienstand = value;
                    RaisPropertyChanged();
                    IsValid();
                }
            }
        }


        void IsValid()
        {
            if (!string.IsNullOrEmpty(_Name) && !string.IsNullOrEmpty(Beruf) && !string.IsNullOrEmpty(GeburtsDaten) &&
                !string.IsNullOrEmpty(Nationalität) && !string.IsNullOrEmpty(Familienstand))
            {
                _store.OnLebenslaufUnterItemChanged(this, true);
            }
            else
            {
                _store.OnLebenslaufUnterItemChanged(this, false);
            }

        }

        internal void SetInstance(LebenslaufPersonenInfoViewModel? personenInfo)
        {

            if (personenInfo is null)
            {
                Familienstand = string.Empty;
                Name = string.Empty;
                Beruf = string.Empty;
                GeburtsDaten = string.Empty;
                Nationalität = string.Empty;
            }
            else
            {
                Familienstand = personenInfo.Familienstand;
                Nationalität = personenInfo.Nationalität;
                GeburtsDaten = personenInfo.GeburtsDaten;
                Beruf = personenInfo.Beruf;
                Name = personenInfo.Name;
            }
        }
    }
}


