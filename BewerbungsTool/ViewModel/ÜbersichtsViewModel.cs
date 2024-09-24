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
            LebenslaufPersonenInfoViewModel = LebenslaufPersonenInfoViewModel.Instance;

            TestViewModel = LebenslaufKontaktListViewModel.Instance;
            TestVM = LebenslaufBerufserfahrungListViewModel.Instance;
            testModel = LebenslaufBildungsListViewModel.Instance;

        }
        private static ÜbersichtsViewModel _instance;

        public static ÜbersichtsViewModel Instance => (_instance ?? new ÜbersichtsViewModel());

        public LebenslaufStatListViewModel LebenslaufStatsListViewModel { get; set; }

        public LebenslaufPersonenInfoViewModel LebenslaufPersonenInfoViewModel { get; set; }

        public DelegateCommand TestLatexCommand { get; set; }

        public LebenslaufBildungsListViewModel testModel { get; set; }

        public LebenslaufBerufserfahrungListViewModel TestVM { get; set; }


        public LebenslaufKontaktListViewModel TestViewModel { get; set; }

    }


}
