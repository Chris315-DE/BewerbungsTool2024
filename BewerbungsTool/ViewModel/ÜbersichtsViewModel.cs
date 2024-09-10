using BewerbungsTool.LatexService;
using BewerbungsTool.MvvmBasics;

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
        }

        private static ÜbersichtsViewModel _instance;

        public static ÜbersichtsViewModel Instance => (_instance ?? new ÜbersichtsViewModel());




        public DelegateCommand TestLatexCommand { get; set; }
    }


}
