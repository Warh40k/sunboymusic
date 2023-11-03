using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using SunBoyMusicStore.Models;
using SunBoyMusicStore.Models.Base;
using SunBoyMusicStore.ViewModels.Base;

namespace SunBoyMusicStore.ViewModels;

public sealed class CompilationsViewModel: EntityViewModel<Compilation>
{
    public CompilationsViewModel()
    {
        Repository = DataManager.Compilations;
        Repository.Add(new Compilation("Дискотека 90-ых", "Весело как в последний раз в жизни"));
        _output_data = new ObservableCollection<Compilation>(Repository);
        SearchCommand = ReactiveCommand.Create<List<object?>>(Search);
        AddCommand = ReactiveCommand.Create<List<object?>>(Add);
        RemoveCommand = ReactiveCommand.Create<int>(Remove);
    }

    protected override void Add(List<object?> vals)
    {
        if (vals[0] != null && vals[1] != null)
        {
            Repository.Add(new Compilation(vals[0].ToString(), vals[1].ToString()!));
            Data = new ObservableCollection<Compilation>(Repository);
        }
    }

    protected override void Search(List<object?> values)
    {
        var selected = Repository.Where(compilation =>
            compilation.Name.Contains(values[0].ToString() ?? "") && compilation.Description.Contains(values[1].ToString() ?? "")); 
        Data = new ObservableCollection<Compilation>(selected);
    }
}