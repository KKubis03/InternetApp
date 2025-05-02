using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models.Dtos.New;

namespace OzeSomeAPI.Services
{
    public class TaskService : BaseService<OzeSome.Data.Models.Task, TaskDto, NewTaskDto>
    {
        public TaskService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<TaskDto> CreateAsync(NewTaskDto dto)
        {
            var task = _mapper.Map<OzeSome.Data.Models.Task>(dto);
            task.CreationDateTime = DateTime.UtcNow;
            task.IsActive = true;
            task.TaskStatusId = 4;
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskDto>(task);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }
            task.IsActive = false;
            task.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            var tasks = await _context.Tasks.Include(t => t.TaskStatus).Where(t => t.IsActive).ToListAsync();
            var tasksDto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return tasksDto;
        }

        public override async Task<TaskDto> GetByIdAsync(Guid id)
        {
            var task = await _context.Tasks.Include(t => t.TaskStatus).FirstOrDefaultAsync(t => t.Id == id && t.IsActive == true);
            return _mapper.Map<TaskDto>(task);
        }

        public override async Task<OzeSome.Data.Models.Task> UpdateAsync(TaskDto dto)
        {
            var task = await _context.Tasks.FindAsync(dto.Id);
            if (task != null)
            {
                _mapper.Map(dto, task);
                task.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return task;
        }
        public async Task<IEnumerable<StatusDto>> GetStatusses()
        {
            var statusses = await _context.TaskStatuses
                .Where(a => a.IsActive)
                .Select(a => new StatusDto
                {
                    Id = a.Id,
                    StatusName = a.StatusName
                })
                .ToListAsync();
            return statusses;
        }
    }
}
