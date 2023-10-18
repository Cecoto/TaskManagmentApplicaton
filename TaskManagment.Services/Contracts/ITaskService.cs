namespace TaskManagment.Services.Contracts
{
    using TaskManagement.DTOs;
    using TaskManagment.Data;

    public interface ITaskService
    {

        Task<Task> AddTaskAsync(CreateTaskDto dto);
        
    }
}
