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



        public LebenslaufPersonenInfoViewModel()
        {

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
                }
            }
        }

    }
}
