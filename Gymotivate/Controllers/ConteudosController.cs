using Microsoft.AspNetCore.Mvc;

namespace Gymotivate.Controllers
{
    public class ConteudosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
