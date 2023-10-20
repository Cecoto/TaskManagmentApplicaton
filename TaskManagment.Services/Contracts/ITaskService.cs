namespace TaskManagment.Services.Contracts
{
    using TaskManagement.DTOs;
    using TaskManagment.Data;

    public interface ITaskService
    {
        Task<Task> AddTaskAsync(FormTaskDto dto);
        Task<IEnumerable<TaskDto>> GetTasksAsync();
        Task<FormTaskDto> EditTaskAsync(Guid taskId, FormTaskDto dto);
        Task<FormTaskDto> GetTaskForEditByIdAsync(Guid taskId);
        Task<bool> DeleteTaskByIdAsync(Guid taskId);
    }
}
