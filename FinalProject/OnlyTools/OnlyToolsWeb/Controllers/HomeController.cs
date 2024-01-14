using Microsoft.AspNetCore.Mvc;
using OnlyToolsWeb.Models;
using System.Diagnostics;

namespace OnlyToolsWeb.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult RentTools()
        {
            return View();
        }
        public IActionResult ShareTools()
        {
            return View();
        }
        public IActionResult BrowseTips()
        {
            return View();
        }
        public IActionResult ShareTips()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult Register()
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
