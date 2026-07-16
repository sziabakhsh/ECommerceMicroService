using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
