using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using RetargetMayaPlugin.Commands;
using RetargetMayaPlugin.Models;

namespace RetargetMayaPlugin.ViewModels;

public class ExportAnimationsWindowViewModel : BaseViewModel
{
    public ICommand ExportCommand { get; } = new ExportCommand();
    public ICommand SelectFolderCommand { get; } = new SelectFolderCommand();
    public ObservableCollection<ClipViewModel> ClipViewModels { get; set; }
    public List<Mesh> Meshes { get; }
    public string CharacterName { get; }
    
    private readonly ICollectionView _clipsCollectionView;
    
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
    
    public bool IsAllChecked
    {
        get => ClipViewModels.All(clipViewModel => clipViewModel.IsChecked);
        set
        {
            foreach (var clipViewModel in ClipViewModels)
            {
                clipViewModel.IsChecked = value;
            }
        }
    }

    private string _searchText;
    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            _clipsCollectionView.Refresh();
            SetField(ref _searchText, value);
        }
    }

    public ExportAnimationsWindowViewModel(ExportContext exportContext)
    {
        Meshes = exportContext.Meshes.ToList();

        var clips = exportContext.Clips
            .Select(clip => new ClipViewModel(clip))
            .ToList();
        ClipViewModels = new ObservableCollection<ClipViewModel>(clips);
        ClipViewModels.CollectionChanged += (_, _) => OnPropertyChanged(nameof(IsAllChecked));
        
        _clipsCollectionView = CollectionViewSource.GetDefaultView(ClipViewModels);
        _clipsCollectionView.Filter = IsClipExist;
        
        CharacterName = exportContext.CharacterName;
        SourceMesh = Meshes.FirstOrDefault();
        TargetMesh = Meshes.FirstOrDefault(mesh => mesh != SourceMesh);
    }

    private bool IsClipExist(object obj)
    {
        var clipViewModel = (ClipViewModel)obj;
        
        return string.IsNullOrEmpty(SearchText) || clipViewModel.Name.Contains(SearchText);
    }
}