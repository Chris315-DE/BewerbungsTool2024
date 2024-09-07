using BewerbungsTool.MvvmBasics;

namespace BewerbungsTool.ViewModel
{
    public class ÜbersichtsViewModel : BaseViewModel 
    {
        private ÜbersichtsViewModel() { }

        private static ÜbersichtsViewModel _instance;

        public static ÜbersichtsViewModel Instance => (_instance ?? new ÜbersichtsViewModel());
    }


}
