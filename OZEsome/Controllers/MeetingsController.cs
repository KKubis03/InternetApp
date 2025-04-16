using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OZEsome.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly Client _client;

        public MeetingsController(Client client)
        {
            _client = client;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            return View(await _client.MeetingsAllAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var meeting = await _client.MeetingsGETAsync(id);
            return View(meeting);
        }

        // GET: Meetings/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Customers = new SelectList((await _client.CustomersAllAsync())
                .Select(c => new { c.Id, FullName = c.FirstName + " " + c.LastName }), "Id", "FullName");
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,MeetingDate,MeetingStatus")] MeetingDto meeting)
        {
            try
            {
                await _client.MeetingsPOSTAsync(meeting);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            MeetingDto meeting = new MeetingDto();
            try
            {
                meeting = await _client.MeetingsGETAsync(id);
                ViewBag.Customers = new SelectList((await _client.CustomersAllAsync())
                    .Select(c => new { c.Id, FullName = c.FirstName + " " + c.LastName }),"Id","FullName",id);
            }
            catch (Exception ex)
            {
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CustomerId,MeetingDate,MeetingStatus,CustomerFirstName,CustomerLastName")] MeetingDto meeting)
        {
            try
            {
                await _client.MeetingsPUTAsync(id, meeting);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            MeetingDto meeting = new MeetingDto();
            try
            {
                meeting = await _client.MeetingsGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _client.MeetingsDELETEAsync(id);
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
