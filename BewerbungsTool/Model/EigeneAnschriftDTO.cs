using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.Model
{
    public class EigeneAnschriftDTO
    {
        public string EigeneMail { get; set; }
        public string EigeneName { get; set; }
        public string EigeneStraße { get; set; }
        public string EigenePlzStadt { get; set; }
        public string EigeneTel { get; set; }


        public EigeneAnschriftDTO(string name, string straße, string plz, string mail = "", string tel = "")
        {
            EigeneName = name;
            EigeneStraße = straße;
            EigenePlzStadt = plz;
            EigeneMail = mail;
            EigeneTel = tel;
        }
    }



}
