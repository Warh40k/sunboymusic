using System.Collections.Generic;
using SunBoyMusicStore.ViewModels.Base;

namespace SunBoyMusicStore.ViewModels;

public static class ViewModelManager
{
    public static List<ViewModelBase>? ViewModels = new();

    public static ViewModelBase GetInstance<T>() where T : ViewModelBase, new()
    {
        foreach (var viewModel in ViewModels)
        {
            if (viewModel is T)
                return viewModel;
        }

        var instance = new T();
        ViewModels.Add(instance);
        return instance;
    }
}