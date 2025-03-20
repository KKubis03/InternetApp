using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;

namespace OzeSomeAPI.Services
{
    public class CustomerService : BaseService<Customer, CustomerDto>
    {
        public CustomerService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<CustomerDto> CreateAsync(CustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            customer.CreationDateTime = DateTime.UtcNow;
            customer.IsActive = true;
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerDto>(customer);
        }

        public override async Task<bool> DeleteAsync(int Id)
        {
            var customer = await _context.Customers.FindAsync(Id);
            if (customer == null)
            {
                return false;
            }
            customer.IsActive = false;
            customer.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _context.Customers.Include(c => c.Address).Where(c => c.IsActive == true).ToListAsync();
            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return customersDto;
        }

        public override async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public override async Task<Customer> UpdateAsync(CustomerDto dto)
        {
            var customer = await _context.Customers.FindAsync(dto.Id);
            if (customer != null)
            {
                _mapper.Map(dto, customer);
                await _context.SaveChangesAsync();
            }
            return customer;
        }
        protected bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
