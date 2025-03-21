using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;

namespace OzeSomeAPI.Services
{
    public class ProductService : BaseService<Product, ProductDto>
    {
        public ProductService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            //var product = _mapper.Map<Product>(dto);
            var product = new Product
            {
                Id = dto.Id,
                ProductName = dto.ProductName,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                CreationDateTime = DateTime.UtcNow,
                IsActive = true
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            product.IsActive = false;
            product.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _context.Products.Include(p => p.Category).Where(p => p.IsActive).ToListAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        public override async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id && p.IsActive == true);
            return _mapper.Map<ProductDto>(product);
        }

        public override async Task<Product> UpdateAsync(ProductDto dto)
        {
            var product = await _context.Products.FindAsync(dto.Id);
            if (product != null)
            {
                _mapper.Map(dto, product);
                product.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return product;
        }
    }
}
