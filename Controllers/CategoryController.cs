using Microsoft.AspNetCore.Mvc;

namespace Students.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
