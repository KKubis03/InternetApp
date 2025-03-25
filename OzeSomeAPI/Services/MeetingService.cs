using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;

namespace OzeSomeAPI.Services
{
    public class MeetingService : BaseService<Meeting, MeetingDto>
    {
        public MeetingService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<MeetingDto> CreateAsync(MeetingDto dto)
        {
            var meeting = new Meeting()
            {
                Id = Guid.NewGuid(),
                CustomerId = dto.CustomerId,
                MeetingDate = dto.MeetingDate,
                MeetingStatus = dto.MeetingStatus,
                CreationDateTime = DateTime.UtcNow,
                IsActive = true
            };
            await _context.Meetings.AddAsync(meeting);
            await _context.SaveChangesAsync();
            return _mapper.Map<MeetingDto>(meeting);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return false;
            }
            meeting.IsActive = false;
            meeting.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<MeetingDto>> GetAllAsync()
        {
            var meetings = await _context.Meetings.Include(m => m.Customer).Where(m => m.IsActive).ToListAsync();
            var meetingsDto = _mapper.Map<IEnumerable<MeetingDto>>(meetings);
            return meetingsDto;
        }

        public override async Task<MeetingDto> GetByIdAsync(Guid id)
        {
            var meeting = await _context.Meetings.Include(m => m.Customer).FirstOrDefaultAsync(m => m.Id == id && m.IsActive == true);
            return _mapper.Map<MeetingDto>(meeting);
        }

        public override async Task<Meeting> UpdateAsync(MeetingDto dto)
        {
            var meeting = await _context.Meetings.FindAsync(dto.Id);
            if (meeting != null)
            {
                _mapper.Map(dto, meeting);
                meeting.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return meeting;
        }
    }
}
