using Microsoft.AspNetCore.Mvc;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models.Dtos.New;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }
        // GET: api/Tasks/statusses
        [HttpGet("statusses")]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetTaskStatusses()
        {
            var st = await _taskService.GetStatusses();
            return Ok(st);
        }
        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var tasksDto = await _taskService.GetAllAsync();
            return Ok(tasksDto);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(Guid id)
        {
            var taskDto = await _taskService.GetByIdAsync(id);
            if (taskDto == null)
            {
                return NotFound();
            }
            return Ok(taskDto);
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(Guid id, TaskDto task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedTask = await _taskService.UpdateAsync(task);
                if (updatedTask == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return NoContent();
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskDto>> PostTask(NewTaskDto task)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdTask = await _taskService.CreateAsync(task);
            if(createdTask == null)
            {
                return StatusCode(500, "Error creating task");
            }
            return CreatedAtAction("GetTask", new { id = createdTask.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var deletedTask = await _taskService.DeleteAsync(id);
            if (deletedTask == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
