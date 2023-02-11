using RetargetMayaPlugin.ViewModels;

namespace RetargetMayaPlugin.Commands;

public class SwapMeshesCommand : BaseCommand
{
    public override bool CanExecute(object parameter)
    {
        return true;
    }

    public override void Execute(object parameter)
    {
        if (parameter is not ExportAnimationsWindowViewModel viewModel)
            return;

        var temporaryMesh = viewModel.TargetMesh;
        viewModel.TargetMesh = viewModel.SourceMesh;
        viewModel.SourceMesh = temporaryMesh;
    }
}