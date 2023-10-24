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
        public async Task<IActionResult> CreateTask([FromBody] FormTaskDto dto)
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
        [HttpGet]
        [Route("EditTask/{taskId}")]
        public async Task<IActionResult> GetTaskForEdit(Guid taskId)
        {
            FormTaskDto task = await taskService.GetTaskForEditByIdAsync(taskId);

            if (task != null)
            {
                return Ok(task);
            }

            return NotFound();
        }
        [HttpPut]
        [Route("EditTask/{taskId}")]
        public async Task<IActionResult> EditTask(Guid taskId, [FromBody] FormTaskDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid task data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTask = await taskService.EditTaskAsync(taskId, dto);

            if (updatedTask == null)
            {
                return NotFound("Task not found");
            }

            return Ok(updatedTask);
        }
        [HttpPost]
        [Route("DeleteTask/{taskId}")]
        public async Task<IActionResult>DeleteTask(Guid taskId)
        {

            bool isDeleted = await taskService.DeleteTaskByIdAsync(taskId);

            if (isDeleted)
            {
                return Ok("Successfully deleted!");
            }
            return NotFound("Task not found!");
        }
    }
}
