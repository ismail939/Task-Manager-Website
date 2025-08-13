using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Noted.Models
{
    [Index(nameof(TableNumber), IsUnique = true)]
    public class Table
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Table number is required.")]
        public int TableNumber { get; set; }
    }
}