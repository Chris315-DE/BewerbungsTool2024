using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufBildungsItemViewModel : BaseViewModel
    {

        private LebenslaufDataStore _data;

        private string _VonBis = null!;
        private string _Was = null!;
        private string _Wo = null!;
        private string _Beschreibung = null!;
        public DelegateCommand SelectCommand { get; set; }


        public LebenslaufBildungsItemViewModel(string vonbis, string was, string wo, string beschreibung)
        {
            _data = LebenslaufDataStore.Instance;
            SelectCommand = new DelegateCommand(o => { _data.OnSelectedLebenslaufBildungsItemChanged(this); });

            Beschreibung = beschreibung;
            Was = was;
            VonBis = vonbis;
            Wo = wo;

        }

        /// <summary>
        /// Dieser Constructor darf nur durch <see cref="JsonConvert.DeserializeObject{T}(string, JsonSerializerSettings?)"/> 
        /// verwendet werden!
        /// </summary>
        private LebenslaufBildungsItemViewModel()
        {
            _data = LebenslaufDataStore.Instance;
            SelectCommand = new DelegateCommand(o => { _data.OnSelectedLebenslaufBildungsItemChanged(this); });

        }



        private bool _IsSelected;

        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
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


    }
}
