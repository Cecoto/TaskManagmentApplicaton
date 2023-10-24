namespace TaskManagment.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
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
        public async Task<Task> AddTaskAsync(FormTaskDto dto)
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

        public async Task<bool> DeleteTaskByIdAsync(Guid taskId)
        {


            Task task = await context.Tasks.FindAsync(taskId);

            if (task!=null)
            {
                task.IsActive = false;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<FormTaskDto> EditTaskAsync(Guid taskId, FormTaskDto dto)
        {
            var existingTask = await context.Tasks.FindAsync(taskId);
            if (existingTask != null)
            {
                existingTask.Title = dto.Title;
                existingTask.Description = dto.Description;
                existingTask.TaskTypeId = dto.TaskTypeId;

                await context.SaveChangesAsync();

                return new FormTaskDto()
                {
                    Title = existingTask.Title,
                    Description = existingTask.Description,
                    TaskTypeId = existingTask.TaskTypeId
                };
            }

            return null!;
        }

        public async Task<FormTaskDto> GetTaskForEditByIdAsync(Guid taskId)
        {
          Task task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

            if (task!=null)
            {
                return new FormTaskDto()
                {
                    Title = task.Title,
                    Description = task.Description,
                    TaskTypeId = task.TaskTypeId
                };
            }
            return null!;
        }

        public async Task<IEnumerable<TaskDto>> GetTasksAsync()
        {
           var tasks = await context.Tasks
                .Where(t=>t.IsActive==true)
                .Select(t=> new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd:MM:yy"),
                    Type = t.Type.Name
                }).ToArrayAsync();

            return tasks;
        }
    }
}