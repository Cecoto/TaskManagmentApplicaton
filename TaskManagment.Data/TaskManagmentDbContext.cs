namespace TaskManagment.Data
{
    using TaskManagment.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.EntityFrameworkCore;
    public class TaskManagmentDbContext : DbContext
    {

        public TaskManagmentDbContext(DbContextOptions<TaskManagmentDbContext> options)
        : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; } = null!;

        public DbSet<TaskType> TaskTypes { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>()
                .Property(t => t.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Task>()
                .Property(t => t.CreatedOn)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
