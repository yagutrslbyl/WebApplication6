using WebApplication6.Models.Base;

namespace WebApplication6.Models
{
    public class Review : BaseEntity
    {
      

        public string UserName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }   // 1–5

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
