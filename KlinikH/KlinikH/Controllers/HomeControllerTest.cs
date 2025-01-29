using KlinikH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KlinikH.Controllers
{
    public class HomeControllerTest : Controller
    {
        private readonly ILogger<HomeControllerTest> _logger;

        public HomeControllerTest(ILogger<HomeControllerTest> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
