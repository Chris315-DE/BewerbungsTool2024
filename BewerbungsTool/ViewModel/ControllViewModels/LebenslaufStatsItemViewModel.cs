using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufStatsItemViewModel : BaseViewModel
    {

        LebenslaufDataStore dataStore;

        public LebenslaufStatsItemViewModel()
        {


            dataStore = LebenslaufDataStore.Instance;
            isSelected = false;
            SliderValue = "1";


            IsSelectedCommand = new DelegateCommand(o =>
            {
                dataStore.OnSelectedLebenslaufStatItemChanged(this);
            });


        }

        private bool _isSelected;
        private string _SliderValue;
        private string _Fähigkeit;

        public bool isSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisPropertyChanged();
                }
            }
        }
        public string SliderValue
        {
            get => _SliderValue;
            set
            {
                if (_SliderValue != value)
                {
                    _SliderValue = value;
                    RaisPropertyChanged();
                    dataStore.OnSelectedLebenslaufStatItemChanged(this);
                }
            }
        }
        public string Fähigkeit
        {
            get => _Fähigkeit;
            set
            {
                if (value != _Fähigkeit)
                {
                    _Fähigkeit = value;
                    RaisPropertyChanged();
                    dataStore.OnSelectedLebenslaufStatItemChanged(this);
                }
            }
        }


        public DelegateCommand IsSelectedCommand { get; set; }

    }
}
