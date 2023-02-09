using Autodesk.Maya.OpenMaya;
using Autodesk.Maya.OpenMayaAnim;

namespace RetargetMayaPlugin.Helpers;

public static class CharacterHelper
{
    public static string GetName(MObject character)
    {
        var fnCharacter = new MFnCharacter(character);
        return fnCharacter.name;
    }
}