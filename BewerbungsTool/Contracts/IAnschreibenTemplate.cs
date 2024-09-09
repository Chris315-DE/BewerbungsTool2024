using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.Contracts
{
    public interface IAnschreibenTemplate<T> : IEquatable<T> where T : class
    {
        string TemplateID { get; set; }

        public string Headder {  get; set; }


        string Einleitung {  get; set; }

        string Hauptteil {  get; set; }

        string Abschluss {  get; set; }

        DateTime StartDatum { get; set; }

        string StartDatumSatz { get; set; }
        


    }
}
