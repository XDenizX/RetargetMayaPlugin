using Autodesk.Maya.OpenMaya;
using RetargetMayaPlugin;

[assembly: ExtensionPlugin(typeof(RetargetPlugin))]

namespace RetargetMayaPlugin;

public class RetargetPlugin : IExtensionPlugin
{
    public bool InitializePlugin()
    {
        return true;
    }

    public bool UninitializePlugin()
    {
        return true;
    }

    public string GetMayaDotNetSdkBuildVersion()
    {
        return "20200400";
    }
}