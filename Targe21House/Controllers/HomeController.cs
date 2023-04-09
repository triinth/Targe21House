using Microsoft.AspNetCore.Mvc;

namespace Targe21House.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
