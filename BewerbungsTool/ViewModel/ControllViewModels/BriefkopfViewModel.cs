using BewerbungsTool.Enums;
using BewerbungsTool.MvvmBasics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.ViewModel
{
    public class BriefkopfViewModel : BaseViewModel
    {

        private string _AnredeVorschau;
        private string _FirmaVorschau;
        private string _EigeneAnschriftVorschau;

        private string _EigeneAnschrift;
        private string _FirmaAnschrift;

        private string? _Person;


        private string? _FirmaName;
        private string? _FirmaZuHänden;
        private string? _FirmaPerson;
        private string? _FirmaStaße;
        private string? _FirmaPlzStadt;


        private string? _EigeneName;
        private string? _EigeneStaße;
        private string? _EigenePlzStadt;
        private string? _EigeneTel;
        private string? _EigeneMail;

        #region EigenePropertys

        public string EigeneName
        {
            get => _EigeneName;
            set
            {
                if (_EigeneName != value)
                {
                    _EigeneName = value;
                    RaisPropertyChanged();
                }
            }
        }

        public string EigeneStraße
        {
            get => _EigeneStaße;
            set
            {
                if (value != _EigeneStaße)
                {
                    _EigeneStaße = value;
                    RaisPropertyChanged();
                }
            }
        }

        public string EigenePlzStadt
        {
            get => _EigenePlzStadt;
            set
            {
                if (value != _EigenePlzStadt)
                {
                    _EigenePlzStadt = value;
                    RaisPropertyChanged();
                }
            }
        }

        public string EigeneTel
        {
            get => _EigeneTel;
            set
            {
                if (value != _EigeneTel)
                {
                    _EigeneTel = value;
                    RaisPropertyChanged();
                }
            }
        }

        public string EigeneMail
        {
            get => _EigeneMail;
            set
            {
                if (value != _EigeneMail)
                {
                    _EigeneMail = value;
                    RaisPropertyChanged();
                }
            }
        }

        #endregion

        #region FirmaPropertys


        public string FirmaName
        {
            get => _FirmaName;
            set
            {
                if (_FirmaName != value)
                {
                    _FirmaName = value;
                    RaisPropertyChanged();

                }
            }
        }

        public string FirmaZuHänden
        {
            get => _FirmaZuHänden;
            set
            {
                if (value != _FirmaZuHänden)
                {
                    _FirmaZuHänden = value;
                    RaisPropertyChanged();

                }
            }
        }

        public string FirmaPerson
        {
            get => _FirmaPerson;
            set
            {
                if (value != _FirmaPerson)
                {
                    _FirmaPerson = value;
                    RaisPropertyChanged();
                }
            }
        }

        public string FirmaStraße
        {
            get => _FirmaStaße;
            set
            {
                if (value != _FirmaStaße)
                {
                    _FirmaStaße = value;
                    RaisPropertyChanged();
                }
            }
        }

        public string FirmaPlzStadt
        {
            get => _FirmaPlzStadt;
            set
            {
                if (value != _FirmaPlzStadt)
                {
                    _FirmaPlzStadt = value;
                    RaisPropertyChanged();
                }
            }
        }

        #endregion





        private BriefkopfViewModel()
        {

            SelectAnredeCommand = new(o =>
            {
                if (o is AnredeEnums anrede)
                {
                    switch (anrede)
                    {
                        case AnredeEnums.Frau:
                            AnredeVorschau = $"Sehr geehrte Frau {FirmaPerson}";
                            break;
                        case AnredeEnums.Herr:
                            AnredeVorschau = $"Sehr geehrter Herr {FirmaPerson}";
                            break;
                        case AnredeEnums.Damen_Und_Herren:
                            AnredeVorschau = "Sehr geehrte Damen und Herren";
                            break;
                    }
                }
            });



        }

        private static BriefkopfViewModel _instance;

        public static BriefkopfViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BriefkopfViewModel();
                }
                return _instance;
            }

        }



        public string FirmaVorschau
        {
            get => _FirmaVorschau;
            set
            {
                if (value != _FirmaVorschau)
                {
                    _FirmaVorschau = value;
                    RaisPropertyChanged();
                }
            }
        }
        public string EigeneAnschriftVorschau
        {
            get => _EigeneAnschriftVorschau;
            set
            {
                if (value != _EigeneAnschriftVorschau)
                {
                    _EigeneAnschriftVorschau = value;
                    RaisPropertyChanged();
                }
            }
        }
        public string AnredeVorschau
        {
            get => _AnredeVorschau;
            set
            {
                if (value != _AnredeVorschau)
                {
                    _AnredeVorschau = value;
                    RaisPropertyChanged();
                }
            }
        }

        public string EigeneAnschrift
        {
            get => _EigeneAnschrift;
            set
            {
                if (value != _EigeneAnschrift)
                {
                    _EigeneAnschrift = value;

                    CreateAnschriftVorschau();

                    RaisPropertyChanged();
                    RaisPropertyChanged(nameof(EigeneAnschriftVorschau));

                }
            }
        }


        public string FirmaAnschrift
        {
            get => _FirmaAnschrift;
            set
            {
                if (value != _FirmaAnschrift)
                {
                    _FirmaAnschrift = value;
                    CreateFirmaVorschau();
                    RaisPropertyChanged();
                    RaisPropertyChanged(nameof(FirmaVorschau));
                }
            }
        }

        private void CreateFirmaVorschau()
        {

            if (!string.IsNullOrEmpty(FirmaAnschrift))
            {
                var AnschriftsArray = FirmaAnschrift.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                if (AnschriftsArray.Length == 4)
                {
                    FirmaName = AnschriftsArray[0];
                    FirmaZuHänden = AnschriftsArray[1];
                    FirmaPerson = "NV";
                    FirmaStraße = AnschriftsArray[2];
                    FirmaPlzStadt = AnschriftsArray[3];


                }
                if (AnschriftsArray.Length == 5)
                {

                    FirmaName = AnschriftsArray[0];
                    FirmaZuHänden = AnschriftsArray[1];
                    FirmaPerson = AnschriftsArray[2];
                    FirmaStraße = AnschriftsArray[3];
                    FirmaPlzStadt = AnschriftsArray[4];

                }
            }
            else
            {
                FirmaName = "";
                FirmaZuHänden = "";
                FirmaStraße = "";
                FirmaPerson = "";
                FirmaPlzStadt = "";
            }




        }

        private void CreateAnschriftVorschau()
        {

            if (!string.IsNullOrEmpty(EigeneAnschrift))
            {
                var AnschriftArray = EigeneAnschrift.Split("\n", StringSplitOptions.RemoveEmptyEntries);

                if (AnschriftArray.Length == 5)
                {
                    EigeneName = AnschriftArray[0];
                    EigeneStraße = AnschriftArray[1];
                    EigenePlzStadt = AnschriftArray[2];
                    EigeneTel = AnschriftArray[3];
                    EigeneMail = AnschriftArray[4];
                }
                if (AnschriftArray.Length == 4)
                {
                    EigeneName = AnschriftArray[0];
                    EigeneStraße = AnschriftArray[1];
                    EigenePlzStadt = AnschriftArray[2];

                    if (AnschriftArray[3].Contains('@'))
                    {
                        EigeneMail = AnschriftArray[3];
                        EigeneTel = "";
                    }
                    else
                    {
                        EigeneMail = "";
                        EigeneTel = AnschriftArray[3];
                    }

                }
            }

            else
            {
                EigeneMail = "";
                EigeneName = "";
                EigeneStraße = "";
                EigenePlzStadt = "";
                EigeneTel = "";
            }






        }

        public DelegateCommand SelectAnredeCommand { get; set; }




    }


}
