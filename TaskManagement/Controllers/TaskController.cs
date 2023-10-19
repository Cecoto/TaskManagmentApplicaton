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
        private readonly ILogger<TaskController> logger;

        public TaskController(ITaskService _taskService,
            ILogger<TaskController> _logger)
        {
            this.taskService = _taskService;
            this.logger = _logger;
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid task data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await taskService.AddTaskAsync(dto);

            return Ok(task);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetTasks()
        {

            try
            {
                var tasks = await taskService.GetTasksAsync();

                return Ok(tasks);

            }
            catch (Exception ex)
            {

                this.logger.LogError(ex, "An error occurred while retrieving tasks.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
