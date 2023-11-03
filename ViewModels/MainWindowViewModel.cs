using System.Reactive;
using Avalonia.Controls;
using ReactiveUI;
using SunBoyMusicStore.ViewModels.Base;
using SunBoyMusicStore.Views;

namespace SunBoyMusicStore.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ReactiveCommand<string, Unit> OpenCommand { get; }

    public MainWindowViewModel()
    {
        OpenCommand = ReactiveCommand.Create<string>(NewWindow);
    }

    private void NewWindow(string ent)
    {
        Window model = ent switch
        {
            "Artists" => new ArtistsView() {DataContext = new ArtistsViewModel()},
            "Albums" => new AlbumsView() {DataContext = new AlbumsViewModel()},
            "Compilations" => new CompilationsView() {DataContext = new CompilationsViewModel()},
            "Genres" => new GenresView() {DataContext = new GenresViewModel()},
            _ => new TracksView() {DataContext = new TracksViewModel()}
        };
        model.Show();
    }
}