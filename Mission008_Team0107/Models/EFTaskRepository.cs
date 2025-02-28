namespace Mission008_Team0107.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskManagementContext _context;

        public EFTaskRepository(TaskManagementContext temp)
        {
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();
        public List<Quadrant> Quadrants => _context.Quadrants.ToList();
        public List<Category> Categories => _context.Categories.ToList();

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}