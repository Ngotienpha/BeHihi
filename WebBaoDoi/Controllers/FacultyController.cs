using Microsoft.AspNetCore.Mvc;
using WebBaoDoi.Models;
using WebBaoDoi.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace WebBaoDoi.Controllers
{
    public class FacultyController : Controller
    {
        private readonly DBContextSample _context;

        public FacultyController(DBContextSample contextSample) 
        {
            _context = contextSample;
        }
        public IActionResult Index()
        {
            var faculties = _context.Faculty;
            return View(faculties);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var faculties = _context.Faculty.FirstOrDefault(x => x.FacultyId == id);
            if(faculties == null)
            {
                return NotFound();
            }
            return View(faculties);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculties = _context.Faculty.Find(id);
            if(faculties == null)
            {
                return NotFound();
            }
            return View(faculties);
        }
        [HttpPost]
        public IActionResult Edit(int id, Faculty faculties)
        {
             if(id != faculties.FacultyId)
            {
                return NotFound();
            }
             if(ModelState.IsValid)
            {
                _context.Update(faculties);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
             return View(faculties);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var faculties = _context.Faculty.Find(id);
            if(faculties == null)
            {
                return NotFound();
            }
            _context.Faculty.Remove(faculties);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculties = _context.Faculty.Find(id);
            if (faculties == null)
            {
                return NotFound();
            }
            return View(faculties);
        }
        [HttpPost]
        public IActionResult Create(Faculty faculties)
        {
             if(ModelState.IsValid)
            {
                _context.Faculty.Add(faculties);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
             return View(faculties);
        }
    }
}
