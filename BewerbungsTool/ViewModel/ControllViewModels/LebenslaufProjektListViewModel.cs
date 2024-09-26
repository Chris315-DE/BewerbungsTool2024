using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel.ControllViewModels
{
    public class LebenslaufProjektListViewModel : BaseViewModel
    {
        private LebenslaufProjektListViewModel() { }
        private static LebenslaufProjektListViewModel instance;

       public static LebenslaufProjektListViewModel Instance { get => instance ?? (instance = new()); }

    } 
}
