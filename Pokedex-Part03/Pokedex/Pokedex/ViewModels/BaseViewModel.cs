using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pokedex.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
