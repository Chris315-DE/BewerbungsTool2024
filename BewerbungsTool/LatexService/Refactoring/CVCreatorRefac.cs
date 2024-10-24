using BewerbungsTool.LatexService.Refactoring;
using BewerbungsTool.LatexService.Refactoring.CVFieldCreators;
using BewerbungsTool.Manager;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace BewerbungsTool.LatexService
{
    public class CVCreatorRefac
    {
        public StringBuilder TexCVBuilder = new StringBuilder();
        public CVSeitenverhältnisManager seitenManager;
        private LebenslaufTemplate _lebenslauftemplate;
        public CVSkillsBuilder _skillBuilder { get; private set; }
        private string FullPath = null!;





        public CVCreatorRefac(LebenslaufTemplate lebenslauf, string fullpath)
        {



            seitenManager = CVSeitenverhältnisManager.Instance;
            if (string.IsNullOrEmpty(fullpath))
                throw new ArgumentNullException(nameof(fullpath));
            _lebenslauftemplate = lebenslauf ?? throw new ArgumentNullException(nameof(lebenslauf));
            TexCVBuilder.AppendLine(CVSetupClass.Setup);
            TexCVBuilder.AppendLine(new CVPersonenInfoBuilder(_lebenslauftemplate.PersonenInfo).LTexInfoBuilder.ToString());
            TexCVBuilder.AppendLine(CvConstantenStore.SkillsKommentar.ToString());
            TexCVBuilder.AppendLine(string.Empty);

            _skillBuilder = new(_lebenslauftemplate.Stats);
            TexCVBuilder.AppendLine(_skillBuilder.CVSkills.ToString());
            TexCVBuilder.AppendLine(CvConstantenStore.BildungKommentar.ToString());
            TexCVBuilder.AppendLine(new CVBildungsBuilder(_lebenslauftemplate.Bildung).CvStringBuilder.ToString());

        }



        public string editfileEx(string path)
        {

            FullPath = Path.ChangeExtension(path, "tex");
            return FullPath;
        }


    }

}



