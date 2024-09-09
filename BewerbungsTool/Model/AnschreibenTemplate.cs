﻿using BewerbungsTool.Contracts;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.Model
{
    public class AnschreibenTemplate : BaseViewModel, IAnschreibenTemplate<AnschreibenTemplate>
    {

        public AnschreibenTemplate(string Id)
        {

            TemplateID = Id;

        }
        private string _StartDatumSatz;




        public string StartDatumSatz
        {
            get => _StartDatumSatz;
             set
            {
                if (value != _StartDatumSatz)
                {
                    _StartDatumSatz = value;
                    RaisPropertyChanged();
                }

            }
        }
        public string TemplateID { get; set; }
        public string Einleitung { get; set; }
        public string Hauptteil { get; set; }
        public string Abschluss { get; set; }

        public string Headder { get; set; }
        public DateTime StartDatum
        {
            get => _StartDatum;
            set
            {
                if (value != _StartDatum)
                {
                    _StartDatum = value;
                    RaisPropertyChanged();

                    if (StartDatum.ToShortDateString() == DateTime.Today.ToShortDateString())
                    {
                        StartDatumSatz = "Da ich monentan nicht vertraglich gebunden bin, ist ein kurzfristiger Eintritt möglich.";
                    }
                    else
                    {
                        StartDatumSatz = $"Die Arbeitsaufnahme bei ihnen  ist für mich ab dem {StartDatum.ToShortDateString()} möglich.";

                    }

                    RaisPropertyChanged(nameof(StartDatumSatz));

                }
            }
        }
        private DateTime _StartDatum;

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
