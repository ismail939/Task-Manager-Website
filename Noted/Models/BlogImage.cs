using System.ComponentModel.DataAnnotations;

namespace Noted.Models
{
    public class BlogImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; }
    }

}