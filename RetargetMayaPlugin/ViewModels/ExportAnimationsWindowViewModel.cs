using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using RetargetMayaPlugin.Commands;
using RetargetMayaPlugin.Models;

namespace RetargetMayaPlugin.ViewModels;

public class ExportAnimationsWindowViewModel : BaseViewModel
{
    public ICommand ExportCommand { get; } = new ExportCommand();
    public ICommand SelectFolderCommand { get; } = new SelectFolderCommand();
    public BindingList<ClipViewModel> ClipViewModels { get; set; }
    public List<Mesh> Meshes { get; }
    public string CharacterName { get; }
    
    private Mesh _sourceMesh;
    public Mesh SourceMesh
    {
        get => _sourceMesh;
        set => SetField(ref _sourceMesh, value);
    }

    private Mesh _targetMesh;
    public Mesh TargetMesh
    {
        get => _targetMesh;
        set => SetField(ref _targetMesh, value);
    }

    private string _filepath;
    public string Filepath
    {
        get => _filepath;
        set => SetField(ref _filepath, value);
    }
    
    public ExportAnimationsWindowViewModel(ExportContext exportContext)
    {
        Meshes = exportContext.Meshes.ToList();

        var clips = exportContext.Clips
            .Select(clip => new ClipViewModel(clip))
            .ToList();
        ClipViewModels = new BindingList<ClipViewModel>(clips);

        CharacterName = exportContext.CharacterName;
        SourceMesh = Meshes.FirstOrDefault();
        TargetMesh = Meshes.FirstOrDefault(mesh => mesh != SourceMesh);
    }
}