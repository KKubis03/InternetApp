    using Microsoft.AspNetCore.Mvc;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models.Dtos.New;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressesController(AddressService addressService)
        {
            _addressService = addressService;
        }
        // GET: api/Addresses/selectList
        [HttpGet("selectList")]
        public async Task<ActionResult<IEnumerable<SelectDto>>> GetSelectList()
        {
            var selectList = await _addressService.GetSelectList();
            return Ok(selectList);
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAddresses()
        {
            var addressesDto = await _addressService.GetAllAsync();
            return Ok(addressesDto);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> GetAddress(Guid id)
        {
            var addressDto = await _addressService.GetByIdAsync(id);
            if (addressDto == null)
            {
                return NotFound();
            }
            return Ok(addressDto);
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(Guid id, AddressDto addressDto)
        {
            if (id != addressDto.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedAddress = await _addressService.UpdateAsync(addressDto);
                if (updatedAddress == null)
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddressDto>> PostAddress(NewAddressDto addressDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addressDtoCreated = await _addressService.CreateAsync(addressDto);
            if (addressDtoCreated == null)
            {
                return BadRequest("Nie udało się utworzyć adresu");
            }
            return CreatedAtAction("GetAddress", new { id = addressDtoCreated.Id }, addressDtoCreated);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            var result = await _addressService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
