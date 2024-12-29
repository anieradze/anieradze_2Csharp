using Microsoft.AspNetCore.Mvc;
using Practice3.Models;
using System.Diagnostics;

namespace Practice3.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = "Data Source=DESKTOP-AIFFBA0\\SQLEXPRESS;Initial Catalog=Orders;Integrated Security=True;Trust Server Certificate=True";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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
