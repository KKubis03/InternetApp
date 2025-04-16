using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzeSome.Data.Models.Dtos;

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
            return View(await _client.OrderDetailsAllAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var order = await _client.OrderDetailsGETAsync(id);
            return View(order);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> CreateDetailsAsync()
        {
            ViewBag.Customers = new SelectList((await _client.CustomersAllAsync())
                .Select(c => new { c.Id, FullName = c.FirstName + " " + c.LastName }), "Id", "FullName");
            ViewBag.Orders = new SelectList((await _client.OrdersAllAsync()).Where(c => c.OrderStatus != "Completed")
                .Select(c => new { c.Id, OrderData = c.OrderDate.Date.ToShortDateString() + " " + c.OrderStatus }), "Id", "OrderData");
            ViewBag.Products = new SelectList((await _client.ProductsAllAsync())
                .Select(c => new { c.Id, c.ProductName }), "Id", "ProductName");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,OrderStatus")] OrderDto order)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDetails([Bind("OrderId, CustomerId, ProductId, Quantity")] NewOrderDetailDto order)
        {
            try
            {
                await _client.OrderDetailsPOSTAsync(order);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            OrderDetailsDto order = new OrderDetailsDto();
            try
            {
                order = await _client.OrderDetailsGETAsync(id);
                ViewBag.Customers = new SelectList((await _client.CustomersAllAsync())
                    .Select(c => new { c.Id, FullName = c.FirstName + " " + c.LastName }), "Id", "FullName", id);
                ViewBag.Orders = new SelectList((await _client.OrdersAllAsync()).Where(c => c.OrderStatus != "Completed")
                .Select(c => new { c.Id, OrderData = c.OrderDate.Date.ToShortDateString() + " " + c.OrderStatus }), "Id", "OrderData");
                ViewBag.Products = new SelectList((await _client.ProductsAllAsync())
                    .Select(c => new { c.Id, c.ProductName }), "Id", "ProductName");
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OrderId, CustomerId, ProductId, Quantity")] OrderDetailsDto order)
        {
            try
            {
                await _client.OrderDetailsPUTAsync(id, order);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            OrderDetailsDto order = new OrderDetailsDto();
            try
            {
                order = await _client.OrderDetailsGETAsync(id);
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
                await _client.OrderDetailsDELETEAsync(id);
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
