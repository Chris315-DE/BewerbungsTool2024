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

            TestViewModel = LebenslaufKontaktListViewModel.Instance;
            testModel = new LebenslaufBerufserfahrungItemViewModel("Demo", "08/2022 - heute", "EGS Konstanz", "Aufgabenbereich: ", ".Net Entwickler mit den schwerpunkten auf Desktop Client Anwendungen (WPF) und .Net-MAUI für Android Apps");

        }
        private static ÜbersichtsViewModel _instance;

        public static ÜbersichtsViewModel Instance => (_instance ?? new ÜbersichtsViewModel());

        public LebenslaufStatListViewModel LebenslaufStatsListViewModel { get; set; }

        public LebenslaufPersonenInfoViewModel LebenslaufPersonenInfoViewModel { get; set; }

        public DelegateCommand TestLatexCommand { get; set; }

        public LebenslaufBerufserfahrungItemViewModel testModel { get; set; }


        public LebenslaufKontaktListViewModel TestViewModel { get; set; }

    }


}
