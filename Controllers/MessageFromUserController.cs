using Microsoft.AspNetCore.Mvc;

namespace Consulting_Server.Controllers
{
    public class MessageFromUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
