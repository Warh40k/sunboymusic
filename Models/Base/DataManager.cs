using System;
using System.Collections.ObjectModel;
using DynamicData;

namespace SunBoyMusicStore.Models.Base;

public static class DataManager
{
    public static ObservableCollection<Artist> Artists { get; set; } = new();
    public static ObservableCollection<Album> Albums { get; set; } = new();
    public static ObservableCollection<Track> Tracks { get; set; }= new();
    public static ObservableCollection<Genre> Genres { get; set; } = new() ;
    public static ObservableCollection<Compilation> Compilations { get; set; } = new();

    public static void AddSampleData()
    {
        var rb = new Genre("r&b");
        var hop = new Genre("hip-hop");
        var brutal = new Genre("Brutal Experimental Symphonic Industrial Death Doom Metal");
        Genres.Add(hop);
        Genres.Add(rb);
        Genres.Add(brutal);
        var Anton = new Artist("Anton", hop, 15);
        var Dimon = new Artist("Dimon", rb, 17);
        var Mike = new Artist("Mike", brutal, 55);
        Artists.Add(Anton);
        Artists.Add(Dimon);
        Artists.Add(Mike);
        var FirstOne = new Album("FirstOne", Anton, DateTime.Today);
        var SecondOne = new Album("SecondOne", Dimon, DateTime.Now);
        var Brut = new Album("Bruuh!", Mike, DateTime.UtcNow);
        Albums.Add(FirstOne);
        Albums.Add(SecondOne);
        Albums.Add(Brut);
        Tracks.Add(new Track("first", FirstOne, TimeSpan.FromMinutes(5), true));
        Tracks.Add(new Track("second", SecondOne, TimeSpan.FromMinutes(6), false));
        Tracks.Add(new Track("third", SecondOne, TimeSpan.FromMinutes(7), true));
        Tracks.Add(new Track("1", Brut, TimeSpan.FromMinutes(28), true));
        Tracks.Add(new Track("2", Brut, TimeSpan.FromMinutes(35), false));
    }
}