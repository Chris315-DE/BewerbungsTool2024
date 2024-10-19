using System.Text;

namespace BewerbungsTool.LatexService
{
    internal class CvConstantenStore
    {

        private const string LATEX_META_SKILLS_KOMMENTAR = @"
%---------------------------------------------------------------------------------------
%	META SKILLS
%----------------------------------------------------------------------------------------";

        private const string LATEX_META_BILDUNG_KOMMENTAR = @"
%---------------------------------------------------------------------------------------
%	EDUCATION
%----------------------------------------------------------------------------------------";

        private const string LATEX_END_LEFT_START_RIGHT = @"
\end{leftcolumn}
\begin{rightcolumn}";


        private const string LATEX_END = @"
\end{rightcolumn}
\end{paracol}
\end{document}";


        private const string LTEX_WORK_EXP_COMMENT = @"
%---------------------------------------------------------------------------------------
%	WORK EXPERIENCE
%----------------------------------------------------------------------------------------

\vspace{10pt}
\cvsection{Berufserfahrung}
\vspace{4pt}
";



        private const string HOTFIX = @"
\mbox{}
\vfill
";


        public static StringBuilder SkillsKommentar = new StringBuilder().Append(LATEX_META_SKILLS_KOMMENTAR);

        public static StringBuilder BildungKommentar = new StringBuilder().Append(LATEX_META_BILDUNG_KOMMENTAR);

        public static StringBuilder EndLeftStartRight = new StringBuilder().Append(LATEX_END_LEFT_START_RIGHT);

        public static StringBuilder END = new StringBuilder().AppendLine(LATEX_END);

        public static StringBuilder WorkExpKommentar = new StringBuilder().Append(LTEX_WORK_EXP_COMMENT);

        public static StringBuilder GetHotfixLines(int amount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < amount; i++)
            {
                sb.Append(HOTFIX);
            }

            return sb;
        }
    }
}



