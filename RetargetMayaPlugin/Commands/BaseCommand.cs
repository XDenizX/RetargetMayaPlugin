using System;
using System.Windows.Input;

namespace RetargetMayaPlugin.Commands;

public abstract class BaseCommand : ICommand
{
    public abstract bool CanExecute(object parameter);
    public abstract void Execute(object parameter);
    
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}