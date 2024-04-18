using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using System.Net.Mail;
using System.Net;
using WebBaoDoi.Areas.Identity.Data;
using WebBaoDoi.Models;

namespace WebBaoDoi.Controllers
{
    public class IdeaController : Controller
    {
        private readonly DBContextSample _context;
        public IdeaController(DBContextSample contextSample)
        {
            _context = contextSample;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Idea idea, IFormFile fileupload, List<IFormFile> imageUrls)
        {
            if (ModelState.IsValid)
            {
                if (fileupload != null)
                {
                    // Lưu hình ảnh đại diện
                    idea.ImageUrl = await SaveImage((IFormFile)imageUrls);
                }
                if (imageUrls != null)
                {
                    idea.ImageUrls = new List<string>();
                    foreach (var file in imageUrls)
                    {
                        // Lưu các hình ảnh khác
                        idea.ImageUrls.Add(await SaveImage(file));
                    }
                }
                _context.Add(idea);
                return RedirectToAction("Index");
            }
            return View(idea);
        }
        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName); 
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName; 
        }

        public IActionResult Index()
        {
            var ideas = _context.Idea;
            return View(ideas);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ideas = _context.Idea.FirstOrDefault(x => x.Id == id);
            if (ideas == null)
            {
                return NotFound();
            }
            return View(ideas);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideas = _context.Idea.Find(id);
            if (ideas == null)
            {
                return NotFound();
            }
            return View(ideas);
        }
        [HttpPost]
        public IActionResult Edit(int id, Idea ideas)
        {
            if (id != ideas.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(ideas);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ideas);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var ideas = _context.Idea.Find(id);
            if (ideas == null)
            {
                return NotFound();
            }
            _context.Idea.Remove(ideas);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideas = _context.Idea.Find(id);
            if (ideas == null)
            {
                return NotFound();
            }
            return View(ideas);
        }
        [HttpPost]
     
        public IActionResult Create(Idea ideas)
        {
            if (ModelState.IsValid)
            {
                _context.Idea.Add(ideas);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ideas);
        }
        public IActionResult Statistic()
        {
            var ideaByFaculty = new List<KeyValuePair<string, int>>();
            var Faculty = _context.Faculty.OrderBy(d => d.FacultyName).ToList();
            foreach(var faculty in Faculty)
            {
                var userIds = _context.Faculty.Where(u => u.FacultyId == faculty.FacultyId).Select(u => u.FacultyId).ToList();
                var ideas = _context.Idea.Where(i => userIds.Contains(i.Id)).ToList();
                var value = new KeyValuePair<string, int>(faculty.FacultyName, ideas.Count());
            }
            ViewBag.IdeaByFaculty = ideaByFaculty;
            ViewData["ideaByFaculty"] = ideaByFaculty;

            return View();
        }
    }
}

