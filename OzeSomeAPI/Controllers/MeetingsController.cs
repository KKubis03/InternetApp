using Microsoft.AspNetCore.Mvc;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models.Dtos.New;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly MeetingService _meetingService;

        public MeetingsController(MeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        // GET: api/Meetings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingDto>>> GetMeetings()
        {
            var meetingsDto = await _meetingService.GetAllAsync();
            return Ok(meetingsDto);
        }

        // GET: api/Meetings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDto>> GetMeeting(Guid id)
        {
            var meetingDto = await _meetingService.GetByIdAsync(id);
            if (meetingDto == null)
            {
                return NotFound();
            }
            return Ok(meetingDto);
        }

        // PUT: api/Meetings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeeting(Guid id, MeetingDto meetingDto)
        {
            if (id != meetingDto.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedMeeting = await _meetingService.UpdateAsync(meetingDto);
                if (updatedMeeting == null)
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

        // POST: api/Meetings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MeetingDto>> PostMeeting(NewMeetingDto meetingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var meetingDtoCreated = await _meetingService.CreateAsync(meetingDto);
            if (meetingDtoCreated == null)
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction("GetMeeting", new { id = meetingDtoCreated.Id }, meetingDto);
        }

        // DELETE: api/Meetings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(Guid id)
        {
            var result = await _meetingService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
