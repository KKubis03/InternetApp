using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzeSome.Data.Models.Dtos;

namespace OZEsome.Controllers
{
    public class CustomersController : Controller
    {
        private readonly Client _client;
        public CustomersController(Client client)
        {
            _client = client;
        }
        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _client.CustomersAllAsync());
        }
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var customer = await _client.CustomersGETAsync(id);
            return View(customer);
        }
        // GET: Customers/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Addresses = new SelectList((await _client.AddressesAllAsync())
                .Select(c => new { c.Id, Address = c.Street + " " + c.Number + " " + c.City}), "Id", "Address");
            return View();
        }
        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, PhoneNumber, Email, AddressId")] NewCustomerDto customer)
        {
            try
            {
                await _client.CustomersPOSTAsync(customer);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            CustomerDto customer = new CustomerDto();
            try
            {
                customer = await _client.CustomersGETAsync(id);
                ViewBag.Addresses = new SelectList((await _client.AddressesAllAsync())
                    .Select(c => new { c.Id, Address = c.Street + " " + c.Number + " " + c.City }), "Id", "Address");
            }
            catch (Exception ex)
            {
            }
            return View(customer);
        }
        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, FirstName, LastName, PhoneNumber, Email, AddressId")] CustomerDto customer)
        {
            try
            {
                await _client.CustomersPUTAsync(id, customer);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            CustomerDto customer = new CustomerDto();
            try
            {
                customer = await _client.CustomersGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(customer);
        }
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _client.CustomersDELETEAsync(id);
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
