using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;

namespace OzeSomeAPI.Services
{
    public class ContractService : BaseService<Contract, ContractDto>
    {
        public ContractService(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override async Task<ContractDto> CreateAsync(ContractDto dto)
        {
            var contract = _mapper.Map<Contract>(dto);
            contract.CreationDateTime = DateTime.UtcNow;
            contract.IsActive = true;
            await _context.Contracts.AddAsync(contract);
            await _context.SaveChangesAsync();
            return _mapper.Map<ContractDto>(contract);
        }
        public override async Task<bool> DeleteAsync(Guid id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return false;
            }
            contract.IsActive = false;
            contract.DeleteDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
        public override async Task<IEnumerable<ContractDto>> GetAllAsync()
        {
            var contracts = await _context.Contracts.Include(c => c.Order).Include(c => c.Customer).Where(c => c.IsActive).ToListAsync();
            var contractsDto = _mapper.Map<IEnumerable<ContractDto>>(contracts);
            return contractsDto;
        }
        public override async Task<ContractDto> GetByIdAsync(Guid id)
        {
            var contract = await _context.Contracts.Include(c => c.Order).Include(c => c.Customer).FirstOrDefaultAsync(c => c.Id == id && c.IsActive == true);
            return _mapper.Map<ContractDto>(contract);
        }
        public override async Task<Contract> UpdateAsync(ContractDto dto)
        {
            var contract = await _context.Contracts.FindAsync(dto.Id);
            if (contract != null)
            {
                _mapper.Map(dto, contract);
                contract.EditDateTime = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return contract;
        }
    }
}
