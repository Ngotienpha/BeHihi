using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Diagnostics;
using System.Net.Mail;
using System.Security.Claims;
using WebBaoDoi.Areas.Identity.Data;
using WebBaoDoi.Models;

namespace WebBaoDoi.Controllers
{
    public class HomeController : Controller
    {
        private DBContextSample _application;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DBContextSample application)
        {
            _logger = logger;
            _application = application;
        }
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Manage")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
