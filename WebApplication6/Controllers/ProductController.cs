using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL;

namespace WebApplication6.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Images)
           .Include(p => p.Tags)
           .FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
           
        }
    }
}
