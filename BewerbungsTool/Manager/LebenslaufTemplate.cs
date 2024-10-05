using BewerbungsTool.Controlls;
using BewerbungsTool.ViewModel.ControllViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.Manager
{
    public class LebenslaufTemplate : IEquatable<LebenslaufTemplate>
    {

        public ObservableCollection<LebenslaufBerufserfahrungItemViewModel> Berufserfahrung;
        public ObservableCollection<LebenslaufBildungsItemViewModel> Bildung;
        public ObservableCollection<LebenslaufKontaktItemViewModel> Kontakt;
        public LebenslaufPersonenInfoViewModel PersonenInfo;
        public ObservableCollection<LebenslaufProjektItemViewModel> Projekt;
        public ObservableCollection<LebenslaufStatsItemViewModel> Stats;



        public string Name;

        public LebenslaufTemplate(string templateName)
        {
            Name = templateName;
            Berufserfahrung = LebenslaufBerufserfahrungListViewModel.Instance.Items;
            Bildung = LebenslaufBildungsListViewModel.Instance.Items;
            Kontakt = LebenslaufKontaktListViewModel.Instance.Items;
            Projekt = LebenslaufProjektListViewModel.Instance.Items;
            Stats = LebenslaufStatListViewModel.Instance.LebenslaufStatList;
            PersonenInfo = LebenslaufPersonenInfoViewModel.Instance;


        }



        //Wird für NewtonsoftVerwendet
        public LebenslaufTemplate()
        {

        }


        public LebenslaufTemplate(string templateName, ObservableCollection<LebenslaufBerufserfahrungItemViewModel> berufserfahrung,
          ObservableCollection<LebenslaufBildungsItemViewModel> bildung, ObservableCollection<LebenslaufKontaktItemViewModel> kontakt,
          LebenslaufPersonenInfoViewModel personenInfo, ObservableCollection<LebenslaufProjektItemViewModel> projekt, ObservableCollection<LebenslaufStatsItemViewModel> stats)
        {
            Name = templateName;
            Berufserfahrung = berufserfahrung;
            Bildung = bildung;
            Kontakt = kontakt;
            PersonenInfo = personenInfo;
            Projekt = projekt;
            Stats = stats;

        }


        public override string ToString()
        {
            return Name;
        }

        public bool Equals(LebenslaufTemplate? other)
        {
            if (other == null) return false;
            if (other.Name == this.Name) return true;
            return false;
        }

        public override bool Equals(object? obj)
        {
           

            var other = obj as LebenslaufTemplate;
            return Equals(other);

        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }


    }






}
