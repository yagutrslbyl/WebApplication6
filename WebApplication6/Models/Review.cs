using WebApplication6.Models.Base;

namespace WebApplication6.Models
{
    public class Review : BaseEntity
    {
      

        public string UserName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }   
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
