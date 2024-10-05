using BewerbungsTool.Contracts;
using BewerbungsTool.Manager;
using BewerbungsTool.Model;
using BewerbungsTool.MvvmBasics;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace BewerbungsTool.ViewModel
{
    public class AnschreibenViewModel : BaseViewModel
    {
        private AnschreibenViewModel()
        {
            BewerbungsTemplate = [];
            TemplateisSelected = false;


            AnschreibenTemplateManager.Instance.GeladeneTemplates.ForEach(template => { BewerbungsTemplate.Add(template); });



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

            DelCommand = new DelegateCommand(o => TemplateisSelected, o =>
            {

                string todel = SelectedTemplate.TemplateID;

                SelectedTemplate = null;
                SaveTemplateCommand.RaiseCanExecuteChanged();
                TemplateisSelected = false;
                BewerbungsTemplate.Clear();

                AnschreibenTemplateManager.Instance.Löschetemplate(todel);

                AnschreibenTemplateManager.Instance.GeladeneTemplates.ForEach(template =>
                {
                    BewerbungsTemplate.Add(template);




                });
            });


            UnterschriftLadenCommand = new DelegateCommand(o => TemplateisSelected, o => UnterschriftLaden());
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
                    UnterschriftLadenCommand.RaiseCanExecuteChanged();
                    DelCommand.RaiseCanExecuteChanged();
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


        public DelegateCommand UnterschriftLadenCommand { get; set; }

        public DelegateCommand DelCommand { get; set; }

        public DelegateCommand SaveTemplateCommand { get; set; }

        private void SaveTemplate(AnschreibenTemplate template)
        {

            SaveManager<AnschreibenTemplate> safe = new(template);

            safe.Save(template.TemplateID);


        }

        private void UnterschriftLaden()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".png";
            dialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            Nullable<bool> result = dialog.ShowDialog();
            dialog.Multiselect = false;
            if (result == true)
            {
                SelectedTemplate.UnterschriftPfad = dialog.FileName;
            }

        }




    }
}
