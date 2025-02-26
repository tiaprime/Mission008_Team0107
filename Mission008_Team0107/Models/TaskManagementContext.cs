using Microsoft.EntityFrameworkCore;

namespace Mission008_Team0107.Models;

public class TaskManagementContext :DbContext
{
    public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
    {
        
    }
    
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Quadrant> Quadrants { get; set; }
    public DbSet<Category> Categories { get; set; }
}