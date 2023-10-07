using CommunityToolkit.Mvvm.ComponentModel;

namespace TodoMaui.Abstracts;

public partial class AbstractViewModel : ObservableObject
{

    [ObservableProperty]
    private bool _isBusy;

    public virtual Task InitializeAsync(Dictionary<string, object> parameters)
    {
        return Task.CompletedTask;
    }

    public virtual Task Destroy() { return Task.CompletedTask; }
}
