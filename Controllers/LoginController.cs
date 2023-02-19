using Dziennik_Zadan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dziennik_Zadan.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<LogowanieUser> _userManager;
        private readonly SignInManager<LogowanieUser> _signInManager;

        public LoginController(UserManager<LogowanieUser> userManager, SignInManager<LogowanieUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(Login log)
        {
            if (!ModelState.IsValid)
            {
                return View(log);
            }
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index2", "Zadania");
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
        public async Task<IActionResult> Register(Rejestracja rej)
        {
            if(!ModelState.IsValid)
            {
                return View(rej);
            }
            var newUser = new LogowanieUser
            {
                Email = rej.Email,
                UserName = rej.UserName
            };
            await _userManager.CreateAsync(newUser);

            return RedirectToAction("Index", "Zadania");
        }

    }
}
