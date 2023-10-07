namespace TodoMaui.Pages.Todo;

public class TaskItemModel
{
    public int Id { get; set; }
    public string Task { get; set; }
    public bool Done { get; set; } = false;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }

}
