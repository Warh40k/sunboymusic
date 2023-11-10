using System.Reactive;
using Avalonia.Controls;
using ReactiveUI;
using SunBoyMusicStore.Models.Base;
using SunBoyMusicStore.ViewModels.Base;
using SunBoyMusicStore.Views;

namespace SunBoyMusicStore.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ReactiveCommand<string, Unit> OpenCommand { get; }

    public MainWindowViewModel()
    {
        OpenCommand = ReactiveCommand.Create<string>(NewWindow);
        DataManager.AddSampleData();
    }

    private void NewWindow(string ent)
    {
        Window model = ent switch
        {
            "Artists" => new ArtistsView {DataContext = ViewModelManager.GetInstance<ArtistsViewModel>()},
            "Albums" => new AlbumsView {DataContext = ViewModelManager.GetInstance<AlbumsViewModel>()},
            "Compilations" => new CompilationsView {DataContext = ViewModelManager.GetInstance<CompilationsViewModel>()},
            "Genres" => new GenresView {DataContext = ViewModelManager.GetInstance<GenresViewModel>()},
            _ => new TracksView {DataContext = ViewModelManager.GetInstance<TracksViewModel>()}
        };
        model.Show();
    }
}