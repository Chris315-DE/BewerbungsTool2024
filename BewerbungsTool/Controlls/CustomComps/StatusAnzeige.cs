using System;
using System.Collections.Generic;
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
            DependencyProperty.Register("DoneList", typeof(List<bool>), typeof(StatusAnzeige), new PropertyMetadata(new List<bool> { true, true, false, false, true }));

        public static DependencyProperty FieldOneProperty =
            DependencyProperty.Register("FieldOne", typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldTowProperty =
            DependencyProperty.Register("FieldTow", typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldThreeProperty =
            DependencyProperty.Register("FieldThree", typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldFourProperty =
            DependencyProperty.Register("FieldFour", typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

        public static DependencyProperty FieldFiveProperty =
            DependencyProperty.Register("FieldFive", typeof(string), typeof(StatusAnzeige), new PropertyMetadata(string.Empty));

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

        public List<bool> DoneList
        {
            get => (List<bool>)GetValue(DoneListProperty);
            set => SetValue(DoneListProperty, value);
        }


    }

}

