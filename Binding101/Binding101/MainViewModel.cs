using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Binding101
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _forename;

        public string Forename
        {
            get => _forename;
            set
            {
                if (value == _forename) return;

                _forename = value;
                OnPropertyChange();
                OnPropertyChange(nameof(Fullname));
            }
        }

        private string _surname;

        public string Surname
        {
            get => _surname;
            set
            {
                if (value == _surname) return;

                _surname = value;
                OnPropertyChange();
                OnPropertyChange(nameof(Fullname));
            }
        }

        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                if (_age == value) return;

                _age = value;
                OnPropertyChange();
            }
        }

        public string Fullname => $"{Forename} {Surname}";

        private void OnPropertyChange([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}