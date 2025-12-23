using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        AppDbContext _context;
        IWebHostEnvironment _environment;
        public ProductController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Table()
        {
            var slider=_context.Sliders.ToList();
            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)

        {
            if (!(slider.ImageFile.ContentType.Contains("image")))
            {
                ModelState.AddModelError("ImageFile", "File type must be image");
                return View();
            }

            if (!(slider.ImageFile.Length > 2 * 1024 * 1024))
            {
                ModelState.AddModelError("ImageFile", "Max File Lenght is 2mb");
                return View();
            }
            string path = Path.Combine(_environment.WebRootPath, "uploadedFiles/Slider");
           
            string fileName = slider.ImageFile.FileName;
            string fullPath=Path.Combine(path, fileName);

            using(FileStream stream=new FileStream(fullPath, FileMode.Create))
            {
                slider.ImageFile.CopyTo (stream);
            };

            slider.ImageUrl = fileName;

            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product=_context.Sliders.Find(id);
            if (product == null) return NotFound();
            _context.Sliders.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
