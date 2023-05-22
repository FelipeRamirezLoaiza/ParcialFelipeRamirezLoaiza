using Microsoft.AspNetCore.Mvc;

namespace WebPages.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
