using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.D3.Examples.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult D3Tree()
        {
            return View();
        }
    }
}