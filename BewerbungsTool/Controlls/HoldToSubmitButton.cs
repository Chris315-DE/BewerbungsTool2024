using CKCustomControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BewerbungsTool.Controlls
{
    public class HoldToSubmitButton : Button
    {

        private CancellationTokenSource _cancellationTokenSource;
        static HoldToSubmitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HoldToSubmitButton), new FrameworkPropertyMetadata(typeof(HoldToSubmitButton)));
        }



        protected override async void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await Task.Delay(1000, _cancellationTokenSource.Token);
                base.OnMouseLeftButtonDown(e);
                base.OnClick();
                MessageBox.Show("Template wurde Gelöscht!");

            }
            catch (TaskCanceledException) 
            {
                MessageBox.Show("Zum Löschen gedrückt halten");
            }
        }

        protected override async void OnClick() { }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {

            CancleSubmit();
            base.OnMouseLeftButtonUp(e);
        }


        protected override void OnMouseLeave(MouseEventArgs e)
        {
            CancleSubmit();
        }

        private void CancleSubmit()
        {
            if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
}
