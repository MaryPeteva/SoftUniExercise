using Microsoft.AspNetCore.Mvc;
using static OnlyToolsWeb.Models.AccountViewModels;

namespace OnlyToolsWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // Validate login and handle authentication
            // Redirect to the appropriate page upon successful login
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            // Validate registration, create user, and handle registration logic
            // Redirect to the appropriate page upon successful registration
            return RedirectToAction("Login", "Account");
        }
    }
}

