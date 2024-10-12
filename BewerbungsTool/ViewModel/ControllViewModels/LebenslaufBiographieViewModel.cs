using BewerbungsTool.DataStore;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufBiographieViewModel : BaseViewModel
    {

        LebenslaufDataStore _datastore;

        private static LebenslaufBiographieViewModel _instance;
        private LebenslaufBiographieViewModel()
        {
            _datastore = LebenslaufDataStore.Instance;



        }
        public static LebenslaufBiographieViewModel Instance => _instance ?? (_instance = new());


        private string _Biography;

        public string Biography
        {
            get => _Biography;
            set
            {
                if (value != _Biography) 
                {
                    _Biography = value;
                    RaisPropertyChanged();
                    if(string.IsNullOrEmpty(value))
                    {
                        _datastore.OnLebenslaufUnterItemChanged(this,false);

                    }
                    else
                    {
                        _datastore.OnLebenslaufUnterItemChanged(this,true);
                    }
                }
            }
        }


    }
}
