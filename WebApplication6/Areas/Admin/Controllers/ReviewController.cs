using Microsoft.AspNetCore.Mvc;
using WebApplication6.Areas.Admin.ViewModels.Review;
using WebApplication6.DAL;
using WebApplication6.Models;


namespace WebApplication6.Areas.Admin.Controllers
        
{
        [Area("Admin")]

public class ReviewController : Controller
    {

        AppDbContext _context;
        public ReviewController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var review = _context.Reviews.ToList();
            return View(review);
        }

        public IActionResult Create()
        {
            ViewBag.Products=_context.Products.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateReviewVM reviewVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Products = _context.Products.ToList();
                return View();
            }
            Review review = new Review()
            {
                Comment = reviewVM.Comment,
                ProductId = reviewVM.ProductId
            };
            _context.Reviews.Add(review);
            _context.SaveChanges();

           return RedirectToAction("Index");
        }
    }
}
