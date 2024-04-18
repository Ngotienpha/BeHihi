using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebBaoDoi.Areas.Identity.Data;
using static System.Net.Mime.MediaTypeNames;

namespace WebBaoDoi.Controllers
{
    public class UsersController : Controller
    {
        private DBContextSample _application;
        public UsersController(DBContextSample application)
        {
            _application = application;
        }

        public IActionResult Index()
        {
            return View(_application.Users.ToList());
        }

        public IActionResult Delete(string id) 
        {
            return View(_application.Users.ToList());
        }
    }
}
