using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using SunBoyMusicStore.Models.Base;

namespace SunBoyMusicStore.ViewModels.Base;

public abstract class EntityViewModel<T>:ViewModelBase where T:Attribute
{
    protected ObservableCollection<T> _output_data = null!;
    protected ObservableCollection<T> _repository = null!;

    public ObservableCollection<T> Repository
    {
        get => _repository;
        set => this.RaiseAndSetIfChanged(ref _repository, value);
    }
    public ReactiveCommand<List<object?>, Unit> SearchCommand  { get; set; }
    public ReactiveCommand<List<object?>, Unit> AddCommand  { get; set; }
    public ReactiveCommand<int, Unit> RemoveCommand  { get; set; }
    
    public ObservableCollection<T> Data
    {
        get => _output_data;
        set => this.RaiseAndSetIfChanged(ref _output_data, value);
    }

    protected abstract void Search(List<object?> values);

    protected abstract void Add(List<object?> vals);
    protected void Remove(int val)
    {
        Repository.RemoveAt(val);
        _output_data.RemoveAt(val);
    }
}