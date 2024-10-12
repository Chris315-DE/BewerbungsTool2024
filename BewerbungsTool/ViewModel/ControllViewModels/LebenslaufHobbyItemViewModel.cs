using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufHobbyItemViewModel : BaseViewModel
    {
        private bool isSelected;
        private LebenslaufDataStore _datastore;

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    RaisPropertyChanged();
                }
            }
        }

        public LebenslaufHobbyItemViewModel(string text)
        {
             Text = text;
            _datastore = LebenslaufDataStore.Instance;
            IsSelectedCommand = new DelegateCommand(o => 
            {
                _datastore.OnLebenslaufHobbyChanged(this);
            });

        }



        private LebenslaufHobbyItemViewModel()
        {
            _datastore = LebenslaufDataStore.Instance;
            IsSelectedCommand = new(o =>
            {
                _datastore.OnLebenslaufHobbyChanged(this);
            });
        }



        public DelegateCommand IsSelectedCommand { get; set; }


        private string _text =null!;

        public string Text
        {
            get => _text;
            set
            {
                if (value != _text)
                {
                    _text = value;
                    RaisPropertyChanged();
                }
            }
        }


    }
}
