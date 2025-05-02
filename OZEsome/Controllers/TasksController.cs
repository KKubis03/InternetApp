using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OZEsome.Controllers
{
    public class TasksController : Controller
    {
        private readonly Client _client;

        public TasksController(Client client)
        {
            _client = client;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(await _client.TasksAllAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var task = await _client.TasksGETAsync(id);
            return View(task);
        }

        // GET: Tasks/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,TaskStatus,Content,Deadline")] NewTaskDto task)
        {
            try
            {
                await _client.TasksPOSTAsync(task);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.TaskStatusses = new SelectList((await _client.Statusses3Async()), "Id", "StatusName");
            TaskDto task = new TaskDto();
            try
            {
                task = await _client.TasksGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Content,Deadline,TaskStatusId,TaskStatusName")] TaskDto task)
        {
            try
            {
                await _client.TasksPUTAsync(id, task);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            TaskDto task = new TaskDto();
            try
            {
                task = await _client.TasksGETAsync(id);
            }
            catch (Exception ex)
            {
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _client.TasksDELETEAsync(id);
                RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
