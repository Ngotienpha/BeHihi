using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBaoDoi.Areas.Identity.Data;

namespace WebBaoDoi.Controllers
{
    public class StudentSubmissionController : Controller
    {
        private readonly DBContextSample _context;
        public StudentSubmissionController(DBContextSample contextSample)
        {
            _context = contextSample;
        }

        public IActionResult ViewIndex()
        {
            var submissions = _context.Submission;
            return View(submissions);
        }
        public IActionResult ExportZip()
        {
            string[] filePaths = new string[] { "path/to/file1.txt", "path/to/file2.txt" };
            using(MemoryStream  zipStream = new MemoryStream()) 
            { 
                using(ZipOutputStream zipOutputStream = new ZipOutputStream(zipStream))
                {
                    foreach(string filePath in filePaths)
                    {
                        string fileName = Path.GetFileName(filePath);
                        ZipEntry entry= new ZipEntry(fileName);
                        zipOutputStream.PutNextEntry(entry);
                        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                        zipOutputStream.Write(fileBytes, 0, fileBytes.Length);
                    }
                }
                byte[] zipBytes = zipStream.ToArray();
                return File(zipBytes, "application/zip","exported_files.zip");
            }
        }
    }
}
