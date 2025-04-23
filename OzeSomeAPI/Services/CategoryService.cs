using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models.Dtos.New;

namespace OzeSomeAPI.Services
{
    public class CategoryService : BaseService<Category, CategoryDto, NewCategoryDto>

    {
        public CategoryService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<CategoryDto> CreateAsync(NewCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            category.CreationDateTime = DateTime.UtcNow;
            category.IsActive = true;
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(category);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }
            category.IsActive = false;
            category.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.Where(x => x.IsActive).ToListAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public override async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public override async Task<Category> UpdateAsync(CategoryDto dto)
        {
            var category = await _context.Categories.FindAsync(dto.Id);
            if (category != null)
            {
                _mapper.Map(dto, category);
                category.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return category;
        }
        public async Task<IEnumerable<SelectDto>> GetSelectList()
        {
            var categories = await _context.Categories
                .Where(c => c.IsActive)
                .Select(c => new SelectDto
                {
                    Id = c.Id,
                    DisplayName = c.CategoryName
                })
                .ToListAsync();
            return categories;
        }
    }
}
