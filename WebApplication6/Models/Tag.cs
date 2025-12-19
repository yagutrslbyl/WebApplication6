using WebApplication6.Models.Base;

namespace WebApplication6.Models
{
    public class Tag: BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
