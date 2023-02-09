using System.Collections.Generic;

namespace RetargetMayaPlugin.Models;

public class ExportContext
{
    public string CharacterName { get; }
    public IEnumerable<Mesh> Meshes { get; }
    public IEnumerable<Clip> Clips { get; }
    
    public ExportContext(IEnumerable<Mesh> meshes, IEnumerable<Clip> clips, string characterName)
    {
        Meshes = meshes;
        Clips = clips;
        CharacterName = characterName;
    }
}