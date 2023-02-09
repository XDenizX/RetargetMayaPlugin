using System.Collections.Generic;
using System.Linq;
using Autodesk.Maya.OpenMaya;
using Autodesk.Maya.OpenMayaAnim;
using RetargetMayaPlugin.Models;

namespace RetargetMayaPlugin.Helpers;

public static class ClipHelper
{
    public static IEnumerable<Clip> GetClips(MObject character)
    {
        var clips = new List<Clip>();
        var fnCharacter = new MFnCharacter(character);
        var clipCount = fnCharacter.sourceClipCount;

        for (var i = 0; i < clipCount; i++)
        {
            var clip = fnCharacter.getSourceClip(i);
            var fnClip = new MFnClip(clip);
            
            // Avoid duplicates in clip list.
            if (!clips.Exists(c => c.Name == fnClip.name))
                clips.Add(new Clip(fnClip.name, fnClip.sourceDuration.value));
        }
        
        return clips;
    }
}