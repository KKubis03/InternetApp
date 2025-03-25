using Microsoft.AspNetCore.Mvc;
using OzeSome.Data.Models.Dtos;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly ContractService _contractService;

        public ContractsController(ContractService contractService)
        {
            _contractService = contractService;
        }

        // GET: api/Contracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractDto>>> GetContracts()
        {
            var contractsDto = await _contractService.GetAllAsync();
            return Ok(contractsDto);
        }

        // GET: api/Contracts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractDto>> GetContract(Guid id)
        {
            var contractDto = await _contractService.GetByIdAsync(id);
            if (contractDto == null)
            {
                return NotFound();
            }
            return Ok(contractDto);
        }

        // PUT: api/Contracts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContract(Guid id, ContractDto contract)
        {
            if (id != contract.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedContract = await _contractService.UpdateAsync(contract);
                if (updatedContract == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return NoContent();
        }

        // POST: api/Contracts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContractDto>> PostContract(ContractDto contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdContract = await _contractService.CreateAsync(contract);
            if (createdContract == null)
            {
                return StatusCode(500, "Error creating contract");
            }
            return CreatedAtAction("GetContract", new { id = createdContract.Id }, createdContract);
        }

        // DELETE: api/Contracts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(Guid id)
        {
            var deletedContract = await _contractService.DeleteAsync(id);
            if (deletedContract == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
