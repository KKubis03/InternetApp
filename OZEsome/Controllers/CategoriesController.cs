using Microsoft.AspNetCore.Mvc;

namespace OZEsome.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Client _client;

        public CategoriesController(Client client)
        {
            _client = client;
        }

        // GET: Categories
        public async Task<IActionResult> Index(string searchString)
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

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var category = await _client.CategoriesGETAsync(id);
            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] NewCategoryDto category)
        {
            try
            {
                await _client.CategoriesPOSTAsync(category);
            }
            catch(Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            CategoryDto category = new CategoryDto();
            try
            {
                category = await _client.CategoriesGETAsync(id);
            }
            catch(Exception ex)
            {
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CategoryName")] CategoryDto category)
        {
            try
            {
                await _client.CategoriesPUTAsync(id, category);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _client.CategoriesDELETEAsync(id);
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
