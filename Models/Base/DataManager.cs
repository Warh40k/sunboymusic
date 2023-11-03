using System;
using System.Collections.ObjectModel;

namespace SunBoyMusicStore.Models.Base;

public static class DataManager
{
    public static ObservableCollection<Artist> Artists { get; set; } = new();
    public static ObservableCollection<Album> Albums { get; set; } = new();
    public static ObservableCollection<Track> Tracks { get; set; }= new();
    public static ObservableCollection<Genre> Genres { get; set; } = new() ;
    public static ObservableCollection<Compilation> Compilations { get; set; } = new();
}