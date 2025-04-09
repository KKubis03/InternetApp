using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OZEsome.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly Client _client;
        public OrderDetailsController(Client client)
        {
            _client = client;
        }
        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            return View(await _client.OrderDetailsAllAsync());
        }
        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var details = await _client.OrderDetailsGETAsync(id);
            return View(details);
        }
        // GET: Meetings/Create
        public async Task<IActionResult> Create()
        {
            //ViewBag.Details = new SelectList((await _client.OrderDetailsAllAsync())
            //    .Select(c => new { c.Id, FullName = c.FirstName + " " + c.LastName }), "Id", "FullName");
            return View();
        }
    }
}
