using Microsoft.AspNetCore.Mvc;

namespace OZEsome.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly Client _client;

        public DocumentsController(Client client)
        {
            _client = client;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            return View(await _client.DocumentsAllAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var document = await _client.DocumentsGETAsync(id);
            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Id,FileName,FilePath")] DocumentDto document)
        {
            try
            {
                await _client.DocumentsPOSTAsync(document);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            DocumentDto document = new DocumentDto();
            try
            {
                document = await _client.DocumentsGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,FileName,FilePath")] DocumentDto document)
        {
            try
            {
                await _client.DocumentsPUTAsync(id, document);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            DocumentDto document = new DocumentDto();
            try
            {
                document = await _client.DocumentsGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _client.DocumentsDELETEAsync(id);
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
