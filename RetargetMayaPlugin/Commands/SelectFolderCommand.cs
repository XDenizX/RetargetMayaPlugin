using Microsoft.WindowsAPICodePack.Dialogs;
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
        
        var dialog = new CommonOpenFileDialog
        {
            Multiselect = false,
            Title = "Select output directory",
            IsFolderPicker = true
        };
        
        if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
            return;

        viewModel.Filepath = dialog.FileName;
    }
}