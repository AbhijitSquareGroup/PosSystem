using Microsoft.AspNetCore.Mvc;

namespace PosSystem.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
