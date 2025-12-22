using WebApplication6.Models;

namespace WebApplication6.VM
{
    public class ProductDetailsVM
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public List<Image> Images { get; set; }
        public List<Review> Reviews { get; set; }
        public Review NewReview { get; set; }
    }
}
