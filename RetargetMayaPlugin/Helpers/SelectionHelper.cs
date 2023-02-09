using Autodesk.Maya.OpenMaya;

namespace RetargetMayaPlugin.Helpers;

public static class SelectionHelper
{
    public static MObject GetSelectedObject()
    {
        var selectionList = new MSelectionList();
        MGlobal.getActiveSelectionList(selectionList);
        
        var selectedObject = new MObject();
        if (!selectionList.isEmpty)
        {
            selectionList.getDependNode(0, selectedObject);
        }

        return selectedObject;
    }

    public static void SelectObject(string objectName)
    {
        MGlobal.executeCommand($"select -r {objectName}");
    }
}