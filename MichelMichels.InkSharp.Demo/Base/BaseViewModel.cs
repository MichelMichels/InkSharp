using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MichelMichels.InkSharp.Demo.Base;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void SetProperty<T>(ref T innerValue, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(innerValue, value))
            return;

        innerValue = value;
        OnPropertyChanged(propertyName);
    }
}
