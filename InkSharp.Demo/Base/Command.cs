using System;
using System.Windows.Input;

namespace MichelMichels.InkSharp.Demo.Base;

public class Command : ICommand
{
    // Fields
    private Action execute;
    private Func<bool> canExecute;

    public Command(Action execute)
    {
        this.execute = execute;
    }
    public Command(Action execute, Func<bool> canExecute)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    // ICommand members
    public event EventHandler CanExecuteChanged;
    public bool CanExecute(object parameter)
    {
        return canExecute != null ? canExecute() : true;
    }
    public void Execute(object parameter)
    {
        execute();
    }

    public void SetCanExecute(Func<bool> canExecute)
    {
        this.canExecute = canExecute;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
public class Command<T> : ICommand
{
    private Action<T> _execute;
    private Predicate<T> _canExecute;

    public Command(Action<T> execute)
    {
        _execute = execute;
    }
    public Command(Action<T> execute, Predicate<T> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    // ICommand members
    public event EventHandler CanExecuteChanged;
    public bool CanExecute(object parameter)
    {
        return _canExecute != null && parameter is T cast ? _canExecute(cast) : true;
    }
    public void Execute(object parameter)
    {
        if (!(parameter is T cast))
            throw new ArgumentException(nameof(parameter));

        _execute(cast);
    }

    public void SetCanExecute(Predicate<T> canExecute)
    {
        _canExecute = canExecute;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
