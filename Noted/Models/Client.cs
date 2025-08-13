using System.ComponentModel.DataAnnotations;
namespace Noted.Models;

public class Client
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }
    
    [Required, DataType(DataType.Password)]
    public  string Password { get; set; }
}
