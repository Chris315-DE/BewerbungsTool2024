using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BewerbungsTool.MvvmBasics
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private double _MinimumWidth;
        private double _MinimumHeight;

        public event PropertyChangedEventHandler? PropertyChanged;




        protected virtual void RaisPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected virtual void WsM_WindowStateChanged(WindowState obj)
        {
            if (obj == WindowState.Maximized)
            {
                MinimumHeight = 1080;
                MinimumWidth = 1920;
            }
            else
            {
                MinimumWidth = 1600;
                MinimumHeight = 900;
            }
        }


        public virtual double MinimumWidth
        {
            get => _MinimumWidth;
            set
            {
                if (value != _MinimumWidth)
                {
                    _MinimumWidth = value;
                    RaisPropertyChanged(nameof(MinimumWidth));
                }
            }
        }
        public virtual double MinimumHeight
        {
            get => _MinimumHeight;
            set
            {
                if (value != _MinimumHeight)
                {
                    _MinimumHeight = value;
                    RaisPropertyChanged(nameof(MinimumHeight));
                }
            }

        }
    }
}
