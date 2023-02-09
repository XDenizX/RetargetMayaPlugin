using Autodesk.Maya.OpenMaya;

namespace RetargetMayaPlugin.Helpers;

public static class ExportHelper
{
    public static void Export(string filepath, string typeName)
    {
        filepath = filepath.Replace(@"\", @"\\");
        MGlobal.executeCommand($"file -force -options \"\" -typ \"{typeName}\" -pr -es \"{filepath}\";");
    }
}