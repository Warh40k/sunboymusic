using SunBoyMusicStore.Models.Base;

namespace SunBoyMusicStore.Models;

public class Compilation: Attribute
{
    public string Description { get; set; }
    public Compilation(string name, string description)
    {
        Name = name;
        Description = description;
    }
}