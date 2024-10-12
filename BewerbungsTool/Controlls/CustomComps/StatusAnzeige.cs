using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BewerbungsTool.Controlls.CustomComps
{
    public class StatusAnzeige : Control
    {
        static StatusAnzeige()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StatusAnzeige), new FrameworkPropertyMetadata(typeof(StatusAnzeige)));
        }



        public static DependencyProperty DoneListProperty =
            DependencyProperty.Register(nameof(DoneList), typeof(ObservableCollection<bool>), typeof(StatusAnzeige), new PropertyMetadata(new ObservableCollection<bool> { true, true, false, false, true,false,false }));

        public static DependencyProperty FieldOneProperty =
            DependencyProperty.Register(nameof(FieldOne), typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldTowProperty =
            DependencyProperty.Register(nameof(FieldTow), typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldThreeProperty =
            DependencyProperty.Register(nameof(FieldThree), typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldFourProperty =
            DependencyProperty.Register(nameof(FieldFour), typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldFiveProperty =
            DependencyProperty.Register(nameof(FieldFive), typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldSixProperty =
            DependencyProperty.Register(nameof(FieldSix),typeof(string), typeof(StatusAnzeige),new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldSevenProperty =
            DependencyProperty.Register(nameof(FieldSeven), typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));



        public string FieldSeven
        {
            get => (string)GetValue(FieldSevenProperty);
            set => SetValue(FieldSevenProperty, value);
        }


        public string FieldSix
        {
            get => (string)GetValue(FieldSixProperty);
            set => SetValue(FieldSixProperty, value);
        }



        public string FieldFive
        {
            get => (string)GetValue(FieldFiveProperty);
            set => SetValue(FieldFiveProperty, value);
        }


        public string FieldFour
        {
            get => (string)GetValue(FieldFourProperty);
            set => SetValue(FieldFourProperty, value);
        }


        public string FieldThree
        {
            get => (string)GetValue(FieldThreeProperty);
            set => SetValue(FieldThreeProperty, value);
        }


        public string FieldTow
        {
            get => (string)GetValue(FieldTowProperty);
            set => SetValue(FieldTowProperty, value);
        }
        public string FieldOne
        {
            get => (string)GetValue(FieldOneProperty);
            set => SetValue(FieldOneProperty, value);
        }

        public ObservableCollection<bool> DoneList
        {
            get => (ObservableCollection<bool>)GetValue(DoneListProperty);
            set => SetValue(DoneListProperty, value);
        }


    }

}

