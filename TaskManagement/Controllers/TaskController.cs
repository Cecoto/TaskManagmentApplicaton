namespace TaskManagementApi.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TaskManagement.DTOs;
    using TaskManagment.Data;
    using TaskManagment.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService taskService;

        public TaskController(ITaskService _taskService)
        {
           this.taskService = _taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
        {
            if (dto== null)
            {
                return BadRequest("Invalid task data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await taskService.AddTaskAsync(dto);

            return  Ok(task);
        }
    }
}
