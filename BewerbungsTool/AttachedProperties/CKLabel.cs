using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bewerbungstool.AttachedProperties
{
    class CKLabel : Label
    {
        public static DependencyProperty IsSetProperty = DependencyProperty.Register("IsSet", typeof(bool), typeof(CKLabel), new PropertyMetadata(true));



        public bool IsSet
        {
            get => (bool)GetValue(IsSetProperty);
            set => SetValue(IsSetProperty, value);
        }





        static CKLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CKLabel), new FrameworkPropertyMetadata(typeof(CKLabel)));
        }
    }



}