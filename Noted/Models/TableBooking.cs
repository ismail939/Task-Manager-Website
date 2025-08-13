using System.ComponentModel.DataAnnotations;

namespace Noted.Models
{
    public class TableBooking
    {
        [Key]
        public int BookingId { get; set; }
        
        [Required]
        public int TableNumber { get; set; }
        
        [Required]
        public int ClientId { get; set; }
        
        [Required]
        public DateTime BookingDate { get; set; }
        
        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }
        
        public string? Notes { get; set; } // Optional notes for the booking
    }
}