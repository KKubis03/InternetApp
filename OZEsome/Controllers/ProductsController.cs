using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Index(string searchString)
        {
            var products = await _client.ProductsAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products
                    .Where(c => c.ProductName.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }
            return View(products);
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
            ViewBag.Categories = new SelectList(await _client.SelectList2Async(), "Id", "DisplayName");
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
        // GET: Categories
        public async Task<IActionResult> Categories(string searchString)
        {
            var categories = await _client.CategoriesAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories
                    .Where(c => c.CategoryName.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }
            return View(categories);
        }
        // GET: Categories/Create
        public IActionResult CategoriesCreate()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoriesCreate([Bind("Id,CategoryName")] NewCategoryDto category)
        {
            try
            {
                await _client.CategoriesPOSTAsync(category);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Categories));
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> CategoriesEdit(Guid id)
        {
            CategoryDto category = new CategoryDto();
            try
            {
                category = await _client.CategoriesGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoriesEdit(Guid id, [Bind("Id,CategoryName")] CategoryDto category)
        {
            try
            {
                await _client.CategoriesPUTAsync(id, category);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Categories));
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> CategoriesDelete(Guid id)
        {
            CategoryDto category = new CategoryDto();
            try
            {
                category = await _client.CategoriesGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoryConfirmed(Guid id)
        {
            try
            {
                await _client.CategoriesDELETEAsync(id);
                RedirectToAction(nameof(Categories));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Categories));
        }
    }
}
