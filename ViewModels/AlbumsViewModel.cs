using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using DynamicData;
using SunBoyMusicStore.Models.Base;
using ReactiveUI;
using SunBoyMusicStore.Models;
using SunBoyMusicStore.ViewModels.Base;

namespace SunBoyMusicStore.ViewModels;

public sealed class AlbumsViewModel: EntityViewModel<Album>
{
    public AlbumsViewModel()
    {
        Repository = DataManager.Albums;
        _output_data = new ObservableCollection<Album>(Repository);
        SearchCommand = ReactiveCommand.Create<List<object?>>(Search);
        AddCommand = ReactiveCommand.Create<List<object?>>(Add);
        RemoveCommand = ReactiveCommand.Create<int>(Remove);
    }

    protected override void Add(List<object?> vals)
    {
        if (vals[0] != null && vals[1] != null && vals[2] != null)
        {
            Repository.Add(new Album((string?)vals[0], (Artist)vals[1], (DateTimeOffset)vals[2]));
            Data = new ObservableCollection<Album>(Repository);
        }
    }

    protected override void Search(List<object?> values)
    {
        var selected = Repository.Where(album => album.Name.Contains((string?)values[0] ?? "") 
                                                 && album.Artist.Name.Contains((string?)values[1] ?? "")); 
        Data = new ObservableCollection<Album>(selected);
    }
}