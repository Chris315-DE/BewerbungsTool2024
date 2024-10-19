﻿using BewerbungsTool.LatexService;
using BewerbungsTool.Manager;
using BewerbungsTool.Model;
using BewerbungsTool.MvvmBasics;
using BewerbungsTool.ViewModel.ControllViewModels;

namespace BewerbungsTool.ViewModel
{
    public class ÜbersichtsViewModel : BaseViewModel
    {
        private ÜbersichtsViewModel()
        {
            TestCVCommand = new(o =>
            {


                LebenslaufTemplate lebenslaufTemplate = new LebenslaufTemplate();
                string tempname = LebenslaufViewModel.Instance.SelectedTemplate;
                foreach (var item in LebenslaufViewModel.Instance.LebenslaufTemplate)
                {
                    if (tempname == item.Name)
                    {
                        lebenslaufTemplate = item;
                        break;
                    }

                }
                CVCreator creator = new CVCreator(lebenslaufTemplate);

            });

            TestAnschreibenCommand = new(o => 
            {
                var cover = new CoverLetterCreator(AnschreibenViewModel.Instance.SelectedTemplate);
                
            });
          

        }
        private static ÜbersichtsViewModel _instance;

        public DelegateCommand TestAnschreibenCommand { get; set; }

        public static ÜbersichtsViewModel Instance => (_instance ?? new ÜbersichtsViewModel());

      

        public DelegateCommand TestCVCommand { get; set; }

      
    }


}
