using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SunBoyMusicStore.Models.Base;
using ReactiveUI;
using SunBoyMusicStore.Models;
using SunBoyMusicStore.ViewModels.Base;

namespace SunBoyMusicStore.ViewModels;

public sealed class TracksViewModel: EntityViewModel<Track>
{
    public TracksViewModel()
    {
        Repository = DataManager.Tracks;
        _output_data = new ObservableCollection<Track>(Repository);
        SearchCommand = ReactiveCommand.Create<List<object?>>(values => Search(values));
        AddCommand = ReactiveCommand.Create<List<object?>>(vals => Add(vals));
        RemoveCommand = ReactiveCommand.Create<int>(Remove);
    }

    protected override void Search(List<object?> values)
    {
        var selected = Repository.Where(track => track.Name.Contains((string?)values[0] ?? "") && track.Album.Name.Contains((string?)values[1]  ?? "")); 
        Data = new ObservableCollection<Track>(selected);
    }

    protected override void Add(List<object?> vals)
    {
        Repository.Add(new Track((string)vals[0], (Album)vals[1], (TimeSpan)vals[2], (bool)vals[3]!));
        Data = new ObservableCollection<Track>(Repository);
    }
}