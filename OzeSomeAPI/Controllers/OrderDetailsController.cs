using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Contexts;
using OzeSome.Data.Models.Dtos;
using OzeSomeAPI.Services;

namespace OzeSomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsService _orderDetailsService;

        public OrderDetailsController(OrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailsDto>>> GetOrderDetails()
        {
            var orderDetailsDto = await _orderDetailsService.GetAllAsync();
            return Ok(orderDetailsDto);
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderDetail(Guid id)
        {
            var orderDetailDto = await _orderDetailsService.GetByIdAsync(id);
            if (orderDetailDto == null)
            {
                return NotFound();
            }
            return Ok(orderDetailDto);
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(Guid id, OrderDetailsDto orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return BadRequest();
            }
            try
            {
                var updatedOrderDetail = await _orderDetailsService.UpdateAsync(orderDetail);
                if (updatedOrderDetail == null)
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

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetailsDto>> PostOrderDetail(OrderDetailsDto orderDetail)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdOrderDetail = await _orderDetailsService.CreateAsync(orderDetail);
            if (createdOrderDetail == null)
            {
                return StatusCode(500, "Error creating order detail");
            }
            return CreatedAtAction("GetOrderDetail", new { id = createdOrderDetail.Id }, createdOrderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(Guid id)
        {
            var deletedOrderDetail = await _orderDetailsService.DeleteAsync(id);
            if (deletedOrderDetail == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
