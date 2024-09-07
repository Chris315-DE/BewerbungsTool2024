using BewerbungsTool.Contracts;
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
            AddTemplateCommand = new DelegateCommand(o => !string.IsNullOrEmpty(NeuesTemplate), o =>
            {

                var TemplatetoADD = new AnschreibenTemplate(NeuesTemplate);

                SetnewTemplate(TemplatetoADD, 0);
                NeuesTemplate = string.Empty;


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
                    if(_SelectedTemplate != null)
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


    }
}
