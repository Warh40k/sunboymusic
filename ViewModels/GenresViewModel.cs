using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using SunBoyMusicStore.Models;
using SunBoyMusicStore.Models.Base;
using SunBoyMusicStore.ViewModels.Base;

namespace SunBoyMusicStore.ViewModels;

public sealed class GenresViewModel: EntityViewModel<Genre>
{
    public GenresViewModel()
    {
        Repository = DataManager.Genres;
        _output_data = new ObservableCollection<Genre>(Repository);
        SearchCommand = ReactiveCommand.Create<List<object?>>(Search);
        AddCommand = ReactiveCommand.Create<List<object?>>(Add);
        RemoveCommand = ReactiveCommand.Create<int>(Remove);
    }

    protected override void Add(List<object?> vals)
    {
        if (vals[0] != null)
        {
            Repository.Add(new Genre(vals[0].ToString()));
            Data = new ObservableCollection<Genre>(Repository);
        }
    }

    protected override void Search(List<object?> values)
    {
        var selected = Repository.Where(genre =>
            genre.Name.Contains(values[0].ToString() ?? "")); 
        Data = new ObservableCollection<Genre>(selected);
    }
}