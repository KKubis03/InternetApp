using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models.Dtos.New;

namespace OzeSomeAPI.Services
{
    public class NoteService : BaseService<Note, NoteDto, NewNoteDto>
    {
        public NoteService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<NoteDto> CreateAsync(NewNoteDto dto)
        {
            var note = _mapper.Map<Note>(dto);
            note.CreationDateTime = DateTime.UtcNow;
            note.IsActive = true;
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            return _mapper.Map<NoteDto>(note);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return false;
            }
            note.IsActive = false;
            note.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<NoteDto>> GetAllAsync()
        {
            var notes = await _context.Notes.Where(n => n.IsActive).ToListAsync();
            var notesDto = _mapper.Map<IEnumerable<NoteDto>>(notes);
            return notesDto;
        }

        public override async Task<NoteDto> GetByIdAsync(Guid id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id && n.IsActive == true);
            return _mapper.Map<NoteDto>(note);
        }

        public override async Task<Note> UpdateAsync(NoteDto dto)
        {
            var note = await _context.Notes.FindAsync(dto.Id);
            if (note != null)
            {
                _mapper.Map(dto, note);
                note.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return note;
        }
    }
}
