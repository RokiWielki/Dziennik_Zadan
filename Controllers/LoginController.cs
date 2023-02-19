using Dziennik_Zadan.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dziennik_Zadan.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Rejestracja rej)
        {
            if(!ModelState.IsValid)
            {
                return View(rej);
            }

            return RedirectToAction("Index", "Zadania");
        }

    }
}
