using WebApplication6.Models.Base;

namespace WebApplication6.Models
{
    public class Image: BaseEntity
    {
        public string ImageUrl { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
