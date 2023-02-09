using RetargetMayaPlugin.Models;

namespace RetargetMayaPlugin.ViewModels;

public class ClipViewModel : BaseViewModel
{
    public Clip Model { get; }
    public string Name => Model.Name;
    
    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set => SetField(ref _isChecked, value);
    }
    
    public ClipViewModel(Clip model)
    {
        Model = model;
    }
}