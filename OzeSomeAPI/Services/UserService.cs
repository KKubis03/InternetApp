using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;

namespace OzeSomeAPI.Services
{
    public class UserService : BaseService<User, UserDto>
    {
        public UserService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<UserDto> CreateAsync(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.CreationDateTime = DateTime.UtcNow;
            user.IsActive = true;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            user.IsActive = false;
            user.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _context.Users.Where(u => u.IsActive).ToListAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return usersDto;
        }

        public override async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.IsActive == true);
            return _mapper.Map<UserDto>(user);
        }

        public override async Task<User> UpdateAsync(UserDto dto)
        {
            var user = await _context.Users.FindAsync(dto.Id);
            if (user != null)
            {
                _mapper.Map(dto, user);
                user.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return user;
        }
    }
}
