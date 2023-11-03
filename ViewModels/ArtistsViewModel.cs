using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using SunBoyMusicStore.Models;
using SunBoyMusicStore.Models.Base;
using SunBoyMusicStore.ViewModels.Base;

namespace SunBoyMusicStore.ViewModels;

public sealed class ArtistsViewModel: EntityViewModel<Artist>
{
    public ArtistsViewModel()
    {
        Repository = DataManager.Artists;
        Repository.Add(new Artist("Anton", new Genre("hip-hop")));
        _output_data = new ObservableCollection<Artist>(Repository);
        SearchCommand = ReactiveCommand.Create<List<object?>>(Search);
        AddCommand = ReactiveCommand.Create<List<object?>>(Add);
        RemoveCommand = ReactiveCommand.Create<int>(Remove);
    }

    protected override void Add(List<object?> vals)
    {
        if (vals[0] != null && vals[1] != null)
        {
            Repository.Add(new Artist(vals[0].ToString(), (Genre)vals[1]) {Age = (int?)vals[2] ?? 0});
            Data = new ObservableCollection<Artist>(Repository);
        }
    }

    protected override void Search(List<object?> values)
    {
        var selected = Repository.Where(artist =>
            artist.Name.Contains(values[0].ToString() ?? "") && artist.Genre.Equals((Genre)values[1])); 
        Data = new ObservableCollection<Artist>(selected);
    }
}