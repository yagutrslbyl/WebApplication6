using WebApplication6.Models.Base;

namespace WebApplication6.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
        public List<Image> Images { get; set; }
    }
}
