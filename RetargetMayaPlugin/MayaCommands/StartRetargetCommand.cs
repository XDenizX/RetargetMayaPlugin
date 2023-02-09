using System.Windows;
using Autodesk.Maya.OpenMaya;
using RetargetMayaPlugin.MayaCommands;
using RetargetMayaPlugin.Helpers;
using RetargetMayaPlugin.Models;
using RetargetMayaPlugin.ViewModels;
using RetargetMayaPlugin.Windows;

[assembly: MPxCommandClass(typeof(StartRetargetCommand), "start_anim_retarget")]

namespace RetargetMayaPlugin.MayaCommands;

public class StartRetargetCommand : MPxCommand, IMPxCommand
{
    public override void doIt(MArgList argumentList)
    {
        var character = SelectionHelper.GetSelectedObject();
        if (character.isNull || character.apiType != MFn.Type.kCharacter)
        {
            MessageBox.Show("Select the 'character' in the Outliner", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var meshes = MeshHelper.GetMeshes();
        var clips = ClipHelper.GetClips(character);
        var characterName = CharacterHelper.GetName(character);
        var exportContext = new ExportContext(meshes, clips, characterName);
        
        var exportAnimationsWindowVm = new ExportAnimationsWindowViewModel(exportContext);
        var exportAnimationsWindow = new ExportAnimationsWindow
        {
            DataContext = exportAnimationsWindowVm
        };
        
        exportAnimationsWindow.ShowDialog();
    }
}