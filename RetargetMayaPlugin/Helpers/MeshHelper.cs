using System.Collections.Generic;
using Autodesk.Maya.OpenMaya;
using RetargetMayaPlugin.Models;

namespace RetargetMayaPlugin.Helpers;

public static class MeshHelper
{
    public static IEnumerable<Mesh> GetMeshes()
    {
        var meshes = new List<Mesh>();
        var meshIterator = new MCDag(MItDag.TraversalType.kDepthFirst, MFn.Type.kMesh);
        
        foreach (var dag in meshIterator)
        {
            var mFnMesh = new MFnMesh(dag.item());
            var meshParent = new MFnTransform(mFnMesh.parent(0));

            if (meshes.Exists(m => m.Name == meshParent.name))
                continue;
            
            meshes.Add(new Mesh(meshParent.name));
        }
        
        return meshes;
    }
}