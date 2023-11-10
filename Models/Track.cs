using System;
using System.Collections.Generic;

namespace SunBoyMusicStore.Models;

public class Track: Base.Attribute
{
    public Album Album { get; set; }
    public Compilation[] Compilations { get; set; }
    public TimeSpan Length { get; set; }
    public bool Explicit { get; set; }
    public Artist Artist => Album.Artist;

    public Track(string name, Album album, TimeSpan length, bool expl, string[]? compilations = null)
    {
        Album = album;
        Name = name;
        Length = length;
        Explicit = expl;
    }

    public new Dictionary<string, string> GetData()
    {
        var dict = base.GetData();
        dict["Album"] = Album.Name;
        dict["Genre"] = Artist.Genre.Name;
        
        return dict;
    }
}