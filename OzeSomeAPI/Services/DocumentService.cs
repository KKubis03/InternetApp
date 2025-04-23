using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models.Dtos.New;

namespace OzeSomeAPI.Services
{
    public class DocumentService : BaseService<Document, DocumentDto, NewDocumentDto>
    {
        public DocumentService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override async Task<DocumentDto> CreateAsync(NewDocumentDto dto)
        {
            var document = _mapper.Map<Document>(dto);
            document.CreationDateTime = DateTime.UtcNow;
            document.IsActive = true;
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
            return _mapper.Map<DocumentDto>(document);
        }
        public override async Task<bool> DeleteAsync(Guid id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return false;
            }
            document.IsActive = false;
            document.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
        public override async Task<IEnumerable<DocumentDto>> GetAllAsync()
        {
            var documents = await _context.Documents.Where(d => d.IsActive).ToListAsync();
            var documentsDto = _mapper.Map<IEnumerable<DocumentDto>>(documents);
            return documentsDto;
        }
        public override async Task<DocumentDto> GetByIdAsync(Guid id)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(d => d.Id == id && d.IsActive == true);
            return _mapper.Map<DocumentDto>(document);
        }
        public override async Task<Document> UpdateAsync(DocumentDto dto)
        {
            var document = await _context.Documents.FindAsync(dto.Id);
            if (document != null)
            {
                _mapper.Map(dto, document);
                document.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return document;
        }
    }
}
