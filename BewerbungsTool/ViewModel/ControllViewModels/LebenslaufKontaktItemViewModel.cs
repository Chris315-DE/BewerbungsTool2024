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
    public class LebenslaufKontaktItemViewModel : BaseViewModel
    {
        private string _icon = null!;
        private string _content = null!;
        private int _index;


        public int Index
        {
            get => _index;
            set
            {
                if (_index != value)
                {
                    _index = value;
                    RaisPropertyChanged();
                }
            }
        }

        public string Icon
        {
            get => _icon;
            set
            {
                if (value != _icon)
                {
                    _icon = value;
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

        private LebenslaufDataStore dataStore;

        public string Content
        {
            get => _content;
            set
            {
                if (value != _content)
                {
                    _content = value;
                    RaisPropertyChanged();
                }
            }
        }

        public DelegateCommand IsSelectedCommand { get; set; }

        public LebenslaufKontaktItemViewModel(string icon, string content, int index)
        {
            Icon = icon;
            Content = content;
            IsSelected = false;
            dataStore = LebenslaufDataStore.Instance;
            Index = index;
            IsSelectedCommand = new DelegateCommand(o => { dataStore.OnSelectedLebenslaufKontaktItemChanged(this); });

        }

        /// <summary>
        /// Dieser Constructor darf nur durch <see cref="JsonConvert.DeserializeObject{T}(string, JsonSerializerSettings?)"/> 
        /// verwendet werden!
        /// </summary>
        private LebenslaufKontaktItemViewModel()
        {
            dataStore = LebenslaufDataStore.Instance;
            IsSelectedCommand = new DelegateCommand(o => { dataStore.OnSelectedLebenslaufKontaktItemChanged(this); });
        }


    }
}
