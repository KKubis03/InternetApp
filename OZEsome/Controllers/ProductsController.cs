using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzeSome.Data.Models.Dtos;

namespace OZEsome.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Client _client;

        public ProductsController(Client client)
        {
            _client = client;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _client.ProductsAllAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _client.ProductsGETAsync(id);
            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _client.CategoriesAllAsync(), "Id", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,CategoryId,Price")] NewProductDto product)
        {
            try
            {
                await _client.ProductsPOSTAsync(product);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Categories = new SelectList(await _client.CategoriesAllAsync(), "Id", "CategoryName");
            ProductDto product = new ProductDto();
            try
            {
                product = await _client.ProductsGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductName,CategoryId,Price")] ProductDto product)
        {
            try
            {
                await _client.ProductsPUTAsync(id, product);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            ProductDto product = new ProductDto();
            try
            {
                product = await _client.ProductsGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _client.ProductsDELETEAsync(id);
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
