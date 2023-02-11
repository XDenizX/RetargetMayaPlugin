using System.IO;
using System.Linq;
using RetargetMayaPlugin.Helpers;
using RetargetMayaPlugin.ViewModels;

namespace RetargetMayaPlugin.Commands;

public class ExportCommand : BaseCommand
{
    private const string ExportTypeName = "X-Ray skeletal motion";
    
    public override bool CanExecute(object parameter)
    {
        if (parameter is not ExportAnimationsWindowViewModel viewModel)
            return false;
        
        return viewModel.SourceMesh != null 
               && viewModel.TargetMesh != null 
               && !string.IsNullOrEmpty(viewModel.Filepath) 
               && viewModel.SourceMesh != viewModel.TargetMesh;
    }

    public override void Execute(object parameter)
    {
        if (parameter is not ExportAnimationsWindowViewModel viewModel)
            return;

        var selectedClips = viewModel.ClipViewModels.Where(clip => clip.IsChecked);
        foreach (var clipViewModel in selectedClips)
        {
            SelectionHelper.SelectObject(viewModel.SourceMesh.Name);
            TimeLineHelper.SetClipToCharacter(clipViewModel.Model, viewModel.CharacterName);
            SelectionHelper.SelectObject(viewModel.TargetMesh.Name);

            var filepath = Path.Combine(viewModel.Filepath, $"{clipViewModel.Name}.skl");
            ExportHelper.Export(filepath, ExportTypeName);
        }
    }
}