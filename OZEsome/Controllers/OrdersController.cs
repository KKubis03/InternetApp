using Microsoft.AspNetCore.Mvc;

namespace OZEsome.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Client _client;

        public OrdersController(Client client)
        {
            _client = client;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _client.OrdersAllAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var order = await _client.OrdersGETAsync(id);
            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
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

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(Guid id)
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

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OrderDate,OrderStatus")] OrderDto order)
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
    }
}
