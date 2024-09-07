using BewerbungsTool.Contracts;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.Model
{
    public class AnschreibenTemplate : IAnschreibenTemplate<AnschreibenTemplate>
    {

        public AnschreibenTemplate(string Id)
        {

            TemplateID = Id;

        }


        public string TemplateID { get; set; }
        public string Einleitung { get; set; }
        public string Hauptteil { get; set; }
        public string Abschluss { get; set; }
        public DateTime StartDatum { get; set; }

        public bool Equals(AnschreibenTemplate? other)
        {
            if (other == null) return false;
            if (other.TemplateID != this.TemplateID)
                return false;
            return true;
        }

        public override bool Equals(object? obj)
        {

            return Equals(obj as AnschreibenTemplate);
        }

        public override int GetHashCode()
        {
            return TemplateID.GetHashCode();
        }

        public override string ToString()
        {
            return TemplateID;
        }

    }
}
