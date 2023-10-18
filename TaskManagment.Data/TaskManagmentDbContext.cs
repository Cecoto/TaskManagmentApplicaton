namespace TaskManagment.Data
{
    using TaskManagment.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    public class TaskManagmentDbContext : DbContext
    {

        public TaskManagmentDbContext(DbContextOptions<TaskManagmentDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<Task> Tasks { get; set; } = null!;

        public DbSet<TaskType> TaskTypes { get; set; } = null!;

    }
}
