using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;

namespace OzeSomeAPI.Services
{
    public class AddressService : BaseService<Address, AddressDto>
    {
        public AddressService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<AddressDto> CreateAsync(AddressDto dto)
        {
            var address = _mapper.Map<Address>(dto);
            address.CreationDateTime = DateTime.UtcNow;
            address.IsActive = true;
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return _mapper.Map<AddressDto>(address);
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return false;
            }
            address.IsActive = false;
            address.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var addresses = await _context.Addresses.Where(a => a.IsActive).ToListAsync();
            var addressesDto = _mapper.Map<IEnumerable<AddressDto>>(addresses);
            return addressesDto;
        }

        public override async Task<AddressDto> GetByIdAsync(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id && a.IsActive == true);
            return _mapper.Map<AddressDto>(address);
        }

        public override async Task<Address> UpdateAsync(AddressDto dto)
        {
            var address = await _context.Addresses.FindAsync(dto.Id);
            if (address != null)
            {
                _mapper.Map(dto, address);
                address.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return address;
        }
    }
}
