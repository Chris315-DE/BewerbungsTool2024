using BewerbungsTool.ViewModel.ControllViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.LatexService.Refactoring.CVFieldCreators
{
    public class CVSkillsBuilder
    {
        private ObservableCollection<LebenslaufStatsItemViewModel> _vm;

        public List<LebenslaufStatsItemViewModel> SortedList { get; private set; }
        public StringBuilder CVSkills { get; private set; } = null!;
        private CVSeitenverhältnisManager manager = CVSeitenverhältnisManager.Instance;
        public CVSkillsBuilder(ObservableCollection<LebenslaufStatsItemViewModel> vm)
        {
            _vm = vm ?? throw new ArgumentNullException(nameof(vm));
            
            InitStringBuilder();
        }





        private void InitStringBuilder()
        {
            CVSkills = new StringBuilder();
            SortedList = _vm.OrderByDescending(o => o.SliderValue).ToList();
            CVSkills.AppendLineOnValueChanged(@"\cvsection{Fähigkeiten}");
            string format = string.Empty;
            foreach (var item in SortedList)
            {
                format = FormatStatToLTEX(item.Fähigkeit, ConvertValue(item.SliderValue), item.SliderValue);
                CVSkills.AppendLineOnValueChanged($"{format}");
                manager.UpLeftSideValue(2);
                CVSkills.AppendLineOnValueChanged(string.Empty);
            }
            CVSkills.AppendLineOnValueChanged(string.Empty);

        }



        private string ConvertValue(string value)
        {
            switch (value)
            {
                case "1":
                    return "Anfänger";
                case "2":
                    return "Anfänger+";
                case "3":
                    return "Grundkenntnisse";
                case "4":
                    return "Fortgeschritten";
                case "5":
                    return "Kompetent";
                case "6":
                    return "Geübt";
                case "7":
                    return "Erfahren";
                case "8":
                    return "Versiert";
                case "9":
                    return "Profi";
                case "10":
                    return "Experte";
                default:
                    return "Unwissend";

            }
        }

        private string FormatStatToLTEX(string statname, string value, string score)
          => @"\cvskill{" + statname + @"} {" + value + "} {" + (float.Parse(score) / 10).ToString().Replace(',', '.') + @"} \\[-2pt]";

    }
}
