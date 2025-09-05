using System.ComponentModel.DataAnnotations;
namespace Noted.Models;

public class Photo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Source { get; set; }

    [Required]
    public string Page { get; set; }

    [Required]
    public string LocationInPage { get; set; }
}