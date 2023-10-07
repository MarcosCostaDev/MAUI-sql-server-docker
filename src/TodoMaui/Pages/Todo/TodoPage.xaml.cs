using TodoMaui.Abstracts;

namespace TodoMaui.Pages.Todo;

public partial class TodoPage : AbstractContentPage
{
	public TodoPage(TodoViewModel todoViewModel)
	{
		InitializeComponent();
		BindingContext = todoViewModel;
    }
}