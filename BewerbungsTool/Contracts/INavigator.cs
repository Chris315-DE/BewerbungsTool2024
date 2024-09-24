using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BewerbungsTool.Contracts
{
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModel { get; }

        BaseViewModel LebenslaufUnterViewModel { get; set; }

        static INavigator Instance { get; }
    }
}
