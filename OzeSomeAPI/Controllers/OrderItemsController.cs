using Microsoft.AspNetCore.Mvc;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models.Dtos.New;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly OrderItemService _orderItemService;
        public OrderItemsController(OrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetOrderItems(Guid orderId)
        {
            var orderItemsDto = await _orderItemService.GetAllAsync(orderId);
            return Ok(orderItemsDto);
        }
        // GET: api/OrderItems
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetAllOrderItems()
        {
            var orderItemsDto = await _orderItemService.GetAllAsync();
            return Ok(orderItemsDto);
        }
        // GET: api/OrdersItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetOrderItem(Guid id)
        {
            var orderDto = await _orderItemService.GetByIdAsync(id);
            if (orderDto == null)
            {
                return NotFound();
            }
            return Ok(orderDto);
        }
        // POST: api/OrderItems
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrderItem(NewOrderItemDto orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderItemDtoCreated = await _orderItemService.CreateAsync(orderItem);
            if (orderItemDtoCreated == null)
            {
                return BadRequest("Nie udało się stworzyć zamówienia");
            }
            return CreatedAtAction("GetOrderItem", new { id = orderItemDtoCreated.Id }, orderItem);
        }
        // Put: api/OrderItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(Guid id, OrderItemDto orderItemDto)
        {
            if (id != orderItemDto.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedOrderItem = await _orderItemService.UpdateAsync(orderItemDto);
                if (updatedOrderItem == null)
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
        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var result = await _orderItemService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
