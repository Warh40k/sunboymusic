using System.Collections.Generic;
using SunBoyMusicStore.Models.Base;

namespace SunBoyMusicStore.Models;

public class Artist: Attribute
{
    public Artist(string name, Genre genre, int age)
    {
        Name = name;
        Genre = genre;
        Age = age;
    }

    public Genre Genre { get; }
    public int Age { get; set; }
    
}