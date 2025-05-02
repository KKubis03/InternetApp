using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzeSome;

namespace OZEsome.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Client _client;

        public OrdersController(Client client)
        {
            _client = client;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            return View(await _client.OrdersAllAsync());
        }
        // GET: OrderDetails
        public async Task<IActionResult> Details(Guid id)
        {
            var order = await _client.OrdersGETAsync(id);
            var orderItems = await _client.OrderItemsAllAsync(id);
            OrderWithItems orderWithItems = new OrderWithItems()
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate.Date,
                OrderStatusId = order.OrderStatusId,
                OrderStatusName = order.OrderStatusName,
                CustomerId = order.CustomerId,
                CustomerFirstName = order.CustomerFirstName,
                CustomerLastName = order.CustomerLastName,
                OrderItems = orderItems
            };
            foreach (var item in orderWithItems.OrderItems)
            {
                orderWithItems.Total += (decimal)item.ProductPrice * item.Quantity;
            }
            return View(orderWithItems);
        }
        // GET: Orders/NewItem
        public async Task<IActionResult> NewItem(Guid id)
        {
            ViewBag.Products = new SelectList(await _client.SelectList4Async(), "Id", "DisplayName");
            NewOrderItemDto newOrderItemdto = new();
            try
            {
                newOrderItemdto.OrderId = id;
            }
            catch (Exception ex)
            {
            }
            return View(newOrderItemdto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewItem([Bind("OrderId,ProductId,Quantity")] NewOrderItemDto orderitem)
        {
            try
            {
                await _client.OrderItemsPOSTAsync(orderitem);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Details), new { id = orderitem.OrderId });
        }
        // GET: OrderItem/Edit/5
        public async Task<IActionResult> EditOrderItem(Guid id)
        {
            OrderItemDto orderItem = new();
            try
            {
                orderItem = await _client.OrderItemsGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(orderItem);
        }
        // POST: OrderItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrderItem(Guid id, [Bind("Id,Quantity,OrderId,ProductId,ProductName,ProductCategoryName,ProductPrice")] OrderItemDto orderItem)
        {
            try
            {
                await _client.OrderItemsPUTAsync(id, orderItem);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Details), new { id = orderItem.OrderId });
        }
        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Customers = new SelectList(await _client.SelectList3Async(), "Id", "DisplayName");
            ViewBag.OrderStatusses = new SelectList(await _client.Statusses2Async(), "Id", "StatusName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,OrderDate,OrderStatusId")] NewOrderDto order)
        {
            try
            {
                await _client.OrdersPOSTAsync(order);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Customers = new SelectList(await _client.SelectList3Async(), "Id", "DisplayName");
            ViewBag.OrderStatusses = new SelectList(await _client.Statusses2Async(), "Id", "StatusName");
            OrderDto order = new OrderDto();
            try
            {
                order = await _client.OrdersGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(order);
        }
        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CustomerId,OrderDate,OrderStatusId")] OrderDto order)
        {
            try
            {
                await _client.OrdersPUTAsync(id, order);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            OrderDto order = new OrderDto();
            try
            {
                order = await _client.OrdersGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(order);
        }
        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _client.OrdersDELETEAsync(id);
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: OrderItems/Delete/5
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            OrderItemDto orderItem = new();
            try
            {
                orderItem = await _client.OrderItemsGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(orderItem);
        }
        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("DeleteOrderItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrderItemConfirmed(Guid id)
        {
            OrderItemDto item = new();
            try
            {
                //OrderItemDto item = new();
                item = await _client.OrderItemsGETAsync(id);
                await _client.OrderItemsDELETEAsync(id);
                RedirectToAction(nameof(Details), new { id = item.OrderId });
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Details), new { id = item.OrderId });
        }
    }
}
