namespace TaskManagment.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Reflection;
    using TaskManagement.DTOs;
    using TaskManagment.Data;
    using TaskManagment.Services.Contracts;

    public class TaskService : ITaskService
    {
        private readonly TaskManagmentDbContext context;
        public TaskService(TaskManagmentDbContext _context)
        {
            this.context = _context;
        }
        public async Task<Task> AddTaskAsync(CreateTaskDto dto)
        {
            var task = new Task()
            {
                Title = dto.Title,
                Description = dto.Description,
                TaskTypeId = dto.TaskTypeId
            };

            context.Tasks.Add(task);
            await context.SaveChangesAsync();

            return task;
        }

        public async Task<IEnumerable<Task>> GetTasksAsync()
        {
            return  await this.context
                .Tasks
                .ToListAsync();
        }
    }
}