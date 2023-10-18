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

            modelBuilder.Entity<TaskType>()
                .HasData(GenerateTypes());
        }

        private TaskType[] GenerateTypes()
        {
            ICollection<TaskType> types = new HashSet<TaskType>();

            types.Add(new TaskType
            {
                Id= 1,
                Name = "Personal"
            });
            types.Add(new TaskType
            {
                Id = 2,
                Name = "Professional"
            });
            types.Add(new TaskType
            {
                Id = 3,
                Name = "Education & Learning"
            });
            types.Add(new TaskType
            {
                Id = 4,
                Name = "Organization & Planning"
            });

            return types.ToArray();
        }
    }
}
