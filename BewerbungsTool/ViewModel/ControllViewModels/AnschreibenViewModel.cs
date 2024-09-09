using BewerbungsTool.Contracts;
using BewerbungsTool.Manager;
using BewerbungsTool.Model;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel
{
    public class AnschreibenViewModel : BaseViewModel
    {
        private AnschreibenViewModel()
        {
            BewerbungsTemplate = [];
            TemplateisSelected = false;


            LoadTemplateManager.Instance.GeladeneTemplates.ForEach(template => { BewerbungsTemplate.Add(template); });



            AddTemplateCommand = new DelegateCommand(o => !string.IsNullOrEmpty(NeuesTemplate), o =>
            {

                var TemplatetoADD = new AnschreibenTemplate(NeuesTemplate)
                {
                    StartDatum = DateTime.Now,
                };

                SetnewTemplate(TemplatetoADD, 0);
                NeuesTemplate = string.Empty;


            });


            SaveTemplateCommand = new DelegateCommand(o => TemplateisSelected, o =>
            {
                SaveTemplate(SelectedTemplate);
            });



        }

        private void DebugTemplates()
        {
            BewerbungsTemplate.Add(new AnschreibenTemplate("DEBUG")
            {
                Einleitung = "Hallo ich bin GOD GAMER \nUnd werde euch alle Versklaven HAHA ich bin GodGamer",
                Headder = "Bewerbung als GodGamer",
                Hauptteil = "Ich bin euer MEISTER MUHAHAH",
                Abschluss = "ALso Kniet Nieder",
                StartDatum = DateTime.Now.AddDays(30)
            });


        }

        private bool _TemplateisSelected;

        public bool TemplateisSelected
        {
            get => _TemplateisSelected;
            set
            {
                if (value != _TemplateisSelected)
                {
                    _TemplateisSelected = value;
                    RaisPropertyChanged();
                    SaveTemplateCommand.RaiseCanExecuteChanged();
                }
            }
        }




        private void SetnewTemplate(AnschreibenTemplate templatetoADD, int retry)
        {



            if (BewerbungsTemplate.Contains(templatetoADD))
            {
                int retry1 = retry + 1;
                if (retry > 0)
                {
                    templatetoADD.TemplateID = templatetoADD.TemplateID.Substring(0, templatetoADD.TemplateID.Length - 1);

                }

                templatetoADD.TemplateID += retry1;
                SetnewTemplate(templatetoADD, retry1);

            }
            else
            {
                BewerbungsTemplate.Add(templatetoADD);
            }
        }


        public AnschreibenTemplate SelectedTemplate
        {
            get => _SelectedTemplate;
            set
            {
                if (value != _SelectedTemplate)
                {
                    _SelectedTemplate = value;
                    if (_SelectedTemplate != null)
                    {
                        TemplateisSelected = true;
                    }
                    RaisPropertyChanged();
                }
            }
        }


        private AnschreibenTemplate _SelectedTemplate;

        private static AnschreibenViewModel _instance;

        public static AnschreibenViewModel Instance => _instance ?? (_instance = new AnschreibenViewModel());


        private ObservableCollection<IAnschreibenTemplate<AnschreibenTemplate>> _BewerbungsTemplate;

        public ObservableCollection<IAnschreibenTemplate<AnschreibenTemplate>> BewerbungsTemplate
        {
            get => _BewerbungsTemplate;
            set
            {
                if (value != _BewerbungsTemplate)
                {
                    _BewerbungsTemplate = value;
                    RaisPropertyChanged();

                }
            }

        }



        public DateTime ToDay { get; set; } = DateTime.Now;
        public DateTime EndDay { get; set; } = DateTime.Now.AddDays(365);


        public DelegateCommand AddTemplateCommand { get; set; }

        private string _neuesTemplate;

        public string NeuesTemplate
        {
            get => _neuesTemplate;
            set
            {
                if (_neuesTemplate != value)
                {
                    _neuesTemplate = value;
                    RaisPropertyChanged();
                    AddTemplateCommand.RaiseCanExecuteChanged();
                }
            }
        }


        public DelegateCommand SaveTemplateCommand { get; set; }

        private void SaveTemplate(AnschreibenTemplate template)
        {

            SaveManager<AnschreibenTemplate> safe = new(template);

            safe.Save(template.TemplateID);


        }



    }
}
