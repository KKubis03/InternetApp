using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models.Dtos.New;

namespace OzeSomeAPI.Services
{
    public class OrderItemService : BaseService<OrderItem, OrderItemDto, NewOrderItemDto>
    {
        public OrderItemService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override async Task<OrderItemDto> CreateAsync(NewOrderItemDto dto)
        {
            var orderItem = _mapper.Map<OrderItem>(dto);
            orderItem.CreationDateTime = DateTime.UtcNow;
            orderItem.IsActive = true;
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderItemDto>(orderItem);
        }
        public override async Task<bool> DeleteAsync(Guid id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return false;
            }
            orderItem.IsActive = false;
            orderItem.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<OrderItemDto>> GetAllAsync(Guid orderId)
        {
            var orderItems = await _context.OrderItems.Include(oi => oi.Product).ThenInclude(p => p.Category).Where(oi => oi.IsActive && oi.OrderId == orderId).ToListAsync();
            var orderItemsDto = _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
            return orderItemsDto;
        }

        public async override Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var orderItems = await _context.OrderItems.Include(oi => oi.Product).ThenInclude(p => p.Category).Where(oi => oi.IsActive).ToListAsync();
            var orderItemsDto = _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
            return orderItemsDto;
        }

        public override async Task<OrderItemDto> GetByIdAsync(Guid id)
        {
            var orderItem = await _context.OrderItems.Include(oi => oi.Product).ThenInclude(p => p.Category).FirstOrDefaultAsync(oi => oi.Id == id && oi.IsActive == true);
            return _mapper.Map<OrderItemDto>(orderItem);
        }
        public override async Task<OrderItem> UpdateAsync(OrderItemDto dto)
        {
            var orderItem = await _context.OrderItems.FindAsync(dto.Id);
            if (orderItem != null)
            {
                _mapper.Map(dto, orderItem);
                orderItem.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return orderItem;
        }
    }
}
