using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
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
        if (vals[0] != null && vals[1] != null)
        {
            Repository.Add(new Album(
                vals[0].ToString(),
                new Artist("Berba", new Genre("lol")),
                DateTime.Now));
            Data = new ObservableCollection<Album>(Repository);
        }
    }

    protected override void Search(List<object?> values)
    {
        throw new NotImplementedException();
    }
}