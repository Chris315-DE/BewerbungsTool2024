using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.LatexService.Refactoring
{
    public abstract class CVItemsBaseBuilder
    {
        internal CVSeitenverhältnisManager manager;


        protected CVItemsBaseBuilder()
        {
            manager = CVSeitenverhältnisManager.Instance;
        }
    }
}
