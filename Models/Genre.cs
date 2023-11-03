using SunBoyMusicStore.Models.Base;

namespace SunBoyMusicStore.Models;

public class Genre: Attribute
{
    public Genre(string name)
    {
        Name = name;
    }
}