using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBaoDoi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebBaoDoi.Areas.Identity.Data;


namespace WebBaoDoi.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly DBContextSample _context;
        public SubmissionController(DBContextSample contextSample) 
        {
            _context = contextSample;
        }
        // GET: SubmissionController
        public IActionResult Index()
        {
            var submissions = _context.Submission;
            return View(submissions);
        }

        // GET: SubmissionController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var submissions = _context.Submission.FirstOrDefault(x => x.Id == id);
            if (submissions == null)
            {
                return NotFound();
            }
            return View(submissions);
        }

        // GET: SubmissionController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubmissionController/Create
        [HttpPost]
        public ActionResult Create(Submission submissions)
        {
            if (ModelState.IsValid)
            {
                _context.Submission.Add(submissions);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(submissions);
        }

        // GET: SubmissionController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submissions = _context.Submission.Find(id);
            if (submissions == null)
            {
                return NotFound();
            }
            return View(submissions);
        }

        // POST: SubmissionController/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Submission submissions)
        {
            if (id != submissions.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(submissions);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(submissions);
        }

        // GET: SubmissionController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submissions = _context.Submission.Find(id);
            if (submissions == null)
            {
                return NotFound();
            }
            return View(submissions);
        }

        // POST: SubmissionController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var submissions = _context.Submission.Find(id);
            if (submissions == null)
            {
                return NotFound();
            }
            _context.Submission.Remove(submissions);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
