namespace Mission008_Team0107.Models;

public interface ITaskRepository
{
    List<TaskObj> Tasks { get; }
    List<Quadrant> Quadrants { get; }
    List<Category> Categories { get; }
    public void AddTask(TaskObj task);
    public void UpdateTask(TaskObj task);
    public void DeleteTask(TaskObj task);
    //MAttia added this
    public List<TaskObj> GetTasksWithDetails();
}