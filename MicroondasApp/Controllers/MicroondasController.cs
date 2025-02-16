using Microsoft.AspNetCore.Mvc;

namespace MicroondasApp.Controllers
{
    public class MicroondasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
