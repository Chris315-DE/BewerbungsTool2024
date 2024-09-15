using BewerbungsTool.LatexService;
using BewerbungsTool.MvvmBasics;
using BewerbungsTool.ViewModel.ControllViewModels;

namespace BewerbungsTool.ViewModel
{
    public class ÜbersichtsViewModel : BaseViewModel 
    {
        private ÜbersichtsViewModel()
        {
            TestLatexCommand = new(o =>
            {
                CoverLetterCreator creator = new CoverLetterCreator(AnschreibenViewModel.Instance.SelectedTemplate);
            });

            LebenslaufStatsListViewModel = LebenslaufStatListViewModel.Instance;
            LebenslaufPersonenInfoViewModel = new();

        }
        private static ÜbersichtsViewModel _instance;

        public static ÜbersichtsViewModel Instance => (_instance ?? new ÜbersichtsViewModel());

        public LebenslaufStatListViewModel LebenslaufStatsListViewModel { get; set; }

        public LebenslaufPersonenInfoViewModel LebenslaufPersonenInfoViewModel { get; set; }

        public DelegateCommand TestLatexCommand { get; set; }
    }


}
