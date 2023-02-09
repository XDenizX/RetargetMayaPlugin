namespace RetargetMayaPlugin.Models;

public class Clip
{
    public string Name { get; }
    public double Duration { get; }
    
    public Clip(string name, double duration)
    {
        Name = name;
        Duration = duration;
    }
}