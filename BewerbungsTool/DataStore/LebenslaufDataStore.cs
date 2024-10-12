using BewerbungsTool.Controlls;
using BewerbungsTool.MvvmBasics;
using BewerbungsTool.ViewModel.ControllViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BewerbungsTool.DataStore
{
    public class LebenslaufDataStore
    {
        private LebenslaufDataStore() { }
        private static LebenslaufDataStore _instance;

        public static LebenslaufDataStore Instance => _instance ?? (_instance = new LebenslaufDataStore());

        public event Action<LebenslaufStatsItemViewModel> LebenslaufStatItemChanged;
        public event Action<LebenslaufKontaktItemViewModel> LebenslaufKontaktItemChanged;
        public event Action<LebenslaufBerufserfahrungItemViewModel> LebenslaufBerufItemChanged;
        public event Action<LebenslaufBildungsItemViewModel> LebenslaufBildungsItemChanged;
        public event Action<LebenslaufProjektItemViewModel> LebenslaufProjektItemChanged;

        public event Action<BaseViewModel,bool> LebenslaufUnderItemIsChanged;

        public event Action<LebenslaufHobbyItemViewModel> LebenslaufHobbyItemChanged;


        public void OnLebenslaufHobbyChanged(LebenslaufHobbyItemViewModel viewModel)
        {
            LebenslaufHobbyItemChanged?.Invoke(viewModel);
        }



        public void OnLebenslaufProjektItemChanged(LebenslaufProjektItemViewModel model)
        {
            LebenslaufProjektItemChanged?.Invoke(model);
        }

        public void OnLebenslaufUnterItemChanged(BaseViewModel model,bool state)
        {
            LebenslaufUnderItemIsChanged?.Invoke(model,state);
        }



        public void OnSelectedLebenslaufBildungsItemChanged(LebenslaufBildungsItemViewModel model)
        {
            LebenslaufBildungsItemChanged?.Invoke(model);
        }


        public void OnSelectedLebenslaufBerufItemChanged(LebenslaufBerufserfahrungItemViewModel model)
        {
            LebenslaufBerufItemChanged?.Invoke(model);
        }


        public void OnSelectedLebenslaufStatItemChanged(LebenslaufStatsItemViewModel model)
        {
            LebenslaufStatItemChanged?.Invoke(model);
        }

        public void OnSelectedLebenslaufKontaktItemChanged(LebenslaufKontaktItemViewModel model) 
        {
            LebenslaufKontaktItemChanged?.Invoke(model);
        }


    }

}
