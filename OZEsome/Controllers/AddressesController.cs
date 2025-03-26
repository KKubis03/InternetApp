using Microsoft.AspNetCore.Mvc;

namespace OZEsome.Controllers
{
    public class AddressesController : Controller
    {
        private readonly Client _client;

        public AddressesController(Client client)
        {
            _client = client;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            return View(await _client.AddressesAllAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var address = await _client.AddressesGETAsync(id);
            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,Number,Code,City,Country")] AddressDto address)
        {
            try
            {
                await _client.AddressesPOSTAsync(address);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            AddressDto address = new AddressDto();
            try
            {
                address = await _client.AddressesGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Street,Number,Code,City,Country")] AddressDto address)
        {
            try
            {
                await _client.AddressesPUTAsync(id, address);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            AddressDto address = new AddressDto();
            try
            {
                address = await _client.AddressesGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _client.AddressesDELETEAsync(id);
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
