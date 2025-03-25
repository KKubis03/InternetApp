using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public DocumentsController(DocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentDto>>> GetDocuments()
        {
            var documentsDto = await _documentService.GetAllAsync();
            return Ok(documentsDto);
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDto>> GetDocument(Guid id)
        {
            var documentDto = await _documentService.GetByIdAsync(id);
            if (documentDto == null)
            {
                return NotFound();
            }
            return Ok(documentDto);
        }

        // PUT: api/Documents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(Guid id, DocumentDto document)
        {
            if (id != document.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedDocument = await _documentService.UpdateAsync(document);
                if (updatedDocument == null)
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

        // POST: api/Documents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentDto>> PostDocument(DocumentDto document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var documentDtoCreated = await _documentService.CreateAsync(document);
            if (documentDtoCreated == null)
            {
                return BadRequest(ModelState);
            }
            return CreatedAtAction("GetDocument", new { id = documentDtoCreated.Id }, documentDtoCreated);
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            var deletedDocument = await _documentService.DeleteAsync(id);
            if (deletedDocument == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
