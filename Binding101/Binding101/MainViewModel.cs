using System.ComponentModel;

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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Forename"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fullname"));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Surname"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fullname"));
            }
        }

        public string Fullname => $"{Forename} {Surname}";
    }
}