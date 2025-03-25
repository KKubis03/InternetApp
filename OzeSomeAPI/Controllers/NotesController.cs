using Microsoft.AspNetCore.Mvc;
using OzeSome.Data.Models.Dtos;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteService _noteService;
        public NotesController(NoteService noteService)
        {
            _noteService = noteService;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotes()
        {
            var notesDto = await _noteService.GetAllAsync();
            return Ok(notesDto);
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDto>> GetNote(Guid id)
        {
            var noteDto = await _noteService.GetByIdAsync(id);
            if (noteDto == null)
            {
                return NotFound();
            }
            return Ok(noteDto);
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(Guid id, NoteDto noteDto)
        {
            if(id != noteDto.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedNote = await _noteService.UpdateAsync(noteDto);
                if (updatedNote == null)
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

        // POST: api/Notes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoteDto>> PostNote(NoteDto noteDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var noteDtoCreated = await _noteService.CreateAsync(noteDto);
            if (noteDtoCreated == null)
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction("GetNote", new { id = noteDtoCreated.Id }, noteDtoCreated);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            var result = await _noteService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
