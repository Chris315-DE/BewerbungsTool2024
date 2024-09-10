using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CKCustomControlls
{
    public class HoldtoSubmitControll : Button
    {

        private CancellationTokenSource _cancellationTokenSource;
        static HoldtoSubmitControll()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HoldtoSubmitControll), new FrameworkPropertyMetadata(typeof(HoldtoSubmitControll)));
        }



        protected override async void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await Task.Delay(1000, _cancellationTokenSource.Token);
                base.OnMouseLeftButtonDown(e);
                base.OnClick();

            }
            catch (TaskCanceledException) { }
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
