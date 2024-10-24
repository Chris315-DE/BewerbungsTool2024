using BewerbungsTool.ViewModel.ControllViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.LatexService.Refactoring.CVFieldCreators
{
    public class CVBildungsBuilder : CVItemsBaseBuilder
    {
        private ObservableCollection<LebenslaufBildungsItemViewModel> _items;
        public StringBuilder CvStringBuilder { get; private set; }

        public CVBildungsBuilder(ObservableCollection<LebenslaufBildungsItemViewModel> items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
            CvStringBuilder = new StringBuilder();
            InitStringBuilder();

        }

        private void InitStringBuilder()
        {
            manager.UpLeftSideValue(10);

            CvStringBuilder.AppendLineOnValueChanged(@"\newline").AppendLineOnValueChanged(string.Empty).AppendLineOnValueChanged(@"\cvsection{Bildung}");


        
            string Event = @"\cvmetaevent";


            foreach (var item in _items)
            {
                CvStringBuilder.AppendLineOnValueChanged(Event);
                CvStringBuilder.AppendLineOnValueChanged("{" + item.VonBis + "}");
                CvStringBuilder.AppendLineOnValueChanged("{" + item.Was + "}");
                CvStringBuilder.AppendLineOnValueChanged("{" + item.Wo + "}");
                CvStringBuilder.AppendLineOnValueChanged(@"{\textit{" + item.Beschreibung + "}");
                manager.UpLeftSideValue(5);
               
            }


        }





    }
}
