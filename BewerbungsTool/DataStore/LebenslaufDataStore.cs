using BewerbungsTool.ViewModel.ControllViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.DataStore
{
    public class LebenslaufDataStore
    {
        private LebenslaufDataStore() { }
        private static LebenslaufDataStore _instance;

        public static LebenslaufDataStore Instance => _instance ?? (_instance = new LebenslaufDataStore());

        public event Action<LebenslaufStatsItemViewModel> LebenslaufStatItemChanged;

        public void OnSelectedLebenslaufStatItemChanged(LebenslaufStatsItemViewModel model)
        {
            LebenslaufStatItemChanged?.Invoke(model);
        }

    }

}
