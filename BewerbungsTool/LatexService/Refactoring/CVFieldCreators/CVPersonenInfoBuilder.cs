using BewerbungsTool.ViewModel.ControllViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.LatexService.Refactoring
{
    public class CVPersonenInfoBuilder
    {


        const int LEFTSEITENVALUE = 10;

        LebenslaufPersonenInfoViewModel _viewModel;
        public StringBuilder LTexInfoBuilder;
        private CVSeitenverhältnisManager manager = CVSeitenverhältnisManager.Instance;
        public CVPersonenInfoBuilder(LebenslaufPersonenInfoViewModel personenInfos)
        {
            LTexInfoBuilder = new StringBuilder();
            _viewModel = personenInfos ?? throw new ArgumentNullException(nameof(personenInfos));
            name = personenInfos.Name ?? string.Empty;
            geburtsDaten = personenInfos.GeburtsDaten ?? string.Empty;
            beruf = personenInfos.Beruf ?? string.Empty;
            nationalität = personenInfos.Nationalität ?? string.Empty;
            familienstand = personenInfos.Familienstand ?? string.Empty;

            InitBuilder();


        }



        private string? name;
        private string? geburtsDaten;
        private string? beruf;
        private string? nationalität;
        private string? familienstand;


        private void InitBuilder()
        {
            manager.UpLeftSideValue(LEFTSEITENVALUE);
            LTexInfoBuilder.AppendLineOnValueChanged(@"\fcolorbox{white}{white}{\begin{minipage}[c][1.5cm][c]{1\mpwidth}")
                .AppendOnValueChanged(@"\LARGE{\textbf{\textcolor{maincol}{")
                .AppendOnValueChanged(name).AppendLineOnValueChanged(@"}}} \\[2pt]")
                .AppendOnValueChanged(@"\normalsize{ \textcolor{maincol} {").AppendOnValueChanged(beruf).AppendLineOnValueChanged("}}")
                .AppendLineOnValueChanged(@"\end{minipage}} \\")
                .AppendOnValueChanged(@"\icontext{CaretRight}{12}{").AppendOnValueChanged(geburtsDaten).AppendLineOnValueChanged(@"}{black}\\[6pt]")
                .AppendOnValueChanged(@"\icontext{CaretRight}{12}{").AppendOnValueChanged(nationalität).AppendLineOnValueChanged(@"}{black}\\[6pt]")
                .AppendOnValueChanged(@"\icontext{CaretRight}{12}{").AppendOnValueChanged(familienstand).AppendLineOnValueChanged(@"}{black}\\[6pt]");
            LTexInfoBuilder.AppendLineOnValueChanged(string.Empty);

        }



        public override string ToString()
        {
            return $"{nameof(name)}: {name},\n{nameof(geburtsDaten)}: {geburtsDaten},\n{nameof(beruf)}: {beruf},\n" +
                $"{nameof(nationalität)}: {nationalität},\n{nameof(familienstand)} : {familienstand}";
        }





    }
}
