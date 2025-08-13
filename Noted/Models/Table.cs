using System.ComponentModel.DataAnnotations;

namespace Noted.Models
{
    public class Table
    {
        [Key]
        public int TableNumber { get; set; }
    }
}