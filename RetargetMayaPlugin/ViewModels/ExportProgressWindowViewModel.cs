namespace RetargetMayaPlugin.ViewModels;

public class ExportProgressWindowViewModel : BaseViewModel
{

    private int _totalClipsCount;
    public int TotalClipsCount
    {
        get => _totalClipsCount;
        set => SetField(ref _totalClipsCount, value);
    }

    private int _currentClipNumber;
    public int CurrentClipNumber
    {
        get => _currentClipNumber;
        set => SetField(ref _currentClipNumber, value);
    }

    private ClipViewModel _currentClip;
    public ClipViewModel CurrentClip 
    {
        get => _currentClip;
        set => SetField(ref _currentClip, value);
    }
}