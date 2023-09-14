using Microsoft.AspNetCore.Mvc;

namespace PosSystem.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
