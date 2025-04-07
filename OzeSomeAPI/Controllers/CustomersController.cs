using Microsoft.AspNetCore.Mvc;
using OzeSome.Data.Models.Dtos;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customersDto = await _customerService.GetAllAsync();
            return Ok(customersDto);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(Guid id)
        {
            var customerDto = await _customerService.GetByIdAsync(id);
            if (customerDto == null)
            {
                return NotFound();
            }
            return Ok(customerDto);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, CustomerDto customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedCustomer = await _customerService.UpdateAsync(customerDto);
                if (updatedCustomer == null)
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

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> PostCustomer(NewCustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = new CustomerDto
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                PhoneNumber = customerDto.PhoneNumber,
                Email = customerDto.Email,
                AddressId = customerDto.AddressId,
            };
            var customerDtoCreated = await _customerService.CreateAsync(customer);
            if (customerDtoCreated == null)
            {
                return BadRequest("Nie udało się utworzyć klienta");
            }
            return CreatedAtAction("GetCustomer", new { id = customerDtoCreated.Id }, customerDto);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await _customerService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
