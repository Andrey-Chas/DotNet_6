using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TempData.Extension;
using TempData.Models;

namespace TempData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("s1", 1);
            TempData["SecretCode"] = "Index";
            var student = new Student { FirstName = "John", LastName = "Smith" };
            HttpContext.Session.Set("s1", student);
            return View();
        }

        public IActionResult Privacy()
        {
            var n = HttpContext.Session.GetInt32("s1");
            var s = TempData["SecretCode"];
            var student = HttpContext.Session.Get("s1");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}