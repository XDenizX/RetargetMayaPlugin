using System.Windows.Forms;
using RetargetMayaPlugin.ViewModels;

namespace RetargetMayaPlugin.Commands;

public class SelectFolderCommand : BaseCommand
{
    public override bool CanExecute(object parameter)
    {
        return true;
    }

    public override void Execute(object parameter)
    {
        if (parameter is not ExportAnimationsWindowViewModel viewModel)
            return;
        
        var dialog = new FolderBrowserDialog();
        dialog.ShowDialog();

        viewModel.Filepath = dialog.SelectedPath;
    }
}