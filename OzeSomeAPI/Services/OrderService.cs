using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;

namespace OzeSomeAPI.Services
{
    public class OrderService : BaseService<Order, OrderDto>
    {
        public OrderService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<OrderDto> CreateAsync(OrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            order.CreationDateTime = DateTime.UtcNow;
            order.IsActive = true;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDto>(order);
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }
            order.IsActive = false;
            order.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _context.Orders.Where(o => o.IsActive).ToListAsync();
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public override async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id && o.IsActive == true);
            return _mapper.Map<OrderDto>(order);
        }

        public override async Task<Order> UpdateAsync(OrderDto dto)
        {
            var order = await _context.Orders.FindAsync(dto.Id);
            if (order != null)
            {
                _mapper.Map(dto, order);
                order.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return order;
        }
    }
}
