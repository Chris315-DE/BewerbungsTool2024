using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.LatexService
{
    public class CVCreatorRefac
    {
        private StringBuilder TexCVBuilder = new StringBuilder();


        public CVCreatorRefac()
        {
            TexCVBuilder.Append(CVSetupClass.Setup);
           
        }
    }
}



