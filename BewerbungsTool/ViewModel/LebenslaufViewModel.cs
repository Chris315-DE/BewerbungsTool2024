using BewerbungsTool.Contracts;
using BewerbungsTool.DataStore;
using BewerbungsTool.Enums;
using BewerbungsTool.Manager;
using BewerbungsTool.MvvmBasics;
using BewerbungsTool.ViewModel.ControllViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel
{
    public class LebenslaufViewModel : BaseViewModel
    {

        private LebenslaufDataStore _dataStore;
        private LebenslaufTemplateLoader _templateLoader;

        private LebenslaufViewModel()
        {
            DoneList = new ObservableCollection<bool> { false, false, false, false, false };
            Navigator = NavigationManager.Instance;
            Navigator.LebenslaufUnterViewModel = LebenslaufBerufserfahrungListViewModel.Instance;
            NaviCommand = new(o => navi(o));
            _dataStore = LebenslaufDataStore.Instance;
            _dataStore.LebenslaufUnderItemIsChanged += UnderViewIsRdy;
            _templateLoader = LebenslaufTemplateLoader.Instance;
            LebenslaufTemplate = [];

            if (_templateLoader.GeladeneTemplates.Count > 0)
            {
                foreach (var item in _templateLoader.GeladeneTemplates)
                {
                    LebenslaufTemplate.Add(item);
                }
            }

            ÄnderungenSpeichernCommand = new DelegateCommand(o => 
            {

                var templateToSafe = LebenslaufTemplate.Where(x => x.Name == SelectedTemplate).First();

                templateToSafe.PersonenInfo = LebenslaufPersonenInfoViewModel.Instance;

                SaveManager<LebenslaufTemplate> save = new SaveManager<LebenslaufTemplate> (templateToSafe);

            

                save.Save(SelectedTemplate);


                _templateLoader.GeladeneTemplates.Clear();
                _templateLoader.LadeTemplates();
                LebenslaufTemplate.Clear();
                if(_templateLoader.GeladeneTemplates.Count > 0)
                {
                    foreach (var item in _templateLoader.GeladeneTemplates)
                    {
                        LebenslaufTemplate.Add(item);
                    }
                }


            });

            AddTemplateCommand = new DelegateCommand(o => checkDoneList() && !string.IsNullOrEmpty(TemplateNeuName), o =>
            {

                SaveManager<LebenslaufTemplate> saveManager = new SaveManager<LebenslaufTemplate>(new LebenslaufTemplate(TemplateNeuName));

                saveManager.Save(TemplateNeuName);

            });


        }


        private bool checkDoneList()
        {
            foreach (var item in DoneList)
            {
                if (!item)
                    return false;
            }
            return true;
        }

        private void UnderViewIsRdy(BaseViewModel obj, bool state)
        {

            switch (obj)
            {
                case LebenslaufBerufserfahrungListViewModel:


                    bool b0 = state;
                    bool b1 = DoneList[1];
                    bool b2 = DoneList[2];
                    bool b3 = DoneList[3];
                    bool b4 = DoneList[4];

                    DoneList = new ObservableCollection<bool> { b0, b1, b2, b3, b4 };


                    RaisPropertyChanged(nameof(DoneList));
                    AddTemplateCommand?.RaiseCanExecuteChanged();
                    break;
                case LebenslaufBildungsListViewModel:

                    b0 = DoneList[0];
                    b1 = state;
                    b2 = DoneList[2];
                    b3 = DoneList[3];
                    b4 = DoneList[4];

                    DoneList = new() { b0, b1, b2, b3, b4 };
                    RaisPropertyChanged(nameof(DoneList));
                    AddTemplateCommand?.RaiseCanExecuteChanged();
                    break;
                case LebenslaufKontaktListViewModel:
                    b0 = DoneList[0];
                    b1 = DoneList[1];
                    b2 = state;
                    b3 = DoneList[3];
                    b4 = DoneList[4];

                    DoneList = new() { b0, b1, b2, b3, b4 };
                    RaisPropertyChanged(nameof(DoneList));
                    AddTemplateCommand?.RaiseCanExecuteChanged();
                    break;
                case LebenslaufPersonenInfoViewModel:
                    b0 = DoneList[0];
                    b1 = DoneList[1];
                    b2 = DoneList[2];
                    b3 = state;
                    b4 = DoneList[4];

                    DoneList = new() { b0, b1, b2, b3, b4 };
                    RaisPropertyChanged(nameof(DoneList));
                    AddTemplateCommand?.RaiseCanExecuteChanged();
                    break;
                case LebenslaufStatListViewModel:
                    b0 = DoneList[0];
                    b1 = DoneList[1];
                    b2 = DoneList[2];
                    b3 = DoneList[3];
                    b4 = state;

                    DoneList = new() { b0, b1, b2, b3, b4 };
                    RaisPropertyChanged(nameof(DoneList));
                    AddTemplateCommand?.RaiseCanExecuteChanged();
                    break;



            }

        }

        private static LebenslaufViewModel _instance;
        public static LebenslaufViewModel Instance => _instance ?? (_instance = new());

        public ObservableCollection<bool> DoneList
        {
            get => _doneList;
            set
            {
                if (value != _doneList)
                {
                    _doneList = value;
                    RaisPropertyChanged();
                }
            }
        }

        private ObservableCollection<bool> _doneList;


        private string _TemplateNeuName;


        public string TemplateNeuName
        {
            get => _TemplateNeuName;
            set
            {
                if (value != _TemplateNeuName)
                {
                    _TemplateNeuName = value;
                    RaisPropertyChanged();
                    AddTemplateCommand?.RaiseCanExecuteChanged();
                }
            }
        }


        public DelegateCommand NaviCommand { get; set; }

        public DelegateCommand ÄnderungenSpeichernCommand { get; set; }

        public INavigator Navigator { get; set; }

        private ObservableCollection<LebenslaufTemplate> _LebenslaufTemplate;
        public ObservableCollection<LebenslaufTemplate> LebenslaufTemplate { get; set; }



        private string _SelectedTemplate;

        public string SelectedTemplate
        {
            get => _SelectedTemplate;
            set
            {
                if (value != _SelectedTemplate && value is not null)
                {

                    RaisPropertyChanged();
                    SwitchSelectedTemplate(value);
                    _SelectedTemplate = value;
                    RaisPropertyChanged(nameof(SelectedTemplate));



                }
            }
        }

        private void SwitchSelectedTemplate(string value)
        {


          
           

            var template = LebenslaufTemplate.Where(o => o.Name == value).FirstOrDefault();

            if (template is null)
                return;

            if (template.Projekt?.Count() > 0)
            {
                LebenslaufProjektListViewModel.Instance.Items = template.Projekt;
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufProjektListViewModel.Instance, true);
            }
            else
            {
                LebenslaufProjektListViewModel.Instance.Items = [];
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufProjektListViewModel.Instance, false);
            }

            if (template.Stats?.Count() > 0)
            {
                LebenslaufStatListViewModel.Instance.LebenslaufStatList = template.Stats;
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufStatListViewModel.Instance, true);
            }
            else 
            {
                LebenslaufStatListViewModel.Instance.LebenslaufStatList = [];
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufStatListViewModel.Instance, false);
            }
            if (template.Kontakt?.Count() > 0)
            {
                LebenslaufKontaktListViewModel.Instance.Items = template.Kontakt;
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufKontaktListViewModel.Instance, true);
            }
            else
            {
                LebenslaufKontaktListViewModel.Instance.Items = [];
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufKontaktListViewModel.Instance, false);
            }

            if(template.Berufserfahrung.Count() > 0)
            {
                LebenslaufBerufserfahrungListViewModel.Instance.Items = template.Berufserfahrung;
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufBerufserfahrungListViewModel.Instance, true);
            }
            else
            {
                LebenslaufBerufserfahrungListViewModel.Instance.Items = [];
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufBerufserfahrungListViewModel.Instance, false);
            }




            if(template.Bildung?.Count() > 0)
            {
                LebenslaufBildungsListViewModel.Instance.Items=template.Bildung;
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufBildungsListViewModel.Instance, true);
            }
            else
            {
                LebenslaufBildungsListViewModel.Instance.Items = [];
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufBildungsListViewModel.Instance, false);
            }
            if (template.PersonenInfo?.Name != null)
            {
                LebenslaufPersonenInfoViewModel.Instance.SetInstance(template.PersonenInfo);
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufPersonenInfoViewModel.Instance, true);
            }
            else 
            {
                LebenslaufPersonenInfoViewModel.Instance.SetInstance(null);
                _dataStore.OnLebenslaufUnterItemChanged(LebenslaufPersonenInfoViewModel.Instance,false);
            }
        }

        public DelegateCommand AddTemplateCommand { get; set; }


        private void navi(object? parameter)
        {
            if (parameter is LebenslaufView view)
            {
                switch (view)
                {
                    case LebenslaufView.Berufserfahrung:
                        Navigator.LebenslaufUnterViewModel = LebenslaufBerufserfahrungListViewModel.Instance;
                        break;
                    case LebenslaufView.Bildung:
                        Navigator.LebenslaufUnterViewModel = LebenslaufBildungsListViewModel.Instance;
                        break;
                    case LebenslaufView.Kontakt:
                        Navigator.LebenslaufUnterViewModel = LebenslaufKontaktListViewModel.Instance;
                        break;
                    case LebenslaufView.PersonenInfo:
                        Navigator.LebenslaufUnterViewModel = LebenslaufPersonenInfoViewModel.Instance;
                        break;
                    case LebenslaufView.Stats:
                        Navigator.LebenslaufUnterViewModel = LebenslaufStatListViewModel.Instance;
                        break;
                    case LebenslaufView.Projekt:
                        Navigator.LebenslaufUnterViewModel = LebenslaufProjektListViewModel.Instance;
                        break;
                    default:
                        Debugger.Break();
                        break;
                }
            }

        }
    }
}