using Microsoft.AspNetCore.Mvc;

namespace SignalR_Project1.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
