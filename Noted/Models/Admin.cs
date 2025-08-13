using System.ComponentModel.DataAnnotations;

namespace Noted.Models
{
    public class Admin
    {
        [Key][Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}

