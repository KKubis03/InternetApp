using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;

namespace OzeSomeAPI.Services
{
    public class OrderDetailDto : BaseService<OrderDetail, OrderDetailsDto>
    {
        public OrderDetailDto(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<OrderDetailsDto> CreateAsync(OrderDetailsDto dto)
        {
            OrderDetail orderDetail = new OrderDetail
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                CustomerId = dto.CustomerId,
                TotalAmount = dto.ProductPrice,
            };
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
            return dto;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return false;
            }
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<OrderDetailsDto>> GetAllAsync()
        {
            var orderDetails = await _context.OrderDetails.Include(o => o.Product).ThenInclude(o => o.Category).Include(o => o.Order).Include(o => o.Customer).ToListAsync();
            var orderDetailsDto = _mapper.Map<IEnumerable<OrderDetailsDto>>(orderDetails);
            return orderDetailsDto;
        }

        public override async Task<OrderDetailsDto> GetByIdAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.Include(o => o.Product).ThenInclude(o => o.Category).Include(o => o.Order).Include(o => o.Customer).FirstOrDefaultAsync(o => o.OrderId == id);
            return _mapper.Map<OrderDetailsDto>(orderDetail);
        }

        public override async Task<OrderDetail> UpdateAsync(OrderDetailsDto dto)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(dto.OrderId);
            if (orderDetail != null)
            {
                _mapper.Map(dto, orderDetail);
                await _context.SaveChangesAsync();
            }
            return orderDetail;
        }
    }
}
