using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;

namespace OzeSomeAPI.Services
{
    public class OrderDetailsService : BaseService<OrderDetail, OrderDetailsDto>
    {
        public OrderDetailsService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<OrderDetailsDto> CreateAsync(OrderDetailsDto dto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(dto);
            orderDetail.CreationDateTime = DateTime.UtcNow;
            orderDetail.IsActive = true;
            orderDetail.Quantity = dto.Quantity;
            var price = await _context.Products.Where(o => o.Id == dto.ProductId).Select(o => o.Price).FirstOrDefaultAsync();
            orderDetail.TotalAmount = price * orderDetail.Quantity;
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDetailsDto>(orderDetail);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return false;
            }
            orderDetail.IsActive = false;
            orderDetail.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<OrderDetailsDto>> GetAllAsync()
        {
            var orderDetails = await _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).ThenInclude(o => o.Category).Include(o => o.Customer).Where(o => o.IsActive).ToListAsync();
            var orderDetailsDto = _mapper.Map<IEnumerable<OrderDetailsDto>>(orderDetails);
            return orderDetailsDto;
        }

        public override async Task<OrderDetailsDto> GetByIdAsync(Guid id)
        {
            var orderDetail = await _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).ThenInclude(o => o.Category).Include(o => o.Customer).FirstOrDefaultAsync(o => o.Id == id && o.IsActive == true);
            return _mapper.Map<OrderDetailsDto>(orderDetail);
        }

        public override async Task<OrderDetail> UpdateAsync(OrderDetailsDto dto)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(dto.Id);
            if (orderDetail != null)
            {
                _mapper.Map(dto, orderDetail);
                orderDetail.EditDateTime = DateTime.UtcNow;
                orderDetail.Quantity = dto.Quantity;
                var price = await _context.Products.Where(o => o.Id == dto.ProductId).Select(o => o.Price).FirstOrDefaultAsync();
                orderDetail.TotalAmount = price * orderDetail.Quantity;
                await _context.SaveChangesAsync();
            }
            return orderDetail;
        }
    }
}
