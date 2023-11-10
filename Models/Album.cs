using System;
using System.Collections.Generic;
using Attribute = SunBoyMusicStore.Models.Base.Attribute;

namespace SunBoyMusicStore.Models;

public class Album: Attribute
{
    public DateTimeOffset PublishDate { get; set; }
    public Artist Artist { get; set; }

    public Album(string name, Artist artist, DateTimeOffset publishDate)
    {
        Name = name;
        Artist = artist;
        PublishDate = publishDate;
    }

    int GetTracksCount()
    {
        throw new NotImplementedException();
    }
}