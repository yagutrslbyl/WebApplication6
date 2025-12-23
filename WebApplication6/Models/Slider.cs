using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
    }
}
