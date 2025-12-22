using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL;
using WebApplication6.VM;

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
           .Include(p => p.Categories)
           .FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var categoryIds=product.Categories
                .Select(c=> c.Id)
                .ToList();

            var relatedProducts=_context.Products
                .Include(p => p.Categories)
                .Where(p=>
                p.Id!= id &&
                p.Categories.Any(c=>categoryIds.Contains(c.Id))).ToList();

            var reviews = _context.Reviews.Where(r => r.Id == id).ToList();

            var vm = new ProductDetailsVM
            {
                Product = product,
                RelatedProducts = relatedProducts,
                Images = product.Images.ToList(),
                Reviews=reviews
            };

            return View(vm);
           
        }
    }
}
