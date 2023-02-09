using System;
using System.Windows.Forms;
using System.Windows.Input;
using RetargetMayaPlugin.ViewModels;

namespace RetargetMayaPlugin.Commands;

public class SelectFolderCommand : ICommand
{
    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        if (parameter is not ExportAnimationsWindowViewModel viewModel)
            return;
        
        var dialog = new FolderBrowserDialog();
        dialog.ShowDialog();

        viewModel.Filepath = dialog.SelectedPath;
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}