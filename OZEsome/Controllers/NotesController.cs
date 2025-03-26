using Microsoft.AspNetCore.Mvc;

namespace OZEsome.Controllers
{
    public class NotesController : Controller
    {
        private readonly Client _client;

        public NotesController(Client client)
        {
            _client = client;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            return View(await _client.NotesAllAsync());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var note = await _client.NotesGETAsync(id);
            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content")] NoteDto note)
        {
            try
            {
                await _client.NotesPOSTAsync(note);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            NoteDto note = new NoteDto();
            try
            {
                note = await _client.NotesGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Content")] NoteDto note)
        {
            try
            {
                await _client.NotesPUTAsync(id, note);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            NoteDto note = new NoteDto();
            try
            {
                note = await _client.NotesGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _client.NotesDELETEAsync(id);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
