using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoMaui.Abstracts;

namespace TodoMaui.Pages.Todo;

public partial class TodoViewModel : AbstractViewModel
{

    public TodoViewModel(TodoRepository repository)
    {
        TodoRepository = repository;
    }
    [ObservableProperty]
    private int _taskItemId;

    [ObservableProperty]
    private string _taskItem;

    [ObservableProperty]
    private ObservableCollection<TaskItemModel> _tasks;

    internal TodoRepository TodoRepository { get; }

    public async Task InitializeAsync()
    {
        List();
    }

    [RelayCommand]
    private void AddItem()
    {
        if (string.IsNullOrEmpty(TaskItem)) return;
        if(TaskItemId > 0)
        {
            TodoRepository.Update(TaskItemId, TaskItem);
            TaskItemId = 0;
        }
        else
        {
            TodoRepository.Add(TaskItem);
        }

        TaskItem = string.Empty;
        List();
    }

    [RelayCommand]
    private void DeleteItem(TaskItemModel taskItemModel)
    {
        TodoRepository.Remove(taskItemModel.Id);
        List();
    }

    [RelayCommand]
    private void EditItem(TaskItemModel taskItemModel)
    {
        TaskItemId = taskItemModel.Id;
        TaskItem = taskItemModel.Task;
    }

    [RelayCommand]
    private void DoneItem(TaskItemModel taskItemModel)
    {
        if (taskItemModel.Done)
        {
            TodoRepository.Undone(taskItemModel.Id);
        }
        else
        {
            TodoRepository.Done(taskItemModel.Id);
        }
        List();
    }

    private void List()
    {
      Tasks = new ObservableCollection<TaskItemModel>(TodoRepository.List());
    }
}
