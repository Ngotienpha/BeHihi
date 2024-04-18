using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WebBaoDoi.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            if (!string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password)) 
            {
                return RedirectToAction("Login");
            }

            ClaimsIdentity identity = null;
            bool isAuthenticate = true;
            if (Email=="Admin@gmail.com" && Password=="Admin@123") 
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Email),
                    new Claim(ClaimTypes.Role,"Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            if (Email == "lykimanh@gmail.com" && Password == "Kimanh@123")
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Email),
                    new Claim(ClaimTypes.Role,"Student")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            if (Email == "luuminhhuy@gmail.com" && Password == "Minhhuy@123")
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Email),
                    new Claim(ClaimTypes.Role,"Coordinator")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            if (Email == "manager@gmail.com" && Password == "Manage@123")
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Email),
                    new Claim(ClaimTypes.Role,"Manage")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
