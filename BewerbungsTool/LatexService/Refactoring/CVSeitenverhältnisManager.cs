using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.LatexService.Refactoring
{
    public class CVSeitenverhältnisManager
    {

        public int LeftSideValue { get; private set; }
        public int RightSideValue { get; private set; }


        const int LEFT_SIDE_MAX_VALUE = 100;
        const int RIGHT_SIDE_MAX_VALUE = 100;
        private CVSeitenverhältnisManager()
        {
            LeftSideValue = 0;
            RightSideValue = 0;
        }

        private static CVSeitenverhältnisManager _instance;

        public static CVSeitenverhältnisManager Instance => _instance ?? (_instance = new CVSeitenverhältnisManager());

        public int UpLeftSideValue(int value)
        {
            LeftSideValue += value;
            LeftValueChanged?.Invoke(LeftSideValue);
            return LeftSideValue;
            
        }

        public int UpRightSideValue(int value)
        {
            RightSideValue += value;
            RightValueChanged?.Invoke(RightSideValue);
            return RightSideValue;
        }

        public event Action<int> LeftValueChanged;

        public event Action<int> RightValueChanged;




    }
}
