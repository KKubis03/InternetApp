using Microsoft.AspNetCore.Mvc;
using OzeSome.Data.Models.Dtos;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var ordersDto = await _orderService.GetAllAsync();
            return Ok(ordersDto);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id)
        {
            var orderDto = await _orderService.GetByIdAsync(id);
            if (orderDto == null)
            {
                return NotFound();
            }
            return Ok(orderDto);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(Guid id, OrderDto orderDto)
        {
            if(id != orderDto.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedOrder = await _orderService.UpdateAsync(orderDto);
                if (updatedOrder == null)
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder(OrderDto orderDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderDtoCreated = await _orderService.CreateAsync(orderDto);
            if(orderDtoCreated == null)
            {
                return BadRequest("Nie udało się stworzyć zamówienia");
            }
            return CreatedAtAction("GetOrder", new { id = orderDtoCreated.Id }, orderDtoCreated);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var result = await _orderService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
