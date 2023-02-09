using Autodesk.Maya.OpenMaya;
using RetargetMayaPlugin.Models;

namespace RetargetMayaPlugin.Helpers;

public static class TimeLineHelper
{
    public static void SetClipToCharacter(Clip clip, string characterName)
    {
        MGlobal.executeCommand($"clip -e -active {clip.Name} {characterName}");
        MGlobal.executeCommand($"playbackOptions -min 0 -max {clip.Duration}");
    }
}