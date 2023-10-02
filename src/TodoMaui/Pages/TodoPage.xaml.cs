using TodoMaui.ViewModels;

namespace TodoMaui.Pages;

public partial class TodoPage : ContentPage
{
	public TodoPage(TodoViewModel todoViewModel)
	{
		InitializeComponent();
		BindingContext = todoViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

       await (BindingContext as TodoViewModel).InitializeAsync();
    }
}