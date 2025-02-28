namespace Mission008_Team0107.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        List<Quadrant> Quadrants { get; }
        List<Category> Categories { get; }
        public void AddTask(Task task);
        public void UpdateTask(Task task);
        public void DeleteTask(Task task);
    } 
}
