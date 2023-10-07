namespace TodoMaui.Abstracts;

public class AbstractContentPage : ContentPage
{

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is AbstractViewModel viewModel)
        {
            _ = Task.Run(() =>
            {
                viewModel.InitializeAsync(new Dictionary<string, object>());
            });

        }
    }

    protected override void OnDisappearing()
    {
        if (BindingContext is AbstractViewModel viewModel)
        {
            _ = Task.Run(() =>
            {
                viewModel.Destroy();
            });
        }
    }
}
