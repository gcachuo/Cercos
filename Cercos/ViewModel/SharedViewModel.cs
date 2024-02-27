using System.ComponentModel;

namespace Cercos.ViewModel
{
    public class SharedViewModel : INotifyPropertyChanged
    {
        private bool _isAdmin;
        private bool _action;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    OnPropertyChanged(nameof(IsAdmin));
                }
            }
        }

        public bool Action
        {
            get { return _action; }
            set
            {
                if (_action != value)
                {
                    _action = value;
                    OnPropertyChanged(nameof(Action));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}